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
using System.Xml;

namespace Server
{
    public partial class frm_Server : Form
    {
        public List<clientManager> _lstClient;

        TcpListener _tcpListener;
        TcpClient _tcpClient;
        Thread _thread;

        clientManager _clientMng;
        IPAddress _svrIP;
        int _svrPort;
        int _svrPortRM;
        int _id;

        public frm_Server()
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

        private void listener()
        {
            _id = 1;
            try
            {
                _tcpListener = new TcpListener(_svrIP, _svrPort);
                _tcpListener.Start();
                lbl_Info.Text = "SERVER - IP: " + _svrIP + "; PORT: " + _svrPort + "; PORT REMOTE: " + _svrPortRM;
                while (true)
                {
                    _tcpClient = _tcpListener.AcceptTcpClient();
                    _clientMng = new clientManager(_id, _tcpClient);
                    dataGridView.Rows.Add(_id, "", "", "");
                    _clientMng._thread = new Thread(doListen);
                    _clientMng._thread.Start();
                    _lstClient.Add(_clientMng);
                    Thread.Sleep(1000);
                    _id++;
                }
            }
            catch
            {
                int error = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
                if (error != 10004)
                {
                    lbl_Info.Text = "";
                    MessageBox.Show("Lỗi khởi tạo Server!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void doListen()
        {
            TcpClient tcpClient = _tcpClient;
            clientManager client = _clientMng;
            NetworkStream netStream = tcpClient.GetStream();
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[tcpClient.ReceiveBufferSize];
                    netStream.Read(buffer, 0, tcpClient.ReceiveBufferSize);
                    string receive = Encoding.UTF8.GetString(buffer).Trim();
                    string[] spl = receive.Split('|');
                    switch (spl[0].ToUpper())
                    {
                        case "NAME":
                            for (int i = 0; i < dataGridView.Rows.Count; i++)
                            {
                                if (Equals(dataGridView.Rows[i].Cells[0].Value.ToString(), client._id.ToString()))
                                {
                                    dataGridView.Rows[i].Cells[1].Value = spl[1];
                                    break;
                                }
                            }
                            break;
                        case "IP":
                            for (int i = 0; i < dataGridView.Rows.Count; i++)
                            {
                                if (Equals(dataGridView.Rows[i].Cells[0].Value.ToString(), client._id.ToString()))
                                {
                                    dataGridView.Rows[i].Cells[2].Value = spl[1];
                                    break;
                                }
                            }
                            break;
                        case "USB":
                            for (int i = 0; i < dataGridView.Rows.Count; i++)
                            {
                                if (Equals(dataGridView.Rows[i].Cells[0].Value.ToString(), client._id.ToString()))
                                {
                                    dataGridView.Rows[i].Cells[3].Value = spl[1];
                                    break;
                                }
                            }
                            break;
                        case "EXIT":
                            for (int i = 0; i < dataGridView.Rows.Count; i++)
                            {
                                if (Equals(dataGridView.Rows[i].Cells[0].Value.ToString(), client._id.ToString()))
                                {
                                    string name = dataGridView.Rows[i].Cells[1].Value.ToString();
                                    string ip = dataGridView.Rows[i].Cells[2].Value.ToString();
                                    MessageBox.Show("Máy: " + name + "; Địa chỉ IP: " + ip + " đã ngắt kết nối do người dùng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    if (String.IsNullOrEmpty(dataGridView.Rows[i].Cells[3].Value.ToString()))
                                        dataGridView.Rows[i].Cells[3].Value = "Đã ngắt kết nối";
                                    else
                                        dataGridView.Rows[i].Cells[3].Value = dataGridView.Rows[i].Cells[3].Value.ToString() + "; Đã ngắt kết nối";
                                    break;
                                }
                            }
                            break;
                        case "CHAT":
                            sendMsg("RESEND|" + receive,client._tcpClient);
                            break;
                    }
                }
                catch
                {
                    client._thread.Abort();    
                }
            }
        }

        private void sendMsg(string msg, TcpClient tcp)
        {
            TcpClient tcpClient = tcp;
            NetworkStream netStream = tcpClient.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(msg + "|");
            netStream.Write(buffer, 0, buffer.Length);
            netStream.Flush();
        }

        private int getId()
        {
            try
            {
                return int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString());
            }
            catch { }
            return 0;
        }

        private clientManager searchClient(int id)
        {
            foreach (clientManager client in _lstClient)
            {
                if (client._id == id)
                {
                    return client;
                }
            }
            return null;
        }
        #endregion

        #region event
        private void frm_Server_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            loadCfg();
            _thread = new Thread(listener);
            _thread .Start();
            _lstClient = new List<clientManager>();
        }

        private void frm_Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
            else
            {
                try
                {
                    foreach (clientManager client in _lstClient)
                    {
                        try
                        {
                            sendMsg("EXIT|", client._tcpClient);
                            if (client._mouse)
                                sendMsg("MOUSE_ENA|", client._tcpClient);
                            client._thread.Abort();
                        }
                        catch { }
                    }
                    _thread.Abort();
                    _tcpListener.Stop();
                }
                catch { }
            }
        }

        private void remoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = getId();
            if (id != 0)
            {
                clientManager client = searchClient(id);
                if (client != null)
                {
                    sendMsg("REMOTE|", client._tcpClient);
                    frm_Remote remote = new frm_Remote(_svrIP, _svrPortRM, client._tcpClient);
                    remote.ShowDialog();
                }
            }
            else
                MessageBox.Show("Chọn máy cần thao tác!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void chatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = getId();
            if (id != 0)
            {
                clientManager client = searchClient(id);
                if (client != null)
                {
                    TcpClient tcpClient = client._tcpClient;
                    frm_Chat frmChat = new frm_Chat();
                    frmChat.tcpClient = tcpClient;
                    frmChat.ShowDialog();
                    frmChat.Dispose();
                }
            }
            else
                MessageBox.Show("Chọn máy cần thao tác!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void mouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = getId();
            if (id != 0)
            {
                clientManager client = searchClient(id);
                if (client != null)
                {
                    if (!client._mouse)
                    {
                        client._mouse = true;
                        mouseToolStripMenuItem.Text = "Khóa chuột và phím (Đã khóa)";
                        sendMsg("MOUSE_DIS|", client._tcpClient);
                    }
                    else
                    {
                        client._mouse = false;
                        mouseToolStripMenuItem.Text = "Khóa chuột và phím";
                        sendMsg("MOUSE_ENA|", client._tcpClient);
                    }
                }
            }else
                MessageBox.Show("Chọn máy cần thao tác!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = getId();
            if (id != 0)
            {
                clientManager client = searchClient(id);
                if (client != null)
                {
                    sendMsg("RESTART|", client._tcpClient);
                }
            }else
                MessageBox.Show("Chọn máy cần thao tác!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void shutdownToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int id = getId();
            if (id != 0)
            {
                clientManager client = searchClient(id);
                if (client != null)
                {
                    sendMsg("SHUTDOWN|", client._tcpClient);
                }
            }
            else
                MessageBox.Show("Chọn máy cần thao tác!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void sendAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_SendAll frmSendAll = new frm_SendAll();
            frmSendAll.lstClient = this._lstClient;
            frmSendAll.ShowDialog();
            frmSendAll.Dispose();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Setting frmSetting = new frm_Setting();
            frmSetting.ShowDialog();
            frmSetting.Dispose();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (clientManager client in _lstClient)
                {
                    try
                    {
                        sendMsg("EXIT|", client._tcpClient);
                        if (client._mouse)
                            sendMsg("MOUSE_ENA|", client._tcpClient);
                        client._thread.Abort();
                    }
                    catch { }
                }
                _tcpListener.Stop();
                _thread.Abort();
                dataGridView.Rows.Clear();
            }
            catch { }
            frm_Server_Load(sender, e);
        }
        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}

public class clientManager
{
    public int _id;
    public TcpClient _tcpClient;
    public Thread _thread;
    public bool _mouse = false;

    public clientManager(int id, TcpClient tcpClient)
    {
        this._id = id;
        this._tcpClient = tcpClient;
    }
}