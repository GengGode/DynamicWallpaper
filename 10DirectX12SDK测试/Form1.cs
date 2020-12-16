using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.DirectX.AudioVideoPlayback;


namespace _10DirectX12SDK测试
{
    public partial class Form1 : Form
    {
        public Video video = null; 
        public Size videoSize= new Size(100,100);

        public Point absZeros = new Point(0, 0);

        public int ptrDisplay = -1;

        public static Form2 f2 = null;

        public Form1()
        {
            InitializeComponent();
            //获取显示器工作区绘制坐标系零点偏移量
            absZeros = getAbsZeros();
            //获取显示器列表
            getScreenList(comboBox1);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            videoSize.Height = panel1.Height;
            videoSize.Width = panel1.Width;

            video = new Video("C:\\Users\\GengG\\source\\repos\\动态壁纸\\001.mp4",true);

            video.Owner = panel1;
            video.Ending += onVideo_Ending;
            video.Play();

            panel1.Height = videoSize.Height;
            panel1.Width = videoSize.Width;
            textBox1.Text = video.Duration.ToString();
        }

        private void onVideo_Ending(object sender, EventArgs e)
        {
            video.CurrentPosition = 0;
            video.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (video.State)
            {
                case StateFlags.Running:
                    video.Pause();
                    break;
                case StateFlags.Paused:
                    video.Play();
                    break;
                case StateFlags.Stopped:
                    //video.Starting();
                    MessageBox.Show("Stop");
                    video.Play();
                    break;
                default:
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            video.Play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            video.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ptrDisplay = comboBox1.SelectedIndex;
            if (ptrDisplay >= 0)
            {
                if (f2 == null)
                {
                    video.Pause();
                    f2 = new Form2("C:\\Users\\GengG\\source\\repos\\动态壁纸\\001.mp4", absZeros, ptrDisplay);
                }
                else
                {
                    f2.Close();
                    f2.Dispose();

                    if (f2.IsDisposed)
                    {
                        f2 = null;
                    }

                    if (f2 == null)
                    {
                        video.Pause();

                        f2 = new Form2("C:\\Users\\GengG\\source\\repos\\动态壁纸\\001.mp4", absZeros, ptrDisplay);
                    }
                    else
                    {

                    }
                }
                f2.Show();
            }
            

        }

        Point getAbsZeros()
        {
            Point res = new Point(Screen.PrimaryScreen.Bounds.Left, Screen.PrimaryScreen.Bounds.Top);

            foreach (Screen scr in Screen.AllScreens)
            {
                if (scr.Bounds.Left < res.X)
                    res.X = scr.Bounds.Left;
                if (scr.Bounds.Top < res.Y)
                    res.Y = scr.Bounds.Top;
            }

            return res;
        }

        void getScreenList(ComboBox com)
        {
            com.Items.Clear();
            foreach (Screen scr in Screen.AllScreens)
            {
                com.Items.Add(scr.DeviceName);
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            getScreenList(comboBox1);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            video.Stop();
            video.Dispose();
            if (!video.Disposed)
            {
                video.Dispose();
            }
        }
    }
}
