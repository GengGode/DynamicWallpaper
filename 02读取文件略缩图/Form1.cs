using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02读取文件略缩图
{
    public partial class Form1 :Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public bool TCBack()
        {
            return false;
        }
        public void E_Get(PaintEventArgs e)
        {
            Image.GetThumbnailImageAbort myCBack = new Image.GetThumbnailImageAbort(TCBack);
            Bitmap myBitmap = new Bitmap("C:\\Users\\GengG\\source\\repos\\动态壁纸V7\\动态壁纸V7\\Resources\\G_.png");
            Image myT = myBitmap.GetThumbnailImage(1024, 1024, myCBack, IntPtr.Zero);
            e.Graphics.DrawImage(myT, 150, 75);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image.GetThumbnailImageAbort myCBack = new Image.GetThumbnailImageAbort(TCBack);
            Bitmap myBitmap = new Bitmap("C:\\Users\\GengG\\source\\repos\\动态壁纸V7\\动态壁纸V7\\Resources\\G_.png");
            Image myT = myBitmap.GetThumbnailImage(40, 40, myCBack, IntPtr.Zero);
            pictureBox1.Image = myT;
            //e.Graphics.DrawImage(myT, 150, 75);
        }
    }
}
