namespace rainfalls.Views.DockFormInspector
{
    partial class frmInspectorDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInspectorDetail));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.InspectorGridControl = new DevExpress.XtraGrid.GridControl();
            this.InspectorGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.UUID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WarningTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SectionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ZoneName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ZoneType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ZoneID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StartTimeFormat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StopTimeFormat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PersonName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PersonType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PersonPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StateFormat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.State = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.repositoryItemHyperLinkEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.inspectorState = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemImageEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repositoryItemImageEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemImageEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemCheckedComboBoxEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InspectorGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InspectorGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inspectorState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.pictureEdit1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(966, 32);
            this.panelControl1.TabIndex = 8;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl1.Location = new System.Drawing.Point(427, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 22);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "巡守记录";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(921, 2);
            this.pictureEdit1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.ZoomPercent = 50D;
            this.pictureEdit1.Size = new System.Drawing.Size(43, 28);
            this.pictureEdit1.TabIndex = 0;
            this.pictureEdit1.Click += new System.EventHandler(this.pictureEdit1_Click);
            // 
            // InspectorGridControl
            // 
            this.InspectorGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InspectorGridControl.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InspectorGridControl.EmbeddedNavigator.Appearance.Options.UseFont = true;
            gridLevelNode1.RelationName = "Level1";
            this.InspectorGridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.InspectorGridControl.Location = new System.Drawing.Point(0, 32);
            this.InspectorGridControl.LookAndFeel.SkinName = "Office 2010 Silver";
            this.InspectorGridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.InspectorGridControl.MainView = this.InspectorGridView;
            this.InspectorGridControl.Name = "InspectorGridControl";
            this.InspectorGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.repositoryItemButtonEdit2,
            this.repositoryItemHyperLinkEdit1,
            this.repositoryItemHyperLinkEdit2,
            this.inspectorState,
            this.repositoryItemImageEdit1,
            this.repositoryItemImageEdit2,
            this.repositoryItemPictureEdit1,
            this.repositoryItemImageEdit3,
            this.repositoryItemImageEdit4,
            this.repositoryItemComboBox1,
            this.repositoryItemCheckedComboBoxEdit1});
            this.InspectorGridControl.Size = new System.Drawing.Size(966, 425);
            this.InspectorGridControl.TabIndex = 9;
            this.InspectorGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.InspectorGridView});
            // 
            // InspectorGridView
            // 
            this.InspectorGridView.ActiveFilterEnabled = false;
            this.InspectorGridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.InspectorGridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Red;
            this.InspectorGridView.Appearance.FocusedRow.BorderColor = System.Drawing.Color.Red;
            this.InspectorGridView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.InspectorGridView.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.InspectorGridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.InspectorGridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.InspectorGridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.InspectorGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.InspectorGridView.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InspectorGridView.Appearance.Row.Options.UseFont = true;
            this.InspectorGridView.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.InspectorGridView.Appearance.VertLine.Options.UseBackColor = true;
            this.InspectorGridView.Appearance.ViewCaption.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.InspectorGridView.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Red;
            this.InspectorGridView.Appearance.ViewCaption.Options.UseFont = true;
            this.InspectorGridView.Appearance.ViewCaption.Options.UseForeColor = true;
            this.InspectorGridView.ColumnPanelRowHeight = 30;
            this.InspectorGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.UUID,
            this.WarningTime,
            this.SectionID,
            this.ZoneName,
            this.ZoneType,
            this.ZoneID,
            this.StartTimeFormat,
            this.StopTimeFormat,
            this.PersonName,
            this.PersonType,
            this.PersonPhone,
            this.StateFormat,
            this.State});
            this.InspectorGridView.FixedLineWidth = 12;
            this.InspectorGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.InspectorGridView.GridControl = this.InspectorGridControl;
            this.InspectorGridView.Name = "InspectorGridView";
            this.InspectorGridView.OptionsBehavior.Editable = false;
            this.InspectorGridView.OptionsBehavior.ReadOnly = true;
            this.InspectorGridView.OptionsCustomization.AllowColumnMoving = false;
            this.InspectorGridView.OptionsCustomization.AllowFilter = false;
            this.InspectorGridView.OptionsCustomization.AllowGroup = false;
            this.InspectorGridView.OptionsCustomization.AllowQuickHideColumns = false;
            this.InspectorGridView.OptionsCustomization.AllowSort = false;
            this.InspectorGridView.OptionsFilter.AllowFilterEditor = false;
            this.InspectorGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.InspectorGridView.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.InspectorGridView.OptionsView.ShowDetailButtons = false;
            this.InspectorGridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.InspectorGridView.OptionsView.ShowGroupPanel = false;
            this.InspectorGridView.OptionsView.ShowIndicator = false;
            this.InspectorGridView.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.True;
            this.InspectorGridView.RowHeight = 25;
            this.InspectorGridView.ViewCaption = "区间列表";
            this.InspectorGridView.ViewCaptionHeight = 10;
            // 
            // UUID
            // 
            this.UUID.Caption = "记录ID";
            this.UUID.FieldName = "UUID";
            this.UUID.Name = "UUID";
            // 
            // WarningTime
            // 
            this.WarningTime.Caption = "报警时间";
            this.WarningTime.FieldName = "WarningTime";
            this.WarningTime.Name = "WarningTime";
            this.WarningTime.Width = 148;
            // 
            // SectionID
            // 
            this.SectionID.Caption = "区间标识";
            this.SectionID.FieldName = "SectionID";
            this.SectionID.Name = "SectionID";
            // 
            // ZoneName
            // 
            this.ZoneName.Caption = "巡守地点";
            this.ZoneName.FieldName = "ZoneName";
            this.ZoneName.Name = "ZoneName";
            this.ZoneName.Visible = true;
            this.ZoneName.VisibleIndex = 0;
            // 
            // ZoneType
            // 
            this.ZoneType.Caption = "巡守类型";
            this.ZoneType.FieldName = "ZoneType";
            this.ZoneType.Name = "ZoneType";
            // 
            // ZoneID
            // 
            this.ZoneID.Caption = "看守点ID";
            this.ZoneID.FieldName = "ZoneID";
            this.ZoneID.Name = "ZoneID";
            // 
            // StartTimeFormat
            // 
            this.StartTimeFormat.Caption = "巡守开始时间";
            this.StartTimeFormat.FieldName = "StartTimeFormat";
            this.StartTimeFormat.Name = "StartTimeFormat";
            this.StartTimeFormat.Visible = true;
            this.StartTimeFormat.VisibleIndex = 1;
            this.StartTimeFormat.Width = 148;
            // 
            // StopTimeFormat
            // 
            this.StopTimeFormat.Caption = "巡守结束时间";
            this.StopTimeFormat.FieldName = "StopTimeFormat";
            this.StopTimeFormat.Name = "StopTimeFormat";
            this.StopTimeFormat.Visible = true;
            this.StopTimeFormat.VisibleIndex = 2;
            this.StopTimeFormat.Width = 148;
            // 
            // PersonName
            // 
            this.PersonName.Caption = "巡守人员";
            this.PersonName.FieldName = "PersonName";
            this.PersonName.Name = "PersonName";
            this.PersonName.Visible = true;
            this.PersonName.VisibleIndex = 3;
            // 
            // PersonType
            // 
            this.PersonType.Caption = "人员情况";
            this.PersonType.FieldName = "PersonType";
            this.PersonType.Name = "PersonType";
            // 
            // PersonPhone
            // 
            this.PersonPhone.Caption = "电话";
            this.PersonPhone.FieldName = "PersonPhone";
            this.PersonPhone.Name = "PersonPhone";
            this.PersonPhone.Visible = true;
            this.PersonPhone.VisibleIndex = 4;
            this.PersonPhone.Width = 224;
            // 
            // StateFormat
            // 
            this.StateFormat.Caption = "措施";
            this.StateFormat.FieldName = "StateFormat";
            this.StateFormat.Name = "StateFormat";
            this.StateFormat.Width = 454;
            // 
            // State
            // 
            this.State.Caption = "InspectorState";
            this.State.FieldName = "InspectorState";
            this.State.Name = "State";
            // 
            // repositoryItemButtonEdit1
            // 
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
            // inspectorState
            // 
            this.inspectorState.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "等待"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "通知"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "巡守")});
            this.inspectorState.Name = "inspectorState";
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            // 
            // repositoryItemImageEdit2
            // 
            this.repositoryItemImageEdit2.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemImageEdit2.Appearance.Image")));
            this.repositoryItemImageEdit2.Appearance.Options.UseImage = true;
            this.repositoryItemImageEdit2.AutoHeight = false;
            this.repositoryItemImageEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit2.Name = "repositoryItemImageEdit2";
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemPictureEdit1.Appearance.Image")));
            this.repositoryItemPictureEdit1.Appearance.Options.UseImage = true;
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // repositoryItemImageEdit3
            // 
            this.repositoryItemImageEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit3.Name = "repositoryItemImageEdit3";
            // 
            // repositoryItemImageEdit4
            // 
            this.repositoryItemImageEdit4.AutoHeight = false;
            this.repositoryItemImageEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit4.Name = "repositoryItemImageEdit4";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "ghjgkjfsdf",
            "sdfsdfsd",
            "sdfsdfs",
            "sdfsdf",
            "sdfsdfsd",
            "sdfsdfweewsdg"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // repositoryItemCheckedComboBoxEdit1
            // 
            this.repositoryItemCheckedComboBoxEdit1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repositoryItemCheckedComboBoxEdit1.Appearance.Options.UseFont = true;
            this.repositoryItemCheckedComboBoxEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCheckedComboBoxEdit1.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "t4t4t4"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "et4te4t"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "te4terg"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "gergerg4")});
            this.repositoryItemCheckedComboBoxEdit1.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.repositoryItemCheckedComboBoxEdit1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.repositoryItemCheckedComboBoxEdit1.Name = "repositoryItemCheckedComboBoxEdit1";
            // 
            // frmInspectorDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 457);
            this.Controls.Add(this.InspectorGridControl);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmInspectorDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmInspectorDetail";
            this.Deactivate += new System.EventHandler(this.frmInspectorDetail_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInspectorDetail_FormClosing);
            this.Load += new System.EventHandler(this.frmInspectorDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InspectorGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InspectorGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inspectorState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraGrid.GridControl InspectorGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView InspectorGridView;
        private DevExpress.XtraGrid.Columns.GridColumn UUID;
        private DevExpress.XtraGrid.Columns.GridColumn WarningTime;
        private DevExpress.XtraGrid.Columns.GridColumn SectionID;
        private DevExpress.XtraGrid.Columns.GridColumn ZoneName;
        private DevExpress.XtraGrid.Columns.GridColumn ZoneType;
        private DevExpress.XtraGrid.Columns.GridColumn ZoneID;
        private DevExpress.XtraGrid.Columns.GridColumn StartTimeFormat;
        private DevExpress.XtraGrid.Columns.GridColumn StopTimeFormat;
        private DevExpress.XtraGrid.Columns.GridColumn PersonName;
        private DevExpress.XtraGrid.Columns.GridColumn PersonType;
        private DevExpress.XtraGrid.Columns.GridColumn PersonPhone;
        private DevExpress.XtraGrid.Columns.GridColumn StateFormat;
        private DevExpress.XtraGrid.Columns.GridColumn State;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup inspectorState;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit repositoryItemCheckedComboBoxEdit1;
    }
}