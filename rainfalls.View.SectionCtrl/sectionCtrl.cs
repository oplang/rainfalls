using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rainfalls.View.SiteCtrl;
using rainfalls.Abstract.Class;
using System.Collections;
using rainfalls.Base.Struct;
using rainfalls.View.frmReg;
using rainfalls.Abstract.Interface;
using rainfalls.View.frmLift;
using rainfalls.Base.Class;
namespace rainfalls.View.SectionCtrl
{
    public delegate void showFrmRegDlgHandler(LEVELINFO li);
    public delegate void showAutoLiftDlgHandler(_autoLiftLevelInfo li);
    public delegate void showFrmLiftDlgHandler();
    public partial class sectionCtrl : UserControl
    {
        protected frmRegDlg m_frmReg ;
        protected frmAutoWindow m_frmAutoWindow = new frmAutoWindow();
        protected frmLiftDlg m_frmLiftDlg;
        protected event showFrmRegDlgHandler showFrmRegDlgEvent;
        protected event showAutoLiftDlgHandler showAutoLiftDlgEvent;
        protected event showFrmLiftDlgHandler showFrmLiftDlgEvent;
        protected IRainfallsDBHelper m_rainfallsDBHelper;
        private string[] m_sLevel = new string[4] { "正常", "出巡", "限速", "扣车" };
        private List<siteCtrl> m_siteCtrlList = new List<siteCtrl>();
        private ASiteCtrlClickEvent m_siteCtrlClick;
        private ASectionSubject m_sectionSubject;
        private int m_nOffsetX;
        private int m_nOffsetY;
        private ALiftLevelManager m_liftLevelManager;
        private _RFLog[] m_rLog;
        _autoLiftLevelInfo m_liftLevelInfo;
        //ISoundPlay m_soundPlay;

        //public ISoundPlay SoundPlay
        //{
        //    get { return m_soundPlay; }
        //    set { m_soundPlay = value; }
        //}
        public ALiftLevelManager LiftLevelManager
        {
            get { return m_liftLevelManager; }
            set 
            {
                m_liftLevelManager = value;
              //  m_liftLevelManager.onNotifyLiftWindowEvent += new NotifyLiftWindowHandler(onNotifyLiftWindowEvent);
               // m_liftLevelManager.onShowLiftButtonEvent += new ShowLiftButton(m_liftLevelManager_onShowLiftButtonEvent);
                m_frmLiftDlg = new frmLiftDlg(m_liftLevelManager);
                m_frmLiftDlg.onAfterLiftEvent += new AfterLiftHandler(onAfterLift);
            }
        }

        //void m_liftLevelManager_onShowLiftButtonEvent(bool b)
        //{
        //    if (this.InvokeRequired)
        //    {
        //        Action<Control> setCtrlVisible = (X) =>
        //        {
        //            if (b)
        //            {
        //                if (X.Visible != b)
        //                {
        //                    m_soundPlay.AppendSoundAcc();
        //                    X.Visible = b;
        //                }
        //            }
        //            else
        //            {
        //                if (X.Visible != b)
        //                {
        //                    m_soundPlay.RemoveSoundAcc();
        //                    X.Visible = b;
        //                }
        //            }
        //        };
        //        Invoke(setCtrlVisible, lbLiftLevel);
        //    }
        //    else
        //    {
        //        if (b)
        //        {
        //            if (lbLiftLevel.Visible != b)
        //            {
        //                m_soundPlay.AppendSoundAcc();
        //                lbLiftLevel.Visible = b;
        //            }
        //        }
        //        else
        //        {
        //            if (lbLiftLevel.Visible != b)
        //            {
        //                m_soundPlay.RemoveSoundAcc();
        //                lbLiftLevel.Visible = b;
        //            }
        //        }

                
        //    }

           
        //}
        #region 解除窗体操作
        void onNotifyLiftWindowEvent(_autoLiftLevelInfo liftLevelInfo, _RFLog[] rlog)
        {
            m_liftLevelInfo = liftLevelInfo;
            m_rLog = rlog;

            try
            {
                this.BeginInvoke(showAutoLiftDlgEvent, liftLevelInfo);
            }
            catch
            {
            }
        }
        void showAutoLiftDlg(_autoLiftLevelInfo li)
        {
            //SetToolTip(li.level);
            System.Diagnostics.Debug.WriteLine(li.secName);
            if (m_frmAutoWindow.IsDisposed)
            {
                m_frmAutoWindow = new frmAutoWindow();
                m_frmAutoWindow.onInvokeWindowEvent += new InvokeLiftWindowHandler(InvokeLiftWindow);
                m_frmAutoWindow.onContinueToCheckEvent += new InvokeLiftWindowHandler(ContinueToCheck);
                //m_frmReg.btnClickEvent += new onBtnClickHandler(frmReg_btnClickEvent);
            }
            if (m_frmAutoWindow.DbHelper == null)
                m_frmAutoWindow.DbHelper = m_rainfallsDBHelper;
            if (!m_frmAutoWindow.Visible && !m_frmLiftDlg.Visible)
            {
                m_frmAutoWindow.setObject(li.secName);
                m_frmAutoWindow.setLocation(m_nOffsetX, m_nOffsetY);
                m_frmAutoWindow.SetLogInfo(li);
                m_frmAutoWindow.Show();

            }
        }

        void ContinueToCheck()
        {
            m_liftLevelManager.SetAutoResetEvent();
        }
        void showFrmLiftDlg()
        {
            if (m_frmLiftDlg.IsDisposed)
            {
                m_frmLiftDlg = new frmLiftDlg(m_liftLevelManager);
            }
            if (m_frmLiftDlg.DbHelper == null)
                m_frmLiftDlg.DbHelper = m_rainfallsDBHelper;
            m_frmLiftDlg.SetLogInfo(m_rLog, m_liftLevelInfo);
            try
            {
                m_frmLiftDlg.Show();
            }
            catch (Exception e)
            {
                string err = e.Message;
            }
        }
        void InvokeLiftWindow()
        {
            this.BeginInvoke(showFrmLiftDlgEvent);
        }
        void onAfterLift(int liftLevel,bool bIsLimitOpen)
        {
            //m_liftLevelManager.EndAutoThread();
            //m_liftLevelManager.Notity(1, false);
            m_sectionSubject.setCurLevel(1);
            m_sectionSubject.saveLevel(1);
            if (bIsLimitOpen)
            {
                m_liftLevelManager.AfterLiftAlarm();
            }
        }
        #endregion
        public sectionCtrl()
        {
           // showFrmRegDlgEvent += new showFrmRegDlgHandler(showFrmRegDlg);
            showAutoLiftDlgEvent+=new showAutoLiftDlgHandler(showAutoLiftDlg);

            showFrmLiftDlgEvent+=new showFrmLiftDlgHandler(showFrmLiftDlg);

            m_frmAutoWindow.onInvokeWindowEvent += new InvokeLiftWindowHandler(InvokeLiftWindow);
            m_frmAutoWindow.onContinueToCheckEvent += new InvokeLiftWindowHandler(ContinueToCheck);
            InitializeComponent();
        }

       

        //public int offsetX
        //{
        //    set { m_nOffsetX = value; }
        //}
        //public int offsetY
        //{
        //    set { m_nOffsetY = value; }
        //} 
        //public ASiteCtrlClickEvent siteCtrlClickEventObj
        //{
        //    set
        //    {
        //        m_siteCtrlClick = value;
        //    }
        //}

        //#region 报警窗体操作
        //void onSectionAlarm(LEVELINFO li)
        //{
        //    this.BeginInvoke(showFrmRegDlgEvent,li);
        //}
        //void showFrmRegDlg(LEVELINFO li)
        //{
        //    if (m_frmReg.IsDisposed)
        //    {
        //        m_frmReg = new frmRegDlg(m_sectionSubject);
        //       // m_frmReg.btnClickEvent += new onBtnClickHandler(frmReg_btnClickEvent);
        //    }
        //    if (m_frmReg.rainfallsDbHelper == null)
        //        m_frmReg.rainfallsDbHelper = m_rainfallsDBHelper;
        //    if (m_frmReg.SoundPlay == null)
        //        m_frmReg.SoundPlay = m_soundPlay;
        //    m_frmReg.setLocation(m_nOffsetX,m_nOffsetY);
        //    m_frmReg.SetLogInfo(li);
        //    m_frmReg.Show();
        //}
        //#endregion
        public IRainfallsDBHelper rainfallsDbHelper
        {
            set { m_rainfallsDBHelper = value; }
        }
        private void sectionCtrl_Load(object sender, EventArgs e)
        {
            //this.Controls.Add(new MyMessageBox("提示文本", new Point(50, 20), this));
            Timer t = new Timer();
            t.Tick += new EventHandler(t_Tick);
            t.Start();

            //Timer t1 = new Timer();
            //t1.Tick += new EventHandler(GifShow);
            //t1.Interval = 1 * 800;
            //t1.Start();
        }

        //void GifShow(object sender, EventArgs e)
        //{
        //    if (lbLiftLevel.BackColor == Color.ForestGreen)
        //    {
        //        lbLiftLevel.BackColor = Color.White;
        //        lbLiftLevel.ForeColor = Color.Black;
        //    }
        //    else
        //    {
        //        lbLiftLevel.BackColor = Color.ForestGreen;
        //        lbLiftLevel.ForeColor = Color.White;
        //    }
        //}

        void t_Tick(object sender, EventArgs e)
        {
            
            //if (m_sectionSubject != null)
            //{
                 
            //    //lbSectionName.Text = string.Format("区间:{0}", );
            //    lbLevel.Text = string.Format("区间:{0}    警戒:{1}",m_sectionSubject.SiteSection, m_sLevel[m_sectionSubject.getCurLevel()]);
            //    if (m_liftLevelManager.isRainProcessStop())
            //    {
            //        m_sectionSubject.ClearCurLevel();
            //        m_liftLevelManager.ClearLevel();
            //    }
            //    if (m_sectionSubject.getCurLevel() > 0)
            //        lbLevel.ForeColor = Color.Red;
            //    else
            //        lbLevel.ForeColor = Color.Black;
          
            //}

        }
        public void SetToolTip(int level)
        {
            //toolTip1.SetToolTip(btnTest, "当前雨量已达到XXx解除标准，\r\n如果检查结束请单击解除");//ttMsg为ToolTip控件,txtLoginName为文本框
            //toolTip1.Show("当前雨量已达到XXx解除标准，\r\n如果检查结束请单击解除", btnTest);
        }
        public void drawSiteCtrl(Dictionary<string, ASiteSubject> siteDictionary)
        {
            int h = 0;
            int w = 0;
            IDictionaryEnumerator en = siteDictionary.GetEnumerator();
            while (en.MoveNext())
            {
                ASiteSubject site = (ASiteSubject)en.Value;
                if (string.Compare(m_sectionSubject.SiteSection, site.Section) == 0)
                {
                    site.onSiteAlarmEvent += new siteAlarmHandler(m_sectionSubject.alarming);
                    siteCtrl s = new siteCtrl();
                    s.siteCtrlClickEventObj = m_siteCtrlClick;
                    h = s.Height;
                    w = s.Width;
                    s.bindSiteRenderObject(site);
                    m_siteCtrlList.Add(s);
                }
                if (site.IsCommSite)
                    site.onSiteAlarmEvent += new siteAlarmHandler(m_sectionSubject.alarming);
            }
            int n = m_siteCtrlList.Count;
            if (n > 0)
            {
                int x = (this.Width) / (n + 1);
                Point p = new Point();
                p.Y = plSection.Location.Y - h;
                for (int i = 0, j = 1; i <= m_siteCtrlList.Count - 1; i++, j++)
                {
                    p.X = x * j - w / 2;

                    m_siteCtrlList[i].Location = p;
                    addCtrl(m_siteCtrlList[i], DockStyle.None);
                }
            }
            
        }
        private void addCtrl(UserControl ctrl, DockStyle ds)
        {
            //if (this.InvokeRequired)
            //{
            //    Action<UserControl> actionAddrCtrl = (X) =>
            //    {
            //        Controls.Add(X);
            //        X.BringToFront();
            //    };
            //    Invoke(actionAddrCtrl, ctrl);
            //}
            //else
            //{
            //    Controls.Add(ctrl);
            //    ctrl.BringToFront();
            //}
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
           
        }

        private void lbLiftLevel_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("解除警戒前,请确认线路检查是否结束!!!", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            m_liftLevelManager.InvokeAutoWindow();
        }

        
    }
}
