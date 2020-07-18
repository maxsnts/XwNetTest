using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace XwNetTest
{
    public partial class Main : Form
    {
        enum State
        {
            Stopped,
            Running,
            Canceling
        }

        State state = State.Stopped;
        private byte[] randomBytes = null;
        private object counterSendLock = new object();
        private long countSent = 0;
        private object counterRecvLock = new object();
        private long countRecv = 0;
        private long totalSent = 0;
        private long totalRecv = 0;
        private long blocksSent = 0;
        private long blocksRecv = 0;
        private static int chartSeconds = 120;
        private bool closing = false;
        private object connectedChannelsLock = new object();
        private int connectedChannels = 0;
        TcpListener server = null;

        Queue<long> qCountSent = new Queue<long>(chartSeconds);
        Queue<long> qCountRecv = new Queue<long>(chartSeconds);
        Queue<long> qAvgSent = new Queue<long>(chartSeconds);
        Queue<long> qAvgRecv = new Queue<long>(chartSeconds);

        //*************************************************************************************************************
        public Main()
        {
            InitializeComponent();
        }

        //*************************************************************************************************************
        private void Main_Load(object sender, EventArgs e)
        {
            string CurrentVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(
                System.Reflection.Assembly.GetAssembly(typeof(Main)).Location).FileVersion.ToString();
            Text = $"XwNetTest {CurrentVersion}";

            Update();

            comboServerIP.Items.Add("Any");
            foreach (var ip in GetAllLocalIPAddress())
                comboServerIP.Items.Add(ip);
            comboServerIP.SelectedIndex = 0;

#if DEBUG
            textClientIP.Text = "172.16.0.125";
#endif
            int maxSize = 1024 * 256;
            randomBytes = new byte[maxSize];
            Random rand = new Random();
            rand.NextBytes(randomBytes);

            chartTraffic.Titles.Clear();
            
            chartTraffic.Series.Clear();
            chartTraffic.Series.Add("Sent Instant");
            chartTraffic.Series.Add("Recv Instant");
            chartTraffic.Series.Add("Sent Average");
            chartTraffic.Series.Add("Recv Average");
            chartTraffic.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            chartTraffic.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Silver;
            chartTraffic.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;

            foreach (var serie in chartTraffic.Series)
                //serie.ChartType = SeriesChartType.Line;
                serie.ChartType = SeriesChartType.Spline;

            for (int i = 0; i < chartSeconds; i++)
            {
                qCountSent.Enqueue(0);
                qCountRecv.Enqueue(0);
                qAvgSent.Enqueue(0);
                qAvgRecv.Enqueue(0);
            }

            Pump.Start();
        }

        //*************************************************************************************************************
        private void Pump_Tick(object sender, EventArgs e)
        {
            if (state == State.Canceling && connectedChannels == 0)
            {
                state = State.Stopped;
                if (closing)
                    Close();
            }

            radioServer.Enabled = (state == State.Stopped);
            radioClient.Enabled = (state == State.Stopped);
            comboServerIP.Enabled = (state == State.Stopped && radioServer.Checked);
            textClientIP.Enabled = (state == State.Stopped && radioClient.Checked);
            numericPort.Enabled = (state == State.Stopped);
            numericChannels.Enabled = (state == State.Stopped && radioClient.Checked);
            buttonStart.Text = (state == State.Stopped) ? "Start" : "Cancel";
            labelChannels.Text = connectedChannels.ToString();
        }

        //*************************************************************************************************************
        private void textClientIP_TextChanged(object sender, EventArgs e)
        {
            if (ValidIP(textClientIP.Text))
                textClientIP.BackColor = SystemColors.Window;
            else
                textClientIP.BackColor = Color.LightSalmon;
        }

        //*************************************************************************************************************
        private string[] GetAllLocalIPAddress()
        {
            List<string> ips = new List<string>();
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ips.Add(ip.ToString());
                }
            }
            return ips.ToArray();
        }

        //*************************************************************************************************************
        private bool ValidIP(string ip)
        {
            return true;
        }

        //*************************************************************************************************************
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (state == State.Canceling)
                return;

            if (state == State.Running)
            {
                state = State.Canceling;
                if(server != null)
                    server.Stop();
                return;
            }

            if (radioServer.Checked)
            {
                IPAddress ip = IPAddress.Any;
                if (comboServerIP.SelectedItem.ToString() != "Any")
                    ip = IPAddress.Parse(comboServerIP.SelectedItem.ToString());
                int port = (int)numericPort.Value;
                object data = new object[] {
                    /*00*/this,
                    /*01*/ip,
                    /*02*/port
                    };
                Thread serverThread = new Thread(StartServer);
                serverThread.Priority = ThreadPriority.Highest;
                serverThread.Start(data);
            }
            else
            {
                if (!ValidIP(textClientIP.Text))
                {
                    MessageBox.Show("Enter a server ip to test with");
                    textClientIP.BackColor = Color.LightSalmon;
                    return;
                }
                textClientIP.BackColor = SystemColors.Window;
                string ip = textClientIP.Text;
                int port = (int)numericPort.Value;
                object data = new object[] {
                    /*00*/this,
                    /*01*/IPAddress.Parse(ip),
                    /*02*/port
                    };

                for (int t = 0; t < numericChannels.Value; t++)
                {
                    Thread clientThread = new Thread(StartClient);
                    clientThread.Priority = ThreadPriority.Highest;
                    clientThread.Start(data);
                }
            }

            Measure.Start();
        }

        //*************************************************************************************************************
        private void Measure_Tick(object sender, EventArgs e)
        {
            if (state == State.Stopped)
                return;

            // this runs every 250ms... lets pretend its a second by multiplying 
            long sent = 0;
            long recv = 0;
            lock (counterSendLock)
            {
                sent = countSent * 4;
                countSent = 0;
            }
            lock (counterRecvLock)
            {
                recv = countRecv * 4;
                countRecv = 0;
            }

            totalSent += sent;
            totalRecv += recv;

            long avgSent = 0;
            long avgRecv = 0;
            if (totalSent > 0 || totalRecv > 0)
            {
                blocksSent++;
                blocksRecv++;
                avgSent = totalSent / blocksSent;
                avgRecv = totalRecv / blocksRecv;
            }

            qCountSent.Enqueue(sent / 1024 / 1024 * 8);
            qCountRecv.Enqueue(recv / 1024 / 1024 * 8);
            qAvgSent.Enqueue(avgSent / 1024 / 1024 * 8);
            qAvgRecv.Enqueue(avgRecv / 1024 / 1024 * 8);

            labelCountSent.Text = $"{GetMBPS(sent)}/s ({GetMB(sent)}/s)";
            labelCountRecv.Text = $"{GetMBPS(recv)}/s ({GetMB(recv)}/s)";
            labelAvgSent.Text = $"{GetMBPS(avgSent)}/s ({GetMB(avgSent)}/s)";
            labelAvgRecv.Text = $"{GetMBPS(avgRecv)}/s ({GetMB(avgRecv)}/s)";
           
            chartTraffic.Series["Sent Instant"].Points.DataBindY(qCountSent.ToArray());
            chartTraffic.Series["Recv Instant"].Points.DataBindY(qCountRecv.ToArray());
            chartTraffic.Series["Sent Average"].Points.DataBindY(qAvgSent.ToArray());
            chartTraffic.Series["Recv Average"].Points.DataBindY(qAvgRecv.ToArray());

            if (qCountSent.Count > chartSeconds)
                qCountSent.Dequeue();
            if (qCountRecv.Count > chartSeconds)
                qCountRecv.Dequeue();
            if (qAvgSent.Count > chartSeconds)
                qAvgSent.Dequeue();
            if (qAvgRecv.Count > chartSeconds)
                qAvgRecv.Dequeue();
        }

        //*************************************************************************************************************
        private string GetMB(double byteCount)
        {
            string size = "0 Bytes";
            /*if (byteCount >= (1024 * 1024 * 1024))
                size = string.Format("{0:##.00}", byteCount / (1024 * 1024 * 1024)) + " GB";
            else*/ if (byteCount >= (1024 * 1024))
                size = string.Format("{0:##.00}", byteCount / (1024 * 1024)) + " MB";
            else if (byteCount >= 1024)
                size = string.Format("{0:##.00}", byteCount / 1024) + " KB";
            else if (byteCount < 1024)
                size = string.Format("{0:##}", byteCount) + " B";
            return size;
        }

        //*************************************************************************************************************
        private string GetMBPS(long byteCount)
        {
            string size = "0 Bytes";
            /*if (byteCount >= (1024 * 1024 * 1024))
                size = string.Format("{0:##.00}", (byteCount * 8) / (1024 * 1024 * 1024)) + " Gbps";
            else*/ if (byteCount >= (1024 * 1024))
                size = string.Format("{0:##.00}", (byteCount * 8) / (1024 * 1024)) + " Mbps";
            else if (byteCount >= 1024)
                size = string.Format("{0:##.00}", (byteCount * 8) / 1024) + " Kbps";
            else if (byteCount < 1024)
                size = string.Format("{0:##}", (byteCount * 8)) + " bps";
            return size;
        }

        //*************************************************************************************************************
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (state == State.Running)
            {
                state = State.Canceling;
                if (server != null)
                    server.Stop();
                closing = true;
                e.Cancel = true;
            }
        }

        //*************************************************************************************************************
        //*************************************************************************************************************
        //*************************************************************************************************************
        //*************************************************************************************************************
        public static void StartServer(object data)
        {
            object[] array = (object[])data;
            Main form = (Main)array[0];
            IPAddress ip = (IPAddress)array[1];
            int port = (int)array[2];

            form.state = State.Running;
            form.server = new TcpListener(ip, port);
            form.server.Start();
            try
            {
                while (true)
                {
                    TcpClient client = form.server.AcceptTcpClient();
                    if (form.state == State.Canceling)
                        return;
                    NetworkStream stream = client.GetStream();
                    object trdData = new object[] {
                        /*00*/form,
                        /*01*/stream
                        };
    
                    Thread sendThread = new Thread(SenderThread);
                    sendThread.Priority = ThreadPriority.Highest;
                    sendThread.Start(trdData);

                    Thread recvThread = new Thread(ReceiverThread);
                    recvThread.Priority = ThreadPriority.Highest;
                    recvThread.Start(trdData);
                }
            }
            catch (SocketException ex)
            {
                if (ex.SocketErrorCode == SocketError.AddressAlreadyInUse)
                {
                    form.state = State.Canceling;
                    MessageBox.Show("Port already in use", "XwNetTest", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //*************************************************************************************************************
        public static void StartClient(object data)
        {
            object[] array = (object[])data;
            Main form = (Main)array[0];
            IPAddress ip = (IPAddress)array[1];
            int port = (int)array[2];

            form.state = State.Running;

            TcpClient client = null;
            try
            {
                lock (form.connectedChannelsLock)
                    form.connectedChannels++;
                client = new TcpClient(ip.ToString(), port);
                NetworkStream stream = client.GetStream();
                object trdData = new object[] {
                    /*00*/form,
                    /*01*/stream
                    };

                Thread sendThread = new Thread(SenderThread);
                sendThread.Priority = ThreadPriority.Highest;
                sendThread.Start(trdData);

                Thread recvThread = new Thread(ReceiverThread);
                recvThread.Priority = ThreadPriority.Highest;
                recvThread.Start(trdData);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                lock (form.connectedChannelsLock)
                    form.connectedChannels--;
                //client.Close();
            }
        }

        //*************************************************************************************************************
        public static void SenderThread(object data)
        {
            object[] array = (object[])data;
            Main form = (Main)array[0];
            NetworkStream stream = (NetworkStream)array[1];

            try
            {
                int maxPacket = 1024 * 256;
                while (true)
                {
                    stream.Write(form.randomBytes, 0, maxPacket);
                    stream.Flush();

                    lock (form.counterSendLock)
                        form.countSent += maxPacket;

                    if (form.state == State.Canceling)
                        return;
                }
            }
            catch { }
        }

        //*************************************************************************************************************
        public static void ReceiverThread(object data)
        {
            object[] array = (object[])data;
            Main form = (Main)array[0];
            NetworkStream stream = (NetworkStream)array[1];

            try
            {
                int i;
                byte[] buffer = new byte[1024 * 256];
                while ((i = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    lock (form.counterRecvLock)
                        form.countRecv += i;

                    if (form.state == State.Canceling)
                        return;
                }
            }
            catch { }
        }
    }
}
