using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using rainfalls.Base.Struct;
using rainfalls.Abstract.Class;
namespace rainfalls.View.Line
{
    public delegate void siteCtrlSelectChange(string id);
    public delegate void changRainMapCaptionHandler(string siteName,string km);
    public partial class lineCtrl : UserControl
    {
        public event siteCtrlSelectChange onSiteCtrlSelectEvent;
        public event changRainMapCaptionHandler onChangeCaptionKMEvent;
        private List<SiteCtrl.siteCtrl> m_leftChild = new List<SiteCtrl.siteCtrl>();
        private List<SiteCtrl.siteCtrl> m_rightChild = new List<SiteCtrl.siteCtrl>();
        private SiteCtrl.siteCtrl m_siteCtrlMain = new SiteCtrl.siteCtrl();
        private ASiteCtrlClickEvent m_siteCtrlEvent;
        private string m_siteName;
        private string m_lineName;
        public lineCtrl()
        {
            InitializeComponent();
        }

        private void lineCtrl_Load(object sender, EventArgs e)
        {
            this.picLine.Width = this.Width;
            m_siteCtrlMain.onChangeSelectEvent += new SiteCtrl.siteCtrlChangeSelectHandler(onSiteCtrlChangeSelect);
        }

        void onSiteCtrlChangeSelect(string id)
        {
            string km = null;
            if (id == m_siteCtrlMain.siteID)
            {
                m_siteCtrlMain.setSelect();
                km = m_siteCtrlMain.siteKM;
            }
            else
            {
                m_siteCtrlMain.setUnSelect();
            }
            int n = m_leftChild.Count;
            if (n > 0)
            {
                for (int i = 0, j = 1; i <= m_leftChild.Count - 1; i++, j++)
                {
                    if (m_leftChild[i].siteID == id)
                    {
                        m_leftChild[i].setSelect();
                        km = m_leftChild[i].siteKM;
                    }
                    else
                    {
                        m_leftChild[i].setUnSelect();
                    }
                }
            }
            n = m_rightChild.Count;
            if (n > 0)
            {
                for (int i = 0, j = 1; i <= m_rightChild.Count - 1; i++, j++)
                {
                    if (m_rightChild[i].siteID == id)
                    {
                        m_rightChild[i].setSelect();
                        km = m_rightChild[i].siteKM;
                    }
                    else
                    {
                        m_rightChild[i].setUnSelect();
                    }
                }
            }
            if (onSiteCtrlSelectEvent != null)
                onSiteCtrlSelectEvent(id);
            if (onChangeCaptionKMEvent != null)
                onChangeCaptionKMEvent(m_siteName,km);
        }
        public void setLineInfo(string line)
        {
            if (line.Equals("单线"))
            {
                Point p = pic2.Location;
                p.X += 5;
                pic2.Location = p;
            }
            else
            {

            }
        }
        public void setSiteName(string name)
        {
            m_siteName = name;
            changLableText(lbSiteName, name);
        }
        public void firstDefault()
        {
            if (onChangeCaptionKMEvent != null)
                onChangeCaptionKMEvent(m_siteName, m_siteCtrlMain.siteKM);
        }
        private void changLableText(Label lb,string name)
        {
            if (this.InvokeRequired)
            {
                Action<Label> actionchangLableText = (X) =>
                {
                    X.Text = name;
                };
                Invoke(actionchangLableText, lb);
            }
            else
            {
                lb.Text = name;
            }
        }


        private void sizeChange()
        {
            int n = m_leftChild.Count;
            if (n > 0)
            {
                int x = (this.Width / 2 - pic1.Width / 2) / (n + 1);
                Point p = new Point();
                p.Y = picLine.Location.Y - m_siteCtrlMain.Height;
                for (int i = 0, j = 1; i <= m_leftChild.Count - 1; i++, j++)
                {
                    p.X = x * j - m_siteCtrlMain.Width / 2;

                    m_leftChild[i].Location = p;
                    addCtrl(m_leftChild[i],DockStyle.None);
                }
            }
            n = m_rightChild.Count;
            if (n > 0)
            {
                Point p = new Point();
                p.Y = picLine.Location.Y - m_siteCtrlMain.Height;
                int x = (this.Width / 2 - pic1.Width / 2) / (n + 1);
                int s = this.Width / 2 + pic1.Width / 2;
                for (int i = 0, j = 1; i <= m_rightChild.Count - 1; i++, j++)
                {
                    p.X = x * j - m_siteCtrlMain.Width / 2 + s;

                    m_rightChild[i].Location = p;
                    addCtrl(m_rightChild[i], DockStyle.None);
                }
            }

        }
        public void bindSiteCtrlRTUobject(List<ASection> sec)
        {
            for (int i = 0; i < sec.Count; i++)
            {
                List<AMonitoringSite> list = sec[i].CurMonitorSiteList;
                for (int j = 0; j < list.Count; j++)
                {
                    if (!list[j].IsDefault)
                    {
                        int k = kmCmp(list[j].SiteKm, m_siteCtrlMain.getSiteKm());
                        SiteCtrl.siteCtrl s = new SiteCtrl.siteCtrl();
                        s.onChangeSelectEvent += new SiteCtrl.siteCtrlChangeSelectHandler(onSiteCtrlChangeSelect);
                        s.bindSiteRenderObject(list[j]);
                        if (k == 1)
                        {
                            m_rightChild.Add(s);
                        }
                        else
                        {
                            m_leftChild.Add(s);
                        }
                    }
                }
            }
            sizeChange();
        }
        public void bindSiteCtrlMainObject(ASection sec)
        {
            List<AMonitoringSite> list = sec.CurMonitorSiteList;
            for (int j = 0; j < list.Count; j++)
            {
                if (list[j].IsDefault)
                {
                    m_siteCtrlMain.bindSiteRenderObject(list[j]);
                    int x = this.Width / 2 - m_siteCtrlMain.Width / 2;
                    Point p = new Point();
                    p.Y = pic1.Location.Y - m_siteCtrlMain.Height;
                    p.X = x;
                    m_siteCtrlMain.Location = p;
                       
                    addCtrl(m_siteCtrlMain, DockStyle.None);
                    m_siteCtrlMain.setSelect();
                }
            }
        }
        private void addCtrl(UserControl ctrl, DockStyle ds)
        {
            if (this.InvokeRequired)
            {
                Action<UserControl> actionAddrCtrl = (X) =>
                {
                    Controls.Add(X);
                    X.BringToFront();
                };
                Invoke(actionAddrCtrl, ctrl);
            }
            else
            {
                Controls.Add(ctrl);
                ctrl.BringToFront();
            }
        } 
        private int kmCmp(string km1, string km2)
        {
            string[] Akm1 = km1.Split('+');
            string[] Akm2 = km2.Split('+');
            string s1 = Akm1[0].Substring(1);
            string s2 = Akm2[0].Substring(1);
            string s11 = Akm1[1];
            string s22 = Akm2[1];
            if (int.Parse(s1) > int.Parse(s2))
            {
                return 1;
            }
            else if (int.Parse(s1) < int.Parse(s2))
            {
                return -1;
            }
            else
            {
                if (int.Parse(s11) > int.Parse(s22))
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }

        private void lineCtrl_SizeChanged(object sender, EventArgs e)
        {
            this.picLine.Width = this.Width;
        }
        public void setChange(string id)
        {

            //if (mainSite.siteID != id)
            //    mainSite.unSelect();
            //else
            //    mainSite.select();
            //int n = m_leftChild.Count;
            //if (n > 0)
            //{
            //    for (int i = 0, j = 1; i <= m_leftChild.Count - 1; i++, j++)
            //    {
            //        if (m_leftChild[i].siteID != id)
            //            m_leftChild[i].unSelect();
            //        else
            //            m_leftChild[i].select();
            //    }
            //}
            //n = m_rightChild.Count;
            //if (n > 0)
            //{
            //    for (int i = 0, j = 1; i <= m_rightChild.Count - 1; i++, j++)
            //    {
            //        if (m_rightChild[i].siteID != id)
            //            m_rightChild[i].unSelect();
            //        else
            //            m_rightChild[i].select();
            //    }
            //}
        }
    }
}
