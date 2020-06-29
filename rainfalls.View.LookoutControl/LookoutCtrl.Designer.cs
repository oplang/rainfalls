namespace rainfalls.View.LookoutControl
{
    partial class LookoutCtrl
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.QJGridControl = new DevExpress.XtraGrid.GridControl();
            this.QJGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.LineName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.XingBieName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SectionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LevelFormat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HadMeasure = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.repositoryItemHyperLinkEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.QJGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QJGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.simpleButton1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.simpleButton1.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.White;
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.Appearance.Options.UseBorderColor = true;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.simpleButton1.Image = global::rainfalls.View.LookoutControl.Properties.Resources.xunshou32;
            this.simpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButton1.Location = new System.Drawing.Point(0, 0);
            this.simpleButton1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.simpleButton1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.simpleButton1.Size = new System.Drawing.Size(839, 37);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "派人巡守";
            // 
            // QJGridControl
            // 
            this.QJGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QJGridControl.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QJGridControl.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.QJGridControl.Location = new System.Drawing.Point(0, 37);
            this.QJGridControl.LookAndFeel.SkinName = "Office 2010 Silver";
            this.QJGridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.QJGridControl.MainView = this.QJGridView;
            this.QJGridControl.Name = "QJGridControl";
            this.QJGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.repositoryItemButtonEdit2,
            this.repositoryItemHyperLinkEdit1,
            this.repositoryItemHyperLinkEdit2});
            this.QJGridControl.Size = new System.Drawing.Size(839, 470);
            this.QJGridControl.TabIndex = 3;
            this.QJGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.QJGridView});
            // 
            // QJGridView
            // 
            this.QJGridView.ActiveFilterEnabled = false;
            this.QJGridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.QJGridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Red;
            this.QJGridView.Appearance.FocusedRow.BorderColor = System.Drawing.Color.Red;
            this.QJGridView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.QJGridView.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.QJGridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.QJGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.QJGridView.Appearance.Row.Options.UseTextOptions = true;
            this.QJGridView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.QJGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.LineName,
            this.XingBieName,
            this.SectionName,
            this.LevelFormat,
            this.HadMeasure,
            this.ID});
            this.QJGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.QJGridView.GridControl = this.QJGridControl;
            this.QJGridView.Name = "QJGridView";
            this.QJGridView.OptionsBehavior.Editable = false;
            this.QJGridView.OptionsBehavior.ReadOnly = true;
            this.QJGridView.OptionsCustomization.AllowColumnMoving = false;
            this.QJGridView.OptionsCustomization.AllowFilter = false;
            this.QJGridView.OptionsCustomization.AllowGroup = false;
            this.QJGridView.OptionsCustomization.AllowQuickHideColumns = false;
            this.QJGridView.OptionsCustomization.AllowSort = false;
            this.QJGridView.OptionsFilter.AllowFilterEditor = false;
            this.QJGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.QJGridView.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.QJGridView.OptionsView.ShowDetailButtons = false;
            this.QJGridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.QJGridView.OptionsView.ShowGroupPanel = false;
            this.QJGridView.OptionsView.ShowIndicator = false;
            this.QJGridView.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.False;
            // 
            // LineName
            // 
            this.LineName.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineName.AppearanceCell.Options.UseFont = true;
            this.LineName.Caption = "巡守地点";
            this.LineName.FieldName = "SeeWarn";
            this.LineName.Name = "LineName";
            this.LineName.Visible = true;
            this.LineName.VisibleIndex = 0;
            // 
            // XingBieName
            // 
            this.XingBieName.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XingBieName.AppearanceCell.Options.UseFont = true;
            this.XingBieName.Caption = "巡守状态";
            this.XingBieName.FieldName = "XingBieName";
            this.XingBieName.Name = "XingBieName";
            this.XingBieName.Visible = true;
            this.XingBieName.VisibleIndex = 1;
            // 
            // SectionName
            // 
            this.SectionName.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SectionName.AppearanceCell.Options.UseFont = true;
            this.SectionName.Caption = "开始时间";
            this.SectionName.FieldName = "开始时间";
            this.SectionName.Name = "SectionName";
            // 
            // LevelFormat
            // 
            this.LevelFormat.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LevelFormat.AppearanceCell.Options.UseFont = true;
            this.LevelFormat.Caption = "结束时间";
            this.LevelFormat.FieldName = "结束时间";
            this.LevelFormat.Name = "LevelFormat";
            // 
            // HadMeasure
            // 
            this.HadMeasure.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.HadMeasure.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.HadMeasure.AppearanceCell.Options.UseFont = true;
            this.HadMeasure.AppearanceCell.Options.UseForeColor = true;
            this.HadMeasure.Caption = "操作";
            this.HadMeasure.FieldName = "操作";
            this.HadMeasure.Name = "HadMeasure";
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "解除", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.repositoryItemButtonEdit1.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // repositoryItemButtonEdit2
            // 
            this.repositoryItemButtonEdit2.AutoHeight = false;
            this.repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            // 
            // repositoryItemHyperLinkEdit2
            // 
            this.repositoryItemHyperLinkEdit2.AutoHeight = false;
            this.repositoryItemHyperLinkEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemHyperLinkEdit2.Caption = "查看";
            this.repositoryItemHyperLinkEdit2.LookAndFeel.SkinName = "Office 2013 Light Gray";
            this.repositoryItemHyperLinkEdit2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.repositoryItemHyperLinkEdit2.Name = "repositoryItemHyperLinkEdit2";
            // 
            // LookoutCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.QJGridControl);
            this.Controls.Add(this.simpleButton1);
            this.Name = "LookoutCtrl";
            this.Size = new System.Drawing.Size(839, 507);
            ((System.ComponentModel.ISupportInitialize)(this.QJGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QJGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.GridControl QJGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView QJGridView;
        private DevExpress.XtraGrid.Columns.GridColumn LineName;
        private DevExpress.XtraGrid.Columns.GridColumn XingBieName;
        private DevExpress.XtraGrid.Columns.GridColumn SectionName;
        private DevExpress.XtraGrid.Columns.GridColumn LevelFormat;
        private DevExpress.XtraGrid.Columns.GridColumn HadMeasure;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit2;


    }
}
