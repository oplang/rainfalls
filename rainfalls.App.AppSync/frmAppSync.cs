using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using Rainfall.UI.TimeDialog;
using System.Net;
using rainfall.App.UpdateForm;
using BaiduCang;
namespace rainfalls.App.AppSync
{
    public partial class frmAppSync : Form
    {
        private Thread TimeSyncThread = null;
        private static string APPPATH = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string DOWNPATH = APPPATH + "temp";
        private readonly string DownloadXMLPath = DOWNPATH + "\\update.ini";
        private readonly string APPBASEPATH = APPPATH + "base.ini";
        private string m_pUpdateID = null;
        private string szHost = "139.129.8.107";
        private string m_pVersion = null;
        private string m_pFileName = null;
        private long m_nDownLoadSize = 0;
        public frmAppSync()
        {
            szHost = CINIFile.IniReadValue("基本信息", "FTP_IP", AppDomain.CurrentDomain.BaseDirectory + "base.ini");
            m_pUpdateID = CINIFile.IniReadValue("基本信息", "更新标识", AppDomain.CurrentDomain.BaseDirectory + "base.ini");
            NetWorkCls.onNotify += new Notity(NetWorkCls_onNotify);
            InitializeComponent();
        }

        void NetWorkCls_onNotify(string msg)
        {
            AddMsg(msg);
        }
        public void Run()
        {
            NetWorkCls.Check1Minute();
            if (NetWorkCls.CheckServeStatus())
            {
                TimeSync();
                UpdateSoft();
            }
        }
        private void frmUpdate_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "rec\\update.png");
            TimeSyncThread = new Thread(new ThreadStart(Run));
            TimeSyncThread.Name = "软件更新";
            TimeSyncThread.Start();
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Tick += new EventHandler(t_Tick);
            t.Start();
        }

        void t_Tick(object sender, EventArgs e)
        {
            this.lbTime.Text = DateTime.Now.ToString();
        }

        void AddMsg(string msg)
        {
            msg = string.Format("{0}-->{1}", System.DateTime.Now.ToString(), msg);
            if (this.InvokeRequired)
            {
                Action<ListBox> AppendMsg = (X) =>
                {
                    X.Items.Add(msg);
                    X.SelectedIndex = X.Items.Count - 1;
                    X.SelectedIndex = -1;
                };
                Invoke(AppendMsg, this.msgBox);
            }
            else
            {
                this.msgBox.Items.Add(msg);
                this.msgBox.SelectedIndex = this.msgBox.Items.Count - 1;
                this.msgBox.SelectedIndex = -1;
            }
        }
        void UpdateSoft()
        {
            DownLoadUpdateXML();
        }
        private void DownLoadUpdateXML()
        {
            if (!string.IsNullOrEmpty(m_pUpdateID))
            {
                using (var webClient = new WebClient())
                {
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    webClient.DownloadFileAsync(new Uri(string.Format("http://www.zzdawei.com/rainfalls.update.app/{0}/update.ini", m_pUpdateID)), DownloadXMLPath);
                }
            }
            else
            {
                AddMsg("没有找到本地设备标识,请检查Base.ini文件");
            }
        }
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (File.Exists(DownloadXMLPath))
                {
                    long lRemoteAppVersion;
                    string szRemoteAppVersion = CINIFile.IniReadValue("APP", "Version", DownloadXMLPath);
                    if (!string.IsNullOrEmpty(szRemoteAppVersion))
                    {
                        m_pVersion = szRemoteAppVersion;
                        szRemoteAppVersion = szRemoteAppVersion.Replace(".", "");
                        if (long.TryParse(szRemoteAppVersion, out lRemoteAppVersion))
                        {
                            string szLocalAppVersion = CINIFile.IniReadValue("基本信息", "软件版本", APPBASEPATH);
                            szLocalAppVersion = szLocalAppVersion.Replace(".", "");
                            long lpLocalAppVersion = long.TryParse(szLocalAppVersion, out lpLocalAppVersion) ? lpLocalAppVersion : 0;
                            if (lRemoteAppVersion > lpLocalAppVersion)
                            {
                                AddMsg("发现新版本,准备下载");
                                string dFile = CINIFile.IniReadValue("APP", "File", DownloadXMLPath);
                                DownLoadFile(dFile);
                            }
                            else
                            {
                                AddMsg("当前已是最新版本");
                            }
                        }
                    }
                }
            }
            else
            {
                    AddMsg(string.Format("检查更新时发生错误:{0}", e.Error.Message));
            }
        }

        private void DownLoadFile(string downLoadFileName)
        {
            using (var webClient = new WebClient())
            {
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
                m_pFileName = downLoadFileName;
                webClient.DownloadFileAsync(new Uri(string.Format("http://www.zzdawei.com/rainfalls.update.app/{0}/{1}", m_pUpdateID, downLoadFileName)), string.Format("{0}\\{1}", DOWNPATH, downLoadFileName));
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
                FileInfo fileInfo = new FileInfo(string.Format("{0}\\{1}", DOWNPATH, m_pFileName));
                if (fileInfo.Length == m_nDownLoadSize)
                {
                    AddMsg("下载完成,准备安装");
                    if (SetupNewSoft())
                    {
                        CINIFile.IniWriteValue("基本信息", "软件版本", m_pVersion, APPBASEPATH);
                        CINIFile.IniWriteValue("基本信息", "更新时间", DateTime.Now.ToString(), APPBASEPATH);
                        try
                        {
                            AddMsg("服务器提交更新完成标识...");
                            string loginUrl = "http://www.zzdawei.com/app/rainfalls.aspx";
                            Encoding encoding = Encoding.GetEncoding("gb2312");
                            IDictionary<string, string> parameters = new Dictionary<string, string>();
                            parameters.Add("id", m_pUpdateID);
                            parameters.Add("version", m_pVersion);
                            HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponse(loginUrl, parameters, null, null, encoding, null);
                        }
                        catch (Exception err)
                        {
                            AddMsg("提交更新标识失败:" + err.Message);
                        }

                    }
                }
                else
                {
                    AddMsg("文件下载不完整,请重试");
                }
            }
            else
            {
               AddMsg(string.Format("下载文件时发生错误:{0}", e.Error.Message));
               AddMsg(string.Format("下载文件时发生错误,请重试"));
            }
        }
        private bool SetupNewSoft()
        {
            bool bIsSetupDone = true;
            try
            {
                string szFile = string.Format("{0}\\{1}", DOWNPATH, m_pFileName);
                if (File.Exists(szFile))
                {
                    Unrar unrar = new Unrar();
                    unrar.DestinationPath = APPPATH;
                    unrar.Open(szFile, Unrar.OpenMode.Extract);
                    while (unrar.ReadHeader())
                    {
                        unrar.Extract();
                    }
                    if (unrar != null)
                        unrar.Close();
                }

            }
            catch (Exception e)
            {
                bIsSetupDone = false;
                AddMsg("解压缩失败原因:" + e.Message);
            }
            return bIsSetupDone;
        }

        #region 时间同步
        /// <summary>
      /// 时间同步
      /// </summary>
      
        void TimeSync()
        {
            try
            {
                AddMsg("开始同步系统时间");
                long nStart = DateTime.Now.ToFileTime();
                TcpClient m_pClient = null;
                m_pClient = new TcpClient(szHost, 2012);
                NetworkStream pNS = m_pClient.GetStream();
                byte[] pBuffer = new byte[2048];
                int nBytesRead = 0;
                nBytesRead = pNS.Read(pBuffer, 0, 2048);

                string sz = "";
                if (nBytesRead != 0)
                {
                    ASCIIEncoding pEncoder = new ASCIIEncoding();
                    sz = pEncoder.GetString(pBuffer, 0, nBytesRead);
                }
                m_pClient.Close();

                long nEnd = DateTime.Now.ToFileTime();
                long nDiff = nEnd - nStart;
                long nSvr = long.Parse(sz);
                long nNow = nSvr + nDiff;
                DateTime pNow = DateTime.FromFileTime(nNow);

                SystemTime st = new SystemTime();
                st.FromDateTime(pNow);
                SystemTime.SetLocalTime(ref st);
                AddMsg("时间同步完成");
                //CSQLite.G_CSQLite.WriteRunLogInfoDB("0xD3", "时间同步完成");
                
            }
            catch
            {
                AddMsg("时间同步失败");
                //CSQLite.G_CSQLite.WriteRunLogInfoDB("0xD4", "时间同步失败");
            }
            finally
            {
                AddMsg("请核对系统时间;如果时间错误请及时修改后,进入系统!!!");
            }
        }
        #endregion 
        private void lbUpdate_Click(object sender, EventArgs e)
        {
            if (!TimeSyncThread.IsAlive)
            {
                TimeSyncThread = new Thread(new ThreadStart(Run));
                TimeSyncThread.Name = "软件更新";
                TimeSyncThread.Start();
            }
        }

        private void lbErrChkdsk_Click(object sender, EventArgs e)
        {
            try
            {
                string appName = "C:\\chk.bat";
                Process proc = Process.Start(appName);
            }
            catch(Exception er)
            {
                throw new Exception(er.Message);
            }
            //CSQLite.G_CSQLite.WriteRunLogInfoDB("0xDD", "单击磁盘修复");
        }

        private void lbIntoSys_Click(object sender, EventArgs e)
        {
            if (TimeSyncThread != null)
                if (TimeSyncThread.IsAlive)
                    return;
            string appName = Application.StartupPath + "\\rainfalls.exe";
            Process proc = Process.Start(appName);
        }

        private void lbTime_Click(object sender, EventArgs e)
        {
            //frmDateTimeDlg dlg = new frmDateTimeDlg();
            //if (dlg.ShowDialog() == DialogResult.OK)
            //    this.lbTime.Text = dlg.GetDateTime.ToString();
            //dlg.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form_TimeDialog dlg = new Form_TimeDialog();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                DateTime dt = dlg.GetDateTime;
                SystemTime st = new SystemTime();
                st.FromDateTime(dt);
                SystemTime.SetLocalTime(ref st);
            }
            dlg.Close();
        }
    }
}
