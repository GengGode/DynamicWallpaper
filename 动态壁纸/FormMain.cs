using Microsoft.DirectX;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace 动态壁纸
{
    public partial class FormMain : Form
    {
        private FormView formView = null;
        private FormSet formSet = null;
        private IntPtr viewPtr = IntPtr.Zero;
        public IntPtr setPtr = IntPtr.Zero;

        public FormMain(System.Diagnostics.Process process)
        {
            InitializeComponent();
            if (process != null)//重复打开对应事件
            {
                //notifyIconMain.Visible = false;

                this.Visible = false;
                this.ShowInTaskbar = false;
                this.ShowIcon = false;
                this.Hide();

                notifyIconMain.ShowBalloonTip(10, "程序已运行", "后台已运行动态壁纸", ToolTipIcon.Info);
                //弹出系统通知
                Win32.ShowWindow(process.MainWindowHandle, 10);
                //将已打开程序前置
                //this.Dispose();
                this.Close();
                //Application.ExitThread();
                //自我关闭
            }
            SetDefaultPictureMain();
            if (SetFile.Default.IsFristStatUp == true)
            {
                //SetFile.Default.IsFristStatUp = false;
                //SetFile.Default.Save();
            }
        }

        #region 改变 Default 图片（SetDefaultPictureMain()）
        public void SetDefaultPictureMain()
        {
            try
            {
                pictureBoxMain.ImageLocation = SetFile.Default.DefaultPath;
                Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                Bitmap myBitmap = new Bitmap(SetFile.Default.DefaultPath);
                Image myThumbnail = myBitmap.GetThumbnailImage(40, 40, myCallback, IntPtr.Zero);
                pictureBoxMain.Image = myThumbnail;
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            /*
            */
        }
        #endregion

        #region 委托（ThumbnailCallback()）
        public bool ThumbnailCallback()
        {
            return false;
        }
        #endregion

        #region 打开或新建 View 窗口
        private void buttonView_Click(object sender, EventArgs e)
        {
            try
            {
                if (viewPtr == IntPtr.Zero || formView == null)
                {
                    formView = new FormView();
                    viewPtr = formView.Handle;
                    formView.Show();
                }
                else
                {
                    formView.Show();
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

        #region 打开或新建 Set 窗口
        private void buttonSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (setPtr == IntPtr.Zero)
                {
                    formSet = new FormSet();
                    setPtr = formSet.Handle;
                    formSet.Show();
                }
                else
                {
                    formSet.Show();
                }
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

        private void buttonBackGroundMain_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }
}
