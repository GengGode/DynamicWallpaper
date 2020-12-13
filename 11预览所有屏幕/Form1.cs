using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11预览所有屏幕
{
    public partial class Form1 : Form
    {
        public Bitmap bit = null;
        public static Rectangle rect;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rectangle mRect=getAllScrRect();
            get1(mRect);

        }

        void get1(Rectangle mRect)
        {
            if (rect == mRect)
            {
                Graphics g = Graphics.FromImage(bit);
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.CopyFromScreen(mRect.Left, mRect.Top, 0, 0, new Size(mRect.Width, mRect.Height));
                pictureBox1.Image = bit;
            }
            else
            {
                rect = mRect;
                if (bit!=null)
                {
                    bit.Dispose();
                    bit = null;
                }
                bit = new Bitmap(mRect.Width, mRect.Height);
                Graphics g = Graphics.FromImage(bit);
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.CopyFromScreen(mRect.Left, mRect.Top, 0, 0, new Size(mRect.Width, mRect.Height));
                pictureBox1.Image = bit;
                g.Dispose();
                //bit.Dispose();
                //bit = null;
            }

            //DeleteObject(bit);
            //bit.Dispose();

        }

        Rectangle getAllScrRect()
        {
            Rectangle res=new Rectangle(0,0,0,0);

            Point absLT = new Point(Screen.PrimaryScreen.Bounds.Left, Screen.PrimaryScreen.Bounds.Top);
            Point absRB = new Point(Screen.PrimaryScreen.Bounds.Right, Screen.PrimaryScreen.Bounds.Bottom);

            //res = Screen.PrimaryScreen.Bounds;
            foreach(Screen scr in Screen.AllScreens)
            {
                //textBox1.Text = textBox1.Text + "\r\n" + absLT.ToString() + ' ' + absRB.ToString()+' '+ scr.Bounds.ToString();

                if (absLT.X > scr.Bounds.Left) absLT.X = scr.Bounds.Left;
                if (absLT.Y > scr.Bounds.Top) absLT.Y = scr.Bounds.Top;
                if (absRB.X < scr.Bounds.Right) absRB.X = scr.Bounds.Right;
                if (absRB.Y < scr.Bounds.Bottom) absRB.Y = scr.Bounds.Bottom;
                //MessageBox.Show(scr.Bounds.ToString());
            }
            res = new Rectangle(absLT.X, absLT.Y ,absRB.X - absLT.X, absRB.Y - absLT.Y);

            //textBox1.Text = textBox1.Text + "\r\n" +absLT.ToString()+' '+absRB.ToString()+ ' ' + res.ToString();
            
            return res;
        }

        [DllImport("coredll.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject(IntPtr hgdiobj);
    }
}
