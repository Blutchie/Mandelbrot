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
    public partial class frmMain : Form
    {
        Bitmap mandelbrot;
        private int width = 1920;
        private int height = 1080;
        private int depth = 200;
        private double rMin = -2.5;
        private double rMax = 1.0;
        private double iMin = -1.2;
        private double iMax = 1.2;

        private DateTime timeStart;
        private DateTime timeEnd;

        public frmMain()
        {
            InitializeComponent();
        }

        private Color Mandel(Complex c)
        {
            Complex z = c;
            for (int h = 0; h <= depth; h++)
            {
                if (z.Magnitude >= 2) return Color.FromArgb(0, (8 * h) % 255, (16 * h) % 255);
                z = Complex.Pow(z, 2) + c;
            }
            return Color.Black;
        }


        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (btnDraw.Text == "Cancel")
            {
                btnDraw.Text = "Draw mandelbrot";
                bgWorker.CancelAsync();
                pBar.Value = 0;
                lblStart.Text = "Start:";
                lblEnd.Text = "End:";
                lblDuration.Text = "Duration:";

               // picMandelbrot.Image = null;
            }
            else
            {
                btnDraw.Text = "Cancel";
                pBar.Value = 0;
                timeStart = DateTime.Now;
                lblStart.Text = "Start: " + timeStart.ToString("H:mm:ss.fff");
                lblEnd.Text = "End:";
                lblDuration.Text = "Duration:";

                //picMandelbrot.Image = null;
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

            double rScale = (Math.Abs(rMin) + Math.Abs(rMax)) / width; // Amount to move each pixel in the real numbers
            double iScale = (Math.Abs(iMin) + Math.Abs(iMax)) / height; // Amount to move each pixel in the imaginary numbers

            mandelbrot = new Bitmap(width, height);
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
                   Complex c = new Complex(x * rScale + rMin, y * iScale + iMin); // Scaled complex number
                   
                   Color pixel = Mandel(c);
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
            double zoom = (double)numZoom.Value;

            double initRMin = (double)numRMin.Value;
            double initRMax = (double)numRMax.Value;

            double initIMin = (double)numIMin.Value;
            double initIMax = (double)numIMax.Value;

            double moveX = (double)numMoveX.Value;
            double moveY = (double)numMoveY.Value;

            rMin = (initRMin - moveX) * (1 / zoom);
            rMax = (initRMax - moveX) * (1 / zoom);
            iMin = (initIMin + moveY) * (1 / zoom);
            iMax = (initIMax + moveY) * (1 / zoom);
        }

    }
}
