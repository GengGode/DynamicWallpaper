using Microsoft.DirectX.AudioVideoPlayback;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _10DirectX12SDK测试
{
    public partial class Form1 : Form
    {
        public Video video = null; 
        public Size videoSize= new Size(100,100);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            videoSize.Height = panel1.Height;
            videoSize.Width = panel1.Width;

            video = new Video("C:\\Users\\GengG\\source\\repos\\动态壁纸\\000.mp4",true);

            video.Owner = panel1;
            video.Play();

            panel1.Height = videoSize.Height;
            panel1.Width = videoSize.Width;

            //video.Play();
            //if (video.State== StateFlags.Running)
            //{
            //    video.Pause();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (video.State==StateFlags.Stopped)
            //{
            //    if (video.Playing)
            //    {
            //        video.Pause();
            //    }
            //    else
            //    {
            //        video.Play();
            //    }
            //}
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
    }
}
