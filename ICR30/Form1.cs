using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Threading;

namespace ICR30
{
    public partial class Form1 : Form

    {
        uint GUI_A_FreqEntryMultiplier;
        uint GUI_B_FreqEntryMultiplier;

        public bool ExitRequested = false;

        SerialPortHandler sph;
        public model_IC_R30 r30;
        Thread tPUW;
        Thread tHSPUW;
        Point lMainReceiver;
        Point lSubReceiver;
        Point lModeSettingsA;
        Point lModeSettingsB;

        bool DebugMode = true;

        // Squelch save variables for Push-to-Monitor functionality.
        int iSqlSaveA;
        int iSqlSaveB;

        // It is useful for the PUWs to know squelch status, so we update these.
        bool SquelchOpenA;
        bool SquelchOpenB;

        // For Loading DSD Radio and Group Files.
        RadioID_DB RadioDB;

        public Form1()
        {
            InitializeComponent();
        }

        public void PeriodicUpdateWorker()
        {
            // Handles periodic updates to display, and Squelch level.
            while (!ExitRequested)
            {
                
                if (chkPUW.Checked)
                {
                    if(sph != null)
                    {
                        if (sph.ExitRequested == true || sph.IsConnected == false)
                        {
                            R30_Disconnect();
                            return;
                        }
                    }
                    
                    if (r30.DualBandMode != model_IC_R30.t_DualBandMode.SingleBMain)
                    {
                        r30.ReqDisplayContentSpecificRF(0x00);
                        if (!SquelchOpenA) r30.ReqSqlLvlSpecificRF(0x00);
                    }
                    if (!SquelchOpenA && !SquelchOpenB)
                    {
                        Thread.Sleep(200);
                    }
                    else
                    {
                        Thread.Sleep(300);
                    }
                    r30.ReqScanCondition();
                    if (r30.DualBandMode != model_IC_R30.t_DualBandMode.SingleAMain)
                    {
                        r30.ReqDisplayContentSpecificRF(0x01);
                        if (!SquelchOpenB) r30.ReqSqlLvlSpecificRF(0x01);
                    }
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
            
        }

        public void HSPeriodicUpdateWorker()
        {
            // This is like the PeriodicUpdateWorker, but for things that need to happen
            // more frequently.
            while (!ExitRequested)
            {

                if (chkPUW.Checked)
                {
                    if (r30.DualBandMode != model_IC_R30.t_DualBandMode.SingleBMain)
                    {
                        if (SquelchOpenA) r30.ReqSqlLvlSpecificRF(0x00);
                    }
                    if (!SquelchOpenA && !SquelchOpenB)
                    {
                        Thread.Sleep(200);
                    }
                    else
                    {
                        Thread.Sleep(100);
                    }
                    if (r30.DualBandMode != model_IC_R30.t_DualBandMode.SingleAMain)
                    {
                        if (SquelchOpenB )r30.ReqSqlLvlSpecificRF(0x01);
                    }
                    Thread.Sleep(100);
                }
                else
                {
                    Thread.Sleep(100);
                }
            }

        }
        public void GUI_PopulateCOMPorts()
        {
            string[] ports = sph.GetPortList();
            mtscb_COMPort.Items.Clear();
            foreach (string port in ports)
            {
                mtscb_COMPort.Items.Add(port);
            }
            mtscb_COMPort.SelectedIndex = 0;
        }
        public void GUI_PopulateBaudRates()
        {
            mtscb_BaudRate.Items.Add(9600);
            mtscb_BaudRate.Items.Add(19200);
            mtscb_BaudRate.SelectedIndex = 0;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (!DebugMode)
            {
                txtDbgSend.Visible = false;
                btnDebugSend.Visible = false;
                chkPUW.Visible = false;
            }
            this.Text = "IC-R30 PC Remote Version " + Application.ProductVersion;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            RadioDB = new RadioID_DB();

            // Default Receiver locations.
            lMainReceiver.X = 21;
            lMainReceiver.Y = 29;
            lSubReceiver.X = 21;
            lSubReceiver.Y = 424;

            // Default mode settings locations.
            lModeSettingsA.X = 627;
            lModeSettingsA.Y = 29;
            lModeSettingsB.X = 627;
            lModeSettingsB.Y = 424;

            this.Width = 980;
            SetReceiverControls(false, false);
            SetReceiverControls(true, false);

            // Default to 1MHz multiplier for frequency entry.
            GUI_Update_A_FreqEntry_Type(1000000);
            GUI_Update_B_FreqEntry_Type(1000000);


            r30 = new model_IC_R30();
            sph = new SerialPortHandler();

            GUI_PopulateCOMPorts();
            GUI_PopulateBaudRates();

            // Register events for Mouse Hover switching
            grpRecA.MouseEnter += GrpRecA_MouseEnter;
            statusStrip1.MouseEnter += GrpRecA_MouseEnter;
            grpRecB.MouseEnter += GrpRecB_MouseEnter;
            statusStrip2.MouseEnter += GrpRecB_MouseEnter;
            grp_A_FM.MouseEnter += GrpRecA_MouseEnter;
            grp_A_AM.MouseEnter += GrpRecA_MouseEnter;
            grp_A_P25.MouseEnter += GrpRecA_MouseEnter;
            grp_A_SSB.MouseEnter += GrpRecA_MouseEnter;
            grp_B_FM.MouseEnter += GrpRecB_MouseEnter;
            grp_B_AM.MouseEnter += GrpRecB_MouseEnter;
            grp_B_P25.MouseEnter += GrpRecB_MouseEnter;
            grpRecA.Click += GrpRecA_Click;
            grpRecB.Click += GrpRecB_Click;

            // Register events for mousewheel controls.
            lblAFreq.MouseWheel += LblAFreq_MouseWheel;
            lblBFreq.MouseWheel += LblBFreq_MouseWheel;
            lbl_A_MEM_GRP.MouseWheel += Lbl_A_MEM_GRP_MouseWheel;
            lbl_B_MEM_GRP.MouseWheel += Lbl_B_MEM_GRP_MouseWheel;
            lbl_A_MEM_MEM.MouseWheel += Lbl_A_MEM_MEM_MouseWheel;
            lbl_B_MEM_MEM.MouseWheel += Lbl_B_MEM_MEM_MouseWheel;
            lbl_A_MemName.MouseWheel += Lbl_A_MemName_MouseWheel;
            lbl_B_MemName.MouseWheel += Lbl_B_MemName_MouseWheel;
            lbl_A_MemGrpName.MouseWheel += Lbl_A_MemGrpName_MouseWheel;
            lbl_B_MemGrpName.MouseWheel += Lbl_B_MemGrpName_MouseWheel;
        }

        private void GrpRecB_Click(object sender, EventArgs e)
        {
            if (mtsdb_SwitchingType.Text == "Manual")
            {
                r30.SetRFAB(0x01);
            }
        }

        private void GrpRecA_Click(object sender, EventArgs e)
        {
            if (mtsdb_SwitchingType.Text == "Manual")
            {
                r30.SetRFAB(0x00);
            }
        }

        public void R30_Connect()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(R30_Connect), new object[] { });
                return;
            }
            r30 = new model_IC_R30();
            r30.SerialInterface = sph;
            sph.PacketReceipt += RoutePacket;
            sph.COMPort = mtscb_COMPort.Text;
            sph.COMBaudRate = Convert.ToInt32(mtscb_BaudRate.Text);
            try
            {
                if (sph.Open() == 0) return;
            }
            catch (Exception ex)
            {
                return;
            }
            ExitRequested = false;
            r30.ReqEvScanConditionChange();
            r30.ReqEvDisplayChangeReport();
            r30.ReqEvP25_ID();
            r30.ReqEvP25_RXStatus();
            r30.ReqFMTSQLFreq();
            r30.ReqFMDTCSCode();
            r30.ReqDisplayContentSpecificRF(0x00);
            r30.ReqDisplayContentSpecificRF(0x01);
            r30.ReqAFGain();
            r30.ReqRFGain();
            r30.ReqSqlLvl();
            r30.ReqMemoryGroups();
            r30.ReqVFOPrograms();
            r30.ReqScanCondition();
            r30.ReqScanInformation();
            tPUW = new Thread(PeriodicUpdateWorker);
            tPUW.Start();
            tHSPUW = new Thread(HSPeriodicUpdateWorker);
            tHSPUW.Start();
            chkPUW.Checked = true;
            mtsbConnect.Text = "Disconnect";
            btnPowerOn.Enabled = true;
            btnPowerOff.Enabled = true;
            mtscb_BaudRate.Enabled = false;
            mtscb_COMPort.Enabled = false;
            return;
        }
        public void R30_Disconnect()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(R30_Disconnect), new object[] { });
                return;
            }
            tHSPUW.Abort();
            sph.Close();
            mtsbConnect.Text = "Connect";
            btnPowerOn.Enabled = false;
            btnPowerOff.Enabled = false;
            mtscb_BaudRate.Enabled = true;
            mtscb_COMPort.Enabled = true;
            return;
        }
        #region Controls

        private void SetReceiverControls(bool RFB, bool bActive)
        {
            // Handles enable/Disable of receiver controls depending on Layout and
            // Switching mode.
            if(!RFB)
            {
                if(bActive)
                {
                    lbl_A_MEM_GRP.Enabled = true;
                    lbl_A_MEM_MEM.Enabled = true;
                    lbl_A_MemGrpName.Enabled = true;
                    lbl_A_MemName.Enabled = true;
                    lblAFreq.Enabled = true;
                    btnA_GHz.Enabled = true;
                    btnA_MHz.Enabled = true;
                    btnA_KHz.Enabled = true;
                    btnA_Hz.Enabled = true;
                    txtA_FreqEntry.Enabled = true;
                    btn_A_KP0.Enabled = true;
                    btn_A_KP1.Enabled = true;
                    btn_A_KP2.Enabled = true;
                    btn_A_KP3.Enabled = true;
                    btn_A_KP4.Enabled = true;
                    btn_A_KP5.Enabled = true;
                    btn_A_KP6.Enabled = true;
                    btn_A_KP7.Enabled = true;
                    btn_A_KP8.Enabled = true;
                    btn_A_KP9.Enabled = true;
                    btn_A_KPdot.Enabled = true;
                    btn_A_KPEnter.Enabled = true;
                    sb_A_Mode.Enabled = true;
                    sb_A_VFOMEM.Enabled = true;
                    sb_A_Scan.Enabled = true;
                    tslbl_A_RecStatus.Enabled = true;
                    trk_A_SqlLvl.Enabled = true;
                    btn_A_ScanCtrl_Skip.Enabled = true;
                    btn_A_ReceiveInd.Enabled = true;
                    trk_A_AFGain.Enabled = true;
                    trk_A_RFGain.Enabled = true;
                    grp_A_AM.Enabled = true;
                    grp_A_FM.Enabled = true;
                    grp_A_P25.Enabled = true;
                    grp_A_SSB.Enabled = true;
                }
                else
                {
                    lbl_A_MEM_GRP.Enabled = false;
                    lbl_A_MEM_MEM.Enabled = false;
                    lbl_A_MemGrpName.Enabled = false;
                    lbl_A_MemName.Enabled = false;
                    lblAFreq.Enabled = false;
                    btnA_GHz.Enabled = false;
                    btnA_MHz.Enabled = false;
                    btnA_KHz.Enabled = false;
                    btnA_Hz.Enabled = false;
                    txtA_FreqEntry.Enabled = false;
                    btn_A_KP0.Enabled = false;
                    btn_A_KP1.Enabled = false;
                    btn_A_KP2.Enabled = false;
                    btn_A_KP3.Enabled = false;
                    btn_A_KP4.Enabled = false;
                    btn_A_KP5.Enabled = false;
                    btn_A_KP6.Enabled = false;
                    btn_A_KP7.Enabled = false;
                    btn_A_KP8.Enabled = false;
                    btn_A_KP9.Enabled = false;
                    btn_A_KPdot.Enabled = false;
                    btn_A_KPEnter.Enabled = false;
                    sb_A_Mode.Enabled = false;
                    sb_A_VFOMEM.Enabled = false;
                    sb_A_Scan.Enabled = false;
                    tslbl_A_RecStatus.Enabled = false;
                    trk_A_SqlLvl.Enabled = false;
                    btn_A_ScanCtrl_Skip.Enabled = false;
                    btn_A_ReceiveInd.Enabled = false;
                    trk_A_AFGain.Enabled = false;
                    trk_A_RFGain.Enabled = false;
                    grp_A_AM.Enabled = false;
                    grp_A_FM.Enabled = false;
                    grp_A_P25.Enabled = false;
                    grp_A_SSB.Enabled = false;
                }
            }
            else
            {
                if (bActive)
                {
                    lbl_B_MEM_GRP.Enabled = true;
                    lbl_B_MEM_MEM.Enabled = true;
                    lbl_B_MemGrpName.Enabled = true;
                    lbl_B_MemName.Enabled = true;
                    lblBFreq.Enabled = true;
                    btnB_GHz.Enabled = true;
                    btnB_MHz.Enabled = true;
                    btnB_KHz.Enabled = true;
                    btnB_Hz.Enabled = true;
                    txtB_FreqEntry.Enabled = true;
                    btn_B_KP0.Enabled = true;
                    btn_B_KP1.Enabled = true;
                    btn_B_KP2.Enabled = true;
                    btn_B_KP3.Enabled = true;
                    btn_B_KP4.Enabled = true;
                    btn_B_KP5.Enabled = true;
                    btn_B_KP6.Enabled = true;
                    btn_B_KP7.Enabled = true;
                    btn_B_KP8.Enabled = true;
                    btn_B_KP9.Enabled = true;
                    btn_B_KPdot.Enabled = true;
                    btn_B_KPEnter.Enabled = true;
                    sb_B_Mode.Enabled = true;
                    sb_B_VFOMEM.Enabled = true;
                    sb_B_Scan.Enabled = true;
                    tslbl_B_RecStatus.Enabled = true;
                    trk_B_SqlLvl.Enabled = true;
                    btn_B_ScanCtrl_Skip.Enabled = true;
                    btn_B_ReceiveInd.Enabled = true;
                    trk_B_AFGain.Enabled = true;
                    trk_B_RFGain.Enabled = true;
                    grp_B_AM.Enabled = true;
                    grp_B_FM.Enabled = true;
                    grp_B_P25.Enabled = true;
                }
                else
                {
                    lbl_B_MEM_GRP.Enabled = false;
                    lbl_B_MEM_MEM.Enabled = false;
                    lbl_B_MemGrpName.Enabled = false;
                    lbl_B_MemName.Enabled = false;
                    lblBFreq.Enabled = false;
                    btnB_GHz.Enabled = false;
                    btnB_MHz.Enabled = false;
                    btnB_KHz.Enabled = false;
                    btnB_Hz.Enabled = false;
                    txtB_FreqEntry.Enabled = false;
                    btn_B_KP0.Enabled = false;
                    btn_B_KP1.Enabled = false;
                    btn_B_KP2.Enabled = false;
                    btn_B_KP3.Enabled = false;
                    btn_B_KP4.Enabled = false;
                    btn_B_KP5.Enabled = false;
                    btn_B_KP6.Enabled = false;
                    btn_B_KP7.Enabled = false;
                    btn_B_KP8.Enabled = false;
                    btn_B_KP9.Enabled = false;
                    btn_B_KPdot.Enabled = false;
                    btn_B_KPEnter.Enabled = false;
                    sb_B_Mode.Enabled = false;
                    sb_B_VFOMEM.Enabled = false;
                    sb_B_Scan.Enabled = false;
                    tslbl_B_RecStatus.Enabled = false;
                    trk_B_SqlLvl.Enabled = false;
                    btn_B_ScanCtrl_Skip.Enabled = false;
                    btn_B_ReceiveInd.Enabled = false;
                    trk_B_AFGain.Enabled = false;
                    trk_B_RFGain.Enabled = false;
                    grp_B_AM.Enabled = false;
                    grp_B_FM.Enabled = false;
                    grp_B_P25.Enabled = false;
                }
            }
        }
        private void mtsbConnect_Click(object sender, EventArgs e)
        {
            if (mtsbConnect.Text == "Connect")
            {
                R30_Connect();
            } 
            else
            {
                R30_Disconnect();
            }
        }
        private void Lbl_B_MemGrpName_MouseWheel(object sender, MouseEventArgs e)
        {
            int curGrp = Convert.ToInt32(lbl_B_MEM_GRP.Text);
            int nextGrp = 0;
            bool up = (e.Delta > 0);
            if (up)
            {
                if (curGrp == 99) nextGrp = 0;
                if (curGrp < 99) nextGrp = curGrp + 1;
            }
            else
            {
                if (curGrp == 0) nextGrp = 99;
                if (curGrp > 0) nextGrp = curGrp - 1;
            }
            r30.SetMemGrp((uint)nextGrp);
            r30.ReqDisplayContentSpecificRF(0x01);
        }

        private void Lbl_A_MemGrpName_MouseWheel(object sender, MouseEventArgs e)
        {
            int curGrp = Convert.ToInt32(lbl_A_MEM_GRP.Text);
            int nextGrp = 0;
            bool up = (e.Delta > 0);
            if (up)
            {
                if (curGrp == 99) nextGrp = 0;
                if (curGrp < 99) nextGrp = curGrp + 1;
            }
            else
            {
                if (curGrp == 0) nextGrp = 99;
                if (curGrp > 0) nextGrp = curGrp - 1;
            }
            r30.SetMemGrp((uint)nextGrp);
            r30.ReqDisplayContentSpecificRF(0x00);
        }

        private void Lbl_B_MemName_MouseWheel(object sender, MouseEventArgs e)
        {
            int curChan = Convert.ToInt32(lbl_B_MEM_MEM.Text);
            int nextChan = 0;
            bool up = (e.Delta > 0);
            if (up)
            {
                if (curChan == 99) nextChan = 0;
                if (curChan < 99) nextChan = curChan + 1;
            }
            else
            {
                if (curChan == 0) nextChan = 99;
                if (curChan > 0) nextChan = curChan - 1;
            }
            r30.SetMemChan((uint)nextChan);
            r30.ReqDisplayContentSpecificRF(0x01);
        }

        private void Lbl_A_MemName_MouseWheel(object sender, MouseEventArgs e)
        {
            int curChan = Convert.ToInt32(lbl_A_MEM_MEM.Text);
            int nextChan = 0;
            bool up = (e.Delta > 0);
            if (up)
            {
                if (curChan == 99) nextChan = 0;
                if (curChan < 99) nextChan = curChan + 1;
            }
            else
            {
                if (curChan == 0) nextChan = 99;
                if (curChan > 0) nextChan = curChan - 1;
            }
            r30.SetMemChan((uint)nextChan);
            r30.ReqDisplayContentSpecificRF(0x00);
        }

        private void Lbl_B_MEM_MEM_MouseWheel(object sender, MouseEventArgs e)
        {
            int curChan = Convert.ToInt32(lbl_B_MEM_MEM.Text);
            int nextChan = 0;
            bool up = (e.Delta > 0);
            if (up)
            {
                if (curChan == 99) nextChan = 0;
                if (curChan < 99) nextChan = curChan + 1;
            }
            else
            {
                if (curChan == 0) nextChan = 99;
                if (curChan > 0) nextChan = curChan - 1;
            }
            r30.SetMemChan((uint)nextChan);
            r30.ReqDisplayContentSpecificRF(0x01);
        }

        private void Lbl_A_MEM_MEM_MouseWheel(object sender, MouseEventArgs e)
        {
            int curChan = Convert.ToInt32(lbl_A_MEM_MEM.Text);
            int nextChan = 0;
            bool up = (e.Delta > 0);
            if (up)
            {
                if (curChan == 99) nextChan = 0;
                if (curChan < 99) nextChan = curChan + 1;
            }
            else
            {
                if (curChan == 0) nextChan = 99;
                if (curChan > 0) nextChan = curChan - 1;
            }
            r30.SetMemChan((uint)nextChan);
            r30.ReqDisplayContentSpecificRF(0x00);
        }

        private void Lbl_B_MEM_GRP_MouseWheel(object sender, MouseEventArgs e)
        {
            int curGrp = Convert.ToInt32(lbl_B_MEM_GRP.Text);
            int nextGrp = 0;
            bool up = (e.Delta > 0);
            if (up)
            {
                if (curGrp == 99) nextGrp = 0;
                if (curGrp < 99) nextGrp = curGrp + 1;
            }
            else
            {
                if (curGrp == 0) nextGrp = 99;
                if (curGrp > 0) nextGrp = curGrp - 1;
            }
            r30.SetMemGrp((uint)nextGrp);
            r30.ReqDisplayContentSpecificRF(0x01);
        }

        private void Lbl_A_MEM_GRP_MouseWheel(object sender, MouseEventArgs e)
        {
            int curGrp = Convert.ToInt32(lbl_A_MEM_GRP.Text);
            int nextGrp = 0;
            bool up = (e.Delta > 0);
            if (up)
            {
                if (curGrp == 99) nextGrp = 0;
                if (curGrp < 99) nextGrp = curGrp + 1; 
            }
            else
            {
                if (curGrp == 0) nextGrp = 99;
                if (curGrp > 0) nextGrp = curGrp - 1;
            }
            r30.SetMemGrp((uint)nextGrp);
            r30.ReqDisplayContentSpecificRF(0x00);

        }

        private void GrpRecA_MouseEnter(object sender, EventArgs e)
        {
            if (r30.DualBandMode == model_IC_R30.t_DualBandMode.DualBMain && mtsdb_SwitchingType.Text == "Mouse Hover")
            {
                r30.SetRFAB(0x00);
                r30.ReqDisplayContentSpecificRF(0x00);
            }

        }

        private void SetRcvFrameColor(int Rcv, System.Drawing.Color color)
        {
            GroupBox gb;
            if (Rcv == 0)
            {
                gb = grpRecA;
            }
            else
            {
                gb = grpRecB;
            }
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(color);
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(myBrush, new Rectangle(gb.Location.X - 3, gb.Location.Y - 3, gb.Width + 6, gb.Height + 6));
            myBrush.Dispose();
            formGraphics.Dispose();
        }

        private void GrpRecB_MouseEnter(object sender, EventArgs e)
        {
            if (r30.DualBandMode == model_IC_R30.t_DualBandMode.DualAMain && mtsdb_SwitchingType.Text == "Mouse Hover")
            {
                r30.SetRFAB(0x01);
                r30.ReqDisplayContentSpecificRF(0x01);
            }
        }

        private void LblAFreq_MouseWheel(object sender, MouseEventArgs e)
        {
            uint curFrequency = Convert.ToUInt32(lblAFreq.Text.Replace(" ", ""));
            uint uMod = 0;

            // |

            if (e.X > 49 && e.X <= 73) uMod = 1000000000;
            if (e.X > 96 && e.X <= 119) uMod = 100000000;
            if (e.X > 119 && e.X <= 142) uMod = 10000000;
            if (e.X > 142 && e.X <= 165) uMod = 1000000;
            if (e.X > 188 && e.X <= 211) uMod = 100000;
            if (e.X > 211 && e.X <= 234) uMod = 10000;
            if (e.X > 234 && e.X <= 257) uMod = 1000;
            if (e.X > 280 && e.X <= 303) uMod = 100;
            if (e.X > 303 && e.X <= 326) uMod = 10;
            uint newfreq = 0;
            if (e.Delta > 0)
            {
                newfreq = curFrequency + uMod;
                if (newfreq > 3304999990) newfreq = 3304999990;
                r30.SetFrequency(newfreq); 
                
                
            }
            else
            {
                newfreq = curFrequency - uMod;
                if (newfreq > 3304999990) newfreq = 3304999990;
                r30.SetFrequency(newfreq);

            }
        }
        private void LblBFreq_MouseWheel(object sender, MouseEventArgs e)
        {
            uint curFrequency = Convert.ToUInt32(lblBFreq.Text.Replace(" ", ""));
            uint uMod = 0;

            // |

            if (e.X > 49 && e.X <= 73) uMod = 1000000000;
            if (e.X > 96 && e.X <= 119) uMod = 100000000;
            if (e.X > 119 && e.X <= 142) uMod = 10000000;
            if (e.X > 142 && e.X <= 165) uMod = 1000000;
            if (e.X > 188 && e.X <= 211) uMod = 100000;
            if (e.X > 211 && e.X <= 234) uMod = 10000;
            if (e.X > 234 && e.X <= 257) uMod = 1000;
            if (e.X > 280 && e.X <= 303) uMod = 100;
            if (e.X > 303 && e.X <= 326) uMod = 10;
            uint newfreq = 0;
            if (e.Delta > 0)
            {
                newfreq = curFrequency + uMod;
                if (newfreq > 3304999990) newfreq = 3304999990;
                r30.SetFrequency(newfreq);
            }
            else
            {
                newfreq = curFrequency - uMod;
                if (newfreq > 3304999990) newfreq = 3304999990;
                r30.SetFrequency(newfreq);
            }
        }

        private void btnDebugSend_Click(object sender, EventArgs e)
        {
            string cmdtext = txtDbgSend.Text.Replace(" ", "");
            byte[] msg = Utils.StringToByteArrayFastest(cmdtext);
            SerialData tmpmsg = new SerialData();
            tmpmsg.ts = DateTime.Now;
            tmpmsg.len = msg.Length;
            tmpmsg.data = msg;
            sph.TXQueue.Enqueue(tmpmsg);
        }

        #region Receive Mode Menu A
        private void mi_Mode_LSB_Click(object sender, EventArgs e)
        {
            r30.SetReceiveMode(model_IC_R30.t_ReceiveMode.LSB);
        }

        private void mi_Mode_USB_Click(object sender, EventArgs e)
        {
            r30.SetReceiveMode(model_IC_R30.t_ReceiveMode.USB);
        }

        private void mi_Mode_AM_Click(object sender, EventArgs e)
        {
            r30.SetReceiveMode(model_IC_R30.t_ReceiveMode.AM);
        }

        private void mi_Mode_AM_N_Click(object sender, EventArgs e)
        {
            r30.SetReceiveMode(model_IC_R30.t_ReceiveMode.AM_N);
        }

        private void mi_Mode_FM_Click(object sender, EventArgs e)
        {
            r30.SetReceiveMode(model_IC_R30.t_ReceiveMode.FM);
        }

        private void mi_Mode_FM_N_Click(object sender, EventArgs e)
        {
            r30.SetReceiveMode(model_IC_R30.t_ReceiveMode.FM_N);
        }

        private void mi_Mode_CW_Click(object sender, EventArgs e)
        {
            r30.SetReceiveMode(model_IC_R30.t_ReceiveMode.CW);
        }

        private void mi_Mode_CW_R_Click(object sender, EventArgs e)
        {
            r30.SetReceiveMode(model_IC_R30.t_ReceiveMode.CW_R);
        }

        private void mi_Mode_WFM_Click(object sender, EventArgs e)
        {
            r30.SetReceiveMode(model_IC_R30.t_ReceiveMode.WFM);
        }

        private void mi_Mode_DSTAR_Click(object sender, EventArgs e)
        {
            r30.SetReceiveMode(model_IC_R30.t_ReceiveMode.D_STAR);
        }

        private void mi_Mode_P25_Click(object sender, EventArgs e)
        {
            r30.SetReceiveMode(model_IC_R30.t_ReceiveMode.P25);
        }

        private void mi_Mode_dPMR_Click(object sender, EventArgs e)
        {
            r30.SetReceiveMode(model_IC_R30.t_ReceiveMode.dPMR);
        }

        private void mi_Mode_NXDX_VN_Click(object sender, EventArgs e)
        {
            r30.SetReceiveMode(model_IC_R30.t_ReceiveMode.NXDN_VN);
        }

        private void mi_Mode_NXDN_N_Click(object sender, EventArgs e)
        {
            r30.SetReceiveMode(model_IC_R30.t_ReceiveMode.NXDN_N);
        }

        private void mi_Mode_DCR_Click(object sender, EventArgs e)
        {
            r30.SetReceiveMode(model_IC_R30.t_ReceiveMode.DCR);
        }
        #endregion
        #region Recieve Mode Menu B
        private void mi_B_Mode_AM_Click(object sender, EventArgs e)
        {
            r30.SetReceiveMode(model_IC_R30.t_ReceiveMode.AM);
        }
        private void mi_B_Mode_DCR_Click(object sender, EventArgs e)
        {
            r30.SetReceiveMode(model_IC_R30.t_ReceiveMode.DCR);
        }
        private void mi_B_Mode_dPMR_Click(object sender, EventArgs e)
        {
            r30.SetReceiveMode(model_IC_R30.t_ReceiveMode.dPMR);
        }
        private void mi_B_Mode_DSTAR_Click(object sender, EventArgs e)
        {
            r30.SetReceiveMode(model_IC_R30.t_ReceiveMode.D_STAR);
        }
        private void mi_B_Mode_FM_Click(object sender, EventArgs e)
        {
            r30.SetReceiveMode(model_IC_R30.t_ReceiveMode.FM);
        }
        private void mi_B_Mode_NXDN_VN_Click(object sender, EventArgs e)
        {
            r30.SetReceiveMode(model_IC_R30.t_ReceiveMode.NXDN_VN);
        }
        private void mi_B_Mode_NXDN_N_Click(object sender, EventArgs e)
        {
            r30.SetReceiveMode(model_IC_R30.t_ReceiveMode.NXDN_N);
        }
        private void mi_B_Mode_P25_Click(object sender, EventArgs e)
        {
            r30.SetReceiveMode(model_IC_R30.t_ReceiveMode.P25);
        }
        #endregion

        private void lblA_GHz_Ind_Click(object sender, EventArgs e)
        {
            GUI_Update_A_FreqEntry_Type(1000000000);
        }
        private void lblB_GHz_Ind_Click(object sender, EventArgs e)
        {
            GUI_Update_B_FreqEntry_Type(1000000000);
        }
        private void lblA_MHz_Ind_Click(object sender, EventArgs e)
        {
            GUI_Update_A_FreqEntry_Type(1000000);
        }
        private void lblB_MHz_Ind_Click(object sender, EventArgs e)
        {
            GUI_Update_B_FreqEntry_Type(1000000);
        }
        private void lblA_KHz_Ind_Click(object sender, EventArgs e)
        {
            GUI_Update_A_FreqEntry_Type(1000);
        }
        private void lblB_KHz_Ind_Click(object sender, EventArgs e)
        {
            GUI_Update_B_FreqEntry_Type(1000);
        }
        private void lblA_Hz_Ind_Click(object sender, EventArgs e)
        {
            GUI_Update_A_FreqEntry_Type(1);
        }
        private void lblB_Hz_Ind_Click(object sender, EventArgs e)
        {
            GUI_Update_B_FreqEntry_Type(1);
        }
        private void txtA_FreqEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch ((byte)e.KeyChar)
            {
                // 0-9 and .
                case 0x30:
                case 0x31:
                case 0x32:
                case 0x33:
                case 0x34:
                case 0x35:
                case 0x36:
                case 0x37:
                case 0x38:
                case 0x39:
                case 0x2E:
                    break;
                // G or g
                case 0x47:
                case 0x67:
                    uint gfreq = GUI_A_ValidateFreqEntry(1000000000);
                    if (gfreq > 0)
                    {
                        r30.SetFrequency(gfreq);
                        txtA_FreqEntry.Clear();
                    }
                    e.Handled = true;
                    break;
                // M or m
                case 0x4D:
                case 0x6D:
                    uint mfreq = GUI_A_ValidateFreqEntry(1000000);
                    if (mfreq > 0)
                    {
                        r30.SetFrequency(mfreq);
                        txtA_FreqEntry.Clear();
                    }
                    e.Handled = true;
                    break;
                // K or k
                case 0x4B:
                case 0x6B:
                    uint kfreq = GUI_A_ValidateFreqEntry(1000);
                    if (kfreq > 0)
                    {
                        r30.SetFrequency(kfreq);
                        txtA_FreqEntry.Clear();
                    }
                    e.Handled = true;
                    break;
                case 0x48:
                case 0x68:
                    uint hfreq = GUI_A_ValidateFreqEntry(1);
                    if (hfreq > 0)
                    {
                        r30.SetFrequency(hfreq);
                        txtA_FreqEntry.Clear();
                    }
                    e.Handled = true;
                    break;
                case 0x0D:
                    uint freq = GUI_A_ValidateFreqEntry(0);
                    if (freq > 0)
                    {
                        r30.SetFrequency(freq);
                        txtA_FreqEntry.Clear();
                    }
                    e.Handled = true;
                    break;
            }
        }
        private void txtB_FreqEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch ((byte)e.KeyChar)
            {
                // 0-9 and .
                case 0x30:
                case 0x31:
                case 0x32:
                case 0x33:
                case 0x34:
                case 0x35:
                case 0x36:
                case 0x37:
                case 0x38:
                case 0x39:
                case 0x2E:
                    break;
                // G or g
                case 0x47:
                case 0x67:
                    uint gfreq = GUI_B_ValidateFreqEntry(1000000000);
                    if (gfreq > 0)
                    {
                        r30.SetFrequency(gfreq);
                        txtB_FreqEntry.Clear();
                    }
                    e.Handled = true;
                    break;
                // M or m
                case 0x4D:
                case 0x6D:
                    uint mfreq = GUI_B_ValidateFreqEntry(1000000);
                    if (mfreq > 0)
                    {
                        r30.SetFrequency(mfreq);
                        txtB_FreqEntry.Clear();
                    }
                    e.Handled = true;
                    break;
                // K or k
                case 0x4B:
                case 0x6B:
                    uint kfreq = GUI_B_ValidateFreqEntry(1000);
                    if (kfreq > 0)
                    {
                        r30.SetFrequency(kfreq);
                        txtB_FreqEntry.Clear();
                    }
                    e.Handled = true;
                    break;
                case 0x48:
                case 0x68:
                    uint hfreq = GUI_B_ValidateFreqEntry(1);
                    if (hfreq > 0)
                    {
                        r30.SetFrequency(hfreq);
                        txtB_FreqEntry.Clear();
                    }
                    e.Handled = true;
                    break;
                case 0x0D:
                    uint freq = GUI_B_ValidateFreqEntry(0);
                    if (freq > 0)
                    {
                        r30.SetFrequency(freq);
                        txtB_FreqEntry.Clear();
                    }
                    e.Handled = true;
                    break;
            }
        }
        public uint GUI_A_ValidateFreqEntry(uint mult = 0)
        {
            if (mult == 0)
            {
                mult = GUI_A_FreqEntryMultiplier;
            }
            double enteredFreq;
            try
            {
                enteredFreq = Convert.ToDouble(txtA_FreqEntry.Text);
            }
            catch (Exception e)
            {
                return 0;
            }
            uint finalfreq = (uint)(enteredFreq * (double)mult);
            return finalfreq;
        }
        public uint GUI_B_ValidateFreqEntry(uint mult = 0)
        {
            if (mult == 0)
            {
                mult = GUI_B_FreqEntryMultiplier;
            }
            double enteredFreq;
            try
            {
                enteredFreq = Convert.ToDouble(txtB_FreqEntry.Text);
            }
            catch (Exception e)
            {
                return 0;
            }
            uint finalfreq = (uint)(enteredFreq * (double)mult);
            return finalfreq;
        }
        private void trk_A_AFGain_Scroll(object sender, EventArgs e)
        {
            r30.SetAFGain((uint)trk_A_AFGain.Value);
        }
        private void trk_B_AFGain_Scroll(object sender, EventArgs e)
        {
            r30.SetAFGain((uint)trk_B_AFGain.Value);
        }
        private void tslbl_A_RecStatus_Click(object sender, EventArgs e)
        {
            if ((string)tslbl_A_RecStatus.Tag == "ON")
            {
                r30.SetRecording(false);
            }
            else
            {
                r30.SetRecording(true);
            }
        }
        private void tslbl_B_RecStatus_Click(object sender, EventArgs e)
        {
            if ((string)tslbl_B_RecStatus.Tag == "ON")
            {
                r30.SetRecording(false);
            }
            else
            {
                r30.SetRecording(true);
            }
        }
        #region KeypadA
        private void btn_A_KP1_Click(object sender, EventArgs e)
        {
            txtA_FreqEntry.Focus();
            SendKeys.Send("1");
        }
        private void btn_A_KP2_Click(object sender, EventArgs e)
        {
            txtA_FreqEntry.Focus();
            SendKeys.Send("2");
        }
        private void btn_A_KP3_Click(object sender, EventArgs e)
        {
            txtA_FreqEntry.Focus();
            SendKeys.Send("3");
        }
        private void btn_A_KP4_Click(object sender, EventArgs e)
        {
            txtA_FreqEntry.Focus();
            SendKeys.Send("4");
        }
        private void btn_A_KP5_Click(object sender, EventArgs e)
        {
            txtA_FreqEntry.Focus();
            SendKeys.Send("5");
        }
        private void btn_A_KP6_Click(object sender, EventArgs e)
        {
            txtA_FreqEntry.Focus();
            SendKeys.Send("6");
        }
        private void btn_A_KP7_Click(object sender, EventArgs e)
        {
            txtA_FreqEntry.Focus();
            SendKeys.Send("7");
        }
        private void btn_A_KP8_Click(object sender, EventArgs e)
        {
            txtA_FreqEntry.Focus();
            SendKeys.Send("8");
        }
        private void btn_A_KP9_Click(object sender, EventArgs e)
        {
            txtA_FreqEntry.Focus();
            SendKeys.Send("9");
        }
        private void btn_A_KP0_Click(object sender, EventArgs e)
        {
            txtA_FreqEntry.Focus();
            SendKeys.Send("0");
        }
        private void btn_A_KPdot_Click(object sender, EventArgs e)
        {
            txtA_FreqEntry.Focus();
            SendKeys.Send(".");
        }
        private void btn_A_KPEnter_Click(object sender, EventArgs e)
        {
            txtA_FreqEntry.Focus();
            SendKeys.Send("{ENTER}");
        }
        #endregion
        #region KeyPadB
        private void btn_B_KP1_Click(object sender, EventArgs e)
        {
            txtB_FreqEntry.Focus();
            SendKeys.Send("1");
        }
        private void btn_B_KP2_Click(object sender, EventArgs e)
        {
            txtB_FreqEntry.Focus();
            SendKeys.Send("2");
        }
        private void btn_B_KP3_Click(object sender, EventArgs e)
        {
            txtB_FreqEntry.Focus();
            SendKeys.Send("3");
        }
        private void btn_B_KP4_Click(object sender, EventArgs e)
        {
            txtB_FreqEntry.Focus();
            SendKeys.Send("4");
        }
        private void btn_B_KP5_Click(object sender, EventArgs e)
        {
            txtB_FreqEntry.Focus();
            SendKeys.Send("5");
        }
        private void btn_B_KP6_Click(object sender, EventArgs e)
        {
            txtB_FreqEntry.Focus();
            SendKeys.Send("6");
        }
        private void btn_B_KP7_Click(object sender, EventArgs e)
        {
            txtB_FreqEntry.Focus();
            SendKeys.Send("7");
        }
        private void btn_B_KP8_Click(object sender, EventArgs e)
        {
            txtB_FreqEntry.Focus();
            SendKeys.Send("8");
        }
        private void btn_B_KP9_Click(object sender, EventArgs e)
        {
            txtB_FreqEntry.Focus();
            SendKeys.Send("9");
        }
        private void btn_B_KP0_Click(object sender, EventArgs e)
        {
            txtB_FreqEntry.Focus();
            SendKeys.Send("0");
        }
        private void btn_B_KPdot_Click(object sender, EventArgs e)
        {
            txtB_FreqEntry.Focus();
            SendKeys.Send(".");
        }
        private void btn_B_KPEnter_Click(object sender, EventArgs e)
        {
            txtB_FreqEntry.Focus();
            SendKeys.Send("{ENTER}");
        }
        #endregion
        private void trk_A_RFGain_Scroll(object sender, EventArgs e)
        {
            int alterval = 0;
            switch (trk_A_RFGain.Value)
            {
                case 0:
                    r30.SetRFGain((uint)model_IC_R30.t_RFGain.RFG1);
                    break;
                case 3:
                    r30.SetRFGain((uint)model_IC_R30.t_RFGain.RFG2);
                    break;
                case 6:
                    r30.SetRFGain((uint)model_IC_R30.t_RFGain.RFG3);
                    break;
                case 9:
                    r30.SetRFGain((uint)model_IC_R30.t_RFGain.RFG4);
                    break;
                case 12:
                    r30.SetRFGain((uint)model_IC_R30.t_RFGain.RFG5);
                    break;
                case 15:
                    r30.SetRFGain((uint)model_IC_R30.t_RFGain.RFG6);
                    break;
                case 18:
                    r30.SetRFGain((uint)model_IC_R30.t_RFGain.RFG7);
                    break;
                case 21:
                    r30.SetRFGain((uint)model_IC_R30.t_RFGain.RFG8);
                    break;
                case 24:
                    r30.SetRFGain((uint)model_IC_R30.t_RFGain.RFG9);
                    break;
                case 27:
                    r30.SetRFGain((uint)model_IC_R30.t_RFGain.RFGMAX);
                    break;
            }
        }
        private void trk_B_RFGain_Scroll(object sender, EventArgs e)
        {
            int alterval = 0;
            switch (trk_B_RFGain.Value)
            {
                case 0:
                    r30.SetRFGain((uint)model_IC_R30.t_RFGain.RFG1);
                    break;
                case 3:
                    r30.SetRFGain((uint)model_IC_R30.t_RFGain.RFG2);
                    break;
                case 6:
                    r30.SetRFGain((uint)model_IC_R30.t_RFGain.RFG3);
                    break;
                case 9:
                    r30.SetRFGain((uint)model_IC_R30.t_RFGain.RFG4);
                    break;
                case 12:
                    r30.SetRFGain((uint)model_IC_R30.t_RFGain.RFG5);
                    break;
                case 15:
                    r30.SetRFGain((uint)model_IC_R30.t_RFGain.RFG6);
                    break;
                case 18:
                    r30.SetRFGain((uint)model_IC_R30.t_RFGain.RFG7);
                    break;
                case 21:
                    r30.SetRFGain((uint)model_IC_R30.t_RFGain.RFG8);
                    break;
                case 24:
                    r30.SetRFGain((uint)model_IC_R30.t_RFGain.RFG9);
                    break;
                case 27:
                    r30.SetRFGain((uint)model_IC_R30.t_RFGain.RFGMAX);
                    break;
            }
        }
        private void trk_A_SqlLvl_Scroll(object sender, EventArgs e)
        {
            int iVal = trk_A_SqlLvl.Value;
            switch(iVal)
            {
                case 0:
                    r30.SetSquelchLvl(0);
                    break;
                case 3:
                    r30.SetSquelchLvl(30);
                    break;
                case 6:
                    r30.SetSquelchLvl(55);
                    break;
                case 9:
                    r30.SetSquelchLvl(80);
                    break;
                case 12:
                    r30.SetSquelchLvl(105);
                    break;
                case 15:
                    r30.SetSquelchLvl(125);
                    break;
                case 18:
                    r30.SetSquelchLvl(150);
                    break;
                case 21:
                    r30.SetSquelchLvl(170);
                    break;
                case 24:
                    r30.SetSquelchLvl(195);
                    break;
                case 27:
                    r30.SetSquelchLvl(220);
                    break;
                case 30:
                    r30.SetSquelchLvl(244);
                    break;
            }
        }
        private void trk_B_SqlLvl_Scroll(object sender, EventArgs e)
        {
            int iVal = trk_B_SqlLvl.Value;
            switch (iVal)
            {
                case 0:
                    r30.SetSquelchLvl(0);
                    break;
                case 3:
                    r30.SetSquelchLvl(30);
                    break;
                case 6:
                    r30.SetSquelchLvl(55);
                    break;
                case 9:
                    r30.SetSquelchLvl(80);
                    break;
                case 12:
                    r30.SetSquelchLvl(105);
                    break;
                case 15:
                    r30.SetSquelchLvl(125);
                    break;
                case 18:
                    r30.SetSquelchLvl(150);
                    break;
                case 21:
                    r30.SetSquelchLvl(170);
                    break;
                case 24:
                    r30.SetSquelchLvl(195);
                    break;
                case 27:
                    r30.SetSquelchLvl(220);
                    break;
                case 30:
                    r30.SetSquelchLvl(244);
                    break;
            }
        }
        private void lblAFreq_MouseClick(object sender, MouseEventArgs e)
        {
            uint curFrequency = Convert.ToUInt32(lblAFreq.Text.Replace(" ", ""));
            uint uMod = 0;

            // |

            if (e.X > 49 && e.X <= 73) uMod = 1000000000;
            if (e.X > 96 && e.X <= 119) uMod = 100000000;
            if (e.X > 119 && e.X <= 142) uMod = 10000000;
            if (e.X > 142 && e.X <= 165) uMod = 1000000;
            if (e.X > 188 && e.X <= 211) uMod = 100000;
            if (e.X > 211 && e.X <= 234) uMod = 10000;
            if (e.X > 234 && e.X <= 257) uMod = 1000;
            if (e.X > 280 && e.X <= 303) uMod = 100;
            if (e.X > 303 && e.X <= 326) uMod = 10;

            if (e.Y <= 15)
            {
                r30.SetFrequency(curFrequency + uMod);
            }
            else
            {
                r30.SetFrequency(curFrequency - uMod);
            }
        }
        private void lblBFreq_MouseClick(object sender, MouseEventArgs e)
        {
            uint curFrequency = Convert.ToUInt32(lblBFreq.Text.Replace(" ", ""));
            uint uMod = 0;

            // |

            if (e.X > 49 && e.X <= 73) uMod = 1000000000;
            if (e.X > 96 && e.X <= 119) uMod = 100000000;
            if (e.X > 119 && e.X <= 142) uMod = 10000000;
            if (e.X > 142 && e.X <= 165) uMod = 1000000;
            if (e.X > 188 && e.X <= 211) uMod = 100000;
            if (e.X > 211 && e.X <= 234) uMod = 10000;
            if (e.X > 234 && e.X <= 257) uMod = 1000;
            if (e.X > 280 && e.X <= 303) uMod = 100;
            if (e.X > 303 && e.X <= 326) uMod = 10;

            if (e.Y <= 15)
            {
                r30.SetFrequency(curFrequency + uMod);
            }
            else
            {
                r30.SetFrequency(curFrequency - uMod);
            }
        }

        private void btnPower_Click(object sender, EventArgs e)
        {
            r30.SetR30PowerState(true);
            Thread.Sleep(500);
            R30_Disconnect();
            R30_Connect();
        }

        private void mi_A_VFO_Click(object sender, EventArgs e)
        {
            r30.SetOperatingMode(model_IC_R30.t_OperatingMode.VFO);
        }

        private void mi_A_MEM_Click(object sender, EventArgs e)
        {
            r30.SetOperatingMode(model_IC_R30.t_OperatingMode.MEM);
        }

        private void mi_A_WX_Click(object sender, EventArgs e)
        {
            r30.SetOperatingMode(model_IC_R30.t_OperatingMode.WX);
        }

        private void mi_B_VFO_Click(object sender, EventArgs e)
        {
            r30.SetOperatingMode(model_IC_R30.t_OperatingMode.VFO);
        }

        private void mi_B_MEM_Click(object sender, EventArgs e)
        {
            r30.SetOperatingMode(model_IC_R30.t_OperatingMode.MEM);
        }

        private void mi_B_WX_Click(object sender, EventArgs e)
        {
            r30.SetOperatingMode(model_IC_R30.t_OperatingMode.WX);
        }
        private void sb_A_Scan_ButtonClick(object sender, EventArgs e)
        {
            if (sb_A_Scan.Text == "Cancel Scan")
            {
                r30.StopScanning();
                r30.ReqScanCondition();
            }
            else
            {
                sb_A_Scan.ShowDropDown();
            }
        }

        private void sb_A_Scan_DropDownOpening(object sender, EventArgs e)
        {
            if(r30.RFA.OperatingMode == model_IC_R30.t_OperatingMode.MEM) GUI_Populate_Scan_Memory(false);
            if (r30.RFA.OperatingMode == model_IC_R30.t_OperatingMode.VFO) GUI_Populate_Scan_Edges(false);
        }

        private void sb_B_Scan_ButtonClick(object sender, EventArgs e)
        {
            if (sb_B_Scan.Text == "Cancel Scan")
            {
                r30.StopScanning();
                r30.ReqScanCondition();
            }
            else
            {
                sb_B_Scan.ShowDropDown();
            }
        }

        private void sb_B_Scan_DropDownOpening(object sender, EventArgs e)
        {
            if (r30.RFB.OperatingMode == model_IC_R30.t_OperatingMode.MEM) GUI_Populate_Scan_Memory(true);
            if (r30.RFB.OperatingMode == model_IC_R30.t_OperatingMode.VFO) GUI_Populate_Scan_Edges(true);
        }

        private void btn_ScanCtrl_Skip_Click(object sender, EventArgs e)
        {
            r30.SetSkip();
        }

        private void btn_B_ScanCtrl_Skip_Click(object sender, EventArgs e)
        {
            r30.SetSkip();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            r30.SetR30PowerState(false);
            Thread.Sleep(500);
            R30_Disconnect();
        }

        private void sb_A_Mode_ButtonClick(object sender, EventArgs e)
        {
            sb_A_Mode.ShowDropDown();
        }

        private void sb_B_Mode_ButtonClick(object sender, EventArgs e)
        {
            sb_B_Mode.ShowDropDown();
        }
        #endregion

        private void RoutePacket(object sender, PacketDataEventArgs e)
        {
            // This is the handler for packet received events. It routes packets based on the
            // command type to packet handlers that do a full decode of their contents.
            // The packet receive chain looks like:
            // Serial port -> RX Queue -> PacketHandler Event -> [This function] -> R30Packet_*
            // (Packet handler) -> GUI_Update_* (Updates display where necessary)

            // From here out there is a lot of this use of the "RFB" flag. We figure out as early
            // as possible which channel we should be updating and RFB = false means RF A is main
            bool RFB = e.serialData.RFB;

            switch (e.serialData.data[4])
            {
                // Commands 0x00 and 0x03 Both return frequency for *Main* channel.
                case 0x00:
                case 0x03:
                    if (e.serialData.len == 11)
                    {
                        if (r30.DualBandMode == model_IC_R30.t_DualBandMode.SingleBMain || r30.DualBandMode == model_IC_R30.t_DualBandMode.DualBMain) RFB = true;
                        byte[] bFreqData = new byte[5];
                        System.Buffer.BlockCopy(e.serialData.data, 5, bFreqData, 0, 5);
                        R30Packet_FreqChanged(bFreqData, RFB);
                    }
                    break;
                case 0x01:
                case 0x04:
                    // Commands 0x01 and 0x04 both return the mode (modulation) in like format
                    if (r30.DualBandMode == model_IC_R30.t_DualBandMode.SingleBMain || r30.DualBandMode == model_IC_R30.t_DualBandMode.DualBMain) RFB = true;
                    byte[] bModeData = new byte[2];
                    System.Buffer.BlockCopy(e.serialData.data, 5, bModeData, 0, 2);
                    R30Packet_ModeChanged(bModeData, RFB);

                    // We also trigger a refresh of CanScan flag for scan entries.
                    r30.ReqScanInformation();
                    break;
                case 0x14:
                    if (r30.DualBandMode == model_IC_R30.t_DualBandMode.SingleBMain || r30.DualBandMode == model_IC_R30.t_DualBandMode.DualBMain) RFB = true;
                    switch (e.serialData.data[5])
                    {
                        case 0x01:
                            byte[] bAFGain = new byte[2];
                            System.Buffer.BlockCopy(e.serialData.data, 6, bAFGain, 0, 2);
                            R30Packet_AFGainChanged(bAFGain, RFB);
                            break;
                        case 0x02:
                            byte[] bRFGain = new byte[2];
                            System.Buffer.BlockCopy(e.serialData.data, 6, bRFGain, 0, 2);
                            R30Packet_RFGainChanged(bRFGain, RFB);
                            break;
                        case 0x03:
                            byte[] bSqlLvl = new byte[2];
                            System.Buffer.BlockCopy(e.serialData.data, 6, bSqlLvl, 0, 2);
                            R30Packet_SqlLvlChanged(bSqlLvl, RFB);
                            break;
                    }
                    break;
                case 0x15:
                    switch(e.serialData.data[5])
                    {
                        case 0x02:
                            if (r30.DualBandMode == model_IC_R30.t_DualBandMode.SingleBMain || r30.DualBandMode == model_IC_R30.t_DualBandMode.DualBMain) RFB = true;
                            byte[] bSMeter = new byte[2];
                            System.Buffer.BlockCopy(e.serialData.data, 6, bSMeter, 0, 2);
                            R30Packet_SMeterChanged(bSMeter, RFB);
                            break;
                    }
                    break;
                case 0x16:
                    switch(e.serialData.data[5])
                    {

                    }
                    break;
                case 0x1A:
                    if (e.serialData.data[5] == 0x10)
                    {
                        if (e.serialData.data[6] == 0x01 || e.serialData.data[6] == 0x02)
                        {
                            switch (e.serialData.data[7])
                            {
                                case 0x00:

                                    break;
                                case 0x01:
                                    r30.ReqDisplayContentSpecificRF(0x00);
                                    if (r30.DualBandMode != model_IC_R30.t_DualBandMode.SingleAMain) r30.ReqDisplayContentSpecificRF(0x01);
                                    break;
                                case 0x02:
                                    if (r30.DualBandMode != model_IC_R30.t_DualBandMode.SingleAMain) r30.ReqDisplayContentSpecificRF(0x00);
                                    r30.ReqDisplayContentSpecificRF(0x01);
                                    break;
                                case 0x03:
                                    r30.ReqDisplayContentSpecificRF(0x00);
                                    r30.ReqDisplayContentSpecificRF(0x01);
                                    break;
                            }
                        }
                    }
                    if (e.serialData.data[5] == 0x0B)
                    {
                        if (e.serialData.data[6] == 0x02)
                        {
                            R30Packet_ScanCondition(new byte[] { e.serialData.data[7], e.serialData.data[8] });
                        }
                    }
                    if(e.serialData.data[5] == 0x0C)
                    {
                        byte[] bScanInfo = new byte[32];
                        System.Buffer.BlockCopy(e.serialData.data, 6, bScanInfo, 0, 32);
                        R30Packet_ScanInformation(bScanInfo, RFB);
                    }
                    if (e.serialData.data[5] == 0x11)
                    {
                        byte[] bDispContent = new byte[e.serialData.len - 7];
                        System.Buffer.BlockCopy(e.serialData.data, 6, bDispContent, 0, e.serialData.len - 7);
                        R30Packet_DisplayContent(bDispContent, RFB);
                    }

                    if (e.serialData.data[5] == 0x12)
                    {
                        byte[] bSquelchSMeter = new byte[e.serialData.len - 7];
                        System.Buffer.BlockCopy(e.serialData.data, 6, bSquelchSMeter, 0, e.serialData.len - 7);
                        R30Packet_SqlSMeterChanged(bSquelchSMeter, RFB);
                    }

                    if (e.serialData.data[5] == 0x0F)
                    {
                        switch (e.serialData.data[6])
                        {
                            case 0x00:
                                byte[] bMemGrpData = new byte[240];
                                System.Buffer.BlockCopy(e.serialData.data, 7, bMemGrpData, 0, 240);
                                R30Packet_Update_Memory_Groups(bMemGrpData);
                                break;
                        }
                    }
                    if (e.serialData.data[5] == 0x0E)
                    {
                        switch (e.serialData.data[6])
                        {
                            case 0x00:
                                byte[] bScanEdgeData = new byte[240];
                                System.Buffer.BlockCopy(e.serialData.data, 7, bScanEdgeData, 0, 240);
                                R30Packet_Update_ScanEdges(bScanEdgeData);
                                break;
                        }
                    }
                    break;
                case 0x1B:
                    switch(e.serialData.data[5])
                    {
                        case 0x01:
                            byte[] bTSQLFreq = new byte[3];
                            System.Buffer.BlockCopy(e.serialData.data, 6, bTSQLFreq, 0, 3);
                            R30Packet_TSQLFreqChanged(bTSQLFreq, RFB);
                            break;
                        case 0x02:
                            byte[] bDTCSCode = new byte[3];
                            System.Buffer.BlockCopy(e.serialData.data, 6, bDTCSCode, 0, 3);
                            R30Packet_DTCSCodeChanged(bDTCSCode, RFB);
                            break;
                    }
                    break;
                case 0x20:
                    switch(e.serialData.data[5])
                    {
                        case 0x06:
                            if (e.serialData.data[6] == 0x01 || e.serialData.data[6] == 0x02)
                            {
                                byte[] bP25RXID = new byte[17];
                                System.Buffer.BlockCopy(e.serialData.data, 7, bP25RXID, 0, 17);
                                R30Packet_P25RXIDChanged(bP25RXID, RFB);
                            }
                            break;
                    }
                    break;
                case 0x29:
                    PacketDataEventArgs newargs = new PacketDataEventArgs();
                    SerialData newsd = new SerialData();
                    newsd.len = e.serialData.len - 2;
                    newsd.ts = e.serialData.ts;
                    newsd.data = new byte[e.serialData.len - 2];
                    System.Buffer.BlockCopy(e.serialData.data, 0, newsd.data, 0, 4);
                    System.Buffer.BlockCopy(e.serialData.data, 6, newsd.data, 4, e.serialData.len - 6);
                    if (e.serialData.data[5] == 0x01) newsd.RFB = true;
                    newargs.serialData = newsd;

                    RoutePacket(this, newargs);

                    break;
            }

        }

        #region GUI Updaters

        public void GUI_Update_A_RecStatus(string s)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(GUI_Update_A_RecStatus), new object[] { s });
                return;
            }
            tslbl_A_RecStatus.Text = s;
            switch(s)
            {
                case "Recording":
                    tslbl_A_RecStatus.ForeColor = Color.SeaGreen;
                    tslbl_A_RecStatus.Tag = "ON";
                    break;
                case "Paused":
                    tslbl_A_RecStatus.ForeColor = Color.Black;
                    tslbl_A_RecStatus.Tag = "ON";
                    break;
                case "Stopped":
                    tslbl_A_RecStatus.ForeColor = Color.Black;
                    tslbl_A_RecStatus.Tag = "OFF";
                    break;
            }
        }
        public void GUI_Update_B_RecStatus(string s)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(GUI_Update_B_RecStatus), new object[] { s });
                return;
            }
            tslbl_B_RecStatus.Text = s;
            switch (s)
            {
                case "Recording":
                    tslbl_B_RecStatus.ForeColor = Color.SeaGreen;
                    tslbl_B_RecStatus.Tag = "ON";
                    break;
                case "Paused":
                    tslbl_B_RecStatus.ForeColor = Color.Black;
                    tslbl_B_RecStatus.Tag = "ON";
                    break;
                case "Stopped":
                    tslbl_B_RecStatus.ForeColor = Color.Black;
                    tslbl_B_RecStatus.Tag = "OFF";
                    break;
            }
        }
        public void GUI_SetDualBandControlProperties(model_IC_R30.t_DualBandMode mode)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<model_IC_R30.t_DualBandMode>(GUI_SetDualBandControlProperties), new object[] { mode });
                return;
            }
            switch (mode)
            {
                case model_IC_R30.t_DualBandMode.SingleAMain:
                    grpRecB.Visible = false;
                    grpRecA.Visible = true;
                    mtsdb_Layout.Text = "Single A";
                    lModeSettingsB.X = 627;
                    lModeSettingsB.Y = 424;
                    grp_B_AM.Location = lModeSettingsB;
                    grp_B_FM.Location = lModeSettingsB;
                    grp_B_P25.Location = lModeSettingsB;
                    this.Height = 450;
                    mtslbl_Switching.Visible = false;
                    mtsdb_SwitchingType.Visible = false;
                    r30.ReqScanInformation();
                    r30.ReqSqlLvl();
                    SetReceiverControls(false, true);
                    if (!r30.MemoryGroups.InitComplete) r30.ReqMemoryGroups();
                    if (!r30.ProgramEdges.InitComplete) r30.ReqVFOPrograms();
                    break;
                case model_IC_R30.t_DualBandMode.SingleBMain:
                    grpRecA.Visible = false;
                    grpRecB.Location = lMainReceiver;
                    lModeSettingsB = lModeSettingsA;
                    grp_B_AM.Location = lModeSettingsB;
                    grp_B_FM.Location = lModeSettingsB;
                    grp_B_P25.Location = lModeSettingsB;
                    grpRecB.Visible = true;
                    mtsdb_Layout.Text = "Single B";
                    this.Height = 450;
                    mtslbl_Switching.Visible = false;
                    mtsdb_SwitchingType.Visible = false;
                    r30.ReqScanInformation();
                    r30.ReqSqlLvl();
                    SetReceiverControls(true, true);
                    if (!r30.MemoryGroups.InitComplete) r30.ReqMemoryGroups();
                    if (!r30.ProgramEdges.InitComplete) r30.ReqVFOPrograms();
                    break;
                case model_IC_R30.t_DualBandMode.DualAMain:
                    grpRecB.Location = lSubReceiver;
                    grpRecB.Visible = true;
                    grpRecA.Visible = true;
                    lModeSettingsB.X = 627;
                    lModeSettingsB.Y = 424;
                    grp_B_AM.Location = lModeSettingsB;
                    grp_B_FM.Location = lModeSettingsB;
                    grp_B_P25.Location = lModeSettingsB;
                    SetRcvFrameColor(0, System.Drawing.Color.ForestGreen);
                    SetRcvFrameColor(1, this.BackColor);
                    mtsdb_Layout.Text = "Dual";
                    this.Height = 843;
                    SetReceiverControls(false, true);
                    if (mtsdb_SwitchingType.Text == "Manual")
                    {
                        SetReceiverControls(false, true);
                        SetReceiverControls(true, false);
                    }
                    mtslbl_Switching.Visible = true;
                    mtsdb_SwitchingType.Visible = true;
                    r30.ReqScanInformation();
                    r30.ReqSqlLvl();
                    if (!r30.MemoryGroups.InitComplete) r30.ReqMemoryGroups();
                    if (!r30.ProgramEdges.InitComplete) r30.ReqVFOPrograms();
                    break;
                case model_IC_R30.t_DualBandMode.DualBMain:
                    SetRcvFrameColor(1, System.Drawing.Color.ForestGreen);
                    SetRcvFrameColor(0, this.BackColor);
                    grpRecB.Location = lSubReceiver;
                    grpRecB.Visible = true;
                    grpRecA.Visible = true;
                    mtsdb_Layout.Text = "Dual";
                    this.Height = 843;
                    lModeSettingsB.X = 627;
                    lModeSettingsB.Y = 424;
                    grp_B_AM.Location = lModeSettingsB;
                    grp_B_FM.Location = lModeSettingsB;
                    grp_B_P25.Location = lModeSettingsB;
                    SetReceiverControls(true, true);
                    if (mtsdb_SwitchingType.Text == "Manual")
                    {
                        SetReceiverControls(true, true);
                        SetReceiverControls(false, false);
                    }
                    mtslbl_Switching.Visible = true;
                    mtsdb_SwitchingType.Visible = true;
                    r30.ReqScanInformation();
                    r30.ReqSqlLvl();
                    if (!r30.MemoryGroups.InitComplete) r30.ReqMemoryGroups();
                    if (!r30.ProgramEdges.InitComplete) r30.ReqVFOPrograms();
                    break;
            }
        }
        public void GUI_Update_A_Frequency(uint freq)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<uint>(GUI_Update_A_Frequency), new object[] { freq });
                return;
            }
            string sFormattedFreq = String.Format("{0:# ### ### ###}", freq);
            lblAFreq.Text = sFormattedFreq;
        }
        public void GUI_Update_B_Frequency(uint freq)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<uint>(GUI_Update_B_Frequency), new object[] { freq });
                return;
            }
            string sFormattedFreq = String.Format("{0:# ### ### ###}", freq);
            lblBFreq.Text = sFormattedFreq;
        }
        public void GUI_Update_A_AFGain(uint uGain)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<uint>(GUI_Update_A_AFGain), new object[] { uGain });
                return;
            }
            trk_A_AFGain.Value = (int)uGain;
        }
        public void GUI_Update_B_AFGain(uint uGain)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<uint>(GUI_Update_B_AFGain), new object[] { uGain });
                return;
            }
            trk_B_AFGain.Value = (int)uGain;
        }
        public void GUI_Update_A_Mode(object o)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<object>(GUI_Update_A_Mode), new object[] { o });
                return;
            }
            switch ((model_IC_R30.t_ReceiveMode)o)
            {
                case model_IC_R30.t_ReceiveMode.LSB:
                    sb_A_Mode.Text = "LSB";
                    break;
                case model_IC_R30.t_ReceiveMode.AM:
                    sb_A_Mode.Text = "AM";
                    break;
                case model_IC_R30.t_ReceiveMode.AM_N:
                    sb_A_Mode.Text = "AM-N";
                    break;
                case model_IC_R30.t_ReceiveMode.CW:
                    sb_A_Mode.Text = "CW";
                    break;
                case model_IC_R30.t_ReceiveMode.CW_R:
                    sb_A_Mode.Text = "CW-R";
                    break;
                case model_IC_R30.t_ReceiveMode.DCR:
                    sb_A_Mode.Text = "DCR";
                    break;
                case model_IC_R30.t_ReceiveMode.dPMR:
                    sb_A_Mode.Text = "dPMR";
                    break;
                case model_IC_R30.t_ReceiveMode.D_STAR:
                    sb_A_Mode.Text = "D_STAR";
                    break;
                case model_IC_R30.t_ReceiveMode.FM:
                    sb_A_Mode.Text = "FM";
                    break;
                case model_IC_R30.t_ReceiveMode.FM_N:
                    sb_A_Mode.Text = "FM-N";
                    break;
                case model_IC_R30.t_ReceiveMode.NXDN_N:
                    sb_A_Mode.Text = "NXDN-N";
                    break;
                case model_IC_R30.t_ReceiveMode.NXDN_VN:
                    sb_A_Mode.Text = "NXDN-VN";
                    break;
                case model_IC_R30.t_ReceiveMode.P25:
                    sb_A_Mode.Text = "P25";
                    break;
                case model_IC_R30.t_ReceiveMode.USB:
                    sb_A_Mode.Text = "USB";
                    break;
                case model_IC_R30.t_ReceiveMode.WFM:
                    sb_A_Mode.Text = "WFM";
                    break;
            }
            GUI_A_ReceiveModeControlUpdates((model_IC_R30.t_ReceiveMode)o);

        }
        public void GUI_Update_B_Mode(object o)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<object>(GUI_Update_B_Mode), new object[] { o });
                return;
            }
            switch ((model_IC_R30.t_ReceiveMode)o)
            {
                case model_IC_R30.t_ReceiveMode.LSB:
                    sb_B_Mode.Text = "LSB";
                    break;
                case model_IC_R30.t_ReceiveMode.AM:
                    sb_B_Mode.Text = "AM";
                    break;
                case model_IC_R30.t_ReceiveMode.AM_N:
                    sb_B_Mode.Text = "AM-N";
                    break;
                case model_IC_R30.t_ReceiveMode.CW:
                    sb_B_Mode.Text = "CW";
                    break;
                case model_IC_R30.t_ReceiveMode.CW_R:
                    sb_B_Mode.Text = "CW-R";
                    break;
                case model_IC_R30.t_ReceiveMode.DCR:
                    sb_B_Mode.Text = "DCR";
                    break;
                case model_IC_R30.t_ReceiveMode.dPMR:
                    sb_B_Mode.Text = "dPMR";
                    break;
                case model_IC_R30.t_ReceiveMode.D_STAR:
                    sb_B_Mode.Text = "D_STAR";
                    break;
                case model_IC_R30.t_ReceiveMode.FM:
                    sb_B_Mode.Text = "FM";
                    break;
                case model_IC_R30.t_ReceiveMode.FM_N:
                    sb_B_Mode.Text = "FM-N";
                    break;
                case model_IC_R30.t_ReceiveMode.NXDN_N:
                    sb_B_Mode.Text = "NXDN-N";
                    break;
                case model_IC_R30.t_ReceiveMode.NXDN_VN:
                    sb_B_Mode.Text = "NXDN-VN";
                    break;
                case model_IC_R30.t_ReceiveMode.P25:
                    sb_B_Mode.Text = "P25";
                    break;
                case model_IC_R30.t_ReceiveMode.USB:
                    sb_B_Mode.Text = "USB";
                    break;
                case model_IC_R30.t_ReceiveMode.WFM:
                    sb_B_Mode.Text = "WFM";
                    break;
            }
            GUI_B_ReceiveModeControlUpdates((model_IC_R30.t_ReceiveMode)o);
        }
        public void GUI_Update_A_OperatingMode(string om)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(GUI_Update_A_OperatingMode), new object[] { om });
                return;
            }
            sb_A_VFOMEM.Text = om;
            //GUI_Populate_Scan_Memory(false);
            switch (om)
            {
                case "VFO":
                    mi_A_MEM.Checked = false;
                    mi_A_VFO.Checked = true;
                    mi_A_WX.Checked = false;
                    lbl_A_MEM_GRP.Visible = false;
                    lbl_A_MEM_MEM.Visible = false;
                    lbl_A_MemGrpName.Visible = false;
                    break;
                case "MEM":
                    mi_A_MEM.Checked = true;
                    mi_A_VFO.Checked = false;
                    mi_A_WX.Checked = false;
                    lbl_A_MEM_GRP.Visible = true;
                    lbl_A_MEM_MEM.Visible = true;
                    lbl_A_MemGrpName.Visible = true;
                    break;
                case "WX":
                    mi_A_MEM.Checked = false;
                    mi_A_VFO.Checked = false;
                    mi_A_WX.Checked = true;
                    lbl_A_MEM_GRP.Visible = false;
                    lbl_A_MEM_MEM.Visible = false;
                    lbl_A_MemGrpName.Visible = false;
                    break;
            }
         }
        public void GUI_Update_B_OperatingMode(string om)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(GUI_Update_B_OperatingMode), new object[] { om });
                return;
            }
            sb_B_VFOMEM.Text = om;
            //GUI_Populate_Scan_Memory(true);
            switch (om)
            {
                case "VFO":
                    mi_B_MEM.Checked = false;
                    mi_B_VFO.Checked = true;
                    mi_B_WX.Checked = false;
                    lbl_B_MemGrpName.Visible = false;
                    lbl_B_MEM_GRP.Visible = false;
                    lbl_B_MEM_MEM.Visible = false;
                    break;
                case "MEM":
                    mi_B_MEM.Checked = true;
                    mi_B_VFO.Checked = false;
                    mi_B_WX.Checked = false;
                    lbl_B_MEM_GRP.Visible = true;
                    lbl_B_MEM_MEM.Visible = true;
                    lbl_B_MemGrpName.Visible = true;
                    break;
                case "WX":
                    mi_B_MEM.Checked = false;
                    mi_B_VFO.Checked = false;
                    mi_B_WX.Checked = true;
                    lbl_B_MEM_GRP.Visible = false;
                    lbl_B_MEM_MEM.Visible = false;
                    lbl_B_MemGrpName.Visible = false;
                    break;
            }
        }
        public void GUI_Update_A_SMeter(uint val)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<uint>(GUI_Update_A_SMeter), new object[] { val });
                return;
            }
            pbASmeter.Maximum = 256;
            pbASmeter.Value = 256;
            pbASmeter.Maximum = 255;
            pbASmeter.Value = (int)val;
        }
        public void GUI_Update_B_SMeter(uint val)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<uint>(GUI_Update_B_SMeter), new object[] { val });
                return;
            }
            pbBSmeter.Maximum = 256;
            pbBSmeter.Value = 256;
            pbBSmeter.Maximum = 255;
            pbBSmeter.Value = (int)val;
        }
        public void GUI_Update_A_RFGain(uint val)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<uint>(GUI_Update_A_RFGain), new object[] { val });
                return;
            }
            trk_A_RFGain.Value = (int)val;
        }
        public void GUI_Update_B_RFGain(uint val)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<uint>(GUI_Update_B_RFGain), new object[] { val });
                return;
            }
            trk_B_RFGain.Value = (int)val;
        }
        public void GUI_Update_A_SqlLvl(uint val)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<uint>(GUI_Update_A_SqlLvl), new object[] { val });
                return;
            }
            if (val == 0)
            {
                trk_A_SqlLvl.Value = 0;
            }
            else
            {
                trk_A_SqlLvl.Value = ((int)val / 24) * 3;
            }
            
        }
        public void GUI_Update_B_SqlLvl(uint val)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<uint>(GUI_Update_B_SqlLvl), new object[] { val });
                return;
            }
            if (val == 0)
            {
                trk_B_SqlLvl.Value = 0;
            }
            else
            {
                trk_B_SqlLvl.Value = ((int)val / 24) * 3;
            }
        }
        public void GUI_Update_A_FreqEntry_Type(uint multiplier)
        {
            GUI_A_FreqEntryMultiplier = multiplier;
            switch (multiplier)
            {
                case 1000000000:
                    lblA_GHz_Ind.BackColor = Color.SeaGreen;
                    lblA_MHz_Ind.BackColor = Color.DarkSlateGray;
                    lblA_KHz_Ind.BackColor = Color.DarkSlateGray;
                    lblA_Hz_Ind.BackColor = Color.DarkSlateGray;
                    break;
                case 1000000:
                    lblA_GHz_Ind.BackColor = Color.DarkSlateGray;
                    lblA_MHz_Ind.BackColor = Color.SeaGreen;
                    lblA_KHz_Ind.BackColor = Color.DarkSlateGray;
                    lblA_Hz_Ind.BackColor = Color.DarkSlateGray;
                    break;
                case 1000:
                    lblA_GHz_Ind.BackColor = Color.DarkSlateGray;
                    lblA_MHz_Ind.BackColor = Color.DarkSlateGray;
                    lblA_KHz_Ind.BackColor = Color.SeaGreen;
                    lblA_Hz_Ind.BackColor = Color.DarkSlateGray;
                    break;
                case 1:
                    lblA_GHz_Ind.BackColor = Color.DarkSlateGray;
                    lblA_MHz_Ind.BackColor = Color.DarkSlateGray;
                    lblA_KHz_Ind.BackColor = Color.DarkSlateGray;
                    lblA_Hz_Ind.BackColor = Color.SeaGreen;
                    break;
            }
        }
        public void GUI_Update_B_FreqEntry_Type(uint multiplier)
        {
            GUI_B_FreqEntryMultiplier = multiplier;
            switch (multiplier)
            {
                case 1000000000:
                    lblB_GHz_Ind.BackColor = Color.SeaGreen;
                    lblB_MHz_Ind.BackColor = Color.DarkSlateGray;
                    lblB_KHz_Ind.BackColor = Color.DarkSlateGray;
                    lblB_Hz_Ind.BackColor = Color.DarkSlateGray;
                    break;
                case 1000000:
                    lblB_GHz_Ind.BackColor = Color.DarkSlateGray;
                    lblB_MHz_Ind.BackColor = Color.SeaGreen;
                    lblB_KHz_Ind.BackColor = Color.DarkSlateGray;
                    lblB_Hz_Ind.BackColor = Color.DarkSlateGray;
                    break;
                case 1000:
                    lblB_GHz_Ind.BackColor = Color.DarkSlateGray;
                    lblB_MHz_Ind.BackColor = Color.DarkSlateGray;
                    lblB_KHz_Ind.BackColor = Color.SeaGreen;
                    lblB_Hz_Ind.BackColor = Color.DarkSlateGray;
                    break;
                case 1:
                    lblB_GHz_Ind.BackColor = Color.DarkSlateGray;
                    lblB_MHz_Ind.BackColor = Color.DarkSlateGray;
                    lblB_KHz_Ind.BackColor = Color.DarkSlateGray;
                    lblB_Hz_Ind.BackColor = Color.SeaGreen;
                    break;
            }
        }
        public void GUI_Update_A_MemName(string val)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(GUI_Update_A_MemName), new object[] { val });
                return;
            }
            lbl_A_MemName.Text = val;
        }
        public void GUI_Update_B_MemName(string val)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(GUI_Update_B_MemName), new object[] { val });
                return;
            }
            lbl_B_MemName.Text = val;
        }
        public void GUI_Update_A_MemGrpNum(int val)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(GUI_Update_A_MemGrpNum), new object[] { val });
                return;
            }
            lbl_A_MEM_GRP.Text = String.Format("{0:00}", val);

            // Also update group name from memory
            try
            {
                lbl_A_MemGrpName.Text = r30.MemoryGroups.Group[val].Name;
            }
            catch(Exception e)
            {

            }
        }
        public void GUI_Update_B_MemGrpNum(int val)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(GUI_Update_B_MemGrpNum), new object[] { val });
                return;
            }
            lbl_B_MEM_GRP.Text = String.Format("{0:00}", val);
            // Also update group name from memory
            try
            {
                lbl_B_MemGrpName.Text = r30.MemoryGroups.Group[val].Name;
            }
            catch (Exception e)
            {

            }
        }
        public void GUI_Update_A_MemNum(int val)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(GUI_Update_A_MemNum), new object[] { val });
                return;
            }
            lbl_A_MEM_MEM.Text = String.Format("{0:00}", val);
        }
        public void GUI_Update_B_MemNum(int val)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(GUI_Update_B_MemNum), new object[] { val });
                return;
            }
            lbl_B_MEM_MEM.Text = String.Format("{0:00}", val);
        }
        public void GUI_Update_A_ScanCondition(model_IC_R30.t_ScanCondition sc)
        {
  
                if (InvokeRequired)
                {
                    this.Invoke(new Action<model_IC_R30.t_ScanCondition>(GUI_Update_A_ScanCondition), new object[] { sc });
                    return;
                }
                switch (sc)
            {
                case model_IC_R30.t_ScanCondition.NO_SCAN:
                    sb_A_Scan.Text = "Start Scan";
                    break;
                case model_IC_R30.t_ScanCondition.UP_SCAN:
                    sb_A_Scan.Text = "Cancel Scan";
                    break;
                case model_IC_R30.t_ScanCondition.DOWN_SCAN:
                    sb_A_Scan.Text = "Cancel Scan";
                    break;
                case model_IC_R30.t_ScanCondition.UP_SCAN_RCV:
                    sb_A_Scan.Text = "Cancel Scan";
                    break;
                case model_IC_R30.t_ScanCondition.DOWN_SCAN_RCV:
                    sb_A_Scan.Text = "Cancel Scan";
                    break;
            }
        }
        public void GUI_Update_B_ScanCondition(model_IC_R30.t_ScanCondition sc)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<model_IC_R30.t_ScanCondition>(GUI_Update_B_ScanCondition), new object[] { sc });
                return;
            }
            switch (sc)
            {
                case model_IC_R30.t_ScanCondition.NO_SCAN:
                    sb_B_Scan.Text = "Start Scan";
                    break;
                case model_IC_R30.t_ScanCondition.UP_SCAN:
                    sb_B_Scan.Text = "Cancel Scan";
                    break;
                case model_IC_R30.t_ScanCondition.DOWN_SCAN:
                    sb_B_Scan.Text = "Cancel Scan";
                    break;
                case model_IC_R30.t_ScanCondition.UP_SCAN_RCV:
                    sb_B_Scan.Text = "Cancel Scan";
                    break;
                case model_IC_R30.t_ScanCondition.DOWN_SCAN_RCV:
                    sb_B_Scan.Text = "Cancel Scan";
                    break;
            }
        }
        public void GUI_Populate_Scan_Memory(bool RFB = false)
        {
            ToolStripSplitButton sb;
            if (!RFB)
            {
                sb = sb_A_Scan;
            }
            else
            {
                sb = sb_B_Scan;
            }

            sb.DropDownItems.Clear();
            model_IC_R30.t_OperatingMode om;
            if (!RFB)
            {
                om = r30.RFA.OperatingMode;
            }
            else
            {
                om = r30.RFB.OperatingMode;
            }
            if(om == model_IC_R30.t_OperatingMode.MEM)
            {
                sb.DropDownItems.Add("[MA] Memory ALL").Click += GUI_A_Start_Scan_Clicked;
                sb.DropDownItems.Add("[MM] Memory MODE").Click += GUI_A_Start_Scan_Clicked;
                sb.DropDownItems.Add("[MG] Memory Group Link").Click += GUI_A_Start_Scan_Clicked;
                foreach (MemoryGroups.t_MemoryGroup mg in r30.MemoryGroups.Group)
                {
                    if (mg.CanScan)
                    {
                        ToolStripItem ni = sb.DropDownItems.Add(String.Format("[M{0:00}] " + mg.Name, mg.Number));
                        ni.Click += GUI_A_Start_Scan_Clicked;
                        if(!RFB)
                        {
                            ni.Name = "mi_A_M" + mg.Number;
                        }
                        else
                        {
                            ni.Name = "mi_B_M" + mg.Number;
                        }
                    }
                }
            }

        }
        public void GUI_Populate_Scan_Edges(bool RFB = false)
        {
            ToolStripSplitButton sb;
            if (!RFB)
            {
                sb = sb_A_Scan;
            }
            else
            {
                sb = sb_B_Scan;
            }

            sb.DropDownItems.Clear();
            model_IC_R30.t_OperatingMode om;
            if (!RFB)
            {
                om = r30.RFA.OperatingMode;
            }
            else
            {
                om = r30.RFB.OperatingMode;
            }
            if (om == model_IC_R30.t_OperatingMode.VFO)
            {
                //sb.DropDownItems.Add("[MA] Memory ALL").Click += GUI_A_Start_Scan_Clicked;
                //sb.DropDownItems.Add("[MM] Memory MODE").Click += GUI_A_Start_Scan_Clicked;
                //sb.DropDownItems.Add("[MG] Memory Group Link").Click += GUI_A_Start_Scan_Clicked;
                foreach (ProgramEdges.t_ScanEdge mg in r30.ProgramEdges.ScanEdges)
                {
                    if (mg.CanScan)
                    {
                        ToolStripItem ni = sb.DropDownItems.Add(String.Format("[P{0:00}] " + mg.Name, mg.Number));
                        ni.Click += GUI_A_Start_Scan_Clicked;
                        if (!RFB)
                        {
                            ni.Name = "mi_A_P" + mg.Number;
                        }
                        else
                        {
                            ni.Name = "mi_B_P" + mg.Number;
                        }
                    }
                }
            }

        }
        private void GUI_A_Start_Scan_Clicked(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            string scanid = tsmi.Text.Substring(tsmi.Text.IndexOf("[") + 1, (tsmi.Text.IndexOf("]") - 1) - tsmi.Text.IndexOf("["));
            switch(scanid[0].ToString())
            {
                case "M":
                    switch (scanid[1].ToString())
                    {
                        case "A":
                            r30.StartMemoryALLScan();
                            r30.ReqScanCondition();
                            break;
                        case "M":
                            r30.StartMemoryMODEScan();
                            r30.ReqScanCondition();
                            break;
                        case "G":
                            r30.StartMemoryGroupLinkScan();
                            r30.ReqScanCondition();
                            break;

                        default:
                            int grpid = Convert.ToInt32(scanid.Substring(1));
                            r30.StartMemoryGroupScan(grpid);
                            r30.ReqScanCondition();
                            break;
                    }
                    break;
                case "P":
                    switch (scanid[1].ToString())
                    {
                        case "A":

                            break;
                        case "M":

                            break;
                        case "G":

                            break;

                        default:
                            int grpid = Convert.ToInt32(scanid.Substring(1));
                            r30.StartVFOProgramScan(grpid);
                            r30.ReqScanCondition();
                            break;
                    }
                    break;
            }
        }
        private void GUI_Update_SquelchInd(bool sq_open, bool RFB = false)
        {
            if(!RFB)
            {
                if (sq_open)
                {
                    btn_A_ReceiveInd.BackColor = System.Drawing.Color.LightGreen;
                    SquelchOpenA = true;
                }
                else
                {
                    btn_A_ReceiveInd.BackColor = System.Drawing.Color.White;
                    SquelchOpenA = false;
                }
            }
            else
            {
                if (sq_open)
                {
                    btn_B_ReceiveInd.BackColor = System.Drawing.Color.LightGreen;
                    SquelchOpenB = true;
                }
                else
                {
                    btn_B_ReceiveInd.BackColor = System.Drawing.Color.White;
                    SquelchOpenB = false;
                }
            }
        }
        private void GUI_Update_P25_SRC(int p25id, bool RFB = false)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int, bool>(GUI_Update_P25_SRC), new object[] { p25id, RFB });
                return;
            }
            if (!RFB)
            {
                txt_A_P25_Src.Text = "" + p25id;
            }
        }
        private void GUI_Update_P25_DST(int p25id, bool RFB = false)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int, bool>(GUI_Update_P25_DST), new object[] { p25id, RFB });
                return;
            }
            if (!RFB)
            {
                txt_A_P25_Dest.Text = "" + p25id;
            }
        }
        private void GUI_Update_P25_NAC(int p25nac, bool RFB = false)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int, bool>(GUI_Update_P25_NAC), new object[] { p25nac, RFB });
                return;
            }
            if (!RFB)
            {
                txt_A_P25_NAC.Text = String.Format("0x{0:X2}", p25nac);
            }
        }
        private void GUI_Update_P25_Emerg(bool p25emerg, bool RFB = false)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<bool, bool>(GUI_Update_P25_Emerg), new object[] { p25emerg, RFB });
                return;
            }
            if (!RFB)
            {
                lbl_A_P25_EMERG.Visible = p25emerg;
            }
        }
        private void GUI_Update_P25_CallType(model_IC_R30.t_P25_CallType type, bool RFB = false)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<model_IC_R30.t_P25_CallType, bool>(GUI_Update_P25_CallType), new object[] { type, RFB });
                return;
            }
            if (!RFB)
            {
                switch(type)
                {
                    case model_IC_R30.t_P25_CallType.NOT_IDENTIFIED:
                        txt_A_P25_CallType.Text = "Unidentified";
                        break;
                    case model_IC_R30.t_P25_CallType.INDIVIDUAL:
                        txt_A_P25_CallType.Text = "Individual";
                        break;
                    case model_IC_R30.t_P25_CallType.GROUP:
                        txt_A_P25_CallType.Text = "Group";
                        break;
                    case model_IC_R30.t_P25_CallType.ALL:
                        txt_A_P25_CallType.Text = "All";
                        break;
                }
            }
        }
        private void GUI_Update_P25_Enc(bool encrypted, bool RFB = false)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<bool, bool>(GUI_Update_P25_Enc), new object[] { encrypted, RFB });
                return;
            }
            if (!RFB)
            {
                lbl_A_P25_Enc.Visible = encrypted;
            }
        }
        private void GUI_Update_P25_DBFields(int p25Src, int p25Dst, int p25nac, model_IC_R30.t_P25_CallType CallType, bool RFB = false)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int, int, int, model_IC_R30.t_P25_CallType, bool>(GUI_Update_P25_DBFields), new object[] { p25Src, p25Dst, p25nac, CallType, RFB });
                return;
            }
            if(!RFB)
            {
                txt_A_P25_Src_DBName.Text = RadioDB.GetP25RadioName(String.Format("0x{0:X2}", p25nac), p25Src.ToString());
                switch (CallType)
                {
                    case model_IC_R30.t_P25_CallType.NOT_IDENTIFIED:

                        break;
                    case model_IC_R30.t_P25_CallType.INDIVIDUAL:
                        txt_A_P25_Dest_DBName.Text = RadioDB.GetP25RadioName(String.Format("{0:X2}", p25nac), p25Dst.ToString());
                        break;
                    case model_IC_R30.t_P25_CallType.GROUP:
                        txt_A_P25_Dest_DBName.Text = RadioDB.GetP25GroupName(String.Format("{0:X2}", p25nac), p25Dst.ToString());
                        break;
                    case model_IC_R30.t_P25_CallType.ALL:

                        break;
                }
            }
        }
        private void GUI_Update_FM_AFC(bool AFC, bool RFB)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<bool, bool>(GUI_Update_FM_AFC), new object[] { AFC, RFB });
                return;
            }
            if(!RFB)
            {
                chk_A_FM_AFC.Checked = AFC;
            }
            else
            {
                chk_B_FM_AFC.Checked = AFC;
            }
        }
        private void GUI_Update_FM_SQLMode(model_IC_R30.t_FM_SqlMode sqlMode, bool RFB)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<model_IC_R30.t_FM_SqlMode, bool>(GUI_Update_FM_SQLMode), new object[] { sqlMode, RFB });
                return;
            }
            if (!RFB)
            {
                switch (sqlMode)
                {
                    case model_IC_R30.t_FM_SqlMode.NONE:
                        opn_A_FM_SqlMode_TSQL.Checked = false;
                        opn_A_FM_SqlMode_DTCS.Checked = false;
                        opn_A_FM_SqlMode_TSQL_R.Checked = false;
                        opn_A_FM_SqlMode_DTCS_R.Checked = false;
                        opn_A_FM_SqlMode_None.Checked = true;
                        lbl_A_FM_SQLFreqOrCode.Visible = false;
                        cmb_A_FM_DTCSCode.Visible = false;
                        cmb_A_FM_TSQLFreq.Visible = false;
                        break;
                    case model_IC_R30.t_FM_SqlMode.TSQL:
                        opn_A_FM_SqlMode_DTCS.Checked = false;
                        opn_A_FM_SqlMode_TSQL_R.Checked = false;
                        opn_A_FM_SqlMode_DTCS_R.Checked = false;
                        opn_A_FM_SqlMode_None.Checked = false;
                        opn_A_FM_SqlMode_TSQL.Checked = true;
                        lbl_A_FM_SQLFreqOrCode.Text = "TSQL Freq:";
                        lbl_A_FM_SQLFreqOrCode.Visible = true;
                        cmb_A_FM_DTCSCode.Visible = false;
                        cmb_A_FM_TSQLFreq.Visible = true;
                        break;
                    case model_IC_R30.t_FM_SqlMode.DTCS:
                        opn_A_FM_SqlMode_TSQL.Checked = false;
                        opn_A_FM_SqlMode_TSQL_R.Checked = false;
                        opn_A_FM_SqlMode_DTCS_R.Checked = false;
                        opn_A_FM_SqlMode_None.Checked = false;
                        opn_A_FM_SqlMode_DTCS.Checked = true;
                        lbl_A_FM_SQLFreqOrCode.Text = "DTCS Code:";
                        lbl_A_FM_SQLFreqOrCode.Visible = true;
                        cmb_A_FM_DTCSCode.Visible = true;
                        cmb_A_FM_TSQLFreq.Visible = false;
                        break;
                    case model_IC_R30.t_FM_SqlMode.TSQL_R:
                        opn_A_FM_SqlMode_TSQL.Checked = false;
                        opn_A_FM_SqlMode_DTCS_R.Checked = false;
                        opn_A_FM_SqlMode_None.Checked = false;
                        opn_A_FM_SqlMode_DTCS.Checked = false;
                        opn_A_FM_SqlMode_TSQL_R.Checked = true;
                        lbl_A_FM_SQLFreqOrCode.Text = "TSQL Freq:";
                        lbl_A_FM_SQLFreqOrCode.Visible = true;
                        cmb_A_FM_DTCSCode.Visible = false;
                        cmb_A_FM_TSQLFreq.Visible = true;
                        break;
                    case model_IC_R30.t_FM_SqlMode.DTCS_R:
                        opn_A_FM_SqlMode_TSQL.Checked = false;
                        opn_A_FM_SqlMode_None.Checked = false;
                        opn_A_FM_SqlMode_DTCS.Checked = false;
                        opn_A_FM_SqlMode_TSQL_R.Checked = false;
                        opn_A_FM_SqlMode_DTCS_R.Checked = true;
                        lbl_A_FM_SQLFreqOrCode.Text = "DTCS Code:";
                        lbl_A_FM_SQLFreqOrCode.Visible = true;
                        cmb_A_FM_DTCSCode.Visible = true;
                        cmb_A_FM_TSQLFreq.Visible = false;
                        break;
                }
            }
            else
            {
                switch (sqlMode)
                {
                    case model_IC_R30.t_FM_SqlMode.NONE:
                        opn_B_FM_SqlMode_TSQL.Checked = false;
                        opn_B_FM_SqlMode_DTCS.Checked = false;
                        opn_B_FM_SqlMode_TSQL_R.Checked = false;
                        opn_B_FM_SqlMode_DTCS_R.Checked = false;
                        opn_B_FM_SqlMode_None.Checked = true;
                        lbl_B_FM_SQLFreqOrCode.Visible = false;
                        cmb_B_FM_DTCSCode.Visible = false;
                        cmb_B_FM_TSQLFreq.Visible = false;
                        break;
                    case model_IC_R30.t_FM_SqlMode.TSQL:
                        opn_B_FM_SqlMode_DTCS.Checked = false;
                        opn_B_FM_SqlMode_TSQL_R.Checked = false;
                        opn_B_FM_SqlMode_DTCS_R.Checked = false;
                        opn_B_FM_SqlMode_None.Checked = false;
                        opn_B_FM_SqlMode_TSQL.Checked = true;
                        lbl_B_FM_SQLFreqOrCode.Text = "TSQL Freq:";
                        lbl_B_FM_SQLFreqOrCode.Visible = true;
                        cmb_B_FM_DTCSCode.Visible = false;
                        cmb_B_FM_TSQLFreq.Visible = true;
                        break;
                    case model_IC_R30.t_FM_SqlMode.DTCS:
                        opn_B_FM_SqlMode_TSQL.Checked = false;
                        opn_B_FM_SqlMode_TSQL_R.Checked = false;
                        opn_B_FM_SqlMode_DTCS_R.Checked = false;
                        opn_B_FM_SqlMode_None.Checked = false;
                        opn_B_FM_SqlMode_DTCS.Checked = true;
                        lbl_B_FM_SQLFreqOrCode.Text = "DTCS Code:";
                        lbl_B_FM_SQLFreqOrCode.Visible = true;
                        cmb_B_FM_DTCSCode.Visible = true;
                        cmb_B_FM_TSQLFreq.Visible = false;
                        break;
                    case model_IC_R30.t_FM_SqlMode.TSQL_R:
                        opn_B_FM_SqlMode_TSQL.Checked = false;
                        opn_B_FM_SqlMode_DTCS_R.Checked = false;
                        opn_B_FM_SqlMode_None.Checked = false;
                        opn_B_FM_SqlMode_DTCS.Checked = false;
                        opn_B_FM_SqlMode_TSQL_R.Checked = true;
                        lbl_B_FM_SQLFreqOrCode.Text = "TSQL Freq:";
                        lbl_B_FM_SQLFreqOrCode.Visible = true;
                        cmb_B_FM_DTCSCode.Visible = false;
                        cmb_B_FM_TSQLFreq.Visible = true;
                        break;
                    case model_IC_R30.t_FM_SqlMode.DTCS_R:
                        opn_B_FM_SqlMode_TSQL.Checked = false;
                        opn_B_FM_SqlMode_None.Checked = false;
                        opn_B_FM_SqlMode_DTCS.Checked = false;
                        opn_B_FM_SqlMode_TSQL_R.Checked = false;
                        opn_B_FM_SqlMode_DTCS_R.Checked = true;
                        lbl_B_FM_SQLFreqOrCode.Text = "DTCS Code:";
                        lbl_B_FM_SQLFreqOrCode.Visible = true;
                        cmb_B_FM_DTCSCode.Visible = true;
                        cmb_B_FM_TSQLFreq.Visible = false;
                        break;
                }
            }
        }
        private void GUI_Update_A_TSQLCode(string sTSQLFreq)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(GUI_Update_A_TSQLCode), new object[] { sTSQLFreq });
                return;
            }
            cmb_A_FM_TSQLFreq.SelectedItem = sTSQLFreq;
        }
        private void GUI_Update_B_TSQLCode(string sTSQLFreq)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(GUI_Update_B_TSQLCode), new object[] { sTSQLFreq });
                return;
            }
            cmb_B_FM_TSQLFreq.SelectedItem = sTSQLFreq;
        }
        private void GUI_Update_A_DTCSCode(string sDTCSCode)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(GUI_Update_A_DTCSCode), new object[] { sDTCSCode });
                return;
            }
            cmb_A_FM_DTCSCode.SelectedItem = sDTCSCode;
        }
        private void GUI_Update_B_DTCSCode(string sDTCSCode)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(GUI_Update_B_DTCSCode), new object[] { sDTCSCode });
                return;
            }
            cmb_B_FM_DTCSCode.SelectedItem = sDTCSCode;
        }
        private void GUI_Update_A_VSC(bool VSC)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<bool>(GUI_Update_A_VSC), new object[] { VSC });
                return;
            }
            chk_A_FM_VSC.Checked = VSC;
            chk_A_AM_VSC.Checked = VSC;
        }
        private void GUI_Update_B_VSC(bool VSC)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<bool>(GUI_Update_B_VSC), new object[] { VSC });
                return;
            }
            chk_B_FM_VSC.Checked = VSC;
            chk_B_AM_VSC.Checked = VSC;
        }
        private void GUI_Update_A_NB(bool NB)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<bool>(GUI_Update_A_NB), new object[] { NB });
                return;
            }
            chk_A_SSB_NB.Checked = NB;
        }
        private void GUI_Update_A_ANL(bool ANL)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<bool>(GUI_Update_A_ANL), new object[] { ANL });
                return;
            }
            chk_A_AM_ANL.Checked = ANL;
        }
        private void GUI_Update_B_ANL(bool ANL)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<bool>(GUI_Update_B_ANL), new object[] { ANL });
                return;
            }
            chk_B_AM_ANL.Checked = ANL;
        }
        private void GUI_A_ReceiveModeControlUpdates(model_IC_R30.t_ReceiveMode mode)
        {
            switch(mode)
            {
                case model_IC_R30.t_ReceiveMode.LSB:
                case model_IC_R30.t_ReceiveMode.USB:
                case model_IC_R30.t_ReceiveMode.CW:
                case model_IC_R30.t_ReceiveMode.CW_R:
                    grp_A_SSB.Location = lModeSettingsA;
                    grp_A_AM.Visible = false;
                    grp_A_FM.Visible = false;
                    grp_A_P25.Visible = false;
                    grp_A_SSB.Visible = true;
                    break;
                case model_IC_R30.t_ReceiveMode.AM:
                case model_IC_R30.t_ReceiveMode.AM_N:
                    grp_A_AM.Location = lModeSettingsA;
                    grp_A_AM.Visible = true;
                    grp_A_FM.Visible = false;
                    grp_A_P25.Visible = false;
                    grp_A_SSB.Visible = false;
                    break;
                case model_IC_R30.t_ReceiveMode.FM:
                case model_IC_R30.t_ReceiveMode.FM_N:
                case model_IC_R30.t_ReceiveMode.WFM:
                    grp_A_FM.Location = lModeSettingsA;
                    grp_A_AM.Visible = false;
                    grp_A_FM.Visible = true;
                    grp_A_P25.Visible = false;
                    grp_A_SSB.Visible = false;
                    break;
                case model_IC_R30.t_ReceiveMode.P25:
                    grp_A_P25.Location = lModeSettingsA;
                    grp_A_AM.Visible = false;
                    grp_A_FM.Visible = false;
                    grp_A_P25.Visible = true;
                    grp_A_SSB.Visible = false;
                    break;
                case model_IC_R30.t_ReceiveMode.D_STAR:
                    grp_A_AM.Visible = false;
                    grp_A_FM.Visible = false;
                    grp_A_P25.Visible = false;
                    grp_A_SSB.Visible = false;
                    break;
                case model_IC_R30.t_ReceiveMode.dPMR:
                    grp_A_AM.Visible = false;
                    grp_A_FM.Visible = false;
                    grp_A_P25.Visible = false;
                    grp_A_SSB.Visible = false;
                    break;
                case model_IC_R30.t_ReceiveMode.NXDN_VN:
                case model_IC_R30.t_ReceiveMode.NXDN_N:
                    grp_A_AM.Visible = false;
                    grp_A_FM.Visible = false;
                    grp_A_P25.Visible = false;
                    grp_A_SSB.Visible = false;
                    break;
                case model_IC_R30.t_ReceiveMode.DCR:
                    grp_A_AM.Visible = false;
                    grp_A_FM.Visible = false;
                    grp_A_P25.Visible = false;
                    grp_A_SSB.Visible = false;
                    break;
            }
        }
        private void GUI_B_ReceiveModeControlUpdates(model_IC_R30.t_ReceiveMode mode)
        {
            switch (mode)
            {
                case model_IC_R30.t_ReceiveMode.LSB:
                case model_IC_R30.t_ReceiveMode.USB:
                case model_IC_R30.t_ReceiveMode.CW:
                case model_IC_R30.t_ReceiveMode.CW_R:
                    // These don't exist on Receiver B
                    break;
                case model_IC_R30.t_ReceiveMode.AM:
                case model_IC_R30.t_ReceiveMode.AM_N:
                    grp_B_AM.Location = lModeSettingsB;
                    grp_B_AM.Visible = true;
                    grp_B_FM.Visible = false;
                    grp_B_P25.Visible = false;
                    break;
                case model_IC_R30.t_ReceiveMode.FM:
                case model_IC_R30.t_ReceiveMode.FM_N:
                case model_IC_R30.t_ReceiveMode.WFM:
                    grp_B_FM.Location = lModeSettingsB;
                    grp_B_AM.Visible = false;
                    grp_B_FM.Visible = true;
                    grp_B_P25.Visible = false;
                    break;
                case model_IC_R30.t_ReceiveMode.P25:
                    grp_B_P25.Location = lModeSettingsB;
                    grp_B_AM.Visible = false;
                    grp_B_FM.Visible = false;
                    grp_B_P25.Visible = true;
                    break;
                case model_IC_R30.t_ReceiveMode.D_STAR:
                    grp_B_AM.Visible = false;
                    grp_B_FM.Visible = false;
                    grp_B_P25.Visible = false;
                    break;
                case model_IC_R30.t_ReceiveMode.dPMR:
                    grp_B_AM.Visible = false;
                    grp_B_FM.Visible = false;
                    grp_B_P25.Visible = false;
                    break;
                case model_IC_R30.t_ReceiveMode.NXDN_VN:
                case model_IC_R30.t_ReceiveMode.NXDN_N:
                    grp_B_AM.Visible = false;
                    grp_B_FM.Visible = false;
                    grp_B_P25.Visible = false;
                    break;
                case model_IC_R30.t_ReceiveMode.DCR:
                    grp_B_AM.Visible = false;
                    grp_B_FM.Visible = false;
                    grp_B_P25.Visible = false;
                    break;
            }
        }
        private void GUI_Update_Attenuator(model_IC_R30.t_Attenuator att)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<model_IC_R30.t_Attenuator>(GUI_Update_Attenuator), new object[] { att });
                return;
            }
            switch(att)
            {
                case model_IC_R30.t_Attenuator.OFF:
                    mtsdb_Attenuator.Text = "OFF";
                    break;
                case model_IC_R30.t_Attenuator.ATT1:
                    mtsdb_Attenuator.Text = "ATT1";
                    break;
                case model_IC_R30.t_Attenuator.ATT2:
                    mtsdb_Attenuator.Text = "ATT2";
                    break;
                case model_IC_R30.t_Attenuator.ATT3:
                    mtsdb_Attenuator.Text = "ATT3";
                    break;
            }
        }
        #endregion

        #region PacketHandlers
        private void R30Packet_ScanInformation(byte[] recdata, bool RFB = false)
        {
            int curMemByte = 16;
            int curMemBit = 0;
            int curPEByte = 4;
            int curPEBit = 0;
            for(int i = 0; i <= 99; i++)
            {
                r30.MemoryGroups.Group[i].CanScan = Utils.GetBitFromByteArray(recdata, curMemByte, curMemBit);
                if (curMemBit == 6)
                {
                    curMemByte++;
                    curMemBit = 0;
                }
                else
                {
                    curMemBit++;
                }
            }
            for (int i = 0; i <= 49; i++)
            {
                r30.ProgramEdges.ScanEdges[i].CanScan = Utils.GetBitFromByteArray(recdata, curPEByte, curPEBit);
                if (curMemBit == 6)
                {
                    curPEByte++;
                    curPEBit = 0;
                }
                else
                {
                    curPEBit++;
                }
            }
        }
        private void R30Packet_TSQLFreqChanged(byte[] recdata, bool RFB = false)
        {
            uint uFreq = Utils.FauxHexToUInt(recdata);
            string sFreq = uFreq.ToString();
            if (!RFB)
            {
                GUI_Update_A_TSQLCode(sFreq.Substring(0, sFreq.Length - 1) + "." + sFreq.Substring(sFreq.Length - 1, 1));
            }
            else
            {
                GUI_Update_B_TSQLCode(sFreq.Substring(0, sFreq.Length - 1) + "." + sFreq.Substring(sFreq.Length - 1, 1));
            }
        }
        private void R30Packet_DTCSCodeChanged(byte[] recdata, bool RFB = false)
        {
            uint uCode = Utils.FauxHexToUInt(new byte[] { recdata[1], recdata[2] });
            string sCode = String.Format("{0:000}", uCode);
            if (!RFB)
            {
                GUI_Update_A_DTCSCode(sCode);
            }
            else
            {
                GUI_Update_B_DTCSCode(sCode);
            }
        }
        private void R30Packet_P25RXIDChanged(byte[] recdata, bool RFB = false)
        {
            byte bSrc0 = (byte)(((int)recdata[2] << 4) | ((int)recdata[3]));
            byte bSrc1 = (byte)(((int)recdata[4] << 4) | ((int)recdata[5]));
            byte bSrc2 = (byte)(((int)recdata[6] << 4) | ((int)recdata[7]));

            byte bDst0 = (byte)(((int)recdata[8] << 4) | ((int)recdata[9]));
            byte bDst1 = (byte)(((int)recdata[10] << 4) | ((int)recdata[11]));
            byte bDst2 = (byte)(((int)recdata[12] << 4) | ((int)recdata[13]));

            byte bNAC0 = (byte)(((int)recdata[15] << 4) | ((int)recdata[16]));
            byte bNAC1 = (byte)((int)recdata[14]);
            
            int iSrc = BitConverter.ToInt32(new byte[] { bSrc2, bSrc1, bSrc0, 0x00 }, 0);
            int iDst = BitConverter.ToInt32(new byte[] { bDst2, bDst1, bDst0, 0x00 }, 0);
            int iNAC = BitConverter.ToInt32(new byte[] { bNAC0, bNAC1, 0x00, 0x00 }, 0);

            bool Encrypted = ((recdata[0] & 0x02) == 2);
            bool Emerg = ((recdata[0] & 0x01) == 1);
            model_IC_R30.t_P25_CallType CallType = (model_IC_R30.t_P25_CallType)((recdata[0] >> 2) & 0x03);
            GUI_Update_P25_SRC(iSrc, RFB);
            GUI_Update_P25_DST(iDst, RFB);
            GUI_Update_P25_NAC(iNAC, RFB);
            GUI_Update_P25_Emerg(Emerg, RFB);
            GUI_Update_P25_CallType(CallType, RFB);
            GUI_Update_P25_Enc(Encrypted, RFB);
            GUI_Update_P25_DBFields(iSrc, iDst, iNAC, CallType, RFB);
        }
        private void R30Packet_AFGainChanged(byte[] recdata, bool RFB = false)
        {
            if (recdata.Length == 2)
            {
                if (!RFB)
                {
                    GUI_Update_A_AFGain(Utils.FauxHexToUInt(recdata));
                }
                else
                {
                    GUI_Update_B_AFGain(Utils.FauxHexToUInt(recdata));
                }
            }
        }
        private void R30Packet_ScanCondition(byte[] recdata)
        {
            r30.RFA.ScanCondition = (model_IC_R30.t_ScanCondition)recdata[0];
            GUI_Update_A_ScanCondition((model_IC_R30.t_ScanCondition)recdata[0]);
            r30.RFB.ScanCondition = (model_IC_R30.t_ScanCondition)recdata[1];
            GUI_Update_B_ScanCondition((model_IC_R30.t_ScanCondition)recdata[1]);
        }
        private void R30Packet_SMeterChanged(byte[] recdata, bool RFB = false)
        {
            if (recdata.Length == 2)
            {
                if (!RFB)
                {
                    GUI_Update_A_SMeter(Utils.FauxHexToUInt(recdata));
                }
                else
                {
                    GUI_Update_B_SMeter(Utils.FauxHexToUInt(recdata));
                }
            }
        }
        private void R30Packet_SqlSMeterChanged(byte[] recdata, bool RFB = false)
        {
            if (recdata.Length == 3)
            {
                byte sqlData = recdata[0];
                byte[] smeterData = new byte[2];
                
                System.Buffer.BlockCopy(recdata, 1, smeterData, 0, 2);
                if (!RFB)
                {
                    GUI_Update_A_SMeter(Utils.FauxHexToUInt(smeterData));
                }
                else
                {
                    GUI_Update_B_SMeter(Utils.FauxHexToUInt(smeterData));
                }
                if (sqlData == 0x01)
                {
                    GUI_Update_SquelchInd(true, RFB);
                }
                else
                {
                    GUI_Update_SquelchInd(false, RFB);
                }
            }
        }
        public void R30Packet_Update_Memory_Groups(byte[] recdata)
        {
            if (r30.MemoryGroupLoaderCurrent == 99) r30.MemoryGroupLoaderCurrent = 0;
            int iRecCntr = 0;
            if (recdata.Length == 240)
            {
                while (iRecCntr < 15 && r30.MemoryGroupLoaderCurrent < 100)
                {
                    byte[] tmpGrpName = new byte[16];
                    System.Buffer.BlockCopy(recdata, iRecCntr * 16, tmpGrpName, 0, 16);
                    r30.MemoryGroups.Group[r30.MemoryGroupLoaderCurrent].Number = r30.MemoryGroupLoaderCurrent;
                    r30.MemoryGroups.Group[r30.MemoryGroupLoaderCurrent].Name = Encoding.ASCII.GetString(tmpGrpName);
                    iRecCntr++;
                    r30.MemoryGroupLoaderCurrent++;
                    if (r30.MemoryGroupLoaderCurrent >= 99) r30.MemoryGroups.InitComplete = true;
                }
            }
        }
        public void R30Packet_Update_ScanEdges(byte[] recdata)
        {
            if (r30.ProgramEdgeLoaderCurrent == 49) r30.ProgramEdgeLoaderCurrent = 0;
            int iRecCntr = 0;
            if (recdata.Length == 240)
            {
                while (iRecCntr < 15 && r30.ProgramEdgeLoaderCurrent < 50)
                {
                    byte[] tmpGrpName = new byte[16];
                    System.Buffer.BlockCopy(recdata, iRecCntr * 16, tmpGrpName, 0, 16);
                    r30.ProgramEdges.ScanEdges[r30.ProgramEdgeLoaderCurrent].Number = r30.ProgramEdgeLoaderCurrent;
                    r30.ProgramEdges.ScanEdges[r30.ProgramEdgeLoaderCurrent].Name = Encoding.ASCII.GetString(tmpGrpName);
                    iRecCntr++;
                    r30.ProgramEdgeLoaderCurrent++;
                    if (r30.ProgramEdgeLoaderCurrent >= 49) r30.ProgramEdges.InitComplete = true;
                }
            }
        }
        private void R30Packet_DisplayContent(byte[] recdata, bool RFB = false)
        {
            if (recdata.Length > 30)
            {
                byte[] payload = recdata;

                // Byte 00 "Status indication"
                R30Packet_DualBandModeChanged(payload[0]);

                // Byte 01 "Operating Mode"
                R30Packet_OperatingModeChanged(payload[1], RFB);

                // Byte 02 - 06 "Frequency"
                byte[] bFreq = new byte[5];
                System.Buffer.BlockCopy(payload, 2, bFreq, 0, 5);
                R30Packet_FreqChanged(bFreq, RFB);

                // Byte 08 - 09 "Receive Mode" (Byte 07 ignored)
                byte[] bReceiveMode = new byte[2];
                System.Buffer.BlockCopy(payload, 8, bReceiveMode, 0, 2);
                R30Packet_ModeChanged(bReceiveMode, RFB);

                // Byte 10 - 11 "RF Gain"
                byte[] bRFGain = new byte[2];
                System.Buffer.BlockCopy(payload, 10, bRFGain, 0, 2);
                R30Packet_RFGainChanged(bRFGain, RFB);

                // Byte 12 "Attenuator"
                R30Packet_AttenuatorChanged(payload[12]);

                // Byte 13 "Duplex"
                R30Packet_DuplexChanged(payload[13]);

                // Byte 14 "WX"
                R30Pakcet_WXChanged(payload[14], RFB);

                // Byte 15 "Mute/Recording Condition"
                R30Packet_MuteRecChanged(payload[15], RFB);

                // Byte 16 "AFC"
                R30Packet_AFCChanged(payload[16], RFB);

                // Byte 17 "SKIP"
                R30Packet_SKIPChanged(payload[17]);

                // Byte 18 - 19 "Memory Channel Group"
                byte[] bMemGrp = new byte[2];
                System.Buffer.BlockCopy(payload, 18, bMemGrp, 0, 2);
                R30Packet_MemGrpNumChanged(bMemGrp, RFB);

                // Byte 20 - 21 "Memory Channel"
                byte[] bMemChan = new byte[2];
                System.Buffer.BlockCopy(payload, 20, bMemChan, 0, 2);
                R30Packet_MemChannelNumChanged(bMemChan, RFB);

                // Byte 22 - 37 "Memory Channel Name"
                byte[] bMemName = new byte[16];
                System.Buffer.BlockCopy(payload, 22, bMemName, 0, 16);
                R30Packet_MemChannelNameChanged(bMemName, RFB);

                // Byte 38 "VSC"
                R30Packet_VSCChanged(payload[38], RFB);

                int iModeSpecificSettingLen = recdata.Length - 39;
                // Byte 39 - 41 "Mode Specific Settings"
                byte[] bModeSpec = new byte[iModeSpecificSettingLen];
                System.Buffer.BlockCopy(payload, 39, bModeSpec, 0, iModeSpecificSettingLen);
                R30Packet_ModeSpecificSettingsChange(bReceiveMode, bModeSpec, RFB);
            }
        }
        private void R30Packet_FreqChanged(byte[] recdata, bool RFB = false)
        {
            if (recdata.Length == 5)
            {
                uint uFrequency = Utils.UnpackFreq(recdata);
                if (uFrequency == 3781764777)
                {
                    uFrequency = 0;
                }

                if (!RFB)
                {
                    r30.RFA.Frequency = uFrequency;
                    GUI_Update_A_Frequency(uFrequency);
                }
                else
                {
                    r30.RFB.Frequency = uFrequency;
                    GUI_Update_B_Frequency(uFrequency);
                }

            }
        }
        private void R30Packet_OperatingModeChanged(byte b, bool RFB = false)
        {
            switch (b)
            {
                case 0x00:
                    if (!RFB)
                    {
                        if (r30.RFA.OperatingMode != model_IC_R30.t_OperatingMode.VFO) r30.ReqScanInformation();
                        r30.RFA.OperatingMode = model_IC_R30.t_OperatingMode.VFO;
                        GUI_Update_A_OperatingMode("VFO");
                    }
                    else
                    {
                        if (r30.RFB.OperatingMode != model_IC_R30.t_OperatingMode.VFO) r30.ReqScanInformation();
                        r30.RFB.OperatingMode = model_IC_R30.t_OperatingMode.VFO;
                        GUI_Update_B_OperatingMode("VFO");
                    }
                    break;
                case 0x01:
                    if (!RFB)
                    {
                        if (r30.RFA.OperatingMode != model_IC_R30.t_OperatingMode.MEM) r30.ReqScanInformation();
                        r30.RFA.OperatingMode = model_IC_R30.t_OperatingMode.MEM;
                        GUI_Update_A_OperatingMode("MEM");
                    }
                    else
                    {
                        if (r30.RFB.OperatingMode != model_IC_R30.t_OperatingMode.MEM) r30.ReqScanInformation();
                        r30.RFB.OperatingMode = model_IC_R30.t_OperatingMode.MEM;
                        GUI_Update_B_OperatingMode("MEM");
                    }
                    break;
                case 0x02:
                    if (!RFB)
                    {
                        r30.RFA.OperatingMode = model_IC_R30.t_OperatingMode.WX;
                        GUI_Update_A_OperatingMode("WX");
                    }
                    else
                    {
                        r30.RFA.OperatingMode = model_IC_R30.t_OperatingMode.WX;
                        GUI_Update_B_OperatingMode("WX");
                    }
                    break;
            }
        }
        private void R30Packet_DualBandModeChanged(byte b)
        {
            switch (b)
            {
                case 0x00:
                    if (r30.DualBandMode != model_IC_R30.t_DualBandMode.SingleAMain)
                    {
                        r30.DualBandMode = model_IC_R30.t_DualBandMode.SingleAMain;
                        r30.RFMAIN = r30.RFA;
                        GUI_SetDualBandControlProperties(model_IC_R30.t_DualBandMode.SingleAMain);
                    }
                    break;
                case 0x01:
                    if (r30.DualBandMode != model_IC_R30.t_DualBandMode.SingleBMain)
                    {
                        r30.DualBandMode = model_IC_R30.t_DualBandMode.SingleBMain;
                        r30.RFMAIN = r30.RFB;
                        GUI_SetDualBandControlProperties(model_IC_R30.t_DualBandMode.SingleBMain);
                    }
                    break;
                case 0x02:
                    if (r30.DualBandMode != model_IC_R30.t_DualBandMode.DualAMain)
                    {
                        r30.DualBandMode = model_IC_R30.t_DualBandMode.DualAMain;
                        r30.RFMAIN = r30.RFA;
                        GUI_SetDualBandControlProperties(model_IC_R30.t_DualBandMode.DualAMain);
                    }
                    break;
                case 0x03:
                    if (r30.DualBandMode != model_IC_R30.t_DualBandMode.DualBMain)
                    {
                        r30.DualBandMode = model_IC_R30.t_DualBandMode.DualBMain;
                        r30.RFMAIN = r30.RFB;
                        GUI_SetDualBandControlProperties(model_IC_R30.t_DualBandMode.DualBMain);
                    }
                    break;
            }
        }
        private void R30Packet_ModeChanged(byte[] recdata, bool RFB = false)
        {
            if (recdata.Length == 2)
            {
                model_IC_R30.t_RFChannel rfc;
                if (!RFB)
                {
                    rfc = r30.RFA;
                }
                else
                {
                    rfc = r30.RFB;
                }
                
                switch (recdata[0])
                {
                    case 0x00:
                        rfc.ReceiveMode = model_IC_R30.t_ReceiveMode.LSB;
                        break;
                    case 0x01:
                        rfc.ReceiveMode = model_IC_R30.t_ReceiveMode.USB;
                        break;
                    case 0x02:
                        switch (recdata[1])
                        {
                            case 0x02:
                                rfc.ReceiveMode = model_IC_R30.t_ReceiveMode.AM_N;
                                break;
                            default:
                                rfc.ReceiveMode = model_IC_R30.t_ReceiveMode.AM;
                                break;
                        }
                        break;
                    case 0x03:
                        rfc.ReceiveMode = model_IC_R30.t_ReceiveMode.CW;
                        break;
                    case 0x05:
                        switch (recdata[1])
                        {
                            case 0x02:
                                rfc.ReceiveMode = model_IC_R30.t_ReceiveMode.FM_N;
                                break;
                            default:
                                rfc.ReceiveMode = model_IC_R30.t_ReceiveMode.FM;
                                break;
                        }
                        break;
                    case 0x06:
                        rfc.ReceiveMode = model_IC_R30.t_ReceiveMode.WFM;
                        break;
                    case 0x07:
                        rfc.ReceiveMode = model_IC_R30.t_ReceiveMode.CW_R;
                        break;
                    case 0x16:
                        rfc.ReceiveMode = model_IC_R30.t_ReceiveMode.P25;
                        break;
                    case 0x17:
                        rfc.ReceiveMode = model_IC_R30.t_ReceiveMode.D_STAR;
                        break;
                    case 0x18:
                        rfc.ReceiveMode = model_IC_R30.t_ReceiveMode.dPMR;
                        break;
                    case 0x19:
                        rfc.ReceiveMode = model_IC_R30.t_ReceiveMode.NXDN_VN;
                        break;
                    case 0x20:
                        rfc.ReceiveMode = model_IC_R30.t_ReceiveMode.NXDN_N;
                        break;
                    case 0x21:
                        rfc.ReceiveMode = model_IC_R30.t_ReceiveMode.DCR;
                        break;
                }
                if (!RFB)
                {
                    GUI_Update_A_Mode(rfc.ReceiveMode);
                }
                else
                {
                    GUI_Update_B_Mode(rfc.ReceiveMode);
                }
            }
        }
        private void R30Packet_RFGainChanged(byte[] recdata, bool RFB = false)
        {
            if (recdata.Length == 2)
            {
                uint iRFGain = Utils.FauxHexToUInt(recdata);
                uint uGuiGain = 0;
                model_IC_R30.t_RFChannel rfc;
                if (!RFB)
                {
                    rfc = r30.RFA;
                }
                else
                {
                    rfc = r30.RFB;
                }
                switch (iRFGain)
                {
                    case (uint)model_IC_R30.t_RFGain.RFG1:
                        rfc.RFGain = model_IC_R30.t_RFGain.RFG1;
                        uGuiGain = 0;
                        break;
                    case (uint)model_IC_R30.t_RFGain.RFG2:
                        rfc.RFGain = model_IC_R30.t_RFGain.RFG2;
                        uGuiGain = 3;
                        break;
                    case (uint)model_IC_R30.t_RFGain.RFG3:
                        rfc.RFGain = model_IC_R30.t_RFGain.RFG3;
                        uGuiGain = 6;
                        break;
                    case (uint)model_IC_R30.t_RFGain.RFG4:
                        rfc.RFGain = model_IC_R30.t_RFGain.RFG4;
                        uGuiGain = 9;
                        break;
                    case (uint)model_IC_R30.t_RFGain.RFG5:
                        rfc.RFGain = model_IC_R30.t_RFGain.RFG5;
                        uGuiGain = 12;
                        break;
                    case (uint)model_IC_R30.t_RFGain.RFG6:
                        rfc.RFGain = model_IC_R30.t_RFGain.RFG6;
                        uGuiGain = 15;
                        break;
                    case (uint)model_IC_R30.t_RFGain.RFG7:
                        rfc.RFGain = model_IC_R30.t_RFGain.RFG7;
                        uGuiGain = 18;
                        break;
                    case (uint)model_IC_R30.t_RFGain.RFG8:
                        rfc.RFGain = model_IC_R30.t_RFGain.RFG8;
                        uGuiGain = 21;
                        break;
                    case (uint)model_IC_R30.t_RFGain.RFG9:
                        rfc.RFGain = model_IC_R30.t_RFGain.RFG9;
                        uGuiGain = 24;
                        break;
                    case (uint)model_IC_R30.t_RFGain.RFGMAX:
                        rfc.RFGain = model_IC_R30.t_RFGain.RFGMAX;
                        uGuiGain = 27;
                        break;
                }
                if (!RFB)
                {
                    GUI_Update_A_RFGain(uGuiGain);
                }
                else
                {
                    GUI_Update_B_RFGain(uGuiGain);
                }
            }
        }
        private void R30Packet_SqlLvlChanged(byte[] recdata, bool RFB = false)
        {
            if (recdata.Length == 2)
            {
                uint uSqlLvl = Utils.FauxHexToUInt(recdata);
                if (!RFB)
                {
                    GUI_Update_A_SqlLvl(uSqlLvl);
                }
                else
                {
                    GUI_Update_B_SqlLvl(uSqlLvl);
                }
            }
        }
        private void R30Packet_AttenuatorChanged(byte b)
        {
            switch(b)
            {
                case 0x00:
                    r30.Attenuator = model_IC_R30.t_Attenuator.OFF;
                    GUI_Update_Attenuator(model_IC_R30.t_Attenuator.OFF);
                    break;
                case 0x15:
                    r30.Attenuator = model_IC_R30.t_Attenuator.ATT1;
                    GUI_Update_Attenuator(model_IC_R30.t_Attenuator.ATT1);
                    break;
                case 0x30:
                    r30.Attenuator = model_IC_R30.t_Attenuator.ATT2;
                    GUI_Update_Attenuator(model_IC_R30.t_Attenuator.ATT2);
                    break;
                case 0x45:
                    r30.Attenuator = model_IC_R30.t_Attenuator.ATT3;
                    GUI_Update_Attenuator(model_IC_R30.t_Attenuator.ATT3);
                    break;
            }
        }
        private void R30Packet_DuplexChanged(byte b, bool RFB = false)
        {
            model_IC_R30.t_RFChannel rfc;
            if (!RFB)
            {
                rfc = r30.RFA;
            }
            else
            {
                rfc = r30.RFB;
            }
            switch (b)
            {
                case 0x10:
                    rfc.Duplex = model_IC_R30.t_Duplex.OFF;
                    break;
                case 0x11:
                    rfc.Duplex = model_IC_R30.t_Duplex.DOWN;
                    break;
                case 0x12:
                    rfc.Duplex = model_IC_R30.t_Duplex.UP;
                    break;
            }
        }
        private void R30Pakcet_WXChanged(byte b, bool RFB = false)
        {
            int WXChannel = b & 0xf;
            model_IC_R30.t_RFChannel rfc;
            if (!RFB)
            {
                rfc = r30.RFA;
            }
            else
            {
                rfc = r30.RFB;
            }
            rfc.WX.Channel = WXChannel;
            if ((b & 0x20) == 1)
            {
                rfc.WX.Alert = true;
            }
            else
            {
                rfc.WX.Alert = false;
            }
            if ((b & 0x10) == 1)
            {
                rfc.WX.AlertCall = true;
            }
            else
            {
                rfc.WX.AlertCall = false;
            }
        }
        private void R30Packet_MuteRecChanged(byte b, bool RFB = false)
        {
            model_IC_R30.t_RFChannel rfc;
            if (!RFB)
            {
                rfc = r30.RFA;
            }
            else
            {
                rfc = r30.RFB;
            }
            if ((b & 0x04) == 1)
            {
                rfc.MuteRec.Mute = true;
            }
            else
            {
                rfc.MuteRec.Mute = false;
            }
            switch (b & 0x03)
            {
                case 0x00:
                    rfc.MuteRec.RecordingState = model_IC_R30.t_RecordingState.STOP;
                    if (!RFB)
                    {
                        GUI_Update_A_RecStatus("Stopped");
                    }
                    else
                    {
                        GUI_Update_B_RecStatus("Stopped");
                    }
                    break;
                case 0x01:
                    rfc.MuteRec.RecordingState = model_IC_R30.t_RecordingState.PAUSE;
                    if (!RFB)
                    {
                        GUI_Update_A_RecStatus("Paused");
                    }
                    else
                    {
                        GUI_Update_B_RecStatus("Paused");
                    }
                    break;
                case 0x02:
                    rfc.MuteRec.RecordingState = model_IC_R30.t_RecordingState.RECORDING;
                    if (!RFB)
                    {
                        GUI_Update_A_RecStatus("Recording");
                    }
                    else
                    {
                        GUI_Update_B_RecStatus("Recording");
                    }
                    break;
            }
        }
        private void R30Packet_AFCChanged(byte b, bool RFB = false)
        {
            model_IC_R30.t_RFChannel rfc;
            if (!RFB)
            {
                rfc = r30.RFA;
            }
            else
            {
                rfc = r30.RFB;
            }
            if (b == 0x01)
            {
                rfc.AFC = true;
                GUI_Update_FM_AFC(true, RFB);
            }
            else
            {
                rfc.AFC = false;
                GUI_Update_FM_AFC(false, RFB);
            }
        }
        private void R30Packet_SKIPChanged(byte b)
        {
            switch (b)
            {
                case 0x00:
                    r30.MemoryChannel.Skip = model_IC_R30.t_SKIP.OFF;
                    break;
                case 0x01:
                    r30.MemoryChannel.Skip = model_IC_R30.t_SKIP.SKIP;
                    break;
                case 0x02:
                    r30.MemoryChannel.Skip = model_IC_R30.t_SKIP.PSKIP;
                    break;
            }
        }
        private void R30Packet_MemGrpNumChanged(byte[] recdata, bool RFB = false)
        {
            if(recdata.Length == 2)
            {
                int GrpNum = (recdata[1] & 0xf) +
                    ((recdata[1] >> 4) * 10);
                r30.MemoryChannel.Group = GrpNum;
                if (!RFB)
                {
                    GUI_Update_A_MemGrpNum(GrpNum);
                }
                else
                {
                    GUI_Update_B_MemGrpNum(GrpNum);
                }
            }
        }
        private void R30Packet_MemChannelNumChanged(byte[] recdata, bool RFB = false)
        {
            if (recdata.Length == 2)
            {
                int ChanNum = (recdata[1] & 0xf) +
                    ((recdata[1] >> 4) * 10);
                r30.MemoryChannel.Channel = ChanNum;
                if (!RFB)
                {
                    GUI_Update_A_MemNum(ChanNum);
                }
                else
                {
                    GUI_Update_B_MemNum(ChanNum);
                }
            }
        }
        private void R30Packet_MemChannelNameChanged(byte[] recdata, bool RFB = false)
        {
            if (recdata.Length == 16)
            {
                string ChanName = Encoding.ASCII.GetString(recdata);
                r30.MemoryChannel.Name = ChanName;
                if (!RFB)
                {
                    GUI_Update_A_MemName(ChanName);
                }
                else
                {
                    GUI_Update_B_MemName(ChanName);
                }
            }
        }
        private void R30Packet_VSCChanged(byte b, bool RFB = false)
        {
            model_IC_R30.t_RFChannel rfc;
            if (!RFB)
            {
                rfc = r30.RFA;
            }
            else
            {
                rfc = r30.RFB;
            }
            if (b == 0x00)
            {
                rfc.VSC = false;
            }
            else
            {
                rfc.VSC = true;
            }
            if(!RFB)
            {
                if(b == 0x00)
                {
                    GUI_Update_A_VSC(false);
                }
                else
                {
                    GUI_Update_A_VSC(true);
                }
            }
            else
            {
                if (b == 0x00)
                {
                    GUI_Update_B_VSC(false);
                }
                else
                {
                    GUI_Update_B_VSC(true);
                }
            }
        }
        private void R30Packet_ModeSpecificSettingsChange(byte[] recvmode, byte[] recdata, bool RFB = false)
        {
            if (recdata.Length > 0)
            {
                model_IC_R30.t_RFChannel rfc;
                if (!RFB)
                {
                    rfc = r30.RFA;
                }
                else
                {
                    rfc = r30.RFB;
                }
                switch (recvmode[0])
                {
                    case 0x00:
                    case 0x01:
                    case 0x03:
                    case 0x07:
                        switch (recdata[0])
                        {
                            case 0x00:
                                rfc.SSBCW_Settings.NB = false;
                                if (!RFB)
                                {
                                    GUI_Update_A_NB(false);
                                }
                                break;
                            case 0x01:
                                rfc.SSBCW_Settings.NB = true;
                                if(!RFB)
                                {
                                    GUI_Update_A_NB(true);
                                }
                                break;
                         }
                        break;
                    case 0x02:
                        if (recdata[0] == 0x00)
                        {
                            rfc.AM_Settings.ANL = false;
                            if (!RFB)
                            {
                                GUI_Update_A_ANL(false);
                            }
                            else
                            {
                                GUI_Update_B_ANL(false);
                            }
                        }
                        else
                        {
                            rfc.AM_Settings.ANL = true;
                            if (!RFB)
                            {
                                GUI_Update_A_ANL(true);
                            }
                            else
                            {
                                GUI_Update_B_ANL(true);
                            }
                        }
                        break;
                    case 0x05:
                        switch(recdata[0])
                        {
                            case 0x00:
                                if (rfc.FM_Settings.TSQL != model_IC_R30.t_FM_TSQL.OFF)
                                {
                                    rfc.FM_Settings.TSQL = model_IC_R30.t_FM_TSQL.OFF;
                                }
                                break;
                            case 0x01:
                                if (rfc.FM_Settings.TSQL != model_IC_R30.t_FM_TSQL.TSQL)
                                {
                                    rfc.FM_Settings.TSQL = model_IC_R30.t_FM_TSQL.TSQL;
                                    GUI_Update_FM_SQLMode(model_IC_R30.t_FM_SqlMode.TSQL, RFB);
                                }
                                break;
                            case 0x02:
                                if (rfc.FM_Settings.TSQL != model_IC_R30.t_FM_TSQL.TSQL_R)
                                {
                                    rfc.FM_Settings.TSQL = model_IC_R30.t_FM_TSQL.TSQL_R;
                                    GUI_Update_FM_SQLMode(model_IC_R30.t_FM_SqlMode.TSQL_R, RFB);
                                }
                                break;
                        }
                        switch(recdata[1])
                        {
                            case 0x00:
                                if (rfc.FM_Settings.DTCS != model_IC_R30.t_FM_DTCS.OFF)
                                {
                                    rfc.FM_Settings.DTCS = model_IC_R30.t_FM_DTCS.OFF;
                                }
                                break;
                            case 0x01:
                                if (rfc.FM_Settings.DTCS != model_IC_R30.t_FM_DTCS.DTCS)
                                {
                                    rfc.FM_Settings.DTCS = model_IC_R30.t_FM_DTCS.DTCS;
                                    GUI_Update_FM_SQLMode(model_IC_R30.t_FM_SqlMode.DTCS, RFB);
                                }
                                break;
                            case 0x02:
                                if (rfc.FM_Settings.DTCS != model_IC_R30.t_FM_DTCS.DTCS_R)
                                {
                                    rfc.FM_Settings.DTCS = model_IC_R30.t_FM_DTCS.DTCS_R;
                                    GUI_Update_FM_SQLMode(model_IC_R30.t_FM_SqlMode.DTCS_R, RFB);
                                }
                                break;
                        }
                        if(recdata[0] == 0x00 && recdata[1] == 0x00)
                        {

                                rfc.FM_Settings.DTCS = model_IC_R30.t_FM_DTCS.OFF;
                                rfc.FM_Settings.TSQL = model_IC_R30.t_FM_TSQL.OFF;
                                GUI_Update_FM_SQLMode(model_IC_R30.t_FM_SqlMode.NONE, RFB);

                        }
                        break;
                    case 0x17:
                        if (recdata[0] == 0x00) rfc.DSTAR_Settings.DSQL = model_IC_R30.t_DSTAR_DSQL.OFF;
                        if (recdata[0] == 0x02) rfc.DSTAR_Settings.DSQL = model_IC_R30.t_DSTAR_DSQL.CSQL;
                        if ((recdata[1] & 1) == 1)
                        {
                            rfc.DSTAR_Settings.PacketLoss = true;
                        }
                        else
                        {
                            rfc.DSTAR_Settings.PacketLoss = false;
                        }
                        if ((recdata[1] & 4) == 4)
                        {
                            rfc.DSTAR_Settings.EMR = true;
                        }
                        else
                        {
                            rfc.DSTAR_Settings.EMR = false;
                        }
                        if ((recdata[1] & 8) == 8)
                        {
                            rfc.DSTAR_Settings.BK = true;
                        }
                        else
                        {
                            rfc.DSTAR_Settings.BK = false;
                        }
                        switch(recdata[2])
                        {
                            case 0x00:
                                rfc.DSTAR_Settings.Interference = model_IC_R30.t_DSTAR_Interference.NONE;
                                break;
                            case 0x01:
                                rfc.DSTAR_Settings.Interference = model_IC_R30.t_DSTAR_Interference.SYNC;
                                break;
                            case 0x02:
                                rfc.DSTAR_Settings.Interference = model_IC_R30.t_DSTAR_Interference.INT;
                                break;
                        }
                        break;
                }
            }
        }
        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (tPUW != null) tPUW.Abort();
                if (tHSPUW != null) tHSPUW.Abort();
                ExitRequested = true;
                sph.ExitRequested = true;
                sph.Close();
            }
            catch(Exception ex)
            {

            }
            Thread.Sleep(500);
        }

        private void mtsdb_Layout_SingleA_Click(object sender, EventArgs e)
        {
            r30.SetRFAB(0x00);
            r30.SetDualMode(false);
            mtsdb_SwitchingType.Visible = false;
            mtslbl_Switching.Visible = false;
            r30.ReqDisplayContentSpecificRF(0x00);
            r30.ReqDisplayContentSpecificRF(0x01);
            SetReceiverControls(false, true);
            SetReceiverControls(true, false);
        }

        private void mtsdb_Layout_Dual_Click(object sender, EventArgs e)
        {
            r30.SetDualMode(true);
            mtsdb_SwitchingType.Visible = true;
            mtslbl_Switching.Visible = true;
            r30.ReqDisplayContentSpecificRF(0x00);
            r30.ReqDisplayContentSpecificRF(0x01);
        }

        private void mtsdb_Layout_SingleB_Click(object sender, EventArgs e)
        {
            r30.SetRFAB(0x01);
            r30.SetDualMode(false);
            mtsdb_SwitchingType.Visible = false;
            mtslbl_Switching.Visible = false;
            r30.ReqDisplayContentSpecificRF(0x00);
            r30.ReqDisplayContentSpecificRF(0x01);
            SetReceiverControls(true, true);
            SetReceiverControls(false, false);
        }

        private void btn_A_ReceiveInd_MouseDown(object sender, MouseEventArgs e)
        {
            iSqlSaveA = trk_A_SqlLvl.Value;
            r30.SetSquelchLvl(0);
        }

        private void btn_A_ReceiveInd_MouseUp(object sender, MouseEventArgs e)
        {
            r30.SetSquelchLvl(((uint)iSqlSaveA / 3) * 23);
        }

        private void btn_B_ReceiveInd_MouseDown(object sender, MouseEventArgs e)
        {
            iSqlSaveB = trk_B_SqlLvl.Value;
            r30.SetSquelchLvl(0);
        }

        private void btn_B_ReceiveInd_MouseUp(object sender, MouseEventArgs e)
        {
            r30.SetSquelchLvl(((uint)iSqlSaveB / 3) * 23);
        }

        private void chk_A_FM_AFC_Click(object sender, EventArgs e)
        {
            if(chk_A_FM_AFC.Checked)
            {
                r30.SetAFCStatus(false);
            }
            else
            {
                r30.SetAFCStatus(true);
            }
            
        }

        private void opn_A_FM_SqlMode_None_Click(object sender, EventArgs e)
        {
            r30.SetFMSquelchMode(model_IC_R30.t_FM_SqlMode.NONE);
            r30.ReqDisplayContentSpecificRF(0x00);
            lbl_A_FM_SQLFreqOrCode.Visible = false;
            cmb_A_FM_DTCSCode.Visible = false;
            cmb_A_FM_TSQLFreq.Visible = false;
        }

        private void opn_A_FM_SqlMode_TSQL_Click(object sender, EventArgs e)
        {
            r30.SetFMSquelchMode(model_IC_R30.t_FM_SqlMode.TSQL);
            r30.ReqFMTSQLFreq();
            r30.ReqDisplayContentSpecificRF(0x00);
            lbl_A_FM_SQLFreqOrCode.Text = "TSQL Freq:";
            lbl_A_FM_SQLFreqOrCode.Visible = true;
            cmb_A_FM_DTCSCode.Visible = false;
            cmb_A_FM_TSQLFreq.Visible = true;
        }

        private void opn_A_FM_SqlMode_TSQL_R_Click(object sender, EventArgs e)
        {
            r30.SetFMSquelchMode(model_IC_R30.t_FM_SqlMode.TSQL_R);
            r30.ReqFMTSQLFreq();
            r30.ReqDisplayContentSpecificRF(0x00);
            lbl_A_FM_SQLFreqOrCode.Text = "TSQL Freq:";
            lbl_A_FM_SQLFreqOrCode.Visible = true;
            cmb_A_FM_DTCSCode.Visible = false;
            cmb_A_FM_TSQLFreq.Visible = true;
        }

        private void opn_A_FM_SqlMode_DTCS_Click(object sender, EventArgs e)
        {
            r30.SetFMSquelchMode(model_IC_R30.t_FM_SqlMode.DTCS);
            r30.ReqFMDTCSCode();
            r30.ReqDisplayContentSpecificRF(0x00);
            lbl_A_FM_SQLFreqOrCode.Text = "DTCS Code:";
            lbl_A_FM_SQLFreqOrCode.Visible = true;
            cmb_A_FM_DTCSCode.Visible = true;
            cmb_A_FM_TSQLFreq.Visible = false;
        }

        private void opn_A_FM_SqlMode_DTCS_R_Click(object sender, EventArgs e)
        {
            r30.SetFMSquelchMode(model_IC_R30.t_FM_SqlMode.DTCS_R);
            r30.ReqFMDTCSCode();
            r30.ReqDisplayContentSpecificRF(0x00);
            lbl_A_FM_SQLFreqOrCode.Text = "DTCS Code:";
            lbl_A_FM_SQLFreqOrCode.Visible = true;
            cmb_A_FM_DTCSCode.Visible = true;
            cmb_A_FM_TSQLFreq.Visible = false;
        }

        private void cmb_A_FM_TSQLFreq_SelectionChangeCommitted(object sender, EventArgs e)
        {
            r30.SetFMTSQLFreq(cmb_A_FM_TSQLFreq.Text);
        }

        private void cmb_A_FM_DTCSCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(opn_A_FM_SqlMode_DTCS.Checked)
            {
                r30.SetFMDTCSCode(cmb_A_FM_DTCSCode.Text, 0x00);
            }
            if (opn_A_FM_SqlMode_DTCS_R.Checked)
            {
                r30.SetFMDTCSCode(cmb_A_FM_DTCSCode.Text, 0x01);
            }
        }

        private void chk_A_FM_VSC_Click(object sender, EventArgs e)
        {
            if(chk_A_FM_VSC.Checked)
            {
                r30.SetVSC(false);
            }
            else
            {
                r30.SetVSC(true);
            }
        }

        private void chk_A_AM_VSC_Click(object sender, EventArgs e)
        {
            if (chk_A_AM_VSC.Checked)
            {
                r30.SetVSC(false);
            }
            else
            {
                r30.SetVSC(true);
            }
        }

        private void chk_A_SSB_NB_Click(object sender, EventArgs e)
        {
            if(chk_A_SSB_NB.Checked)
            {
                r30.SetNB(false);
            }
            else
            {
                r30.SetNB(true);
            }
        }

        private void chk_B_FM_AFC_Click(object sender, EventArgs e)
        {
            if (chk_B_FM_AFC.Checked)
            {
                r30.SetAFCStatus(false);
            }
            else
            {
                r30.SetAFCStatus(true);
            }
        }

        private void chk_B_FM_VSC_Click(object sender, EventArgs e)
        {
            if (chk_B_FM_VSC.Checked)
            {
                r30.SetVSC(false);
            }
            else
            {
                r30.SetVSC(true);
            }
        }

        private void opn_B_FM_SqlMode_None_Click(object sender, EventArgs e)
        {
            r30.SetFMSquelchMode(model_IC_R30.t_FM_SqlMode.NONE);
            r30.ReqDisplayContentSpecificRF(0x01);
            lbl_B_FM_SQLFreqOrCode.Visible = false;
            cmb_B_FM_DTCSCode.Visible = false;
            cmb_B_FM_TSQLFreq.Visible = false;
        }

        private void opn_B_FM_SqlMode_TSQL_Click(object sender, EventArgs e)
        {
            r30.SetFMSquelchMode(model_IC_R30.t_FM_SqlMode.TSQL);
            r30.ReqFMTSQLFreq();
            r30.ReqDisplayContentSpecificRF(0x01);
            lbl_B_FM_SQLFreqOrCode.Text = "TSQL Freq:";
            lbl_B_FM_SQLFreqOrCode.Visible = true;
            cmb_B_FM_DTCSCode.Visible = false;
            cmb_B_FM_TSQLFreq.Visible = true;
        }

        private void opn_B_FM_SqlMode_DTCS_Click(object sender, EventArgs e)
        {
            r30.SetFMSquelchMode(model_IC_R30.t_FM_SqlMode.DTCS);
            r30.ReqFMDTCSCode();
            r30.ReqDisplayContentSpecificRF(0x01);
            lbl_B_FM_SQLFreqOrCode.Text = "DTCS Code:";
            lbl_B_FM_SQLFreqOrCode.Visible = true;
            cmb_B_FM_DTCSCode.Visible = true;
            cmb_B_FM_TSQLFreq.Visible = false;
        }

        private void opn_B_FM_SqlMode_TSQL_R_Click(object sender, EventArgs e)
        {
            r30.SetFMSquelchMode(model_IC_R30.t_FM_SqlMode.TSQL_R);
            r30.ReqFMTSQLFreq();
            r30.ReqDisplayContentSpecificRF(0x01);
            lbl_B_FM_SQLFreqOrCode.Text = "TSQL Freq:";
            lbl_B_FM_SQLFreqOrCode.Visible = true;
            cmb_B_FM_DTCSCode.Visible = false;
            cmb_B_FM_TSQLFreq.Visible = true;
        }

        private void opn_B_FM_SqlMode_DTCS_R_Click(object sender, EventArgs e)
        {
            r30.SetFMSquelchMode(model_IC_R30.t_FM_SqlMode.DTCS_R);
            r30.ReqFMDTCSCode();
            r30.ReqDisplayContentSpecificRF(0x01);
            lbl_B_FM_SQLFreqOrCode.Text = "DTCS Code:";
            lbl_B_FM_SQLFreqOrCode.Visible = true;
            cmb_B_FM_DTCSCode.Visible = true;
            cmb_B_FM_TSQLFreq.Visible = false;
        }

        private void cmb_B_FM_DTCSCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (opn_B_FM_SqlMode_DTCS.Checked)
            {
                r30.SetFMDTCSCode(cmb_B_FM_DTCSCode.Text, 0x00);
            }
            if (opn_B_FM_SqlMode_DTCS_R.Checked)
            {
                r30.SetFMDTCSCode(cmb_B_FM_DTCSCode.Text, 0x01);
            }
        }

        private void cmb_B_FM_TSQLFreq_SelectionChangeCommitted(object sender, EventArgs e)
        {
            r30.SetFMTSQLFreq(cmb_B_FM_TSQLFreq.Text);
        }

        private void chk_A_AM_ANL_Click(object sender, EventArgs e)
        {
            if (chk_A_AM_ANL.Checked)
            {
                r30.SetANL(false);
            }
            else
            {
                r30.SetANL(true);
            }
        }

        private void chk_B_AM_ANL_Click(object sender, EventArgs e)
        {
            if (chk_B_AM_ANL.Checked)
            {
                r30.SetANL(false);
            }
            else
            {
                r30.SetANL(true);
            }
        }

        private void chk_B_AM_VSC_Click(object sender, EventArgs e)
        {
            if (chk_B_AM_VSC.Checked)
            {
                r30.SetVSC(false);
            }
            else
            {
                r30.SetVSC(true);
            }
        }

        private void chkPUW_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void mtsdb_SwitchingType_Manual_Click(object sender, EventArgs e)
        {
            if (r30.DualBandMode == model_IC_R30.t_DualBandMode.DualAMain)
            {
                SetReceiverControls(false, true);
                SetReceiverControls(true, false);
            }
            if(r30.DualBandMode == model_IC_R30.t_DualBandMode.DualBMain)
            {
                SetReceiverControls(true, true);
                SetReceiverControls(false, false);
            }
            mtsdb_SwitchingType.Text = "Manual";
        }

        private void mtsdb_SwitchingType_MouseOver_Click(object sender, EventArgs e)
        {
            if (r30.DualBandMode == model_IC_R30.t_DualBandMode.DualAMain)
            {
                SetReceiverControls(false, true);
                SetReceiverControls(true, true);
            }
            if (r30.DualBandMode == model_IC_R30.t_DualBandMode.DualBMain)
            {
                SetReceiverControls(true, true);
                SetReceiverControls(false, true);
            }
            mtsdb_SwitchingType.Text = "Mouse Hover";
        }

        private void btnA_GHz_Click(object sender, EventArgs e)
        {
            txtA_FreqEntry.Focus();
            SendKeys.Send("G");
        }

        private void btnA_MHz_Click(object sender, EventArgs e)
        {
            txtA_FreqEntry.Focus();
            SendKeys.Send("M");
        }

        private void btnA_KHz_Click(object sender, EventArgs e)
        {
            txtA_FreqEntry.Focus();
            SendKeys.Send("K");
        }

        private void btnA_Hz_Click(object sender, EventArgs e)
        {
            txtA_FreqEntry.Focus();
            SendKeys.Send("H");
        }

        private void btnB_GHz_Click(object sender, EventArgs e)
        {
            txtB_FreqEntry.Focus();
            SendKeys.Send("G");
        }

        private void btnB_MHz_Click(object sender, EventArgs e)
        {
            txtB_FreqEntry.Focus();
            SendKeys.Send("M");
        }

        private void btnB_KHz_Click(object sender, EventArgs e)
        {
            txtB_FreqEntry.Focus();
            SendKeys.Send("K");
        }

        private void btnB_Hz_Click(object sender, EventArgs e)
        {
            txtB_FreqEntry.Focus();
            SendKeys.Send("H");
        }

        private void mtsdb_Attenuator_OFF_Click(object sender, EventArgs e)
        {
            r30.SetAttenuator(0);
        }

        private void mtsdb_Attenuator_ATT1_Click(object sender, EventArgs e)
        {
            r30.SetAttenuator(15);
        }

        private void mtsdb_Attenuator_ATT2_Click(object sender, EventArgs e)
        {
            r30.SetAttenuator(30);
        }

        private void mtsdb_Attenuator_ATT3_Click(object sender, EventArgs e)
        {
            r30.SetAttenuator(45);
        }

        private void btn_About_Click(object sender, EventArgs e)
        {
            frmAbout AboutForm = new frmAbout();
            AboutForm.Show();
        }

        private void mtscb_COMPort_Click(object sender, EventArgs e)
        {

        }

        private void mtsdb_Data_LoadP25Grp_Click(object sender, EventArgs e)
        {
            dlgOpenFile.Filter = "DSDPlus Group Files (*.groups)|*.groups";
            dlgOpenFile.Title = "Open DSD Groups File";
            dlgOpenFile.ShowDialog();
            if (dlgOpenFile.FileName != "")
            {
                RadioDB.LoadP25Groups(dlgOpenFile.FileName);
            }
        }

        private void mtsdb_Data_LoadP25Rad_Click(object sender, EventArgs e)
        {
            dlgOpenFile.Filter = "DSDPlus Radio Files (*.radios)|*.radios";
            dlgOpenFile.Title = "Open DSD Radios File";
            dlgOpenFile.ShowDialog();
            if (dlgOpenFile.FileName != "")
            {
                RadioDB.LoadP25Radios(dlgOpenFile.FileName);
            }
        }

        private void btnScanTest_Click(object sender, EventArgs e)
        {
            //chkPUW.Checked = false;
            //Thread.Sleep(250);
            //Dictionary<uint, short> sValues = r30.GetSigLevels(Convert.ToUInt32(lblAFreq.Text.Replace(" ", "")), 10000000, 5000);
            frmScanGraph frmSG = new frmScanGraph();
            frmSG.r30 = r30;
            frmSG.myparent = this;
            frmSG.Show();
            //frmSG.chart1.Series.Add("Test");
            //foreach (uint freq in sValues.Keys)
            //{
            //    frmSG.chart1.Series["Test"].Points.AddXY(freq, sValues[freq]);
            //}
        }

        public void Scan_Pause_GUI()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(Scan_Pause_GUI), new object[] {  });
                return;
            }
            SetReceiverControls(false, false);
            SetReceiverControls(true, false);
            chkPUW.Checked = false;
            Thread.Sleep(500);
            sph.SyncMode = true;
        }
        public void Scan_Resume_GUI()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(Scan_Resume_GUI), new object[] { });
                return;
            }
            
            r30.SyncSendCommand(0x00, Utils.PackFreq(r30.RFA.Frequency));
            sph.SyncMode = false;
            switch (r30.DualBandMode)
            {
                case model_IC_R30.t_DualBandMode.SingleAMain:
                    SetReceiverControls(false, true);
                    SetReceiverControls(true, false);
                    r30.SetRFAB(0x00);
                    r30.SetReceiveMode(r30.RFA.ReceiveMode);
                    break;
                case model_IC_R30.t_DualBandMode.SingleBMain:
                    SetReceiverControls(false, false);
                    SetReceiverControls(true, true);
                    r30.SetRFAB(0x01);
                    break;
                case model_IC_R30.t_DualBandMode.DualAMain:
                    SetReceiverControls(false, true);
                    SetReceiverControls(true, true);
                    r30.SetRFAB(0x00);
                    r30.SetReceiveMode(r30.RFA.ReceiveMode);
                    break;
                case model_IC_R30.t_DualBandMode.DualBMain:
                    SetReceiverControls(false, true);
                    SetReceiverControls(true, true);
                    r30.SetReceiveMode(r30.RFA.ReceiveMode);
                    r30.SetRFAB(0x01);
                    break;
            }
            chkPUW.Checked = true;
        }
    }
}
