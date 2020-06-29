using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rainfalls.Views.SiteCtrl
{
    public partial class siteControl : UserControl
    {
        private bool m_bIsTopShow = false;
        private string m_pSiteName;
        public siteControl()
        {
            InitializeComponent();
        }
        [CategoryAttribute("site"),
      DescriptionAttribute("站点显示位置")]
        public bool IsTopShow
        {
            set
            {
                m_bIsTopShow = value;
                if (m_bIsTopShow)
                {
                    lineBottomH.Visible = false;
                    lineBottomV.Visible = false;
                    bottomSiteName.Visible = false;

                    lineTopH.Visible = true;
                    lineTopV.Visible = true;
                    topSiteName.Visible = true;
                }
                else
                {
                    lineTopH.Visible = false;
                    lineTopV.Visible = false;
                    topSiteName.Visible = false;

                    lineBottomH.Visible = true;
                    lineBottomV.Visible = true;
                    bottomSiteName.Visible = true;
                }
            }
            get
            {
                return m_bIsTopShow;
            }
        }
        [CategoryAttribute("site"),
        DescriptionAttribute("站点名称"),
        DefaultValue("测试站点")]
        public string SiteName
        {
            get
            {
                return m_pSiteName;
            }
            set
            {
                m_pSiteName = value;
                topSiteName.Text = value;
                bottomSiteName.Text = value;
            }
        }
    }
}
