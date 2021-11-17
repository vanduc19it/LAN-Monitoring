namespace Server
{
    partial class frm_Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Setting));
            this.lblIP = new System.Windows.Forms.Label();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.lbl_Port = new System.Windows.Forms.Label();
            this.txt_PortRM = new System.Windows.Forms.TextBox();
            this.lbl_PortRM = new System.Windows.Forms.Label();
            this.btn_Create = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(14, 12);
            this.lblIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(88, 16);
            this.lblIP.TabIndex = 0;
            this.lblIP.Text = "Địa chỉ IP";
            // 
            // txt_IP
            // 
            this.txt_IP.Location = new System.Drawing.Point(121, 9);
            this.txt_IP.Margin = new System.Windows.Forms.Padding(4);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(197, 22);
            this.txt_IP.TabIndex = 1;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(218, 99);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(4);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(100, 28);
            this.btn_OK.TabIndex = 6;
            this.btn_OK.Text = "Đồng ý";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(121, 39);
            this.txt_Port.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(197, 22);
            this.txt_Port.TabIndex = 3;
            // 
            // lbl_Port
            // 
            this.lbl_Port.AutoSize = true;
            this.lbl_Port.Location = new System.Drawing.Point(14, 42);
            this.lbl_Port.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Port.Name = "lbl_Port";
            this.lbl_Port.Size = new System.Drawing.Size(104, 16);
            this.lbl_Port.TabIndex = 2;
            this.lbl_Port.Text = "Cổng kết nối";
            // 
            // txt_PortRM
            // 
            this.txt_PortRM.Location = new System.Drawing.Point(121, 69);
            this.txt_PortRM.Margin = new System.Windows.Forms.Padding(4);
            this.txt_PortRM.Name = "txt_PortRM";
            this.txt_PortRM.Size = new System.Drawing.Size(197, 22);
            this.txt_PortRM.TabIndex = 4;
            // 
            // lbl_PortRM
            // 
            this.lbl_PortRM.AutoSize = true;
            this.lbl_PortRM.Location = new System.Drawing.Point(14, 72);
            this.lbl_PortRM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_PortRM.Name = "lbl_PortRM";
            this.lbl_PortRM.Size = new System.Drawing.Size(96, 16);
            this.lbl_PortRM.TabIndex = 4;
            this.lbl_PortRM.Text = "Cổng Remote";
            // 
            // btn_Create
            // 
            this.btn_Create.Location = new System.Drawing.Point(10, 99);
            this.btn_Create.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(172, 28);
            this.btn_Create.TabIndex = 7;
            this.btn_Create.Text = "Tạo lại file config";
            this.btn_Create.UseVisualStyleBackColor = true;
            this.btn_Create.Click += new System.EventHandler(this.btn_Create_Click);
            // 
            // frm_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 135);
            this.Controls.Add(this.btn_Create);
            this.Controls.Add(this.txt_PortRM);
            this.Controls.Add(this.lbl_PortRM);
            this.Controls.Add(this.txt_Port);
            this.Controls.Add(this.lbl_Port);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.txt_IP);
            this.Controls.Add(this.lblIP);
            this.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cấu hình";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Setting_FormClosed);
            this.Load += new System.EventHandler(this.frm_Setting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.TextBox txt_IP;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.Label lbl_Port;
        private System.Windows.Forms.TextBox txt_PortRM;
        private System.Windows.Forms.Label lbl_PortRM;
        private System.Windows.Forms.Button btn_Create;
    }
}