using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;
using System.Threading;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ICR30
{
    public class PacketDataEventArgs : EventArgs
    {
        public SerialData serialData { get; set; }
        public PacketDataEventArgs()
        {
            serialData = new SerialData();
        }
    }
    
    // The message structure included in packet receipt events.
    public struct SerialData
    {
        public DateTime ts;
        public int len;
        public byte[] data;
        public bool RFB;
    }


    public class SerialPortHandler
    {
        // COM Port Defaults
        public string COMPort = "COM4";
        public int COMBaudRate = 9600;
        public Parity COMParity = Parity.None;
        public int COMDataBits = 8;
        public int COMStartBits = 1;
        public StopBits COMStopBits = StopBits.One;
        public Handshake COMHandshake = Handshake.None;

        // Debug flag
        public bool DebugMode = true;

        // Sync Mode Flag
        public bool SyncMode = false;

        // Flag to let consumer know connection status.
        public bool IsConnected = false;

        // Buffer for partial messages awaiting completion.
        public byte[] inputBuffer;

        // Event Handler for Receiving completed packets from queue.
        public event EventHandler<PacketDataEventArgs> PacketReceipt;

        // Public flag for when we are shutting down.
        public bool ExitRequested = false;

        // TX and RX Packet Queues
        public ConcurrentQueue<SerialData> RXQueue;
        public ConcurrentQueue<SerialData> TXQueue;

        // Reader thread that builds messages and drops them into RX Queue
        private Thread tReader;

        // Writer thread services TX Queue and transmits serial data.
        private Thread tWriter;

        // RXQ Thread services the completed RX packets, firing events for each.
        private Thread tRXQ;

        private SerialPort sp;

        public int Open()
        {
            // Reset Exit flag on new connections
            ExitRequested = false;

            // Instantiate new Serial Port and configure it.
            sp = new SerialPort();
            sp.PortName = COMPort;
            sp.BaudRate = COMBaudRate;
            sp.Parity = COMParity;
            sp.DataBits = COMDataBits;
            sp.StopBits = COMStopBits;
            sp.Handshake = COMHandshake;
            sp.ReadTimeout = 6000;
            sp.WriteTimeout = 6000;

            // Re-Initialize empty buffer for partial messages in case
            // there were any leftover bytes from last connection.
            inputBuffer = new byte[0];

            // Create/Recreate empty queues
            RXQueue = new ConcurrentQueue<SerialData>();
            TXQueue = new ConcurrentQueue<SerialData>();

            // Create worker threads.
            tReader = new Thread(Read);
            tWriter = new Thread(Write);
            tRXQ = new Thread(RXQRunner);

            try
            {
                // Open serial port
                sp.Open();
            }
            catch (Exception e)
            {
                if (DebugMode) Console.WriteLine("sp.Open: " + e.Message);
                return 0;
            }

            // Set connected flag.
            IsConnected = true;

            // Start worker threads
            tReader.Start();
            tWriter.Start();
            tRXQ.Start();

            return 1;
        }

        public string[] GetPortList()
        {
            // Just return a list of COM ports
            return SerialPort.GetPortNames();
        }
        private void Read()
        {
            // The main read loop. Collects incoming bytes, and passes them to the message parser.
            while (!ExitRequested)
            {
                // Only proceed if port is actually in open state.
                if(sp.IsOpen)
                {
                    if (sp.BytesToRead > 0 && !SyncMode)
                    {
                        // Read whatever bytes are available. Note that this property is sometimes not
                        // accurate and will leave bytes behind. That's okay as we will pick them up next time.
                        byte[] readBuf = new byte[sp.BytesToRead];
                        try
                        {
                            sp.Read(readBuf, 0, sp.BytesToRead);
                        }
                        catch (Exception e)
                        {
                            if (DebugMode) Console.WriteLine("sp.Read: " + e.Message);
                        }
                        GetMsgsFromBufffer(readBuf);
                    }
                }
                else
                {
                    // If Serial Port has closed, we set IsConnected to false to trigger teardown
                    // of the serial connection, and let all worker threads know to shut down via
                    // ExitRequested = true.
                    IsConnected = false;
                    ExitRequested = true;
                    if (DebugMode) Console.WriteLine("Read() sp.IsOpen: == false");
                }
                Thread.Sleep(50);
            }
        }

        private int GetMsgsFromBufffer(byte[] datain)
        {
            // Message parser. Saves previous unconsumed bytes until it hits message end.
            // Here we append the newly received bytes to that buffer.
            inputBuffer = Utils.AppendByteArrray(inputBuffer, datain);
            byte[] msg = new byte[0];
            int msgcounter = 0;
            foreach (byte b in inputBuffer)
            {
                // Messages end with 0xFD, so we package this message up and add to queue.
                if (b == 0xfd)
                {
                    msg = Utils.AddByteToArray(msg, b);
                    SerialData tmpmsg = new SerialData();
                    tmpmsg.ts = DateTime.Now;
                    tmpmsg.len = msg.Length;
                    tmpmsg.data = msg;
                    if (DebugMode) Console.Write(" <- " + Utils.PrintByteArray(msg));
                    RXQueue.Enqueue(tmpmsg);
                    msg = new byte[0];
                    msgcounter++;
                }
                else
                {
                    // If it isn't an end of message, continue message.
                    msg = Utils.AddByteToArray(msg, b);
                    
                }
            }

            // Clear message buffer, since these bytes were consumed in the message.
            inputBuffer = new byte[0];

            // And if there are bytes left in message with no end, drop them all back into
            // the input buffer for the next round.
            if (msg.Length > 0)
            {
                inputBuffer = msg;
            }
            return msgcounter;
        }

        private void RXQRunner()
        {
            // This function is a separate thread that takes messages/packets from the RX Queue
            // and sends them in events back to the main form.
            while (!ExitRequested)
            {
                while(RXQueue.Count > 0)
                {
                    SerialData sd;
                    if (RXQueue.TryDequeue(out sd))
                    {
                        PacketDataEventArgs sdev = new PacketDataEventArgs();
                        sdev.serialData = sd;

                        PacketReceipt?.Invoke(this, sdev);
                    }
                }
                Thread.Sleep(1);
            }
        }

        
        private void Write()
        {
            // This function is a poorly named thread that works the TX queue, sending packets
            // that were dropped in the queue by various functions.
            while(!ExitRequested)
            {
                if(TXQueue.Count > 0 && !SyncMode)
                {
                    SerialData outData;
                    if(TXQueue.TryDequeue(out outData))
                    {
                        try
                        {
                            sp.Write(outData.data, 0, outData.len);
                        }
                        catch(Exception ex)
                        {
                            // Trigger stoppage of all worker threads with ExitRequested = true and
                            // trigger serial teardown via IsConnected = false flag.
                            if (DebugMode) Console.WriteLine("sp.Write: " + ex.Message);
                            ExitRequested = true;
                            IsConnected = false;
                            return;
                        }
                        if (DebugMode) Console.Write(" -> " + Utils.PrintByteArray(outData.data));
                    }
                }
                Thread.Sleep(1);
            }
        }

        public byte[] SyncRead()
        {
            bool msgEnd = false;
            byte[] msgbuffer = new byte[0];
            while (msgEnd == false)
            {
                if (sp.BytesToRead > 0)
                {
                    // Read whatever bytes are available. Note that this property is sometimes not
                    // accurate and will leave bytes behind. That's okay as we will pick them up next time.
                    byte[] readBuf = new byte[1];
                    try
                    {
                        sp.Read(readBuf, 0, 1);
                        
                    }
                    catch (Exception e)
                    {
                        if (DebugMode) Console.WriteLine("sp.Read: " + e.Message);
                    }
                    if(readBuf[0] == 0xFD)
                    {
                        msgEnd = true;
                        msgbuffer = Utils.AddByteToArray(msgbuffer, readBuf[0]);
                    }
                    else
                    {
                        msgbuffer = Utils.AddByteToArray(msgbuffer, readBuf[0]);
                    }
                }
            }
            if (DebugMode) Console.Write(" <--- " + Utils.PrintByteArray(msgbuffer));
            return msgbuffer;
        }

        public bool SyncWrite(byte[] bData)
        {
            try
            {
                if (DebugMode) Console.Write(" ---> " + Utils.PrintByteArray(bData));
                sp.Write(bData, 0, bData.Length);
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
        public int Close()
        {
            try
            {
                // Clean up any threads that are still running on close.
                if (tReader != null ) tReader.Abort();
                if (tWriter != null) tWriter.Abort();
                if (tRXQ != null) tRXQ.Abort();
                if (sp != null) sp.Close();
                IsConnected = false;
            }
            catch(Exception e)
            {
                return 0;
            }
            return 1;
        }
    }
}
