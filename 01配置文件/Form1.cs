using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01配置文件
{
    public partial class Form1 :Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //public static Con
        private void button1_Click(object sender, EventArgs e)
        {
            //string filepath=ConfigurationManager.
            label1.Text = Set.Default.path;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="")
            {
                Set.Default.path = textBox1.Text;
                Set.Default.Save();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Properties.Settings.Default.FileName = "path";
            Properties.Settings.Default.Save();
            Set.Default.Reset();
            ;
        }
    }
}
