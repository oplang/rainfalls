namespace rainfalls.Views.Zone
{
    partial class ZoneControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZoneControl));
            this.lbZoneState = new DevExpress.XtraEditors.LabelControl();
            this.imageListZone = new System.Windows.Forms.ImageList();
            this.lbZoneName = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbZoneState
            // 
            this.lbZoneState.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbZoneState.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lbZoneState.Appearance.ImageIndex = 0;
            this.lbZoneState.Appearance.ImageList = this.imageListZone;
            this.lbZoneState.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbZoneState.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lbZoneState.LineVisible = true;
            this.lbZoneState.Location = new System.Drawing.Point(5, 1);
            this.lbZoneState.Name = "lbZoneState";
            this.lbZoneState.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lbZoneState.Size = new System.Drawing.Size(36, 34);
            this.lbZoneState.TabIndex = 4;
            this.lbZoneState.Click += new System.EventHandler(this.ControlClick);
            // 
            // imageListZone
            // 
            this.imageListZone.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListZone.ImageStream")));
            this.imageListZone.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListZone.Images.SetKeyName(0, "phone.png");
            this.imageListZone.Images.SetKeyName(1, "walk.png");
            this.imageListZone.Images.SetKeyName(2, "phone_no.png");
            this.imageListZone.Images.SetKeyName(3, "if_ic_keyboard_arrow_right_48px_352468.png");
            // 
            // lbZoneName
            // 
            this.lbZoneName.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbZoneName.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lbZoneName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbZoneName.Location = new System.Drawing.Point(32, 1);
            this.lbZoneName.LookAndFeel.SkinName = "Office 2013";
            this.lbZoneName.Name = "lbZoneName";
            this.lbZoneName.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lbZoneName.Size = new System.Drawing.Size(236, 34);
            this.lbZoneName.TabIndex = 5;
            this.lbZoneName.Text = "K254~k300,K234~k100";
            this.lbZoneName.Click += new System.EventHandler(this.ControlClick);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.lbZoneState);
            this.panelControl1.Controls.Add(this.lbZoneName);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(324, 35);
            this.panelControl1.TabIndex = 6;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl2.Appearance.ImageIndex = 3;
            this.labelControl2.Appearance.ImageList = this.imageListZone;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl2.LineVisible = true;
            this.labelControl2.Location = new System.Drawing.Point(283, 1);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.labelControl2.Size = new System.Drawing.Size(36, 34);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Click += new System.EventHandler(this.ControlClick);
            // 
            // ZoneControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelControl1);
            this.Name = "ZoneControl";
            this.Size = new System.Drawing.Size(324, 35);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbZoneState;
        private DevExpress.XtraEditors.LabelControl lbZoneName;
        private System.Windows.Forms.ImageList imageListZone;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;

    }
}
