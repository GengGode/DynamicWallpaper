using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04获取视频时长
{
    public partial class Form1 :Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            int a = GetMediaTimeLenSecond("C:\\Users\\GengG\\Desktop\\illya.mp4");
            label1.Text =""+a;
        }
    }

}
