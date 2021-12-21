namespace Server
{
    partial class frm_SendAll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_SendAll));
            this.rtxtMsg = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtxtMsg
            // 
            this.rtxtMsg.Location = new System.Drawing.Point(13, 8);
            this.rtxtMsg.Name = "rtxtMsg";
            this.rtxtMsg.Size = new System.Drawing.Size(259, 217);
            this.rtxtMsg.TabIndex = 0;
            this.rtxtMsg.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnSend.Location = new System.Drawing.Point(13, 232);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(259, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Gửi";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // frm_SendAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.rtxtMsg);
            this.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_SendAll";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gửi tin nhắn đến tất cả";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_SendAll_FormClosing);
            this.Load += new System.EventHandler(this.frm_SendAll_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtMsg;
        private System.Windows.Forms.Button btnSend;
    }
}