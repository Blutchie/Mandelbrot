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

namespace Mandelbrot
{
    public partial class frmMain : Form
    {
        Bitmap mandelbrot;
        private int width = 600;
        private int height = 600;
        private int depth = 20;

        private DateTime timeStart;
        private DateTime timeEnd;

        public frmMain()
        {
            InitializeComponent();
        }

        private bool Mandel(Complex c)
        {
            Complex z = 0;
            for (int h = 0; h <= depth; h++)
            {
                z = Complex.Pow(z, 2) + c;
                if (Complex.Abs(z) >= 2) return false;
            }
            return true;
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

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            mandelbrot = new Bitmap(width, height);
            using (Graphics graph = Graphics.FromImage(mandelbrot))
            {
                Rectangle ImageSize = new Rectangle(0, 0, width, height);
                graph.FillRectangle(Brushes.White, ImageSize);
            }

            for (int x = 0; x < width; x++)
            {
                double real = x / ((double)width / 3.0) - 1.5;
                for (int y = 0; y < height / 2; y++)
                {
                    if (bgWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    double img = y / ((double)height / 3.0) - 1.5;
                    Complex c = new Complex(real, img);
                    if (Mandel(c))
                    {
                        mandelbrot.SetPixel(x, y, Color.Black);
                        mandelbrot.SetPixel(x, height - y - 1, Color.Black);
                    }
                }
                bgWorker.ReportProgress((int)(((double)(x + 1) / (double)width) * 100.0));
            }
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
    }
}
