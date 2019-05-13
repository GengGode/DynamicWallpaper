using System;
using System.Windows.Forms;

namespace 动态壁纸
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Diagnostics.Process process = RunningInstance();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain(process));
        }

        public static System.Diagnostics.Process RunningInstance()
        {
            System.Diagnostics.Process current = System.Diagnostics.Process.GetCurrentProcess();
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process process in processes)
            {
                if (process.ProcessName == current.ProcessName)
                {
                    if (process.Id != current.Id) 
                    { 
                        if (process.MainModule.FileName == current.MainModule.FileName)
                        {
                            return process;
                        }
                    }
                }
            }
            return null;
        }
    }
}
