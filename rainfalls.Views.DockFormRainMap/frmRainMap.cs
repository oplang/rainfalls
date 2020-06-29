using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using rainfalls.View.RainMapCaption;
using rainfalls.View.RainMapCtrl;
using rainfalls.Abstract.Interface;
using rainfalls.Abstract.Class;

namespace rainfalls.Views.DockFormRainMap
{
    public partial class frmRainMap : DockContent
    {
        private static frmRainMap uniqueInstance;
        private static readonly object padlock = new object();

        private captionCtrl m_pRainfallsCaption;
        private RainMapCtr m_pRainfallsMap;
        private frmRainMap()
        {
            InitializeComponent();
            this.AllowEndUserDocking = false;
        }
        public static frmRainMap getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new frmRainMap();
                    }
                }
            }
            return uniqueInstance;
        }
        public IToolBar ToolBarControl
        {
            set { m_pRainfallsMap.ToolBarControl = value; }
        }
        public ISiteControl SiteControl
        {
            set { m_pRainfallsMap.SiteControl = value; }
        }
        public List<ASiteObj> SiteObjList
        {
            set { m_pRainfallsMap.SiteObjList = value; }
        }
        private void frmRainMap_Load(object sender, EventArgs e)
        {
            
            //addCtrl(m_pRainfallsCaption, DockStyle.Top);
            //m_pRainfallsCaption.setCaptionKm(CRainfallXmlHelper.getInstance().siteName + m_pDefaultKM);
        }
        public void DrawRainMap(IRainCalc siteRainCalc,IRainfallsDBHelper dbHelper)
        {
            
            m_pRainfallsMap = new RainMapCtr(siteRainCalc);
            m_pRainfallsMap.Dock = DockStyle.Fill;
            this.Controls.Add(m_pRainfallsMap);

            m_pRainfallsCaption = new captionCtrl(this);
            m_pRainfallsCaption.DbHelper = dbHelper;
            m_pRainfallsCaption.SiteRainCalc = siteRainCalc;
            m_pRainfallsCaption.Dock = DockStyle.Top;
            this.Controls.Add(m_pRainfallsCaption);

          

            
           // m_pRainfallsMap.ToolBarControl = m_pRainfallsToolbar;
        }
        public void Unicom()
        {
            m_pRainfallsCaption.RainMapObj = m_pRainfallsMap;
            m_pRainfallsCaption.DrawRainMapCaption();
        }
        public IRainMap RainMapObj
        {
            get { return m_pRainfallsMap; }
        }
        public IRainMapCaption RainMapCaptionObj
        {
            get { return m_pRainfallsCaption; }
        }

 
    }
}
