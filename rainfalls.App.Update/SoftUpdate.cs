using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.ComponentModel;
using System.Threading;

namespace rainfalls.App.Update
{
    public delegate void UpdateNotifyDelegate(string msg);
    public class SoftUpdate
    {
        public event UpdateNotifyDelegate OnUpdateNofityEvent;
        private static string APPPATH = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string DOWNPATH = APPPATH + "temp";
        private readonly string DownloadXMLPath = DOWNPATH + "\\update.ini";
        private readonly string APPBASEPATH = APPPATH + "base.ini";
        private string UpdateID = null;
        long m_nDownLoadSize = 0;
        private string m_pVersion = null;
        public string Version
        {
            get { return m_pVersion; }
        }
        public long FileSize
        {
            get { return m_nDownLoadSize; }
        }
        string m_pFileName = null;
        public string FileName
        {
            get { return m_pFileName; }
        }
        public SoftUpdate()
        {
            if (!Directory.Exists(DOWNPATH))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(DOWNPATH);
                directoryInfo.Create();
            }
            UpdateID = IniHelper.IniReadValue("基本信息", "更新标识", APPBASEPATH);
        }
        
        Thread AppUpdateThread = null;
        public void RUNAUTOUPDATE()
        {
            AppUpdateThread = new Thread(new ThreadStart(run));
            AppUpdateThread.Start();
        }
        public void STOPAUTOUPDATE()
        {
            if (AppUpdateThread != null)
                if (AppUpdateThread.IsAlive)
                    AppUpdateThread.Abort();
        }
        void run()
        {
            for (; ; )
            {
                DownLoadUpdateXML();
                Thread.Sleep(5 * 60 * 1000);
            }
        }

        private void DownLoadUpdateXML()
        {
            using (var webClient = new WebClient())
            {
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadFileAsync(new Uri(string.Format("http://www.zzdawei.com/rainfalls.update.app/{0}/update.ini",UpdateID)), DownloadXMLPath);
                
            }
        }
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (File.Exists(DownloadXMLPath))
                {
                    long lRemoteAppVersion;
                    string szRemoteAppVersion = IniHelper.IniReadValue("APP", "Version", DownloadXMLPath);
                    if (!string.IsNullOrEmpty(szRemoteAppVersion))
                    {
                        m_pVersion  = szRemoteAppVersion;
                        szRemoteAppVersion = szRemoteAppVersion.Replace(".", "");
                        if (long.TryParse(szRemoteAppVersion, out lRemoteAppVersion))
                        {
                            string szLocalAppVersion = IniHelper.IniReadValue("基本信息", "软件版本", APPBASEPATH);
                            szLocalAppVersion = szLocalAppVersion.Replace(".", "");
                            long lpLocalAppVersion = long.TryParse(szLocalAppVersion, out lpLocalAppVersion) ? lpLocalAppVersion : 0;
                            if (lRemoteAppVersion > lpLocalAppVersion)
                            {
                                string dFile = IniHelper.IniReadValue("APP", "File", DownloadXMLPath);
                                DownLoadFile(dFile);
                            }
                        }
                    }
                }
            }
            else
            {
                if (OnUpdateNofityEvent != null)
                {
                    OnUpdateNofityEvent(string.Format("检查更新时发生错误:{0}", e.Error.Message));
                }
            }
        }
        
        private void DownLoadFile(string downLoadFileName)
        {
            using (var webClient = new WebClient())
            {
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
                m_pFileName = downLoadFileName;
                webClient.DownloadFileAsync(new Uri(string.Format("http://www.zzdawei.com/rainfalls.update.app/{0}/{1}", UpdateID, downLoadFileName)), string.Format("{0}\\{1}", DOWNPATH, downLoadFileName));
            }
        }

        void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            m_nDownLoadSize = e.TotalBytesToReceive;
        }

        void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                FileInfo fileInfo = new FileInfo(string.Format("{0}\\{1}", DOWNPATH, FileName));
                if (fileInfo.Length == FileSize)
                {
                    if (OnUpdateNofityEvent != null)
                    {
                        OnUpdateNofityEvent("OK");
                    }
                }
                else
                {
                    if (OnUpdateNofityEvent != null)
                    {
                        OnUpdateNofityEvent("下载的文件不完整");
                    }
                }
            }
            else
            {
                if (OnUpdateNofityEvent != null)
                {
                    OnUpdateNofityEvent(string.Format("下载文件时发生错误:{0}",e.Error.Message));
                }
            }
        }
       

       
    }
}
