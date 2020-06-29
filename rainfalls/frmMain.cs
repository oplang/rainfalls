using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using rainfalls.Abstract.Class;
using rainfalls.Abstract.Interface;
using rainfalls.Base.Mtup;
using rainfalls.Base.SQLite;
using rainfalls.Base.Struct;

using rainfalls.Business.DbHelper;
using rainfalls.Business.RainCalc;
using rainfalls.Business.Site;
using rainfalls.Business.SoundPlay;
using rainfalls.DataSource.Comm;
using rainfalls.Model.XmlHelper;
using rainfalls.path;
using rainfalls.View.RainMapCaption;
using rainfalls.View.RainMapCtrl;
using rainfalls.View.Toolbar;
using Zyf.Ini;
using rainfalls.View.SectionControl;
using rainfalls.View.SiteControl;
using rainfalls.Base.Class;
using Zyf.NetWork;
using rainfalls.Base.ErrorHandle;
using rainfalls.View.Messagebox;
using rainfalls.View.TrackOpenNofityControl;
using rainfalls.Business.CObserver;
using rainfalls.View.frmConfig;
using rainfalls.DataSource.Remote;
namespace rainfalls
{
    public partial class frmMain : Form
    {
     
        private rainfallsDBHelper m_pDbHelper;
        private IRainCalc m_pSiteRainCalc = new siteRainCalc();
        private rainfallsToolBar m_pRainfallsToolbar;
        private captionCtrl m_pRainfallsCaption;
        private RainMapCtr m_pRainfallsMap;
        private SectionControl m_pSectionControl;
        private UITrackOpenNofityControl m_pNotifyControl;
        private SiteControl m_pSiteControl;
        private static AutoResetEvent mEvent = new AutoResetEvent(false);
        private static AutoResetEvent mRainMapEvent = new AutoResetEvent(false);
        private Thread m_pInitCtrlThread;
        private Thread m_pInitRainMapEventThread;
        private List<string> m_pSecs = new List<string>();
       
       
        private string m_pDefaultKM;
        BindingSource m_pSectionSource = new BindingSource();
        BindingSource m_pSiteSource = new BindingSource();
        private IDataUpload m_pUpLoad;


        /*重构*/
        private Observer m_pSiteObserver = new CObserver();
        private List<ASiteObj> m_pSiteObjList = new List<ASiteObj>();
        private List<ASectionObj> m_pSectionObjList = new List<ASectionObj>();
        public frmMain()
        {
          
            InitializeComponent();
        }
        void InitializeCtrl()
        {
            #region 工具栏
            m_pRainfallsToolbar = new rainfallsToolBar();
            m_pRainfallsToolbar.DbHelper = m_pDbHelper;
            m_pRainfallsToolbar.SiteRainCalc = m_pSiteRainCalc;
            addCtrl(m_pRainfallsToolbar, DockStyle.Top);

            #endregion
         
            #region 线路+站点
            m_pSectionControl = new SectionControl();
            m_pSectionControl.RainfallsDbHelper = m_pDbHelper;
            m_pSectionControl.SoundPlay = CAlarmSound.getInstance();
            m_pSectionSource.DataSource = m_pSectionObjList;
            m_pSectionControl.BindingData(m_pSectionSource);
            m_pSectionControl.SectionObjList = m_pSectionObjList;
            addCtrl(m_pSectionControl, DockStyle.Top);
            m_pSectionControl.ControlHeight();
            #endregion
          
            #region 雨量标题
            m_pRainfallsCaption = new captionCtrl();
            addCtrl(m_pRainfallsCaption,DockStyle.Top);
            m_pRainfallsCaption.setCaptionKm(CRainfallXmlHelper.getInstance().siteName + m_pDefaultKM);
            #endregion
          
            #region 监测点列表
           // m_pRainfallStatueBar = new statueBarCtrl();
            m_pSiteControl = new SiteControl();
            m_pSiteSource.DataSource = m_pSiteObjList;
            m_pSiteControl.BindingData(m_pSiteSource);
            addCtrl(m_pSiteControl, DockStyle.Bottom);
            m_pSiteControl.ControlHeight();
            #endregion
            #region 通知栏
            m_pNotifyControl = new UITrackOpenNofityControl();
            addCtrl(m_pNotifyControl, DockStyle.Bottom);

            #endregion
            mEvent.Set();
        }
        private void addCtrl(UserControl ctrl,DockStyle ds)
        {
            if (this.InvokeRequired)
            {
                Action<UserControl> actionAddrCtrl = (X) =>
                {
                    Controls.Add(X);
                    X.Dock = ds;
                    X.BringToFront();
                };
                Invoke(actionAddrCtrl, ctrl);
            }
        }
        private void addCtrl(Form ctrl)
        {
            if (this.InvokeRequired)
            {
                Action<Form> actionAddrCtrl = (X) =>
                {
                    X.Show();
                };
                Invoke(actionAddrCtrl, ctrl);
            }
        }
        void UnicomInterface()
        {
            mEvent.WaitOne();
            #region 雨量图
            m_pRainfallsMap = new RainMapCtr(m_pSiteRainCalc);
            m_pRainfallsMap.ToolBarControl = m_pRainfallsToolbar;
            m_pRainfallsMap.SiteObjList = m_pSiteObjList;
            m_pRainfallsMap.SiteControl = (ISiteControl)m_pSiteControl;
            addCtrl(m_pRainfallsMap, DockStyle.Fill);
            m_pSiteObserver.RainMapObj = m_pRainfallsMap;
            m_pSiteControl.RainMapObj = m_pRainfallsMap;
            m_pSiteControl.RainMapCaptionObj = m_pRainfallsCaption;
            m_pRainfallsCaption.RainMapObj = m_pRainfallsMap;
            m_pRainfallsCaption.DrawRainMapCaption();
            #endregion
            string v = CINIFile.IniReadValue("基本信息", "软件版本", paths.baseInfoPath);
            m_pDbHelper.WriteRunLogInfoDB("start" + v, "软件启动");
        }
        #region 重构代码
        private void InitializationRainfalls()
        {
            List<ASectionObj> seclist = CRainfallXmlHelper.getInstance().GetSection();
            if (seclist.Count <= 0)
            {
                MessageBox.Show("初始化区间配置信息错误,如有问题请联系我们!!!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                foreach (ASectionObj obj in seclist){
                    m_pSectionObjList.Add(obj);
                }

                m_pSiteObserver.SectionObjList = m_pSectionObjList;
            }
            try
            {
                InitializationSiteList();
            }
            catch { MessageBox.Show("初始化采集点配置信息错误,如有问题请联系我们!!!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            m_pSiteObserver.SiteObjLists = m_pSiteObjList;
            m_pSiteObserver.StartTimer();
            foreach (ASectionObj obj in m_pSectionObjList) {
                obj.InitializeComponent();
            }
            foreach (ASiteObj obj in m_pSiteObjList)
            {
                obj.StartRTUdaemon();
            }
        }
        private void InitializationSiteList()
        {
            siteInfo comm_site = CRainfallXmlHelper.getInstance().GetCommSiteInfo();
            ASiteObj obj = InitializationComSite(comm_site);
            obj.DbHelper = m_pDbHelper;
            obj.InitializeComponent();
            m_pSiteObjList.Add(obj);
            obj.SiteName = CRainfallXmlHelper.getInstance().siteName + "(" + obj.SiteKM + ")";
            obj.SiteObserver = m_pSiteObserver;
            AddSiteObjToSectinObj(obj);
            List<siteInfo> psslist = CRainfallXmlHelper.getInstance().GetRTUSiteInfo();
            foreach (siteInfo si in psslist)
            {
                ASiteObj asj = new CSiteObj();
                asj.SiteID = si.id;
                asj.SiteKM = si.km;
                asj.SectionID = si.section_id;
                asj.Type = "ssl";
                asj.DbHelper = m_pDbHelper;
                asj.InitializeComponent();
                asj.SiteName = CRainfallXmlHelper.getInstance().siteName + "(" + si.km + ")";
                asj.SiteObserver = m_pSiteObserver;
                asj.RTUdaemon = new rtu_daemon();
                m_pSiteObjList.Add(asj);
                AddSiteObjToSectinObj(asj);
            }
                
        }
        private void AddSiteObjToSectinObj(ASiteObj obj)
        {
            foreach (ASectionObj sec in m_pSectionObjList)
            {
                if (obj.Type.Equals("comm"))
                {
                    sec.AddSiteObject(obj);
                    obj.SectionsName += "["+sec.SectionName+"]";
                }
                else
                {
                    if (sec.ID.Equals(obj.SectionID))
                    {
                        sec.AddSiteObject(obj);
                        obj.SectionsName += "[" + sec.SectionName + "]";
                    }
                }
            }
        }
        private ASiteObj InitializationComSite(siteInfo site)
        {
            ASiteObj asj = new CSiteObj();
            asj.SiteID = site.id;
            asj.SiteKM = site.km;
            asj.SectionID = site.section_id;
            asj.Type = "comm";
            m_pDefaultKM = asj.SiteKM;
            comm_daemon.getInstance().receviedNewClickEvent += new DataSource.Comm.OnReceviedNewClickEvent(asj.ReceviedData);
            string comX = CINIFile.IniReadValue("基本信息", "串口编号", paths.baseInfoPath);
            if (string.IsNullOrEmpty(comX))
                MessageBox.Show("没有找到串口配置信息,如有问题请联系我们!!!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            comm_daemon.getInstance().Initialize(comX);
            return asj;
        }
        #endregion
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case CMessage.WM_ONADD_PERSON:
                    MessageBox.Show("没有找到当前值班负责人信息,点击确定手动修改!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    SetCurPerson();
                    break;
            }
            base.WndProc(ref m);
        }
        void SetCurPerson()
        {
            frmUserInfo dlg = new frmUserInfo();
            dlg.ShowDialog();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
           m_pUpLoad = CDataUpload.getInstance();
           IniHelper.IniWriteValue("System", paths.MainHandle, this.Handle.ToInt32().ToString(), paths.HandlePath);
            
            string ip = CINIFile.IniReadValue("基本信息", "MTUP_IP", paths.baseInfoPath);
            //SQLite操作对象
            m_pDbHelper = rainfallsDBHelper.getInstance(new SQLiteDbHelper(), m_pUpLoad);
            //报警算法
            m_pDbHelper.InitQueueR();
            InitializationRainfalls();

            m_pInitCtrlThread = new Thread(new ThreadStart(InitializeCtrl));
            m_pInitCtrlThread.Start();
            //InitSiteCtrlThread = new Thread(new ThreadStart(initializeSiteObj));
            //InitSiteCtrlThread.Start();
            m_pInitRainMapEventThread = new Thread(new ThreadStart(UnicomInterface));
            m_pInitRainMapEventThread.Start();

            NetWorkCls.onNotify += new Notity(NetWorkCls_onNotify);
         //   System.Threading.Timer timer = new System.Threading.Timer(new TimerCallback(timer_Elapsed), null, 0, 1000);
          Thread  NetWorkThread = new Thread(new ThreadStart(timer_Elapsed));
            NetWorkThread.Start();
            Sysinfo();
        }
        void Sysinfo()
        {
            txtSysInfo.Text = "系统版本:" + CINIFile.IniReadValue("基本信息", "软件版本", paths.baseInfoPath);
             txtDeviceID.Text = "更新时间:" + CINIFile.IniReadValue("基本信息", "更新时间", paths.baseInfoPath);
            //txtDeviceID.Text = "更新标识:" + CINIFile.IniReadValue("基本信息", "更新标识", paths.baseInfoPath);
            //txtMtup.Text = "MTUP:" + CINIFile.IniReadValue("基本信息", "MTUP标识", paths.baseInfoPath);
        }
        void timer_Elapsed()
        {
            for (; ; )
            {
                try
                {
                    m_pSectionControl.QJGridViewRefreshRow();
                    NetWorkCls.CheckServeStatus();
                }
                catch
                {
                }
                Thread.Sleep(5000);
            }
        }
        void NetWorkCls_onNotify(string msg)
        {
            txtNetWorkState.Text = msg;
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (ASiteObj obj in m_pSiteObjList)
            {
                obj.StopRTUdaemon();
            }
            m_pSiteObserver.EndTimer();
            CAlarmSound.getInstance().Dispose();
            if (m_pInitCtrlThread != null)
                if (m_pInitCtrlThread.IsAlive)
                    m_pInitCtrlThread.Abort();
           
            if (m_pInitRainMapEventThread != null)
                if (m_pInitRainMapEventThread.IsAlive)
                    m_pInitRainMapEventThread.Abort();
            m_pDbHelper.Dispose();
            string v = CINIFile.IniReadValue("基本信息", "软件版本", paths.baseInfoPath);
            m_pDbHelper.WriteRunLogInfoDB("exit" + v, "软件退出");
            Process.GetCurrentProcess().Kill();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtSystime.Text = string.Format("系统时间:{0}", DateTime.Now.ToString());
          
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            PostRefreshSiteGridViewMessage();
        }
        private void PostRefreshSiteGridViewMessage()
        {
            //string szHandle = IniHelper.IniReadValue("System", paths.SiteControlHandle, paths.HandlePath);
            //if (szHandle.Length > 0)
            //{
            //    int nHandle = int.Parse(szHandle);
            //    IntPtr pHandle = new IntPtr(nHandle);
            //    CWinMsgAPI.PostMessage(pHandle, CMessage.WM_ONREFRESH_SITEGRIDVIEW, 0, 0);
            //}
        }
    }
}
