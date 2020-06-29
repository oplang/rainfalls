namespace rainfalls.View.frmDateTime
{
    partial class frmDateTimeDlg
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
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.lbDay = new System.Windows.Forms.Label();
            this.lbMonth = new System.Windows.Forms.Label();
            this.lbYear = new System.Windows.Forms.Label();
            this.lbAddYear = new System.Windows.Forms.Label();
            this.lbAddMonth = new System.Windows.Forms.Label();
            this.lbAddDay = new System.Windows.Forms.Label();
            this.lbSubYear = new System.Windows.Forms.Label();
            this.lbSubMonth = new System.Windows.Forms.Label();
            this.lbSubDay = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(170, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 25);
            this.label8.TabIndex = 32;
            this.label8.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(88, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 25);
            this.label7.TabIndex = 31;
            this.label7.Text = "-";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.Black;
            this.btnOK.Location = new System.Drawing.Point(67, 157);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(137, 45);
            this.btnOK.TabIndex = 30;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lbDay
            // 
            this.lbDay.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDay.Location = new System.Drawing.Point(196, 62);
            this.lbDay.Name = "lbDay";
            this.lbDay.Size = new System.Drawing.Size(50, 25);
            this.lbDay.TabIndex = 29;
            this.lbDay.Text = "02";
            this.lbDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbMonth
            // 
            this.lbMonth.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMonth.Location = new System.Drawing.Point(114, 62);
            this.lbMonth.Name = "lbMonth";
            this.lbMonth.Size = new System.Drawing.Size(50, 25);
            this.lbMonth.TabIndex = 26;
            this.lbMonth.Text = "02";
            this.lbMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbYear
            // 
            this.lbYear.AutoSize = true;
            this.lbYear.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbYear.Location = new System.Drawing.Point(31, 63);
            this.lbYear.Name = "lbYear";
            this.lbYear.Size = new System.Drawing.Size(56, 25);
            this.lbYear.TabIndex = 23;
            this.lbYear.Text = "2015";
            // 
            // lbAddYear
            // 
            this.lbAddYear.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAddYear.Location = new System.Drawing.Point(34, 11);
            this.lbAddYear.Name = "lbAddYear";
            this.lbAddYear.Size = new System.Drawing.Size(48, 48);
            this.lbAddYear.TabIndex = 33;
            this.lbAddYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbAddYear.Click += new System.EventHandler(this.pbAddYear_Click);
            // 
            // lbAddMonth
            // 
            this.lbAddMonth.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddMonth.Location = new System.Drawing.Point(114, 11);
            this.lbAddMonth.Name = "lbAddMonth";
            this.lbAddMonth.Size = new System.Drawing.Size(48, 48);
            this.lbAddMonth.TabIndex = 34;
            this.lbAddMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbAddMonth.Click += new System.EventHandler(this.pbAddMonth_Click);
            // 
            // lbAddDay
            // 
            this.lbAddDay.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddDay.Location = new System.Drawing.Point(196, 11);
            this.lbAddDay.Name = "lbAddDay";
            this.lbAddDay.Size = new System.Drawing.Size(48, 48);
            this.lbAddDay.TabIndex = 35;
            this.lbAddDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbAddDay.Click += new System.EventHandler(this.pbAddDay_Click);
            // 
            // lbSubYear
            // 
            this.lbSubYear.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSubYear.Location = new System.Drawing.Point(34, 88);
            this.lbSubYear.Name = "lbSubYear";
            this.lbSubYear.Size = new System.Drawing.Size(48, 48);
            this.lbSubYear.TabIndex = 36;
            this.lbSubYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbSubYear.Click += new System.EventHandler(this.pbSubYear_Click);
            // 
            // lbSubMonth
            // 
            this.lbSubMonth.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSubMonth.Location = new System.Drawing.Point(114, 88);
            this.lbSubMonth.Name = "lbSubMonth";
            this.lbSubMonth.Size = new System.Drawing.Size(48, 48);
            this.lbSubMonth.TabIndex = 37;
            this.lbSubMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbSubMonth.Click += new System.EventHandler(this.pbSubMonth_Click);
            // 
            // lbSubDay
            // 
            this.lbSubDay.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSubDay.Location = new System.Drawing.Point(196, 88);
            this.lbSubDay.Name = "lbSubDay";
            this.lbSubDay.Size = new System.Drawing.Size(48, 48);
            this.lbSubDay.TabIndex = 38;
            this.lbSubDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbSubDay.Click += new System.EventHandler(this.pbSubDay_Click);
            // 
            // frmDateTimeDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 250);
            this.ControlBox = false;
            this.Controls.Add(this.lbSubDay);
            this.Controls.Add(this.lbSubMonth);
            this.Controls.Add(this.lbSubYear);
            this.Controls.Add(this.lbAddDay);
            this.Controls.Add(this.lbAddMonth);
            this.Controls.Add(this.lbAddYear);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbDay);
            this.Controls.Add(this.lbMonth);
            this.Controls.Add(this.lbYear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDateTimeDlg";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "日期";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmDateTimeDlg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lbDay;
        private System.Windows.Forms.Label lbMonth;
        private System.Windows.Forms.Label lbYear;
        private System.Windows.Forms.Label lbAddMonth;
        private System.Windows.Forms.Label lbAddDay;
        private System.Windows.Forms.Label lbSubYear;
        private System.Windows.Forms.Label lbSubMonth;
        private System.Windows.Forms.Label lbSubDay;
        private System.Windows.Forms.Label lbAddYear;
    }
}