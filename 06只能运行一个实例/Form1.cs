using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06只能运行一个实例
{
    public partial class Form1 : Form
    {
        public Form1(bool State)
        {
            InitializeComponent();

            if (State==true)
            {

            }
            else
            {
                notifyIcon1.ShowBalloonTip(10, "动态壁纸", "程序已运行", ToolTipIcon.Info);
                this.Close();

                //Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            notifyIcon1.ShowBalloonTip(10, "???", "程序已运行", 0);

        }
    }
}
