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
        private int width = 600;
        private int height = 600;
        private int depth = 20;
        private double zoom = 1;
        private double map_x = -2.0;
        private double map_y = -1.5;

        private DateTime timeStart;
        private DateTime timeEnd;

        public frmMain()
        {
            InitializeComponent();
        }

        private Color Mandel(Complex c)
        {
            Complex z = 0;
            for (int h = 0; h <= depth; h++)
            {
                if (z.Magnitude >= 2) return Color.FromArgb(0, (8 * h) % 255, (16 * h) % 255);
                z = Complex.Pow(z, 2) + c;
            }
            return Color.Black; ;
        }


        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (btnDraw.Text == "Cancel")
            {
                btnDraw.Text = "Draw mandelbrot";
                bgWorker.CancelAsync();
                pBar.Value = 0;
                lblStart.Text = "Start:"; ;
                lblEnd.Text = "End:";
                lblDuration.Text = "Duration:";

                picMandelbrot.Image = null;
            }
            else
            {
                btnDraw.Text = "Cancel";
                pBar.Value = 0;
                timeStart = DateTime.Now;
                lblStart.Text = "Start: " + timeStart.ToString("H:mm:ss.fff");
                lblEnd.Text = "End:";
                lblDuration.Text = "Duration:";

                picMandelbrot.Image = null;
                bgWorker.RunWorkerAsync();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numWidth.Value = width;
            numHeight.Value = height;
            numDepth.Value = depth;
            numMapX.Value = Convert.ToDecimal(map_x);
            numMapY.Value = Convert.ToDecimal(map_y);
            numZoom.Value = Convert.ToDecimal(zoom);
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

            mandelbrot = new Bitmap(width, height);
            BitmapData data = mandelbrot.LockBits(new Rectangle(0, 0, mandelbrot.Width, mandelbrot.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr scan0 = data.Scan0;

            Parallel.For(0, width, x => 
            {
                double real = (x / ((double)width / 3.0) + map_x) / zoom;
                for (int y = 0; y < height; y++)
                {
                   if (bgWorker.CancellationPending)
                   {
                       e.Cancel = true;
                       return;
                   }
                   double img = (y / ((double)height / 3.0) + map_y) / zoom;
                   Complex c = new Complex(real, img);

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

        private void numMapX_ValueChanged(object sender, EventArgs e)
        {
            map_x = Convert.ToDouble(numMapX.Value);
        }

        private void numMapY_ValueChanged(object sender, EventArgs e)
        {
            map_y = Convert.ToDouble(numMapY.Value);
        }

        private void numZoom_ValueChanged(object sender, EventArgs e)
        {
            zoom = Convert.ToDouble(numZoom.Value);
        }
    }
}
