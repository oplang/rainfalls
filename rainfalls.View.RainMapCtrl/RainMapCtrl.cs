using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Collections;
using System.Data;
using System.Text;
using System.Windows.Forms;
using rainfalls.Business.RainMap;
using rainfalls.Base.Class;
using rainfalls.Abstract.Interface;
using rainfalls.Abstract.Class;
namespace rainfalls.View.RainMapCtrl
{
    /*
     * 2018年5月7日，将鼠标移动显示10分钟最大雨量修改为鼠标单击显示10分钟最大雨量
     */
    public enum ENU_MODE
    {
        REALTIME = 0,
        HISTORY = 1
    }
    public partial class RainMapCtr : UserControl, IRainMap
    {
        CRainmapRender m_pRainMap = null;
        bool m_bRealtime = true;
        private List<ASiteObj> m_pSiteObjList;
        private ASiteObj m_pActiveSiteObj;
        System.Windows.Forms.Timer m_pTimer;
        public RainMapCtr(IRainCalc siteRainCalc)
        {
            m_pRainMap = new CRainmapRender(this.Width, this.Height, siteRainCalc);
            m_pRainMap.OnCountRainStartAndStopTimeEvent += new RainMapNotifyDelegate(RainMapRender_OnCountRainStartAndStopTimeEvent);
            InitializeComponent();
            CSoftInfo.getInstance().UpdasteIdentity = "B";
        }
        public ASiteObj GetActiveSiteObj()
        {
            return m_pActiveSiteObj;
        }
        private IToolBar m_pToolBarControl;
        public IToolBar ToolBarControl
        {
            set { m_pToolBarControl = value; }
        }
        private ISiteControl m_pSiteControl;
        public ISiteControl SiteControl
        {
            set { m_pSiteControl = value; }
        }
        public void DrawRainMap(string id)
        {

            if (m_pActiveSiteObj != null)
            {
                if (m_pActiveSiteObj.SiteID.Equals(id))
                {
                    AsyncDrawRainMapImage();
                }
            }

    
        }
        public void ChangeActiveSite(string id)
        {
            foreach (ASiteObj obj in m_pSiteObjList)
                if (obj.SiteID.Equals(id))
                    m_pActiveSiteObj = obj;

            m_pToolBarControl.SetActivitySite(m_pActiveSiteObj);
            AsyncDrawRainMapImage();
        }
        private void AsyncDrawRainMapImage()
        {
            int nWidth = 0;
            int nHeight = 0;
            if (this.InvokeRequired)
            {
                Action<PictureBox> actionAddrCtrl = (X) =>
                {
                    X.Image = m_pRainMap.DrawRainMap(ref nWidth, ref nHeight, m_bRealtime, m_pActiveSiteObj);
                    X.Width = nWidth;
                    X.Height = nHeight;
                };
                Invoke(actionAddrCtrl, pictureBox_Main);
            }
            else
            {
                pictureBox_Main.Image = m_pRainMap.DrawRainMap(ref nWidth, ref nHeight, m_bRealtime, m_pActiveSiteObj);
                pictureBox_Main.Width = nWidth;
                pictureBox_Main.Height = nHeight;
            }
        }
        public List<ASiteObj> SiteObjList
        {
            set
            {
                m_pSiteObjList = value;
                foreach (ASiteObj obj in m_pSiteObjList)
                    if (obj.Type.Equals("comm"))
                        m_pActiveSiteObj = obj;
                m_pToolBarControl.SetActivitySite(m_pActiveSiteObj);
            }
        }
        void RainMapRender_OnCountRainStartAndStopTimeEvent(long t, bool b)
        {
            foreach (ASiteObj obj in m_pSiteObjList)
            {
                obj.IsRealTime = b;
                obj.BeginTime = t;
                obj.RainfallCoumpter();
            }
        }
        public CRainmapRender GetRainMapRender()
        {
            return m_pRainMap;
        }
        private void UserControl_RainMap_Load(object sender, EventArgs e)
        {
            m_pTimer = new System.Windows.Forms.Timer();
            m_pTimer.Interval = 60000;
            m_pTimer.Tick += new EventHandler(OnTimer);
            m_pTimer.Enabled = true;
        }
        public void refresh()
        {
            DrawRealtime();
        }
        public void OnTimer(object sender, EventArgs e)
        {
           
            if (!m_bRealtime) return;

            int nWidth = 0;
            int nHeight = 0;
            pictureBox_Main.Image = m_pRainMap.DrawRainMap(ref nWidth, ref nHeight, m_bRealtime, m_pActiveSiteObj);
            pictureBox_Main.Width = nWidth;
            pictureBox_Main.Height = nHeight;
        }

        public string DrawPrevDay()
        {
            m_bRealtime = false;

            long nBeginTime = m_pRainMap.GetBeginTime();
            nBeginTime -= 24 * 3600;
            m_pRainMap.SetBeginTime(nBeginTime);

            int nWidth = 0;
            int nHeight = 0;
            pictureBox_Main.Image = m_pRainMap.DrawRainMap(ref nWidth, ref nHeight, m_bRealtime, m_pActiveSiteObj);
            pictureBox_Main.Width = nWidth;
            pictureBox_Main.Height = nHeight;
            return m_pRainMap.GetRainCaptionString();
        }

        public string DrawNextDay(out bool b)
        {
            DateTime today = DateTime.Now;
            long t0 = Time.DateTime2DbTime(today);
            if (today.Hour <= 18)
                t0 -= 24 * 3600;

            today = Time.DbTime2DateTime(t0);
            today = new DateTime(today.Year, today.Month, today.Day, 18, 0, 0);

            t0 = m_pRainMap.GetBeginTime() + 24 * 3600;
            if (t0 > Time.DateTime2DbTime(today))
            {
                b = true;
                return DrawRealtime();
            }

            m_bRealtime = (Time.DateTime2DbTime(today) == t0);
            m_pRainMap.SetBeginTime(t0);

            int nWidth = 0;
            int nHeight = 0;
            pictureBox_Main.Image = m_pRainMap.DrawRainMap(ref nWidth, ref nHeight, m_bRealtime, m_pActiveSiteObj);
            pictureBox_Main.Width = nWidth;
            pictureBox_Main.Height = nHeight;
            b = false;
            return m_pRainMap.GetRainCaptionString();
        }

        public string DrawRealtime()
        {
            m_pSiteControl.RefreshSiteGirdView();
            m_bRealtime = true;
            m_pRainMap.CalcBeginTime();
            int nWidth = 0;
            int nHeight = 0;
            pictureBox_Main.Image = m_pRainMap.DrawRainMap(ref nWidth, ref nHeight, m_bRealtime, m_pActiveSiteObj);
            InvokePic(nWidth, nHeight);
            return m_pRainMap.GetRainCaptionString();
        }
        private void InvokePic(int nWidth, int nHeight)
        {
            if (pictureBox_Main.InvokeRequired)
            {
                // 当一个控件的InvokeRequired属性值为真时，说明有一个创建它以外的线程想访问它
                Action<int> actionWidthDelegate = (X) => { pictureBox_Main.Width = X; };
                Action<int> actionHeightDelegate = (X) => { pictureBox_Main.Height = X; };
                // 或者
                // Action<string> actionDelegate = delegate(string txt) { this.label2.Text = txt; };
                this.pictureBox_Main.Invoke(actionWidthDelegate, nWidth);
                this.pictureBox_Main.Invoke(actionHeightDelegate, nWidth);
            }
            else
            {
                pictureBox_Main.Width = nWidth;
                pictureBox_Main.Height = nHeight;
            }

        }
 
        private void pictureBox_Main_MouseMove(object sender, MouseEventArgs e)
        {

            //if (m_pRainMap == null) return;

            //m_pRainMap.OnMouseMove(pictureBox_Main, ParentTip, e.X, e.Y);

            //m_pRainMap.OnMouseMove(pictureBox_Main, e.X,e.Y);
            //toolTip_Main.Show(szMsg, pictureBox_Main, new Point(e.X, e.Y));
        }

        public string DrawAnyTime(DateTime t)
        {
            DateTime pSpecTime = new DateTime(t.Year, t.Month, t.Day, 0, 0, 0);
            long nSpecTime = Time.DateTime2DbTime(pSpecTime);

            long nBeginTime = m_pRainMap.GetBeginTime();
            DateTime pBeginTime = Time.DbTime2DateTime(nBeginTime);

            DateTime pStartDay = new DateTime(pBeginTime.Year, pBeginTime.Month, pBeginTime.Day, 0, 0, 0);
            long diff = difftime(Time.DateTime2DbTime(pStartDay), nSpecTime);

            long nBegin = nBeginTime - diff;
            m_pRainMap.SetBeginTime(nBegin);
            m_bRealtime = false;

            int nWidth = 0;
            int nHeight = 0;
            pictureBox_Main.Image = m_pRainMap.DrawRainMap(ref nWidth, ref nHeight, m_bRealtime, m_pActiveSiteObj);
            pictureBox_Main.Width = nWidth;
            pictureBox_Main.Height = nHeight;
            return m_pRainMap.GetRainCaptionString();
        }
        long difftime(long t1, long t2)
        {
            return (t1 - t2);
        }

        private void RainMapCtr_SizeChanged(object sender, EventArgs e)
        {
            m_pRainMap.parentWidth = this.Width;
            m_pRainMap.parentHeight = this.Height;
            int nWidth = 0;
            int nHeight = 0;
            if (m_pActiveSiteObj != null)
                pictureBox_Main.Image = m_pRainMap.DrawRainMap(ref nWidth, ref nHeight, m_bRealtime, m_pActiveSiteObj);
            pictureBox_Main.Width = nWidth;
            pictureBox_Main.Height = nHeight;
        }

        private void pictureBox_Main_MouseHover(object sender, EventArgs e)
        {
            //if (m_pRainMap == null) return;

            //m_pRainMap.OnMouseMove(pictureBox_Main, toolTip_Main, Control.MousePosition.X, Control.MousePosition.Y);
           
        }

        private void pictureBox_Main_MouseEnter(object sender, EventArgs e)
        {
            //if (m_pRainMap == null) return;

            //m_pRainMap.OnMouseMove(pictureBox_Main, toolTip_Main, Control.MousePosition.X, Control.MousePosition.Y);
        }

        private void pictureBox_Main_Click(object sender, EventArgs e)
        {
            if (m_pRainMap == null) return;

            m_pRainMap.OnMouseMove(pictureBox_Main, toolTip_Main, Control.MousePosition.X, Control.MousePosition.Y);
        }
    }
}
