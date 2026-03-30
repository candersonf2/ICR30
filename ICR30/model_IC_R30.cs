using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ICR30
{
    public class model_IC_R30
    {
        // This class is full of structures meant to keep track of the current state of the
        // radio, rather than storing values in GUI elements. Sadly, due to some synchronization
        // issues I have ended up doing both. I need to clean this up a lot.

        // Two main RF interfaces, RFA and RFB. RFMAIN is supposed to always be set to a reference
        // of whichever RF Channel is "Main." This is maintained by the DisplayContent packet processor
        // As that is what tells me which mode we are in...
        public t_RFChannel RFA;
        public t_RFChannel RFB;
        public t_RFChannel RFMAIN;

        // I added a fake DualBandMode called NONE to let the app know it has not discovered which
        // mode we are in yet. This was necessary to allow triggering sync up of this.
        public t_DualBandMode DualBandMode = t_DualBandMode.NONE;

        public t_Attenuator Attenuator;
        public t_MemoryChan MemoryChannel;

        // A reference to the SerialPortHandler is passed to this class to make things easier
        // as all of the commands will live here. This is supposed to allow similarly structured
        // classes for different models of receiver to work with some of the same classes.
        public SerialPortHandler SerialInterface;

        // The structure and name of these is a little wonky after some changes, but these are
        // where we cache the memory and VFO scan edge entries. The classes are defined below.
        public MemoryGroups MemoryGroups = new MemoryGroups();
        public ProgramEdges ProgramEdges = new ProgramEdges();

        // Used for synchronization for loading current memory/program names.
        // Icom decided to send the names across several separate packets, with no
        // internal identification of which memory entries they were, so we must keep track of the
        // total number of entries received until the sequence of packets is complete.
        public int MemoryGroupLoaderCurrent;
        public int ProgramEdgeLoaderCurrent;

        // Gee, I hope nobody changes this setting in their R30.
        // TODO: make configurable.
        public byte R30_ID = 0x9C;

        #region Type Definitions
        public struct t_RFChannel
        {
            public uint Frequency;
            public uint FrequencyStep;
            public t_ReceiveMode ReceiveMode;
            public uint AFGain;
            public t_RFGain RFGain;
            public bool VSC;
            public t_Duplex Duplex;
            public t_DSTAR_Settings DSTAR_Settings;
            public t_FM_Settings FM_Settings;
            public t_AM_Settings AM_Settings;
            public t_SSBCW_Settings SSBCW_Settings;
            public t_ScanCondition ScanCondition;
            public t_OperatingMode OperatingMode;
            public t_MuteRec MuteRec;
            public t_WX WX;
            public bool AFC;
        }
        public enum t_FM_SqlMode
        {
            NONE = 0,
            TSQL = 1,
            DTCS = 2,
            TSQL_R = 3,
            DTCS_R = 4
        }
        public enum t_P25_CallType
        {
            NOT_IDENTIFIED = 0,
            INDIVIDUAL = 1,
            GROUP = 2,
            ALL = 3
        }
        public enum t_ReceiveMode
        {
            LSB = 0x0100,
            USB = 0x0101,
            AM = 0x0102,
            AM_N = 0x0202,
            CW = 0x0103,
            FM = 0x0105,
            FM_N = 0x0205,
            WFM = 0x0106,
            CW_R = 0x0107,
            P25 = 0x0116,
            D_STAR = 0x0117,
            dPMR = 0x0118,
            NXDN_VN = 0x0119,
            NXDN_N = 0x0120,
            DCR = 0x0121
        }
        public enum t_DualBandMode
        {
            SingleAMain,
            SingleBMain,
            DualAMain,
            DualBMain,
            NONE
        }
        public struct t_WX
        {
            public int Channel;
            public bool Alert;
            public bool AlertCall;
        }
        public struct t_MemoryChan
        {
            public t_SKIP Skip;
            public int Group;
            public int Channel;
            public string Name;
        }
        public enum t_SKIP
        {
            OFF = 0x00,
            SKIP = 0x01,
            PSKIP = 0x02
        }
        public struct t_MuteRec
        {
            public bool Mute;
            public t_RecordingState RecordingState;
        }
        public enum t_RecordingState
        {
            STOP = 0x00,
            PAUSE = 0x01,
            RECORDING = 0x03
        }
        public enum t_Duplex
        {
            OFF = 0x10,
            DOWN = 0x11,
            UP = 0x12
        }
        public enum t_Attenuator
        {
            OFF = 0x00,
            ATT1 = 0x15,
            ATT2 = 0x30,
            ATT3 = 0x45
        }
        public enum t_RFGain
        {
            RFG1 = 12,
            RFG2 = 38,
            RFG3 = 64,
            RFG4 = 89,
            RFG5 = 115,
            RFG6 = 140,
            RFG7 = 166,
            RFG8 = 192,
            RFG9 = 217,
            RFGMAX = 243
        }
        public enum t_OperatingMode
        {
            VFO,
            MEM,
            WX
        }
        public enum t_ScanCondition
        {
            NO_SCAN = 0x00,
            UP_SCAN = 0x01,
            DOWN_SCAN = 0x02,
            UP_SCAN_RCV = 0x03,
            DOWN_SCAN_RCV = 0x04
        }
        public enum t_FM_TSQL
        {
            OFF,
            TSQL,
            TSQL_R
        }
        public enum t_FM_DTCS
        {
            OFF,
            DTCS,
            DTCS_R
        }
        public enum t_DSTAR_DSQL
        {
            OFF,
            CSQL
        }
        public struct t_FM_Settings
        {
            public t_FM_TSQL TSQL;
            public t_FM_DTCS DTCS;
            public bool AFC;
        }
        public struct t_AM_Settings
        {
            public bool ANL;
        }
        public struct t_SSBCW_Settings
        {
            public bool NB;
        }
        public struct t_DSTAR_Settings
        {
            public t_DSTAR_DSQL DSQL;
            public bool PacketLoss;
            public bool EMR;
            public bool BK;
            public t_DSTAR_Interference Interference;
        }
        public enum t_DSTAR_Interference
        {
            NONE = 0x00,
            SYNC = 0x01,
            INT = 0x02
        }
        #endregion

        #region R30 Commands
        public void SetReceiveMode(t_ReceiveMode mode)
        {
            // Sets the receive mode (demodulation) for the *Main* Channel
            byte[] brcvmode = new byte[2];
            switch(mode)
            {
                case t_ReceiveMode.LSB:
                    brcvmode[0] = 0x00;
                    brcvmode[1] = 0x01;
                    break;
                case t_ReceiveMode.USB:
                    brcvmode[0] = 0x01;
                    brcvmode[1] = 0x01;
                    break;
                case t_ReceiveMode.AM:
                    brcvmode[0] = 0x02;
                    brcvmode[1] = 0x01;
                    break;
                case t_ReceiveMode.AM_N:
                    brcvmode[0] = 0x02;
                    brcvmode[1] = 0x02;
                    break;
                case t_ReceiveMode.CW:
                    brcvmode[0] = 0x03;
                    brcvmode[1] = 0x01;
                    break;
                case t_ReceiveMode.FM:
                    brcvmode[0] = 0x05;
                    brcvmode[1] = 0x01;
                    break;
                case t_ReceiveMode.FM_N:
                    brcvmode[0] = 0x05;
                    brcvmode[1] = 0x02;
                    break;
                case t_ReceiveMode.WFM:
                    brcvmode[0] = 0x06;
                    brcvmode[1] = 0x01;
                    break;
                case t_ReceiveMode.CW_R:
                    brcvmode[0] = 0x07;
                    brcvmode[1] = 0x01;
                    break;
                case t_ReceiveMode.P25:
                    brcvmode[0] = 0x16;
                    brcvmode[1] = 0x01;
                    break;
                case t_ReceiveMode.D_STAR:
                    brcvmode[0] = 0x17;
                    brcvmode[1] = 0x01;
                    break;
                case t_ReceiveMode.dPMR:
                    brcvmode[0] = 0x18;
                    brcvmode[1] = 0x01;
                    break;
                case t_ReceiveMode.NXDN_VN:
                    brcvmode[0] = 0x19;
                    brcvmode[1] = 0x01;
                    break;
                case t_ReceiveMode.NXDN_N:
                    brcvmode[0] = 0x20;
                    brcvmode[1] = 0x01;
                    break;
                case t_ReceiveMode.DCR:
                    brcvmode[0] = 0x21;
                    brcvmode[1] = 0x01;
                    break;
            }
            SendCommand(0x06, brcvmode);
            SendCommand(0x04, new byte[0]);
        }
        public void SetVSC(bool onOff)
        {
            // Sets Voice Squelch for the *Main* Channel (AM/FM Only)
            if (onOff)
            {
                SendCommand(0x16, 0x4C, new byte[] { 0x01 });
            }
            else
            {
                SendCommand(0x16, 0x4C, new byte[] { 0x00 });
            }
        }
        public void SetNB(bool onOff)
        {
            // Sets the Noise Blanker state for the *Main* Channel (SSB Only)
            if (onOff)
            {
                SendCommand(0x16, 0x22, new byte[] { 0x01 });
            }
            else
            {
                SendCommand(0x16, 0x22, new byte[] { 0x00 });
            }
        }
        public void SetANL(bool onOff)
        {
            // Sets the Automatic Noise Limiter for the *Main* Channel (AM Only)
            if (onOff)
            {
                SendCommand(0x1A, 0x00, new byte[] { 0x01 });
            }
            else
            {
                SendCommand(0x1A, 0x00, new byte[] { 0x00 });
            }
        }
        public void SetFrequency(uint uFreq)
        {
            // Sets Frequency for the *Main* Channel
            SendCommand(0x00, Utils.PackFreq(uFreq));

            // Also request the current frequency after to keep internal state synced.
            SendCommand(0x03, new byte[0]);
        }
        public void ReqDisplayContent()
        {
            // Requests Display Content for the *Main* Channel
            // Note: This is the giant amalgamation of various radio state info that Icom
            // probably included specifically for their remote app. We get most state info
            // from the response to this.... though I have stopped using this for the RF Channel
            // specific one below.
            SendCommand(0x1A, 0x11, new byte[0]);
        }
        public void ReqDisplayContentSpecificRF(byte RFC)
        {
            // Requests Display content for a *Specific* Channel. 0x00 for A, 0x01 for B
            // This is one of the very few functions that can target a specific RF Cbannel
            SendCommand(0x29, RFC, new byte[] { 0x1A, 0x11 });
        }
        public void ReqAFGain()
        {
            // Requests current AF Gain (Volume) setting for the *Main* Channel
            SendCommand(0x14, 0x01, new byte[0]);
        }
        public void ReqRFGain()
        {
            // Requested the current RF Gain setting for the *Main* Channel
            SendCommand(0x14, 0x02, new byte[0]);
        }
        public void ReqSqlLvl()
        {
            // Requests the current Squelch open/close level for the *Main* Channel
            SendCommand(0x14, 0x03, new byte[0]);
        }
        public void SetSkip()
        {
            // Sets Temporary skip on the current memory channel
            // on the *Main* RF Channel
            SendCommand(0x1A, 0x0A, new byte[] { 0x02 });
        }
        public void SetRFAB(byte bRFC)
        {
            // Switches the *Main* channel in Dual mode. 0x00 for A 0x01 for B
            SendCommand(0x07, (byte)(0xD0 | bRFC), new byte[0]);
        }
        public void SetR30PowerState(bool onoff)
        {
            // Sends a POWER ON message to the radio
            // This one doesn't use my usual SendCommand due to the number of header bytes
            // necessary to wake it up.
            byte[] msg = new byte[] {0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE,
            0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, R30_ID, 0x00, 0x18, 0x00, 0xFD};
            if (onoff) msg[23] = 0x01;

            SerialData sd = new SerialData();
            sd.data = msg;
            sd.len = msg.Length;
            sd.ts = DateTime.Now;
            SerialInterface.TXQueue.Enqueue(sd);
        }
        public void ReqDisplayChangeReportTrans()
        {
            // This asks which RF channels have display updates available since
            // they were last requested. This turns out to be less useful than it sounds.
            SendCommand(0x1A, 0x10, new byte[] { 0x02 });
        }
        public void ReqSqlLvlSpecificRF(byte RFC)
        {
            // Requests the current Squelch status (open/close) and S-Meter
            // Level. I need to rename this, as the name clashes with squelch level
            // This is one of the other few commands where you can specify an RF Channel
            SendCommand(0x29, RFC, new byte[] { 0x1A, 0x12 });
        }
        public void SetDualMode(bool dual)
        {
            // Enables or disables DualWatch mode. 0x01 enable, 0x00 disable.
            if (dual)
            {
                SendCommand(0x16, 0x59, new byte[] { 0x01 });
            }
            else
            {
                SendCommand(0x16, 0x59, new byte[] { 0x00 });
            }
        }
        public void ReqMemoryGroups()
        {
            // Requests the names of memory groups. You have to list each memory group number
            // that you want the name returned for. You MUST list exactly 15, or fill empty slots
            // with 0xFF. To get all of them you have to make several requests of 15, and fill the
            // last few slots with 0xFFs. This is a giant pain.
            // This function just requests all of them.
            int grpnum = 0;
            while (grpnum < MemoryGroups.Group.Length)
            {
                int entrycntr = 0;
                byte[] dataout = new byte[31];
                dataout[0] = 0x00;
                while (entrycntr < 15)
                {
                    int i2 = entrycntr * 2;
                    if (grpnum > MemoryGroups.Group.Length)
                    {
                        dataout[i2 + 1] = 0xFF;
                        dataout[(i2 + 1) + 1] = 0xFF;
                    }
                    else
                    {
                        dataout[i2 + 1] = 0x00;
                        dataout[(i2 + 1) + 1] = Utils.UIntToFauxHex((uint)grpnum, 1)[0];
                    }
                    entrycntr++;
                    grpnum++;
                }
                SendCommand(0x1A, 0x0F, dataout);
            }

        }
        public void ReqVFOPrograms()
        {
            // Requests the names of VFO Program Scan edges. Like the Memory version, you MUST
            // send a list of exactly 15 (using 0xFF for slots you don't need) but there are only
            // 50 instead of 100.
            // This function requests all of the names.
            int grpnum = 0;
            while (grpnum < ProgramEdges.ScanEdges.Length)
            {
                int entrycntr = 0;
                byte[] dataout = new byte[16];
                dataout[0] = 0x00;
                while (entrycntr < 15)
                {
                    int i2 = entrycntr;
                    if (grpnum > ProgramEdges.ScanEdges.Length)
                    {
                        dataout[i2 + 1] = 0xFF;
                    }
                    else
                    {
                        dataout[i2 + 1] = Utils.UIntToFauxHex((uint)grpnum, 1)[0];
                    }
                    entrycntr++;
                    grpnum++;
                }
                SendCommand(0x1A, 0x0E, dataout);
            }

        }
        public void SetMemGrp(uint grp)
        {
            // Changes to the specified memory group in Memory mode on *Main* Channel
            SendCommand(0x08, 0xA0, Utils.UIntToFauxHex(grp, 2));
        }
        public void SetMemChan(uint chan)
        {
            // Changes to the specified memory channel in Memory mode on *Main* Channel
            SendCommand(0x08, Utils.UIntToFauxHex(chan, 2));
        }
        public void ReqSMeter()
        {
            // Requests Current S-Meter level for *Main* Channel
            SendCommand(0x15, 0x02, new byte[0]);
        }
        public void SetOperatingMode(t_OperatingMode mode)
        {
            // Sets the "Operating Mode" A.K.A. VFO, MEM, or WX for the *Main* Channel
            SendCommand(0x1A, 0x04, new byte[] { (byte) mode });
        }
        public void SetAFGain(uint uGain)
        {
            // Sets the AF Gain (Volume) for the *Main* Channel
            SendCommand(0x14, 0x01, Utils.UIntToFauxHex(uGain, 2));
        }
        public void SetRFGain(uint uGain)
        {
            // Sets the RF Gain for the *Main* Channel
            SendCommand(0x14, 0x02, Utils.UIntToFauxHex(uGain, 2));
        }
        public void SetSquelchLvl(uint uSql)
        {
            // Sets the Squelch (open/close) level for the *Main* channel
            SendCommand(0x14, 0x03, Utils.UIntToFauxHex(uSql, 2));
        }
        public void StartMemoryGroupScan(int mg)
        {
            // Begin a scan of the specified memory group on the *Main* Channel
            byte[] bmg = Utils.UIntToFauxHex((uint)mg, 2);
            byte[] msg = new byte[5];
            msg[0] = 0x00;
            msg[1] = 0x00;
            msg[2] = 0x08;
            Buffer.BlockCopy(bmg, 0, msg, 3, 2);
            SendCommand(0x1A, 0x0A, msg);
        }
        public void StartVFOProgramScan(int pe)
        {
            // Begin a scan of the specified VFO Program on the *Main* channel.
            byte[] bpe = Utils.UIntToFauxHex((uint)pe, 1);
            byte[] msg = new byte[4];
            msg[0] = 0x00;
            msg[1] = 0x00;
            msg[2] = 0x03;
            Buffer.BlockCopy(bpe, 0, msg, 3, 1);
            SendCommand(0x1A, 0x0A, msg);
        }
        public void SetAttenuator(uint uAtt)
        {
            // Sets the attenuator level for the radio.
            SendCommand(0x11, Utils.UIntToFauxHex(uAtt, 1));
        }
        public void StartMemoryALLScan()
        {
            // Starts a scan of ALL memory channels on the *Main* channel
            SendCommand(0x1A, 0x0A, new byte[] { 0x00, 0x00, 0x04 });
        }
        public void StartMemoryMODEScan()
        {
            // Starts a scan of all memory channels for the current mode on the
            // *Main* channel.
            SendCommand(0x1A, 0x0A, new byte[] { 0x00, 0x00, 0x05 });
        }
        public void StartMemoryGroupLinkScan()
        {
            // Begins a scan of the memory linked groups on the *Main* Channel
            SendCommand(0x1A, 0x0A, new byte[] { 0x00, 0x00, 0x07 });
        }
        public void StopScanning()
        {
            // Cancel the active scan on the *Main* Channel
            SendCommand(0x1A, 0x0A, new byte[] { 0x01});
        }
        public void ReqScanCondition()
        {
            // Requests the current scan status for the *Main* channel
            // Are we in a scan? Are we paused listining to a channel while scanning?
            SendCommand(0x1A, 0x0B, new byte[] { 0x02 });
        }
        public void ReqScanInformation()
        {
            // Badly named. Get scan information (Type, availability, etc)
            // for the *Main* channel. I mainly use this to get a bitwise list of which
            // mem channels/VFO programs are scannable. It varies by VFO vs MEM mode.
            SendCommand(0x1A, 0x0C, new byte[0]);
        }
        public void SetRecording(bool rec)
        {
            // Enable/Disable recording for the *Main* Channel
            if (rec)
            {
                SendCommand(0x1A, 0x09, new byte[1] { 0x01 });
            }
            else
            {
                SendCommand(0x1A, 0x09, new byte[1] { 0x00 });
            }
        }
        public void SetFMSquelchMode(t_FM_SqlMode mode)
        {
            // Sets the FM Tone/Code Squelch mode for the *Main* channel.
            // Setting the actual code or tone frequency is a different command.
            switch (mode)
            {
                case t_FM_SqlMode.NONE:
                    SendCommand(0x16, 0x4b, new byte[] { 0x00 });
                    SendCommand(0x16, 0x43, new byte[] { 0x00 });
                    break;
                case t_FM_SqlMode.TSQL:
                    SendCommand(0x16, 0x4b, new byte[] { 0x00 });
                    SendCommand(0x16, 0x43, new byte[] { 0x01 });
                    break;
                case t_FM_SqlMode.DTCS:
                    SendCommand(0x16, 0x43, new byte[] { 0x00 });
                    SendCommand(0x16, 0x4b, new byte[] { 0x01 });
                    break;
                case t_FM_SqlMode.TSQL_R:
                    SendCommand(0x16, 0x4b, new byte[] { 0x00 });
                    SendCommand(0x16, 0x43, new byte[] { 0x02 });
                    break;
                case t_FM_SqlMode.DTCS_R:
                    SendCommand(0x16, 0x43, new byte[] { 0x00 });
                    SendCommand(0x16, 0x4b, new byte[] { 0x02 });
                    break;
            }
        }
        public void SetAFCStatus(bool onoff)
        {
            // Sets the Automatic Frequency Correction option for FM mode on the *Main*
            // channel.
            byte bOnOff;
            if (onoff)
            {
                bOnOff = 0x01;
            }
            else
            {
                bOnOff = 0x00;
            }
            SendCommand(0x16, 0x4a, new byte[] { bOnOff });
        }
        public void ReqFMTSQLFreq()
        {
            // Get the FM Tone Squelch frequency for the *Main* channel.
            SendCommand(0x1B, 0x01, new byte[0]);
        }
        public void ReqFMDTCSCode()
        {
            // Get the DTCS Code for the *Main* channel
            SendCommand(0x1B, 0x02, new byte[0]);
        }
        public void SetFMTSQLFreq(string sFreq)
        {
            // SET the Tone Squelch frequency for the *Main* channel
            byte[] bFreq = Utils.UIntToFauxHex(Convert.ToUInt32(sFreq.Replace(".", "")), 2);
            SendCommand(0x1B, 0x01, new byte[] { 0x00, bFreq[0], bFreq[1] });
        }
        public void SetFMDTCSCode(string sCode, byte bPolarity)
        {
            // SET the DTCS code for the *Main* channel
            byte[] bCode = Utils.UIntToFauxHex(Convert.ToUInt32(sCode), 2);
            SendCommand(0x1B, 0x02, new byte[] { bPolarity, bCode[0], bCode[1] });
        }

        #region Event Subscription Requests
        public void ReqEvScanConditionChange()
        {
            // Requests Scan condition updates when the conditions change on
            // the *Main* channel so we don't have to ask for it.
            SendCommand(0x1A, 0x0B, new byte[] { 0x00, 0x01 });
        }
        public void ReqEvDisplayChangeReport()
        {
            // Requests Display Update updates when the conditions change on
            // the *Main* channel so we don't have to ask for it.
            // This is not particularly reliable.
            SendCommand(0x1A, 0x10, new byte[] { 0x00, 0x01 });
        }
        public void ReqEvDSTAR_CallSign()
        {
            // Requests D-STAR Call Sign updates when the conditions change on
            // the *Main* channel so we don't have to ask for it.
            SendCommand(0x20, 0x00, new byte[] { 0x00, 0x01 });
        }
        public void ReqEvDSTAR_Message()
        {
            // Requests D-STAR Message updates when the conditions change on
            // the *Main* channel so we don't have to ask for it.
            SendCommand(0x20, 0x01, new byte[] { 0x00, 0x01 });
        }
        public void ReqEvDSTAR_RXStatus()
        {
            // Requests D-STAR RX Status updates when the conditions change on
            // the *Main* channel so we don't have to ask for it.
            SendCommand(0x20, 0x02, new byte[] { 0x00, 0x01 });
        }
        public void ReqEvDSTAR_GPSData()
        {
            // Requests D-STAR GPS Data updates when the conditions change on
            // the *Main* channel so we don't have to ask for it.
            SendCommand(0x20, 0x03, new byte[] { 0x00, 0x01 });
        }
        public void ReqEvDSTAR_GPSMessage()
        {
            // Requests D-STAR GPS Message updates when the conditions change on
            // the *Main* channel so we don't have to ask for it.
            SendCommand(0x20, 0x04, new byte[] { 0x00, 0x01 });
        }
        public void ReqEvDSTAR_CSQLCode()
        {
            // Requests CSQL Code updates when the conditions change on
            // the *Main* channel so we don't have to ask for it.
            SendCommand(0x20, 0x05, new byte[] { 0x00, 0x01 });
        }
        public void ReqEvP25_ID()
        {
            // Requests P25 ID updates when the conditions change on
            // the *Main* channel so we don't have to ask for it.
            SendCommand(0x20, 0x06, new byte[] { 0x00, 0x01 });
        }
        public void ReqEvP25_RXStatus()
        {
            // Requests P25 RXStatus updates when the conditions change on
            // the *Main* channel so we don't have to ask for it.
            SendCommand(0x20, 0x07, new byte[] { 0x00, 0x01 });
        }
        public void ReqEvdPMR_RXID()
        {
            // Requests dPMR ID updates when the conditions change on
            // the *Main* channel so we don't have to ask for it.
            SendCommand(0x20, 0x08, new byte[] { 0x00, 0x01 });
        }
        public void ReqEvdPMR_RXStatus()
        {
            // Requests dPMR RXStatus updates when the conditions change on
            // the *Main* channel so we don't have to ask for it.
            SendCommand(0x20, 0x09, new byte[] { 0x00, 0x01 });
        }
        public void ReqEvNXDN_RXID()
        {
            // Requests NXDN ID updates when the conditions change on
            // the *Main* channel so we don't have to ask for it.
            SendCommand(0x20, 0x0A, new byte[] { 0x00, 0x01 });
        }
        public void ReqEvNXDN_RXStatus()
        {
            // Requests NXDN RXStatus updates when the conditions change on
            // the *Main* channel so we don't have to ask for it.
            SendCommand(0x20, 0x0B, new byte[] { 0x00, 0x01 });
        }
        public void ReqEvDCR_RXID()
        {
            // Requests DCR ID updates when the conditions change on
            // the *Main* channel so we don't have to ask for it.
            SendCommand(0x20, 0x0C, new byte[] { 0x00, 0x01 });
        }
        public void ReqEvDCR_RXStatus()
        {
            // Requests DCR RXStatus updates when the conditions change on
            // the *Main* channel so we don't have to ask for it.
            SendCommand(0x20, 0x0D, new byte[] { 0x00, 0x01 });
        }

        #endregion

        #endregion
        #region SendCommand Variants
        // This needs to be reworked. As I was going along, the CI-V command listing keeps adding
        // new sub, and sub-sub commands to their command set. So we have overloads.
        public void SendCommand(byte cmd, byte subcmd, byte[] data)
        {
            if (SerialInterface != null)
            {
                byte[] msg = new byte[7 + data.Length];
                msg[0] = 0xFE;
                msg[1] = 0xFE;
                msg[2] = R30_ID;
                msg[3] = 0x00;
                msg[4] = cmd;
                msg[5] = subcmd;
                System.Buffer.BlockCopy(data, 0, msg, 6, data.Length);
                msg[msg.Length - 1] = 0xFD;
                SerialData sd = new SerialData();
                sd.ts = DateTime.Now;
                sd.len = msg.Length;
                sd.data = msg;

                SerialInterface.TXQueue.Enqueue(sd);

            }
        }
        public void SyncSendCommand(byte cmd, byte subcmd, byte[] data)
        {
            if (SerialInterface != null)
            {
                byte[] msg = new byte[7 + data.Length];
                msg[0] = 0xFE;
                msg[1] = 0xFE;
                msg[2] = R30_ID;
                msg[3] = 0x00;
                msg[4] = cmd;
                msg[5] = subcmd;
                System.Buffer.BlockCopy(data, 0, msg, 6, data.Length);
                msg[msg.Length - 1] = 0xFD;

                SerialInterface.SyncWrite(msg);
            }
        }

        public void SyncSendCommand(byte cmd, byte[] data)
        {
            if (SerialInterface != null)
            {
                byte[] msg = new byte[6 + data.Length];
                msg[0] = 0xFE;
                msg[1] = 0xFE;
                msg[2] = R30_ID;
                msg[3] = 0x00;
                msg[4] = cmd;
                System.Buffer.BlockCopy(data, 0, msg, 5, data.Length);
                msg[msg.Length - 1] = 0xFD;

                SerialInterface.SyncWrite(msg);
            }
        }
        public void SendCommand(byte cmd, byte[] data)
        {
            if (SerialInterface != null)
            {
                byte[] msg = new byte[6 + data.Length];
                msg[0] = 0xFE;
                msg[1] = 0xFE;
                msg[2] = R30_ID;
                msg[3] = 0x00;
                msg[4] = cmd;
                System.Buffer.BlockCopy(data, 0, msg, 5, data.Length);
                msg[msg.Length - 1] = 0xFD;
                SerialData sd = new SerialData();
                sd.ts = DateTime.Now;
                sd.len = msg.Length;
                sd.data = msg;
                SerialInterface.TXQueue.Enqueue(sd);
            }
        }
        public void SendCommand(byte cmd, byte subcmd, byte[] data, DateTime ts)
        {
            if (SerialInterface != null)
            {
                if (ts == null) ts = DateTime.Now;
                byte[] msg = new byte[7 + data.Length];
                msg[0] = 0xFE;
                msg[1] = 0xFE;
                msg[2] = R30_ID;
                msg[3] = 0x00;
                msg[4] = cmd;
                msg[5] = subcmd;
                System.Buffer.BlockCopy(data, 0, msg, 6, data.Length);
                msg[msg.Length - 1] = 0xFD;
                SerialData sd = new SerialData();
                sd.ts = ts;
                sd.len = msg.Length;
                sd.data = msg;
                SerialInterface.TXQueue.Enqueue(sd);
            }
        }
        public void SendCommand(byte cmd, byte[] data, DateTime ts)
        {
            // Timestamps aren't currently used for anything, but this function exists in case
            // I Dequeue a packet and need to re-queue it for later. The idea was to preserve ordering
            // or even allow scheduled packets in the TX Queue.
            if (SerialInterface != null)
            {
                if (ts == null) ts = DateTime.Now;
                byte[] msg = new byte[6 + data.Length];
                msg[0] = 0xFE;
                msg[1] = 0xFE;
                msg[2] = R30_ID;
                msg[3] = 0x00;
                msg[4] = cmd;
                System.Buffer.BlockCopy(data, 0, msg, 5, data.Length);
                msg[msg.Length - 1] = 0xFD;
                SerialData sd = new SerialData();
                sd.ts = ts;
                sd.len = msg.Length;
                sd.data = msg;
                SerialInterface.TXQueue.Enqueue(sd);
            }
        }
        #endregion

        public Dictionary<uint, short> GetSigLevels(uint CenterFreq, uint BW, int Step)
        {
            Dictionary<uint, short> sValues = new Dictionary<uint, short>();
            uint startFreq = (CenterFreq - (BW / 2));
            uint stopFreq = (CenterFreq + (BW / 2));
            uint curFreq = startFreq;
            SetRFAB(0x00);
            SetReceiveMode(t_ReceiveMode.AM_N);
            SetSquelchLvl(0x00);
            Thread.Sleep(100);
            SerialInterface.SyncMode = true;

            while (curFreq <= stopFreq)
            {
                SyncSendCommand(0x00, Utils.PackFreq(curFreq));
                Thread.Sleep(10);
                SyncSendCommand(0x15, 0x02, new byte[0]);
                byte[] bSmeterResp = SerialInterface.SyncRead();
                byte[] bSmeter = new byte[2];
                System.Buffer.BlockCopy(bSmeterResp, 6, bSmeter, 0, 2);
                short sSmeterLvl = (short)Utils.FauxHexToUInt(bSmeter);
                sValues.Add(curFreq, sSmeterLvl);
                curFreq = (uint)(curFreq + Step);
            }
            SerialInterface.SyncMode = false;
            return sValues;
        }

        public short GetSigLevel(uint Frequency)
        {
            SyncSendCommand(0x00, Utils.PackFreq(Frequency));
            Thread.Sleep(1);
            SyncSendCommand(0x15, 0x02, new byte[0]);
            byte[] bSmeterResp = SerialInterface.SyncRead();
            byte[] bSmeter = new byte[2];
            System.Buffer.BlockCopy(bSmeterResp, 6, bSmeter, 0, 2);
            short sSmeterLvl = (short)Utils.FauxHexToUInt(bSmeter);
            return sSmeterLvl;
        }

    }
    public class MemoryGroups
    {
        public bool InitComplete;
        public MemoryGroups()
        {
            Group = new t_MemoryGroup[100];
            for (int i = 0; i  < 100; i++)
            {
                Group[i].Entries = new t_MemEntry[100];
                Group[i].CanScan = true;
            }
        }
        public t_MemoryGroup[] Group;
        public struct t_MemoryGroup
        {
            public string Name;
            public int Number;
            public t_MemEntry[] Entries;
            public bool CanScan;
        }
        public struct t_MemEntry
        {
            public string Name;
            public int Number;
            public int Skip;
        }
    }
    public class ProgramEdges
    {
        public struct t_ScanEdge
        {
            public uint StartFreq;
            public uint StopFreq;
            public bool skip;
            public int Number;
            public string Name;
            public bool CanScan;
        }
        public bool InitComplete;
        public t_ScanEdge[] ScanEdges;
        public ProgramEdges()
        {
            ScanEdges = new t_ScanEdge[50];
            for (int i = 0; i < 50; i++)
            {
                ScanEdges[i] = new t_ScanEdge();
                ScanEdges[i].CanScan = true;
            }
        }
    }

    

}
