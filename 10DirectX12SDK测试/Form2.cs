using Microsoft.DirectX.AudioVideoPlayback;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace _10DirectX12SDK测试
{
    public partial class Form2 : Form
    {
        public Video video = null;
        public Size videoSize = new Size(100, 100);
        public Point absZeros = new Point(0, 0);
        public int ptrDisplay = -1;

        private IntPtr Ptr = IntPtr.Zero;

        public Form2(string path, Point mAbsZeros,int mptrDisplay)
        {
            Ptr = this.Handle;
            absZeros = mAbsZeros;
            ptrDisplay = mptrDisplay;

            InitializeComponent();

            SetBackGroud();
            video = new Video(path);
            videoSize.Height = Height;
            videoSize.Width = Width;
            video.Owner = this;
            video.Play();
            video.Ending += onVideo_Ending;
            Height = videoSize.Height;
            Width = videoSize.Width;
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Show();
            absZeros = getAbsZeros();
            SetFullScreen(ptrDisplay);
            
        }

        private void onVideo_Ending(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            //if (video.StopPosition == video.Duration)
            //{
            //    video.CurrentPosition = 0;
            //    video.Play();
            //}
            //else
            //{
            //    MessageBox.Show(video.StopPosition.ToString() + ' ' + video.Duration);
            //}

            video.CurrentPosition = 0;
            video.Play();
        }

        public void SetFullScreen(int i)
        {
            Win32.MoveWindow(this.Handle, Screen.AllScreens[i].Bounds.Left- absZeros.X, Screen.AllScreens[i].Bounds.Top- absZeros.Y, Screen.AllScreens[i].Bounds.Width, Screen.AllScreens[i].Bounds.Height, true);

            //MessageBox.Show((Screen.AllScreens[i].Bounds.Left - absZeros.X).ToString() + " " + (Screen.AllScreens[i].Bounds.Top - absZeros.Y).ToString());
        }

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

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
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
