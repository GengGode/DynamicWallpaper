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
    public partial class Form2 : Form
    {
        public int TimeMs = 0;
        public bool IsLoop = true;

        public Form2()
        {
            InitializeComponent();
        }

        private void TimeAdd()
        {
            timer1.Start();
        }

        private void TextAdd(string str)
        {
            textBox1.Text = str + "\r\n"+ textBox1.Text;
            textBox1.ScrollToCaret();
        }

        private void TextClear()
        {
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimeAdd();
            TextAdd("start");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeMs += timer1.Interval;

            if (TimeMs >= int.Parse(textBox2.Text) * 1000) 
            {
                timer1.Stop();
                TextAdd(TimeMs.ToString());
                if (IsLoop)
                {
                    TimeMs = 0;
                    timer1.Start();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TimeMs = 0;
            if (timer1.Enabled)
            {
                timer1.Stop();
                TextAdd("stop");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (IsLoop == true)
            {
                IsLoop = false;
                TextAdd("Loop OFF");
            }
            else
            {
                IsLoop = true;
                TextAdd("Loop ON");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TextClear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                TextAdd("play pause");
                TextAdd(TimeMs.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled==false)
            {
                timer1.Start();
                TextAdd("playing");
                TextAdd(TimeMs.ToString());
            }
        }
    }
}
