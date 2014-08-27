namespace Mandelbrot
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDraw = new System.Windows.Forms.Button();
            this.picMandelbrot = new System.Windows.Forms.PictureBox();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.lblDepth = new System.Windows.Forms.Label();
            this.numDepth = new System.Windows.Forms.NumericUpDown();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.lblDuration = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblIMin = new System.Windows.Forms.Label();
            this.numIMin = new System.Windows.Forms.NumericUpDown();
            this.lblRMin = new System.Windows.Forms.Label();
            this.numRMin = new System.Windows.Forms.NumericUpDown();
            this.lblRMax = new System.Windows.Forms.Label();
            this.numRMax = new System.Windows.Forms.NumericUpDown();
            this.lblIMax = new System.Windows.Forms.Label();
            this.numIMax = new System.Windows.Forms.NumericUpDown();
            this.lblZoom = new System.Windows.Forms.Label();
            this.numZoom = new System.Windows.Forms.NumericUpDown();
            this.lblMoveY = new System.Windows.Forms.Label();
            this.lblMoveX = new System.Windows.Forms.Label();
            this.numMoveX = new System.Windows.Forms.NumericUpDown();
            this.numMoveY = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.picMandelbrot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveY)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(12, 13);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(96, 23);
            this.btnDraw.TabIndex = 0;
            this.btnDraw.Text = "Draw mandelbrot";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // picMandelbrot
            // 
            this.picMandelbrot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picMandelbrot.BackColor = System.Drawing.Color.White;
            this.picMandelbrot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMandelbrot.Location = new System.Drawing.Point(12, 94);
            this.picMandelbrot.Name = "picMandelbrot";
            this.picMandelbrot.Size = new System.Drawing.Size(1050, 455);
            this.picMandelbrot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMandelbrot.TabIndex = 1;
            this.picMandelbrot.TabStop = false;
            // 
            // numWidth
            // 
            this.numWidth.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numWidth.Location = new System.Drawing.Point(221, 16);
            this.numWidth.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numWidth.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(80, 20);
            this.numWidth.TabIndex = 2;
            this.numWidth.Value = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            this.numWidth.ValueChanged += new System.EventHandler(this.numWidth_ValueChanged);
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(180, 18);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(35, 13);
            this.lblWidth.TabIndex = 3;
            this.lblWidth.Text = "Width";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(307, 18);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(38, 13);
            this.lblHeight.TabIndex = 5;
            this.lblHeight.Text = "Height";
            // 
            // numHeight
            // 
            this.numHeight.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numHeight.Location = new System.Drawing.Point(348, 16);
            this.numHeight.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numHeight.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(80, 20);
            this.numHeight.TabIndex = 4;
            this.numHeight.Value = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            this.numHeight.ValueChanged += new System.EventHandler(this.numHeight_ValueChanged);
            // 
            // lblDepth
            // 
            this.lblDepth.AutoSize = true;
            this.lblDepth.Location = new System.Drawing.Point(439, 18);
            this.lblDepth.Name = "lblDepth";
            this.lblDepth.Size = new System.Drawing.Size(36, 13);
            this.lblDepth.TabIndex = 7;
            this.lblDepth.Text = "Depth";
            // 
            // numDepth
            // 
            this.numDepth.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numDepth.Location = new System.Drawing.Point(480, 16);
            this.numDepth.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numDepth.Name = "numDepth";
            this.numDepth.Size = new System.Drawing.Size(80, 20);
            this.numDepth.TabIndex = 6;
            this.numDepth.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numDepth.ValueChanged += new System.EventHandler(this.numDepth_ValueChanged);
            // 
            // lblStart
            // 
            this.lblStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStart.Location = new System.Drawing.Point(856, 13);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(100, 13);
            this.lblStart.TabIndex = 8;
            this.lblStart.Text = "Start: ";
            // 
            // lblEnd
            // 
            this.lblEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEnd.Location = new System.Drawing.Point(962, 13);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(100, 13);
            this.lblEnd.TabIndex = 9;
            this.lblEnd.Text = "End: ";
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // pBar
            // 
            this.pBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pBar.Location = new System.Drawing.Point(12, 70);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(1049, 18);
            this.pBar.TabIndex = 10;
            // 
            // lblDuration
            // 
            this.lblDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDuration.Location = new System.Drawing.Point(856, 26);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(206, 13);
            this.lblDuration.TabIndex = 11;
            this.lblDuration.Text = "Duration:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(114, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(40, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblIMin
            // 
            this.lblIMin.AutoSize = true;
            this.lblIMin.Location = new System.Drawing.Point(439, 44);
            this.lblIMin.Name = "lblIMin";
            this.lblIMin.Size = new System.Drawing.Size(26, 13);
            this.lblIMin.TabIndex = 18;
            this.lblIMin.Text = "iMin";
            // 
            // numIMin
            // 
            this.numIMin.DecimalPlaces = 20;
            this.numIMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numIMin.Location = new System.Drawing.Point(480, 42);
            this.numIMin.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numIMin.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.numIMin.Name = "numIMin";
            this.numIMin.Size = new System.Drawing.Size(80, 20);
            this.numIMin.TabIndex = 17;
            this.numIMin.Value = new decimal(new int[] {
            12,
            0,
            0,
            -2147418112});
            this.numIMin.ValueChanged += new System.EventHandler(this.mapping_Changed);
            // 
            // lblRMin
            // 
            this.lblRMin.AutoSize = true;
            this.lblRMin.Location = new System.Drawing.Point(180, 44);
            this.lblRMin.Name = "lblRMin";
            this.lblRMin.Size = new System.Drawing.Size(27, 13);
            this.lblRMin.TabIndex = 14;
            this.lblRMin.Text = "rMin";
            // 
            // numRMin
            // 
            this.numRMin.DecimalPlaces = 20;
            this.numRMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numRMin.Location = new System.Drawing.Point(221, 42);
            this.numRMin.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numRMin.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.numRMin.Name = "numRMin";
            this.numRMin.Size = new System.Drawing.Size(80, 20);
            this.numRMin.TabIndex = 13;
            this.numRMin.Value = new decimal(new int[] {
            25,
            0,
            0,
            -2147418112});
            this.numRMin.ValueChanged += new System.EventHandler(this.mapping_Changed);
            // 
            // lblRMax
            // 
            this.lblRMax.AutoSize = true;
            this.lblRMax.Location = new System.Drawing.Point(307, 44);
            this.lblRMax.Name = "lblRMax";
            this.lblRMax.Size = new System.Drawing.Size(30, 13);
            this.lblRMax.TabIndex = 20;
            this.lblRMax.Text = "rMax";
            // 
            // numRMax
            // 
            this.numRMax.DecimalPlaces = 20;
            this.numRMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numRMax.Location = new System.Drawing.Point(348, 42);
            this.numRMax.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numRMax.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.numRMax.Name = "numRMax";
            this.numRMax.Size = new System.Drawing.Size(80, 20);
            this.numRMax.TabIndex = 19;
            this.numRMax.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRMax.ValueChanged += new System.EventHandler(this.mapping_Changed);
            // 
            // lblIMax
            // 
            this.lblIMax.AutoSize = true;
            this.lblIMax.Location = new System.Drawing.Point(567, 44);
            this.lblIMax.Name = "lblIMax";
            this.lblIMax.Size = new System.Drawing.Size(29, 13);
            this.lblIMax.TabIndex = 22;
            this.lblIMax.Text = "iMax";
            // 
            // numIMax
            // 
            this.numIMax.DecimalPlaces = 20;
            this.numIMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numIMax.Location = new System.Drawing.Point(613, 42);
            this.numIMax.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numIMax.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.numIMax.Name = "numIMax";
            this.numIMax.Size = new System.Drawing.Size(80, 20);
            this.numIMax.TabIndex = 21;
            this.numIMax.Value = new decimal(new int[] {
            12,
            0,
            0,
            65536});
            this.numIMax.ValueChanged += new System.EventHandler(this.mapping_Changed);
            // 
            // lblZoom
            // 
            this.lblZoom.AutoSize = true;
            this.lblZoom.Location = new System.Drawing.Point(703, 44);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(34, 13);
            this.lblZoom.TabIndex = 24;
            this.lblZoom.Text = "Zoom";
            // 
            // numZoom
            // 
            this.numZoom.DecimalPlaces = 20;
            this.numZoom.Location = new System.Drawing.Point(744, 42);
            this.numZoom.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numZoom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numZoom.Name = "numZoom";
            this.numZoom.Size = new System.Drawing.Size(80, 20);
            this.numZoom.TabIndex = 23;
            this.numZoom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numZoom.ValueChanged += new System.EventHandler(this.mapping_Changed);
            // 
            // lblMoveY
            // 
            this.lblMoveY.AutoSize = true;
            this.lblMoveY.Location = new System.Drawing.Point(703, 18);
            this.lblMoveY.Name = "lblMoveY";
            this.lblMoveY.Size = new System.Drawing.Size(43, 13);
            this.lblMoveY.TabIndex = 26;
            this.lblMoveY.Text = "move Y";
            // 
            // lblMoveX
            // 
            this.lblMoveX.AutoSize = true;
            this.lblMoveX.Location = new System.Drawing.Point(567, 18);
            this.lblMoveX.Name = "lblMoveX";
            this.lblMoveX.Size = new System.Drawing.Size(43, 13);
            this.lblMoveX.TabIndex = 28;
            this.lblMoveX.Text = "move X";
            // 
            // numMoveX
            // 
            this.numMoveX.DecimalPlaces = 20;
            this.numMoveX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numMoveX.Location = new System.Drawing.Point(613, 16);
            this.numMoveX.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMoveX.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.numMoveX.Name = "numMoveX";
            this.numMoveX.Size = new System.Drawing.Size(80, 20);
            this.numMoveX.TabIndex = 27;
            this.numMoveX.ValueChanged += new System.EventHandler(this.mapping_Changed);
            // 
            // numMoveY
            // 
            this.numMoveY.DecimalPlaces = 20;
            this.numMoveY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numMoveY.Location = new System.Drawing.Point(745, 16);
            this.numMoveY.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMoveY.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.numMoveY.Name = "numMoveY";
            this.numMoveY.Size = new System.Drawing.Size(80, 20);
            this.numMoveY.TabIndex = 29;
            this.numMoveY.ValueChanged += new System.EventHandler(this.mapping_Changed);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 561);
            this.Controls.Add(this.numMoveY);
            this.Controls.Add(this.lblMoveX);
            this.Controls.Add(this.numMoveX);
            this.Controls.Add(this.lblMoveY);
            this.Controls.Add(this.lblZoom);
            this.Controls.Add(this.numZoom);
            this.Controls.Add(this.lblIMax);
            this.Controls.Add(this.numIMax);
            this.Controls.Add(this.lblRMax);
            this.Controls.Add(this.numRMax);
            this.Controls.Add(this.lblIMin);
            this.Controls.Add(this.numIMin);
            this.Controls.Add(this.lblRMin);
            this.Controls.Add(this.numRMin);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.pBar);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lblDepth);
            this.Controls.Add(this.numDepth);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.numHeight);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.numWidth);
            this.Controls.Add(this.picMandelbrot);
            this.Controls.Add(this.btnDraw);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "frmMain";
            this.Text = "Mandelbrot";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMandelbrot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.PictureBox picMandelbrot;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.Label lblDepth;
        private System.Windows.Forms.NumericUpDown numDepth;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblEnd;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblIMin;
        private System.Windows.Forms.NumericUpDown numIMin;
        private System.Windows.Forms.Label lblRMin;
        private System.Windows.Forms.NumericUpDown numRMin;
        private System.Windows.Forms.Label lblRMax;
        private System.Windows.Forms.NumericUpDown numRMax;
        private System.Windows.Forms.Label lblIMax;
        private System.Windows.Forms.NumericUpDown numIMax;
        private System.Windows.Forms.Label lblZoom;
        private System.Windows.Forms.NumericUpDown numZoom;
        private System.Windows.Forms.Label lblMoveY;
        private System.Windows.Forms.Label lblMoveX;
        private System.Windows.Forms.NumericUpDown numMoveX;
        private System.Windows.Forms.NumericUpDown numMoveY;
    }
}

