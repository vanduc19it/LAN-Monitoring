using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Xml;

namespace Client
{
    public partial class frm_Client : Form
    {
        TcpClient _tcpClient;
        Thread _thread, _threadRM;
        String str_response = "echo";
        IPAddress _svrIP;
        int _svrPort;
        int _svrPortRM;
        bool _exit = false;

        public frm_Client()
        {
            InitializeComponent();
        }

        #region function
        private void loadCfg()
        {
            try
            {
                XmlDocument config = new XmlDocument();
                string path = Application.StartupPath + @"\config.xml";
                config.Load(path);
                _svrIP = IPAddress.Parse(config.SelectSingleNode("//ip").InnerText);
                _svrPort = Int32.Parse(config.SelectSingleNode("//port").InnerText);
                _svrPortRM = Int32.Parse(config.SelectSingleNode("//portRM").InnerText);
            }
            catch
            {
                frm_Setting frmSetting = new frm_Setting();
                frmSetting.ShowDialog();
                frmSetting.Dispose();
            }
        }

        private void connect()
        {
            try
            {
                _tcpClient = new TcpClient();
                _tcpClient.Connect(_svrIP, _svrPort);
                sendInfo();
                _thread = new Thread(doListen);
                _thread.Start();
                lbl_Info.Text = "Đã kết nối đến Server - " + _svrIP;
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến Server!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void sendInfo()
        {
            string msg;
            msg = "NAME|" + Dns.GetHostName();
            sendMsg(msg);
            Thread.Sleep(1000);
            IPEndPoint ipEP = (IPEndPoint)_tcpClient.Client.RemoteEndPoint;
            IPAddress ipAdd = ipEP.Address;
            msg = "IP|" + ipAdd.ToString();
            sendMsg(msg);
        }

        private void doListen()
        {
            NetworkStream netStream = _tcpClient.GetStream();
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[_tcpClient.ReceiveBufferSize];
                    netStream.Read(buffer, 0, _tcpClient.ReceiveBufferSize);
                    string receive = Encoding.UTF8.GetString(buffer).Trim();
                    string[] spl = receive.Split('|');
                    switch (spl[0].ToUpper())
                    {
                        case "CHAT":
                            rtxt_Messeage.AppendText("\n" + spl[1]);
                            rtxt_Messeage.Select(rtxt_Messeage.Text.Length, 0);
                            rtxt_Messeage.ScrollToCaret();
                            break;
                        case "CHATON":
                            txt_Message.Enabled = true;
                            btn_Send.Enabled = true;
                            break;
                        case "CHATOFF":
                            txt_Message.Clear();
                            txt_Message.Enabled = false;
                            btn_Send.Enabled = false;
                            break;
                        case "MOUSE_DIS":
                            BlockInput(true);
                            break;
                        case "MOUSE_ENA":
                            BlockInput(false);
                            break;
                        case "RESTART":
                            sendMsg("EXIT");
                            _exit = true;
                            Process pro_res = new Process();
                            ProcessStartInfo proInfo_res = new ProcessStartInfo();
                            proInfo_res.WindowStyle = ProcessWindowStyle.Hidden;
                            proInfo_res.FileName = "shutdown.exe";
                            proInfo_res.Arguments = "/f -r -t 00";
                            pro_res.StartInfo = proInfo_res;
                            pro_res.Start();
                            this.Close();
                            break;
                        case "SHUTDOWN":
                            sendMsg("EXIT");
                            _exit = true;
                            Process pro_shut = new Process();
                            ProcessStartInfo proInfo_shut = new ProcessStartInfo();
                            proInfo_shut.WindowStyle = ProcessWindowStyle.Hidden;
                            proInfo_shut.FileName = "shutdown.exe";
                            proInfo_shut.Arguments = "/f -s -t 00";
                            pro_shut.StartInfo = proInfo_shut;
                            pro_shut.Start();
                            this.Close();
                            break;
                        case "REMOTE":
                            _threadRM = new Thread(remote);
                            _threadRM.Start();
                            break;
                        case "MOUSE_LEFT":
                            SetCursorPos(int.Parse(spl[1]), int.Parse(spl[2]));
                            mouseLeft(int.Parse(spl[1]), int.Parse(spl[2]));
                            break;
                        case "MOUSE_RIGHT":
                            SetCursorPos(int.Parse(spl[1]), int.Parse(spl[2]));
                            mouseRight(int.Parse(spl[1]), int.Parse(spl[2]));
                            break;
                        case "MOUSE_DLEFT":
                            SetCursorPos(int.Parse(spl[1]), int.Parse(spl[2]));
                            mouseLeft(int.Parse(spl[1]), int.Parse(spl[2]));
                            mouseLeft(int.Parse(spl[1]), int.Parse(spl[2]));
                            break;
                        case "MOUSE_DRIGHT":
                            SetCursorPos(int.Parse(spl[1]), int.Parse(spl[2]));
                            mouseRight(int.Parse(spl[1]), int.Parse(spl[2]));
                            mouseRight(int.Parse(spl[1]), int.Parse(spl[2]));
                            break;
                        case "MOUSE_MOVE":
                            SetCursorPos(int.Parse(spl[1]), int.Parse(spl[2]));
                            break;
                        case "KEY":
                            keyDown((Keys)int.Parse(spl[1]));
                            keyDown((Keys)int.Parse(spl[1]));
                            break;
                        case "EXIT":
                            lbl_Info.Text = "Server đã tắt!";
                            _thread.Abort();
                            _tcpClient.Close();
                            break;
                        case "SENDALL":
                            MessageBox.Show(spl[1], "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case "RESEND":
                            sendMsg(spl[1] + "|" + spl[2]);
                            break;
                        case "GETP":
                            DanhSachProcess();
                            break;
                        case "STP":
                            try
                            {
                                Process.Start("" + spl[1]);
                            }
                            catch
                            {
                                
                            }
                           
                            break;
                        case "KILLP":
                            var processes = Process.GetProcessesByName(spl[1]);

                            foreach (var process in processes)
                            {
                                Process.GetProcessById(process.Id).Kill();

                            }
                            break;
                    }
                }
                catch 
                {
                    _thread.Abort();
                }
            }
        }
        private void DanhSachProcess()
        {
            str_response = "";
            Process[] pAll = Process.GetProcesses();
            List<String> mList = new List<String>();

            for (int i = 1; i < pAll.Length; i++)
            {
                mList.Add(pAll[i].ProcessName);
            }

            mList.Sort();

            str_response = pAll[0].ProcessName + "";

            for (int i = 1; i < mList.Count; i++)
            {
                str_response = str_response + "@#" + mList[i];
            }
            String result = "GET|" + str_response;
            sendMsg(result);
           
        }

        private void sendMsg(string msg)
        {
            NetworkStream netStream = _tcpClient.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(msg + "|");
            netStream.Write(buffer, 0, buffer.Length);
            netStream.Flush();
        }
        #endregion

        #region mouse & key
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern uint keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        [DllImport("user32.dll",CharSet=CharSet.Auto,CallingConvention=CallingConvention.StdCall)]
        public static extern bool BlockInput([In, MarshalAs(UnmanagedType.Bool)]bool fBlockIt);
        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int X, int Y);

        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int KEYEVENTF_EXTENDEDKEY = 0x0001;
        private const int KEYEVENTF_KEYUP = 0x0002;

        private void mouseLeft(int x, int y)
        {
            mouse_event((uint)MOUSEEVENTF_LEFTDOWN, (uint)x, (uint)y, 0, 0);
            mouse_event((uint)MOUSEEVENTF_LEFTUP, (uint)x, (uint)y, 0, 0);
        }

        private void mouseRight(int x, int y)
        {
            mouse_event((uint)MOUSEEVENTF_RIGHTDOWN, (uint)x, (uint)y, 0, 0);
            mouse_event((uint)MOUSEEVENTF_RIGHTUP, (uint)x, (uint)y, 0, 0);
        }

        private void keyUp(Keys key)
        {
            keybd_event((byte)key, 0, KEYEVENTF_EXTENDEDKEY, 0);
        }

        private void keyDown(Keys key)
        {
            keybd_event((byte)key, 0, KEYEVENTF_KEYUP, 0);
        }
        #endregion

        #region usb
        private const int DBT_DEVICEARRIVAL = 0x8000;
        private const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
        private const int DBT_DEVTYP_VOLUME = 0x00000002;

        protected override void WndProc(ref Message m)
        {
            int devType;
            base.WndProc(ref m);
            switch (m.WParam.ToInt32())
            {
                case DBT_DEVICEARRIVAL:
                    devType = Marshal.ReadInt32(m.LParam, 4);
                    if (devType == DBT_DEVTYP_VOLUME)
                        sendMsg("USB|Có kết nối thiết bị ngoại vi!");
                    break;
                case DBT_DEVICEREMOVECOMPLETE:
                    devType = Marshal.ReadInt32(m.LParam, 4);
                    if (devType == DBT_DEVTYP_VOLUME)
                        sendMsg("USB|Thiết bị ngoại vi đã được tháo!");
                    break;
            }
        }
        #endregion

        #region remote
        private void remote()
        {
            TcpClient tcp = new TcpClient();
            try
            {
                tcp = new TcpClient();
                tcp.Connect(_svrIP, _svrPortRM);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến Server!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            NetworkStream netStream = tcp.GetStream();
            Bitmap bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            gfxScreenshot.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            gfxScreenshot.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            gfxScreenshot.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
            gfxScreenshot.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            BinaryFormatter format = new BinaryFormatter();
            Image image;
            while (true)
            {           
                try
                {
                    gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
                    image = bmpScreenshot;
                    format.Serialize(netStream, image);
                }
                catch
                {
                    break;
                }
            }
            _threadRM.Abort();
        }
        #endregion

        #region event
        private void frm_Client_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            loadCfg();
            connect();
        }
        
        private void frm_Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_exit)
            {
                if (MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    e.Cancel = true;
                else
                {
                    try
                    {
                        string msg = "EXIT";
                        sendMsg(msg);
                        _tcpClient.Close();
                        _thread.Abort();
                    }
                    catch { }
                    this.Dispose();
                }
            }
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            string msg = "CHAT|Client: " + txt_Message.Text;
            sendMsg(msg);
            rtxt_Messeage.AppendText("\nClient: " + txt_Message.Text);
            rtxt_Messeage.Select(rtxt_Messeage.Text.Length, 0);
            rtxt_Messeage.ScrollToCaret();
            txt_Message.Clear();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Setting _frmSetting = new frm_Setting();
            _frmSetting.ShowDialog();
            _frmSetting.Dispose();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Client_Load(sender, e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_Message_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Send_Click(sender, e);
            }
        }
        #endregion
    }
}
        