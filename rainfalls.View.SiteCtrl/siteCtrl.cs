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
namespace rainfalls.View.SiteCtrl
{
    public partial class siteCtrl : UserControl
    {
        private int m_nDevState;
        private string [] m_state = new string[2]{"正常","异常"};
        private string[] m_sLevel = new string[4] { "正常", "出巡","限速","扣车" };
        private string m_siteKm;
        private string m_siteId;
        private string mSiteName;
        private ASiteCtrlClickEvent m_siteCtrlClick;
        private ASiteSubject m_siteRender;
        public siteCtrl()
        {
            InitializeComponent();
        }
        public void bindSiteRenderObject(ASiteSubject siteRender)
        {
            m_siteRender = siteRender;
            m_siteKm = siteRender.SiteKm;
            m_siteId = siteRender.SiteId;
        }
        public string getSiteKm()
        {
            return m_siteRender.SiteKm;
        }
        void updateSiteCtrlLevel(int level)
        {
            //if (lbLevel.InvokeRequired)
            //{
            //    Action<int> updateCtrlLevel = (X) =>
            //    {
            //        lbLevel.Text = m_sLevel[X];
            //        lbLevel.ForeColor = Color.Red;
            //        lbStaticLevel.ForeColor = Color.Red;
            //    };
            //    lbLevel.Invoke(updateCtrlLevel, level);
            //}
            //else
            //{
            //    lbLevel.Text = m_sLevel[level];
            //    lbLevel.ForeColor = Color.Red;
            //    lbStaticLevel.ForeColor = Color.Red;
            //}
        }
        public ASiteCtrlClickEvent siteCtrlClickEventObj
        {
            set
            {
                m_siteCtrlClick = value;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (m_siteRender != null)
            {
                if (m_siteRender.isRainStop())
                {
                    lbCont.Text = string.Format("{0}.{1}mm", 0, 0);
                    lb1HRain.Text = string.Format("{0}.{1}mm", 0, 0);
                    lb3HRain.Text = string.Format("{0}.{1}mm", 0, 0);
                }
                else
                {
                    lbCont.Text = string.Format("{0}.{1}mm", m_siteRender.getRealRainInfo().rainCont / 10, m_siteRender.getRealRainInfo().rainCont % 10);
                    lb1HRain.Text = string.Format("{0}.{1}mm", m_siteRender.getRealRainInfo().rain1H / 10, m_siteRender.getRealRainInfo().rain1H % 10);
                    lb3HRain.Text = string.Format("{0}.{1}mm", m_siteRender.getRealRainInfo().rain3H / 10, m_siteRender.getRealRainInfo().rain3H % 10);
                }
                lbSiteName.Text = string.Format("【{0}】{1}", mSiteName, "");
            }
            
        }
        public string siteID
        {
            set
            {
                m_siteId = value;
            }
            get
            {
                return m_siteId;
            }
        }
        public string siteKM
        {
            set
            {
                m_siteKm = value;
            }
            get
            {
                return m_siteKm;
            }
        }

        public int DevStatue
        {
            set
            {
                m_nDevState = value;
            }
        }
        void picVisibleChange(bool b)
        {
            //if (pic_select.InvokeRequired)
            //{
            //    Action<bool> visibleChange = (X) =>
            //    {
            //        pic_select.Visible = X;
            //    };
            //    pic_select.Invoke(visibleChange, b);
            //}
            //else
            //    pic_select.Visible = b;
        }
        public void setSelect()
        {
            picVisibleChange(true);
        }
        public void setUnSelect()
        {
            picVisibleChange(false);
        }
        private void siteCtrl_Click(object sender, EventArgs e)
        {
            m_siteCtrlClick.setCurrentSite(m_siteId);
            m_siteCtrlClick.setCaptionKM(m_siteKm);
        }

        private void siteCtrl_Load(object sender, EventArgs e)
        {
            Timer t = new Timer();
            t.Interval = 100;
            t.Tick += new EventHandler(timer1_Tick);
            t.Start();
        }
    }
}
