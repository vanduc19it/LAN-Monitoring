using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Net;

namespace Client
{
    public partial class frm_Setting : Form
    {
        public frm_Setting()
        {
            InitializeComponent();
        }

        private void frm_Setting_Load(object sender, EventArgs e)
        {
            try
            {
                XmlDocument config = new XmlDocument();
                string path = Application.StartupPath + @"\config.xml";
                config.Load(path);
                txt_IP.Text = config.SelectSingleNode("//ip").InnerText;
                txt_Port.Text = config.SelectSingleNode("//port").InnerText;
                txt_PortRM.Text = config.SelectSingleNode("//portRM").InnerText;
                IPAddress.Parse(txt_IP.Text);
                Int32.Parse(txt_Port.Text);
                Int32.Parse(txt_PortRM.Text);
            }
            catch
            {
                MessageBox.Show("File config không tồn tại hoặc lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_IP.Text) && !String.IsNullOrEmpty(txt_Port.Text) && !String.IsNullOrEmpty(txt_PortRM.Text))
            {
                try
                {
                    XmlDocument config = new XmlDocument();
                    string path = Application.StartupPath + @"\config.xml";
                    config.Load(path);
                    config.SelectSingleNode("//ip").InnerText = txt_IP.Text;
                    config.SelectSingleNode("//port").InnerText = txt_Port.Text;
                    config.SelectSingleNode("//portRM").InnerText = txt_PortRM.Text;
                    config.Save(path);
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Lỗi không thể cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Phải nhập đầu đủ các thông số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\config.xml";
            string contentXML = "<config>"+
                                "<ip></ip>"+
                                "<port></port>"+
                                "<portRM></portRM>"+
                                "</config>";
            XmlDocument config = new XmlDocument();
            config.LoadXml(contentXML);
            XmlTextWriter writer = new XmlTextWriter(path, null);
            writer.Formatting = Formatting.Indented;
            config.Save(writer);
            writer.Close();
            MessageBox.Show("Khởi tạo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frm_Setting_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
