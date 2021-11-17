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

namespace Server
{
    public partial class frm_Chat : Form
    {
        public TcpClient tcpClient;
        Thread thread;
        public frm_Chat()
        {
            InitializeComponent();
        }

        private void sendMsg(string msg)
        {
            NetworkStream netStream = tcpClient.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            netStream.Write(buffer, 0, buffer.Length);
            netStream.Flush();
        }

        private void receiveMsg()
        {
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
                        case "CHAT":
                            rtxt_Messeage.AppendText("\n" + spl[1]);
                            rtxt_Messeage.Select(rtxt_Messeage.Text.Length, 0);
                            rtxt_Messeage.ScrollToCaret();
                            break;
                        default:
                            sendMsg("RESEND|" + receive);
                            break;
                    }
                }
                catch
                {
                    break;
                }
            }
            this.Close();
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            string msg = "CHAT|Server: " + txt_Message.Text;
            sendMsg(msg);
            rtxt_Messeage.AppendText("\nServer: " + txt_Message.Text);
            rtxt_Messeage.Select(rtxt_Messeage.Text.Length, 0);
            rtxt_Messeage.ScrollToCaret();
            txt_Message.Clear();
        }

        private void frm_Chat_Load(object sender, EventArgs e)
        {
            sendMsg("CHATON|");
            thread = new Thread(receiveMsg);
            thread.Start();
        }

        private void frm_Chat_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                sendMsg("CHATOFF|");
                thread.Abort();
            }
            catch { }
            this.Dispose();
        }

        private void txt_Message_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Send_Click(sender, e);
            }
        }

    }
}
