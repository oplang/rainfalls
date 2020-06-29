namespace rainfalls.View.frmReg
{
    partial class frmRegDlg
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
            this.btnOk = new System.Windows.Forms.Button();
            this.labShould = new System.Windows.Forms.Label();
            this.labReason = new System.Windows.Forms.Label();
            this.labStaticPerson = new System.Windows.Forms.Label();
            this.labStaticShould = new System.Windows.Forms.Label();
            this.labStaticReason = new System.Windows.Forms.Label();
            this.labPerson = new System.Windows.Forms.Label();
            this.lbKm = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.lbTimeCaption = new System.Windows.Forms.Label();
            this.groupCtrl = new DevExpress.XtraEditors.GroupControl();
            this.dropDownButton1 = new DevExpress.XtraEditors.DropDownButton();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.checkButton1 = new DevExpress.XtraEditors.CheckButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupCtrl)).BeginInit();
            this.groupCtrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(207, 245);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(199, 45);
            this.btnOk.TabIndex = 15;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // labShould
            // 
            this.labShould.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labShould.ForeColor = System.Drawing.Color.Black;
            this.labShould.Location = new System.Drawing.Point(128, 104);
            this.labShould.Name = "labShould";
            this.labShould.Size = new System.Drawing.Size(366, 20);
            this.labShould.TabIndex = 13;
            this.labShould.Text = "登记运统46,限速行车";
            // 
            // labReason
            // 
            this.labReason.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labReason.ForeColor = System.Drawing.Color.Black;
            this.labReason.Location = new System.Drawing.Point(128, 53);
            this.labReason.Name = "labReason";
            this.labReason.Size = new System.Drawing.Size(463, 45);
            this.labReason.TabIndex = 12;
            this.labReason.Text = "12月15日05:30-12月15日06:30降雨量增加30mm已达到限速运行标准";
            // 
            // labStaticPerson
            // 
            this.labStaticPerson.AutoSize = true;
            this.labStaticPerson.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labStaticPerson.ForeColor = System.Drawing.Color.Chocolate;
            this.labStaticPerson.Location = new System.Drawing.Point(29, 200);
            this.labStaticPerson.Name = "labStaticPerson";
            this.labStaticPerson.Size = new System.Drawing.Size(99, 19);
            this.labStaticPerson.TabIndex = 11;
            this.labStaticPerson.Text = "防洪负责人：";
            // 
            // labStaticShould
            // 
            this.labStaticShould.AutoSize = true;
            this.labStaticShould.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labStaticShould.ForeColor = System.Drawing.Color.Chocolate;
            this.labStaticShould.Location = new System.Drawing.Point(43, 104);
            this.labStaticShould.Name = "labStaticShould";
            this.labStaticShould.Size = new System.Drawing.Size(84, 19);
            this.labStaticShould.TabIndex = 10;
            this.labStaticShould.Text = "建议措施：";
            // 
            // labStaticReason
            // 
            this.labStaticReason.AutoSize = true;
            this.labStaticReason.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labStaticReason.ForeColor = System.Drawing.Color.Chocolate;
            this.labStaticReason.Location = new System.Drawing.Point(43, 53);
            this.labStaticReason.Name = "labStaticReason";
            this.labStaticReason.Size = new System.Drawing.Size(84, 19);
            this.labStaticReason.TabIndex = 9;
            this.labStaticReason.Text = "报警原因：";
            // 
            // labPerson
            // 
            this.labPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labPerson.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPerson.ForeColor = System.Drawing.Color.DarkGreen;
            this.labPerson.Location = new System.Drawing.Point(128, 183);
            this.labPerson.Name = "labPerson";
            this.labPerson.Size = new System.Drawing.Size(101, 53);
            this.labPerson.TabIndex = 14;
            this.labPerson.Text = "单击选择";
            this.labPerson.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labPerson.Click += new System.EventHandler(this.labPerson_Click);
            // 
            // lbKm
            // 
            this.lbKm.AutoSize = true;
            this.lbKm.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbKm.ForeColor = System.Drawing.Color.Red;
            this.lbKm.Location = new System.Drawing.Point(132, 9);
            this.lbKm.Name = "lbKm";
            this.lbKm.Size = new System.Drawing.Size(16, 19);
            this.lbKm.TabIndex = 36;
            this.lbKm.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Chocolate;
            this.label3.Location = new System.Drawing.Point(44, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 19);
            this.label3.TabIndex = 35;
            this.label3.Text = "报警区间：";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTime.ForeColor = System.Drawing.Color.Black;
            this.lbTime.Location = new System.Drawing.Point(128, 150);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(161, 19);
            this.lbTime.TabIndex = 38;
            this.lbTime.Text = "2012-12-12 05:00:00";
            // 
            // lbTimeCaption
            // 
            this.lbTimeCaption.AutoSize = true;
            this.lbTimeCaption.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTimeCaption.ForeColor = System.Drawing.Color.Chocolate;
            this.lbTimeCaption.Location = new System.Drawing.Point(14, 150);
            this.lbTimeCaption.Name = "lbTimeCaption";
            this.lbTimeCaption.Size = new System.Drawing.Size(84, 19);
            this.lbTimeCaption.TabIndex = 37;
            this.lbTimeCaption.Text = "开始时间：";
            // 
            // groupCtrl
            // 
            this.groupCtrl.Controls.Add(this.dropDownButton1);
            this.groupCtrl.Location = new System.Drawing.Point(567, 169);
            this.groupCtrl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupCtrl.Name = "groupCtrl";
            this.groupCtrl.Size = new System.Drawing.Size(536, 197);
            this.groupCtrl.TabIndex = 39;
            this.groupCtrl.Text = "区间";
            // 
            // dropDownButton1
            // 
            this.dropDownButton1.Location = new System.Drawing.Point(81, 137);
            this.dropDownButton1.Name = "dropDownButton1";
            this.dropDownButton1.Size = new System.Drawing.Size(158, 35);
            this.dropDownButton1.TabIndex = 0;
            this.dropDownButton1.Text = "dropDownButton1";
            this.dropDownButton1.Click += new System.EventHandler(this.dropDownButton1_Click);
            // 
            // popupMenu1
            // 
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.MaxItemId = 0;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1173, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 524);
            this.barDockControlBottom.Size = new System.Drawing.Size(1173, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 524);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1173, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 524);
            // 
            // checkButton1
            // 
            this.checkButton1.Location = new System.Drawing.Point(365, 374);
            this.checkButton1.Name = "checkButton1";
            this.checkButton1.Size = new System.Drawing.Size(129, 44);
            this.checkButton1.TabIndex = 44;
            this.checkButton1.Text = "checkButton1";
            // 
            // frmRegDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 524);
            this.ControlBox = false;
            this.Controls.Add(this.checkButton1);
            this.Controls.Add(this.groupCtrl);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.lbTimeCaption);
            this.Controls.Add(this.lbKm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.labShould);
            this.Controls.Add(this.labReason);
            this.Controls.Add(this.labStaticPerson);
            this.Controls.Add(this.labStaticShould);
            this.Controls.Add(this.labStaticReason);
            this.Controls.Add(this.labPerson);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegDlg";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "防洪措施/行车措施";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.groupCtrl)).EndInit();
            this.groupCtrl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label labShould;
        private System.Windows.Forms.Label labReason;
        private System.Windows.Forms.Label labStaticPerson;
        private System.Windows.Forms.Label labStaticShould;
        private System.Windows.Forms.Label labStaticReason;
        private System.Windows.Forms.Label labPerson;
        private System.Windows.Forms.Label lbKm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Label lbTimeCaption;
        private DevExpress.XtraEditors.GroupControl groupCtrl;
        private DevExpress.XtraEditors.DropDownButton dropDownButton1;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.CheckButton checkButton1;
    }
}