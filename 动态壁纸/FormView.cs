using Microsoft.DirectX;
using Microsoft.DirectX.AudioVideoPlayback;
using System;
using System.Linq;
using System.Windows.Forms;

namespace 动态壁纸
{
    public partial class FormView : Form
    {
        private FormBackGround formBackGround = null;
        private IntPtr backGroundPtr = IntPtr.Zero;
        private Video videoViewPanel = null;

        public FormView()
        {
            InitializeComponent();
        }

        #region 窗口关闭事件
        private void FormView_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            //WindowState = FormWindowState.Minimized;
            //ShowInTaskbar = false;
            if (videoViewPanel != null)
            {
                videoViewPanel.Stop();
                videoViewPanel.Dispose();
                videoViewPanel = null;
                //销毁视频对象
            }

        }
        #endregion

        #region 选择并预览视频文件
        private void buttonOpenFileView_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileViewDialog = new OpenFileDialog();
            OpenFileViewDialog.Filter = "Video|*.mp4;*.wmv;*.avi;*.flv;|Picture|*.jpg;*.png;*.gif;*.bmp;*.dng;|All|*.*;";
            DialogResult OpenResultView = OpenFileViewDialog.ShowDialog();
            if (OpenResultView == DialogResult.OK)
            {
                try
                {
                    SetFile.Default.TempViewPath = OpenFileViewDialog.FileName;
                    if (videoViewPanel != null)
                    {
                        if (videoViewPanel.Playing)
                        {
                            videoViewPanel.Stop();
                            videoViewPanel.Dispose();
                            videoViewPanel = null;
                        }
                    }

                    videoViewPanel = new Video(SetFile.Default.TempViewPath);

                    //控制播放视频窗口的大小（此项目是把视频放到一个panel中，panelView是一个panel）
                    int width = panelView.Width;
                    int height = panelView.Height;
                    videoViewPanel.Owner = panelView;
                    videoViewPanel.Owner.Width = width;
                    videoViewPanel.Owner.Height = height;

                    videoViewPanel.Play();
                }
                catch (DirectXException ee)
                {
                    MessageBox.Show(ee.Message);
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
            OpenFileViewDialog.Dispose();
        }
        #endregion

        #region 打开或新建 BackGround 窗口
        private void buttonBackGround_Click(object sender, EventArgs e)
        {
            int ScreenCount = ComboBoxAllScreens.SelectedIndex;
            if (videoViewPanel!=null)
            {
                if (videoViewPanel.Playing)
                {
                    videoViewPanel.Pause();
                }
            }
            try
            {
                if (backGroundPtr == IntPtr.Zero)
                {
                    formBackGround = new FormBackGround();
                    backGroundPtr = formBackGround.Handle;

                    if (SetFile.Default.TempViewPath != null)
                    {
                        formBackGround.VideoBackGroundPlay(SetFile.Default.TempViewPath);
                        //formBackGround.
                        //音量控制
                        //formBackGround.BackGPlay(tempPath, viewP.Audio.Volume);
                        //videoViewPanel.Pause();
                    }
                    formBackGround.SetFullScreen(ScreenCount);
                    formBackGround.Show();
                    /*
                    if (SetFile.Default.IsFullScreenOfMainWindow)//Screen.AllScreens.Count() = 1
                    {
                        formBackGround.SetFullScreen(0);
                        formBackGround.Show();
                    }
                    else
                    {
                        if (SetFile.Default.DefaultFullScreen < Screen.AllScreens.Count())
                        {
                            formBackGround.SetFullScreen(SetFile.Default.DefaultFullScreen);
                            formBackGround.Show();
                        }
                        else
                        {
                            formBackGround.SetFullScreen(0);
                            formBackGround.Show();
                        }
                    }
                    */
                }
                /*else
                {
                    formBackGround.Show();

                    //if (tempPath != null)
                        //formBackGround.BackGPlay(tempPath, viewP.Audio.Volume);
                }*/
            }
            catch (DirectXException ee)
            {
                MessageBox.Show(ee.Message);
            }
            catch (DllNotFoundException ee)
            {
                MessageBox.Show(ee.Message);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        #endregion

        private void FormView_Load(object sender, EventArgs e)
        {
            
            int Count = Screen.AllScreens.Count();
            int i;
            for (i = 0; i < Count; i++)
            {
                String screen = Screen.AllScreens[i].DeviceName;//.ToString();
                ComboBoxAllScreens.Items.Add(screen);
            }
            
            /*
            Screen[] Screens = Screen.AllScreens.ToArray();
            //Screen[Bounds={X=0,Y=0,Width=1366,Height=768} WorkingArea={X=0,Y=0,Width=1366,Height=768} Primary=True DeviceName=\\.\DISPLAY1
            //Screen[Bounds={X=1366,Y=-235,Width=1920,Height=1080} WorkingArea={X=1366,Y=-235,Width=1920,Height=1080} Primary=False DeviceName=\\.\DISPLAY2
            
            foreach (Screen Screen in Screens)
            {
                ComboBoxAllScreens.Items.Add(Screen);
            }
            */
            ComboBoxAllScreens.SelectedIndex = 0;
        }
    }
}
