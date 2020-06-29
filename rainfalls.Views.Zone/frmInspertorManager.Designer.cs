namespace rainfalls.Views.Zone
{
    partial class frmInspertorManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInspertorManager));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.sbClose = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnStop = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnStart = new DevExpress.XtraEditors.SimpleButton();
            this.gcPerson = new DevExpress.XtraEditors.GroupControl();
            this.radioGroupPerson = new DevExpress.XtraEditors.RadioGroup();
            this.gcWorkNumber = new DevExpress.XtraEditors.GroupControl();
            this.sbtnNumberDel = new DevExpress.XtraEditors.SimpleButton();
            this.btn8 = new DevExpress.XtraEditors.SimpleButton();
            this.btn7 = new DevExpress.XtraEditors.SimpleButton();
            this.btn6 = new DevExpress.XtraEditors.SimpleButton();
            this.btn5 = new DevExpress.XtraEditors.SimpleButton();
            this.btn9 = new DevExpress.XtraEditors.SimpleButton();
            this.btn4 = new DevExpress.XtraEditors.SimpleButton();
            this.btn3 = new DevExpress.XtraEditors.SimpleButton();
            this.btn2 = new DevExpress.XtraEditors.SimpleButton();
            this.btn1 = new DevExpress.XtraEditors.SimpleButton();
            this.btn0 = new DevExpress.XtraEditors.SimpleButton();
            this.txtWorkNumber = new DevExpress.XtraEditors.TextEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lbCaption = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPerson)).BeginInit();
            this.gcPerson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcWorkNumber)).BeginInit();
            this.gcWorkNumber.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.panelControl1.Controls.Add(this.sbClose);
            this.panelControl1.Controls.Add(this.sbtnStop);
            this.panelControl1.Controls.Add(this.sbtnStart);
            this.panelControl1.Controls.Add(this.gcPerson);
            this.panelControl1.Controls.Add(this.gcWorkNumber);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(623, 528);
            this.panelControl1.TabIndex = 0;
            // 
            // sbClose
            // 
            this.sbClose.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sbClose.Appearance.Options.UseFont = true;
            this.sbClose.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.sbClose.Location = new System.Drawing.Point(411, 461);
            this.sbClose.LookAndFeel.SkinName = "Office 2010 Black";
            this.sbClose.Name = "sbClose";
            this.sbClose.Size = new System.Drawing.Size(145, 54);
            this.sbClose.TabIndex = 15;
            this.sbClose.Text = "取消";
            this.sbClose.Click += new System.EventHandler(this.sbClose_Click);
            // 
            // sbtnStop
            // 
            this.sbtnStop.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sbtnStop.Appearance.Options.UseFont = true;
            this.sbtnStop.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.sbtnStop.Location = new System.Drawing.Point(239, 461);
            this.sbtnStop.LookAndFeel.SkinName = "Office 2010 Black";
            this.sbtnStop.Name = "sbtnStop";
            this.sbtnStop.Size = new System.Drawing.Size(145, 54);
            this.sbtnStop.TabIndex = 13;
            this.sbtnStop.Text = "结束巡守";
            this.sbtnStop.Click += new System.EventHandler(this.sbtnStop_Click);
            // 
            // sbtnStart
            // 
            this.sbtnStart.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sbtnStart.Appearance.Options.UseFont = true;
            this.sbtnStart.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.sbtnStart.Location = new System.Drawing.Point(67, 460);
            this.sbtnStart.LookAndFeel.SkinName = "Office 2010 Black";
            this.sbtnStart.Name = "sbtnStart";
            this.sbtnStart.Size = new System.Drawing.Size(145, 54);
            this.sbtnStart.TabIndex = 12;
            this.sbtnStart.Text = "派人巡守";
            this.sbtnStart.Click += new System.EventHandler(this.sbtnStart_Click);
            // 
            // gcPerson
            // 
            this.gcPerson.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gcPerson.AppearanceCaption.Options.UseFont = true;
            this.gcPerson.Controls.Add(this.radioGroupPerson);
            this.gcPerson.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcPerson.Location = new System.Drawing.Point(2, 239);
            this.gcPerson.Name = "gcPerson";
            this.gcPerson.Size = new System.Drawing.Size(619, 208);
            this.gcPerson.TabIndex = 11;
            this.gcPerson.Text = "巡守人员";
            // 
            // radioGroupPerson
            // 
            this.radioGroupPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroupPerson.Location = new System.Drawing.Point(2, 29);
            this.radioGroupPerson.Name = "radioGroupPerson";
            this.radioGroupPerson.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGroupPerson.Properties.Appearance.Options.UseFont = true;
            this.radioGroupPerson.Properties.Columns = 3;
            this.radioGroupPerson.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "李白"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "杜甫"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "白居易"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(),
            new DevExpress.XtraEditors.Controls.RadioGroupItem()});
            this.radioGroupPerson.Size = new System.Drawing.Size(615, 177);
            this.radioGroupPerson.TabIndex = 0;
            // 
            // gcWorkNumber
            // 
            this.gcWorkNumber.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gcWorkNumber.AppearanceCaption.Options.UseFont = true;
            this.gcWorkNumber.Controls.Add(this.sbtnNumberDel);
            this.gcWorkNumber.Controls.Add(this.btn8);
            this.gcWorkNumber.Controls.Add(this.btn7);
            this.gcWorkNumber.Controls.Add(this.btn6);
            this.gcWorkNumber.Controls.Add(this.btn5);
            this.gcWorkNumber.Controls.Add(this.btn9);
            this.gcWorkNumber.Controls.Add(this.btn4);
            this.gcWorkNumber.Controls.Add(this.btn3);
            this.gcWorkNumber.Controls.Add(this.btn2);
            this.gcWorkNumber.Controls.Add(this.btn1);
            this.gcWorkNumber.Controls.Add(this.btn0);
            this.gcWorkNumber.Controls.Add(this.txtWorkNumber);
            this.gcWorkNumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcWorkNumber.Location = new System.Drawing.Point(2, 44);
            this.gcWorkNumber.Name = "gcWorkNumber";
            this.gcWorkNumber.Size = new System.Drawing.Size(619, 195);
            this.gcWorkNumber.TabIndex = 10;
            this.gcWorkNumber.Text = "派工单";
            // 
            // sbtnNumberDel
            // 
            this.sbtnNumberDel.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sbtnNumberDel.Appearance.Options.UseFont = true;
            this.sbtnNumberDel.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.sbtnNumberDel.Location = new System.Drawing.Point(497, 92);
            this.sbtnNumberDel.LookAndFeel.SkinName = "Office 2010 Black";
            this.sbtnNumberDel.Name = "sbtnNumberDel";
            this.sbtnNumberDel.Size = new System.Drawing.Size(78, 90);
            this.sbtnNumberDel.TabIndex = 26;
            this.sbtnNumberDel.Text = "删除";
            this.sbtnNumberDel.Click += new System.EventHandler(this.sbtnNumberDel_Click);
            // 
            // btn8
            // 
            this.btn8.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn8.Appearance.Options.UseFont = true;
            this.btn8.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn8.Location = new System.Drawing.Point(317, 140);
            this.btn8.LookAndFeel.SkinName = "Office 2010 Black";
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(84, 42);
            this.btn8.TabIndex = 25;
            this.btn8.Text = "8";
            this.btn8.Click += new System.EventHandler(this.btnNumberClick);
            // 
            // btn7
            // 
            this.btn7.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn7.Appearance.Options.UseFont = true;
            this.btn7.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn7.Location = new System.Drawing.Point(227, 140);
            this.btn7.LookAndFeel.SkinName = "Office 2010 Black";
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(84, 42);
            this.btn7.TabIndex = 24;
            this.btn7.Text = "7";
            this.btn7.Click += new System.EventHandler(this.btnNumberClick);
            // 
            // btn6
            // 
            this.btn6.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn6.Appearance.Options.UseFont = true;
            this.btn6.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn6.Location = new System.Drawing.Point(137, 140);
            this.btn6.LookAndFeel.SkinName = "Office 2010 Black";
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(84, 42);
            this.btn6.TabIndex = 23;
            this.btn6.Text = "6";
            this.btn6.Click += new System.EventHandler(this.btnNumberClick);
            // 
            // btn5
            // 
            this.btn5.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn5.Appearance.Options.UseFont = true;
            this.btn5.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn5.Location = new System.Drawing.Point(46, 140);
            this.btn5.LookAndFeel.SkinName = "Office 2010 Black";
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(84, 42);
            this.btn5.TabIndex = 22;
            this.btn5.Text = "5";
            this.btn5.Click += new System.EventHandler(this.btnNumberClick);
            // 
            // btn9
            // 
            this.btn9.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn9.Appearance.Options.UseFont = true;
            this.btn9.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn9.Location = new System.Drawing.Point(405, 140);
            this.btn9.LookAndFeel.SkinName = "Office 2010 Black";
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(86, 42);
            this.btn9.TabIndex = 21;
            this.btn9.Text = "9";
            this.btn9.Click += new System.EventHandler(this.btnNumberClick);
            // 
            // btn4
            // 
            this.btn4.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn4.Appearance.Options.UseFont = true;
            this.btn4.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn4.Location = new System.Drawing.Point(407, 92);
            this.btn4.LookAndFeel.SkinName = "Office 2010 Black";
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(84, 42);
            this.btn4.TabIndex = 20;
            this.btn4.Text = "4";
            this.btn4.Click += new System.EventHandler(this.btnNumberClick);
            // 
            // btn3
            // 
            this.btn3.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn3.Appearance.Options.UseFont = true;
            this.btn3.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn3.Location = new System.Drawing.Point(317, 92);
            this.btn3.LookAndFeel.SkinName = "Office 2010 Black";
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(84, 42);
            this.btn3.TabIndex = 19;
            this.btn3.Text = "3";
            this.btn3.Click += new System.EventHandler(this.btnNumberClick);
            // 
            // btn2
            // 
            this.btn2.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn2.Appearance.Options.UseFont = true;
            this.btn2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn2.Location = new System.Drawing.Point(227, 92);
            this.btn2.LookAndFeel.SkinName = "Office 2010 Black";
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(84, 42);
            this.btn2.TabIndex = 18;
            this.btn2.Text = "2";
            this.btn2.Click += new System.EventHandler(this.btnNumberClick);
            // 
            // btn1
            // 
            this.btn1.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn1.Appearance.Options.UseFont = true;
            this.btn1.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn1.Location = new System.Drawing.Point(137, 92);
            this.btn1.LookAndFeel.SkinName = "Office 2010 Black";
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(84, 42);
            this.btn1.TabIndex = 17;
            this.btn1.Text = "1";
            this.btn1.Click += new System.EventHandler(this.btnNumberClick);
            // 
            // btn0
            // 
            this.btn0.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn0.Appearance.Options.UseFont = true;
            this.btn0.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn0.Location = new System.Drawing.Point(46, 92);
            this.btn0.LookAndFeel.SkinName = "Office 2010 Black";
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(84, 42);
            this.btn0.TabIndex = 16;
            this.btn0.Text = "0";
            this.btn0.Click += new System.EventHandler(this.btnNumberClick);
            // 
            // txtWorkNumber
            // 
            this.txtWorkNumber.EditValue = "";
            this.txtWorkNumber.Location = new System.Drawing.Point(46, 40);
            this.txtWorkNumber.Name = "txtWorkNumber";
            this.txtWorkNumber.Properties.AllowFocused = false;
            this.txtWorkNumber.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWorkNumber.Properties.Appearance.Options.UseFont = true;
            this.txtWorkNumber.Properties.AutoHeight = false;
            this.txtWorkNumber.Properties.NullText = "请在30分钟内填写派工单";
            this.txtWorkNumber.Size = new System.Drawing.Size(529, 46);
            this.txtWorkNumber.TabIndex = 9;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lbCaption);
            this.panelControl2.Controls.Add(this.pictureEdit1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(619, 42);
            this.panelControl2.TabIndex = 8;
            // 
            // lbCaption
            // 
            this.lbCaption.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCaption.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbCaption.Location = new System.Drawing.Point(10, 10);
            this.lbCaption.Name = "lbCaption";
            this.lbCaption.Size = new System.Drawing.Size(64, 22);
            this.lbCaption.TabIndex = 1;
            this.lbCaption.Text = "巡守操作";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(574, 2);
            this.pictureEdit1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.ZoomPercent = 50D;
            this.pictureEdit1.Size = new System.Drawing.Size(43, 38);
            this.pictureEdit1.TabIndex = 0;
            // 
            // frmInspertorManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 528);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmInspertorManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmInspertorManager";
            this.Deactivate += new System.EventHandler(this.frmInspertorManager_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInspertorManager_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPerson)).EndInit();
            this.gcPerson.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcWorkNumber)).EndInit();
            this.gcWorkNumber.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl lbCaption;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.GroupControl gcWorkNumber;
        private DevExpress.XtraEditors.TextEdit txtWorkNumber;
        private DevExpress.XtraEditors.GroupControl gcPerson;
        private DevExpress.XtraEditors.RadioGroup radioGroupPerson;
        private DevExpress.XtraEditors.SimpleButton sbClose;
        private DevExpress.XtraEditors.SimpleButton sbtnStop;
        private DevExpress.XtraEditors.SimpleButton sbtnStart;
        private DevExpress.XtraEditors.SimpleButton sbtnNumberDel;
        private DevExpress.XtraEditors.SimpleButton btn8;
        private DevExpress.XtraEditors.SimpleButton btn7;
        private DevExpress.XtraEditors.SimpleButton btn6;
        private DevExpress.XtraEditors.SimpleButton btn5;
        private DevExpress.XtraEditors.SimpleButton btn9;
        private DevExpress.XtraEditors.SimpleButton btn4;
        private DevExpress.XtraEditors.SimpleButton btn3;
        private DevExpress.XtraEditors.SimpleButton btn2;
        private DevExpress.XtraEditors.SimpleButton btn1;
        private DevExpress.XtraEditors.SimpleButton btn0;
    }
}