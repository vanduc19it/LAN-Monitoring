namespace ProgressBarExample
{
    partial class ProgressDialog
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dia_status_label = new System.Windows.Forms.Label();
            this.dia_main_title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 119);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(463, 14);
            this.progressBar1.TabIndex = 1;
            // 
            // dia_status_label
            // 
            this.dia_status_label.Font = new System.Drawing.Font("Tw Cen MT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dia_status_label.Location = new System.Drawing.Point(0, 136);
            this.dia_status_label.Name = "dia_status_label";
            this.dia_status_label.Size = new System.Drawing.Size(489, 23);
            this.dia_status_label.TabIndex = 2;
            this.dia_status_label.Text = "dia_status_label";
            this.dia_status_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dia_main_title
            // 
            this.dia_main_title.Font = new System.Drawing.Font("Tw Cen MT", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dia_main_title.Location = new System.Drawing.Point(6, 9);
            this.dia_main_title.Name = "dia_main_title";
            this.dia_main_title.Size = new System.Drawing.Size(469, 107);
            this.dia_main_title.TabIndex = 4;
            this.dia_main_title.Text = "Please Wait......";
            this.dia_main_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgressDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 163);
            this.Controls.Add(this.dia_main_title);
            this.Controls.Add(this.dia_status_label);
            this.Controls.Add(this.progressBar1);
            this.Name = "ProgressDialog";
            this.Text = "Wait....";
            this.Load += new System.EventHandler(this.ProgressDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label dia_status_label;
        private System.Windows.Forms.Label dia_main_title;
    }
}