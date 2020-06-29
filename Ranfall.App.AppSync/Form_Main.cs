using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Diagnostics;
using Rainfall.UI.TimeDialog;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.IO;
namespace Rainfall.App.AppSync
{

    public partial class Form_Main : Form
    {
        private Thread TimeSyncThread = null;
        private Thread UpdateThread = null;
        private Thread DialUpThread = null;
        protected delegate void AddListBoxMsgEvent(string msg);
        protected event AddListBoxMsgEvent addListBoxMsgEvent;
        protected IDbManager m_pDbManager = null;
        protected IDbManager m_pDbTempManager = null;
        protected string szHost = null;
        protected string szPort = null;
        protected delegate void ShowMsgBox();
        string source = Application.StartupPath + "\\Update";
        string destination = Application.StartupPath;
        string szPath = Application.StartupPath + "\\RainMapConfig.ini";
        protected int iUpdate = 0;
        GSMMODEM gm = new GSMMODEM();
        #region 声明WIN32API函数以及结构 **************************************

        [Serializable,
        System.Runtime.InteropServices.StructLayout
            (System.Runtime.InteropServices.LayoutKind.Sequential,
            CharSet = System.Runtime.InteropServices.CharSet.Auto
            ),
        System.Runtime.InteropServices.BestFitMapping(false)]
        private struct WIN32_FIND_DATA
        {
            public int dwFileAttributes;
            public int ftCreationTime_dwLowDateTime;
            public int ftCreationTime_dwHighDateTime;
            public int ftLastAccessTime_dwLowDateTime;
            public int ftLastAccessTime_dwHighDateTime;
            public int ftLastWriteTime_dwLowDateTime;
            public int ftLastWriteTime_dwHighDateTime;
            public int nFileSizeHigh;
            public int nFileSizeLow;
            public int dwReserved0;
            public int dwReserved1;
            [System.Runtime.InteropServices.MarshalAs
                (System.Runtime.InteropServices.UnmanagedType.ByValTStr,
                SizeConst = 260)]
            public string cFileName;
            [System.Runtime.InteropServices.MarshalAs
                (System.Runtime.InteropServices.UnmanagedType.ByValTStr,
                SizeConst = 14)]
            public string cAlternateFileName;
        }

        [System.Runtime.InteropServices.DllImport
            ("kernel32.dll",
            CharSet = System.Runtime.InteropServices.CharSet.Auto,
            SetLastError = true)]
        private static extern IntPtr FindFirstFile(string pFileName, ref WIN32_FIND_DATA pFindFileData);

        [System.Runtime.InteropServices.DllImport
            ("kernel32.dll",
           CharSet = System.Runtime.InteropServices.CharSet.Auto,
            SetLastError = true)]
        private static extern bool FindNextFile(IntPtr hndFindFile, ref WIN32_FIND_DATA lpFindFileData);

        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FindClose(IntPtr hndFindFile);

        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool DeleteFile(string pFileName);
        #endregion

        public Form_Main()
        {
            InitializeComponent();
        }
        protected void DialUp()
        {
             
           
                  TimeSyncThread = new Thread(new ThreadStart(TimeSync));
                  TimeSyncThread.Start();
            

        }
        protected void UpdateProcess()
        {
            bool isUpdate = false;
            if (!isConnected())
            {
                CRasDial ras = new CRasDial();
                ras.EntryName = "cmcc";
                ras.UserName = "";
                ras.Password = "";
                AddMsg("正在拨号");
                CSQLite.G_CSQLite.WriteRunLogInfoDB("0xD1", "正在拨号");
                int result = ras.DialUp();
                if (result == 0)
                {
                    AddMsg("拨号成功");
                    CSQLite.G_CSQLite.WriteRunLogInfoDB("0xD2", "拨号成功");
                }
                else
                {
                    AddMsg("[拨号失败]错误ID号：" + result);
                    AddMsg("请核对系统时间;如果时间错误请及时修改后,进入系统!!!");
                    CSQLite.G_CSQLite.WriteRunLogInfoDB("0xFF" + result, "拨号失败");
                    return;
                }
            }
            if (isConnected())
            {
                CUpdate update = new CUpdate(szHost);
                string msg;
                if (update.CheckUpdates(out msg))
                {
                    AddMsg(msg);
                    if (update.downLoad(out msg))
                    {
                        AddMsg(msg);
                        isUpdate = true;
                    }
                    else
                    {
                        AddMsg(msg);
                    }
                }
                else
                {
                    AddMsg(msg);
                }
                if (isUpdate)
                    StartProcess();
            }
        }
        private void StartProcess()
        {
            try
            {
                if (!CheckProcessExists())
                {
                    using (Process p = new Process())
                    {
                        p.StartInfo.FileName = System.IO.Path.Combine(Application.StartupPath, "Update.exe");
                        p.StartInfo.Arguments = "Update.exe";
                        p.StartInfo.UseShellExecute = true;
                        p.Start();
                        p.WaitForInputIdle(10000);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("更新程序启动失败：{0} {1}", ex.Source, ex.Message));
            }
        }

        private static bool CheckProcessExists()
        {
            Process[] processes = Process.GetProcessesByName("Update");
            foreach (Process p in processes)
            {
                if (String.Compare(Path.Combine(Application.StartupPath, "Update.exe"), p.MainModule.FileName, false) == 0)
                    return true;
            }
            return false;
        }

        protected void Init()
        {
            try
            {
                pictureBox1.Load(Application.StartupPath + "\\Resources\\" + "update1.png");
            }
            catch
            {
            }
            try
            {
                szHost = XmlConfig.readServerIP();
                szPort = XmlConfig.readComPort();
            }
            catch
            {
                AddMsg("没有找到配置文件,将从默认站点下载");
                szHost = "125.40.29.43";
            }
            m_pDbManager = new CDbManager_Sqlite(Application.StartupPath + "\\rainfall.sqlite", "");
            m_pDbTempManager = new CDbManager_Sqlite(Application.StartupPath + "\\temp.sqlite", "");
            CSQLite.G_CSQLite = new CSQLite(m_pDbManager, m_pDbTempManager);
            this.label1.Text =  DateTime.Now.ToString("yyyy年MM月dd日HH:mm:ss");
            this.timer1.Interval = 1000;
            this.timer1.Start();
            addListBoxMsgEvent += Form_Main_addListBoxMsgEvent;
            DialUpThread = new Thread(new ThreadStart(DialUp));
            DialUpThread.Start();
        }
       
        private void Form_Main_Load(object sender, EventArgs e)
        {
            Init();
        }
        void AddMsg(string msg)
        {
            msg += "***";
            msg = "+" + msg;
            this.BeginInvoke(addListBoxMsgEvent, msg);
        }
        void Form_Main_addListBoxMsgEvent(string msg)
        {
            this.msgBox.Items.Add(msg);
            this.msgBox.SelectedIndex = this.msgBox.Items.Count - 1;
            this.msgBox.SelectedIndex = -1;
        }
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
                CSQLite.G_CSQLite.WriteRunLogInfoDB("0xD3", "时间同步完成");
                AddMsg("请核对系统时间;如果时间错误请及时修改后,进入系统!!!");
            }
            catch
            {
                AddMsg("时间同步失败");
                CSQLite.G_CSQLite.WriteRunLogInfoDB("0xD4", "时间同步失败");
                AddMsg("请核对系统时间;如果时间错误请及时修改后,进入系统!!!");
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Text =  DateTime.Now.ToString("yyyy年MM月dd日HH:mm:ss");
        }
        private void Form_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            foreach (Process process in processes)
            {
                if (process.Id == current.Id)
                {
                    process.Kill();
                }
            }   
        }
        private void lbErrChkdsk_Click(object sender, EventArgs e)
        {
            string appName = "C:\\chk.bat";
            Process proc = Process.Start(appName);
            CSQLite.G_CSQLite.WriteRunLogInfoDB("0xDD", "单击磁盘修复");
        }

        private void lbIntoSys_Click(object sender, EventArgs e)
        {
            if (DialUpThread != null)
                if (DialUpThread.IsAlive)
                    return;
            if (TimeSyncThread != null)
                if (TimeSyncThread.IsAlive)
                    return;
            if (UpdateThread != null)
                if (UpdateThread.IsAlive)
                    return; 

            string appName = Application.StartupPath + "\\Rainfall.exe";
            Process proc = Process.Start(appName);
        }

        private void lbModifyDateTime_Click(object sender, EventArgs e)
        {
            Form_TimeDialog dlg = new Form_TimeDialog();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                DateTime dt = dlg.GetDateTime;
                SystemTime st = new SystemTime();
                st.FromDateTime(dt);
                SystemTime.SetLocalTime(ref st);
                CSQLite.G_CSQLite.WriteRunLogInfoDB("0xD5", "手动修改时间成功");
            }
            dlg.Close();
        }

        private void lbUpdate_Click(object sender, EventArgs e)
        {
            CSQLite.G_CSQLite.WriteRunLogInfoDB("0xD6", "单击手动更新");
            UpdateThread = new Thread(new ThreadStart(UpdateProcess));
            UpdateThread.Start();
        }
        /// <summary>
        /// 判定网络连接
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>

        public  bool isConnected()
        {
            for (int i = 0; i < 4; i++)
            {
                if (CmdPing(szHost) == "与目标通路")
                {
                    return true;
                }
            }
            return false;
        }
        public static string CmdPing(string strIp)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";           //设置程序名  
            p.StartInfo.UseShellExecute = false;        //关闭shell的使用  
            p.StartInfo.RedirectStandardInput = true;   //重定向标准输入  
            p.StartInfo.RedirectStandardOutput = true;  //重定向标准输出  
            p.StartInfo.RedirectStandardError = true;   //重定向错误输出  
            p.StartInfo.CreateNoWindow = true;          //不显示窗口  
            string pingrst;
            p.Start();
            p.StandardInput.WriteLine("ping -n 1 " + strIp);    //-n 1 : 向目标IP发送一次请求  
            p.StandardInput.WriteLine("exit");
            string strRst = p.StandardOutput.ReadToEnd();   //命令执行完后返回结果的所有信息  
            if (strRst.IndexOf("(0% loss)") != -1)
            {
                pingrst = "与目标通路";
            }
            else if (strRst.IndexOf("Destination host unreachable.") != -1)
            {
                pingrst = "无法到达目的主机";
            }
            else if (strRst.IndexOf("Request timed out.") != -1)
            {
                pingrst = "超时";
            }
            else if (strRst.IndexOf("not find") != -1)
            {
                pingrst = "无法解析主机";
            }
            else
            {
                pingrst = strRst;
            }
            p.Close();
            return pingrst;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void msgBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }   
    }
}