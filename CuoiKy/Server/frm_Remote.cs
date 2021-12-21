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
using System.Runtime.Serialization.Formatters.Binary;

namespace Server
{
    public partial class frm_Remote : Form
    {
        TcpListener _tcpListener;
        TcpClient _tcpClient, _tcpClientRM;
        Thread _thread;

        IPAddress _svrIP;
        int _svrPortRM;
        int w_image, h_image;

        public frm_Remote(IPAddress ip, int port, TcpClient tcp)
        {
            InitializeComponent();
            _svrIP = ip;
            _svrPortRM = port;
            _tcpClient = tcp;
        }

        private void listener()
        {
            try
            {
                _tcpListener = new TcpListener(_svrIP, _svrPortRM);
                _tcpListener.Start();
                _tcpClientRM = _tcpListener.AcceptTcpClient();
                _thread = new Thread(doListen);
                _thread.Start();
            }
            catch
            {
                MessageBox.Show("Cổng đang được sử dụng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void doListen()
        {
            NetworkStream netStream = _tcpClientRM.GetStream();
            BinaryFormatter format = new BinaryFormatter();
            Image image;
            while (true)
            {
                try
                {
                    image = (Image)format.Deserialize(netStream);
                    w_image = image.Width;
                    h_image = image.Height;
                    pictureBox.Image = image;
                    this.Refresh();
                }
                catch
                {
                    break;
                }
            }
            this.Close();
        }
        //chup mh
        private void GrabScreen()
        {
            Rectangle rect = Screen.PrimaryScreen.Bounds;
            Bitmap bm = new Bitmap(rect.Width, rect.Height);
            Graphics g = Graphics.FromImage(bm);
            g.CopyFromScreen(0, 0, 0, 0, rect.Size);
            this.BackgroundImage = bm;
        }


        private void sendMsg(string msg)
        {
            NetworkStream netStream = _tcpClient.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(msg + "|");
            netStream.Write(buffer, 0, buffer.Length);
            netStream.Flush();
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X * w_image / pictureBox.Width;
            int y = e.Y * h_image / pictureBox.Height;
            if (e.Button == MouseButtons.Left)
                sendMsg("MOUSE_LEFT|" + x + "|" + y);
            if (e.Button == MouseButtons.Right)
                sendMsg("MOUSE_RIGHT|" + x + "|" + y);
        }


        private void pictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int x = e.X * w_image / pictureBox.Width;
            int y = e.Y * h_image / pictureBox.Height;
            if (e.Button == MouseButtons.Left)
                sendMsg("MOUSE_DLEFT|" + x + "|" + y);
            if (e.Button == MouseButtons.Right)
                sendMsg("MOUSE_DRIGHT|" + x + "|" + y);
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X * w_image / pictureBox.Width;
            int y = e.Y * h_image / pictureBox.Height;
            sendMsg("MOUSE_MOVE|" + x + "|" + y);
        }

        private void frm_Remote_KeyPress(object sender, KeyPressEventArgs e)
        {
            sendMsg("KEY|" + (int)e.KeyChar);
        }

        private void frm_Remote_Load(object sender, EventArgs e)
        {
            listener();
        }

        private void frm_Remote_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _tcpListener.Stop();
                _tcpClientRM.Close();
                _thread.Abort();
            }
            catch { }
            this.Dispose();
        }

        private void mouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mouseToolStripMenuItem.Text == "Khóa chuột và phím")
            {
                sendMsg("MOUSE_DIS|");
                mouseToolStripMenuItem.Text = "Khóa chuột và phím (Đã khóa)";
            }
            else
            {
                sendMsg("MOUSE_ENA|");
                mouseToolStripMenuItem.Text = "Khóa chuột và phím";
            }
        }

        private void chatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Chat frmChat = new frm_Chat();
            frmChat.tcpClient = _tcpClient;
            frmChat.ShowDialog();
            frmChat.Dispose();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sendMsg("RESTART|");
        }


        //chup man hinh
        private void btnchup_Click(object sender, EventArgs e)
        {
            GrabScreen();
        }
        //luu anh
        private void btnsave_Click(object sender, EventArgs e)
        {
            this.BackgroundImage.Save("Screen.png");
        }

        private void shutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sendMsg("SHUTDOWN|");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
