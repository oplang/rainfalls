namespace Rainfall.App.AppSync
{
    partial class Form_Main
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
            this.components = new System.ComponentModel.Container();
            this.msgBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbIntoSys = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbModifyDateTime = new System.Windows.Forms.Label();
            this.lbErrChkdsk = new System.Windows.Forms.Label();
            this.lbUpdate = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // msgBox
            // 
            this.msgBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.msgBox.FormattingEnabled = true;
            this.msgBox.ItemHeight = 17;
            this.msgBox.Location = new System.Drawing.Point(2, 129);
            this.msgBox.Name = "msgBox";
            this.msgBox.Size = new System.Drawing.Size(600, 106);
            this.msgBox.TabIndex = 1;
            this.msgBox.SelectedIndexChanged += new System.EventHandler(this.msgBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(2, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 60);
            this.label1.TabIndex = 3;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbIntoSys
            // 
            this.lbIntoSys.BackColor = System.Drawing.Color.Black;
            this.lbIntoSys.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbIntoSys.ForeColor = System.Drawing.Color.White;
            this.lbIntoSys.Location = new System.Drawing.Point(504, 243);
            this.lbIntoSys.Name = "lbIntoSys";
            this.lbIntoSys.Size = new System.Drawing.Size(98, 60);
            this.lbIntoSys.TabIndex = 4;
            this.lbIntoSys.Text = "进入系统";
            this.lbIntoSys.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbIntoSys.Click += new System.EventHandler(this.lbIntoSys_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbModifyDateTime
            // 
            this.lbModifyDateTime.BackColor = System.Drawing.Color.Black;
            this.lbModifyDateTime.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lbModifyDateTime.ForeColor = System.Drawing.Color.White;
            this.lbModifyDateTime.Location = new System.Drawing.Point(218, 243);
            this.lbModifyDateTime.Name = "lbModifyDateTime";
            this.lbModifyDateTime.Size = new System.Drawing.Size(97, 60);
            this.lbModifyDateTime.TabIndex = 5;
            this.lbModifyDateTime.Text = "修改时间";
            this.lbModifyDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbModifyDateTime.Click += new System.EventHandler(this.lbModifyDateTime_Click);
            // 
            // lbErrChkdsk
            // 
            this.lbErrChkdsk.BackColor = System.Drawing.Color.Black;
            this.lbErrChkdsk.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbErrChkdsk.ForeColor = System.Drawing.Color.White;
            this.lbErrChkdsk.Location = new System.Drawing.Point(412, 243);
            this.lbErrChkdsk.Name = "lbErrChkdsk";
            this.lbErrChkdsk.Size = new System.Drawing.Size(92, 60);
            this.lbErrChkdsk.TabIndex = 6;
            this.lbErrChkdsk.Text = "磁盘修复";
            this.lbErrChkdsk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbErrChkdsk.Click += new System.EventHandler(this.lbErrChkdsk_Click);
            // 
            // lbUpdate
            // 
            this.lbUpdate.BackColor = System.Drawing.Color.Black;
            this.lbUpdate.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lbUpdate.ForeColor = System.Drawing.Color.Yellow;
            this.lbUpdate.Location = new System.Drawing.Point(315, 243);
            this.lbUpdate.Name = "lbUpdate";
            this.lbUpdate.Size = new System.Drawing.Size(97, 60);
            this.lbUpdate.TabIndex = 7;
            this.lbUpdate.Text = "手动更新";
            this.lbUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbUpdate.Click += new System.EventHandler(this.lbUpdate_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(2, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(605, 306);
            this.ControlBox = false;
            this.Controls.Add(this.lbUpdate);
            this.Controls.Add(this.lbErrChkdsk);
            this.Controls.Add(this.lbModifyDateTime);
            this.Controls.Add(this.lbIntoSys);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.msgBox);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Main_FormClosed);
            this.Load += new System.EventHandler(this.Form_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox msgBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbIntoSys;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbModifyDateTime;
        private System.Windows.Forms.Label lbErrChkdsk;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbUpdate;
    }
}