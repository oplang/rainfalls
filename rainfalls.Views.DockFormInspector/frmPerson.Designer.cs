namespace rainfalls.Views.DockFormInspector
{
    partial class frmPerson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPerson));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.PersonGridControl = new DevExpress.XtraGrid.GridControl();
            this.PersonGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.personName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.personPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PersonType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PersonState = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.PersonGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonGridView)).BeginInit();
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
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.simpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton1.Location = new System.Drawing.Point(0, 328);
            this.simpleButton1.LookAndFeel.SkinName = "Office 2010 Black";
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(597, 44);
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "巡查";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
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
            this.panelControl1.Size = new System.Drawing.Size(597, 32);
            this.panelControl1.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(242, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(112, 20);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "单击指派巡守人员";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(2, 2);
            this.pictureEdit1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.PictureAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.ZoomPercent = 50D;
            this.pictureEdit1.Size = new System.Drawing.Size(43, 28);
            this.pictureEdit1.TabIndex = 0;
            this.pictureEdit1.EditValueChanged += new System.EventHandler(this.pictureEdit1_EditValueChanged);
            this.pictureEdit1.Click += new System.EventHandler(this.pictureEdit1_Click);
            // 
            // PersonGridControl
            // 
            this.PersonGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PersonGridControl.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PersonGridControl.EmbeddedNavigator.Appearance.Options.UseFont = true;
            gridLevelNode1.RelationName = "Level1";
            this.PersonGridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.PersonGridControl.Location = new System.Drawing.Point(0, 32);
            this.PersonGridControl.LookAndFeel.SkinName = "VS2010";
            this.PersonGridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.PersonGridControl.MainView = this.PersonGridView;
            this.PersonGridControl.Name = "PersonGridControl";
            this.PersonGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
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
            this.PersonGridControl.Size = new System.Drawing.Size(597, 296);
            this.PersonGridControl.TabIndex = 8;
            this.PersonGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.PersonGridView});
            // 
            // PersonGridView
            // 
            this.PersonGridView.ActiveFilterEnabled = false;
            this.PersonGridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.PersonGridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.PersonGridView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.PersonGridView.Appearance.GroupRow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PersonGridView.Appearance.GroupRow.Options.UseFont = true;
            this.PersonGridView.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Silver;
            this.PersonGridView.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.Silver;
            this.PersonGridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PersonGridView.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.PersonGridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.PersonGridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.PersonGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PersonGridView.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PersonGridView.Appearance.Row.Options.UseFont = true;
            this.PersonGridView.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.PersonGridView.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.PersonGridView.Appearance.SelectedRow.Options.UseBackColor = true;
            this.PersonGridView.Appearance.ViewCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PersonGridView.Appearance.ViewCaption.Options.UseFont = true;
            this.PersonGridView.ColumnPanelRowHeight = 30;
            this.PersonGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.personName,
            this.personPhone,
            this.PersonType,
            this.PersonState});
            this.PersonGridView.FixedLineWidth = 12;
            this.PersonGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.PersonGridView.GridControl = this.PersonGridControl;
            this.PersonGridView.GroupCount = 1;
            this.PersonGridView.Name = "PersonGridView";
            this.PersonGridView.OptionsBehavior.AutoExpandAllGroups = true;
            this.PersonGridView.OptionsBehavior.Editable = false;
            this.PersonGridView.OptionsBehavior.ReadOnly = true;
            this.PersonGridView.OptionsCustomization.AllowColumnMoving = false;
            this.PersonGridView.OptionsCustomization.AllowFilter = false;
            this.PersonGridView.OptionsCustomization.AllowGroup = false;
            this.PersonGridView.OptionsCustomization.AllowQuickHideColumns = false;
            this.PersonGridView.OptionsCustomization.AllowSort = false;
            this.PersonGridView.OptionsFilter.AllowFilterEditor = false;
            this.PersonGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.PersonGridView.OptionsView.ShowColumnHeaders = false;
            this.PersonGridView.OptionsView.ShowDetailButtons = false;
            this.PersonGridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.PersonGridView.OptionsView.ShowGroupPanel = false;
            this.PersonGridView.OptionsView.ShowIndicator = false;
            this.PersonGridView.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.True;
            this.PersonGridView.RowHeight = 35;
            this.PersonGridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.PersonType, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.PersonGridView.ViewCaption = "防洪巡守人员列表";
            this.PersonGridView.ViewCaptionHeight = 10;
            // 
            // personName
            // 
            this.personName.AppearanceCell.Options.UseTextOptions = true;
            this.personName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.personName.Caption = "巡守人员";
            this.personName.FieldName = "PersonName";
            this.personName.Name = "personName";
            this.personName.Visible = true;
            this.personName.VisibleIndex = 0;
            this.personName.Width = 104;
            // 
            // personPhone
            // 
            this.personPhone.Caption = "电话";
            this.personPhone.FieldName = "PersonPhone";
            this.personPhone.Name = "personPhone";
            this.personPhone.Visible = true;
            this.personPhone.VisibleIndex = 1;
            this.personPhone.Width = 225;
            // 
            // PersonType
            // 
            this.PersonType.Caption = "编制";
            this.PersonType.FieldName = "PersonType";
            this.PersonType.Name = "PersonType";
            this.PersonType.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.PersonType.Visible = true;
            this.PersonType.VisibleIndex = 2;
            // 
            // PersonState
            // 
            this.PersonState.Caption = "gridColumn1";
            this.PersonState.FieldName = "PersonState";
            this.PersonState.Name = "PersonState";
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
            // frmPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 372);
            this.Controls.Add(this.PersonGridControl);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.simpleButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPerson";
            this.Text = "frmPerson";
            this.Deactivate += new System.EventHandler(this.frmPerson_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPerson_FormClosing);
            this.Load += new System.EventHandler(this.frmPerson_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonGridView)).EndInit();
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

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl PersonGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView PersonGridView;
        private DevExpress.XtraGrid.Columns.GridColumn personName;
        private DevExpress.XtraGrid.Columns.GridColumn personPhone;
        private DevExpress.XtraGrid.Columns.GridColumn PersonType;
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
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn PersonState;


    }
}