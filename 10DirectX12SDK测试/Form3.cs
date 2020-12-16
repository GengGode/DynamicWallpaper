using System;
using System.Windows.Forms;

namespace _10DirectX12SDK测试
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.f2.video.Stop();
            Form1.f2.video.Dispose();
            Form1.f2.Close();
            this.Close();

        }
    }
}
