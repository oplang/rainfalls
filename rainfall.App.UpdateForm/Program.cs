using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace rainfall.App.UpdateForm
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool createNew;
            using (System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out createNew))
            {
                if (createNew)
                {
                    if (args.Length == 0)
                        Application.Run(new frmUpdate());
                    else
                        Application.Run(new frmUpdate(args[0]));
                }
                else
                {
                    System.Threading.Thread.Sleep(1000);
                    System.Environment.Exit(1);
                }
            }  
          
        }
    }
}
