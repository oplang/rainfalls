namespace rainfalls.Views.DockFormInspector
{
    partial class frmInspector
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInspector));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnShowAll = new DevExpress.XtraEditors.LabelControl();
            this.lbInspectorConfig = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "phone.png");
            this.imageList1.Images.SetKeyName(1, "phone_no.png");
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.btnShowAll.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowAll.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnShowAll.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.btnShowAll.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnShowAll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnShowAll.Location = new System.Drawing.Point(0, 411);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(395, 42);
            this.btnShowAll.TabIndex = 5;
            this.btnShowAll.Text = "巡守日志";
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // lbInspectorConfig
            // 
            this.lbInspectorConfig.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.lbInspectorConfig.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInspectorConfig.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbInspectorConfig.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbInspectorConfig.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lbInspectorConfig.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbInspectorConfig.Location = new System.Drawing.Point(0, 369);
            this.lbInspectorConfig.Name = "lbInspectorConfig";
            this.lbInspectorConfig.Size = new System.Drawing.Size(395, 42);
            this.lbInspectorConfig.TabIndex = 7;
            this.lbInspectorConfig.Text = "巡守配置";
            this.lbInspectorConfig.Click += new System.EventHandler(this.lbInspectorConfig_Click);
            // 
            // frmInspector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(395, 453);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.lbInspectorConfig);
            this.Controls.Add(this.btnShowAll);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmInspector";
            this.TabText = "";
            this.Text = "防洪巡守";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmInspector_FormClosed);
            this.Load += new System.EventHandler(this.frmInspector_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.LabelControl btnShowAll;
        private DevExpress.XtraEditors.LabelControl lbInspectorConfig;


    }
}