using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Net;
using BaiduCang;

namespace rainfall.App.UpdateForm
{
    public partial class frmUpdate : Form
    {
        private static string APPPATH = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string DOWNPATH = APPPATH + "temp";
        private readonly string DownloadXMLPath = DOWNPATH + "\\update.ini";
        private readonly string APPBASEPATH = APPPATH + "base.ini";
        private bool m_bIsOK = true;
        private string m_pRarFileName;
        private Thread m_pUpdateThread = null;
        public frmUpdate(string rarFileName)
        {
            m_pRarFileName = rarFileName;
            InitializeComponent();
        }
        public frmUpdate()
        {
            m_pRarFileName = IniHelper.IniReadValue("APP", "File", DownloadXMLPath); ;
            InitializeComponent();
        }
        void SetProcessBarValue(int n)
        {
            if (this.InvokeRequired)
            {
                Action<ProgressBar> SetValue = (X) =>
                {
                    X.Value = n;
                };
                Invoke(SetValue, m_pBarProcess);
            }
            else
            {
                m_pBarProcess.Value = n;
            }
        }
        void SetLableText(string text)
        {
            if (this.InvokeRequired)
            {
                Action<Label> SetValue = (X) =>
                {
                    X.Text = text;
                };
                Invoke(SetValue, m_pLableMessage);
            }
            else
            {
                m_pLableMessage.Text = text;
            }
        }
        void SetButtonEnable()
        {
            if (this.InvokeRequired)
            {
                Action<Button> SetValue = (X) =>
                {
                    X.Enabled = true;
                };
                Invoke(SetValue, m_pBtnUpdate);
            }
            else
            {
                m_pBtnUpdate.Enabled = true;
            }
        }
        private void frmUpdate_Load(object sender, EventArgs e)
        {
            m_pUpdateThread = new Thread(new ThreadStart(UpdateRainfalls));
            m_pUpdateThread.Start();
        }
        void UpdateRainfalls()
        {
            Thread.Sleep(1000);
            SetProcessBarValue(10);
            SetLableText("正在关闭雨量计...");
            if (!KillRainfallProcess())
            {
                SetLableText("雨量计没有运行,将直接执行安装程序...");
            }
            Thread.Sleep(2000);
            SetProcessBarValue(30);
            SetLableText("开始安装....");
            if (SetupNewSoft())
            {
                Thread.Sleep(2000);
                SetProcessBarValue(90);
                SetLableText("安装完成,准备重启...");
                string szRemoteAppVersion = IniHelper.IniReadValue("APP", "Version", DownloadXMLPath);
                IniHelper.IniWriteValue("基本信息", "软件版本", szRemoteAppVersion, APPBASEPATH);
                IniHelper.IniWriteValue("基本信息", "更新时间", DateTime.Now.ToString(), APPBASEPATH);
                string devid = IniHelper.IniReadValue("基本信息", "更新标识", APPBASEPATH);
                
                try
                {
                    SetProcessBarValue(100);
                    SetLableText("正在向服务器提交更新完成标识...");

                    string loginUrl = "http://www.zzdawei.com/app/rainfalls.aspx";
                    Encoding encoding = Encoding.GetEncoding("gb2312");
                    IDictionary<string, string> parameters = new Dictionary<string, string>();
                    parameters.Add("id", devid);
                    parameters.Add("version", szRemoteAppVersion);
                    HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponse(loginUrl, parameters, null, null, encoding, null);
                    Thread.Sleep(1000);
                }
                catch( Exception e)
                {
                    SetLableText("提交更新标识失败:" + e.Message);
                }
                SetButtonEnable();
                Thread.Sleep(3000);
                this.Close();
            }
            else
            {
                SetLableText("安装失败,更新程序将自动关闭...");
                SetButtonEnable();
                Thread.Sleep(3000);
            }

        }

        private void RestartRainfalls()
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = System.IO.Path.Combine(Application.StartupPath, "rainfalls.exe");
                p.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show("重启失败原因:" + e.Message);
            }
        }
        private bool KillRainfallProcess()
        {
            bool bIsKill = false;
            Process[] processes = Process.GetProcessesByName("rainfalls");
            foreach (Process p in processes)
            {
                p.Kill();
                p.Close();
                bIsKill = true;
            }
            System.Threading.Thread.Sleep(1000);
            return bIsKill;
        }
        private bool SetupNewSoft()
        {
            bool bIsSetupDone = true;
            try
            {
                string szFile = string.Format("{0}\\{1}", DOWNPATH, m_pRarFileName);
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
                MessageBox.Show("解压缩失败原因:" + e.Message);
            }
            return bIsSetupDone;
        }

        private void frmUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_bIsOK)
                RestartRainfalls();
            if (m_pUpdateThread != null)
                if (m_pUpdateThread.IsAlive)
                    m_pUpdateThread.Abort();
        }
      
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
