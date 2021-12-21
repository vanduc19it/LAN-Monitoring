using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProgressBarExample
{
    public partial class ProgressDialog : Form
    {
        public ProgressDialog()
        {
            InitializeComponent();
        }

        public void UpdateProgress(int progress)
        {
            if (progressBar1.InvokeRequired)
                progressBar1.BeginInvoke(new Action(() => progressBar1.Value = progress));
            else
                progressBar1.Value = progress;

        }

        public void setMaximum(int maxValue)
        {
            if (progressBar1.InvokeRequired)
                progressBar1.BeginInvoke(new Action(() => progressBar1.Maximum = maxValue));
            else
                progressBar1.Value = maxValue;
        }


        public void setProgressInformation(string message)
        {
            if (progressBar1.InvokeRequired)
                progressBar1.BeginInvoke(new Action(() => dia_status_label.Text = message));
            else
                dia_status_label.Text = message;
        }

        public void setMainInformation(string message)
        {
            if (progressBar1.InvokeRequired)
                progressBar1.BeginInvoke(new Action(() => dia_status_label.Text = message));
            else
                dia_status_label.Text = message;
        }

        public void SetIndeterminate(bool isIndeterminate)
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.BeginInvoke(new Action(() =>
                    {
                        if (isIndeterminate)
                            progressBar1.Style = ProgressBarStyle.Marquee;
                        else
                            progressBar1.Style = ProgressBarStyle.Blocks;
                    }
                ));
            }
            else
            {
                if (isIndeterminate)
                    progressBar1.Style = ProgressBarStyle.Marquee;
                else
                    progressBar1.Style = ProgressBarStyle.Blocks;
            }
        }

        private void ProgressDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
