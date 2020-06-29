namespace rainfalls.View.SectionControl
{
    partial class SectionControl
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue3 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule4 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue4 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.SectionAlarmLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LevelFormat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QJGridControl = new DevExpress.XtraGrid.GridControl();
            this.QJGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.LineName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.XingBieName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SectionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HadMeasure = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.QJGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QJGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // SectionAlarmLevel
            // 
            this.SectionAlarmLevel.Caption = "level";
            this.SectionAlarmLevel.FieldName = "SectionAlarmLevel";
            this.SectionAlarmLevel.Name = "SectionAlarmLevel";
            // 
            // LevelFormat
            // 
            this.LevelFormat.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LevelFormat.AppearanceCell.Options.UseFont = true;
            this.LevelFormat.Caption = "警戒";
            this.LevelFormat.FieldName = "LevelFormat";
            this.LevelFormat.Name = "LevelFormat";
            this.LevelFormat.Visible = true;
            this.LevelFormat.VisibleIndex = 3;
            // 
            // QJGridControl
            // 
            this.QJGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QJGridControl.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QJGridControl.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.QJGridControl.Location = new System.Drawing.Point(0, 0);
            this.QJGridControl.LookAndFeel.SkinName = "Office 2010 Silver";
            this.QJGridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.QJGridControl.MainView = this.QJGridView;
            this.QJGridControl.Name = "QJGridControl";
            this.QJGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.repositoryItemButtonEdit2,
            this.repositoryItemHyperLinkEdit1,
            this.repositoryItemHyperLinkEdit2});
            this.QJGridControl.Size = new System.Drawing.Size(1062, 188);
            this.QJGridControl.TabIndex = 0;
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
            this.QJGridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QJGridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.QJGridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.QJGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.QJGridView.Appearance.Row.Options.UseTextOptions = true;
            this.QJGridView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.QJGridView.Appearance.ViewCaption.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QJGridView.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Red;
            this.QJGridView.Appearance.ViewCaption.Options.UseFont = true;
            this.QJGridView.Appearance.ViewCaption.Options.UseForeColor = true;
            this.QJGridView.ColumnPanelRowHeight = 35;
            this.QJGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.LineName,
            this.XingBieName,
            this.SectionName,
            this.LevelFormat,
            this.HadMeasure,
            this.ID,
            this.SectionAlarmLevel});
            this.QJGridView.FixedLineWidth = 12;
            this.QJGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.SectionAlarmLevel;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Blue;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = "1";
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.SectionAlarmLevel;
            gridFormatRule2.Name = "Format1";
            formatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            formatConditionRuleValue2.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue2.Value1 = "2";
            gridFormatRule2.Rule = formatConditionRuleValue2;
            gridFormatRule3.ApplyToRow = true;
            gridFormatRule3.Column = this.SectionAlarmLevel;
            gridFormatRule3.Name = "Format2";
            formatConditionRuleValue3.Appearance.ForeColor = System.Drawing.Color.Maroon;
            formatConditionRuleValue3.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue3.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue3.Value1 = "3";
            gridFormatRule3.Rule = formatConditionRuleValue3;
            gridFormatRule4.ApplyToRow = true;
            gridFormatRule4.Column = this.SectionAlarmLevel;
            gridFormatRule4.Name = "Format3";
            formatConditionRuleValue4.Appearance.ForeColor = System.Drawing.Color.Red;
            formatConditionRuleValue4.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue4.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue4.PredefinedName = "Italic Text";
            formatConditionRuleValue4.Value1 = "4";
            formatConditionRuleValue4.Value2 = "4";
            gridFormatRule4.Rule = formatConditionRuleValue4;
            this.QJGridView.FormatRules.Add(gridFormatRule1);
            this.QJGridView.FormatRules.Add(gridFormatRule2);
            this.QJGridView.FormatRules.Add(gridFormatRule3);
            this.QJGridView.FormatRules.Add(gridFormatRule4);
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
            this.QJGridView.RowHeight = 30;
            this.QJGridView.ViewCaption = "区间列表";
            this.QJGridView.ViewCaptionHeight = 10;
            // 
            // LineName
            // 
            this.LineName.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineName.AppearanceCell.Options.UseFont = true;
            this.LineName.Caption = "警戒值";
            this.LineName.ColumnEdit = this.repositoryItemHyperLinkEdit2;
            this.LineName.FieldName = "SeeWarn";
            this.LineName.Name = "LineName";
            this.LineName.Visible = true;
            this.LineName.VisibleIndex = 0;
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
            // XingBieName
            // 
            this.XingBieName.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XingBieName.AppearanceCell.Options.UseFont = true;
            this.XingBieName.Caption = "线路行别";
            this.XingBieName.FieldName = "XingBieName";
            this.XingBieName.Name = "XingBieName";
            this.XingBieName.Visible = true;
            this.XingBieName.VisibleIndex = 1;
            // 
            // SectionName
            // 
            this.SectionName.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SectionName.AppearanceCell.Options.UseFont = true;
            this.SectionName.Caption = "区间";
            this.SectionName.FieldName = "SectionName";
            this.SectionName.Name = "SectionName";
            this.SectionName.Visible = true;
            this.SectionName.VisibleIndex = 2;
            // 
            // HadMeasure
            // 
            this.HadMeasure.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.HadMeasure.AppearanceCell.Options.UseFont = true;
            this.HadMeasure.Caption = "应采取措施";
            this.HadMeasure.FieldName = "HadMeasure";
            this.HadMeasure.Name = "HadMeasure";
            this.HadMeasure.Visible = true;
            this.HadMeasure.VisibleIndex = 4;
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
            // SectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.QJGridControl);
            this.Name = "SectionControl";
            this.Size = new System.Drawing.Size(1062, 188);
            this.Load += new System.EventHandler(this.SectionControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QJGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QJGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl QJGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView QJGridView;
        private DevExpress.XtraGrid.Columns.GridColumn LineName;
        private DevExpress.XtraGrid.Columns.GridColumn XingBieName;
        private DevExpress.XtraGrid.Columns.GridColumn SectionName;
        private DevExpress.XtraGrid.Columns.GridColumn HadMeasure;
        private DevExpress.XtraGrid.Columns.GridColumn LevelFormat;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn SectionAlarmLevel;
    }
}
