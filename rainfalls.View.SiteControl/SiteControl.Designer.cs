namespace rainfalls.View.SiteControl
{
    partial class SiteControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SiteControl));
            this.SiteName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SiteGridControl = new DevExpress.XtraGrid.GridControl();
            this.siteGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SiteID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.site_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LevelisHave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.Section = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ContRain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Rain1H = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Rain12H = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Rain24H = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Rain3H = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RainProStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RainProEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.Rain7Day = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Rain10M = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.SiteGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // SiteName
            // 
            this.SiteName.Caption = "站点名称";
            this.SiteName.FieldName = "SiteName";
            this.SiteName.Name = "SiteName";
            // 
            // SiteGridControl
            // 
            this.SiteGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SiteGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(0);
            this.SiteGridControl.Location = new System.Drawing.Point(0, 0);
            this.SiteGridControl.LookAndFeel.SkinName = "Office 2010 Silver";
            this.SiteGridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.SiteGridControl.MainView = this.siteGridView;
            this.SiteGridControl.Name = "SiteGridControl";
            this.SiteGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1,
            this.repositoryItemHyperLinkEdit2});
            this.SiteGridControl.Size = new System.Drawing.Size(851, 265);
            this.SiteGridControl.TabIndex = 1;
            this.SiteGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.siteGridView});
            // 
            // siteGridView
            // 
            this.siteGridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.siteGridView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.siteGridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.siteGridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.siteGridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.siteGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.siteGridView.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.siteGridView.Appearance.Row.Options.UseFont = true;
            this.siteGridView.Appearance.Row.Options.UseTextOptions = true;
            this.siteGridView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.siteGridView.Appearance.ViewCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.siteGridView.Appearance.ViewCaption.Image = ((System.Drawing.Image)(resources.GetObject("siteGridView.Appearance.ViewCaption.Image")));
            this.siteGridView.Appearance.ViewCaption.Options.UseFont = true;
            this.siteGridView.Appearance.ViewCaption.Options.UseImage = true;
            this.siteGridView.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.siteGridView.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.siteGridView.ColumnPanelRowHeight = 25;
            this.siteGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SiteID,
            this.site_name,
            this.LevelisHave,
            this.Section,
            this.ContRain,
            this.Rain10M,
            this.Rain1H,
            this.Rain12H,
            this.Rain24H,
            this.Rain3H,
            this.Rain7Day,
            this.RainProStart,
            this.RainProEnd});
            this.siteGridView.GridControl = this.SiteGridControl;
            this.siteGridView.Name = "siteGridView";
            this.siteGridView.OptionsBehavior.Editable = false;
            this.siteGridView.OptionsBehavior.ReadOnly = true;
            this.siteGridView.OptionsCustomization.AllowColumnMoving = false;
            this.siteGridView.OptionsCustomization.AllowFilter = false;
            this.siteGridView.OptionsCustomization.AllowGroup = false;
            this.siteGridView.OptionsCustomization.AllowQuickHideColumns = false;
            this.siteGridView.OptionsCustomization.AllowSort = false;
            this.siteGridView.OptionsFilter.AllowFilterEditor = false;
            this.siteGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.siteGridView.OptionsView.ShowDetailButtons = false;
            this.siteGridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.siteGridView.OptionsView.ShowGroupPanel = false;
            this.siteGridView.OptionsView.ShowIndicator = false;
            this.siteGridView.RowHeight = 30;
            this.siteGridView.ViewCaptionHeight = 0;
            // 
            // SiteID
            // 
            this.SiteID.Caption = "站点标识";
            this.SiteID.FieldName = "SiteID";
            this.SiteID.Name = "SiteID";
            // 
            // site_name
            // 
            this.site_name.Caption = "站点名称";
            this.site_name.FieldName = "SiteName";
            this.site_name.Name = "site_name";
            this.site_name.Visible = true;
            this.site_name.VisibleIndex = 0;
            // 
            // LevelisHave
            // 
            this.LevelisHave.Caption = "警戒值";
            this.LevelisHave.ColumnEdit = this.repositoryItemHyperLinkEdit2;
            this.LevelisHave.FieldName = "ShowFiles";
            this.LevelisHave.Name = "LevelisHave";
            // 
            // repositoryItemHyperLinkEdit2
            // 
            this.repositoryItemHyperLinkEdit2.AutoHeight = false;
            this.repositoryItemHyperLinkEdit2.Name = "repositoryItemHyperLinkEdit2";
            // 
            // Section
            // 
            this.Section.Caption = "影响区间";
            this.Section.FieldName = "SectionsName";
            this.Section.Name = "Section";
            this.Section.Visible = true;
            this.Section.VisibleIndex = 1;
            // 
            // ContRain
            // 
            this.ContRain.Caption = "连续";
            this.ContRain.FieldName = "ContRain";
            this.ContRain.Name = "ContRain";
            this.ContRain.Visible = true;
            this.ContRain.VisibleIndex = 2;
            // 
            // Rain1H
            // 
            this.Rain1H.Caption = "1小时";
            this.Rain1H.FieldName = "Rain1H";
            this.Rain1H.Name = "Rain1H";
            this.Rain1H.Visible = true;
            this.Rain1H.VisibleIndex = 4;
            // 
            // Rain12H
            // 
            this.Rain12H.Caption = "12小时";
            this.Rain12H.FieldName = "Rain12H";
            this.Rain12H.Name = "Rain12H";
            this.Rain12H.Visible = true;
            this.Rain12H.VisibleIndex = 5;
            // 
            // Rain24H
            // 
            this.Rain24H.Caption = "24小时";
            this.Rain24H.FieldName = "Rain24H";
            this.Rain24H.Name = "Rain24H";
            this.Rain24H.Visible = true;
            this.Rain24H.VisibleIndex = 6;
            // 
            // Rain3H
            // 
            this.Rain3H.Caption = "5天";
            this.Rain3H.FieldName = "Rain3H";
            this.Rain3H.Name = "Rain3H";
            this.Rain3H.Visible = true;
            this.Rain3H.VisibleIndex = 7;
            // 
            // RainProStart
            // 
            this.RainProStart.Caption = "降雨过程开始时间";
            this.RainProStart.FieldName = "RainProStartTime";
            this.RainProStart.Name = "RainProStart";
            this.RainProStart.Visible = true;
            this.RainProStart.VisibleIndex = 9;
            // 
            // RainProEnd
            // 
            this.RainProEnd.Caption = "降雨过程结束时间";
            this.RainProEnd.FieldName = "RainProStopTime";
            this.RainProEnd.Name = "RainProEnd";
            this.RainProEnd.Visible = true;
            this.RainProEnd.VisibleIndex = 10;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AccessibleName = "";
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Caption = "查看";
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            // 
            // Rain7Day
            // 
            this.Rain7Day.Caption = "7天";
            this.Rain7Day.FieldName = "Rain7Day";
            this.Rain7Day.Name = "Rain7Day";
            this.Rain7Day.Visible = true;
            this.Rain7Day.VisibleIndex = 8;
            // 
            // Rain10M
            // 
            this.Rain10M.Caption = "10分";
            this.Rain10M.FieldName = "Rain10M";
            this.Rain10M.Name = "Rain10M";
            this.Rain10M.Visible = true;
            this.Rain10M.VisibleIndex = 3;
            // 
            // SiteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.SiteGridControl);
            this.Name = "SiteControl";
            this.Size = new System.Drawing.Size(851, 265);
            this.Load += new System.EventHandler(this.SiteControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SiteGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn SiteName;
        private DevExpress.XtraGrid.GridControl SiteGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView siteGridView;
        private DevExpress.XtraGrid.Columns.GridColumn SiteID;
        private DevExpress.XtraGrid.Columns.GridColumn site_name;
        private DevExpress.XtraGrid.Columns.GridColumn LevelisHave;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn Section;
        private DevExpress.XtraGrid.Columns.GridColumn ContRain;
        private DevExpress.XtraGrid.Columns.GridColumn Rain1H;
        private DevExpress.XtraGrid.Columns.GridColumn Rain12H;
        private DevExpress.XtraGrid.Columns.GridColumn Rain24H;
        private DevExpress.XtraGrid.Columns.GridColumn RainProStart;
        private DevExpress.XtraGrid.Columns.GridColumn RainProEnd;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn Rain3H;
        private DevExpress.XtraGrid.Columns.GridColumn Rain7Day;
        private DevExpress.XtraGrid.Columns.GridColumn Rain10M;
    }
}
