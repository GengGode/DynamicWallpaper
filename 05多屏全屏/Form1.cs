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
            SetBackGround();
            SetFullScreen(comboBox1.SelectedIndex);

            textBox1.Text = textBox1.Text + this.DesktopBounds.ToString() + this.Location.ToString();
            textBox1.Text = textBox1.Text+ this.DesktopBounds.Location.Y+ Screen.AllScreens[comboBox1.SelectedIndex].ToString();
        }

        #region 窗口全屏（SetFullScreen(int i)）
        public void SetFullScreen(int i)
        {
            Win32.MoveWindow(this.Handle, 0, 0, Screen.AllScreens[comboBox1.SelectedIndex].Bounds.Width, Screen.AllScreens[comboBox1.SelectedIndex].Bounds.Height, true);

            Point PointScree0 = new Point(0, 0);
            Point PointScree1 = new Point(Screen.AllScreens[1].Bounds.Location.X, Screen.AllScreens[1].Bounds.Location.Y);
            int k;
            for (k=0;k< Screen.AllScreens.Count()-1;k++)
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
            //textBox1.Text = textBox1.Text + PointScree0.ToString()+ PointScree1.ToString();

            if (comboBox1.SelectedIndex == 0)
            {
                Win32.MoveWindow(this.Handle, this.DesktopBounds.Location.X, -this.DesktopBounds.Location.Y, Screen.AllScreens[comboBox1.SelectedIndex].Bounds.Width, Screen.AllScreens[comboBox1.SelectedIndex].Bounds.Height, true);
            }
            else
            {
                Win32.MoveWindow(this.Handle, Screen.AllScreens[comboBox1.SelectedIndex].Bounds.X, 0, Screen.AllScreens[comboBox1.SelectedIndex].Bounds.Width, Screen.AllScreens[comboBox1.SelectedIndex].Bounds.Height, true);
                
            }
        }
        #endregion

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
                        //Win32.SetWindowPos();
                    }
                    return true;
                }, IntPtr.Zero);
            }// 窗口置父，设置背景窗口的父窗口为 Program Manager 窗口
            Win32.SetParent(this.Handle, Ptr);
            
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            int Count = Screen.AllScreens.Count();
            int i;
            for (i = 0; i < Count; i++)
            {
                String screen = Screen.AllScreens[i].DeviceName;//.ToString();
                comboBox1.Items.Add(screen);
            }
            comboBox1.SelectedIndex = 0;
        }
    }
}
