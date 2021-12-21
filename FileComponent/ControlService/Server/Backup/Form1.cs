using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net.Sockets ;
using System.IO;
using System.Threading;
namespace Server
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(178)));
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(200, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Iam Waiting Your Order";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(210, 32);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "My Remote ShutDown";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			Thread myth;
			myth= new Thread  (new System.Threading .ThreadStart(StartMethod)); // Start Thread Session
			myth.Start ();
		}
		void StartMethod ()
		{


			mytcpl = new TcpListener (5020);		 // Open The Port
			mytcpl.Start ();						 // Start Listening on That Port
			mysocket = mytcpl.AcceptSocket ();		 // Accept Any Request From Client and Start a Session
			myns = new NetworkStream (mysocket);	 // Receives The Binary Data From Port
			mysr = new StreamReader (myns);			 // Convert Received Data to String
			string order = mysr.ReadLine();
			if (order=="ShutDown") System.Diagnostics.Process.Start("ShutDown.exe");		 // Print The Message
			// you can add anything
			// Here

			else MessageBox.Show(order + " Request Not Found");
			mytcpl.Stop();							 // Close TCP Session
			
			if (mysocket.Connected ==true)		     // Looping While Connected to Receive Another Message 
			{
				while (true)
				{
					StartMethod ();					 // Back to First Method
				}
			}
		}
		TcpListener mytcpl;						 // Objects  Declaration 
		Socket mysocket;
		NetworkStream myns;
		private System.Windows.Forms.Label label1;
		StreamReader mysr;

		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				mytcpl.Stop ();
				Application.ExitThread ();
				Application.Exit();
			}
			catch (Exception ex) {MessageBox .Show (ex.Message );}
		}
	}
}
