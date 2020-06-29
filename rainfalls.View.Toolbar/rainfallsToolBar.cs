using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using rainfalls.Base.Struct;
using rainfalls.Abstract.Class;
using rainfalls.Abstract.Interface;
using System.Collections;
using rainfalls.DataSource.Comm;
using System.Diagnostics;
using rainfalls.View.frmConfig;
using rainfalls.View.MeasureLog;
using rainfalls.View.ShutDown;
using Zyf.Ini;
using rainfalls.path;
namespace rainfalls.View.Toolbar
{
    public partial class rainfallsToolBar : UserControl, IToolBar
    {

        private IRainCalc m_siteRainCalc;
        private IRainfallsDBHelper m_dbHelper;

        public IRainfallsDBHelper DbHelper
        {
            get { return m_dbHelper; }
            set { m_dbHelper = value; ; }
        }
        public IRainCalc SiteRainCalc
        {
            get { return m_siteRainCalc; }
            set { m_siteRainCalc = value; }
        }
        public rainfallsToolBar()
        {
            InitializeComponent();
        }

        private void rainfallsToolBar_SizeChanged(object sender, EventArgs e)
        {
            int w = this.Size.Width / 5;
            lbPerson.Width = lbOpen.Width = lbConfig.Width = lbTest.Width = lbShutDown.Width = w;
            Point p = new Point();
            p.X = 0;
            p.Y = 0;
            lbPerson.Location = p;
            lbPerson.Visible = true;
            p.X += w;
            lbOpen.Location = p;
            lbOpen.Visible = true;
            p.X += w;
            lbConfig.Location = p;
            lbConfig.Visible = true;
            p.X += w;
            lbTest.Location = p;
            lbTest.Visible = true;
            p.X += w;
            lbShutDown.Location = p;
            lbShutDown.Visible = true;
        }

        private void rainfallsToolBar_Load(object sender, EventArgs e)
        {
            string pCruPerson = CINIFile.IniReadValue("基本信息", "当前值班负责人", paths.baseInfoPath);
            lbPerson.Text = string.Format("值班负责人:{0}", string.IsNullOrEmpty(pCruPerson) ? "" : pCruPerson);
        }

        private void lbOpen_Click(object sender, EventArgs e)
        {
            frmMeasuerLog frm = frmMeasuerLog.InstanceObject();
            frm.Show();
            frm.DbHelper = m_dbHelper;
            frm.Init();
            frm.Focus();
        }

        private void lbConfig_Click(object sender, EventArgs e)
        {
            frmUserInfo.getInstance().OnChangePerson += new UpdatePerson(rainfallsToolBar_OnChangePerson);
            frmUserInfo.getInstance().Show();

        }

        void rainfallsToolBar_OnChangePerson(string name)
        {
            lbPerson.Text = string.Format("值班负责人:{0}", name);
        }

        private void lbTest_Click(object sender, EventArgs e)
        {
            //string comX = CINIFile.IniReadValue("基本信息", "串口编号", paths.baseInfoPath);
            //try
            //{
            //    // 启动外部程序
            //    comm_daemon.getInstance().Close();
            //    string appName = Application.StartupPath + "\\TESTRainFall.exe";
            //    Process proc = Process.Start(appName);
            //    if (proc != null)
            //    {
            //        // 监视进程退出
            //        proc.EnableRaisingEvents = true;
            //        // 指定退出事件方法
            //        proc.Exited += new EventHandler(proc_TestExited);
            //       // CSQLite.G_CSQLite.WriteRunLogInfoDB("0x04", "进入测试模式");
            //    }

            //}
            //catch (ArgumentException ex)
            //{

            //   // setRunLogStatusBarText("无法启动测试程序:" + ex.Message);
            //    comm_daemon.getInstance().Initialize(comX);
            //}
            m_dbHelper.WriteRunLogInfoDB("test", "进入软件测试");

   
            string appName = Application.StartupPath + "\\TESTRainFall.exe";
            Process proc = Process.Start(appName);
       
        }
        private void proc_TestExited(object sender, EventArgs e)
        {
        
        }

        private void lbLog_Click(object sender, EventArgs e)
        {
            //frmRainLog.rainLogDlg rainLogDlg =  frmRainLog.rainLogDlg.InstanceObject();
            //rainLogDlg.TopMost = true;
            //rainLogDlg.SiteRainCalc = m_siteRainCalc;
            //rainLogDlg.DbHelper = m_dbHelper;
            //rainLogDlg.SetDefault(m_pSiteObj);
            //rainLogDlg.Show();
            //rainLogDlg.Focus();
        }

        private void lbShutDown_Click(object sender, EventArgs e)
        {
            frmShutDown frm = frmShutDown.InstanceObject();
            frm.Show();
            frm.Focus();
        }

        public void SetActivitySite(ASiteObj obj)
        {
        }
    }
}
