namespace Server_LAN_Monitoring_System
{
    partial class Server_Start
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.btn_start_stop = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.txt_send = new System.Windows.Forms.TextBox();
            this.lb_process_list = new System.Windows.Forms.ListBox();
            this.btn_process_kill = new System.Windows.Forms.Button();
            this.lb_client_list = new System.Windows.Forms.ListBox();
            this.txt_client_view = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_client_selected = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txt_process_new = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.txt_process_kill = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_ip
            // 
            this.txt_ip.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ip.Location = new System.Drawing.Point(7, 8);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(391, 29);
            this.txt_ip.TabIndex = 8;
            this.txt_ip.TextChanged += new System.EventHandler(this.txt_ip_TextChanged);
            // 
            // btn_start_stop
            // 
            this.btn_start_stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start_stop.Location = new System.Drawing.Point(404, 8);
            this.btn_start_stop.Name = "btn_start_stop";
            this.btn_start_stop.Size = new System.Drawing.Size(71, 29);
            this.btn_start_stop.TabIndex = 7;
            this.btn_start_stop.Text = "Start";
            this.btn_start_stop.UseVisualStyleBackColor = true;
            this.btn_start_stop.Click += new System.EventHandler(this.btn_start_stop_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(10, 43);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(538, 160);
            this.listBox1.TabIndex = 9;
            this.listBox1.Click += new System.EventHandler(this.click);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(187, 163);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(63, 23);
            this.btn_send.TabIndex = 14;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // txt_send
            // 
            this.txt_send.Location = new System.Drawing.Point(19, 165);
            this.txt_send.Name = "txt_send";
            this.txt_send.Size = new System.Drawing.Size(151, 20);
            this.txt_send.TabIndex = 15;
            this.txt_send.TextChanged += new System.EventHandler(this.txt_send_TextChanged);
            // 
            // lb_process_list
            // 
            this.lb_process_list.FormattingEnabled = true;
            this.lb_process_list.Location = new System.Drawing.Point(554, 49);
            this.lb_process_list.Name = "lb_process_list";
            this.lb_process_list.Size = new System.Drawing.Size(139, 381);
            this.lb_process_list.TabIndex = 16;
            this.lb_process_list.SelectedIndexChanged += new System.EventHandler(this.lb_process_list_SelectedIndexChanged);
            // 
            // btn_process_kill
            // 
            this.btn_process_kill.Location = new System.Drawing.Point(616, 471);
            this.btn_process_kill.Name = "btn_process_kill";
            this.btn_process_kill.Size = new System.Drawing.Size(77, 23);
            this.btn_process_kill.TabIndex = 17;
            this.btn_process_kill.Text = "Kill";
            this.btn_process_kill.UseVisualStyleBackColor = true;
            this.btn_process_kill.Visible = false;
            this.btn_process_kill.Click += new System.EventHandler(this.btn_process_kill_Click);
            // 
            // lb_client_list
            // 
            this.lb_client_list.FormattingEnabled = true;
            this.lb_client_list.Location = new System.Drawing.Point(9, 32);
            this.lb_client_list.Name = "lb_client_list";
            this.lb_client_list.Size = new System.Drawing.Size(220, 121);
            this.lb_client_list.TabIndex = 19;
            this.lb_client_list.SelectedIndexChanged += new System.EventHandler(this.lb_client_list_SelectedIndexChanged);
            // 
            // txt_client_view
            // 
            this.txt_client_view.Location = new System.Drawing.Point(9, 172);
            this.txt_client_view.Multiline = true;
            this.txt_client_view.Name = "txt_client_view";
            this.txt_client_view.Size = new System.Drawing.Size(222, 81);
            this.txt_client_view.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Controlling  --->";
            // 
            // lbl_client_selected
            // 
            this.lbl_client_selected.AutoSize = true;
            this.lbl_client_selected.Location = new System.Drawing.Point(332, 29);
            this.lbl_client_selected.Name = "lbl_client_selected";
            this.lbl_client_selected.Size = new System.Drawing.Size(27, 13);
            this.lbl_client_selected.TabIndex = 23;
            this.lbl_client_selected.Text = "N/A";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.txt_send);
            this.panel1.Controls.Add(this.btn_send);
            this.panel1.Location = new System.Drawing.Point(252, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 198);
            this.panel1.TabIndex = 24;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(19, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(231, 143);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button14);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(223, 117);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Mouse Control";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(84, 35);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(63, 23);
            this.button4.TabIndex = 20;
            this.button4.Text = "MUp";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button6_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(15, 63);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(63, 23);
            this.button3.TabIndex = 19;
            this.button3.Text = "MLeft";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button6_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(153, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "MRight";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button6_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(84, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "MDown";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button6_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button7);
            this.tabPage2.Controls.Add(this.button8);
            this.tabPage2.Controls.Add(this.button9);
            this.tabPage2.Controls.Add(this.button10);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(223, 117);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Shotdown, Lock, etc";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(120, 31);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(82, 23);
            this.button7.TabIndex = 24;
            this.button7.Text = "Lock";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button6_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(23, 31);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(82, 23);
            this.button8.TabIndex = 23;
            this.button8.Text = "Shutdown";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button6_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(23, 64);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(82, 23);
            this.button9.TabIndex = 22;
            this.button9.Text = "Logoff";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button6_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(120, 64);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(82, 23);
            this.button10.TabIndex = 21;
            this.button10.Text = "Restart";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button6_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txt_process_new);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.button13);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(223, 117);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Process Tasks";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txt_process_new
            // 
            this.txt_process_new.Location = new System.Drawing.Point(15, 86);
            this.txt_process_new.Name = "txt_process_new";
            this.txt_process_new.Size = new System.Drawing.Size(126, 20);
            this.txt_process_new.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Start New Process";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Click To See Process List";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(147, 83);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(63, 23);
            this.button5.TabIndex = 28;
            this.button5.Text = "Start";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(65, 29);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(82, 23);
            this.button13.TabIndex = 23;
            this.button13.Text = "getp";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.lbl_client_selected);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_client_view);
            this.groupBox1.Controls.Add(this.lb_client_list);
            this.groupBox1.Location = new System.Drawing.Point(7, 206);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 259);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control Panel for Controlling Clients";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Selected Client Info.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "List of Clients";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(580, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "List of Processes";
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Location = new System.Drawing.Point(482, 17);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(43, 20);
            this.button11.TabIndex = 28;
            this.button11.Text = "Start";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Visible = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.Location = new System.Drawing.Point(531, 17);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(43, 20);
            this.button12.TabIndex = 29;
            this.button12.Text = "Stop";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Visible = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // txt_process_kill
            // 
            this.txt_process_kill.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_process_kill.Location = new System.Drawing.Point(554, 436);
            this.txt_process_kill.Name = "txt_process_kill";
            this.txt_process_kill.Size = new System.Drawing.Size(141, 29);
            this.txt_process_kill.TabIndex = 30;
            this.txt_process_kill.Visible = false;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(14, 6);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(64, 23);
            this.button6.TabIndex = 21;
            this.button6.Text = "MLClick";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(153, 6);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(64, 23);
            this.button14.TabIndex = 21;
            this.button14.Text = "MRClick";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button6_Click);
            // 
            // Server_Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 522);
            this.Controls.Add(this.txt_process_kill);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_process_kill);
            this.Controls.Add(this.lb_process_list);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.txt_ip);
            this.Controls.Add(this.btn_start_stop);
            this.Name = "Server_Start";
            this.Text = "Server_Start";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.closing_form);
            this.Load += new System.EventHandler(this.Server_Start_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.Button btn_start_stop;
        private System.Windows.Forms.ListBox listBox1;
        public System.Windows.Forms.Button btn_send;
        public  System.Windows.Forms.TextBox txt_send;
        private System.Windows.Forms.ListBox lb_process_list;
        private System.Windows.Forms.Button btn_process_kill;
        private System.Windows.Forms.TextBox txt_client_view;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_client_selected;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.TextBox txt_process_kill;
        internal System.Windows.Forms.ListBox lb_client_list;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txt_process_new;
        public System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button14;
    }
}

