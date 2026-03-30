
namespace ICR30
{
    partial class frmScanGraph
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtCenterFreq = new System.Windows.Forms.TextBox();
            this.txtBandwidth = new System.Windows.Forms.TextBox();
            this.txtStepSize = new System.Windows.Forms.TextBox();
            this.grpScanControls = new System.Windows.Forms.GroupBox();
            this.lblStep = new System.Windows.Forms.Label();
            this.lblBandwidth = new System.Windows.Forms.Label();
            this.lblCenterFreq = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.grpScanControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(1, 2);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(300, 300);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(464, 37);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Scan";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtCenterFreq
            // 
            this.txtCenterFreq.Location = new System.Drawing.Point(89, 39);
            this.txtCenterFreq.Name = "txtCenterFreq";
            this.txtCenterFreq.Size = new System.Drawing.Size(100, 20);
            this.txtCenterFreq.TabIndex = 3;
            // 
            // txtBandwidth
            // 
            this.txtBandwidth.Location = new System.Drawing.Point(271, 39);
            this.txtBandwidth.Name = "txtBandwidth";
            this.txtBandwidth.Size = new System.Drawing.Size(77, 20);
            this.txtBandwidth.TabIndex = 4;
            this.txtBandwidth.Text = "100000";
            this.txtBandwidth.TextChanged += new System.EventHandler(this.txtBandwidth_TextChanged);
            // 
            // txtStepSize
            // 
            this.txtStepSize.Location = new System.Drawing.Point(393, 39);
            this.txtStepSize.Name = "txtStepSize";
            this.txtStepSize.Size = new System.Drawing.Size(65, 20);
            this.txtStepSize.TabIndex = 5;
            this.txtStepSize.Text = "1000";
            // 
            // grpScanControls
            // 
            this.grpScanControls.Controls.Add(this.lblStep);
            this.grpScanControls.Controls.Add(this.lblBandwidth);
            this.grpScanControls.Controls.Add(this.lblCenterFreq);
            this.grpScanControls.Controls.Add(this.btnStart);
            this.grpScanControls.Controls.Add(this.txtCenterFreq);
            this.grpScanControls.Controls.Add(this.txtBandwidth);
            this.grpScanControls.Controls.Add(this.txtStepSize);
            this.grpScanControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpScanControls.Location = new System.Drawing.Point(12, 357);
            this.grpScanControls.Name = "grpScanControls";
            this.grpScanControls.Size = new System.Drawing.Size(555, 90);
            this.grpScanControls.TabIndex = 6;
            this.grpScanControls.TabStop = false;
            this.grpScanControls.Text = "Scan Controls";
            // 
            // lblStep
            // 
            this.lblStep.AutoSize = true;
            this.lblStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep.Location = new System.Drawing.Point(354, 42);
            this.lblStep.Name = "lblStep";
            this.lblStep.Size = new System.Drawing.Size(37, 13);
            this.lblStep.TabIndex = 8;
            this.lblStep.Text = "Step:";
            // 
            // lblBandwidth
            // 
            this.lblBandwidth.AutoSize = true;
            this.lblBandwidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBandwidth.Location = new System.Drawing.Point(195, 42);
            this.lblBandwidth.Name = "lblBandwidth";
            this.lblBandwidth.Size = new System.Drawing.Size(70, 13);
            this.lblBandwidth.TabIndex = 7;
            this.lblBandwidth.Text = "Bandwidth:";
            // 
            // lblCenterFreq
            // 
            this.lblCenterFreq.AutoSize = true;
            this.lblCenterFreq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCenterFreq.Location = new System.Drawing.Point(6, 42);
            this.lblCenterFreq.Name = "lblCenterFreq";
            this.lblCenterFreq.Size = new System.Drawing.Size(77, 13);
            this.lblCenterFreq.TabIndex = 6;
            this.lblCenterFreq.Text = "Center Freq:";
            // 
            // frmScanGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpScanControls);
            this.Controls.Add(this.chart1);
            this.Name = "frmScanGraph";
            this.Text = "frmScanGraph";
            this.Load += new System.EventHandler(this.frmScanGraph_Load);
            this.Resize += new System.EventHandler(this.frmScanGraph_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.grpScanControls.ResumeLayout(false);
            this.grpScanControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtCenterFreq;
        private System.Windows.Forms.TextBox txtBandwidth;
        private System.Windows.Forms.TextBox txtStepSize;
        private System.Windows.Forms.GroupBox grpScanControls;
        private System.Windows.Forms.Label lblBandwidth;
        private System.Windows.Forms.Label lblCenterFreq;
        private System.Windows.Forms.Label lblStep;
    }
}