using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using rainfalls.Abstract.Class;
using rainfalls.View.SiteControl;
using rainfalls.Abstract.Interface;
namespace rainfalls.Views.SiteDockForm
{
    public partial class frmSite : DockContent
    {
        private static frmSite uniqueInstance;
        private static readonly object padlock = new object();
        BindingSource m_pSiteSource = new BindingSource();
        private SiteControl m_pSiteControl;
        private frmSite()
        {
            InitializeComponent();
            this.AllowEndUserDocking = false;
        }
        public static frmSite getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new frmSite();
                    }
                }
            }
            return uniqueInstance;
        }
        public void InitializeSiteList(List<ASiteObj> SiteObjList )
        {
            m_pSiteControl = new SiteControl();
            m_pSiteSource.DataSource = SiteObjList;
            m_pSiteControl.BindingData(m_pSiteSource);
            m_pSiteControl.Dock = DockStyle.Fill;
            this.Controls.Add(m_pSiteControl);
            m_pSiteControl.ControlHeight();
        }
        public ISiteControl SiteControl
        {
            get { return m_pSiteControl; }
        }
        public IRainMap RainMapObj
        {
            set { m_pSiteControl.RainMapObj = value; }
        }
        public IRainMapCaption RainMapCaptionObj
        {
            set { m_pSiteControl.RainMapCaptionObj = value; }
        }
    }
}
