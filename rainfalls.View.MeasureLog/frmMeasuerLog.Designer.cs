namespace rainfalls.View.MeasureLog
{
    partial class frmMeasuerLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMeasuerLog));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.dtMeasureLog = new System.Windows.Forms.DataGridView();
            this.tmColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.区间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReasonWhyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reasonColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMeasureLog)).BeginInit();
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
            this.panelControl1.Size = new System.Drawing.Size(989, 32);
            this.panelControl1.TabIndex = 28;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl1.Location = new System.Drawing.Point(438, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 22);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "措施日志";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(944, 2);
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
            this.pictureEdit1.Click += new System.EventHandler(this.pictureEdit1_Click);
            // 
            // dtMeasureLog
            // 
            this.dtMeasureLog.AllowUserToAddRows = false;
            this.dtMeasureLog.AllowUserToResizeColumns = false;
            this.dtMeasureLog.AllowUserToResizeRows = false;
            this.dtMeasureLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtMeasureLog.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtMeasureLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtMeasureLog.ColumnHeadersHeight = 35;
            this.dtMeasureLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tmColumn,
            this.区间,
            this.ReasonWhyColumn,
            this.reasonColumn,
            this.personColumn,
            this.id});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtMeasureLog.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtMeasureLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtMeasureLog.EnableHeadersVisualStyles = false;
            this.dtMeasureLog.Location = new System.Drawing.Point(0, 32);
            this.dtMeasureLog.MultiSelect = false;
            this.dtMeasureLog.Name = "dtMeasureLog";
            this.dtMeasureLog.ReadOnly = true;
            this.dtMeasureLog.RowHeadersVisible = false;
            this.dtMeasureLog.RowTemplate.Height = 30;
            this.dtMeasureLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtMeasureLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtMeasureLog.Size = new System.Drawing.Size(989, 438);
            this.dtMeasureLog.TabIndex = 29;
            // 
            // tmColumn
            // 
            this.tmColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tmColumn.FillWeight = 48.98957F;
            this.tmColumn.HeaderText = "登记时间";
            this.tmColumn.Name = "tmColumn";
            this.tmColumn.ReadOnly = true;
            this.tmColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tmColumn.Width = 70;
            // 
            // 区间
            // 
            this.区间.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.区间.HeaderText = "区间";
            this.区间.Name = "区间";
            this.区间.ReadOnly = true;
            this.区间.Width = 61;
            // 
            // ReasonWhyColumn
            // 
            this.ReasonWhyColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ReasonWhyColumn.FillWeight = 206.1769F;
            this.ReasonWhyColumn.HeaderText = "采取措施原因";
            this.ReasonWhyColumn.Name = "ReasonWhyColumn";
            this.ReasonWhyColumn.ReadOnly = true;
            this.ReasonWhyColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // reasonColumn
            // 
            this.reasonColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.reasonColumn.FillWeight = 101.5228F;
            this.reasonColumn.HeaderText = "应采取措施";
            this.reasonColumn.Name = "reasonColumn";
            this.reasonColumn.ReadOnly = true;
            this.reasonColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.reasonColumn.Width = 84;
            // 
            // personColumn
            // 
            this.personColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.personColumn.FillWeight = 43.31067F;
            this.personColumn.HeaderText = "被通知人";
            this.personColumn.Name = "personColumn";
            this.personColumn.ReadOnly = true;
            this.personColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.personColumn.Width = 70;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.id.HeaderText = "采集点";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id.Width = 56;
            // 
            // frmMeasuerLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 470);
            this.ControlBox = false;
            this.Controls.Add(this.dtMeasureLog);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMeasuerLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "措施日志";
            this.Deactivate += new System.EventHandler(this.frmMeasuerLog_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMeasuerLog_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMeasuerLog_FormClosed);
            this.Load += new System.EventHandler(this.frmMeasuerLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMeasureLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private System.Windows.Forms.DataGridView dtMeasureLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 区间;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReasonWhyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reasonColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn personColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
    }
}