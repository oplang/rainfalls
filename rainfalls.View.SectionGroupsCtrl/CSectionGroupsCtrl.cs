//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Collections;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;
//using rainfalls.Abstract.Class;
//using rainfalls.Base.Struct;
//using rainfalls.View.SectionCtrl;
//using rainfalls.Abstract.Interface;

//namespace rainfalls.View.SectionGroupsCtrl
//{
//    public partial class CSectionGroupsCtrl : UserControl
//    {
//        private ASiteCtrlClickEvent m_siteCtrlClick;
//        private string[] m_sLevel = new string[4] { "正常", "出巡", "限速", "扣车" };
//        private string m_siteName = null;
//        private ASiteSubject m_siteRender;
        
//        public CSectionGroupsCtrl()
//        {
//            InitializeComponent();
//        }
//        public ASiteCtrlClickEvent siteCtrlClickEventObj
//        {
//            set
//            {
//                m_siteCtrlClick = value;
//            }
//        }
//        public string siteName
//        {
//            set { m_siteName = value; }
//            get { return m_siteName; }
//        }
//        private void sectionGroupsCtrl_Load(object sender, EventArgs e)
//        {
//         //   picLine.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "rec\\splitLine.bmp");
//            Timer t = new Timer();
//            t.Tick += new EventHandler(t_Tick);
//            t.Start();
//        }

//        void t_Tick(object sender, EventArgs e)
//        {
//            //if (m_siteRender != null)
//            //{
//            //    if ( m_siteRender.isRainStop())
//            //    {
//            //        lbCont.Text = string.Format("{0}.{1}mm", 0, 0);
//            //        lb1HRain.Text = string.Format("{0}.{1}mm", 0, 0);
//            //        lb3HRain.Text = string.Format("{0}.{1}mm", 0, 0);
//            //    }
//            //    else
//            //    {
//            //        lbCont.Text = string.Format("{0}.{1}mm", m_siteRender.getRealRainInfo().rainCont / 10, m_siteRender.getRealRainInfo().rainCont % 10);
//            //        lb1HRain.Text = string.Format("{0}.{1}mm", m_siteRender.getRealRainInfo().rain1H / 10, m_siteRender.getRealRainInfo().rain1H % 10);
//            //        lb3HRain.Text = string.Format("{0}.{1}mm", m_siteRender.getRealRainInfo().rain3H / 10, m_siteRender.getRealRainInfo().rain3H % 10);
//            //    }
//            //    lbSiteName.Text = string.Format("【{0}】{1}", m_siteName, "");
//            //}
//        }
//        private void sectionGroupsCtrl_Paint(object sender, PaintEventArgs e)
//        {
//            this.picLine.Width = this.Width;
//        }
//        public void drawCtrl(int nSpace, Dictionary<string, ASectionSubject> section, Dictionary<string, ASiteSubject> site, IRainfallsDBHelper dbHelper, Dictionary<string, ALiftLevelManager> liftLevelManager,ISoundPlay soundPlay)
//        {
//            int marinLeft = nSpace;
//            int marinRight = nSpace;
//            int n = section.Count;
//            int nCtrlSpace = nSpace * (n - 1);
//            int w = (this.Width - marinLeft - marinRight - nCtrlSpace) / n;
//            Point p = new Point();
//            p.X = marinLeft;
//            int nOffsetX = 0;
//            int nOffsetY = 0;
//            IDictionaryEnumerator en = section.GetEnumerator();
//            while (en.MoveNext())
//            {
//                sectionCtrl sc = new sectionCtrl();
//                sc.offsetX = nOffsetX;
//                sc.offsetY = nOffsetY;
//                sc.siteCtrlClickEventObj = m_siteCtrlClick;
//                sc.rainfallsDbHelper = dbHelper;
//                sc.Width = w;
//                p.Y = picLine.Location.Y - sc.Height;
//                sc.Location = p;
//                ASectionSubject ass = (ASectionSubject)en.Value;
//                ass.onNotifyLiftLevelEvent += new onNotifyHandler(liftLevelManager[ass.SiteSection].Notity);
//                ass.NotifyLiftLevelManager();
//                sc.SoundPlay = soundPlay;
//                sc.sectionSubject = ass;
//                sc.LiftLevelManager = liftLevelManager[ass.SiteSection];
//                sc.drawSiteCtrl(site);
//                p.X += (w + nSpace);
//                addCtrl(sc, DockStyle.None);
//                nOffsetX += 50;
//                nOffsetY += 50;
//            }
//            settingLocalSiteRender(site);
//        }
//        private void settingLocalSiteRender(Dictionary<string, ASiteSubject> site)
//        {
//            IDictionaryEnumerator en = site.GetEnumerator();
//            while (en.MoveNext())
//            {
//                ASiteSubject se = (ASiteSubject)en.Value;
//                if (se.IsCommSite)
//                    m_siteRender = se;
//            }
//        }
//        private void addCtrl(UserControl ctrl, DockStyle ds)
//        {
//            if (this.InvokeRequired)
//            {
//                Action<UserControl> actionAddrCtrl = (X) =>
//                {
//                    Controls.Add(X);
//                    X.BringToFront();
//                };
//                Invoke(actionAddrCtrl, ctrl);
//            }
//            else
//            {
//                Controls.Add(ctrl);
//                ctrl.BringToFront();
//            }
//        }

//        private void siteCtrlClick(object sender, EventArgs e)
//        {
//            m_siteCtrlClick.setCurrentSite(m_siteRender.SiteId);
//            m_siteCtrlClick.setCaptionKM(m_siteRender.SiteKm);

//        }
//        private void plBack_MouseEnter(object sender, EventArgs e)
//        {
//        //    this.lbStatic3H.ForeColor = this.lbStatic1H.ForeColor = this.lb1HRain.ForeColor = this.lb3HRain.ForeColor = this.lbCont.ForeColor = this.lbSiteName.ForeColor = lbStaticCont.ForeColor = Color.LightGoldenrodYellow;
//        }

//        private void plBack_MouseLeave(object sender, EventArgs e)
//        {

//        } 
//    }
//}
