using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
namespace rainfalls
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createNew;
            using (System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out createNew))
            {
                if (createNew)
                {
                    //Application.ThreadException += new ThreadExceptionEventHandler(UIThreadException);
                    Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                    //AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                    DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
                    Application.Run(new frmMain());
                }
                else
                {
                    System.Threading.Thread.Sleep(1000);
                    System.Environment.Exit(1);
                }
            }  

        }
        //private static void UIThreadException(object sender, ThreadExceptionEventArgs t)
        //{
        //    try
        //    {

        //        string errorMsg = "Windows窗体线程异常 : \n\n";
        //        MessageBox.Show(errorMsg + t.Exception.Message + Environment.NewLine + t.Exception.StackTrace + t.Exception.TargetSite + t.Exception.Source + t.Exception.InnerException + t.Exception.Data.Values + t.Exception);
        //    }
        //    catch
        //    {
        //        MessageBox.Show("不可恢复的Windows窗体异常，应用程序将退出！");
        //    }
        //}

        //private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        //{
        //    try
        //    {
        //        Exception ex = (Exception)e.ExceptionObject;
        //        string errorMsg = "非窗体线程异常 : \n\n";
        //        MessageBox.Show(errorMsg + ex.Message + Environment.NewLine + ex.StackTrace + ex.TargetSite);
        //    }
        //    catch
        //    {
        //        MessageBox.Show("不可恢复的非Windows窗体线程异常，应用程序将退出！");
        //    }
        //}
    }
}
