using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ICR30
{
    public partial class frmScanGraph : Form
    {
        public frmScanGraph()
        {
            InitializeComponent();
        }
        public model_IC_R30 r30;
        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();
        public Form1 myparent;
        private void frmScanGraph_Load(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.Legends.Clear();
            chart1.Width = this.Width;
            chart1.Height = this.Height - 140;
            chart1.Location = new Point(0, 0);
            grpScanControls.Location = new Point(12, this.Height - 130);
            txtCenterFreq.Text = r30.RFA.Frequency.ToString();
        }

        private void frmScanGraph_Resize(object sender, EventArgs e)
        {

            chart1.Width = this.Width;
            chart1.Height = this.Height - 140;
            grpScanControls.Location = new Point(12, this.Height - 130);
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart1.HitTest(pos.X, pos.Y, false,
                                            ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    var prop = result.Object as DataPoint;
                    if (prop != null)
                    {
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                        // check if the cursor is really close to the point (2 pixels around the point)
                        if (Math.Abs(pos.X - pointXPixel) < 2) //&&
                            //Math.Abs(pos.Y - pointYPixel) < 2)
                        {
                            tooltip.Show("X=" + prop.XValue + ", Y=" + prop.YValues[0], this.chart1,
                                            pos.X, pos.Y - 15);
                        }
                    }
                }
            }
        }

        private void txtBandwidth_TextChanged(object sender, EventArgs e)
        {

        }

        private void ScanFreqRange(uint uFrequency, uint uBandwidth, uint uStep, model_IC_R30.t_ReceiveMode mode)
        {
            btnStart.Enabled = false;
            txtCenterFreq.Enabled = false;
            txtBandwidth.Enabled = false;
            txtStepSize.Enabled = false;
            uint startFreq = (uFrequency - (uBandwidth / 2));
            uint stopFreq = (uFrequency + (uBandwidth / 2));
            uint curFreq = startFreq;
            r30.SetRFAB(0x00);
            r30.SetReceiveMode(mode);
            myparent.Scan_Pause_GUI();
            if(chart1.Series.IsUniqueName("Test"))
            {
                chart1.Series.Add("Test");
                chart1.Series["Test"].BorderWidth = 0;
                chart1.ChartAreas[0].AxisY.Maximum = 255;
            }
            int curIndex = 0;
            while (curFreq <= stopFreq)
            {
                if (chart1.Series["Test"].Points.Count > curIndex)
                {
                    chart1.Series["Test"].Points.ElementAt(curIndex).SetValueXY(curFreq, r30.GetSigLevel(curFreq));
                }
                else
                {
                    chart1.Series["Test"].Points.AddXY(curFreq, r30.GetSigLevel(curFreq));
                }
                curIndex++;
                curFreq = curFreq + uStep;
                chart1.Refresh();
                Application.DoEvents();
            }
            myparent.Scan_Resume_GUI();
            btnStart.Enabled = true;
            txtCenterFreq.Enabled = true;
            txtBandwidth.Enabled = true;
            txtStepSize.Enabled = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ScanFreqRange(Convert.ToUInt32(txtCenterFreq.Text), Convert.ToUInt32(txtBandwidth.Text), Convert.ToUInt32(txtStepSize.Text), model_IC_R30.t_ReceiveMode.FM_N);
        }
    }
}
