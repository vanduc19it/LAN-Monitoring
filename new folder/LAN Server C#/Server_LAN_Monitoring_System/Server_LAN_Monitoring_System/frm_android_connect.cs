




using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Server_LAN_Monitoring_System
{
    public partial class frm_android_connect : Form
    {
        int port_mobile = 8009;
        Socket mSocket_mobile;
        TcpListener mTCP_listener_mobile;
        Client mClient_mobile;
        private IPAddress temp_ipAd;
        String ip;
        Server_Start myparent;

        public frm_android_connect( Server_Start mparent ,String  ip)
        {
            InitializeComponent();
            this.ip = ip;
            this.myparent = mparent;
            Thread backgroundThread = new Thread(
 new ThreadStart(() =>
 {

     start_it_for_mobile();
 }));
            backgroundThread.Start();

        }

        private void frm_android_connect_Load(object sender, EventArgs e)
        {

      
            
        }
        private void start_it_for_mobile()
        {
            try
            {

              addToLog("Thread Mobile Started..");
              
              temp_ipAd = IPAddress.Parse("" + ip); //use local m/c IP address, and use the same in the client
              /* Initializes the Listener */
              mTCP_listener_mobile = new TcpListener(temp_ipAd, port_mobile);
              mSocket_mobile = null;

              mClient_mobile = new Client(temp_ipAd.ToString(), port_mobile, mSocket_mobile, mTCP_listener_mobile, false);
              ////    addToLog("IP = " + temp_ipAd.ToString());
              // addToClientList(mClient);

              /* Start Listeneting at the specified port */
              mClient_mobile.tcpListener.Start();

              addToLog("Server started for mobile at point ===> [ip : port] = [ " + mClient_mobile.ipaddress + ":" + port_mobile + "]");

              EndPoint myEndPoint = mClient_mobile.tcpListener.LocalEndpoint;

              //// addToLog("Server point is  :" + myEndPoint);

              addToLog("Waiting for a mobile connection.....");

              mClient_mobile.socket = mClient_mobile.tcpListener.AcceptSocket();
              mClient_mobile.isConnected = true;
              mClient_mobile.tcpListener.Stop();

              EndPoint acceptedEndPoint = mClient_mobile.socket.RemoteEndPoint;

              //addToLog("Connection accepted from " + acceptedEndPoint);

              //String client_ip = acceptedEndPoint.ToString().Substring(0, acceptedEndPoint.ToString().IndexOf(":"));
              addToLog("Connection Accepted from mobile [Port = " + port_mobile + "]");


              addToLog("Thread Mobile End");


              listen_to_server();


            }
            catch (Exception e1)
            {
                addToLog("frm_android_connect.cs - 94 - Error = " + e1.Message);
            }
        }



        private void listen_to_server()
        {
            //try
            //{

         byte[] b = new byte[1000];
      
            addToLog("Lsitening to android!");

                l:
            int k = mClient_mobile.socket.Receive(b);

                if (b.Length < 3)
                    goto l;
            string result = System.Text.Encoding.UTF8.GetString(b);
            addToLog("Response Received from android!");
            addToLog("Received Text from android : " + result);

            ////////

            // Android Commands will be FOllowed here.

            if (result.StartsWith("cc"))
            {
                try
                {
                    // Demo ---> "cc1ccMUp"
                    int indexofcc1 = result.IndexOf("cc_")+3;

                //    addToLog("cc1 =  " + indexofcc1);
                    //int indexofcc2 = result.LastIndexOf("cc");

                    //addToLog("cc2 =  " + indexofcc2);
                    //int indexofcmd1 = indexofcc2 + 2;

                    //addToLog("cmd1 =  " + indexofcmd1);
                    int client_select = Convert.ToInt32( result .Substring ( indexofcc1  , result.Length -  indexofcc1 ));


                  //  addToLog("client_select  =  " + client_select);

                    //String cmd = result.Substring(indexofcmd1, result.Length - indexofcmd1);

                    //addToLog("cmd =  " + cmd );
 addToLog("Sending Client Select command to Server = " + client_select);

                    my_parent_select_client(client_select);

                   
                    //my_parent_set_text(cmd);

                    //addToLog("now setting cmd = " + cmd);

                    //myparent.send_click();
                    ////my_parent_set_text("" + result);
                    sendCommandToClient("Index of Server Client List Changed to " + client_select);

                    
                }
                catch(Exception e)
                {
                    addToLog("Err = "+e.Message +"  frm_mob lnno = 138 can not get number in cc ");
                    sendCommandToClient("Error @ cc");
             
                }

            }
            else if (result.Contains("c_list"))
            {

                //my_parent_set_text("" + result);

                sendCommandToClient ( get_client_list());
                //mClient_mobile.socket.Send(asen.GetBytes(str_send_text)); // Sending to Client
            }
            else
            {
                my_parent_set_text("" + result);
                sendCommandToClient(myparent.send_click());
          
            }



         
           


            ///////
                listen_to_server();

            //}
            //catch (Exception e1)
            //{
            //    addToLog("Connection was forcibly closed by the remote host.");
            //    MessageBox.Show("Error = " + e1.Message);
            //}
            //    // tcpclnt.Close();
        }

        private void sendCommandToClient(String cmd)
        {
            ASCIIEncoding asen = new ASCIIEncoding();
            mClient_mobile.socket.Send(asen.GetBytes(cmd)); // Sending to Client
            addToLog("\nText Send to Mobile   -> " + cmd);
        }
        private string get_client_list()
        {
            String ret="null";

            if (myparent.mClientList.Count > 1)
            {
                ret = "0" + "";
                for (int i = 1; i < myparent.mClientList.Count; i++)
                {
                    if (myparent.mClientList[i].isConnected)
                        ret = ret + "" + "@#" + i;
                }
            }

            return ret;
        }


        private void addToLog(String string1)
        {

            if (listBox1.InvokeRequired)
            {
                listBox1.BeginInvoke(new Action(() =>
                {
                    listBox1.Items.Add(string1);
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }
                    ));
            }
            else
            {
                {
                    listBox1.Items.Add(string1);
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }

            }

        }

        private void my_parent_select_client(int client_select)
        {

            if (myparent.lb_client_list.InvokeRequired)
            {
                myparent.lb_client_list.BeginInvoke(new Action(() =>
                {

                    myparent.lb_client_list.SelectedIndex = client_select;

                    addToLog("own inv client slected as  " + client_select);
                }
                    ));
            }
            else
            {
                {

                    myparent.lb_client_list.SelectedIndex = client_select;

                }

            }

        }


        private void my_parent_set_text(String string1)
        {

            if (myparent.txt_send.InvokeRequired)
            {
                myparent.txt_send.BeginInvoke(new Action(() =>
                {

                    myparent.txt_send.Text = string1;
                }
                    ));
            }
            else
            {
                {

                    myparent.txt_send.Text = string1;
                }

            }

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void formclosingmob(object sender, FormClosingEventArgs e)
        {
         
                //MessageBox.Show("Closing");
                mTCP_listener_mobile .Stop();
                if (mSocket_mobile != null)
                    mSocket_mobile.Close();
         
        }

    }
}








