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

                    try
                    {
                        videoViewPanel = new Video(SetFile.Default.TempViewPath);
                        //控制播放视频窗口的大小（此项目是把视频放到一个panel中，panelView是一个panel）
                        
                        try
                        {
                            int width = panelView.Width;
                            int height = panelView.Height;
                            videoViewPanel.Owner = panelView;
                            videoViewPanel.Owner.Width = width;
                            videoViewPanel.Owner.Height = height;
                        }
                        catch (Exception ee)
                        {
                            MessageBox.Show(ee.Message);
                        }

                    }
                    catch (DirectXException ee)
                    {
                        MessageBox.Show(ee.ToString());
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.Message);
                    }

                    


                    videoViewPanel.Play();
                }
                /*
                catch (DirectXException ee)
                {
                    MessageBox.Show(ee.ToString());
                }
                */
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
                        
                    }
                    formBackGround.SetFullScreen(ScreenCount);
                    formBackGround.Show();
                }
                else
                {
                    formBackGround.VideoBackGroundStop();
                    if (SetFile.Default.TempViewPath != null)
                    {
                        formBackGround.VideoBackGroundPlay(SetFile.Default.TempViewPath);
                        //SetFile.Default.NowPlayingPath = SetFile.Default.TempViewPath;
                    }
                }
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
            ComboBoxAllScreens.SelectedIndex = 0;
        }

        private void panelView_DoubleClick(object sender, EventArgs e)
        {
            PausepanelView();
        }

        private void PausepanelView()
        {
            if (videoViewPanel != null)
            {
                if (videoViewPanel.Playing)
                {
                    videoViewPanel.Pause();
                }
            }
        }

        private void panelView_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panelView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PausepanelView();

        }

        
    }
}
