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

namespace Server
{
    public partial class frm_SendAll : Form
    {
        public List<clientManager> lstClient;
        public frm_SendAll()
        {
            InitializeComponent();
        }

        private void sendAll(string msg)
        {
            foreach (clientManager client in lstClient)
            {
                if (client._tcpClient.Connected)
                {
                    TcpClient tcpClient = client._tcpClient;
                    NetworkStream netStream = tcpClient.GetStream();
                    byte[] buffer = Encoding.UTF8.GetBytes(msg+"|");
                    netStream.Write(buffer, 0, buffer.Length);
                    netStream.Flush();
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string msg = "SENDALL|"+rtxtMsg.Text;
            sendAll(msg);
            rtxtMsg.Clear();
        }

        private void frm_SendAll_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
