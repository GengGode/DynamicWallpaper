using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 动态壁纸
{
    public partial class FormSet : Form
    {
        public FormSet()
        {
            InitializeComponent();
            labelDefaultPath.Text = "DefaultPath: " + SetFile.Default.DefaultPath;
        }

        private void buttonDefaultPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog DefaultPath = new OpenFileDialog();
            DefaultPath.Filter = "Video|*.mp4;*.wmv;*.avi;*.flv;|Picture|*.jpg;*.png;*.gif;*.bmp;*.dng;|All|*.*;";
            DialogResult OpenDefaultPath = DefaultPath.ShowDialog();
            if (OpenDefaultPath == DialogResult.OK)
            {
                SetFile.Default.DefaultPath = DefaultPath.FileName;
                labelDefaultPath.Text = "DefaultPath: " + SetFile.Default.DefaultPath;
            }
        }

        private void FormSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
