
namespace ICR30
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtDbgSend = new System.Windows.Forms.TextBox();
            this.btnDebugSend = new System.Windows.Forms.Button();
            this.grpRecA = new System.Windows.Forms.GroupBox();
            this.lbl_A_SqlAuto = new System.Windows.Forms.Label();
            this.lbl_A_SqlOpen = new System.Windows.Forms.Label();
            this.btn_A_ReceiveInd = new System.Windows.Forms.Button();
            this.lbl_A_MemGrpName = new System.Windows.Forms.Label();
            this.grp_A_ScanCtrl = new System.Windows.Forms.GroupBox();
            this.btn_A_ScanCtrl_Skip = new System.Windows.Forms.Button();
            this.lbl_A_MEM_MEM = new System.Windows.Forms.Label();
            this.lbl_A_MEM_GRP = new System.Windows.Forms.Label();
            this.lbl_A_MemName = new System.Windows.Forms.Label();
            this.pbASmeter = new System.Windows.Forms.ProgressBar();
            this.btn_A_KPdot = new System.Windows.Forms.Button();
            this.btn_A_KPEnter = new System.Windows.Forms.Button();
            this.btn_A_KP9 = new System.Windows.Forms.Button();
            this.btn_A_KP8 = new System.Windows.Forms.Button();
            this.btn_A_KP7 = new System.Windows.Forms.Button();
            this.btn_A_KP6 = new System.Windows.Forms.Button();
            this.btn_A_KP5 = new System.Windows.Forms.Button();
            this.btn_A_KP4 = new System.Windows.Forms.Button();
            this.btn_A_KP3 = new System.Windows.Forms.Button();
            this.btn_A_KP2 = new System.Windows.Forms.Button();
            this.btn_A_KP1 = new System.Windows.Forms.Button();
            this.btn_A_KP0 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sb_A_Mode = new System.Windows.Forms.ToolStripSplitButton();
            this.m_A_Mode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mi_A_Mode_AM = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_A_Mode_AM_N = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_A_Mode_CW = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_A_Mode_CW_R = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_A_Mode_DCR = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_A_Mode_dPMR = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_A_Mode_DSTAR = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_A_Mode_FM = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_A_Mode_FM_N = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_A_Mode_LSB = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_A_Mode_NXDN_N = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_A_Mode_NXDX_VN = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_A_Mode_P25 = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_A_Mode_USB = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_A_Mode_WFM = new System.Windows.Forms.ToolStripMenuItem();
            this.sb_A_VFOMEM = new System.Windows.Forms.ToolStripDropDownButton();
            this.mi_A_VFO = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_A_MEM = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_A_WX = new System.Windows.Forms.ToolStripMenuItem();
            this.sb_A_Scan = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tslbl_A_RecStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_A_Sql = new System.Windows.Forms.Label();
            this.trk_A_SqlLvl = new System.Windows.Forms.TrackBar();
            this.lbl_A_RFGain = new System.Windows.Forms.Label();
            this.trk_A_RFGain = new System.Windows.Forms.TrackBar();
            this.lbl_A_AFGain = new System.Windows.Forms.Label();
            this.trk_A_AFGain = new System.Windows.Forms.TrackBar();
            this.lblA_Hz_Ind = new System.Windows.Forms.Label();
            this.lblA_KHz_Ind = new System.Windows.Forms.Label();
            this.lblA_MHz_Ind = new System.Windows.Forms.Label();
            this.lblA_GHz_Ind = new System.Windows.Forms.Label();
            this.btnA_Hz = new System.Windows.Forms.Button();
            this.btnA_KHz = new System.Windows.Forms.Button();
            this.btnA_GHz = new System.Windows.Forms.Button();
            this.btnA_MHz = new System.Windows.Forms.Button();
            this.txtA_FreqEntry = new System.Windows.Forms.TextBox();
            this.lblAFreq = new System.Windows.Forms.Label();
            this.grpRecB = new System.Windows.Forms.GroupBox();
            this.lbl_B_SqlAuto = new System.Windows.Forms.Label();
            this.lbl_B_SqlOpen = new System.Windows.Forms.Label();
            this.btn_B_ReceiveInd = new System.Windows.Forms.Button();
            this.lbl_B_MemGrpName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_B_ScanCtrl_Skip = new System.Windows.Forms.Button();
            this.lbl_B_MEM_MEM = new System.Windows.Forms.Label();
            this.lbl_B_MEM_GRP = new System.Windows.Forms.Label();
            this.lbl_B_MemName = new System.Windows.Forms.Label();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.sb_B_Mode = new System.Windows.Forms.ToolStripSplitButton();
            this.m_B_Mode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mi_B_Mode_AM = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_B_Mode_DCR = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_B_Mode_dPMR = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_B_Mode_DSTAR = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_B_Mode_FM = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_B_Mode_NXDN_VN = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_B_Mode_NXDN_N = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_B_Mode_P25 = new System.Windows.Forms.ToolStripMenuItem();
            this.sb_B_VFOMEM = new System.Windows.Forms.ToolStripDropDownButton();
            this.mi_B_VFO = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_B_MEM = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_B_WX = new System.Windows.Forms.ToolStripMenuItem();
            this.sb_B_Scan = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tslbl_B_RecStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbBSmeter = new System.Windows.Forms.ProgressBar();
            this.btn_B_KPdot = new System.Windows.Forms.Button();
            this.btn_B_KPEnter = new System.Windows.Forms.Button();
            this.btn_B_KP9 = new System.Windows.Forms.Button();
            this.btn_B_KP8 = new System.Windows.Forms.Button();
            this.btn_B_KP7 = new System.Windows.Forms.Button();
            this.btn_B_KP6 = new System.Windows.Forms.Button();
            this.btn_B_KP5 = new System.Windows.Forms.Button();
            this.btn_B_KP4 = new System.Windows.Forms.Button();
            this.btn_B_KP3 = new System.Windows.Forms.Button();
            this.btn_B_KP2 = new System.Windows.Forms.Button();
            this.btn_B_KP1 = new System.Windows.Forms.Button();
            this.btn_B_KP0 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.trk_B_SqlLvl = new System.Windows.Forms.TrackBar();
            this.lbl_B_RFGain = new System.Windows.Forms.Label();
            this.trk_B_RFGain = new System.Windows.Forms.TrackBar();
            this.lbl_B_AFGain = new System.Windows.Forms.Label();
            this.trk_B_AFGain = new System.Windows.Forms.TrackBar();
            this.lblB_Hz_Ind = new System.Windows.Forms.Label();
            this.lblB_KHz_Ind = new System.Windows.Forms.Label();
            this.lblB_MHz_Ind = new System.Windows.Forms.Label();
            this.lblB_GHz_Ind = new System.Windows.Forms.Label();
            this.btnB_Hz = new System.Windows.Forms.Button();
            this.btnB_KHz = new System.Windows.Forms.Button();
            this.btnB_GHz = new System.Windows.Forms.Button();
            this.btnB_MHz = new System.Windows.Forms.Button();
            this.txtB_FreqEntry = new System.Windows.Forms.TextBox();
            this.lblBFreq = new System.Windows.Forms.Label();
            this.chkPUW = new System.Windows.Forms.CheckBox();
            this.btnPowerOn = new System.Windows.Forms.Button();
            this.btnPowerOff = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mtsbConnect = new System.Windows.Forms.ToolStripButton();
            this.mtsl_COMPort = new System.Windows.Forms.ToolStripLabel();
            this.mtscb_COMPort = new System.Windows.Forms.ToolStripComboBox();
            this.mtsl_BaudRate = new System.Windows.Forms.ToolStripLabel();
            this.mtscb_BaudRate = new System.Windows.Forms.ToolStripComboBox();
            this.mtsl_Layout = new System.Windows.Forms.ToolStripLabel();
            this.mtsdb_Layout = new System.Windows.Forms.ToolStripDropDownButton();
            this.mtsdb_Layout_SingleA = new System.Windows.Forms.ToolStripMenuItem();
            this.mtsdb_Layout_SingleB = new System.Windows.Forms.ToolStripMenuItem();
            this.mtsdb_Layout_Dual = new System.Windows.Forms.ToolStripMenuItem();
            this.mtsdb_SwitchingType = new System.Windows.Forms.ToolStripDropDownButton();
            this.mtsdb_SwitchingType_MouseOver = new System.Windows.Forms.ToolStripMenuItem();
            this.mtsdb_SwitchingType_Manual = new System.Windows.Forms.ToolStripMenuItem();
            this.grp_A_FM = new System.Windows.Forms.GroupBox();
            this.lbl_A_FM_SQLFreqOrCode = new System.Windows.Forms.Label();
            this.opn_A_FM_SqlMode_DTCS_R = new System.Windows.Forms.RadioButton();
            this.opn_A_FM_SqlMode_DTCS = new System.Windows.Forms.RadioButton();
            this.opn_A_FM_SqlMode_TSQL_R = new System.Windows.Forms.RadioButton();
            this.opn_A_FM_SqlMode_TSQL = new System.Windows.Forms.RadioButton();
            this.opn_A_FM_SqlMode_None = new System.Windows.Forms.RadioButton();
            this.chk_A_FM_VSC = new System.Windows.Forms.CheckBox();
            this.cmb_A_FM_DTCSCode = new System.Windows.Forms.ComboBox();
            this.cmb_A_FM_TSQLFreq = new System.Windows.Forms.ComboBox();
            this.lbl_A_FM_SQLTYPE = new System.Windows.Forms.Label();
            this.chk_A_FM_AFC = new System.Windows.Forms.CheckBox();
            this.grp_A_P25 = new System.Windows.Forms.GroupBox();
            this.txt_A_P25_Dest_DBName = new System.Windows.Forms.TextBox();
            this.txt_A_P25_Src_DBName = new System.Windows.Forms.TextBox();
            this.txt_A_P25_CallType = new System.Windows.Forms.TextBox();
            this.txt_A_P25_NAC = new System.Windows.Forms.TextBox();
            this.txt_A_P25_Dest = new System.Windows.Forms.TextBox();
            this.txt_A_P25_Src = new System.Windows.Forms.TextBox();
            this.lbl_A_P25_CallType = new System.Windows.Forms.Label();
            this.lbl_A_P25_Enc = new System.Windows.Forms.Label();
            this.lbl_A_P25_EMERG = new System.Windows.Forms.Label();
            this.lbl_A_P25_NAC = new System.Windows.Forms.Label();
            this.lbl_A_P25_Dest = new System.Windows.Forms.Label();
            this.lbl_A_P25_Src = new System.Windows.Forms.Label();
            this.grp_A_AM = new System.Windows.Forms.GroupBox();
            this.chk_A_AM_ANL = new System.Windows.Forms.CheckBox();
            this.chk_A_AM_VSC = new System.Windows.Forms.CheckBox();
            this.grp_A_SSB = new System.Windows.Forms.GroupBox();
            this.chk_A_SSB_NB = new System.Windows.Forms.CheckBox();
            this.grp_B_FM = new System.Windows.Forms.GroupBox();
            this.lbl_B_FM_SQLFreqOrCode = new System.Windows.Forms.Label();
            this.opn_B_FM_SqlMode_DTCS_R = new System.Windows.Forms.RadioButton();
            this.opn_B_FM_SqlMode_DTCS = new System.Windows.Forms.RadioButton();
            this.opn_B_FM_SqlMode_TSQL_R = new System.Windows.Forms.RadioButton();
            this.opn_B_FM_SqlMode_TSQL = new System.Windows.Forms.RadioButton();
            this.opn_B_FM_SqlMode_None = new System.Windows.Forms.RadioButton();
            this.chk_B_FM_VSC = new System.Windows.Forms.CheckBox();
            this.cmb_B_FM_DTCSCode = new System.Windows.Forms.ComboBox();
            this.cmb_B_FM_TSQLFreq = new System.Windows.Forms.ComboBox();
            this.lbl_B_FM_SQLTYPE = new System.Windows.Forms.Label();
            this.chk_B_FM_AFC = new System.Windows.Forms.CheckBox();
            this.grp_B_P25 = new System.Windows.Forms.GroupBox();
            this.txt_B_P25_Dest_DBName = new System.Windows.Forms.TextBox();
            this.txt_B_P25_Src_DBName = new System.Windows.Forms.TextBox();
            this.txt_B_P25_CallType = new System.Windows.Forms.TextBox();
            this.txt_B_P25_NAC = new System.Windows.Forms.TextBox();
            this.txt_B_P25_Dest = new System.Windows.Forms.TextBox();
            this.txt_B_P25_Src = new System.Windows.Forms.TextBox();
            this.lbl_B_P25_CallType = new System.Windows.Forms.Label();
            this.lbl_B_P25_Enc = new System.Windows.Forms.Label();
            this.lbl_B_P25_EMERG = new System.Windows.Forms.Label();
            this.lbl_B_P25_NAC = new System.Windows.Forms.Label();
            this.lbl_B_P25_Dest = new System.Windows.Forms.Label();
            this.lbl_B_P25_Src = new System.Windows.Forms.Label();
            this.grp_B_AM = new System.Windows.Forms.GroupBox();
            this.chk_B_AM_ANL = new System.Windows.Forms.CheckBox();
            this.chk_B_AM_VSC = new System.Windows.Forms.CheckBox();
            this.mtslbl_Switching = new System.Windows.Forms.ToolStripLabel();
            this.mtsl_Attenuator = new System.Windows.Forms.ToolStripLabel();
            this.mtsdb_Attenuator = new System.Windows.Forms.ToolStripDropDownButton();
            this.mtsdb_Attenuator_OFF = new System.Windows.Forms.ToolStripMenuItem();
            this.mtsdb_Attenuator_ATT1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mtsdb_Attenuator_ATT2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mtsdb_Attenuator_ATT3 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_About = new System.Windows.Forms.Button();
            this.mtsdb_Data = new System.Windows.Forms.ToolStripDropDownButton();
            this.mtsdb_Data_LoadP25Grp = new System.Windows.Forms.ToolStripMenuItem();
            this.mtsdb_Data_LoadP25Rad = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.btnScanTest = new System.Windows.Forms.Button();
            this.grpRecA.SuspendLayout();
            this.grp_A_ScanCtrl.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.m_A_Mode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trk_A_SqlLvl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_A_RFGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_A_AFGain)).BeginInit();
            this.grpRecB.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.m_B_Mode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trk_B_SqlLvl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_B_RFGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_B_AFGain)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.grp_A_FM.SuspendLayout();
            this.grp_A_P25.SuspendLayout();
            this.grp_A_AM.SuspendLayout();
            this.grp_A_SSB.SuspendLayout();
            this.grp_B_FM.SuspendLayout();
            this.grp_B_P25.SuspendLayout();
            this.grp_B_AM.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDbgSend
            // 
            this.txtDbgSend.Location = new System.Drawing.Point(11, 385);
            this.txtDbgSend.Name = "txtDbgSend";
            this.txtDbgSend.Size = new System.Drawing.Size(373, 20);
            this.txtDbgSend.TabIndex = 1;
            // 
            // btnDebugSend
            // 
            this.btnDebugSend.Location = new System.Drawing.Point(390, 382);
            this.btnDebugSend.Name = "btnDebugSend";
            this.btnDebugSend.Size = new System.Drawing.Size(75, 23);
            this.btnDebugSend.TabIndex = 2;
            this.btnDebugSend.Text = "Send";
            this.btnDebugSend.UseVisualStyleBackColor = true;
            this.btnDebugSend.Click += new System.EventHandler(this.btnDebugSend_Click);
            // 
            // grpRecA
            // 
            this.grpRecA.BackColor = System.Drawing.Color.Transparent;
            this.grpRecA.Controls.Add(this.lbl_A_SqlAuto);
            this.grpRecA.Controls.Add(this.lbl_A_SqlOpen);
            this.grpRecA.Controls.Add(this.btn_A_ReceiveInd);
            this.grpRecA.Controls.Add(this.lbl_A_MemGrpName);
            this.grpRecA.Controls.Add(this.grp_A_ScanCtrl);
            this.grpRecA.Controls.Add(this.lbl_A_MEM_MEM);
            this.grpRecA.Controls.Add(this.lbl_A_MEM_GRP);
            this.grpRecA.Controls.Add(this.lbl_A_MemName);
            this.grpRecA.Controls.Add(this.pbASmeter);
            this.grpRecA.Controls.Add(this.btn_A_KPdot);
            this.grpRecA.Controls.Add(this.btn_A_KPEnter);
            this.grpRecA.Controls.Add(this.btn_A_KP9);
            this.grpRecA.Controls.Add(this.btn_A_KP8);
            this.grpRecA.Controls.Add(this.btn_A_KP7);
            this.grpRecA.Controls.Add(this.btn_A_KP6);
            this.grpRecA.Controls.Add(this.btn_A_KP5);
            this.grpRecA.Controls.Add(this.btn_A_KP4);
            this.grpRecA.Controls.Add(this.btn_A_KP3);
            this.grpRecA.Controls.Add(this.btn_A_KP2);
            this.grpRecA.Controls.Add(this.btn_A_KP1);
            this.grpRecA.Controls.Add(this.btn_A_KP0);
            this.grpRecA.Controls.Add(this.statusStrip1);
            this.grpRecA.Controls.Add(this.lbl_A_Sql);
            this.grpRecA.Controls.Add(this.trk_A_SqlLvl);
            this.grpRecA.Controls.Add(this.lbl_A_RFGain);
            this.grpRecA.Controls.Add(this.trk_A_RFGain);
            this.grpRecA.Controls.Add(this.lbl_A_AFGain);
            this.grpRecA.Controls.Add(this.trk_A_AFGain);
            this.grpRecA.Controls.Add(this.lblA_Hz_Ind);
            this.grpRecA.Controls.Add(this.lblA_KHz_Ind);
            this.grpRecA.Controls.Add(this.lblA_MHz_Ind);
            this.grpRecA.Controls.Add(this.lblA_GHz_Ind);
            this.grpRecA.Controls.Add(this.btnA_Hz);
            this.grpRecA.Controls.Add(this.btnA_KHz);
            this.grpRecA.Controls.Add(this.btnA_GHz);
            this.grpRecA.Controls.Add(this.btnA_MHz);
            this.grpRecA.Controls.Add(this.txtA_FreqEntry);
            this.grpRecA.Controls.Add(this.lblAFreq);
            this.grpRecA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRecA.Location = new System.Drawing.Point(21, 29);
            this.grpRecA.Name = "grpRecA";
            this.grpRecA.Size = new System.Drawing.Size(600, 350);
            this.grpRecA.TabIndex = 3;
            this.grpRecA.TabStop = false;
            this.grpRecA.Text = "Receiver A";
            // 
            // lbl_A_SqlAuto
            // 
            this.lbl_A_SqlAuto.AutoSize = true;
            this.lbl_A_SqlAuto.Location = new System.Drawing.Point(382, 259);
            this.lbl_A_SqlAuto.Name = "lbl_A_SqlAuto";
            this.lbl_A_SqlAuto.Size = new System.Drawing.Size(15, 26);
            this.lbl_A_SqlAuto.TabIndex = 41;
            this.lbl_A_SqlAuto.Text = "|\r\nA";
            this.lbl_A_SqlAuto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_A_SqlOpen
            // 
            this.lbl_A_SqlOpen.AutoSize = true;
            this.lbl_A_SqlOpen.Location = new System.Drawing.Point(364, 259);
            this.lbl_A_SqlOpen.Name = "lbl_A_SqlOpen";
            this.lbl_A_SqlOpen.Size = new System.Drawing.Size(16, 26);
            this.lbl_A_SqlOpen.TabIndex = 40;
            this.lbl_A_SqlOpen.Text = "|\r\nO";
            this.lbl_A_SqlOpen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_A_ReceiveInd
            // 
            this.btn_A_ReceiveInd.Location = new System.Drawing.Point(464, 19);
            this.btn_A_ReceiveInd.Name = "btn_A_ReceiveInd";
            this.btn_A_ReceiveInd.Size = new System.Drawing.Size(102, 23);
            this.btn_A_ReceiveInd.TabIndex = 39;
            this.btn_A_ReceiveInd.Text = "Receive";
            this.btn_A_ReceiveInd.UseVisualStyleBackColor = true;
            this.btn_A_ReceiveInd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_A_ReceiveInd_MouseDown);
            this.btn_A_ReceiveInd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_A_ReceiveInd_MouseUp);
            // 
            // lbl_A_MemGrpName
            // 
            this.lbl_A_MemGrpName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_A_MemGrpName.Location = new System.Drawing.Point(78, 25);
            this.lbl_A_MemGrpName.Name = "lbl_A_MemGrpName";
            this.lbl_A_MemGrpName.Size = new System.Drawing.Size(285, 36);
            this.lbl_A_MemGrpName.TabIndex = 38;
            // 
            // grp_A_ScanCtrl
            // 
            this.grp_A_ScanCtrl.Controls.Add(this.btn_A_ScanCtrl_Skip);
            this.grp_A_ScanCtrl.Location = new System.Drawing.Point(424, 280);
            this.grp_A_ScanCtrl.Name = "grp_A_ScanCtrl";
            this.grp_A_ScanCtrl.Size = new System.Drawing.Size(170, 42);
            this.grp_A_ScanCtrl.TabIndex = 37;
            this.grp_A_ScanCtrl.TabStop = false;
            this.grp_A_ScanCtrl.Text = "Scan Control";
            // 
            // btn_A_ScanCtrl_Skip
            // 
            this.btn_A_ScanCtrl_Skip.Location = new System.Drawing.Point(6, 13);
            this.btn_A_ScanCtrl_Skip.Name = "btn_A_ScanCtrl_Skip";
            this.btn_A_ScanCtrl_Skip.Size = new System.Drawing.Size(43, 23);
            this.btn_A_ScanCtrl_Skip.TabIndex = 0;
            this.btn_A_ScanCtrl_Skip.Text = "Skip";
            this.btn_A_ScanCtrl_Skip.UseVisualStyleBackColor = true;
            this.btn_A_ScanCtrl_Skip.Click += new System.EventHandler(this.btn_ScanCtrl_Skip_Click);
            // 
            // lbl_A_MEM_MEM
            // 
            this.lbl_A_MEM_MEM.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_A_MEM_MEM.Location = new System.Drawing.Point(29, 55);
            this.lbl_A_MEM_MEM.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_A_MEM_MEM.Name = "lbl_A_MEM_MEM";
            this.lbl_A_MEM_MEM.Size = new System.Drawing.Size(46, 36);
            this.lbl_A_MEM_MEM.TabIndex = 36;
            this.lbl_A_MEM_MEM.Text = "00";
            // 
            // lbl_A_MEM_GRP
            // 
            this.lbl_A_MEM_GRP.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_A_MEM_GRP.Location = new System.Drawing.Point(29, 25);
            this.lbl_A_MEM_GRP.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_A_MEM_GRP.Name = "lbl_A_MEM_GRP";
            this.lbl_A_MEM_GRP.Size = new System.Drawing.Size(46, 36);
            this.lbl_A_MEM_GRP.TabIndex = 35;
            this.lbl_A_MEM_GRP.Text = "00";
            // 
            // lbl_A_MemName
            // 
            this.lbl_A_MemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_A_MemName.Location = new System.Drawing.Point(78, 55);
            this.lbl_A_MemName.Name = "lbl_A_MemName";
            this.lbl_A_MemName.Size = new System.Drawing.Size(285, 36);
            this.lbl_A_MemName.TabIndex = 34;
            // 
            // pbASmeter
            // 
            this.pbASmeter.Location = new System.Drawing.Point(408, 210);
            this.pbASmeter.MarqueeAnimationSpeed = 0;
            this.pbASmeter.Maximum = 255;
            this.pbASmeter.Name = "pbASmeter";
            this.pbASmeter.Size = new System.Drawing.Size(163, 13);
            this.pbASmeter.TabIndex = 33;
            // 
            // btn_A_KPdot
            // 
            this.btn_A_KPdot.Location = new System.Drawing.Point(133, 295);
            this.btn_A_KPdot.Name = "btn_A_KPdot";
            this.btn_A_KPdot.Size = new System.Drawing.Size(55, 23);
            this.btn_A_KPdot.TabIndex = 32;
            this.btn_A_KPdot.Text = ".";
            this.btn_A_KPdot.UseVisualStyleBackColor = true;
            this.btn_A_KPdot.Click += new System.EventHandler(this.btn_A_KPdot_Click);
            // 
            // btn_A_KPEnter
            // 
            this.btn_A_KPEnter.Location = new System.Drawing.Point(255, 295);
            this.btn_A_KPEnter.Name = "btn_A_KPEnter";
            this.btn_A_KPEnter.Size = new System.Drawing.Size(55, 23);
            this.btn_A_KPEnter.TabIndex = 31;
            this.btn_A_KPEnter.Text = "Enter";
            this.btn_A_KPEnter.UseVisualStyleBackColor = true;
            this.btn_A_KPEnter.Click += new System.EventHandler(this.btn_A_KPEnter_Click);
            // 
            // btn_A_KP9
            // 
            this.btn_A_KP9.Location = new System.Drawing.Point(255, 266);
            this.btn_A_KP9.Name = "btn_A_KP9";
            this.btn_A_KP9.Size = new System.Drawing.Size(55, 23);
            this.btn_A_KP9.TabIndex = 30;
            this.btn_A_KP9.Text = "9";
            this.btn_A_KP9.UseVisualStyleBackColor = true;
            this.btn_A_KP9.Click += new System.EventHandler(this.btn_A_KP9_Click);
            // 
            // btn_A_KP8
            // 
            this.btn_A_KP8.Location = new System.Drawing.Point(194, 266);
            this.btn_A_KP8.Name = "btn_A_KP8";
            this.btn_A_KP8.Size = new System.Drawing.Size(55, 23);
            this.btn_A_KP8.TabIndex = 29;
            this.btn_A_KP8.Text = "8";
            this.btn_A_KP8.UseVisualStyleBackColor = true;
            this.btn_A_KP8.Click += new System.EventHandler(this.btn_A_KP8_Click);
            // 
            // btn_A_KP7
            // 
            this.btn_A_KP7.Location = new System.Drawing.Point(133, 266);
            this.btn_A_KP7.Name = "btn_A_KP7";
            this.btn_A_KP7.Size = new System.Drawing.Size(55, 23);
            this.btn_A_KP7.TabIndex = 28;
            this.btn_A_KP7.Text = "7";
            this.btn_A_KP7.UseVisualStyleBackColor = true;
            this.btn_A_KP7.Click += new System.EventHandler(this.btn_A_KP7_Click);
            // 
            // btn_A_KP6
            // 
            this.btn_A_KP6.Location = new System.Drawing.Point(255, 237);
            this.btn_A_KP6.Name = "btn_A_KP6";
            this.btn_A_KP6.Size = new System.Drawing.Size(55, 23);
            this.btn_A_KP6.TabIndex = 27;
            this.btn_A_KP6.Text = "6";
            this.btn_A_KP6.UseVisualStyleBackColor = true;
            this.btn_A_KP6.Click += new System.EventHandler(this.btn_A_KP6_Click);
            // 
            // btn_A_KP5
            // 
            this.btn_A_KP5.Location = new System.Drawing.Point(194, 237);
            this.btn_A_KP5.Name = "btn_A_KP5";
            this.btn_A_KP5.Size = new System.Drawing.Size(55, 23);
            this.btn_A_KP5.TabIndex = 26;
            this.btn_A_KP5.Text = "5";
            this.btn_A_KP5.UseVisualStyleBackColor = true;
            this.btn_A_KP5.Click += new System.EventHandler(this.btn_A_KP5_Click);
            // 
            // btn_A_KP4
            // 
            this.btn_A_KP4.Location = new System.Drawing.Point(133, 237);
            this.btn_A_KP4.Name = "btn_A_KP4";
            this.btn_A_KP4.Size = new System.Drawing.Size(55, 23);
            this.btn_A_KP4.TabIndex = 25;
            this.btn_A_KP4.Text = "4";
            this.btn_A_KP4.UseVisualStyleBackColor = true;
            this.btn_A_KP4.Click += new System.EventHandler(this.btn_A_KP4_Click);
            // 
            // btn_A_KP3
            // 
            this.btn_A_KP3.Location = new System.Drawing.Point(255, 208);
            this.btn_A_KP3.Name = "btn_A_KP3";
            this.btn_A_KP3.Size = new System.Drawing.Size(55, 23);
            this.btn_A_KP3.TabIndex = 24;
            this.btn_A_KP3.Text = "3";
            this.btn_A_KP3.UseVisualStyleBackColor = true;
            this.btn_A_KP3.Click += new System.EventHandler(this.btn_A_KP3_Click);
            // 
            // btn_A_KP2
            // 
            this.btn_A_KP2.Location = new System.Drawing.Point(194, 208);
            this.btn_A_KP2.Name = "btn_A_KP2";
            this.btn_A_KP2.Size = new System.Drawing.Size(55, 23);
            this.btn_A_KP2.TabIndex = 23;
            this.btn_A_KP2.Text = "2";
            this.btn_A_KP2.UseVisualStyleBackColor = true;
            this.btn_A_KP2.Click += new System.EventHandler(this.btn_A_KP2_Click);
            // 
            // btn_A_KP1
            // 
            this.btn_A_KP1.Location = new System.Drawing.Point(133, 208);
            this.btn_A_KP1.Name = "btn_A_KP1";
            this.btn_A_KP1.Size = new System.Drawing.Size(55, 23);
            this.btn_A_KP1.TabIndex = 22;
            this.btn_A_KP1.Text = "1";
            this.btn_A_KP1.UseVisualStyleBackColor = true;
            this.btn_A_KP1.Click += new System.EventHandler(this.btn_A_KP1_Click);
            // 
            // btn_A_KP0
            // 
            this.btn_A_KP0.Location = new System.Drawing.Point(194, 295);
            this.btn_A_KP0.Name = "btn_A_KP0";
            this.btn_A_KP0.Size = new System.Drawing.Size(55, 23);
            this.btn_A_KP0.TabIndex = 21;
            this.btn_A_KP0.Text = "0";
            this.btn_A_KP0.UseVisualStyleBackColor = true;
            this.btn_A_KP0.Click += new System.EventHandler(this.btn_A_KP0_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sb_A_Mode,
            this.sb_A_VFOMEM,
            this.sb_A_Scan,
            this.tslbl_A_RecStatus});
            this.statusStrip1.Location = new System.Drawing.Point(3, 325);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(594, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 20;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sb_A_Mode
            // 
            this.sb_A_Mode.AutoSize = false;
            this.sb_A_Mode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sb_A_Mode.DropDown = this.m_A_Mode;
            this.sb_A_Mode.Image = ((System.Drawing.Image)(resources.GetObject("sb_A_Mode.Image")));
            this.sb_A_Mode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sb_A_Mode.Name = "sb_A_Mode";
            this.sb_A_Mode.Size = new System.Drawing.Size(75, 20);
            this.sb_A_Mode.Text = "Mode";
            this.sb_A_Mode.ToolTipText = "Mode / Modulation";
            this.sb_A_Mode.ButtonClick += new System.EventHandler(this.sb_A_Mode_ButtonClick);
            // 
            // m_A_Mode
            // 
            this.m_A_Mode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_A_Mode_AM,
            this.mi_A_Mode_AM_N,
            this.mi_A_Mode_CW,
            this.mi_A_Mode_CW_R,
            this.mi_A_Mode_DCR,
            this.mi_A_Mode_dPMR,
            this.mi_A_Mode_DSTAR,
            this.mi_A_Mode_FM,
            this.mi_A_Mode_FM_N,
            this.mi_A_Mode_LSB,
            this.mi_A_Mode_NXDN_N,
            this.mi_A_Mode_NXDX_VN,
            this.mi_A_Mode_P25,
            this.mi_A_Mode_USB,
            this.mi_A_Mode_WFM});
            this.m_A_Mode.Name = "mMode";
            this.m_A_Mode.OwnerItem = this.sb_A_Mode;
            this.m_A_Mode.Size = new System.Drawing.Size(129, 334);
            // 
            // mi_A_Mode_AM
            // 
            this.mi_A_Mode_AM.Name = "mi_A_Mode_AM";
            this.mi_A_Mode_AM.Size = new System.Drawing.Size(128, 22);
            this.mi_A_Mode_AM.Text = "AM";
            this.mi_A_Mode_AM.Click += new System.EventHandler(this.mi_Mode_AM_Click);
            // 
            // mi_A_Mode_AM_N
            // 
            this.mi_A_Mode_AM_N.Name = "mi_A_Mode_AM_N";
            this.mi_A_Mode_AM_N.Size = new System.Drawing.Size(128, 22);
            this.mi_A_Mode_AM_N.Text = "AM-N";
            this.mi_A_Mode_AM_N.Click += new System.EventHandler(this.mi_Mode_AM_N_Click);
            // 
            // mi_A_Mode_CW
            // 
            this.mi_A_Mode_CW.Name = "mi_A_Mode_CW";
            this.mi_A_Mode_CW.Size = new System.Drawing.Size(128, 22);
            this.mi_A_Mode_CW.Text = "CW";
            this.mi_A_Mode_CW.Click += new System.EventHandler(this.mi_Mode_CW_Click);
            // 
            // mi_A_Mode_CW_R
            // 
            this.mi_A_Mode_CW_R.Name = "mi_A_Mode_CW_R";
            this.mi_A_Mode_CW_R.Size = new System.Drawing.Size(128, 22);
            this.mi_A_Mode_CW_R.Text = "CW-R";
            this.mi_A_Mode_CW_R.Click += new System.EventHandler(this.mi_Mode_CW_R_Click);
            // 
            // mi_A_Mode_DCR
            // 
            this.mi_A_Mode_DCR.Name = "mi_A_Mode_DCR";
            this.mi_A_Mode_DCR.Size = new System.Drawing.Size(128, 22);
            this.mi_A_Mode_DCR.Text = "DCR";
            this.mi_A_Mode_DCR.Click += new System.EventHandler(this.mi_Mode_DCR_Click);
            // 
            // mi_A_Mode_dPMR
            // 
            this.mi_A_Mode_dPMR.Name = "mi_A_Mode_dPMR";
            this.mi_A_Mode_dPMR.Size = new System.Drawing.Size(128, 22);
            this.mi_A_Mode_dPMR.Text = "dPMR";
            this.mi_A_Mode_dPMR.Click += new System.EventHandler(this.mi_Mode_dPMR_Click);
            // 
            // mi_A_Mode_DSTAR
            // 
            this.mi_A_Mode_DSTAR.Name = "mi_A_Mode_DSTAR";
            this.mi_A_Mode_DSTAR.Size = new System.Drawing.Size(128, 22);
            this.mi_A_Mode_DSTAR.Text = "D-STAR";
            this.mi_A_Mode_DSTAR.Click += new System.EventHandler(this.mi_Mode_DSTAR_Click);
            // 
            // mi_A_Mode_FM
            // 
            this.mi_A_Mode_FM.Name = "mi_A_Mode_FM";
            this.mi_A_Mode_FM.Size = new System.Drawing.Size(128, 22);
            this.mi_A_Mode_FM.Text = "FM";
            this.mi_A_Mode_FM.Click += new System.EventHandler(this.mi_Mode_FM_Click);
            // 
            // mi_A_Mode_FM_N
            // 
            this.mi_A_Mode_FM_N.Name = "mi_A_Mode_FM_N";
            this.mi_A_Mode_FM_N.Size = new System.Drawing.Size(128, 22);
            this.mi_A_Mode_FM_N.Text = "FM-N";
            this.mi_A_Mode_FM_N.Click += new System.EventHandler(this.mi_Mode_FM_N_Click);
            // 
            // mi_A_Mode_LSB
            // 
            this.mi_A_Mode_LSB.Name = "mi_A_Mode_LSB";
            this.mi_A_Mode_LSB.Size = new System.Drawing.Size(128, 22);
            this.mi_A_Mode_LSB.Text = "LSB";
            this.mi_A_Mode_LSB.Click += new System.EventHandler(this.mi_Mode_LSB_Click);
            // 
            // mi_A_Mode_NXDN_N
            // 
            this.mi_A_Mode_NXDN_N.Name = "mi_A_Mode_NXDN_N";
            this.mi_A_Mode_NXDN_N.Size = new System.Drawing.Size(128, 22);
            this.mi_A_Mode_NXDN_N.Text = "NXDN-N";
            this.mi_A_Mode_NXDN_N.Click += new System.EventHandler(this.mi_Mode_NXDN_N_Click);
            // 
            // mi_A_Mode_NXDX_VN
            // 
            this.mi_A_Mode_NXDX_VN.Name = "mi_A_Mode_NXDX_VN";
            this.mi_A_Mode_NXDX_VN.Size = new System.Drawing.Size(128, 22);
            this.mi_A_Mode_NXDX_VN.Text = "NXDN-VN";
            this.mi_A_Mode_NXDX_VN.Click += new System.EventHandler(this.mi_Mode_NXDX_VN_Click);
            // 
            // mi_A_Mode_P25
            // 
            this.mi_A_Mode_P25.Name = "mi_A_Mode_P25";
            this.mi_A_Mode_P25.Size = new System.Drawing.Size(128, 22);
            this.mi_A_Mode_P25.Text = "P25";
            this.mi_A_Mode_P25.Click += new System.EventHandler(this.mi_Mode_P25_Click);
            // 
            // mi_A_Mode_USB
            // 
            this.mi_A_Mode_USB.Name = "mi_A_Mode_USB";
            this.mi_A_Mode_USB.Size = new System.Drawing.Size(128, 22);
            this.mi_A_Mode_USB.Text = "USB";
            this.mi_A_Mode_USB.Click += new System.EventHandler(this.mi_Mode_USB_Click);
            // 
            // mi_A_Mode_WFM
            // 
            this.mi_A_Mode_WFM.Name = "mi_A_Mode_WFM";
            this.mi_A_Mode_WFM.Size = new System.Drawing.Size(128, 22);
            this.mi_A_Mode_WFM.Text = "WFM";
            this.mi_A_Mode_WFM.Click += new System.EventHandler(this.mi_Mode_WFM_Click);
            // 
            // sb_A_VFOMEM
            // 
            this.sb_A_VFOMEM.AutoSize = false;
            this.sb_A_VFOMEM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sb_A_VFOMEM.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_A_VFO,
            this.mi_A_MEM,
            this.mi_A_WX});
            this.sb_A_VFOMEM.Image = ((System.Drawing.Image)(resources.GetObject("sb_A_VFOMEM.Image")));
            this.sb_A_VFOMEM.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sb_A_VFOMEM.Name = "sb_A_VFOMEM";
            this.sb_A_VFOMEM.Size = new System.Drawing.Size(60, 20);
            this.sb_A_VFOMEM.Text = "VFO";
            this.sb_A_VFOMEM.ToolTipText = "Tuning Mode";
            // 
            // mi_A_VFO
            // 
            this.mi_A_VFO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mi_A_VFO.Name = "mi_A_VFO";
            this.mi_A_VFO.Size = new System.Drawing.Size(102, 22);
            this.mi_A_VFO.Text = "VFO";
            this.mi_A_VFO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mi_A_VFO.Click += new System.EventHandler(this.mi_A_VFO_Click);
            // 
            // mi_A_MEM
            // 
            this.mi_A_MEM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mi_A_MEM.Name = "mi_A_MEM";
            this.mi_A_MEM.Size = new System.Drawing.Size(102, 22);
            this.mi_A_MEM.Text = "MEM";
            this.mi_A_MEM.Click += new System.EventHandler(this.mi_A_MEM_Click);
            // 
            // mi_A_WX
            // 
            this.mi_A_WX.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mi_A_WX.Name = "mi_A_WX";
            this.mi_A_WX.Size = new System.Drawing.Size(102, 22);
            this.mi_A_WX.Text = "WX";
            this.mi_A_WX.Click += new System.EventHandler(this.mi_A_WX_Click);
            // 
            // sb_A_Scan
            // 
            this.sb_A_Scan.AutoSize = false;
            this.sb_A_Scan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sb_A_Scan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.sb_A_Scan.Image = ((System.Drawing.Image)(resources.GetObject("sb_A_Scan.Image")));
            this.sb_A_Scan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sb_A_Scan.Name = "sb_A_Scan";
            this.sb_A_Scan.Size = new System.Drawing.Size(79, 20);
            this.sb_A_Scan.Text = "Start Scan";
            this.sb_A_Scan.ToolTipText = "Scan Control";
            this.sb_A_Scan.ButtonClick += new System.EventHandler(this.sb_A_Scan_ButtonClick);
            this.sb_A_Scan.DropDownOpening += new System.EventHandler(this.sb_A_Scan_DropDownOpening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // tslbl_A_RecStatus
            // 
            this.tslbl_A_RecStatus.AutoSize = false;
            this.tslbl_A_RecStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.tslbl_A_RecStatus.Name = "tslbl_A_RecStatus";
            this.tslbl_A_RecStatus.Size = new System.Drawing.Size(75, 17);
            this.tslbl_A_RecStatus.Text = "Stopped";
            this.tslbl_A_RecStatus.ToolTipText = "Recording Status";
            this.tslbl_A_RecStatus.Click += new System.EventHandler(this.tslbl_A_RecStatus_Click);
            // 
            // lbl_A_Sql
            // 
            this.lbl_A_Sql.AutoSize = true;
            this.lbl_A_Sql.Location = new System.Drawing.Point(429, 259);
            this.lbl_A_Sql.Name = "lbl_A_Sql";
            this.lbl_A_Sql.Size = new System.Drawing.Size(46, 13);
            this.lbl_A_Sql.TabIndex = 18;
            this.lbl_A_Sql.Text = "Sql Lvl";
            // 
            // trk_A_SqlLvl
            // 
            this.trk_A_SqlLvl.Location = new System.Drawing.Point(359, 229);
            this.trk_A_SqlLvl.Maximum = 30;
            this.trk_A_SqlLvl.Name = "trk_A_SqlLvl";
            this.trk_A_SqlLvl.Size = new System.Drawing.Size(220, 45);
            this.trk_A_SqlLvl.TabIndex = 17;
            this.trk_A_SqlLvl.TickFrequency = 3;
            this.trk_A_SqlLvl.Scroll += new System.EventHandler(this.trk_A_SqlLvl_Scroll);
            // 
            // lbl_A_RFGain
            // 
            this.lbl_A_RFGain.AutoSize = true;
            this.lbl_A_RFGain.Location = new System.Drawing.Point(513, 62);
            this.lbl_A_RFGain.Name = "lbl_A_RFGain";
            this.lbl_A_RFGain.Size = new System.Drawing.Size(53, 13);
            this.lbl_A_RFGain.TabIndex = 16;
            this.lbl_A_RFGain.Text = "RF Gain";
            // 
            // trk_A_RFGain
            // 
            this.trk_A_RFGain.LargeChange = 3;
            this.trk_A_RFGain.Location = new System.Drawing.Point(521, 81);
            this.trk_A_RFGain.Maximum = 27;
            this.trk_A_RFGain.Name = "trk_A_RFGain";
            this.trk_A_RFGain.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trk_A_RFGain.Size = new System.Drawing.Size(45, 121);
            this.trk_A_RFGain.SmallChange = 3;
            this.trk_A_RFGain.TabIndex = 15;
            this.trk_A_RFGain.TickFrequency = 3;
            this.trk_A_RFGain.Scroll += new System.EventHandler(this.trk_A_RFGain_Scroll);
            // 
            // lbl_A_AFGain
            // 
            this.lbl_A_AFGain.AutoSize = true;
            this.lbl_A_AFGain.Location = new System.Drawing.Point(458, 62);
            this.lbl_A_AFGain.Name = "lbl_A_AFGain";
            this.lbl_A_AFGain.Size = new System.Drawing.Size(52, 13);
            this.lbl_A_AFGain.TabIndex = 14;
            this.lbl_A_AFGain.Text = "AF Gain";
            // 
            // trk_A_AFGain
            // 
            this.trk_A_AFGain.LargeChange = 20;
            this.trk_A_AFGain.Location = new System.Drawing.Point(467, 81);
            this.trk_A_AFGain.Maximum = 255;
            this.trk_A_AFGain.Name = "trk_A_AFGain";
            this.trk_A_AFGain.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trk_A_AFGain.Size = new System.Drawing.Size(45, 121);
            this.trk_A_AFGain.SmallChange = 5;
            this.trk_A_AFGain.TabIndex = 13;
            this.trk_A_AFGain.Scroll += new System.EventHandler(this.trk_A_AFGain_Scroll);
            // 
            // lblA_Hz_Ind
            // 
            this.lblA_Hz_Ind.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblA_Hz_Ind.Location = new System.Drawing.Point(298, 158);
            this.lblA_Hz_Ind.Name = "lblA_Hz_Ind";
            this.lblA_Hz_Ind.Size = new System.Drawing.Size(66, 13);
            this.lblA_Hz_Ind.TabIndex = 12;
            this.lblA_Hz_Ind.Click += new System.EventHandler(this.lblA_Hz_Ind_Click);
            // 
            // lblA_KHz_Ind
            // 
            this.lblA_KHz_Ind.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblA_KHz_Ind.Location = new System.Drawing.Point(209, 158);
            this.lblA_KHz_Ind.Name = "lblA_KHz_Ind";
            this.lblA_KHz_Ind.Size = new System.Drawing.Size(66, 13);
            this.lblA_KHz_Ind.TabIndex = 11;
            this.lblA_KHz_Ind.Click += new System.EventHandler(this.lblA_KHz_Ind_Click);
            // 
            // lblA_MHz_Ind
            // 
            this.lblA_MHz_Ind.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblA_MHz_Ind.Location = new System.Drawing.Point(122, 158);
            this.lblA_MHz_Ind.Name = "lblA_MHz_Ind";
            this.lblA_MHz_Ind.Size = new System.Drawing.Size(66, 13);
            this.lblA_MHz_Ind.TabIndex = 10;
            this.lblA_MHz_Ind.Click += new System.EventHandler(this.lblA_MHz_Ind_Click);
            // 
            // lblA_GHz_Ind
            // 
            this.lblA_GHz_Ind.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblA_GHz_Ind.Location = new System.Drawing.Point(32, 158);
            this.lblA_GHz_Ind.Name = "lblA_GHz_Ind";
            this.lblA_GHz_Ind.Size = new System.Drawing.Size(66, 13);
            this.lblA_GHz_Ind.TabIndex = 9;
            this.lblA_GHz_Ind.Click += new System.EventHandler(this.lblA_GHz_Ind_Click);
            // 
            // btnA_Hz
            // 
            this.btnA_Hz.Location = new System.Drawing.Point(298, 132);
            this.btnA_Hz.Name = "btnA_Hz";
            this.btnA_Hz.Size = new System.Drawing.Size(66, 23);
            this.btnA_Hz.TabIndex = 8;
            this.btnA_Hz.Text = "H";
            this.btnA_Hz.UseVisualStyleBackColor = true;
            this.btnA_Hz.Click += new System.EventHandler(this.btnA_Hz_Click);
            // 
            // btnA_KHz
            // 
            this.btnA_KHz.Location = new System.Drawing.Point(209, 132);
            this.btnA_KHz.Name = "btnA_KHz";
            this.btnA_KHz.Size = new System.Drawing.Size(66, 23);
            this.btnA_KHz.TabIndex = 7;
            this.btnA_KHz.Text = "K";
            this.btnA_KHz.UseVisualStyleBackColor = true;
            this.btnA_KHz.Click += new System.EventHandler(this.btnA_KHz_Click);
            // 
            // btnA_GHz
            // 
            this.btnA_GHz.Location = new System.Drawing.Point(32, 132);
            this.btnA_GHz.Name = "btnA_GHz";
            this.btnA_GHz.Size = new System.Drawing.Size(66, 23);
            this.btnA_GHz.TabIndex = 6;
            this.btnA_GHz.Text = "G";
            this.btnA_GHz.UseVisualStyleBackColor = true;
            this.btnA_GHz.Click += new System.EventHandler(this.btnA_GHz_Click);
            // 
            // btnA_MHz
            // 
            this.btnA_MHz.Location = new System.Drawing.Point(122, 132);
            this.btnA_MHz.Name = "btnA_MHz";
            this.btnA_MHz.Size = new System.Drawing.Size(66, 23);
            this.btnA_MHz.TabIndex = 5;
            this.btnA_MHz.Text = "M";
            this.btnA_MHz.UseVisualStyleBackColor = true;
            this.btnA_MHz.Click += new System.EventHandler(this.btnA_MHz_Click);
            // 
            // txtA_FreqEntry
            // 
            this.txtA_FreqEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtA_FreqEntry.Location = new System.Drawing.Point(130, 177);
            this.txtA_FreqEntry.Name = "txtA_FreqEntry";
            this.txtA_FreqEntry.Size = new System.Drawing.Size(180, 26);
            this.txtA_FreqEntry.TabIndex = 4;
            this.txtA_FreqEntry.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtA_FreqEntry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtA_FreqEntry_KeyPress);
            // 
            // lblAFreq
            // 
            this.lblAFreq.Font = new System.Drawing.Font("Lucida Console", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAFreq.Location = new System.Drawing.Point(23, 98);
            this.lblAFreq.Name = "lblAFreq";
            this.lblAFreq.Size = new System.Drawing.Size(350, 31);
            this.lblAFreq.TabIndex = 3;
            this.lblAFreq.Text = "000 000 000 000";
            this.lblAFreq.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblAFreq.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblAFreq_MouseClick);
            // 
            // grpRecB
            // 
            this.grpRecB.Controls.Add(this.lbl_B_SqlAuto);
            this.grpRecB.Controls.Add(this.lbl_B_SqlOpen);
            this.grpRecB.Controls.Add(this.btn_B_ReceiveInd);
            this.grpRecB.Controls.Add(this.lbl_B_MemGrpName);
            this.grpRecB.Controls.Add(this.groupBox2);
            this.grpRecB.Controls.Add(this.lbl_B_MEM_MEM);
            this.grpRecB.Controls.Add(this.lbl_B_MEM_GRP);
            this.grpRecB.Controls.Add(this.lbl_B_MemName);
            this.grpRecB.Controls.Add(this.statusStrip2);
            this.grpRecB.Controls.Add(this.pbBSmeter);
            this.grpRecB.Controls.Add(this.btn_B_KPdot);
            this.grpRecB.Controls.Add(this.btn_B_KPEnter);
            this.grpRecB.Controls.Add(this.btn_B_KP9);
            this.grpRecB.Controls.Add(this.btn_B_KP8);
            this.grpRecB.Controls.Add(this.btn_B_KP7);
            this.grpRecB.Controls.Add(this.btn_B_KP6);
            this.grpRecB.Controls.Add(this.btn_B_KP5);
            this.grpRecB.Controls.Add(this.btn_B_KP4);
            this.grpRecB.Controls.Add(this.btn_B_KP3);
            this.grpRecB.Controls.Add(this.btn_B_KP2);
            this.grpRecB.Controls.Add(this.btn_B_KP1);
            this.grpRecB.Controls.Add(this.btn_B_KP0);
            this.grpRecB.Controls.Add(this.label3);
            this.grpRecB.Controls.Add(this.trk_B_SqlLvl);
            this.grpRecB.Controls.Add(this.lbl_B_RFGain);
            this.grpRecB.Controls.Add(this.trk_B_RFGain);
            this.grpRecB.Controls.Add(this.lbl_B_AFGain);
            this.grpRecB.Controls.Add(this.trk_B_AFGain);
            this.grpRecB.Controls.Add(this.lblB_Hz_Ind);
            this.grpRecB.Controls.Add(this.lblB_KHz_Ind);
            this.grpRecB.Controls.Add(this.lblB_MHz_Ind);
            this.grpRecB.Controls.Add(this.lblB_GHz_Ind);
            this.grpRecB.Controls.Add(this.btnB_Hz);
            this.grpRecB.Controls.Add(this.btnB_KHz);
            this.grpRecB.Controls.Add(this.btnB_GHz);
            this.grpRecB.Controls.Add(this.btnB_MHz);
            this.grpRecB.Controls.Add(this.txtB_FreqEntry);
            this.grpRecB.Controls.Add(this.lblBFreq);
            this.grpRecB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRecB.Location = new System.Drawing.Point(21, 424);
            this.grpRecB.Name = "grpRecB";
            this.grpRecB.Size = new System.Drawing.Size(597, 350);
            this.grpRecB.TabIndex = 4;
            this.grpRecB.TabStop = false;
            this.grpRecB.Text = "Receiver B";
            // 
            // lbl_B_SqlAuto
            // 
            this.lbl_B_SqlAuto.AutoSize = true;
            this.lbl_B_SqlAuto.Location = new System.Drawing.Point(382, 267);
            this.lbl_B_SqlAuto.Name = "lbl_B_SqlAuto";
            this.lbl_B_SqlAuto.Size = new System.Drawing.Size(15, 26);
            this.lbl_B_SqlAuto.TabIndex = 73;
            this.lbl_B_SqlAuto.Text = "|\r\nA";
            this.lbl_B_SqlAuto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_B_SqlOpen
            // 
            this.lbl_B_SqlOpen.AutoSize = true;
            this.lbl_B_SqlOpen.Location = new System.Drawing.Point(364, 267);
            this.lbl_B_SqlOpen.Name = "lbl_B_SqlOpen";
            this.lbl_B_SqlOpen.Size = new System.Drawing.Size(16, 26);
            this.lbl_B_SqlOpen.TabIndex = 72;
            this.lbl_B_SqlOpen.Text = "|\r\nO";
            this.lbl_B_SqlOpen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_B_ReceiveInd
            // 
            this.btn_B_ReceiveInd.Location = new System.Drawing.Point(464, 19);
            this.btn_B_ReceiveInd.Name = "btn_B_ReceiveInd";
            this.btn_B_ReceiveInd.Size = new System.Drawing.Size(102, 23);
            this.btn_B_ReceiveInd.TabIndex = 40;
            this.btn_B_ReceiveInd.Text = "Receive";
            this.btn_B_ReceiveInd.UseVisualStyleBackColor = true;
            this.btn_B_ReceiveInd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_B_ReceiveInd_MouseDown);
            this.btn_B_ReceiveInd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_B_ReceiveInd_MouseUp);
            // 
            // lbl_B_MemGrpName
            // 
            this.lbl_B_MemGrpName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_B_MemGrpName.Location = new System.Drawing.Point(78, 25);
            this.lbl_B_MemGrpName.Name = "lbl_B_MemGrpName";
            this.lbl_B_MemGrpName.Size = new System.Drawing.Size(285, 36);
            this.lbl_B_MemGrpName.TabIndex = 71;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_B_ScanCtrl_Skip);
            this.groupBox2.Location = new System.Drawing.Point(421, 280);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(170, 42);
            this.groupBox2.TabIndex = 70;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scan Control";
            // 
            // btn_B_ScanCtrl_Skip
            // 
            this.btn_B_ScanCtrl_Skip.Location = new System.Drawing.Point(6, 13);
            this.btn_B_ScanCtrl_Skip.Name = "btn_B_ScanCtrl_Skip";
            this.btn_B_ScanCtrl_Skip.Size = new System.Drawing.Size(43, 23);
            this.btn_B_ScanCtrl_Skip.TabIndex = 0;
            this.btn_B_ScanCtrl_Skip.Text = "Skip";
            this.btn_B_ScanCtrl_Skip.UseVisualStyleBackColor = true;
            this.btn_B_ScanCtrl_Skip.Click += new System.EventHandler(this.btn_B_ScanCtrl_Skip_Click);
            // 
            // lbl_B_MEM_MEM
            // 
            this.lbl_B_MEM_MEM.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_B_MEM_MEM.Location = new System.Drawing.Point(29, 55);
            this.lbl_B_MEM_MEM.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_B_MEM_MEM.Name = "lbl_B_MEM_MEM";
            this.lbl_B_MEM_MEM.Size = new System.Drawing.Size(46, 36);
            this.lbl_B_MEM_MEM.TabIndex = 69;
            this.lbl_B_MEM_MEM.Text = "00";
            // 
            // lbl_B_MEM_GRP
            // 
            this.lbl_B_MEM_GRP.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_B_MEM_GRP.Location = new System.Drawing.Point(29, 25);
            this.lbl_B_MEM_GRP.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_B_MEM_GRP.Name = "lbl_B_MEM_GRP";
            this.lbl_B_MEM_GRP.Size = new System.Drawing.Size(46, 36);
            this.lbl_B_MEM_GRP.TabIndex = 68;
            this.lbl_B_MEM_GRP.Text = "00";
            // 
            // lbl_B_MemName
            // 
            this.lbl_B_MemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_B_MemName.Location = new System.Drawing.Point(78, 55);
            this.lbl_B_MemName.Name = "lbl_B_MemName";
            this.lbl_B_MemName.Size = new System.Drawing.Size(288, 36);
            this.lbl_B_MemName.TabIndex = 67;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sb_B_Mode,
            this.sb_B_VFOMEM,
            this.sb_B_Scan,
            this.tslbl_B_RecStatus});
            this.statusStrip2.Location = new System.Drawing.Point(3, 325);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.ShowItemToolTips = true;
            this.statusStrip2.Size = new System.Drawing.Size(591, 22);
            this.statusStrip2.SizingGrip = false;
            this.statusStrip2.TabIndex = 66;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // sb_B_Mode
            // 
            this.sb_B_Mode.AutoSize = false;
            this.sb_B_Mode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sb_B_Mode.DropDown = this.m_B_Mode;
            this.sb_B_Mode.Image = ((System.Drawing.Image)(resources.GetObject("sb_B_Mode.Image")));
            this.sb_B_Mode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sb_B_Mode.Name = "sb_B_Mode";
            this.sb_B_Mode.Size = new System.Drawing.Size(75, 20);
            this.sb_B_Mode.Text = "Mode";
            this.sb_B_Mode.ToolTipText = "Mode / Modulation";
            this.sb_B_Mode.ButtonClick += new System.EventHandler(this.sb_B_Mode_ButtonClick);
            // 
            // m_B_Mode
            // 
            this.m_B_Mode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_B_Mode_AM,
            this.mi_B_Mode_DCR,
            this.mi_B_Mode_dPMR,
            this.mi_B_Mode_DSTAR,
            this.mi_B_Mode_FM,
            this.mi_B_Mode_NXDN_VN,
            this.mi_B_Mode_NXDN_N,
            this.mi_B_Mode_P25});
            this.m_B_Mode.Name = "mMode";
            this.m_B_Mode.OwnerItem = this.sb_B_Mode;
            this.m_B_Mode.Size = new System.Drawing.Size(129, 180);
            // 
            // mi_B_Mode_AM
            // 
            this.mi_B_Mode_AM.Name = "mi_B_Mode_AM";
            this.mi_B_Mode_AM.Size = new System.Drawing.Size(128, 22);
            this.mi_B_Mode_AM.Text = "AM";
            this.mi_B_Mode_AM.Click += new System.EventHandler(this.mi_B_Mode_AM_Click);
            // 
            // mi_B_Mode_DCR
            // 
            this.mi_B_Mode_DCR.Name = "mi_B_Mode_DCR";
            this.mi_B_Mode_DCR.Size = new System.Drawing.Size(128, 22);
            this.mi_B_Mode_DCR.Text = "DCR";
            this.mi_B_Mode_DCR.Click += new System.EventHandler(this.mi_B_Mode_DCR_Click);
            // 
            // mi_B_Mode_dPMR
            // 
            this.mi_B_Mode_dPMR.Name = "mi_B_Mode_dPMR";
            this.mi_B_Mode_dPMR.Size = new System.Drawing.Size(128, 22);
            this.mi_B_Mode_dPMR.Text = "dPMR";
            this.mi_B_Mode_dPMR.Click += new System.EventHandler(this.mi_B_Mode_dPMR_Click);
            // 
            // mi_B_Mode_DSTAR
            // 
            this.mi_B_Mode_DSTAR.Name = "mi_B_Mode_DSTAR";
            this.mi_B_Mode_DSTAR.Size = new System.Drawing.Size(128, 22);
            this.mi_B_Mode_DSTAR.Text = "D-STAR";
            this.mi_B_Mode_DSTAR.Click += new System.EventHandler(this.mi_B_Mode_DSTAR_Click);
            // 
            // mi_B_Mode_FM
            // 
            this.mi_B_Mode_FM.Name = "mi_B_Mode_FM";
            this.mi_B_Mode_FM.Size = new System.Drawing.Size(128, 22);
            this.mi_B_Mode_FM.Text = "FM";
            this.mi_B_Mode_FM.Click += new System.EventHandler(this.mi_B_Mode_FM_Click);
            // 
            // mi_B_Mode_NXDN_VN
            // 
            this.mi_B_Mode_NXDN_VN.Name = "mi_B_Mode_NXDN_VN";
            this.mi_B_Mode_NXDN_VN.Size = new System.Drawing.Size(128, 22);
            this.mi_B_Mode_NXDN_VN.Text = "NXDN-VN";
            this.mi_B_Mode_NXDN_VN.Click += new System.EventHandler(this.mi_B_Mode_NXDN_VN_Click);
            // 
            // mi_B_Mode_NXDN_N
            // 
            this.mi_B_Mode_NXDN_N.Name = "mi_B_Mode_NXDN_N";
            this.mi_B_Mode_NXDN_N.Size = new System.Drawing.Size(128, 22);
            this.mi_B_Mode_NXDN_N.Text = "NXDN-N";
            this.mi_B_Mode_NXDN_N.Click += new System.EventHandler(this.mi_B_Mode_NXDN_N_Click);
            // 
            // mi_B_Mode_P25
            // 
            this.mi_B_Mode_P25.Name = "mi_B_Mode_P25";
            this.mi_B_Mode_P25.Size = new System.Drawing.Size(128, 22);
            this.mi_B_Mode_P25.Text = "P25";
            this.mi_B_Mode_P25.Click += new System.EventHandler(this.mi_B_Mode_P25_Click);
            // 
            // sb_B_VFOMEM
            // 
            this.sb_B_VFOMEM.AutoSize = false;
            this.sb_B_VFOMEM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sb_B_VFOMEM.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_B_VFO,
            this.mi_B_MEM,
            this.mi_B_WX});
            this.sb_B_VFOMEM.Image = ((System.Drawing.Image)(resources.GetObject("sb_B_VFOMEM.Image")));
            this.sb_B_VFOMEM.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sb_B_VFOMEM.Name = "sb_B_VFOMEM";
            this.sb_B_VFOMEM.Size = new System.Drawing.Size(60, 20);
            this.sb_B_VFOMEM.Text = "VFO";
            this.sb_B_VFOMEM.ToolTipText = "Tuning Mode";
            // 
            // mi_B_VFO
            // 
            this.mi_B_VFO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mi_B_VFO.Name = "mi_B_VFO";
            this.mi_B_VFO.Size = new System.Drawing.Size(102, 22);
            this.mi_B_VFO.Text = "VFO";
            this.mi_B_VFO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mi_B_VFO.Click += new System.EventHandler(this.mi_B_VFO_Click);
            // 
            // mi_B_MEM
            // 
            this.mi_B_MEM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mi_B_MEM.Name = "mi_B_MEM";
            this.mi_B_MEM.Size = new System.Drawing.Size(102, 22);
            this.mi_B_MEM.Text = "MEM";
            this.mi_B_MEM.Click += new System.EventHandler(this.mi_B_MEM_Click);
            // 
            // mi_B_WX
            // 
            this.mi_B_WX.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mi_B_WX.Name = "mi_B_WX";
            this.mi_B_WX.Size = new System.Drawing.Size(102, 22);
            this.mi_B_WX.Text = "WX";
            this.mi_B_WX.Click += new System.EventHandler(this.mi_B_WX_Click);
            // 
            // sb_B_Scan
            // 
            this.sb_B_Scan.AutoSize = false;
            this.sb_B_Scan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sb_B_Scan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.sb_B_Scan.Image = ((System.Drawing.Image)(resources.GetObject("sb_B_Scan.Image")));
            this.sb_B_Scan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sb_B_Scan.Name = "sb_B_Scan";
            this.sb_B_Scan.Size = new System.Drawing.Size(79, 20);
            this.sb_B_Scan.Text = "Start Scan";
            this.sb_B_Scan.ToolTipText = "Scan Control";
            this.sb_B_Scan.ButtonClick += new System.EventHandler(this.sb_B_Scan_ButtonClick);
            this.sb_B_Scan.DropDownOpening += new System.EventHandler(this.sb_B_Scan_DropDownOpening);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "toolStripMenuItem1";
            // 
            // tslbl_B_RecStatus
            // 
            this.tslbl_B_RecStatus.AutoSize = false;
            this.tslbl_B_RecStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.tslbl_B_RecStatus.Name = "tslbl_B_RecStatus";
            this.tslbl_B_RecStatus.Size = new System.Drawing.Size(75, 17);
            this.tslbl_B_RecStatus.Text = "Stopped";
            this.tslbl_B_RecStatus.ToolTipText = "Recording Status";
            this.tslbl_B_RecStatus.Click += new System.EventHandler(this.tslbl_B_RecStatus_Click);
            // 
            // pbBSmeter
            // 
            this.pbBSmeter.Location = new System.Drawing.Point(408, 220);
            this.pbBSmeter.MarqueeAnimationSpeed = 0;
            this.pbBSmeter.Maximum = 255;
            this.pbBSmeter.Name = "pbBSmeter";
            this.pbBSmeter.Size = new System.Drawing.Size(163, 11);
            this.pbBSmeter.TabIndex = 65;
            // 
            // btn_B_KPdot
            // 
            this.btn_B_KPdot.Location = new System.Drawing.Point(136, 288);
            this.btn_B_KPdot.Name = "btn_B_KPdot";
            this.btn_B_KPdot.Size = new System.Drawing.Size(55, 23);
            this.btn_B_KPdot.TabIndex = 64;
            this.btn_B_KPdot.Text = ".";
            this.btn_B_KPdot.UseVisualStyleBackColor = true;
            this.btn_B_KPdot.Click += new System.EventHandler(this.btn_B_KPdot_Click);
            // 
            // btn_B_KPEnter
            // 
            this.btn_B_KPEnter.Location = new System.Drawing.Point(258, 288);
            this.btn_B_KPEnter.Name = "btn_B_KPEnter";
            this.btn_B_KPEnter.Size = new System.Drawing.Size(55, 23);
            this.btn_B_KPEnter.TabIndex = 63;
            this.btn_B_KPEnter.Text = "Enter";
            this.btn_B_KPEnter.UseVisualStyleBackColor = true;
            this.btn_B_KPEnter.Click += new System.EventHandler(this.btn_B_KPEnter_Click);
            // 
            // btn_B_KP9
            // 
            this.btn_B_KP9.Location = new System.Drawing.Point(258, 259);
            this.btn_B_KP9.Name = "btn_B_KP9";
            this.btn_B_KP9.Size = new System.Drawing.Size(55, 23);
            this.btn_B_KP9.TabIndex = 62;
            this.btn_B_KP9.Text = "9";
            this.btn_B_KP9.UseVisualStyleBackColor = true;
            this.btn_B_KP9.Click += new System.EventHandler(this.btn_B_KP9_Click);
            // 
            // btn_B_KP8
            // 
            this.btn_B_KP8.Location = new System.Drawing.Point(197, 259);
            this.btn_B_KP8.Name = "btn_B_KP8";
            this.btn_B_KP8.Size = new System.Drawing.Size(55, 23);
            this.btn_B_KP8.TabIndex = 61;
            this.btn_B_KP8.Text = "8";
            this.btn_B_KP8.UseVisualStyleBackColor = true;
            this.btn_B_KP8.Click += new System.EventHandler(this.btn_B_KP8_Click);
            // 
            // btn_B_KP7
            // 
            this.btn_B_KP7.Location = new System.Drawing.Point(136, 259);
            this.btn_B_KP7.Name = "btn_B_KP7";
            this.btn_B_KP7.Size = new System.Drawing.Size(55, 23);
            this.btn_B_KP7.TabIndex = 60;
            this.btn_B_KP7.Text = "7";
            this.btn_B_KP7.UseVisualStyleBackColor = true;
            this.btn_B_KP7.Click += new System.EventHandler(this.btn_B_KP7_Click);
            // 
            // btn_B_KP6
            // 
            this.btn_B_KP6.Location = new System.Drawing.Point(258, 230);
            this.btn_B_KP6.Name = "btn_B_KP6";
            this.btn_B_KP6.Size = new System.Drawing.Size(55, 23);
            this.btn_B_KP6.TabIndex = 59;
            this.btn_B_KP6.Text = "6";
            this.btn_B_KP6.UseVisualStyleBackColor = true;
            this.btn_B_KP6.Click += new System.EventHandler(this.btn_B_KP6_Click);
            // 
            // btn_B_KP5
            // 
            this.btn_B_KP5.Location = new System.Drawing.Point(197, 230);
            this.btn_B_KP5.Name = "btn_B_KP5";
            this.btn_B_KP5.Size = new System.Drawing.Size(55, 23);
            this.btn_B_KP5.TabIndex = 58;
            this.btn_B_KP5.Text = "5";
            this.btn_B_KP5.UseVisualStyleBackColor = true;
            this.btn_B_KP5.Click += new System.EventHandler(this.btn_B_KP5_Click);
            // 
            // btn_B_KP4
            // 
            this.btn_B_KP4.Location = new System.Drawing.Point(136, 230);
            this.btn_B_KP4.Name = "btn_B_KP4";
            this.btn_B_KP4.Size = new System.Drawing.Size(55, 23);
            this.btn_B_KP4.TabIndex = 57;
            this.btn_B_KP4.Text = "4";
            this.btn_B_KP4.UseVisualStyleBackColor = true;
            this.btn_B_KP4.Click += new System.EventHandler(this.btn_B_KP4_Click);
            // 
            // btn_B_KP3
            // 
            this.btn_B_KP3.Location = new System.Drawing.Point(258, 201);
            this.btn_B_KP3.Name = "btn_B_KP3";
            this.btn_B_KP3.Size = new System.Drawing.Size(55, 23);
            this.btn_B_KP3.TabIndex = 56;
            this.btn_B_KP3.Text = "3";
            this.btn_B_KP3.UseVisualStyleBackColor = true;
            this.btn_B_KP3.Click += new System.EventHandler(this.btn_B_KP3_Click);
            // 
            // btn_B_KP2
            // 
            this.btn_B_KP2.Location = new System.Drawing.Point(197, 201);
            this.btn_B_KP2.Name = "btn_B_KP2";
            this.btn_B_KP2.Size = new System.Drawing.Size(55, 23);
            this.btn_B_KP2.TabIndex = 55;
            this.btn_B_KP2.Text = "2";
            this.btn_B_KP2.UseVisualStyleBackColor = true;
            this.btn_B_KP2.Click += new System.EventHandler(this.btn_B_KP2_Click);
            // 
            // btn_B_KP1
            // 
            this.btn_B_KP1.Location = new System.Drawing.Point(136, 201);
            this.btn_B_KP1.Name = "btn_B_KP1";
            this.btn_B_KP1.Size = new System.Drawing.Size(55, 23);
            this.btn_B_KP1.TabIndex = 54;
            this.btn_B_KP1.Text = "1";
            this.btn_B_KP1.UseVisualStyleBackColor = true;
            this.btn_B_KP1.Click += new System.EventHandler(this.btn_B_KP1_Click);
            // 
            // btn_B_KP0
            // 
            this.btn_B_KP0.Location = new System.Drawing.Point(197, 288);
            this.btn_B_KP0.Name = "btn_B_KP0";
            this.btn_B_KP0.Size = new System.Drawing.Size(55, 23);
            this.btn_B_KP0.TabIndex = 53;
            this.btn_B_KP0.Text = "0";
            this.btn_B_KP0.UseVisualStyleBackColor = true;
            this.btn_B_KP0.Click += new System.EventHandler(this.btn_B_KP0_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(429, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Sql Lvl";
            // 
            // trk_B_SqlLvl
            // 
            this.trk_B_SqlLvl.Location = new System.Drawing.Point(359, 237);
            this.trk_B_SqlLvl.Maximum = 30;
            this.trk_B_SqlLvl.Name = "trk_B_SqlLvl";
            this.trk_B_SqlLvl.Size = new System.Drawing.Size(212, 45);
            this.trk_B_SqlLvl.TabIndex = 50;
            this.trk_B_SqlLvl.TickFrequency = 3;
            this.trk_B_SqlLvl.Scroll += new System.EventHandler(this.trk_B_SqlLvl_Scroll);
            // 
            // lbl_B_RFGain
            // 
            this.lbl_B_RFGain.AutoSize = true;
            this.lbl_B_RFGain.Location = new System.Drawing.Point(516, 70);
            this.lbl_B_RFGain.Name = "lbl_B_RFGain";
            this.lbl_B_RFGain.Size = new System.Drawing.Size(53, 13);
            this.lbl_B_RFGain.TabIndex = 49;
            this.lbl_B_RFGain.Text = "RF Gain";
            // 
            // trk_B_RFGain
            // 
            this.trk_B_RFGain.LargeChange = 3;
            this.trk_B_RFGain.Location = new System.Drawing.Point(524, 89);
            this.trk_B_RFGain.Maximum = 27;
            this.trk_B_RFGain.Name = "trk_B_RFGain";
            this.trk_B_RFGain.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trk_B_RFGain.Size = new System.Drawing.Size(45, 121);
            this.trk_B_RFGain.SmallChange = 3;
            this.trk_B_RFGain.TabIndex = 48;
            this.trk_B_RFGain.TickFrequency = 3;
            this.trk_B_RFGain.Scroll += new System.EventHandler(this.trk_B_RFGain_Scroll);
            // 
            // lbl_B_AFGain
            // 
            this.lbl_B_AFGain.AutoSize = true;
            this.lbl_B_AFGain.Location = new System.Drawing.Point(461, 70);
            this.lbl_B_AFGain.Name = "lbl_B_AFGain";
            this.lbl_B_AFGain.Size = new System.Drawing.Size(52, 13);
            this.lbl_B_AFGain.TabIndex = 47;
            this.lbl_B_AFGain.Text = "AF Gain";
            // 
            // trk_B_AFGain
            // 
            this.trk_B_AFGain.LargeChange = 20;
            this.trk_B_AFGain.Location = new System.Drawing.Point(470, 89);
            this.trk_B_AFGain.Maximum = 255;
            this.trk_B_AFGain.Name = "trk_B_AFGain";
            this.trk_B_AFGain.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trk_B_AFGain.Size = new System.Drawing.Size(45, 121);
            this.trk_B_AFGain.SmallChange = 5;
            this.trk_B_AFGain.TabIndex = 46;
            this.trk_B_AFGain.Scroll += new System.EventHandler(this.trk_B_AFGain_Scroll);
            // 
            // lblB_Hz_Ind
            // 
            this.lblB_Hz_Ind.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblB_Hz_Ind.Location = new System.Drawing.Point(301, 151);
            this.lblB_Hz_Ind.Name = "lblB_Hz_Ind";
            this.lblB_Hz_Ind.Size = new System.Drawing.Size(66, 13);
            this.lblB_Hz_Ind.TabIndex = 45;
            this.lblB_Hz_Ind.Click += new System.EventHandler(this.lblB_Hz_Ind_Click);
            // 
            // lblB_KHz_Ind
            // 
            this.lblB_KHz_Ind.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblB_KHz_Ind.Location = new System.Drawing.Point(212, 151);
            this.lblB_KHz_Ind.Name = "lblB_KHz_Ind";
            this.lblB_KHz_Ind.Size = new System.Drawing.Size(66, 13);
            this.lblB_KHz_Ind.TabIndex = 44;
            this.lblB_KHz_Ind.Click += new System.EventHandler(this.lblB_KHz_Ind_Click);
            // 
            // lblB_MHz_Ind
            // 
            this.lblB_MHz_Ind.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblB_MHz_Ind.Location = new System.Drawing.Point(125, 151);
            this.lblB_MHz_Ind.Name = "lblB_MHz_Ind";
            this.lblB_MHz_Ind.Size = new System.Drawing.Size(66, 13);
            this.lblB_MHz_Ind.TabIndex = 43;
            this.lblB_MHz_Ind.Click += new System.EventHandler(this.lblB_MHz_Ind_Click);
            // 
            // lblB_GHz_Ind
            // 
            this.lblB_GHz_Ind.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblB_GHz_Ind.Location = new System.Drawing.Point(35, 151);
            this.lblB_GHz_Ind.Name = "lblB_GHz_Ind";
            this.lblB_GHz_Ind.Size = new System.Drawing.Size(66, 13);
            this.lblB_GHz_Ind.TabIndex = 42;
            this.lblB_GHz_Ind.Click += new System.EventHandler(this.lblB_GHz_Ind_Click);
            // 
            // btnB_Hz
            // 
            this.btnB_Hz.Location = new System.Drawing.Point(301, 125);
            this.btnB_Hz.Name = "btnB_Hz";
            this.btnB_Hz.Size = new System.Drawing.Size(66, 23);
            this.btnB_Hz.TabIndex = 41;
            this.btnB_Hz.Text = "H";
            this.btnB_Hz.UseVisualStyleBackColor = true;
            this.btnB_Hz.Click += new System.EventHandler(this.btnB_Hz_Click);
            // 
            // btnB_KHz
            // 
            this.btnB_KHz.Location = new System.Drawing.Point(212, 125);
            this.btnB_KHz.Name = "btnB_KHz";
            this.btnB_KHz.Size = new System.Drawing.Size(66, 23);
            this.btnB_KHz.TabIndex = 40;
            this.btnB_KHz.Text = "K";
            this.btnB_KHz.UseVisualStyleBackColor = true;
            this.btnB_KHz.Click += new System.EventHandler(this.btnB_KHz_Click);
            // 
            // btnB_GHz
            // 
            this.btnB_GHz.Location = new System.Drawing.Point(35, 125);
            this.btnB_GHz.Name = "btnB_GHz";
            this.btnB_GHz.Size = new System.Drawing.Size(66, 23);
            this.btnB_GHz.TabIndex = 39;
            this.btnB_GHz.Text = "G";
            this.btnB_GHz.UseVisualStyleBackColor = true;
            this.btnB_GHz.Click += new System.EventHandler(this.btnB_GHz_Click);
            // 
            // btnB_MHz
            // 
            this.btnB_MHz.Location = new System.Drawing.Point(125, 125);
            this.btnB_MHz.Name = "btnB_MHz";
            this.btnB_MHz.Size = new System.Drawing.Size(66, 23);
            this.btnB_MHz.TabIndex = 38;
            this.btnB_MHz.Text = "M";
            this.btnB_MHz.UseVisualStyleBackColor = true;
            this.btnB_MHz.Click += new System.EventHandler(this.btnB_MHz_Click);
            // 
            // txtB_FreqEntry
            // 
            this.txtB_FreqEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtB_FreqEntry.Location = new System.Drawing.Point(133, 170);
            this.txtB_FreqEntry.Name = "txtB_FreqEntry";
            this.txtB_FreqEntry.Size = new System.Drawing.Size(180, 26);
            this.txtB_FreqEntry.TabIndex = 37;
            this.txtB_FreqEntry.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtB_FreqEntry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtB_FreqEntry_KeyPress);
            // 
            // lblBFreq
            // 
            this.lblBFreq.Font = new System.Drawing.Font("Lucida Console", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBFreq.Location = new System.Drawing.Point(26, 91);
            this.lblBFreq.Name = "lblBFreq";
            this.lblBFreq.Size = new System.Drawing.Size(350, 31);
            this.lblBFreq.TabIndex = 36;
            this.lblBFreq.Text = "000 000 000 000";
            this.lblBFreq.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblBFreq.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblBFreq_MouseClick);
            // 
            // chkPUW
            // 
            this.chkPUW.AutoSize = true;
            this.chkPUW.Location = new System.Drawing.Point(600, 385);
            this.chkPUW.Name = "chkPUW";
            this.chkPUW.Size = new System.Drawing.Size(94, 17);
            this.chkPUW.TabIndex = 5;
            this.chkPUW.Text = "PUW Enabled";
            this.chkPUW.UseVisualStyleBackColor = true;
            this.chkPUW.CheckedChanged += new System.EventHandler(this.chkPUW_CheckedChanged);
            // 
            // btnPowerOn
            // 
            this.btnPowerOn.Enabled = false;
            this.btnPowerOn.Location = new System.Drawing.Point(786, 0);
            this.btnPowerOn.Name = "btnPowerOn";
            this.btnPowerOn.Size = new System.Drawing.Size(60, 23);
            this.btnPowerOn.TabIndex = 9;
            this.btnPowerOn.Text = "PowerOn";
            this.btnPowerOn.UseVisualStyleBackColor = true;
            this.btnPowerOn.Click += new System.EventHandler(this.btnPower_Click);
            // 
            // btnPowerOff
            // 
            this.btnPowerOff.Enabled = false;
            this.btnPowerOff.Location = new System.Drawing.Point(844, 0);
            this.btnPowerOff.Name = "btnPowerOff";
            this.btnPowerOff.Size = new System.Drawing.Size(59, 23);
            this.btnPowerOff.TabIndex = 10;
            this.btnPowerOff.Text = "PowerOff";
            this.btnPowerOff.UseVisualStyleBackColor = true;
            this.btnPowerOff.Click += new System.EventHandler(this.button1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mtsbConnect,
            this.mtsl_COMPort,
            this.mtscb_COMPort,
            this.mtsl_BaudRate,
            this.mtscb_BaudRate,
            this.mtsl_Layout,
            this.mtsdb_Layout,
            this.mtslbl_Switching,
            this.mtsdb_SwitchingType,
            this.mtsl_Attenuator,
            this.mtsdb_Attenuator,
            this.mtsdb_Data});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1685, 25);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mtsbConnect
            // 
            this.mtsbConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mtsbConnect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtsbConnect.Image = ((System.Drawing.Image)(resources.GetObject("mtsbConnect.Image")));
            this.mtsbConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mtsbConnect.Name = "mtsbConnect";
            this.mtsbConnect.Size = new System.Drawing.Size(57, 22);
            this.mtsbConnect.Text = "Connect";
            this.mtsbConnect.Click += new System.EventHandler(this.mtsbConnect_Click);
            // 
            // mtsl_COMPort
            // 
            this.mtsl_COMPort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtsl_COMPort.Name = "mtsl_COMPort";
            this.mtsl_COMPort.Size = new System.Drawing.Size(34, 22);
            this.mtsl_COMPort.Text = "Port:";
            // 
            // mtscb_COMPort
            // 
            this.mtscb_COMPort.AutoSize = false;
            this.mtscb_COMPort.Name = "mtscb_COMPort";
            this.mtscb_COMPort.Size = new System.Drawing.Size(90, 25);
            this.mtscb_COMPort.Click += new System.EventHandler(this.mtscb_COMPort_Click);
            // 
            // mtsl_BaudRate
            // 
            this.mtsl_BaudRate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtsl_BaudRate.Name = "mtsl_BaudRate";
            this.mtsl_BaudRate.Size = new System.Drawing.Size(38, 22);
            this.mtsl_BaudRate.Text = "Baud:";
            // 
            // mtscb_BaudRate
            // 
            this.mtscb_BaudRate.AutoSize = false;
            this.mtscb_BaudRate.Name = "mtscb_BaudRate";
            this.mtscb_BaudRate.Size = new System.Drawing.Size(90, 25);
            this.mtscb_BaudRate.ToolTipText = "Use 9600 For Bluetooth";
            // 
            // mtsl_Layout
            // 
            this.mtsl_Layout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtsl_Layout.Name = "mtsl_Layout";
            this.mtsl_Layout.Size = new System.Drawing.Size(47, 22);
            this.mtsl_Layout.Text = "Layout:";
            // 
            // mtsdb_Layout
            // 
            this.mtsdb_Layout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mtsdb_Layout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mtsdb_Layout_SingleA,
            this.mtsdb_Layout_SingleB,
            this.mtsdb_Layout_Dual});
            this.mtsdb_Layout.Image = ((System.Drawing.Image)(resources.GetObject("mtsdb_Layout.Image")));
            this.mtsdb_Layout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mtsdb_Layout.Name = "mtsdb_Layout";
            this.mtsdb_Layout.Size = new System.Drawing.Size(44, 22);
            this.mtsdb_Layout.Text = "Dual";
            // 
            // mtsdb_Layout_SingleA
            // 
            this.mtsdb_Layout_SingleA.Name = "mtsdb_Layout_SingleA";
            this.mtsdb_Layout_SingleA.Size = new System.Drawing.Size(180, 22);
            this.mtsdb_Layout_SingleA.Text = "Single A";
            this.mtsdb_Layout_SingleA.Click += new System.EventHandler(this.mtsdb_Layout_SingleA_Click);
            // 
            // mtsdb_Layout_SingleB
            // 
            this.mtsdb_Layout_SingleB.Name = "mtsdb_Layout_SingleB";
            this.mtsdb_Layout_SingleB.Size = new System.Drawing.Size(180, 22);
            this.mtsdb_Layout_SingleB.Text = "Single B";
            this.mtsdb_Layout_SingleB.Click += new System.EventHandler(this.mtsdb_Layout_SingleB_Click);
            // 
            // mtsdb_Layout_Dual
            // 
            this.mtsdb_Layout_Dual.Name = "mtsdb_Layout_Dual";
            this.mtsdb_Layout_Dual.Size = new System.Drawing.Size(180, 22);
            this.mtsdb_Layout_Dual.Text = "Dual";
            this.mtsdb_Layout_Dual.Click += new System.EventHandler(this.mtsdb_Layout_Dual_Click);
            // 
            // mtsdb_SwitchingType
            // 
            this.mtsdb_SwitchingType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mtsdb_SwitchingType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mtsdb_SwitchingType_MouseOver,
            this.mtsdb_SwitchingType_Manual});
            this.mtsdb_SwitchingType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtsdb_SwitchingType.Image = ((System.Drawing.Image)(resources.GetObject("mtsdb_SwitchingType.Image")));
            this.mtsdb_SwitchingType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mtsdb_SwitchingType.Name = "mtsdb_SwitchingType";
            this.mtsdb_SwitchingType.Size = new System.Drawing.Size(91, 22);
            this.mtsdb_SwitchingType.Text = "Mouse Hover";
            // 
            // mtsdb_SwitchingType_MouseOver
            // 
            this.mtsdb_SwitchingType_MouseOver.Name = "mtsdb_SwitchingType_MouseOver";
            this.mtsdb_SwitchingType_MouseOver.Size = new System.Drawing.Size(180, 22);
            this.mtsdb_SwitchingType_MouseOver.Text = "Mouse Hover";
            this.mtsdb_SwitchingType_MouseOver.Click += new System.EventHandler(this.mtsdb_SwitchingType_MouseOver_Click);
            // 
            // mtsdb_SwitchingType_Manual
            // 
            this.mtsdb_SwitchingType_Manual.Name = "mtsdb_SwitchingType_Manual";
            this.mtsdb_SwitchingType_Manual.Size = new System.Drawing.Size(180, 22);
            this.mtsdb_SwitchingType_Manual.Text = "Manual";
            this.mtsdb_SwitchingType_Manual.Click += new System.EventHandler(this.mtsdb_SwitchingType_Manual_Click);
            // 
            // grp_A_FM
            // 
            this.grp_A_FM.Controls.Add(this.lbl_A_FM_SQLFreqOrCode);
            this.grp_A_FM.Controls.Add(this.opn_A_FM_SqlMode_DTCS_R);
            this.grp_A_FM.Controls.Add(this.opn_A_FM_SqlMode_DTCS);
            this.grp_A_FM.Controls.Add(this.opn_A_FM_SqlMode_TSQL_R);
            this.grp_A_FM.Controls.Add(this.opn_A_FM_SqlMode_TSQL);
            this.grp_A_FM.Controls.Add(this.opn_A_FM_SqlMode_None);
            this.grp_A_FM.Controls.Add(this.chk_A_FM_VSC);
            this.grp_A_FM.Controls.Add(this.cmb_A_FM_DTCSCode);
            this.grp_A_FM.Controls.Add(this.cmb_A_FM_TSQLFreq);
            this.grp_A_FM.Controls.Add(this.lbl_A_FM_SQLTYPE);
            this.grp_A_FM.Controls.Add(this.chk_A_FM_AFC);
            this.grp_A_FM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_A_FM.Location = new System.Drawing.Point(627, 29);
            this.grp_A_FM.Name = "grp_A_FM";
            this.grp_A_FM.Size = new System.Drawing.Size(300, 350);
            this.grp_A_FM.TabIndex = 12;
            this.grp_A_FM.TabStop = false;
            this.grp_A_FM.Text = "FM";
            // 
            // lbl_A_FM_SQLFreqOrCode
            // 
            this.lbl_A_FM_SQLFreqOrCode.AutoSize = true;
            this.lbl_A_FM_SQLFreqOrCode.Location = new System.Drawing.Point(18, 137);
            this.lbl_A_FM_SQLFreqOrCode.Name = "lbl_A_FM_SQLFreqOrCode";
            this.lbl_A_FM_SQLFreqOrCode.Size = new System.Drawing.Size(41, 13);
            this.lbl_A_FM_SQLFreqOrCode.TabIndex = 11;
            this.lbl_A_FM_SQLFreqOrCode.Text = "label1";
            // 
            // opn_A_FM_SqlMode_DTCS_R
            // 
            this.opn_A_FM_SqlMode_DTCS_R.AutoCheck = false;
            this.opn_A_FM_SqlMode_DTCS_R.AutoSize = true;
            this.opn_A_FM_SqlMode_DTCS_R.Location = new System.Drawing.Point(149, 104);
            this.opn_A_FM_SqlMode_DTCS_R.Name = "opn_A_FM_SqlMode_DTCS_R";
            this.opn_A_FM_SqlMode_DTCS_R.Size = new System.Drawing.Size(71, 17);
            this.opn_A_FM_SqlMode_DTCS_R.TabIndex = 10;
            this.opn_A_FM_SqlMode_DTCS_R.TabStop = true;
            this.opn_A_FM_SqlMode_DTCS_R.Text = "DTCS-R";
            this.opn_A_FM_SqlMode_DTCS_R.UseVisualStyleBackColor = true;
            this.opn_A_FM_SqlMode_DTCS_R.Click += new System.EventHandler(this.opn_A_FM_SqlMode_DTCS_R_Click);
            // 
            // opn_A_FM_SqlMode_DTCS
            // 
            this.opn_A_FM_SqlMode_DTCS.AutoCheck = false;
            this.opn_A_FM_SqlMode_DTCS.AutoSize = true;
            this.opn_A_FM_SqlMode_DTCS.Location = new System.Drawing.Point(149, 81);
            this.opn_A_FM_SqlMode_DTCS.Name = "opn_A_FM_SqlMode_DTCS";
            this.opn_A_FM_SqlMode_DTCS.Size = new System.Drawing.Size(58, 17);
            this.opn_A_FM_SqlMode_DTCS.TabIndex = 9;
            this.opn_A_FM_SqlMode_DTCS.TabStop = true;
            this.opn_A_FM_SqlMode_DTCS.Text = "DTCS";
            this.opn_A_FM_SqlMode_DTCS.UseVisualStyleBackColor = true;
            this.opn_A_FM_SqlMode_DTCS.Click += new System.EventHandler(this.opn_A_FM_SqlMode_DTCS_Click);
            // 
            // opn_A_FM_SqlMode_TSQL_R
            // 
            this.opn_A_FM_SqlMode_TSQL_R.AutoCheck = false;
            this.opn_A_FM_SqlMode_TSQL_R.AutoSize = true;
            this.opn_A_FM_SqlMode_TSQL_R.Location = new System.Drawing.Point(69, 103);
            this.opn_A_FM_SqlMode_TSQL_R.Name = "opn_A_FM_SqlMode_TSQL_R";
            this.opn_A_FM_SqlMode_TSQL_R.Size = new System.Drawing.Size(70, 17);
            this.opn_A_FM_SqlMode_TSQL_R.TabIndex = 8;
            this.opn_A_FM_SqlMode_TSQL_R.TabStop = true;
            this.opn_A_FM_SqlMode_TSQL_R.Text = "TSQL-R";
            this.opn_A_FM_SqlMode_TSQL_R.UseVisualStyleBackColor = true;
            this.opn_A_FM_SqlMode_TSQL_R.Click += new System.EventHandler(this.opn_A_FM_SqlMode_TSQL_R_Click);
            // 
            // opn_A_FM_SqlMode_TSQL
            // 
            this.opn_A_FM_SqlMode_TSQL.AutoCheck = false;
            this.opn_A_FM_SqlMode_TSQL.AutoSize = true;
            this.opn_A_FM_SqlMode_TSQL.Location = new System.Drawing.Point(69, 81);
            this.opn_A_FM_SqlMode_TSQL.Name = "opn_A_FM_SqlMode_TSQL";
            this.opn_A_FM_SqlMode_TSQL.Size = new System.Drawing.Size(57, 17);
            this.opn_A_FM_SqlMode_TSQL.TabIndex = 7;
            this.opn_A_FM_SqlMode_TSQL.TabStop = true;
            this.opn_A_FM_SqlMode_TSQL.Text = "TSQL";
            this.opn_A_FM_SqlMode_TSQL.UseVisualStyleBackColor = true;
            this.opn_A_FM_SqlMode_TSQL.Click += new System.EventHandler(this.opn_A_FM_SqlMode_TSQL_Click);
            // 
            // opn_A_FM_SqlMode_None
            // 
            this.opn_A_FM_SqlMode_None.AutoCheck = false;
            this.opn_A_FM_SqlMode_None.AutoSize = true;
            this.opn_A_FM_SqlMode_None.Location = new System.Drawing.Point(21, 81);
            this.opn_A_FM_SqlMode_None.Name = "opn_A_FM_SqlMode_None";
            this.opn_A_FM_SqlMode_None.Size = new System.Drawing.Size(42, 17);
            this.opn_A_FM_SqlMode_None.TabIndex = 6;
            this.opn_A_FM_SqlMode_None.TabStop = true;
            this.opn_A_FM_SqlMode_None.Text = "Off";
            this.opn_A_FM_SqlMode_None.UseVisualStyleBackColor = true;
            this.opn_A_FM_SqlMode_None.Click += new System.EventHandler(this.opn_A_FM_SqlMode_None_Click);
            // 
            // chk_A_FM_VSC
            // 
            this.chk_A_FM_VSC.AutoCheck = false;
            this.chk_A_FM_VSC.AutoSize = true;
            this.chk_A_FM_VSC.Location = new System.Drawing.Point(73, 34);
            this.chk_A_FM_VSC.Name = "chk_A_FM_VSC";
            this.chk_A_FM_VSC.Size = new System.Drawing.Size(50, 17);
            this.chk_A_FM_VSC.TabIndex = 5;
            this.chk_A_FM_VSC.Text = "VSC";
            this.chk_A_FM_VSC.UseVisualStyleBackColor = true;
            this.chk_A_FM_VSC.Click += new System.EventHandler(this.chk_A_FM_VSC_Click);
            // 
            // cmb_A_FM_DTCSCode
            // 
            this.cmb_A_FM_DTCSCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_A_FM_DTCSCode.FormattingEnabled = true;
            this.cmb_A_FM_DTCSCode.Items.AddRange(new object[] {
            "023",
            "025",
            "026",
            "031",
            "032",
            "036",
            "043",
            "047",
            "051",
            "053",
            "054",
            "065",
            "071",
            "072",
            "073",
            "074",
            "114",
            "115",
            "116",
            "122",
            "125",
            "131",
            "132",
            "134",
            "143",
            "145",
            "152",
            "155",
            "156",
            "162",
            "165",
            "172",
            "174",
            "205",
            "212",
            "223",
            "225",
            "226",
            "243",
            "244",
            "245",
            "246",
            "251",
            "252",
            "255",
            "261",
            "263",
            "265",
            "266",
            "271",
            "274",
            "306",
            "311",
            "315",
            "325",
            "331",
            "332",
            "343",
            "346",
            "351",
            "356",
            "364",
            "365",
            "371",
            "411",
            "412",
            "413",
            "423",
            "431",
            "432",
            "445",
            "446",
            "452",
            "454",
            "455",
            "462",
            "464",
            "465",
            "466",
            "503",
            "506",
            "516",
            "523",
            "526",
            "532",
            "546",
            "565",
            "606",
            "612",
            "624",
            "627",
            "631",
            "632",
            "654",
            "662",
            "664",
            "703",
            "712",
            "723",
            "731",
            "732",
            "734",
            "743",
            "754"});
            this.cmb_A_FM_DTCSCode.Location = new System.Drawing.Point(96, 134);
            this.cmb_A_FM_DTCSCode.Name = "cmb_A_FM_DTCSCode";
            this.cmb_A_FM_DTCSCode.Size = new System.Drawing.Size(68, 21);
            this.cmb_A_FM_DTCSCode.TabIndex = 4;
            this.cmb_A_FM_DTCSCode.SelectionChangeCommitted += new System.EventHandler(this.cmb_A_FM_DTCSCode_SelectionChangeCommitted);
            // 
            // cmb_A_FM_TSQLFreq
            // 
            this.cmb_A_FM_TSQLFreq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_A_FM_TSQLFreq.FormattingEnabled = true;
            this.cmb_A_FM_TSQLFreq.Items.AddRange(new object[] {
            "67.0",
            "69.3",
            "71.9",
            "74.4",
            "77.0",
            "79.7",
            "82.5",
            "85.4",
            "88.5",
            "91.5",
            "94.8",
            "97.4",
            "100.0",
            "103.5",
            "107.2",
            "110.9",
            "114.8",
            "118.8",
            "123.0",
            "127.3",
            "131.8",
            "136.5",
            "141.3",
            "146.2",
            "151.4",
            "156.7",
            "159.8",
            "162.2",
            "165.5",
            "167.9",
            "171.3",
            "173.8",
            "177.3",
            "179.9",
            "183.5",
            "186.2",
            "189.9",
            "192.8",
            "196.6",
            "199.5",
            "203.5",
            "206.5",
            "210.7",
            "218.1",
            "225.7",
            "229.1",
            "233.6",
            "241.8",
            "250.3",
            "254.1"});
            this.cmb_A_FM_TSQLFreq.Location = new System.Drawing.Point(96, 134);
            this.cmb_A_FM_TSQLFreq.Name = "cmb_A_FM_TSQLFreq";
            this.cmb_A_FM_TSQLFreq.Size = new System.Drawing.Size(68, 21);
            this.cmb_A_FM_TSQLFreq.TabIndex = 3;
            this.cmb_A_FM_TSQLFreq.SelectionChangeCommitted += new System.EventHandler(this.cmb_A_FM_TSQLFreq_SelectionChangeCommitted);
            // 
            // lbl_A_FM_SQLTYPE
            // 
            this.lbl_A_FM_SQLTYPE.AutoSize = true;
            this.lbl_A_FM_SQLTYPE.Location = new System.Drawing.Point(18, 62);
            this.lbl_A_FM_SQLTYPE.Name = "lbl_A_FM_SQLTYPE";
            this.lbl_A_FM_SQLTYPE.Size = new System.Drawing.Size(79, 13);
            this.lbl_A_FM_SQLTYPE.TabIndex = 2;
            this.lbl_A_FM_SQLTYPE.Text = "Adv Squelch";
            // 
            // chk_A_FM_AFC
            // 
            this.chk_A_FM_AFC.AutoCheck = false;
            this.chk_A_FM_AFC.AutoSize = true;
            this.chk_A_FM_AFC.Location = new System.Drawing.Point(18, 34);
            this.chk_A_FM_AFC.Name = "chk_A_FM_AFC";
            this.chk_A_FM_AFC.Size = new System.Drawing.Size(49, 17);
            this.chk_A_FM_AFC.TabIndex = 0;
            this.chk_A_FM_AFC.Text = "AFC";
            this.chk_A_FM_AFC.UseVisualStyleBackColor = true;
            this.chk_A_FM_AFC.Click += new System.EventHandler(this.chk_A_FM_AFC_Click);
            // 
            // grp_A_P25
            // 
            this.grp_A_P25.Controls.Add(this.txt_A_P25_Dest_DBName);
            this.grp_A_P25.Controls.Add(this.txt_A_P25_Src_DBName);
            this.grp_A_P25.Controls.Add(this.txt_A_P25_CallType);
            this.grp_A_P25.Controls.Add(this.txt_A_P25_NAC);
            this.grp_A_P25.Controls.Add(this.txt_A_P25_Dest);
            this.grp_A_P25.Controls.Add(this.txt_A_P25_Src);
            this.grp_A_P25.Controls.Add(this.lbl_A_P25_CallType);
            this.grp_A_P25.Controls.Add(this.lbl_A_P25_Enc);
            this.grp_A_P25.Controls.Add(this.lbl_A_P25_EMERG);
            this.grp_A_P25.Controls.Add(this.lbl_A_P25_NAC);
            this.grp_A_P25.Controls.Add(this.lbl_A_P25_Dest);
            this.grp_A_P25.Controls.Add(this.lbl_A_P25_Src);
            this.grp_A_P25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_A_P25.Location = new System.Drawing.Point(986, 29);
            this.grp_A_P25.Name = "grp_A_P25";
            this.grp_A_P25.Size = new System.Drawing.Size(300, 350);
            this.grp_A_P25.TabIndex = 13;
            this.grp_A_P25.TabStop = false;
            this.grp_A_P25.Text = "P25";
            // 
            // txt_A_P25_Dest_DBName
            // 
            this.txt_A_P25_Dest_DBName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_A_P25_Dest_DBName.Location = new System.Drawing.Point(6, 192);
            this.txt_A_P25_Dest_DBName.Name = "txt_A_P25_Dest_DBName";
            this.txt_A_P25_Dest_DBName.ReadOnly = true;
            this.txt_A_P25_Dest_DBName.Size = new System.Drawing.Size(288, 24);
            this.txt_A_P25_Dest_DBName.TabIndex = 11;
            // 
            // txt_A_P25_Src_DBName
            // 
            this.txt_A_P25_Src_DBName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_A_P25_Src_DBName.Location = new System.Drawing.Point(6, 100);
            this.txt_A_P25_Src_DBName.Name = "txt_A_P25_Src_DBName";
            this.txt_A_P25_Src_DBName.ReadOnly = true;
            this.txt_A_P25_Src_DBName.Size = new System.Drawing.Size(288, 24);
            this.txt_A_P25_Src_DBName.TabIndex = 10;
            // 
            // txt_A_P25_CallType
            // 
            this.txt_A_P25_CallType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_A_P25_CallType.Location = new System.Drawing.Point(123, 249);
            this.txt_A_P25_CallType.Name = "txt_A_P25_CallType";
            this.txt_A_P25_CallType.ReadOnly = true;
            this.txt_A_P25_CallType.Size = new System.Drawing.Size(100, 26);
            this.txt_A_P25_CallType.TabIndex = 9;
            // 
            // txt_A_P25_NAC
            // 
            this.txt_A_P25_NAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_A_P25_NAC.Location = new System.Drawing.Point(9, 249);
            this.txt_A_P25_NAC.Name = "txt_A_P25_NAC";
            this.txt_A_P25_NAC.ReadOnly = true;
            this.txt_A_P25_NAC.Size = new System.Drawing.Size(94, 26);
            this.txt_A_P25_NAC.TabIndex = 8;
            // 
            // txt_A_P25_Dest
            // 
            this.txt_A_P25_Dest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_A_P25_Dest.Location = new System.Drawing.Point(9, 160);
            this.txt_A_P25_Dest.Name = "txt_A_P25_Dest";
            this.txt_A_P25_Dest.ReadOnly = true;
            this.txt_A_P25_Dest.Size = new System.Drawing.Size(132, 26);
            this.txt_A_P25_Dest.TabIndex = 7;
            // 
            // txt_A_P25_Src
            // 
            this.txt_A_P25_Src.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_A_P25_Src.Location = new System.Drawing.Point(6, 68);
            this.txt_A_P25_Src.Name = "txt_A_P25_Src";
            this.txt_A_P25_Src.ReadOnly = true;
            this.txt_A_P25_Src.Size = new System.Drawing.Size(135, 26);
            this.txt_A_P25_Src.TabIndex = 6;
            // 
            // lbl_A_P25_CallType
            // 
            this.lbl_A_P25_CallType.AutoSize = true;
            this.lbl_A_P25_CallType.Location = new System.Drawing.Point(120, 233);
            this.lbl_A_P25_CallType.Name = "lbl_A_P25_CallType";
            this.lbl_A_P25_CallType.Size = new System.Drawing.Size(64, 13);
            this.lbl_A_P25_CallType.TabIndex = 5;
            this.lbl_A_P25_CallType.Text = "Call Type:";
            // 
            // lbl_A_P25_Enc
            // 
            this.lbl_A_P25_Enc.AutoSize = true;
            this.lbl_A_P25_Enc.ForeColor = System.Drawing.Color.Blue;
            this.lbl_A_P25_Enc.Location = new System.Drawing.Point(129, 20);
            this.lbl_A_P25_Enc.Name = "lbl_A_P25_Enc";
            this.lbl_A_P25_Enc.Size = new System.Drawing.Size(64, 13);
            this.lbl_A_P25_Enc.TabIndex = 4;
            this.lbl_A_P25_Enc.Text = "Encrypted";
            // 
            // lbl_A_P25_EMERG
            // 
            this.lbl_A_P25_EMERG.AutoSize = true;
            this.lbl_A_P25_EMERG.ForeColor = System.Drawing.Color.Red;
            this.lbl_A_P25_EMERG.Location = new System.Drawing.Point(18, 20);
            this.lbl_A_P25_EMERG.Name = "lbl_A_P25_EMERG";
            this.lbl_A_P25_EMERG.Size = new System.Drawing.Size(51, 13);
            this.lbl_A_P25_EMERG.TabIndex = 3;
            this.lbl_A_P25_EMERG.Text = "EMERG";
            // 
            // lbl_A_P25_NAC
            // 
            this.lbl_A_P25_NAC.AutoSize = true;
            this.lbl_A_P25_NAC.Location = new System.Drawing.Point(6, 233);
            this.lbl_A_P25_NAC.Name = "lbl_A_P25_NAC";
            this.lbl_A_P25_NAC.Size = new System.Drawing.Size(36, 13);
            this.lbl_A_P25_NAC.TabIndex = 2;
            this.lbl_A_P25_NAC.Text = "NAC:";
            // 
            // lbl_A_P25_Dest
            // 
            this.lbl_A_P25_Dest.AutoSize = true;
            this.lbl_A_P25_Dest.Location = new System.Drawing.Point(6, 141);
            this.lbl_A_P25_Dest.Name = "lbl_A_P25_Dest";
            this.lbl_A_P25_Dest.Size = new System.Drawing.Size(46, 13);
            this.lbl_A_P25_Dest.TabIndex = 1;
            this.lbl_A_P25_Dest.Text = "Called:";
            // 
            // lbl_A_P25_Src
            // 
            this.lbl_A_P25_Src.AutoSize = true;
            this.lbl_A_P25_Src.Location = new System.Drawing.Point(6, 49);
            this.lbl_A_P25_Src.Name = "lbl_A_P25_Src";
            this.lbl_A_P25_Src.Size = new System.Drawing.Size(43, 13);
            this.lbl_A_P25_Src.TabIndex = 0;
            this.lbl_A_P25_Src.Text = "Caller:";
            // 
            // grp_A_AM
            // 
            this.grp_A_AM.Controls.Add(this.chk_A_AM_ANL);
            this.grp_A_AM.Controls.Add(this.chk_A_AM_VSC);
            this.grp_A_AM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_A_AM.Location = new System.Drawing.Point(1293, 32);
            this.grp_A_AM.Name = "grp_A_AM";
            this.grp_A_AM.Size = new System.Drawing.Size(300, 350);
            this.grp_A_AM.TabIndex = 14;
            this.grp_A_AM.TabStop = false;
            this.grp_A_AM.Text = "AM";
            // 
            // chk_A_AM_ANL
            // 
            this.chk_A_AM_ANL.AutoCheck = false;
            this.chk_A_AM_ANL.AutoSize = true;
            this.chk_A_AM_ANL.Location = new System.Drawing.Point(16, 31);
            this.chk_A_AM_ANL.Name = "chk_A_AM_ANL";
            this.chk_A_AM_ANL.Size = new System.Drawing.Size(50, 17);
            this.chk_A_AM_ANL.TabIndex = 7;
            this.chk_A_AM_ANL.Text = "ANL";
            this.chk_A_AM_ANL.UseVisualStyleBackColor = true;
            this.chk_A_AM_ANL.Click += new System.EventHandler(this.chk_A_AM_ANL_Click);
            // 
            // chk_A_AM_VSC
            // 
            this.chk_A_AM_VSC.AutoCheck = false;
            this.chk_A_AM_VSC.AutoSize = true;
            this.chk_A_AM_VSC.Location = new System.Drawing.Point(84, 31);
            this.chk_A_AM_VSC.Name = "chk_A_AM_VSC";
            this.chk_A_AM_VSC.Size = new System.Drawing.Size(50, 17);
            this.chk_A_AM_VSC.TabIndex = 6;
            this.chk_A_AM_VSC.Text = "VSC";
            this.chk_A_AM_VSC.UseVisualStyleBackColor = true;
            this.chk_A_AM_VSC.Click += new System.EventHandler(this.chk_A_AM_VSC_Click);
            // 
            // grp_A_SSB
            // 
            this.grp_A_SSB.Controls.Add(this.chk_A_SSB_NB);
            this.grp_A_SSB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_A_SSB.Location = new System.Drawing.Point(1528, 32);
            this.grp_A_SSB.Name = "grp_A_SSB";
            this.grp_A_SSB.Size = new System.Drawing.Size(300, 350);
            this.grp_A_SSB.TabIndex = 15;
            this.grp_A_SSB.TabStop = false;
            this.grp_A_SSB.Text = "SSB / CW";
            // 
            // chk_A_SSB_NB
            // 
            this.chk_A_SSB_NB.AutoCheck = false;
            this.chk_A_SSB_NB.AutoSize = true;
            this.chk_A_SSB_NB.Location = new System.Drawing.Point(6, 31);
            this.chk_A_SSB_NB.Name = "chk_A_SSB_NB";
            this.chk_A_SSB_NB.Size = new System.Drawing.Size(43, 17);
            this.chk_A_SSB_NB.TabIndex = 7;
            this.chk_A_SSB_NB.Text = "NB";
            this.chk_A_SSB_NB.UseVisualStyleBackColor = true;
            this.chk_A_SSB_NB.Click += new System.EventHandler(this.chk_A_SSB_NB_Click);
            // 
            // grp_B_FM
            // 
            this.grp_B_FM.Controls.Add(this.lbl_B_FM_SQLFreqOrCode);
            this.grp_B_FM.Controls.Add(this.opn_B_FM_SqlMode_DTCS_R);
            this.grp_B_FM.Controls.Add(this.opn_B_FM_SqlMode_DTCS);
            this.grp_B_FM.Controls.Add(this.opn_B_FM_SqlMode_TSQL_R);
            this.grp_B_FM.Controls.Add(this.opn_B_FM_SqlMode_TSQL);
            this.grp_B_FM.Controls.Add(this.opn_B_FM_SqlMode_None);
            this.grp_B_FM.Controls.Add(this.chk_B_FM_VSC);
            this.grp_B_FM.Controls.Add(this.cmb_B_FM_DTCSCode);
            this.grp_B_FM.Controls.Add(this.cmb_B_FM_TSQLFreq);
            this.grp_B_FM.Controls.Add(this.lbl_B_FM_SQLTYPE);
            this.grp_B_FM.Controls.Add(this.chk_B_FM_AFC);
            this.grp_B_FM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_B_FM.Location = new System.Drawing.Point(627, 424);
            this.grp_B_FM.Name = "grp_B_FM";
            this.grp_B_FM.Size = new System.Drawing.Size(300, 350);
            this.grp_B_FM.TabIndex = 16;
            this.grp_B_FM.TabStop = false;
            this.grp_B_FM.Text = "FM";
            // 
            // lbl_B_FM_SQLFreqOrCode
            // 
            this.lbl_B_FM_SQLFreqOrCode.AutoSize = true;
            this.lbl_B_FM_SQLFreqOrCode.Location = new System.Drawing.Point(18, 137);
            this.lbl_B_FM_SQLFreqOrCode.Name = "lbl_B_FM_SQLFreqOrCode";
            this.lbl_B_FM_SQLFreqOrCode.Size = new System.Drawing.Size(41, 13);
            this.lbl_B_FM_SQLFreqOrCode.TabIndex = 11;
            this.lbl_B_FM_SQLFreqOrCode.Text = "label1";
            // 
            // opn_B_FM_SqlMode_DTCS_R
            // 
            this.opn_B_FM_SqlMode_DTCS_R.AutoCheck = false;
            this.opn_B_FM_SqlMode_DTCS_R.AutoSize = true;
            this.opn_B_FM_SqlMode_DTCS_R.Location = new System.Drawing.Point(149, 104);
            this.opn_B_FM_SqlMode_DTCS_R.Name = "opn_B_FM_SqlMode_DTCS_R";
            this.opn_B_FM_SqlMode_DTCS_R.Size = new System.Drawing.Size(71, 17);
            this.opn_B_FM_SqlMode_DTCS_R.TabIndex = 10;
            this.opn_B_FM_SqlMode_DTCS_R.TabStop = true;
            this.opn_B_FM_SqlMode_DTCS_R.Text = "DTCS-R";
            this.opn_B_FM_SqlMode_DTCS_R.UseVisualStyleBackColor = true;
            this.opn_B_FM_SqlMode_DTCS_R.Click += new System.EventHandler(this.opn_B_FM_SqlMode_DTCS_R_Click);
            // 
            // opn_B_FM_SqlMode_DTCS
            // 
            this.opn_B_FM_SqlMode_DTCS.AutoCheck = false;
            this.opn_B_FM_SqlMode_DTCS.AutoSize = true;
            this.opn_B_FM_SqlMode_DTCS.Location = new System.Drawing.Point(149, 81);
            this.opn_B_FM_SqlMode_DTCS.Name = "opn_B_FM_SqlMode_DTCS";
            this.opn_B_FM_SqlMode_DTCS.Size = new System.Drawing.Size(58, 17);
            this.opn_B_FM_SqlMode_DTCS.TabIndex = 9;
            this.opn_B_FM_SqlMode_DTCS.TabStop = true;
            this.opn_B_FM_SqlMode_DTCS.Text = "DTCS";
            this.opn_B_FM_SqlMode_DTCS.UseVisualStyleBackColor = true;
            this.opn_B_FM_SqlMode_DTCS.Click += new System.EventHandler(this.opn_B_FM_SqlMode_DTCS_Click);
            // 
            // opn_B_FM_SqlMode_TSQL_R
            // 
            this.opn_B_FM_SqlMode_TSQL_R.AutoCheck = false;
            this.opn_B_FM_SqlMode_TSQL_R.AutoSize = true;
            this.opn_B_FM_SqlMode_TSQL_R.Location = new System.Drawing.Point(69, 103);
            this.opn_B_FM_SqlMode_TSQL_R.Name = "opn_B_FM_SqlMode_TSQL_R";
            this.opn_B_FM_SqlMode_TSQL_R.Size = new System.Drawing.Size(70, 17);
            this.opn_B_FM_SqlMode_TSQL_R.TabIndex = 8;
            this.opn_B_FM_SqlMode_TSQL_R.TabStop = true;
            this.opn_B_FM_SqlMode_TSQL_R.Text = "TSQL-R";
            this.opn_B_FM_SqlMode_TSQL_R.UseVisualStyleBackColor = true;
            this.opn_B_FM_SqlMode_TSQL_R.Click += new System.EventHandler(this.opn_B_FM_SqlMode_TSQL_R_Click);
            // 
            // opn_B_FM_SqlMode_TSQL
            // 
            this.opn_B_FM_SqlMode_TSQL.AutoCheck = false;
            this.opn_B_FM_SqlMode_TSQL.AutoSize = true;
            this.opn_B_FM_SqlMode_TSQL.Location = new System.Drawing.Point(69, 81);
            this.opn_B_FM_SqlMode_TSQL.Name = "opn_B_FM_SqlMode_TSQL";
            this.opn_B_FM_SqlMode_TSQL.Size = new System.Drawing.Size(57, 17);
            this.opn_B_FM_SqlMode_TSQL.TabIndex = 7;
            this.opn_B_FM_SqlMode_TSQL.TabStop = true;
            this.opn_B_FM_SqlMode_TSQL.Text = "TSQL";
            this.opn_B_FM_SqlMode_TSQL.UseVisualStyleBackColor = true;
            this.opn_B_FM_SqlMode_TSQL.Click += new System.EventHandler(this.opn_B_FM_SqlMode_TSQL_Click);
            // 
            // opn_B_FM_SqlMode_None
            // 
            this.opn_B_FM_SqlMode_None.AutoCheck = false;
            this.opn_B_FM_SqlMode_None.AutoSize = true;
            this.opn_B_FM_SqlMode_None.Location = new System.Drawing.Point(21, 81);
            this.opn_B_FM_SqlMode_None.Name = "opn_B_FM_SqlMode_None";
            this.opn_B_FM_SqlMode_None.Size = new System.Drawing.Size(42, 17);
            this.opn_B_FM_SqlMode_None.TabIndex = 6;
            this.opn_B_FM_SqlMode_None.TabStop = true;
            this.opn_B_FM_SqlMode_None.Text = "Off";
            this.opn_B_FM_SqlMode_None.UseVisualStyleBackColor = true;
            this.opn_B_FM_SqlMode_None.Click += new System.EventHandler(this.opn_B_FM_SqlMode_None_Click);
            // 
            // chk_B_FM_VSC
            // 
            this.chk_B_FM_VSC.AutoCheck = false;
            this.chk_B_FM_VSC.AutoSize = true;
            this.chk_B_FM_VSC.Location = new System.Drawing.Point(73, 34);
            this.chk_B_FM_VSC.Name = "chk_B_FM_VSC";
            this.chk_B_FM_VSC.Size = new System.Drawing.Size(50, 17);
            this.chk_B_FM_VSC.TabIndex = 5;
            this.chk_B_FM_VSC.Text = "VSC";
            this.chk_B_FM_VSC.UseVisualStyleBackColor = true;
            this.chk_B_FM_VSC.Click += new System.EventHandler(this.chk_B_FM_VSC_Click);
            // 
            // cmb_B_FM_DTCSCode
            // 
            this.cmb_B_FM_DTCSCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_B_FM_DTCSCode.FormattingEnabled = true;
            this.cmb_B_FM_DTCSCode.Items.AddRange(new object[] {
            "023",
            "025",
            "026",
            "031",
            "032",
            "036",
            "043",
            "047",
            "051",
            "053",
            "054",
            "065",
            "071",
            "072",
            "073",
            "074",
            "114",
            "115",
            "116",
            "122",
            "125",
            "131",
            "132",
            "134",
            "143",
            "145",
            "152",
            "155",
            "156",
            "162",
            "165",
            "172",
            "174",
            "205",
            "212",
            "223",
            "225",
            "226",
            "243",
            "244",
            "245",
            "246",
            "251",
            "252",
            "255",
            "261",
            "263",
            "265",
            "266",
            "271",
            "274",
            "306",
            "311",
            "315",
            "325",
            "331",
            "332",
            "343",
            "346",
            "351",
            "356",
            "364",
            "365",
            "371",
            "411",
            "412",
            "413",
            "423",
            "431",
            "432",
            "445",
            "446",
            "452",
            "454",
            "455",
            "462",
            "464",
            "465",
            "466",
            "503",
            "506",
            "516",
            "523",
            "526",
            "532",
            "546",
            "565",
            "606",
            "612",
            "624",
            "627",
            "631",
            "632",
            "654",
            "662",
            "664",
            "703",
            "712",
            "723",
            "731",
            "732",
            "734",
            "743",
            "754"});
            this.cmb_B_FM_DTCSCode.Location = new System.Drawing.Point(96, 134);
            this.cmb_B_FM_DTCSCode.Name = "cmb_B_FM_DTCSCode";
            this.cmb_B_FM_DTCSCode.Size = new System.Drawing.Size(68, 21);
            this.cmb_B_FM_DTCSCode.TabIndex = 4;
            this.cmb_B_FM_DTCSCode.SelectionChangeCommitted += new System.EventHandler(this.cmb_B_FM_DTCSCode_SelectionChangeCommitted);
            // 
            // cmb_B_FM_TSQLFreq
            // 
            this.cmb_B_FM_TSQLFreq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_B_FM_TSQLFreq.FormattingEnabled = true;
            this.cmb_B_FM_TSQLFreq.Items.AddRange(new object[] {
            "67.0",
            "69.3",
            "71.9",
            "74.4",
            "77.0",
            "79.7",
            "82.5",
            "85.4",
            "88.5",
            "91.5",
            "94.8",
            "97.4",
            "100.0",
            "103.5",
            "107.2",
            "110.9",
            "114.8",
            "118.8",
            "123.0",
            "127.3",
            "131.8",
            "136.5",
            "141.3",
            "146.2",
            "151.4",
            "156.7",
            "159.8",
            "162.2",
            "165.5",
            "167.9",
            "171.3",
            "173.8",
            "177.3",
            "179.9",
            "183.5",
            "186.2",
            "189.9",
            "192.8",
            "196.6",
            "199.5",
            "203.5",
            "206.5",
            "210.7",
            "218.1",
            "225.7",
            "229.1",
            "233.6",
            "241.8",
            "250.3",
            "254.1"});
            this.cmb_B_FM_TSQLFreq.Location = new System.Drawing.Point(96, 134);
            this.cmb_B_FM_TSQLFreq.Name = "cmb_B_FM_TSQLFreq";
            this.cmb_B_FM_TSQLFreq.Size = new System.Drawing.Size(68, 21);
            this.cmb_B_FM_TSQLFreq.TabIndex = 3;
            this.cmb_B_FM_TSQLFreq.SelectionChangeCommitted += new System.EventHandler(this.cmb_B_FM_TSQLFreq_SelectionChangeCommitted);
            // 
            // lbl_B_FM_SQLTYPE
            // 
            this.lbl_B_FM_SQLTYPE.AutoSize = true;
            this.lbl_B_FM_SQLTYPE.Location = new System.Drawing.Point(18, 62);
            this.lbl_B_FM_SQLTYPE.Name = "lbl_B_FM_SQLTYPE";
            this.lbl_B_FM_SQLTYPE.Size = new System.Drawing.Size(79, 13);
            this.lbl_B_FM_SQLTYPE.TabIndex = 2;
            this.lbl_B_FM_SQLTYPE.Text = "Adv Squelch";
            // 
            // chk_B_FM_AFC
            // 
            this.chk_B_FM_AFC.AutoCheck = false;
            this.chk_B_FM_AFC.AutoSize = true;
            this.chk_B_FM_AFC.Location = new System.Drawing.Point(18, 34);
            this.chk_B_FM_AFC.Name = "chk_B_FM_AFC";
            this.chk_B_FM_AFC.Size = new System.Drawing.Size(49, 17);
            this.chk_B_FM_AFC.TabIndex = 0;
            this.chk_B_FM_AFC.Text = "AFC";
            this.chk_B_FM_AFC.UseVisualStyleBackColor = true;
            this.chk_B_FM_AFC.Click += new System.EventHandler(this.chk_B_FM_AFC_Click);
            // 
            // grp_B_P25
            // 
            this.grp_B_P25.Controls.Add(this.txt_B_P25_Dest_DBName);
            this.grp_B_P25.Controls.Add(this.txt_B_P25_Src_DBName);
            this.grp_B_P25.Controls.Add(this.txt_B_P25_CallType);
            this.grp_B_P25.Controls.Add(this.txt_B_P25_NAC);
            this.grp_B_P25.Controls.Add(this.txt_B_P25_Dest);
            this.grp_B_P25.Controls.Add(this.txt_B_P25_Src);
            this.grp_B_P25.Controls.Add(this.lbl_B_P25_CallType);
            this.grp_B_P25.Controls.Add(this.lbl_B_P25_Enc);
            this.grp_B_P25.Controls.Add(this.lbl_B_P25_EMERG);
            this.grp_B_P25.Controls.Add(this.lbl_B_P25_NAC);
            this.grp_B_P25.Controls.Add(this.lbl_B_P25_Dest);
            this.grp_B_P25.Controls.Add(this.lbl_B_P25_Src);
            this.grp_B_P25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_B_P25.Location = new System.Drawing.Point(986, 427);
            this.grp_B_P25.Name = "grp_B_P25";
            this.grp_B_P25.Size = new System.Drawing.Size(300, 350);
            this.grp_B_P25.TabIndex = 17;
            this.grp_B_P25.TabStop = false;
            this.grp_B_P25.Text = "P25";
            // 
            // txt_B_P25_Dest_DBName
            // 
            this.txt_B_P25_Dest_DBName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_B_P25_Dest_DBName.Location = new System.Drawing.Point(6, 192);
            this.txt_B_P25_Dest_DBName.Name = "txt_B_P25_Dest_DBName";
            this.txt_B_P25_Dest_DBName.ReadOnly = true;
            this.txt_B_P25_Dest_DBName.Size = new System.Drawing.Size(288, 24);
            this.txt_B_P25_Dest_DBName.TabIndex = 11;
            // 
            // txt_B_P25_Src_DBName
            // 
            this.txt_B_P25_Src_DBName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_B_P25_Src_DBName.Location = new System.Drawing.Point(6, 100);
            this.txt_B_P25_Src_DBName.Name = "txt_B_P25_Src_DBName";
            this.txt_B_P25_Src_DBName.ReadOnly = true;
            this.txt_B_P25_Src_DBName.Size = new System.Drawing.Size(288, 24);
            this.txt_B_P25_Src_DBName.TabIndex = 10;
            // 
            // txt_B_P25_CallType
            // 
            this.txt_B_P25_CallType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_B_P25_CallType.Location = new System.Drawing.Point(123, 249);
            this.txt_B_P25_CallType.Name = "txt_B_P25_CallType";
            this.txt_B_P25_CallType.ReadOnly = true;
            this.txt_B_P25_CallType.Size = new System.Drawing.Size(100, 26);
            this.txt_B_P25_CallType.TabIndex = 9;
            // 
            // txt_B_P25_NAC
            // 
            this.txt_B_P25_NAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_B_P25_NAC.Location = new System.Drawing.Point(9, 249);
            this.txt_B_P25_NAC.Name = "txt_B_P25_NAC";
            this.txt_B_P25_NAC.ReadOnly = true;
            this.txt_B_P25_NAC.Size = new System.Drawing.Size(94, 26);
            this.txt_B_P25_NAC.TabIndex = 8;
            // 
            // txt_B_P25_Dest
            // 
            this.txt_B_P25_Dest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_B_P25_Dest.Location = new System.Drawing.Point(9, 160);
            this.txt_B_P25_Dest.Name = "txt_B_P25_Dest";
            this.txt_B_P25_Dest.ReadOnly = true;
            this.txt_B_P25_Dest.Size = new System.Drawing.Size(132, 26);
            this.txt_B_P25_Dest.TabIndex = 7;
            // 
            // txt_B_P25_Src
            // 
            this.txt_B_P25_Src.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_B_P25_Src.Location = new System.Drawing.Point(6, 68);
            this.txt_B_P25_Src.Name = "txt_B_P25_Src";
            this.txt_B_P25_Src.ReadOnly = true;
            this.txt_B_P25_Src.Size = new System.Drawing.Size(135, 26);
            this.txt_B_P25_Src.TabIndex = 6;
            // 
            // lbl_B_P25_CallType
            // 
            this.lbl_B_P25_CallType.AutoSize = true;
            this.lbl_B_P25_CallType.Location = new System.Drawing.Point(129, 233);
            this.lbl_B_P25_CallType.Name = "lbl_B_P25_CallType";
            this.lbl_B_P25_CallType.Size = new System.Drawing.Size(64, 13);
            this.lbl_B_P25_CallType.TabIndex = 5;
            this.lbl_B_P25_CallType.Text = "Call Type:";
            // 
            // lbl_B_P25_Enc
            // 
            this.lbl_B_P25_Enc.AutoSize = true;
            this.lbl_B_P25_Enc.ForeColor = System.Drawing.Color.Blue;
            this.lbl_B_P25_Enc.Location = new System.Drawing.Point(129, 20);
            this.lbl_B_P25_Enc.Name = "lbl_B_P25_Enc";
            this.lbl_B_P25_Enc.Size = new System.Drawing.Size(64, 13);
            this.lbl_B_P25_Enc.TabIndex = 4;
            this.lbl_B_P25_Enc.Text = "Encrypted";
            // 
            // lbl_B_P25_EMERG
            // 
            this.lbl_B_P25_EMERG.AutoSize = true;
            this.lbl_B_P25_EMERG.ForeColor = System.Drawing.Color.Red;
            this.lbl_B_P25_EMERG.Location = new System.Drawing.Point(18, 20);
            this.lbl_B_P25_EMERG.Name = "lbl_B_P25_EMERG";
            this.lbl_B_P25_EMERG.Size = new System.Drawing.Size(51, 13);
            this.lbl_B_P25_EMERG.TabIndex = 3;
            this.lbl_B_P25_EMERG.Text = "EMERG";
            // 
            // lbl_B_P25_NAC
            // 
            this.lbl_B_P25_NAC.AutoSize = true;
            this.lbl_B_P25_NAC.Location = new System.Drawing.Point(6, 233);
            this.lbl_B_P25_NAC.Name = "lbl_B_P25_NAC";
            this.lbl_B_P25_NAC.Size = new System.Drawing.Size(36, 13);
            this.lbl_B_P25_NAC.TabIndex = 2;
            this.lbl_B_P25_NAC.Text = "NAC:";
            // 
            // lbl_B_P25_Dest
            // 
            this.lbl_B_P25_Dest.AutoSize = true;
            this.lbl_B_P25_Dest.Location = new System.Drawing.Point(6, 141);
            this.lbl_B_P25_Dest.Name = "lbl_B_P25_Dest";
            this.lbl_B_P25_Dest.Size = new System.Drawing.Size(46, 13);
            this.lbl_B_P25_Dest.TabIndex = 1;
            this.lbl_B_P25_Dest.Text = "Called:";
            // 
            // lbl_B_P25_Src
            // 
            this.lbl_B_P25_Src.AutoSize = true;
            this.lbl_B_P25_Src.Location = new System.Drawing.Point(6, 49);
            this.lbl_B_P25_Src.Name = "lbl_B_P25_Src";
            this.lbl_B_P25_Src.Size = new System.Drawing.Size(43, 13);
            this.lbl_B_P25_Src.TabIndex = 0;
            this.lbl_B_P25_Src.Text = "Caller:";
            // 
            // grp_B_AM
            // 
            this.grp_B_AM.Controls.Add(this.chk_B_AM_ANL);
            this.grp_B_AM.Controls.Add(this.chk_B_AM_VSC);
            this.grp_B_AM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_B_AM.Location = new System.Drawing.Point(1293, 427);
            this.grp_B_AM.Name = "grp_B_AM";
            this.grp_B_AM.Size = new System.Drawing.Size(300, 350);
            this.grp_B_AM.TabIndex = 18;
            this.grp_B_AM.TabStop = false;
            this.grp_B_AM.Text = "AM";
            // 
            // chk_B_AM_ANL
            // 
            this.chk_B_AM_ANL.AutoCheck = false;
            this.chk_B_AM_ANL.AutoSize = true;
            this.chk_B_AM_ANL.Location = new System.Drawing.Point(16, 31);
            this.chk_B_AM_ANL.Name = "chk_B_AM_ANL";
            this.chk_B_AM_ANL.Size = new System.Drawing.Size(50, 17);
            this.chk_B_AM_ANL.TabIndex = 7;
            this.chk_B_AM_ANL.Text = "ANL";
            this.chk_B_AM_ANL.UseVisualStyleBackColor = true;
            this.chk_B_AM_ANL.Click += new System.EventHandler(this.chk_B_AM_ANL_Click);
            // 
            // chk_B_AM_VSC
            // 
            this.chk_B_AM_VSC.AutoCheck = false;
            this.chk_B_AM_VSC.AutoSize = true;
            this.chk_B_AM_VSC.Location = new System.Drawing.Point(84, 31);
            this.chk_B_AM_VSC.Name = "chk_B_AM_VSC";
            this.chk_B_AM_VSC.Size = new System.Drawing.Size(50, 17);
            this.chk_B_AM_VSC.TabIndex = 6;
            this.chk_B_AM_VSC.Text = "VSC";
            this.chk_B_AM_VSC.UseVisualStyleBackColor = true;
            this.chk_B_AM_VSC.Click += new System.EventHandler(this.chk_B_AM_VSC_Click);
            // 
            // mtslbl_Switching
            // 
            this.mtslbl_Switching.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtslbl_Switching.Name = "mtslbl_Switching";
            this.mtslbl_Switching.Size = new System.Drawing.Size(65, 22);
            this.mtslbl_Switching.Text = "Switching:";
            // 
            // mtsl_Attenuator
            // 
            this.mtsl_Attenuator.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtsl_Attenuator.Name = "mtsl_Attenuator";
            this.mtsl_Attenuator.Size = new System.Drawing.Size(72, 22);
            this.mtsl_Attenuator.Text = "Attenuator:";
            // 
            // mtsdb_Attenuator
            // 
            this.mtsdb_Attenuator.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mtsdb_Attenuator.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mtsdb_Attenuator_OFF,
            this.mtsdb_Attenuator_ATT1,
            this.mtsdb_Attenuator_ATT2,
            this.mtsdb_Attenuator_ATT3});
            this.mtsdb_Attenuator.Image = ((System.Drawing.Image)(resources.GetObject("mtsdb_Attenuator.Image")));
            this.mtsdb_Attenuator.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mtsdb_Attenuator.Name = "mtsdb_Attenuator";
            this.mtsdb_Attenuator.Size = new System.Drawing.Size(41, 22);
            this.mtsdb_Attenuator.Text = "OFF";
            this.mtsdb_Attenuator.ToolTipText = "Attenuation";
            // 
            // mtsdb_Attenuator_OFF
            // 
            this.mtsdb_Attenuator_OFF.Name = "mtsdb_Attenuator_OFF";
            this.mtsdb_Attenuator_OFF.Size = new System.Drawing.Size(180, 22);
            this.mtsdb_Attenuator_OFF.Text = "OFF";
            this.mtsdb_Attenuator_OFF.Click += new System.EventHandler(this.mtsdb_Attenuator_OFF_Click);
            // 
            // mtsdb_Attenuator_ATT1
            // 
            this.mtsdb_Attenuator_ATT1.Name = "mtsdb_Attenuator_ATT1";
            this.mtsdb_Attenuator_ATT1.Size = new System.Drawing.Size(180, 22);
            this.mtsdb_Attenuator_ATT1.Text = "ATT1";
            this.mtsdb_Attenuator_ATT1.Click += new System.EventHandler(this.mtsdb_Attenuator_ATT1_Click);
            // 
            // mtsdb_Attenuator_ATT2
            // 
            this.mtsdb_Attenuator_ATT2.Name = "mtsdb_Attenuator_ATT2";
            this.mtsdb_Attenuator_ATT2.Size = new System.Drawing.Size(180, 22);
            this.mtsdb_Attenuator_ATT2.Text = "ATT2";
            this.mtsdb_Attenuator_ATT2.Click += new System.EventHandler(this.mtsdb_Attenuator_ATT2_Click);
            // 
            // mtsdb_Attenuator_ATT3
            // 
            this.mtsdb_Attenuator_ATT3.Name = "mtsdb_Attenuator_ATT3";
            this.mtsdb_Attenuator_ATT3.Size = new System.Drawing.Size(180, 22);
            this.mtsdb_Attenuator_ATT3.Text = "ATT3";
            this.mtsdb_Attenuator_ATT3.Click += new System.EventHandler(this.mtsdb_Attenuator_ATT3_Click);
            // 
            // btn_About
            // 
            this.btn_About.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_About.Location = new System.Drawing.Point(909, 2);
            this.btn_About.Name = "btn_About";
            this.btn_About.Size = new System.Drawing.Size(28, 21);
            this.btn_About.TabIndex = 20;
            this.btn_About.Text = "?";
            this.btn_About.UseVisualStyleBackColor = true;
            this.btn_About.Click += new System.EventHandler(this.btn_About_Click);
            // 
            // mtsdb_Data
            // 
            this.mtsdb_Data.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mtsdb_Data.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mtsdb_Data_LoadP25Grp,
            this.mtsdb_Data_LoadP25Rad});
            this.mtsdb_Data.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtsdb_Data.Image = ((System.Drawing.Image)(resources.GetObject("mtsdb_Data.Image")));
            this.mtsdb_Data.ImageTransparentColor = System.Drawing.Color.MediumAquamarine;
            this.mtsdb_Data.Name = "mtsdb_Data";
            this.mtsdb_Data.Size = new System.Drawing.Size(46, 22);
            this.mtsdb_Data.Text = "Data";
            // 
            // mtsdb_Data_LoadP25Grp
            // 
            this.mtsdb_Data_LoadP25Grp.Name = "mtsdb_Data_LoadP25Grp";
            this.mtsdb_Data_LoadP25Grp.Size = new System.Drawing.Size(203, 22);
            this.mtsdb_Data_LoadP25Grp.Text = "Load DSD Groups (P25)";
            this.mtsdb_Data_LoadP25Grp.Click += new System.EventHandler(this.mtsdb_Data_LoadP25Grp_Click);
            // 
            // mtsdb_Data_LoadP25Rad
            // 
            this.mtsdb_Data_LoadP25Rad.Name = "mtsdb_Data_LoadP25Rad";
            this.mtsdb_Data_LoadP25Rad.Size = new System.Drawing.Size(203, 22);
            this.mtsdb_Data_LoadP25Rad.Text = "Load DSD Radios (P25)";
            this.mtsdb_Data_LoadP25Rad.Click += new System.EventHandler(this.mtsdb_Data_LoadP25Rad_Click);
            // 
            // btnScanTest
            // 
            this.btnScanTest.Location = new System.Drawing.Point(488, 386);
            this.btnScanTest.Name = "btnScanTest";
            this.btnScanTest.Size = new System.Drawing.Size(75, 23);
            this.btnScanTest.TabIndex = 21;
            this.btnScanTest.Text = "button1";
            this.btnScanTest.UseVisualStyleBackColor = true;
            this.btnScanTest.Click += new System.EventHandler(this.btnScanTest_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1685, 804);
            this.Controls.Add(this.btnScanTest);
            this.Controls.Add(this.btn_About);
            this.Controls.Add(this.grp_B_AM);
            this.Controls.Add(this.grp_B_P25);
            this.Controls.Add(this.grp_B_FM);
            this.Controls.Add(this.grp_A_SSB);
            this.Controls.Add(this.grp_A_AM);
            this.Controls.Add(this.grp_A_P25);
            this.Controls.Add(this.grp_A_FM);
            this.Controls.Add(this.btnPowerOff);
            this.Controls.Add(this.btnPowerOn);
            this.Controls.Add(this.chkPUW);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.grpRecB);
            this.Controls.Add(this.btnDebugSend);
            this.Controls.Add(this.txtDbgSend);
            this.Controls.Add(this.grpRecA);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "IC-R30 PC Remote";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpRecA.ResumeLayout(false);
            this.grpRecA.PerformLayout();
            this.grp_A_ScanCtrl.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.m_A_Mode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trk_A_SqlLvl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_A_RFGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_A_AFGain)).EndInit();
            this.grpRecB.ResumeLayout(false);
            this.grpRecB.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.m_B_Mode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trk_B_SqlLvl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_B_RFGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_B_AFGain)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.grp_A_FM.ResumeLayout(false);
            this.grp_A_FM.PerformLayout();
            this.grp_A_P25.ResumeLayout(false);
            this.grp_A_P25.PerformLayout();
            this.grp_A_AM.ResumeLayout(false);
            this.grp_A_AM.PerformLayout();
            this.grp_A_SSB.ResumeLayout(false);
            this.grp_A_SSB.PerformLayout();
            this.grp_B_FM.ResumeLayout(false);
            this.grp_B_FM.PerformLayout();
            this.grp_B_P25.ResumeLayout(false);
            this.grp_B_P25.PerformLayout();
            this.grp_B_AM.ResumeLayout(false);
            this.grp_B_AM.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtDbgSend;
        private System.Windows.Forms.Button btnDebugSend;
        private System.Windows.Forms.GroupBox grpRecA;
        private System.Windows.Forms.GroupBox grpRecB;
        private System.Windows.Forms.ContextMenuStrip m_A_Mode;
        private System.Windows.Forms.ToolStripMenuItem mi_A_Mode_LSB;
        private System.Windows.Forms.ToolStripMenuItem mi_A_Mode_USB;
        private System.Windows.Forms.ToolStripMenuItem mi_A_Mode_AM;
        private System.Windows.Forms.ToolStripMenuItem mi_A_Mode_AM_N;
        private System.Windows.Forms.ToolStripMenuItem mi_A_Mode_FM;
        private System.Windows.Forms.ToolStripMenuItem mi_A_Mode_FM_N;
        private System.Windows.Forms.ToolStripMenuItem mi_A_Mode_CW;
        private System.Windows.Forms.ToolStripMenuItem mi_A_Mode_CW_R;
        private System.Windows.Forms.ToolStripMenuItem mi_A_Mode_WFM;
        private System.Windows.Forms.ToolStripMenuItem mi_A_Mode_DSTAR;
        private System.Windows.Forms.ToolStripMenuItem mi_A_Mode_P25;
        private System.Windows.Forms.ToolStripMenuItem mi_A_Mode_dPMR;
        private System.Windows.Forms.ToolStripMenuItem mi_A_Mode_NXDX_VN;
        private System.Windows.Forms.ToolStripMenuItem mi_A_Mode_NXDN_N;
        private System.Windows.Forms.ToolStripMenuItem mi_A_Mode_DCR;
        private System.Windows.Forms.Label lblA_Hz_Ind;
        private System.Windows.Forms.Label lblA_KHz_Ind;
        private System.Windows.Forms.Label lblA_MHz_Ind;
        private System.Windows.Forms.Label lblA_GHz_Ind;
        private System.Windows.Forms.Button btnA_Hz;
        private System.Windows.Forms.Button btnA_KHz;
        private System.Windows.Forms.Button btnA_GHz;
        private System.Windows.Forms.Button btnA_MHz;
        private System.Windows.Forms.TextBox txtA_FreqEntry;
        private System.Windows.Forms.Label lblAFreq;
        private System.Windows.Forms.Label lbl_A_Sql;
        private System.Windows.Forms.TrackBar trk_A_SqlLvl;
        private System.Windows.Forms.Label lbl_A_RFGain;
        private System.Windows.Forms.TrackBar trk_A_RFGain;
        private System.Windows.Forms.Label lbl_A_AFGain;
        private System.Windows.Forms.TrackBar trk_A_AFGain;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslbl_A_RecStatus;
        private System.Windows.Forms.Button btn_A_KPdot;
        private System.Windows.Forms.Button btn_A_KPEnter;
        private System.Windows.Forms.Button btn_A_KP9;
        private System.Windows.Forms.Button btn_A_KP8;
        private System.Windows.Forms.Button btn_A_KP7;
        private System.Windows.Forms.Button btn_A_KP6;
        private System.Windows.Forms.Button btn_A_KP5;
        private System.Windows.Forms.Button btn_A_KP4;
        private System.Windows.Forms.Button btn_A_KP3;
        private System.Windows.Forms.Button btn_A_KP2;
        private System.Windows.Forms.Button btn_A_KP1;
        private System.Windows.Forms.Button btn_A_KP0;
        private System.Windows.Forms.ProgressBar pbASmeter;
        private System.Windows.Forms.CheckBox chkPUW;
        private System.Windows.Forms.ToolStripSplitButton sb_A_Scan;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ProgressBar pbBSmeter;
        private System.Windows.Forms.Button btn_B_KPdot;
        private System.Windows.Forms.Button btn_B_KPEnter;
        private System.Windows.Forms.Button btn_B_KP9;
        private System.Windows.Forms.Button btn_B_KP8;
        private System.Windows.Forms.Button btn_B_KP7;
        private System.Windows.Forms.Button btn_B_KP6;
        private System.Windows.Forms.Button btn_B_KP5;
        private System.Windows.Forms.Button btn_B_KP4;
        private System.Windows.Forms.Button btn_B_KP3;
        private System.Windows.Forms.Button btn_B_KP2;
        private System.Windows.Forms.Button btn_B_KP1;
        private System.Windows.Forms.Button btn_B_KP0;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trk_B_SqlLvl;
        private System.Windows.Forms.Label lbl_B_RFGain;
        private System.Windows.Forms.TrackBar trk_B_RFGain;
        private System.Windows.Forms.Label lbl_B_AFGain;
        private System.Windows.Forms.TrackBar trk_B_AFGain;
        private System.Windows.Forms.Label lblB_Hz_Ind;
        private System.Windows.Forms.Label lblB_KHz_Ind;
        private System.Windows.Forms.Label lblB_MHz_Ind;
        private System.Windows.Forms.Label lblB_GHz_Ind;
        private System.Windows.Forms.Button btnB_Hz;
        private System.Windows.Forms.Button btnB_KHz;
        private System.Windows.Forms.Button btnB_GHz;
        private System.Windows.Forms.Button btnB_MHz;
        private System.Windows.Forms.TextBox txtB_FreqEntry;
        private System.Windows.Forms.Label lblBFreq;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel tslbl_B_RecStatus;
        private System.Windows.Forms.ToolStripSplitButton sb_B_Scan;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Button btnPowerOn;
        private System.Windows.Forms.ToolStripSplitButton sb_A_Mode;
        private System.Windows.Forms.ToolStripSplitButton sb_B_Mode;
        private System.Windows.Forms.ContextMenuStrip m_B_Mode;
        private System.Windows.Forms.ToolStripMenuItem mi_B_Mode_AM;
        private System.Windows.Forms.ToolStripMenuItem mi_B_Mode_FM;
        private System.Windows.Forms.ToolStripMenuItem mi_B_Mode_DSTAR;
        private System.Windows.Forms.ToolStripMenuItem mi_B_Mode_P25;
        private System.Windows.Forms.ToolStripMenuItem mi_B_Mode_dPMR;
        private System.Windows.Forms.ToolStripMenuItem mi_B_Mode_NXDN_VN;
        private System.Windows.Forms.ToolStripMenuItem mi_B_Mode_NXDN_N;
        private System.Windows.Forms.ToolStripMenuItem mi_B_Mode_DCR;
        private System.Windows.Forms.ToolStripDropDownButton sb_A_VFOMEM;
        private System.Windows.Forms.ToolStripMenuItem mi_A_VFO;
        private System.Windows.Forms.ToolStripMenuItem mi_A_MEM;
        private System.Windows.Forms.ToolStripMenuItem mi_A_WX;
        private System.Windows.Forms.ToolStripDropDownButton sb_B_VFOMEM;
        private System.Windows.Forms.ToolStripMenuItem mi_B_VFO;
        private System.Windows.Forms.ToolStripMenuItem mi_B_MEM;
        private System.Windows.Forms.ToolStripMenuItem mi_B_WX;
        private System.Windows.Forms.Label lbl_A_MemName;
        private System.Windows.Forms.Label lbl_B_MemName;
        private System.Windows.Forms.Label lbl_A_MEM_MEM;
        private System.Windows.Forms.Label lbl_A_MEM_GRP;
        private System.Windows.Forms.Label lbl_B_MEM_MEM;
        private System.Windows.Forms.Label lbl_B_MEM_GRP;
        private System.Windows.Forms.GroupBox grp_A_ScanCtrl;
        private System.Windows.Forms.Button btn_A_ScanCtrl_Skip;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_B_ScanCtrl_Skip;
        private System.Windows.Forms.Label lbl_A_MemGrpName;
        private System.Windows.Forms.Label lbl_B_MemGrpName;
        private System.Windows.Forms.Button btnPowerOff;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton mtsbConnect;
        private System.Windows.Forms.ToolStripLabel mtsl_COMPort;
        private System.Windows.Forms.ToolStripComboBox mtscb_COMPort;
        private System.Windows.Forms.ToolStripLabel mtsl_BaudRate;
        private System.Windows.Forms.ToolStripComboBox mtscb_BaudRate;
        private System.Windows.Forms.ToolStripLabel mtsl_Layout;
        private System.Windows.Forms.ToolStripDropDownButton mtsdb_Layout;
        private System.Windows.Forms.ToolStripMenuItem mtsdb_Layout_SingleA;
        private System.Windows.Forms.ToolStripMenuItem mtsdb_Layout_Dual;
        private System.Windows.Forms.ToolStripMenuItem mtsdb_Layout_SingleB;
        private System.Windows.Forms.Button btn_A_ReceiveInd;
        private System.Windows.Forms.Button btn_B_ReceiveInd;
        private System.Windows.Forms.Label lbl_A_SqlAuto;
        private System.Windows.Forms.Label lbl_A_SqlOpen;
        private System.Windows.Forms.Label lbl_B_SqlAuto;
        private System.Windows.Forms.Label lbl_B_SqlOpen;
        private System.Windows.Forms.GroupBox grp_A_FM;
        private System.Windows.Forms.ComboBox cmb_A_FM_DTCSCode;
        private System.Windows.Forms.ComboBox cmb_A_FM_TSQLFreq;
        private System.Windows.Forms.Label lbl_A_FM_SQLTYPE;
        private System.Windows.Forms.CheckBox chk_A_FM_AFC;
        private System.Windows.Forms.CheckBox chk_A_FM_VSC;
        private System.Windows.Forms.GroupBox grp_A_P25;
        private System.Windows.Forms.TextBox txt_A_P25_CallType;
        private System.Windows.Forms.TextBox txt_A_P25_NAC;
        private System.Windows.Forms.TextBox txt_A_P25_Dest;
        private System.Windows.Forms.TextBox txt_A_P25_Src;
        private System.Windows.Forms.Label lbl_A_P25_CallType;
        private System.Windows.Forms.Label lbl_A_P25_Enc;
        private System.Windows.Forms.Label lbl_A_P25_EMERG;
        private System.Windows.Forms.Label lbl_A_P25_NAC;
        private System.Windows.Forms.Label lbl_A_P25_Dest;
        private System.Windows.Forms.Label lbl_A_P25_Src;
        private System.Windows.Forms.TextBox txt_A_P25_Src_DBName;
        private System.Windows.Forms.TextBox txt_A_P25_Dest_DBName;
        private System.Windows.Forms.RadioButton opn_A_FM_SqlMode_DTCS_R;
        private System.Windows.Forms.RadioButton opn_A_FM_SqlMode_DTCS;
        private System.Windows.Forms.RadioButton opn_A_FM_SqlMode_TSQL_R;
        private System.Windows.Forms.RadioButton opn_A_FM_SqlMode_TSQL;
        private System.Windows.Forms.RadioButton opn_A_FM_SqlMode_None;
        private System.Windows.Forms.Label lbl_A_FM_SQLFreqOrCode;
        private System.Windows.Forms.GroupBox grp_A_AM;
        private System.Windows.Forms.CheckBox chk_A_AM_ANL;
        private System.Windows.Forms.CheckBox chk_A_AM_VSC;
        private System.Windows.Forms.GroupBox grp_A_SSB;
        private System.Windows.Forms.CheckBox chk_A_SSB_NB;
        private System.Windows.Forms.GroupBox grp_B_FM;
        private System.Windows.Forms.Label lbl_B_FM_SQLFreqOrCode;
        private System.Windows.Forms.RadioButton opn_B_FM_SqlMode_DTCS_R;
        private System.Windows.Forms.RadioButton opn_B_FM_SqlMode_DTCS;
        private System.Windows.Forms.RadioButton opn_B_FM_SqlMode_TSQL_R;
        private System.Windows.Forms.RadioButton opn_B_FM_SqlMode_TSQL;
        private System.Windows.Forms.RadioButton opn_B_FM_SqlMode_None;
        private System.Windows.Forms.CheckBox chk_B_FM_VSC;
        private System.Windows.Forms.ComboBox cmb_B_FM_DTCSCode;
        private System.Windows.Forms.ComboBox cmb_B_FM_TSQLFreq;
        private System.Windows.Forms.Label lbl_B_FM_SQLTYPE;
        private System.Windows.Forms.CheckBox chk_B_FM_AFC;
        private System.Windows.Forms.GroupBox grp_B_P25;
        private System.Windows.Forms.TextBox txt_B_P25_Dest_DBName;
        private System.Windows.Forms.TextBox txt_B_P25_Src_DBName;
        private System.Windows.Forms.TextBox txt_B_P25_CallType;
        private System.Windows.Forms.TextBox txt_B_P25_NAC;
        private System.Windows.Forms.TextBox txt_B_P25_Dest;
        private System.Windows.Forms.TextBox txt_B_P25_Src;
        private System.Windows.Forms.Label lbl_B_P25_CallType;
        private System.Windows.Forms.Label lbl_B_P25_Enc;
        private System.Windows.Forms.Label lbl_B_P25_EMERG;
        private System.Windows.Forms.Label lbl_B_P25_NAC;
        private System.Windows.Forms.Label lbl_B_P25_Dest;
        private System.Windows.Forms.Label lbl_B_P25_Src;
        private System.Windows.Forms.GroupBox grp_B_AM;
        private System.Windows.Forms.CheckBox chk_B_AM_ANL;
        private System.Windows.Forms.CheckBox chk_B_AM_VSC;
        private System.Windows.Forms.ToolStripDropDownButton mtsdb_SwitchingType;
        private System.Windows.Forms.ToolStripMenuItem mtsdb_SwitchingType_MouseOver;
        private System.Windows.Forms.ToolStripMenuItem mtsdb_SwitchingType_Manual;
        private System.Windows.Forms.ToolStripLabel mtslbl_Switching;
        private System.Windows.Forms.ToolStripLabel mtsl_Attenuator;
        private System.Windows.Forms.ToolStripDropDownButton mtsdb_Attenuator;
        private System.Windows.Forms.ToolStripMenuItem mtsdb_Attenuator_OFF;
        private System.Windows.Forms.ToolStripMenuItem mtsdb_Attenuator_ATT1;
        private System.Windows.Forms.ToolStripMenuItem mtsdb_Attenuator_ATT2;
        private System.Windows.Forms.ToolStripMenuItem mtsdb_Attenuator_ATT3;
        private System.Windows.Forms.Button btn_About;
        private System.Windows.Forms.ToolStripDropDownButton mtsdb_Data;
        private System.Windows.Forms.ToolStripMenuItem mtsdb_Data_LoadP25Grp;
        private System.Windows.Forms.ToolStripMenuItem mtsdb_Data_LoadP25Rad;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.Button btnScanTest;
    }
}

