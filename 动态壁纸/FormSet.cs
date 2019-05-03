using System;
using System.Windows.Forms;

namespace 动态壁纸
{
    public partial class FormSet : Form
    {
        private FormAbout formAbout = null;
        private IntPtr aboutPtr = IntPtr.Zero;

        internal FormAbout FormAbout { get => formAbout; set => formAbout = value; }

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

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            if (FormAbout == null)
            {
                FormAbout = new FormAbout();
                FormAbout.Show();
            }
            else
            {
                FormAbout = new FormAbout();
                FormAbout.Show();
                //FormAbout.Show();
            }
        }
    }
}
