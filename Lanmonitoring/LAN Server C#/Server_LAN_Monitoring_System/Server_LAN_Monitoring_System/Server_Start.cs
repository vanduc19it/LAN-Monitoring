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
using ServiceExample;
using System.Diagnostics;
using System.Threading;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Binary;

namespace Server_LAN_Monitoring_System
{
    public partial class Server_Start : Form
    {

        int index_selected = -1;
        int client_index;
        internal List<Client> mClientList;

        IPAddress temp_ipAd;

        int My_Socket = 8001;
        Socket temp_s;
        TcpListener temp_myList;

        int port_mobile = 4444;
        Socket mSocket_mobile;
        TcpListener mTCP_listener_mobile;
        Client mClient_mobile;
        private TcpClient client;
        private NetworkStream mainStream;
        private readonly Thread Listening;
        private readonly Thread GetImage;
        public Server_Start()
        {
            InitializeComponent();
            mClientList = new List<Client>();
            client_index = 0;
            Listening = new Thread(StartListening);
            GetImage = new Thread(ReceiveImage);
        }

        private void btn_start_stop_Click(object sender, EventArgs e)
        {
            

            start_it();

            frm_android_connect mMobile = new frm_android_connect(this, txt_ip.Text);
            mMobile.Show();
           

        }



        private void start_it()
        {
            if (btn_start_stop.Text == "Stop")
            {
                foreach (Client mClient in mClientList)
                {
                    
                    mClient.tcpListener.Stop();
                    if (mClient.socket != null)
                        mClient.socket.Close();
                }
                listBox1.Items.Clear();
                lb_client_list.Items.Clear();
                txt_client_view.Text = "";
                btn_start_stop.Text = "Start";
                lbl_client_selected.Text = "N/A";
            }
            else
            {
                start_server_for_all();
                btn_start_stop.Text = "Stop";
            }
        }

        private void start_server_for_all()
        {
            Thread backgroundThread = new Thread(
        new ThreadStart(() =>
        {
            try
            {
                int my_count = client_index;
                int my_port = My_Socket;
               

                client_index++;
                My_Socket++;
                
                temp_ipAd = IPAddress.Parse("" + txt_ip.Text); //use local m/c IP address, and use the same in the client
                /* Initializes the Listener */
                temp_myList = new TcpListener(temp_ipAd, my_port);
                temp_s = null;

                Client mClient = new Client(temp_ipAd.ToString(), my_port, temp_s, temp_myList, false);
                
                mClientList.Add(mClient);

                /* Start Listeneting at the specified port */
                mClientList[my_count].tcpListener.Start();

                addToLog("Client No. ====> " + my_count);
                addToLog("Server started at point ===> [ip : port] = [ " + mClient.ipaddress + ":" + my_port + "]");

                EndPoint myEndPoint = mClientList[my_count].tcpListener.LocalEndpoint;

               

                addToLog("Waiting for a connection.....");


                mClientList[my_count].socket = mClientList[my_count].tcpListener.AcceptSocket();

                addToClientList(mClient);

                mClientList[my_count].isConnected = true;

                mClientList[my_count].tcpListener.Stop();


                EndPoint acceptedEndPoint = mClientList[my_count].socket.RemoteEndPoint;

                addToLog("Connection Accepted from New Client [ client_index = " + my_count + " ][Port = " + my_port + "]");


                addToLog("Thread End  List<Client> count = " + mClientList.Count);

                start_server_for_all();
                
            }
            catch (Exception e)
            {
                addToLog("Error Server_Start_152");
            }
            
        }
    ));

            // Start the background process thread
            backgroundThread.Start();



        }




        private void addToClientList(Client mClient)
        {
            if (lb_client_list.InvokeRequired)
            {
                lb_client_list.BeginInvoke(new Action(() =>
                {
                    lb_client_list.Items.Add(mClient.connected_port + "");
                    lb_client_list.SelectedIndex = lb_client_list.Items.Count - 1;
                }
                    ));
            }
            else
            {
                {
                    lb_client_list.Items.Add(mClient.connected_port + "");
                   
                }

            }

        }



        private void addToLog(String string1)
        {

            if (lb_process_list.InvokeRequired)
            {
                lb_process_list.BeginInvoke(new Action(() =>
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

        private void Server_Start_Load(object sender, EventArgs e)
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
              
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {

                    txt_ip.Text=ip.ToString();
                }
            }
         
         
        }


        private void listAllProcesses(string result)
        {
            lb_process_list.Items.Clear();
            String[] ps = Regex.Split(result,"@#");
            foreach (String s in ps)
            {
                addToProcessList(s);
            }

        }

        public void addToProcessList(String str)
        {
            if (lb_process_list.InvokeRequired)
                lb_process_list.BeginInvoke(new Action(() => lb_process_list.Items.Add(str)
 ));
            else
                lb_process_list.BeginInvoke(new Action(() => lb_process_list.Items.Add(str)));


        }

        private string  ListenForReply(int index)
        {
            byte[] b = new byte[5000];
            try
            {
                int k = mClientList[index].socket .Receive(b);
                string result = System.Text.Encoding.UTF8.GetString(b);
                addToLog("Response Received from "+index );
                addToLog("Received Text : [" + result+"] from "+index );


                if (result.Contains("@#"))
                    listAllProcesses(result);

                return result;


            }
            catch (Exception e)
            {
                addToLog("Error @ 148");
                return "null";
            }
        }


        private void ListenForReplyForAndroid()
        {


            Thread backgroundThread = new Thread(
new ThreadStart(() =>
{
    try
    {

        byte[] b = new byte[5000];
        try
        {
            addToLog("Lsitening to android!");

            int k = mClient_mobile.socket.Receive(b);

            string result = System.Text.Encoding.UTF8.GetString(b);
            addToLog("Response Received from android!");
            addToLog("Received Text from android : " + result);



        }
        catch (Exception e)
        {
            addToLog("Error @ 148");
        }

    }
    catch (Exception e1)
    {
        addToLog("Error = mo " + e1.Message);
    }
}
));

            // Start the background process thread
            backgroundThread.Start();

        }

       

        private void btn_send_Click(object sender, EventArgs e)
        {
            send_click();
        }

        public string send_click()
        {
            addToLog("Sending Command! = ---" + txt_send.Text  + "---");

            // code for call from thread
            if (lb_client_list.InvokeRequired)
                lb_client_list.BeginInvoke(new Action(() => index_selected = lb_client_list.SelectedIndex));
            else
                lb_client_list.BeginInvoke(new Action(() => index_selected = lb_client_list.SelectedIndex));

            // is client selected
            if (index_selected >= 0)
            {
                if (mClientList[index_selected].isConnected)
                {
                    return sendToClient(index_selected, txt_send.Text);
                }
                else
                {
                    MessageBox.Show("This Client is Not Connected");
                    return "not_con";
                }
            }
            else
            {
                MessageBox.Show("Select Client To Send Command!");
                return "not_con";
            }
        }

        private void btn_process_kill_Click(object sender, EventArgs e)
        {
            
            if (lb_client_list.SelectedIndex >= 0)
            {

                if (mClientList[lb_client_list.SelectedIndex].isConnected)
                {

                    sendToClient(lb_client_list.SelectedIndex, txt_process_kill.Text + "_"/*"killp_" + lb_process_list.SelectedIndex*/);
                  
                    addToLog("pname =  ----" + txt_process_kill.Text + "----");

                }
                else
                {
                    MessageBox.Show("This Client is Not Connected");
                }

            }
            else
            {
                MessageBox.Show("Select Client To Send Command!");
            }
        }

        private string  sendToClient(int index,String cmd)
        {
            ASCIIEncoding asen = new ASCIIEncoding();
            String str_send_text = cmd;  // Getting Input From Form TextBox
            


            mClientList[index].socket.Send(asen.GetBytes(str_send_text)); // Sending to Client
            addToLog("\nText Send to [" + index + " ] -> " + str_send_text);
            return ListenForReply(index );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            start_server_for_all ();
        }

        private void lb_client_list_SelectedIndexChanged(object sender, EventArgs e)
        {

            index_selected = lb_client_list.SelectedIndex;
            txt_client_view.Text = "";
            if (lb_client_list.SelectedIndex >= 0)
            {
                txt_client_view.AppendText(lb_client_list.SelectedIndex + "\n");
                txt_client_view.AppendText(mClientList[lb_client_list.SelectedIndex].connected_port + "\n");
                txt_client_view.AppendText(mClientList[lb_client_list.SelectedIndex].ipaddress + "\n");

                if (lbl_client_selected.InvokeRequired)
                    lbl_client_selected.BeginInvoke(new Action(() => lbl_client_selected.Tag = "m"));


                lbl_client_selected.Text = lb_client_list.SelectedIndex + "";
            }
        }

        private void txt_send_TextChanged(object sender, EventArgs e)
        {

        }


        private void button6_Click(object sender, EventArgs e)
        {
            Button mButton = (Button)sender;
            if (lb_client_list.SelectedIndex >= 0)
            {
                if (mClientList[lb_client_list.SelectedIndex].isConnected)
                {
                    sendToClient(lb_client_list.SelectedIndex, mButton.Text);
                }
                else
                {
                    MessageBox.Show("This Client is Not Connected");
                }
            }
            else
            {
                MessageBox.Show("Select Client To Send Command!");
            }
        }

        private void closing_form(object sender, FormClosingEventArgs e)
        {
            foreach (Client mClient in mClientList)
            {
               
                mClient.tcpListener.Stop();
                if (mClient.socket != null)
                    mClient.socket.Close();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
 
        }

        private void button12_Click(object sender, EventArgs e)
        {
            mClient_mobile.tcpListener.Stop();
            if(mClient_mobile.socket !=null)
                   mClient_mobile.socket.Close();
            mClient_mobile.isConnected = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Button mButton = (Button)sender;
            if (lb_client_list.SelectedIndex >= 0)
            {
                if (mClientList[lb_client_list.SelectedIndex].isConnected)
                {
                    sendToClient(lb_client_list.SelectedIndex, "MLeftClick");
                }
                else
                {
                    MessageBox.Show("This Client is Not Connected");
                }
            }
            else
            {
                MessageBox.Show("Select Client To Send Command!");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Button mButton = (Button)sender;
            if (lb_client_list.SelectedIndex >= 0)
            {
                if (mClientList[lb_client_list.SelectedIndex].isConnected)
                {
                    sendToClient(lb_client_list.SelectedIndex, "MRightClick");
                }
                else
                {
                    MessageBox.Show("This Client is Not Connected");
                }
            }
            else
            {
                MessageBox.Show("Select Client To Send Command!");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                MessageBox.Show("" + listBox1.SelectedItem.ToString());
            }
        }

        private void lb_process_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_process_kill.Text = "killp_"  +lb_process_list.SelectedItem.ToString ();
        }

        private void txt_ip_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Button mButton = (Button)sender;
            if (lb_client_list.SelectedIndex >= 0)
            {
                if (mClientList[lb_client_list.SelectedIndex].isConnected)
                {
                    sendToClient(lb_client_list.SelectedIndex,"cmd_"+ txt_process_new.Text );
                }
                else
                {
                    MessageBox.Show("This Client is Not Connected");
                }
            }
            else
            {
                MessageBox.Show("Select Client To Send Command!");
            }

        }

        private void btnListen_Click(object sender, EventArgs e)
        {   
            new Form2(My_Socket+1           ).Show();
            /*Listening.Start();*/
            /* new Form2(int.Parse(txtPort.Text)).Show();*/
            /*  btnListen.Enabled = false;*/
        }
        private void ReceiveImage()
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            foreach (Client mClient in mClientList)
            {
                while (mClient.isConnected)
                {



              
                   mainStream = client.GetStream();
                    pictureBox.Image = (Image)binFormatter.Deserialize(mainStream);
                }
            }
        }
        private void StartListening()
        {
            
            GetImage.Start();

        }

        private void txt_process_kill_TextChanged(object sender, EventArgs e)
        {

        }

       /* private void btnRefresh_Click(object sender, EventArgs e)
        {
            lb_process_list.Items.Clear();
           
        }*/
    }
}






