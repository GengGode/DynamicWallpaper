using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06只能运行一个实例
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            bool State=true;

            if (RunningInstance() == null)
            {
                State = true;
            }
            else
            {
                State = false;
                //MessageBox.Show("已经运行了一个实例了。");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(State));

        }
        public static System.Diagnostics.Process RunningInstance()
        {
            System.Diagnostics.Process current = System.Diagnostics.Process.GetCurrentProcess();
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process process in processes) //查找相同名称的进程 
            {
                if (process.ProcessName == current.ProcessName) 
                { //确认相同进程的程序运行位置是否一样. 
                  //if (System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("/", @"/") == current.MainModule.FileName)
                    if (process.Id != current.Id) //忽略当前进程 
                    { //Return the other process instance. 
                        if (process.MainModule.FileName == current.MainModule.FileName) 
                        {
                            return process;
                        }
                    }
                }
            } //No other instance was found, return null. 
            return null;
        }
    }
    
}
