using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using ServiceExample;
using System.Diagnostics;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Drawing.Imaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace LAN_MOnitoring_Client
{
    public partial class ClientStart : Form
    {
        /*private readonly TcpClient client = new TcpClient();
        private NetworkStream mainStream;
        private int portNumber;*/
        int Server_Socket=8001;
        
        String str_response = "echo";
        Stream stm;
        TcpClient tcpclnt;
        bool connected = false;
        public ClientStart()
        {
            InitializeComponent();
        }
        private void btn_start_stop_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(
  () =>
  {
      if (connected)
      {
          tcpclnt.Close();
          stm.Close();
          connected = false;
      }
      else
      {
          connect_to_Server(txt_ip.Text);
      }
  }
)).Start();

        }

        private Boolean connect_to_Server(String ip)
        {

            tcpclnt = new TcpClient();
            addToLog("Connecting....");
            
            try
            {
                tcpclnt.Connect(ip, Server_Socket); // use the ipaddress as in the server program
                addToLog("Connected to ip = " + ip + " Port = " + Server_Socket);
                listen_to_server();
            }
            catch (Exception e)
            {

                try
                {
                    tcpclnt.Connect(ip, Server_Socket + 1); // use the ipaddress as in the server program

                    addToLog("Connected to ip = " + ip + " Port = " + (Server_Socket + 1));
                    listen_to_server();
                }
                catch (Exception e2)
                {
                    try
                    {
                        tcpclnt.Connect(ip, Server_Socket + 2); // use the ipaddress as in the server program

                        addToLog("Connected to ip = " + ip + " Port = " + (Server_Socket + 2));
                        listen_to_server();
                    }
                    catch (Exception e3)
                    {

                        try
                        {
                            tcpclnt.Connect(ip, Server_Socket + 3); // use the ipaddress as in the server program

                            addToLog("Connected to ip = " + ip + " Port = " + (Server_Socket + 3));
                            listen_to_server();
                        }
                        catch (Exception e4)
                        {
                            try
                            {
                                tcpclnt.Connect(ip, Server_Socket + 4); // use the ipaddress as in the server program

                                addToLog("Connected to ip = " + ip + " Port = " + (Server_Socket + 4));
                                listen_to_server();
                            }
                            catch (Exception e5)
                            {
                                try
                                {
                                    tcpclnt.Connect(ip, Server_Socket + 5); // use the ipaddress as in the server program

                                    addToLog("Connected to ip = " + ip + " Port = " + (Server_Socket + 5));
                                    listen_to_server();
                                }
                                catch (Exception e6)
                                {
                                    MessageBox.Show("Server Not Ready!");
                                    return false;
                                }
                            }
                        }


                    }
                }


            }
            
            return false;
        }
        private void listen_to_server()
        {
            try
            {
                connected = true;
               
                stm = tcpclnt.GetStream();

              

                byte[] bb = new byte[1000];
                int k = stm.Read(bb, 0, 1000);
                String str_text_from_server = System.Text.Encoding.UTF8.GetString(bb);
                addToLog("Text Received from Server : " + str_text_from_server);

                hanldeRequest(str_text_from_server);

           

                stm = tcpclnt.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(str_response);
                addToLog("Transmitting Echo Response....");

                stm.Write(ba, 0, ba.Length);



                listen_to_server();

            }
            catch (Exception e1)
            {
                addToLog("Connection was forcibly closed by the remote host.");
                connected = false;
                MessageBox.Show("Error = " + e1.Message);
            }
           
        }

       
        
        private void hanldeRequest(String result)
        {
            if (result.Contains("MUp"))
            {
                VirtualMouse.Move(0, -10);
            }
            else if (result.Contains("MRight"))
            {
                str_response = "mr";
                VirtualMouse.Move(10, 0);
            }
            else if (result.Contains("MDown"))
            {
                VirtualMouse.Move(0, 10);
            }
            else if (result.Contains("MLeft"))
            {
                VirtualMouse.Move(-10, 0);
            }
            else if (result.Contains("MRClick"))
            {
                ServiceExample.VirtualMouse.RightClick();
            }
            else if (result.Contains("MLClick"))
            {
                ServiceExample.VirtualMouse.LeftClick();
            }


            else if (result.Contains("Shutdown"))
            {
                Shutdown_Restart_LogOff_Lock.shutdownBtn_Click();
            }
            else if (result.Contains("Logoff"))
            {

                Shutdown_Restart_LogOff_Lock.logOffBtn_Click ();
            }
            else if (result.Contains("Restart"))
            {
                Shutdown_Restart_LogOff_Lock.restartBtn_Click();
            }

            else if (result.Contains("Lock"))
            {
                Shutdown_Restart_LogOff_Lock.LockWorkStation();
            }
            else if (result.Contains("Shutdown_a"))
            {
                Shutdown_Restart_LogOff_Lock.shotShutdownBtn_Click();
            }

            else if (result.Contains("cmd_"))
            {
                String cmd_command = result.Substring(result.IndexOf("cmd_") + 4);
              
                try
                {
                    Process.Start("" + cmd_command);
                }

                catch (Exception e)
                {

                }

            }
    


            
            else if (result.Contains("getp"))
            {

                /*str_response = "";
                Process[] pAll = Process.GetProcesses();
                List<String> mList = new List<String>();

                for (int i = 1; i < pAll.Length; i++)
                {
                    mList.Add ( pAll[i].ProcessName);
                }

                mList.Sort();

                str_response = pAll[0].ProcessName + "";

                for (int i = 1; i < mList.Count ; i++)
                {
                    str_response = str_response + "" + "@#" + mList[i];
                }*/

                DanhSachProcess();
            }

            else if (result.Contains("killp_"))
            {


                string[] arrListStr = result.Split('_');




               
               
                
                /*if(arrListStr[1].Equals("notepad"))
                {
                    addToLog("" + arrListStr[1].Length);
                }
                else
                {
                    addToLog("" + arrListStr[1].Length);
                }*/
                var processes = Process.GetProcessesByName(arrListStr[1]);

             
                foreach (var process in processes)
                {
                    addToLog("" + process.ProcessName);
                    addToLog("" + process.Id);
                    Process.GetProcessById(process.Id).Kill();

                }

            }

            else
            {
                addToLog("in else ");
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
                str_response = str_response + "" + "@#" + mList[i];
            }
        }

        private void ClientStart_Load(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(
    () =>
    {
        if (connected)
        {
            tcpclnt.Close();
            stm.Close();
            connected = false;
        }
        else
        {
            connect_to_Server(txt_ip.Text);
        }
    }
)).Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            ServiceExample.VirtualMouse.Move(10, 10);
        }

        public void addToLog(String str)
        {
            if (listBox1.InvokeRequired)
                listBox1.BeginInvoke(new Action(() =>
                {
                    listBox1.Items.Add(str); listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    ;
                }
 ));
            else
                listBox1.BeginInvoke(new Action(() =>
                {
                    listBox1.Items.Add(str); listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    ;
                }));


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_ip_TextChanged(object sender, EventArgs e)
        {

        }
        private static Image GrabDesktop()
        {
            Rectangle bound = Screen.PrimaryScreen.Bounds;
            Bitmap screenshot = new Bitmap(bound.Width, bound.Height, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(screenshot);
            graphics.CopyFromScreen(bound.X, bound.Y, 0, 0, bound.Size, CopyPixelOperation.SourceCopy);


            return screenshot;
        }

        

        private void SendDesktopImage()
        {
            connected = true;
            BinaryFormatter binFormatter = new BinaryFormatter();
            stm = tcpclnt.GetStream();
            binFormatter.Serialize(stm, GrabDesktop());

        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            if (btnShare.Text.StartsWith("Share"))
            {
                timer1.Start();
                btnShare.Text = "Stop Sharing";
            }
            else
            {
                timer1.Stop();
                btnShare.Text = "Share My Screen";
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            SendDesktopImage();
        }
    }




}











