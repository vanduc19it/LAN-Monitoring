namespace Client
{
    partial class frm_Client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Client));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_Info = new System.Windows.Forms.Label();
            this.rtxt_Messeage = new System.Windows.Forms.RichTextBox();
            this.txt_Message = new System.Windows.Forms.TextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(494, 30);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(63, 26);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.settingToolStripMenuItem.Text = "Cấu hình";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.restartToolStripMenuItem.Text = "Kết nối lại";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.exitToolStripMenuItem.Text = "Thoát";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // lbl_Info
            // 
            this.lbl_Info.Font = new System.Drawing.Font("Courier New", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Info.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_Info.Location = new System.Drawing.Point(13, 30);
            this.lbl_Info.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(468, 16);
            this.lbl_Info.TabIndex = 1;
            this.lbl_Info.Text = "Đang chờ kết nối!";
            this.lbl_Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtxt_Messeage
            // 
            this.rtxt_Messeage.BackColor = System.Drawing.SystemColors.HighlightText;
            this.rtxt_Messeage.Location = new System.Drawing.Point(12, 54);
            this.rtxt_Messeage.Name = "rtxt_Messeage";
            this.rtxt_Messeage.ReadOnly = true;
            this.rtxt_Messeage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtxt_Messeage.Size = new System.Drawing.Size(470, 180);
            this.rtxt_Messeage.TabIndex = 2;
            this.rtxt_Messeage.Text = "";
            // 
            // txt_Message
            // 
            this.txt_Message.Enabled = false;
            this.txt_Message.Location = new System.Drawing.Point(12, 240);
            this.txt_Message.Name = "txt_Message";
            this.txt_Message.Size = new System.Drawing.Size(386, 26);
            this.txt_Message.TabIndex = 3;
            this.txt_Message.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Message_KeyDown);
            // 
            // btn_Send
            // 
            this.btn_Send.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Send.Enabled = false;
            this.btn_Send.Location = new System.Drawing.Point(405, 240);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 23);
            this.btn_Send.TabIndex = 4;
            this.btn_Send.Text = "Gửi";
            this.btn_Send.UseVisualStyleBackColor = false;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // frm_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 272);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.txt_Message);
            this.Controls.Add(this.rtxt_Messeage);
            this.Controls.Add(this.lbl_Info);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frm_Client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Client_FormClosing);
            this.Load += new System.EventHandler(this.frm_Client_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label lbl_Info;
        private System.Windows.Forms.RichTextBox rtxt_Messeage;
        private System.Windows.Forms.TextBox txt_Message;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
    }
}