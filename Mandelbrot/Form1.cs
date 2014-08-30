using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Threading;
using System.Drawing.Imaging;

namespace Mandelbrot
{
    public partial class frmMandelbrot : Form
    {
        Bitmap mandelbrot;

        private int width = 1920;
        private int height = 1080;
        private int depth = 200;

        private double rMin = -2.5;
        private double rMax = 1.0;
        private double iMin = -1.2;
        private double iMax = 1.2;

        double zoomFactor = 0.5;
        double zoomPow = 4;

        private double rMinTemp = -2.5;
        private double rMaxTemp = 1.0;
        private double iMinTemp = -1.2;
        private double iMaxTemp = 1.2;

        private DateTime timeStart;
        private DateTime timeEnd;

        public frmMandelbrot()
        {
            InitializeComponent();
        }


        private void btnDraw_Click(object sender, EventArgs e)
        {
            DrawMandelbrot();            
        }

        private void DrawMandelbrot()
        {
            
            rMinTemp = rMin;
            rMaxTemp = rMax;
            iMinTemp = iMin;
            iMaxTemp = iMax;

            if (btnDraw.Text == "Cancel")
            {
                btnDraw.Text = "Draw mandelbrot";
                bgWorker.CancelAsync();
                pBar.Value = 0;
                lblStart.Text = "Start:";
                lblEnd.Text = "End:";
                lblDuration.Text = "Duration:";
            }
            else
            {
                btnDraw.Text = "Cancel";
                pBar.Value = 0;
                timeStart = DateTime.Now;
                lblStart.Text = "Start: " + timeStart.ToString("H:mm:ss.fff");
                lblEnd.Text = "End:";
                lblDuration.Text = "Duration:";
                bgWorker.RunWorkerAsync();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numWidth.Value = width;
            numHeight.Value = height;
            numDepth.Value = depth;
            numRMin.Value = Convert.ToDecimal(rMin);
            numRMax.Value = Convert.ToDecimal(rMax);
            numIMin.Value = Convert.ToDecimal(iMin);
            numIMax.Value = Convert.ToDecimal(iMax);
            txtRMin.Text = rMin.ToString();
            txtRMax.Text = rMax.ToString();
            txtIMin.Text = iMin.ToString();
            txtIMax.Text = iMax.ToString();
        }

        private void numWidth_ValueChanged(object sender, EventArgs e)
        {
            width = (int)numWidth.Value;
        }

        private void numHeight_ValueChanged(object sender, EventArgs e)
        {
            height = (int)numHeight.Value;
        }

        private void numDepth_ValueChanged(object sender, EventArgs e)
        {
            depth = (int)numDepth.Value;

        }

        private unsafe void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            double pixels_total = width * height;
            double pixels_done = 0;

            double rScale = (rMax - rMin) / (width - 1); 
            double iScale = (iMax - iMin) / (height - 1);

            mandelbrot = new Bitmap(width, height);
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();

            BitmapData data = mandelbrot.LockBits(new Rectangle(0, 0, mandelbrot.Width, mandelbrot.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr scan0 = data.Scan0;

            Parallel.For(0, width, x => 
            {
                for (int y = 0; y < height; y++)
                {
                   if (bgWorker.CancellationPending)
                   {
                       e.Cancel = true;
                       return;
                   }
                   double c_re = rMin + x * rScale;
                   double c_im = iMax - y * iScale;
                   double Z_re = c_re, Z_im = c_im;

                   Color pixel = Color.Black;
                   for (int d = 0; d < depth; ++d)
                   {
                       double Z_re2 = Z_re * Z_re, Z_im2 = Z_im * Z_im;
                       if (Z_re2 + Z_im2 > 4)
                       {
                           pixel = Color.FromArgb(0, (int)(((double)d / depth) * 255d), 0);
                           break;
                       }
                       Z_im = 2 * Z_re * Z_im + c_im;
                       Z_re = Z_re2 - Z_im2 + c_re;
                   }

                   byte* imagePointer = (byte*)scan0.ToPointer();
                   int offset = (y * data.Stride) + (3 * x);
                   byte* px = (imagePointer + offset);
                   px[0] = pixel.B;
                   px[1] = pixel.G;
                   px[2] = pixel.R;

                   pixels_done++;
                }
                bgWorker.ReportProgress((int)((pixels_done / pixels_total) * 100.0));
            });
            mandelbrot.UnlockBits(data);

        }


        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                picMandelbrot.Image = mandelbrot;
                timeEnd = DateTime.Now;
                lblEnd.Text = "End: " + timeEnd.ToString("H:mm:ss.fff");
                lblDuration.Text = "Duration: " + timeEnd.Subtract(timeStart);
                btnDraw.Text = "Draw mandelbrot";
                pBar.Value = 100;
            }
            pBar.Value = 0;
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pBar.Value = e.ProgressPercentage;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Bitmap image(*.bmp)|*.bmp";
            save.ShowDialog();
            if (save.FileName != "")
            {
                mandelbrot.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
            }
        }


        private void mapping_Changed(object sender, EventArgs e)
        {
            
            double initRMin = (double)numRMin.Value;
            double initRMax = (double)numRMax.Value;
            double initIMin = (double)numIMin.Value;
            double initIMax = (double)numIMax.Value;

            double moveX = (double)numMoveX.Value;
            double moveY = (double)numMoveY.Value;

            double zoom = (double)numZoom.Value;
            zoom = Math.Pow(zoom, zoomPow);
            
            double ratio = (initRMax - initRMin) / (initIMax - initIMin);
            double zoomFactorX = zoomFactor * ratio;
            double zoomFactorY = zoomFactor;

            double rangeR = (initRMax - initRMin) / 2;
            double rangeI = (initIMax - initIMin) / 2;

            rMin = (initRMin - moveX) + (rangeR - (rangeR / (1 + (zoom * zoomFactor) - zoomFactor)));
            rMax = (initRMax - moveX) - (rangeR - (rangeR / (1 + (zoom * zoomFactor) - zoomFactor)));
            iMin = (initIMin - moveY) + (rangeI - (rangeI / (1 + (zoom * zoomFactor) - zoomFactor)));
            iMax = (initIMax - moveY) - (rangeI - (rangeI / (1 + (zoom * zoomFactor) - zoomFactor)));

            txtRMin.Text = rMin.ToString();
            txtRMax.Text = rMax.ToString();
            txtIMin.Text = iMin.ToString();
            txtIMax.Text = iMax.ToString();
        }

        private void picMandelbrot_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 1)
            {
                int imageX = -1;
                int imageY = -1;

                if ((double)height / (double)picMandelbrot.Height > (double)width / (double)picMandelbrot.Width)
                {
                    double ratio = (double)height / (double)picMandelbrot.Height;
                    double offset = (picMandelbrot.Width - (width / ratio)) / 2;
                    imageX = (int)((e.X - offset) * ratio);
                    imageY = (int)(e.Y * ratio);
                }
                else
                {
                    double ratio = (double)width / (double)picMandelbrot.Width;
                    double offset = (picMandelbrot.Height - (height / ratio)) / 2;
                    imageX = (int)(e.X * ratio);
                    imageY = (int)((e.Y - offset) * ratio);
                }

                if (imageX > 0 && imageX < width && imageY > 0 && imageY < height)
                {
                    CenterMandelbrot(imageX, imageY);                    
                }
                
            }
            else
            {
                DrawMandelbrot();
            }

        }

        private void CenterMandelbrot(int centerX, int centerY)
        {
            double initRMin = (double)numRMin.Value;
            double initRMax = (double)numRMax.Value;
            double initIMin = (double)numIMin.Value;
            double initIMax = (double)numIMax.Value;

            double ratio = (initRMax - initRMin) / (initIMax - initIMin);
            double zoomFactorX = zoomFactor * ratio;
            double zoomFactorY = zoomFactor;

            double moveX = (double)numMoveX.Value;
            double moveY = (double)numMoveY.Value;

            double zoom = (double)numZoom.Value;
            zoom = Math.Pow(zoom, zoomPow);

            double rangeR = (rMaxTemp - rMinTemp) / 2;
            double rangeI = (iMaxTemp - iMinTemp) / 2;
            double initRangeR = (initRMax - initRMin) / 2;
            double initRangeI = (initIMax - initIMin) / 2;

            double rMinShouldBe = (((double)centerX / (double)width) * (rMaxTemp - rMinTemp)) + rMinTemp - rangeR;
            double iMinShouldBe = ((1 - ((double)centerY / (double)height)) * (iMaxTemp - iMinTemp)) + iMinTemp - rangeI;
            
            numMoveX.Value = Convert.ToDecimal(-1 * (rMinShouldBe - (initRangeR - (initRangeR / (1 + (zoom * zoomFactor) - zoomFactor))) - initRMin));
            numMoveY.Value = Convert.ToDecimal(-1 * (iMinShouldBe - (initRangeI - (initRangeI / (1 + (zoom * zoomFactor) - zoomFactor))) - initIMin));
        }
    }
}
