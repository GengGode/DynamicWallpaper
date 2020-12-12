using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.AudioVideoPlayback;

namespace _09Win1903中Video加载视频
{
    public partial class Form1 : Form
    {
        private Video video = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog OpenFileViewDialog = new OpenFileDialog();
            OpenFileViewDialog.Filter = "Video|*.mp4;*.wmv;*.avi;*.flv;|Picture|*.jpg;*.png;*.gif;*.bmp;*.dng;|All|*.*;";
            DialogResult OpenResultView = OpenFileViewDialog.ShowDialog();
            if (OpenResultView == DialogResult.OK)
            {
                if (video != null) 
                {
                    if (video.Playing == true)
                    {
                        video.Stop();
                        video.Dispose();
                    }
                }
                video = new Video(OpenFileViewDialog.FileName,false);
                //"C:\Users\GengG\Videos\壁纸\Comp 1_1.mp4"
                video.Owner = panel1;
                video.Owner.Width = panel1.Width;
                video.Owner.Height = panel1.Height;
                video.Play();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (video != null)
            {
                if (video.Playing == true)
                {
                    video.Stop();
                    video.Dispose();
                }
            }
            video = new Video("C:\\Users\\GengG\\Videos\\壁纸\\Comp 1_1.mp4", false);
            //"C:\Users\GengG\Videos\壁纸\Comp 1_1.mp4"
            video.Owner = panel1;
            video.Owner.Width = panel1.Width;
            video.Owner.Height = panel1.Height;
            video.Play();
        }
    }
}
