using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _05多屏全屏
{
    public partial class Form1 : Form
    {
        private IntPtr Ptr = IntPtr.Zero;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            int i = 0;
            this.DesktopBounds = new Rectangle(Screen.AllScreens[i].WorkingArea.X, Screen.AllScreens[i].WorkingArea.Y, Screen.AllScreens[i].WorkingArea.Width, Screen.AllScreens[i].WorkingArea.Height);
            this.Location = new Point(Screen.AllScreens[i].Bounds.X, Screen.AllScreens[i].Bounds.Y);

            SetBackGround();
        }

        #region 设置为桌面（SetBackGround()）
        private void SetBackGround()
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
    }
}
