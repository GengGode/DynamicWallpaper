using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _08定时器暂停继续
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TextAdd(string str)
        {
            textBox1.Text = textBox1.Text + str + "\r\n";
        }

        private void TextClear()
        {
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            TextAdd("Start");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TextAdd("End");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TextAdd(timer1.Interval.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            TextAdd("Stop");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TextAdd(timer1.Enabled.ToString());
        }
    }
}
