using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;
using rainfalls.path;
using rainfalls.Abstract.Interface;
using rainfalls.Abstract.Class;
using rainfalls.Business.DbHelper;
using rainfalls.Base.Mtup;
using rainfalls.Base.SQLite;
using rainfalls.Business.SoundPlay;
using rainfalls.Model.XmlHelper;
using rainfalls.Business.CObserver;
using rainfalls.Base.Struct;
using rainfalls.Business.Site;
using rainfalls.DataSource.Comm;
using rainfalls.DataSource.Remote;
using Zyf.Ini;
using System.Diagnostics;
using rainfalls.Business.RainCalc;
using rainfalls.Business.InspectorLab;
using rainfalls.Base.Class;
using rainfalls.Views.DockFormToolBar;
using rainfalls.Views.SectionDockForm;
using rainfalls.Views.SiteDockForm;
using rainfalls.Views.DockFormRainMap;
using rainfalls.Views.DockFormInspector;
using rainfalls.Repair;
namespace rainfalls2018
{
    public partial class frmMain : Form
    {
        private frmToolBar m_pFrmToolbar;
        private frmSection m_pFrmSection;
        private frmSite m_pFrmSite;
        private frmRainMap m_pFrmRainMap;
        private frmInspector m_pFrmInspector;
        private DeserializeDockContent m_pDDC;
        private rainfallsDBHelper m_pDbHelper;
        private IDataUpload m_pUpLoad;
        private Observer m_pSiteObserver = new CObserver();
        private List<ASectionObj> m_pSectionObjList = new List<ASectionObj>();
        private List<ASiteObj> m_pSiteObjList = new List<ASiteObj>();
        private IRainCalc m_pSiteRainCalc = new siteRainCalc();

        bool m_bIsLoaded = false;
        public frmMain()
        {
            ObjectInitialze();
            InitializationRainfalls();
            m_pDDC = new DeserializeDockContent(GetContentFromPersistString);
            InitializeComponent();
        }

        private IDockContent GetContentFromPersistString(string persistString)
        {
            try
            {
                if (persistString == typeof(frmSection).ToString())
                {

                    m_pFrmSection = frmSection.getInstance();
                    m_pFrmSection.Show(m_pDockPanel, DockState.Document);

                    return m_pFrmSection;
                }
                else if (persistString == typeof(frmSite).ToString())
                {
                    m_pFrmSite = frmSite.getInstance();
                    m_pFrmSite.InitializeSiteList((m_pSiteObjList));
                    m_pFrmSite.Show(m_pDockPanel, DockState.Document);
                    return m_pFrmSite;
                }
                else if (persistString == typeof(frmInspector).ToString())
                {
                    m_pFrmInspector = frmInspector.getInstance();
                    m_pFrmInspector.Show(m_pDockPanel, DockState.Document);
                    return m_pFrmInspector;
                }
                else if (persistString == typeof(frmRainMap).ToString())
                {
                    m_pFrmRainMap = frmRainMap.getInstance();
                    m_pFrmRainMap.DrawRainMap(m_pSiteRainCalc, m_pDbHelper);
                    m_pFrmRainMap.Show(m_pDockPanel, DockState.Document);
                    m_pFrmRainMap.SizeChanged += new EventHandler(m_pFrmRainMap_SizeChanged);
                    return m_pFrmRainMap;
                }
                //else if (persistString == typeof(frmToolBar).ToString())
                //{
                //    //m_pFrmToolbar = frmToolBar.getInstance();
                //    //m_pFrmToolbar.Show(m_pDockPanel, DockState.Document);
                //    //return m_pFrmToolbar;
                //}
                else
                {
                    //NewLayout();
                    return null;


                }
            }
            catch (Exception e)
            {
                MessageBox.Show("没有找到可用的布局文件,窗体将自动排列", "警告");
                return null;
            }
           
        }

        void m_pFrmRainMap_SizeChanged(object sender, EventArgs e)
        {
            if (m_bIsLoaded)
            {
                m_pDockPanel.SaveAsXml(paths.LayoutPath);
            }
        }
        private void NewLayout()
        {
            
            m_pFrmSection = frmSection.getInstance();
            m_pFrmSection.Show(m_pDockPanel, DockState.Document);
            m_pFrmSection.InitializeSectionList(m_pDbHelper, CAlarmSound.getInstance(), m_pSectionObjList);

            m_pFrmSite = frmSite.getInstance();
            m_pFrmSite.InitializeSiteList((m_pSiteObjList));
            m_pFrmSite.Show(m_pDockPanel, DockState.Document);

            m_pFrmRainMap = frmRainMap.getInstance();
            m_pFrmRainMap.DrawRainMap(m_pSiteRainCalc, m_pDbHelper);
            m_pFrmRainMap.Show(m_pDockPanel, DockState.Document);

            m_pFrmInspector = frmInspector.getInstance();
            m_pFrmInspector.Show(m_pDockPanel, DockState.Document);

            //m_pFrmToolbar = frmToolBar.getInstance();
            //m_pFrmToolbar.Show(m_pDockPanel, DockState.Document);


        }
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
                foreach (ASectionObj obj in seclist)
                {
                    obj.DBHelper = m_pDbHelper;
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
            foreach (ASectionObj obj in m_pSectionObjList)
            {
                obj.InitializeComponent();
            }
            foreach (ASiteObj obj in m_pSiteObjList)
            {
                obj.StartRTUdaemon();
            }
           // aliyun_daemon.getInstance().start();
            m_pSiteRainCalc.setSectionObjList(m_pSectionObjList);
        }
        private void InitializationSiteList()
        {
            #region 添加本地Comm采集对象
            siteInfo comm_site = CRainfallXmlHelper.getInstance().GetCommSiteInfo();
            if (!string.IsNullOrEmpty(comm_site.id))
            {
                ASiteObj obj = InitializationComSite(comm_site);
                obj.DbHelper = m_pDbHelper;
                obj.InitializeComponent();
                m_pSiteObjList.Add(obj);
                obj.SiteName = string.Format("{0}", obj.SiteKM);
                obj.SiteObserver = m_pSiteObserver;
                AddSiteObjToSectinObj(obj);
                m_pDefaultSiteName = obj.SiteName;
            }
            #endregion
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
                asj.SiteName = string.Format("{0}",  si.km);
                asj.SiteObserver = m_pSiteObserver;
                asj.RTUdaemon = new rtu_daemon();
               // aliyun_daemon.getInstance().AddRTUObj(asj);
                bool bIsExist = false;
                foreach (ASiteObj ObjExist in m_pSiteObjList)
                {
                    if(ObjExist.SiteID.Equals(asj.SiteID))
                    {
                        bIsExist = true;
                        AddSiteObjTosectionObj(ObjExist, asj.SectionID);
                        break;
                    }
                }
                if (!bIsExist)
                {
                    m_pSiteObjList.Add(asj);
                    AddSiteObjToSectinObj(asj);
                }
            }

        }
        private void AddSiteObjTosectionObj(ASiteObj obj, string section_id)
        {
            foreach (ASectionObj sec in m_pSectionObjList)
            {
                if (obj.Type.Equals("ssl"))
                {
                    if (sec.ID.Equals(section_id))
                    {
                        sec.AddSiteObject(obj);
                        obj.SectionsName += string.Format("[{0}]", sec.SectionName);
                    }
                }
            }
        }
        private void AddSiteObjToSectinObj(ASiteObj obj)
        {
            foreach (ASectionObj sec in m_pSectionObjList)
            {
                if (obj.Type.Equals("comm"))
                {
                    if (CRepair.getInstance().IsInMainSite(sec.ID))
                    {
                        sec.AddSiteObject(obj);
                        obj.SectionsName += string.Format("[{0}]", sec.SectionName);
                    }
                }
                else
                {
                    if (sec.ID.Equals(obj.SectionID))
                    {
                        sec.AddSiteObject(obj);
                        obj.SectionsName += string.Format("[{0}]", sec.SectionName);
                    }
                }
            }
        }
        private string m_pDefaultSiteName;
        private ASiteObj InitializationComSite(siteInfo site)
        {
            ASiteObj asj = new CSiteObj();
            asj.SiteID = site.id;
            asj.SiteKM = site.km;
            asj.SectionID = site.section_id;
            asj.Type = "comm";
           
           // aliyun_daemon.getInstance().QueueName = asj.SiteID;
            //m_pDefaultKM = asj.SiteKM;

            string comX = CINIFile.IniReadValue("基本信息", "串口编号", paths.baseInfoPath);
            if (string.IsNullOrEmpty(comX))
            {
                MessageBox.Show("没有找到串口配置信息,如有问题请联系我们!!!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                comm_daemon.getInstance().Initialize(comX, this.Handle.ToInt32());
                comm_daemon.getInstance().receviedNewClickEvent += new rainfalls.DataSource.Comm.OnReceviedNewClickEvent(asj.ReceviedData);
            }
            return asj;
        }
        private void ObjectInitialze()
        {
            m_pUpLoad = CDataUpload.getInstance();
            m_pUpLoad.SetCommSiteID(CINIFile.IniReadValue("基本信息", "MTUP标识", paths.baseInfoPath));
            m_pDbHelper = rainfallsDBHelper.getInstance(new SQLiteDbHelper(), m_pUpLoad);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            IniHelper.IniWriteValue("System", paths.MainHandle, this.Handle.ToInt32().ToString(), paths.HandlePath);
            /* xp系统
           
            */

            //string pVerson = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            //MessageBox.Show(pVerson);
            InspectorsLab.getInstance().DbHelper = m_pDbHelper;
            InspectorsLab.getInstance().ReadInSpectorRecords();
            m_pRainfallsToolbar.DbHelper = m_pDbHelper;
            m_pRainfallsToolbar.SiteRainCalc = m_pSiteRainCalc;
            this.m_pDockPanel.DocumentStyle = DocumentStyle.DockingMdi;
            if (System.IO.File.Exists(paths.LayoutPath))
            {
                this.m_pDockPanel.LoadFromXml(paths.LayoutPath, m_pDDC);
            }
            else
            {
                NewLayout();
            }
            FormUnicomm();
            string v = CINIFile.IniReadValue("基本信息", "软件版本", paths.baseInfoPath);
            m_pDbHelper.WriteRunLogInfoDB("start" + v, "软件启动");
            CSoftInfo.getInstance().SetDefaultSiteName(m_pDefaultSiteName);
            m_bIsLoaded = true;
        }
        private void FormUnicomm()
        {
           
            m_pFrmSection.InitializeSectionList(m_pDbHelper, CAlarmSound.getInstance(), m_pSectionObjList);

            m_pFrmRainMap.ToolBarControl = m_pRainfallsToolbar;
            m_pFrmRainMap.SiteObjList = m_pSiteObjList;
            m_pFrmRainMap.SiteControl = m_pFrmSite.SiteControl;

            m_pSiteObserver.RainMapObj = m_pFrmRainMap.RainMapObj;
            m_pFrmSite.RainMapObj = m_pFrmRainMap.RainMapObj;
            m_pFrmSite.RainMapCaptionObj = m_pFrmRainMap.RainMapCaptionObj;
            m_pFrmRainMap.Unicom();
        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
               
                foreach (ASiteObj obj in m_pSiteObjList)
                {
                    obj.StopRTUdaemon();
                }
                m_pSiteObserver.EndTimer();
                CAlarmSound.getInstance().Dispose();

                m_pDbHelper.Dispose();

                string v = CINIFile.IniReadValue("基本信息", "软件版本", paths.baseInfoPath);
                m_pDbHelper.WriteRunLogInfoDB("exit" + v, "软件退出");
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception err)
            {
                throw new Exception(string.Format("{0}:{1}:{2}:{3}", err.Message, err.Source, err.InnerException, err.Data));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string comm = comm_daemon.getInstance().CheckPortState() ? "已打开" : "已关闭";
            string tm = string.Format("系统时间：{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            txtNetWorkState.Text = string.Format("当前网络状态：{0}  |  软件版本：{1}  |  {2} | 雨量采集端口[{3}]：{4}",
                CDataUpload.getInstance().NetWorkState, CSoftInfo.getInstance().Verson, tm, comm_daemon.getInstance().COMX, comm);
        }

    }
}
