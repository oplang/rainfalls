using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;

namespace rainfalls.App.AppSync
{
    public delegate void Notity(string msg);
    public class NetWorkCls
    {
        public static event Notity onNotify;
        static string url = "www.baidu.com";
        static string[] urls = url.Split(new char[] { ';' });
        static void notify(string msg)
        {
            if (onNotify != null)
            {
                onNotify(msg);
            }
        }
        /// <summary>
        /// 检测网络连接状态
        /// </summary>
        /// <param name="urls"></param>
        public static bool CheckServeStatus()
        {
            int errCount = 0;//ping时连接失败个数

            if (!LocalConnectionStatus())
            {
                onNotify("网络异常~无连接");
                return false;
            }
            else if (!MyPing(urls, out errCount))
            {
                if ((double)errCount / urls.Length >= 0.3)
                {
                    onNotify("网络异常~连接多次无响应");
                    return false;
                }
                else
                {
                    onNotify("网络不稳定");
                    return true;
                }
            }
            else
            {
                onNotify("网络正常");
                return true;
            }
        }
        public static void Check1Minute()
        {
            long t = Time.DateTime2DbTime(DateTime.Now);
            onNotify("正在加载网络设备");
            bool isDone = false;
            do
            {
                int errCount = 0;//ping时连接失败个数

                if (!LocalConnectionStatus())
                {
                    isDone =  false;
                }
                else if (!MyPing(urls, out errCount))
                {
                    if ((double)errCount / urls.Length >= 0.3)
                    {
                        isDone =  false;
                    }
                    else
                    {
                        isDone =  true;
                    }
                }
                else
                {
                    isDone =  true;
                }
                if (isDone)
                    break;
            } while (Time.DateTime2DbTime(DateTime.Now) - t < 60);
            
        }
        #region 网络检测

        private const int INTERNET_CONNECTION_MODEM = 1;
        private const int INTERNET_CONNECTION_LAN = 2;

        [System.Runtime.InteropServices.DllImport("winInet.dll")]
        private static extern bool InternetGetConnectedState(ref int dwFlag, int dwReserved);

        /// <summary>
        /// 判断本地的连接状态
        /// </summary>
        /// <returns></returns>
        private static bool LocalConnectionStatus()
        {
            System.Int32 dwFlag = new Int32();
            if (!InternetGetConnectedState(ref dwFlag, 0))
            {
                return false;
            }
            else
            {
                if ((dwFlag & INTERNET_CONNECTION_MODEM) != 0)
                {
                    return true;
                }
                else if ((dwFlag & INTERNET_CONNECTION_LAN) != 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Ping命令检测网络是否畅通
        /// </summary>
        /// <param name="urls">URL数据</param>
        /// <param name="errorCount">ping时连接失败个数</param>
        /// <returns></returns>
        public static bool MyPing(string[] urls, out int errorCount)
        {
            bool isconn = true;
            Ping ping = new Ping();
            errorCount = 0;
            try
            {
                PingReply pr;
                for (int i = 0; i < urls.Length; i++)
                {
                    pr = ping.Send(urls[i]);
                    if (pr.Status != IPStatus.Success)
                    {
                        isconn = false;
                        errorCount++;
                    }
                }
            }
            catch
            {
                isconn = false;
                errorCount = urls.Length;
            }
            //if (errorCount > 0 && errorCount < 3)
            //  isconn = true;
            return isconn;
        }

        #endregion
    }

}
