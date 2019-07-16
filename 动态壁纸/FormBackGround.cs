using Microsoft.DirectX.AudioVideoPlayback;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace 动态壁纸
{
    public partial class FormBackGround :Form
    {
        private IntPtr Ptr = IntPtr.Zero;
        private Video videoBackGround = null;

        public FormBackGround()
        {
            InitializeComponent();
            Ptr = this.Handle;
            SetBackGroud();
        }

        #region 窗口关闭事件
        private void FormBackGround_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            //WindowState = FormWindowState.Minimized;
            //ShowInTaskbar = false;

            //销毁视频对象
        }
        #endregion

        #region 设置为桌面（SetBackGround()）
        private void SetBackGroud()
        {
            Ptr = Win32.FindWindow("Progman", null);
            if (Ptr != IntPtr.Zero)
            {
                IntPtr resultIntPtr = IntPtr.Zero;
                Win32.SendMessageTimeout(Ptr, 0x52c, IntPtr.Zero, IntPtr.Zero, 0, 0x3e8, resultIntPtr);
                Win32.EnumWindows((hwnd, IProgress) =>
                {
                    if (Win32.FindWindowEx(hwnd, IntPtr.Zero, "SHELLDLL_DefView", null) != IntPtr.Zero)
                    {
                        IntPtr tempHwnd = Win32.FindWindowEx(IntPtr.Zero, hwnd, "WorkerW", null);
                        Win32.ShowWindow(tempHwnd, 0);
                    }
                    return true;
                }, IntPtr.Zero);
            }// 窗口置父，设置背景窗口的父窗口为 Program Manager 窗口
            Win32.SetParent(this.Handle, Ptr);
        }
        #endregion

        #region 窗口全屏（SetFullScreen(int i)）
        public void SetFullScreen(int i)
        {
            Win32.MoveWindow(this.Handle, 0, 0, Screen.AllScreens[i].Bounds.Width, Screen.AllScreens[i].Bounds.Height, true);
            
            if (Screen.AllScreens.Count()>1)
            {
                Point PointScree0 = new Point(0, 0);
                Point PointScree1 = new Point(Screen.AllScreens[1].Bounds.Location.X, Screen.AllScreens[1].Bounds.Location.Y);
                int k;
                for (k = 0; k < Screen.AllScreens.Count() - 1; k++)
                {
                    if (Screen.AllScreens[k].Bounds.Location.X < Screen.AllScreens[k + 1].Bounds.Location.X)
                    {
                        PointScree0.X = 0;
                        PointScree1.X = Screen.AllScreens[k].Bounds.Width;
                    }
                    if (Screen.AllScreens[k].Bounds.Location.Y > Screen.AllScreens[k + 1].Bounds.Location.Y)
                    {
                        PointScree0.Y = this.DesktopBounds.Location.Y;
                        PointScree1.Y = 0;
                    }

                }
            }
            
            //textBox1.Text = textBox1.Text + PointScree0.ToString()+ PointScree1.ToString();

            if (i == 0)
            {
                Win32.MoveWindow(this.Handle, this.DesktopBounds.Location.X, -this.DesktopBounds.Location.Y, Screen.AllScreens[i].Bounds.Width, Screen.AllScreens[i].Bounds.Height, true);
            }
            else
            {
                Win32.MoveWindow(this.Handle, Screen.AllScreens[i].Bounds.X, 0, Screen.AllScreens[i].Bounds.Width, Screen.AllScreens[i].Bounds.Height, true);

            }
        }
        #endregion

        public void VideoBackGroundPlay(string Path)
        {
            if (videoBackGround != null)
            {
                if (videoBackGround.Playing)
                {
                    videoBackGround.Stop();
                    videoBackGround.Dispose();
                    videoBackGround = null;
                }
            }

            videoBackGround = new Video(Path);
            
            //控制播放视频窗口的大小（此项目是把视频放到一个panel中，panelView是一个panel）
            int width = this.Width;
            int height = this.Height;
            videoBackGround.Owner = this;//panelBackGround;
            videoBackGround.Owner.Width = width;
            videoBackGround.Owner.Height = height;
            SetFile.Default.NowVideoTimes = GetMediaTimeLenSecond(Path);
            SetFile.Default.NowPlayingPath = Path;
            BackGroundVideoTimer.Interval = SetFile.Default.NowVideoTimes * 1000;
            videoBackGround.Play();
            BackGroundVideoTimer.Start();
        }

        public void VideoBackGroundPause()
        {
            if (FormMain.backGroundPtr == Ptr)
            {
                if (videoBackGround != null)
                {
                    if (videoBackGround.Playing)
                    {
                        videoBackGround.Pause();
                        BackGroundVideoTimer.Stop();
                    }
                    else
                    {
                        videoBackGround.Play();
                        BackGroundVideoTimer.Start();
                    }
                }
            }
        }

        public void VideoBackGroundStop()
        {
            if (FormMain.backGroundPtr == Ptr)
            {
                if (videoBackGround != null)
                {
                    if (videoBackGround.Playing)
                    {
                        videoBackGround.Stop();
                        videoBackGround.Dispose();
                        videoBackGround = null;
                    }
                    else
                    {
                        videoBackGround.Dispose();
                        videoBackGround = null;
                    }
                }
            }
        }

        #region GetVideoTimeLong(GetMediaTimeLenSecond(string path))
        /// <summary>
        /// 长度秒(支持mp4?)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static int GetMediaTimeLenSecond(string path)
        {
            try
            {
                Shell32.Shell shell = new Shell32.Shell();
                //文件路径               
                Shell32.Folder folder = shell.NameSpace(path.Substring(0, path.LastIndexOf("\\")));
                //文件名称             
                Shell32.FolderItem folderitem = folder.ParseName(path.Substring(path.LastIndexOf("\\") + 1));
                string len;
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    len = folder.GetDetailsOf(folderitem, 27);
                }
                else
                {
                    len = folder.GetDetailsOf(folderitem, 21);
                }

                string[] str = len.Split(new char[] { ':' });
                int sum = 0;
                sum = int.Parse(str[0]) * 60 * 60 + int.Parse(str[1]) * 60 + int.Parse(str[2]);

                return sum;
            }
            catch (Exception ex) { return 0; }
        }
        #endregion

        private void BackGroundVideoTimer_Tick(object sender, EventArgs e)
        {
            if (videoBackGround != null)
            {
                if (videoBackGround.Playing)
                {
                    videoBackGround.Stop();
                    BackGroundVideoTimer.Stop();
                    videoBackGround.Dispose();
                    videoBackGround = null;
                    videoBackGround = new Video(SetFile.Default.NowPlayingPath);

                    //控制播放视频窗口的大小（此项目是把视频放到一个panel中，panelView是一个panel）
                    int width = this.Width;
                    int height = this.Height;
                    videoBackGround.Owner = this;//panelBackGround;
                    videoBackGround.Owner.Width = width;
                    videoBackGround.Owner.Height = height;
                    videoBackGround.Play();
                    BackGroundVideoTimer.Start();
                }
            }
        }
    }
}
