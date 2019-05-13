using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 动态壁纸;

namespace _06只能运行一个实例
{
    public partial class Form1 : Form
    {
        public Form1(bool State, System.Diagnostics.Process process)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
            this.Visible = false;
            this.ShowInTaskbar = false;

            if (State != true) 
            {
                notifyIcon1.ShowBalloonTip(10, "程序", "程序已运行", ToolTipIcon.Info);
                Win32.ShowWindow(process.MainWindowHandle, 4);
                this.Close();

            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.Visible = true;
                this.ShowInTaskbar = true;
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
