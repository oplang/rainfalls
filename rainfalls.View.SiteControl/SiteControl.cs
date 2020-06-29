using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using rainfalls.Abstract.Class;
using rainfalls.Abstract.Interface;
using rainfalls.Base.Class;
using Zyf.Ini;
using rainfalls.path;
using rainfalls.View.frmConfig;
namespace rainfalls.View.SiteControl
{
 
    public partial class SiteControl : UserControl,ISiteControl
    {
        public SiteControl()
        {
            InitializeComponent();
        }

        private IRainMap m_pRainMapCtrlObj;
        public IRainMap RainMapObj
        {
            set { m_pRainMapCtrlObj = value; }
        }
        private IRainMapCaption m_pRainMapCaption;
        public IRainMapCaption RainMapCaptionObj
        {
            set { m_pRainMapCaption = value; }
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case CMessage.WM_ONREFRESH_SITEGRIDVIEW:
                    RefreshSiteGirdView();
                    break;
                case CMessage.WM_ONREFRESH_RAINMAP:
                    m_pRainMapCtrlObj.DrawRealtime();
                    break;
            }
            base.WndProc(ref m);
        }
        public void BindingData(BindingSource dataSource)
        {
            if (SiteGridControl.InvokeRequired)
            {
                Action<DevExpress.XtraGrid.GridControl> bind = (X) =>
                {
                    X.DataSource = dataSource;
                    siteGridView.BestFitColumns();
                };
                Invoke(bind, SiteGridControl);
            }
            else
            {
                SiteGridControl.DataSource = dataSource;  
            }
        }
        public void ControlHeight()
        {
            //if (this.InvokeRequired)
            //{
            //    Action<UserControl> bind = (X) =>
            //    {
            //        X.Height = siteGridView.RowHeight * (siteGridView.RowCount) + siteGridView.ColumnPanelRowHeight +100;
            //        //this.Height = QJGridView.RowHeight * (QJGridView.RowCount) + QJGridView.ColumnPanelRowHeight + 5;
            //    };
            //    Invoke(bind, this);
            //}
            //else
            //{
            //    // QJGridView.ViewCaptionHeight = 10;
            //    this.Height = siteGridView.RowHeight * (siteGridView.RowCount) + siteGridView.ColumnPanelRowHeight;
            //}

            // this.Height = 130;
        }
        public void RefreshSiteGirdView()
        {
            siteGridView.RefreshData();
            siteGridView.Columns["RainProStartTime"].BestFit();
            siteGridView.Columns["RainProStopTime"].BestFit();
           
        }
        private void SiteControl_Load(object sender, EventArgs e)
        {
            IniHelper.IniWriteValue("System", paths.SiteControlHandle, this.Handle.ToInt32().ToString(), paths.HandlePath);
            this.siteGridView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(siteGridView_RowClick);    
        }
        void siteGridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int i = this.siteGridView.FocusedRowHandle;
            if (i >= 0)
            {
                siteGridView.Columns["RainProStartTime"].BestFit();
                siteGridView.Columns["RainProStopTime"].BestFit();
                object needAlert = siteGridView.GetRowCellValue(this.siteGridView.FocusedRowHandle, siteGridView.Columns["SiteID"]);
                string id = (string)needAlert;
                m_pRainMapCtrlObj.ChangeActiveSite(id);
                object o = siteGridView.GetRowCellValue(this.siteGridView.FocusedRowHandle, siteGridView.Columns["SiteName"]);
                string siteName = (string)o;
                m_pRainMapCaption.setCaptionKm(siteName);
            }
        }
       
    }
}
