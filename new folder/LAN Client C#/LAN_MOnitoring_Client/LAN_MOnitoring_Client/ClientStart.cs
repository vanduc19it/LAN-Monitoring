






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

namespace LAN_MOnitoring_Client
{
    public partial class ClientStart : Form
    {

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
                //    String str = txt_send_data.Text;
                stm = tcpclnt.GetStream();

                //    ASCIIEncoding asen = new ASCIIEncoding();
                //    byte[] ba = asen.GetBytes(str);
                //    addToLog("Transmitting.....");

                //    stm.Write(ba, 0, ba.Length);

                byte[] bb = new byte[1000];
                int k = stm.Read(bb, 0, 1000);
                String str_text_from_server = System.Text.Encoding.UTF8.GetString(bb);
                addToLog("Text Received from Server : " + str_text_from_server);

                hanldeRequest(str_text_from_server);

                //    String str = txt_send_data.Text;

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
            //    // tcpclnt.Close();
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
               // MessageBox.Show("CMd = " + cmd_command);
                try
                {
                    Process.Start("" + cmd_command);
                }

                catch (Exception e)
                {

               //     MessageBox.Show("Err = " + e.Message );
                }
            }
    //        else if (result.Contains("killp_"))
    //        {

    //            addToLog("killing request = : ----" + result+"----");
    //            String pname = result.Substring(result.IndexOf("killp_") + 6, result.Length - result.IndexOf("killp_") + 6);

    //            pname = pname.Trim();

    //          addToLog("killing pname = ----" + pname+"----");
    //    //      MessageBox.Show("Pname = ." + pname+".");



    //            Process[] p_cmd = Process.GetProcessesByName("cmd");
    //            //addToLog("custom list retrived name as " + "cmd" + " = " + p_cmd.Length);


    //            Process[] p_notepad = Process.GetProcessesByName("notepad");
    //           // addToLog("custom list retrived name as " + "notepad" + " = " + p_notepad.Length);
                
                
    //          //  Process[] ps = Process.GetProcessesByName(pname);
    //          //  addToLog("no of listitems retrived name as ----" + pname + "---- = " + ps.Length);
    //            //   MessageBox.Show("Count of processes having name - "+pname +" = " + ps.Length );
    //            foreach (Process p in p_notepad)
    //            {
    //                addToLog("killing process" );
    //                p.Kill();
    //                //                  MessageBox.Show("in for");
    //            }
                
    ////            MessageBox.Show("OLD COunt = " + p_old.Length + "\n NEW COunt = " + p_new.Length);
    //        }
            
            else if (result.Contains("getp"))
            {

                str_response = "";
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
                }

//                MyProcess p1 = new MyProcess("process1");



                //JsonArray jsonArray = new JsonArray();
                //jsonArray.Add(JsonValue.CreateNumberValue(116));
                //jsonArray.Add(JsonValue.CreateNumberValue(3.14159));
                //jsonArray.Add(JsonValue.CreateBooleanValue(true));
                //jsonArray.Add(JsonValue.CreateStringValue("abc"));
                //string jsonString = jsonArray.Stringify();

            }


            else
            {
                addToLog("in else ");
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

    }




}











