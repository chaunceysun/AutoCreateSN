using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoCreateSN
{
    public partial class Form1 : Form
    {
        int n;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            n = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath + "\\";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (btnOK.BackColor == Color.Green)
            {
                n = Convert.ToInt32(textBox3.Text);
                timer1_Tick(new object(),new EventArgs());
                timer1.Interval = Convert.ToInt32(textBox4.Text);
                timer1.Enabled = true;
                timer1.Start();
                btnOK.Text = "Stop";
                btnOK.BackColor = Color.Red;
            }
            else
            {
                textBox3.Text = n.ToString();
                timer1.Enabled = false;
                timer1.Stop();
                btnOK.Text = "Start";
                btnOK.BackColor = Color.Green;
            }
            //btnOK.BackColor = btnOK.BackColor == Color.Green ? Color.Red : Color.Green;
        }

        public void Write(string s)
        {
            FileStream fs = new FileStream(textBox1.Text + textBox2.Text, FileMode.Append);
            //获得字节数组
            byte[] data = Encoding.Default.GetBytes(s);
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string sNow = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            Write("Getech,Front Table," + sNow + "," + sNow + ",11.27,48,SN" + n.ToString().PadLeft(6, '0') + "\r\n");
            n++;
        }
    }
}
