namespace rainfalls.App.AppSync
{
    partial class frmAppSync
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbErrChkdsk = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbUpdate = new System.Windows.Forms.Label();
            this.lbIntoSys = new System.Windows.Forms.Label();
            this.msgBox = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbErrChkdsk
            // 
            this.lbErrChkdsk.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lbErrChkdsk.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbErrChkdsk.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbErrChkdsk.ForeColor = System.Drawing.Color.White;
            this.lbErrChkdsk.Location = new System.Drawing.Point(293, 0);
            this.lbErrChkdsk.Name = "lbErrChkdsk";
            this.lbErrChkdsk.Size = new System.Drawing.Size(99, 56);
            this.lbErrChkdsk.TabIndex = 13;
            this.lbErrChkdsk.Text = "磁盘修复";
            this.lbErrChkdsk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbErrChkdsk.Click += new System.EventHandler(this.lbErrChkdsk_Click);
            // 
            // lbTime
            // 
            this.lbTime.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lbTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTime.ForeColor = System.Drawing.Color.White;
            this.lbTime.Location = new System.Drawing.Point(100, 0);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(193, 56);
            this.lbTime.TabIndex = 10;
            this.lbTime.Text = "2015-15-15 20:20:20";
            this.lbTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTime.Click += new System.EventHandler(this.lbTime_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(601, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // lbUpdate
            // 
            this.lbUpdate.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lbUpdate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbUpdate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbUpdate.ForeColor = System.Drawing.Color.Orange;
            this.lbUpdate.Location = new System.Drawing.Point(392, 0);
            this.lbUpdate.Name = "lbUpdate";
            this.lbUpdate.Size = new System.Drawing.Size(104, 56);
            this.lbUpdate.TabIndex = 14;
            this.lbUpdate.Text = "手动更新";
            this.lbUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbUpdate.Click += new System.EventHandler(this.lbUpdate_Click);
            // 
            // lbIntoSys
            // 
            this.lbIntoSys.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lbIntoSys.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbIntoSys.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbIntoSys.ForeColor = System.Drawing.Color.White;
            this.lbIntoSys.Location = new System.Drawing.Point(496, 0);
            this.lbIntoSys.Name = "lbIntoSys";
            this.lbIntoSys.Size = new System.Drawing.Size(105, 56);
            this.lbIntoSys.TabIndex = 11;
            this.lbIntoSys.Text = "进入系统";
            this.lbIntoSys.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbIntoSys.Click += new System.EventHandler(this.lbIntoSys_Click);
            // 
            // msgBox
            // 
            this.msgBox.BackColor = System.Drawing.Color.White;
            this.msgBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.msgBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.msgBox.FormattingEnabled = true;
            this.msgBox.ItemHeight = 20;
            this.msgBox.Location = new System.Drawing.Point(0, 135);
            this.msgBox.Name = "msgBox";
            this.msgBox.Size = new System.Drawing.Size(601, 164);
            this.msgBox.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbTime);
            this.panel1.Controls.Add(this.lbErrChkdsk);
            this.panel1.Controls.Add(this.lbUpdate);
            this.panel1.Controls.Add(this.lbIntoSys);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 299);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(601, 56);
            this.panel1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 56);
            this.label1.TabIndex = 15;
            this.label1.Text = "修改时间";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // frmAppSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 355);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.msgBox);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAppSync";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbErrChkdsk;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbUpdate;
        private System.Windows.Forms.Label lbIntoSys;
        private System.Windows.Forms.ListBox msgBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}

