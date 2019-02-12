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

namespace 动态壁纸
{
    public partial class FormBackGround :Form
    {
        private IntPtr Ptr = IntPtr.Zero;
        private Video videoBackGround = null;

        public FormBackGround()
        {
            InitializeComponent();
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
        public void SetFullScreen(Byte i)
        {
            
            if(System.Windows.Forms.Screen.AllScreens.Count() != 1)
            {
                if (System.Windows.Forms.Screen.AllScreens.Count() > i)
                {
                    this.Location = new Point(Screen.AllScreens[i].Bounds.X, Screen.AllScreens[i].Bounds.Y);
                    this.Width = Screen.AllScreens[i].Bounds.Width;
                    this.Height = Screen.AllScreens[i].Bounds.Height;
                }
            }
            else
            {
                this.Location = new Point(Screen.AllScreens[0].Bounds.X, Screen.AllScreens[0].Bounds.Y);
                this.Width = Screen.AllScreens[0].Bounds.Width;
                this.Height = Screen.AllScreens[0].Bounds.Height;
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
            int width = panelBackGround.Width;
            int height = panelBackGround.Height;
            videoBackGround.Owner = panelBackGround;
            videoBackGround.Owner.Width = width;
            videoBackGround.Owner.Height = height;

            videoBackGround.Play();
        }
    }
}
