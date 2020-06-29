namespace rainfalls.View.RainMapCaption
{
    partial class frmDateTime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDateTime));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lbCaption = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.lbDay = new DevExpress.XtraEditors.LabelControl();
            this.lbMonth = new DevExpress.XtraEditors.LabelControl();
            this.lbYear = new DevExpress.XtraEditors.LabelControl();
            this.sbQuery = new DevExpress.XtraEditors.SimpleButton();
            this.lbSubDay = new DevExpress.XtraEditors.SimpleButton();
            this.lbAddDay = new DevExpress.XtraEditors.SimpleButton();
            this.lbSubMonth = new DevExpress.XtraEditors.SimpleButton();
            this.lbAddMonth = new DevExpress.XtraEditors.SimpleButton();
            this.lbSubYear = new DevExpress.XtraEditors.SimpleButton();
            this.lbAddYear = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lbDay);
            this.panelControl2.Controls.Add(this.lbMonth);
            this.panelControl2.Controls.Add(this.lbYear);
            this.panelControl2.Controls.Add(this.sbQuery);
            this.panelControl2.Controls.Add(this.lbSubDay);
            this.panelControl2.Controls.Add(this.lbAddDay);
            this.panelControl2.Controls.Add(this.lbSubMonth);
            this.panelControl2.Controls.Add(this.lbAddMonth);
            this.panelControl2.Controls.Add(this.lbSubYear);
            this.panelControl2.Controls.Add(this.lbAddYear);
            this.panelControl2.Controls.Add(this.panelControl1);
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(481, 330);
            this.panelControl2.TabIndex = 30;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lbCaption);
            this.panelControl1.Controls.Add(this.pictureEdit1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(477, 32);
            this.panelControl1.TabIndex = 30;
            // 
            // lbCaption
            // 
            this.lbCaption.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbCaption.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCaption.Location = new System.Drawing.Point(11, 5);
            this.lbCaption.Name = "lbCaption";
            this.lbCaption.Size = new System.Drawing.Size(80, 22);
            this.lbCaption.TabIndex = 1;
            this.lbCaption.Text = "当前日期：";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(432, 2);
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
            // lbDay
            // 
            this.lbDay.Appearance.BackColor = System.Drawing.Color.White;
            this.lbDay.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.lbDay.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDay.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbDay.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbDay.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lbDay.Location = new System.Drawing.Point(303, 118);
            this.lbDay.Name = "lbDay";
            this.lbDay.Size = new System.Drawing.Size(115, 37);
            this.lbDay.TabIndex = 40;
            this.lbDay.Text = "-";
            // 
            // lbMonth
            // 
            this.lbMonth.Appearance.BackColor = System.Drawing.Color.White;
            this.lbMonth.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.lbMonth.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMonth.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbMonth.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbMonth.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lbMonth.Location = new System.Drawing.Point(182, 118);
            this.lbMonth.Name = "lbMonth";
            this.lbMonth.Size = new System.Drawing.Size(115, 37);
            this.lbMonth.TabIndex = 39;
            this.lbMonth.Text = "-";
            // 
            // lbYear
            // 
            this.lbYear.Appearance.BackColor = System.Drawing.Color.White;
            this.lbYear.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.lbYear.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbYear.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbYear.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbYear.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lbYear.Location = new System.Drawing.Point(61, 118);
            this.lbYear.Name = "lbYear";
            this.lbYear.Size = new System.Drawing.Size(115, 37);
            this.lbYear.TabIndex = 38;
            this.lbYear.Text = "-";
            // 
            // sbQuery
            // 
            this.sbQuery.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sbQuery.Appearance.Options.UseFont = true;
            this.sbQuery.Location = new System.Drawing.Point(61, 234);
            this.sbQuery.Name = "sbQuery";
            this.sbQuery.Size = new System.Drawing.Size(357, 63);
            this.sbQuery.TabIndex = 37;
            this.sbQuery.Text = "确定";
            this.sbQuery.Click += new System.EventHandler(this.sbQuery_Click);
            // 
            // lbSubDay
            // 
            this.lbSubDay.Appearance.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSubDay.Appearance.Options.UseFont = true;
            this.lbSubDay.Location = new System.Drawing.Point(303, 156);
            this.lbSubDay.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            this.lbSubDay.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lbSubDay.Name = "lbSubDay";
            this.lbSubDay.Size = new System.Drawing.Size(115, 47);
            this.lbSubDay.TabIndex = 36;
            this.lbSubDay.Text = "-";
            this.lbSubDay.Click += new System.EventHandler(this.lbSubDay_Click);
            // 
            // lbAddDay
            // 
            this.lbAddDay.Appearance.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAddDay.Appearance.Options.UseFont = true;
            this.lbAddDay.Location = new System.Drawing.Point(303, 70);
            this.lbAddDay.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            this.lbAddDay.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lbAddDay.Name = "lbAddDay";
            this.lbAddDay.Size = new System.Drawing.Size(115, 47);
            this.lbAddDay.TabIndex = 35;
            this.lbAddDay.Text = "+";
            this.lbAddDay.Click += new System.EventHandler(this.lbAddDay_Click);
            // 
            // lbSubMonth
            // 
            this.lbSubMonth.Appearance.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSubMonth.Appearance.Options.UseFont = true;
            this.lbSubMonth.Location = new System.Drawing.Point(182, 156);
            this.lbSubMonth.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            this.lbSubMonth.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lbSubMonth.Name = "lbSubMonth";
            this.lbSubMonth.Size = new System.Drawing.Size(115, 47);
            this.lbSubMonth.TabIndex = 34;
            this.lbSubMonth.Text = "-";
            this.lbSubMonth.Click += new System.EventHandler(this.lbSubMonth_Click);
            // 
            // lbAddMonth
            // 
            this.lbAddMonth.Appearance.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAddMonth.Appearance.Options.UseFont = true;
            this.lbAddMonth.Location = new System.Drawing.Point(182, 70);
            this.lbAddMonth.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            this.lbAddMonth.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lbAddMonth.Name = "lbAddMonth";
            this.lbAddMonth.Size = new System.Drawing.Size(115, 47);
            this.lbAddMonth.TabIndex = 33;
            this.lbAddMonth.Text = "+";
            this.lbAddMonth.Click += new System.EventHandler(this.lbAddMonth_Click);
            // 
            // lbSubYear
            // 
            this.lbSubYear.Appearance.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSubYear.Appearance.Options.UseFont = true;
            this.lbSubYear.Location = new System.Drawing.Point(61, 156);
            this.lbSubYear.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            this.lbSubYear.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lbSubYear.Name = "lbSubYear";
            this.lbSubYear.Size = new System.Drawing.Size(115, 47);
            this.lbSubYear.TabIndex = 32;
            this.lbSubYear.Text = "-";
            this.lbSubYear.Click += new System.EventHandler(this.lbSubYear_Click);
            // 
            // lbAddYear
            // 
            this.lbAddYear.Appearance.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAddYear.Appearance.Options.UseFont = true;
            this.lbAddYear.Location = new System.Drawing.Point(61, 70);
            this.lbAddYear.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            this.lbAddYear.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lbAddYear.Name = "lbAddYear";
            this.lbAddYear.Size = new System.Drawing.Size(115, 47);
            this.lbAddYear.TabIndex = 31;
            this.lbAddYear.Text = "+";
            this.lbAddYear.Click += new System.EventHandler(this.lbAddYear_Click);
            // 
            // frmDateTime
            // 
            this.AcceptButton = this.sbQuery;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 330);
            this.Controls.Add(this.panelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDateTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDateTime";
            this.Deactivate += new System.EventHandler(this.frmDateTime_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDateTime_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDateTime_FormClosed);
            this.Load += new System.EventHandler(this.frmDateTime_Load);
            this.VisibleChanged += new System.EventHandler(this.frmDateTime_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lbCaption;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl lbDay;
        private DevExpress.XtraEditors.LabelControl lbMonth;
        private DevExpress.XtraEditors.LabelControl lbYear;
        private DevExpress.XtraEditors.SimpleButton sbQuery;
        private DevExpress.XtraEditors.SimpleButton lbSubDay;
        private DevExpress.XtraEditors.SimpleButton lbAddDay;
        private DevExpress.XtraEditors.SimpleButton lbSubMonth;
        private DevExpress.XtraEditors.SimpleButton lbAddMonth;
        private DevExpress.XtraEditors.SimpleButton lbSubYear;
        private DevExpress.XtraEditors.SimpleButton lbAddYear;

    }
}