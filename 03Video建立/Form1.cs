using System;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.AudioVideoPlayback;

namespace _03Video建立
{
    public partial class Form1 :Form
    {
        public Video videoViewPanel = null;
        private string TempViewPath = "C:\\Users\\GengG\\Desktop\\illya.mp4";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileViewDialog = new OpenFileDialog();
            OpenFileViewDialog.Filter = "Video|*.mp4;*.wmv;*.avi;*.flv;|Picture|*.jpg;*.png;*.gif;*.bmp;*.dng;|All|*.*;";
            DialogResult OpenResultView = OpenFileViewDialog.ShowDialog();
            if (OpenResultView == DialogResult.OK)
            {
                try
                {
                    TempViewPath = OpenFileViewDialog.FileName;
                    if (videoViewPanel != null)
                    {
                        if (videoViewPanel.Playing)
                        {
                            videoViewPanel.Stop();
                            videoViewPanel.Dispose();
                            videoViewPanel = null;
                        }
                    }

                    //videoViewPanel = new Video(TempViewPath,false);
                    //videoViewPanel = Video.FromFile(TempViewPath, false); //Open(TempViewPath, false);
                    videoViewPanel = new Video(TempViewPath, true);
                    videoViewPanel.Owner = panel1;

                    //控制播放视频窗口的大小（此项目是把视频放到一个panel中，panelView是一个panel）
                    int width = panel1.Width;
                    int height = panel1.Height;
                    videoViewPanel.Owner.Width = width;
                    videoViewPanel.Owner.Height = height;

                    videoViewPanel.Play();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.ToString());
                }
            }
            OpenFileViewDialog.Dispose();
        }
    }
}
