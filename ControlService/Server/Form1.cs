using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net.Sockets ;
using System.IO;
using System.Threading;
using System.Text;


using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Server
{

	public class Form1 : System.Windows.Forms.Form
    {
        private IContainer components;

        [DllImport("user32")]
        public static extern void LockWorkStation();
        [DllImport("user32")]
        public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

		public Form1()
		{
			
			InitializeComponent();

		}

		
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(26, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Iam Waiting Your Order";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(373, 173);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "My Remote Receive";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			Thread myth;
			myth= new Thread  (new System.Threading .ThreadStart(StartMethod)); 
			myth.Start ();

        }
        string localvairable;

		void StartMethod ()
		{

           
            TcpListener mytcpl = new TcpListener(5020);

			mytcpl.Start ();						
			mysocket = mytcpl.AcceptSocket ();		 
			myns = new NetworkStream (mysocket);	 
			mysr = new StreamReader (myns);			 
			string order = mysr.ReadLine();

            if (order == "calc")
            {
                System.Diagnostics.Process.Start("calc.exe");             
             
                localvairable = "calc";
                cross_Thred(localvairable);
            }

            if (order == "compmgmt")
            {
                System.Diagnostics.Process.Start("compmgmt.msc");          

                localvairable = "compmgmt";
                cross_Thred(localvairable);
            }
            if (order == "dxdiag")
            {
                System.Diagnostics.Process.Start("dxdiag");                  

                localvairable = "dxdiag";
                cross_Thred(localvairable);
            }
            if (order == "control desktop")
            {
                System.Diagnostics.Process.Start("control desktop");       

                localvairable = "control desktop";
                cross_Thred(localvairable);
            }
            if (order == "eventvwr")
            {
                System.Diagnostics.Process.Start("eventvwr.msc");
                localvairable = "eventvwr";
                cross_Thred(localvairable);
            }
            if (order == "control mouse")
            {
                System.Diagnostics.Process.Start("firefox");
                localvairable = "control mouse";
                cross_Thred(localvairable);
            }
            if (order == "Ping")
            {
                System.Diagnostics.Process.Start("cmd");
                localvairable = "Ping";
                cross_Thred(localvairable);
            }

            if (order == "Youtube")
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCk1GGSsG157EERZSn_XoW9A");
                localvairable = "Youtube";
                cross_Thred(localvairable);
            }

            if (order == "satratup")
            {
                System.Diagnostics.Process.Start("msconfig");

                localvairable = "satratup";
                cross_Thred(localvairable);
            }
      

                   if (order == "OurWebSite")
            {
                System.Diagnostics.Process.Start("https://doan1nam2.herokuapp.com/");

                localvairable = "OurWebSite";
                cross_Thred(localvairable);
            }

                   if (order == "Shutdown")
            {
                Process.Start("shutdown", "/s /t 0");

                localvairable = "Shutdown";
                cross_Thred(localvairable);
            }

                   if (order == "Restart")
                   {
                       Process.Start("shutdown", "/r /t 0");

                       localvairable = "Restart";
                       cross_Thred(localvairable);
                   }
                   if (order == "LogOff")
                   {
                       ExitWindowsEx(0, 0);

                       localvairable = "LogOff";
                       cross_Thred(localvairable);
                   }

                       

            else

                mytcpl.Stop();		


            mytcpl.Stop();	
			if (mysocket.Connected ==true)		   
			{
				while (true)
				{
					StartMethod ();				
				}
			}
		}
		TcpListener mytcpl;					
		Socket mysocket;
		NetworkStream myns;
        private System.Windows.Forms.Label label1;
		StreamReader mysr;



       

        void Read_From_Anther_PC(String server, String order)
		{

            try
            {
                Int32 port = 5020;
                TcpClient client = new TcpClient(server, port);

                byte[] bytes = new byte[client.ReceiveBufferSize];

                NetworkStream stream = client.GetStream();

                if (stream.CanWrite)
                {
                    Byte[] sendBytes = Encoding.UTF8.GetBytes(order);
                    stream.Write(sendBytes, 0, sendBytes.Length);
                }
                else
                {
                    client.Close();
                    stream.Close();
                    return;
                }
                System.Threading.Thread.Sleep(50);
                stream.Read(bytes, 0, (int)client.ReceiveBufferSize);
                string returndata = Encoding.UTF8.GetString(bytes);
                int Length = returndata.Length;

                if (order == "calc")
                {
                    System.Diagnostics.Process.Start("calc.exe");            
                 
                    localvairable = "calc";
                    cross_Thred(localvairable);
                }

                if (order == "compmgmt")
                {
                    System.Diagnostics.Process.Start("compmgmt.msc");        

                    localvairable = "compmgmt";
                    cross_Thred(localvairable);
                }
                if (order == "dxdiag")
                {
                    System.Diagnostics.Process.Start("dxdiag");                 

                    localvairable = "dxdiag";
                    cross_Thred(localvairable);
                }
                if (order == "control desktop")
                {
                    System.Diagnostics.Process.Start("control desktop");     

                    localvairable = "control desktop";
                    cross_Thred(localvairable);
                }
                if (order == "eventvwr")
                {
                    System.Diagnostics.Process.Start("eventvwr.msc");
                    localvairable = "eventvwr";
                    cross_Thred(localvairable);
                }
                if (order == "control mouse")
                {
                    System.Diagnostics.Process.Start("firefox");
                    localvairable = "control mouse";
                    cross_Thred(localvairable);
                }
                if (order == "Ping")
                {
                    System.Diagnostics.Process.Start("cmd");
                    localvairable = "Ping";
                    cross_Thred(localvairable);
                }

                if (order == "Youtube")
                {
                    System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCk1GGSsG157EERZSn_XoW9A");
                    localvairable = "Youtube";
                    cross_Thred(localvairable);
                }

                if (order == "Facebook")
                {
                    System.Diagnostics.Process.Start("https://facebook.com//duc19it");

                    localvairable = "Facebook";
                    cross_Thred(localvairable);
                }


                if (order == "OurWebSite")
                {
                    System.Diagnostics.Process.Start("https://doan1nam2.herokuapp.com/");

                    localvairable = "OurWebSite";
                    cross_Thred(localvairable);
                }
                else

                    mytcpl.Stop();		 


                mytcpl.Stop();
                if (mysocket.Connected == true)		  
                {
                    while (true)
                    {
                        StartMethod();					
                    }
                }

                stream.Close();
                client.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }

		}
        void cross_Thred( string Receiving )
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    label1.Text = Receiving +" "+"is done !";
                }));
            }
            else
            {
                label1.Text = Receiving +" is not done !";
            }
        }
		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				mytcpl.Stop ();
				Application.ExitThread ();
				Application.Exit();
			}
			catch (Exception ex) 
            {
               
            }
		}

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        } 
	}
}
