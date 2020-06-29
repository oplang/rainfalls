namespace rainfalls.View.RainMapCaption
{
    partial class captionCtrl
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
                m_pSoftUpdate.STOPAUTOUPDATE();
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
            this.lbAnyTime = new System.Windows.Forms.Label();
            this.lbToday = new System.Windows.Forms.Label();
            this.lbNextDay = new System.Windows.Forms.Label();
            this.lbPreDay = new System.Windows.Forms.Label();
            this.lbRainLog = new System.Windows.Forms.Label();
            this.lbDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbAnyTime
            // 
            this.lbAnyTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbAnyTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbAnyTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbAnyTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAnyTime.Location = new System.Drawing.Point(949, 2);
            this.lbAnyTime.Name = "lbAnyTime";
            this.lbAnyTime.Size = new System.Drawing.Size(114, 28);
            this.lbAnyTime.TabIndex = 1;
            this.lbAnyTime.Text = "指定";
            this.lbAnyTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbAnyTime.Click += new System.EventHandler(this.lbAnyTime_Click);
            this.lbAnyTime.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.lbAnyTime.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            // 
            // lbToday
            // 
            this.lbToday.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbToday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbToday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbToday.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbToday.Location = new System.Drawing.Point(835, 2);
            this.lbToday.Name = "lbToday";
            this.lbToday.Size = new System.Drawing.Size(114, 28);
            this.lbToday.TabIndex = 2;
            this.lbToday.Text = "今天";
            this.lbToday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbToday.Click += new System.EventHandler(this.lbToday_Click);
            this.lbToday.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.lbToday.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            // 
            // lbNextDay
            // 
            this.lbNextDay.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbNextDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbNextDay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbNextDay.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbNextDay.Location = new System.Drawing.Point(721, 2);
            this.lbNextDay.Name = "lbNextDay";
            this.lbNextDay.Size = new System.Drawing.Size(114, 28);
            this.lbNextDay.TabIndex = 3;
            this.lbNextDay.Text = "后一天";
            this.lbNextDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbNextDay.Click += new System.EventHandler(this.lbNextDay_Click);
            this.lbNextDay.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.lbNextDay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            // 
            // lbPreDay
            // 
            this.lbPreDay.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbPreDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPreDay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbPreDay.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPreDay.Location = new System.Drawing.Point(607, 2);
            this.lbPreDay.Name = "lbPreDay";
            this.lbPreDay.Size = new System.Drawing.Size(114, 28);
            this.lbPreDay.TabIndex = 4;
            this.lbPreDay.Text = "前一天";
            this.lbPreDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbPreDay.Click += new System.EventHandler(this.lbPreDay_Click);
            this.lbPreDay.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.lbPreDay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            // 
            // lbRainLog
            // 
            this.lbRainLog.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbRainLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbRainLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbRainLog.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbRainLog.Location = new System.Drawing.Point(493, 2);
            this.lbRainLog.Name = "lbRainLog";
            this.lbRainLog.Size = new System.Drawing.Size(114, 28);
            this.lbRainLog.TabIndex = 7;
            this.lbRainLog.Text = "雨量日志";
            this.lbRainLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbRainLog.Click += new System.EventHandler(this.lbRainLog_Click);
            // 
            // lbDate
            // 
            this.lbDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbDate.AutoSize = true;
            this.lbDate.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDate.ForeColor = System.Drawing.Color.Maroon;
            this.lbDate.Location = new System.Drawing.Point(25, 7);
            this.lbDate.Margin = new System.Windows.Forms.Padding(30, 0, 3, 0);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(19, 15);
            this.lbDate.TabIndex = 5;
            this.lbDate.Text = "....";
            this.lbDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // captionCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbRainLog);
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.lbPreDay);
            this.Controls.Add(this.lbNextDay);
            this.Controls.Add(this.lbToday);
            this.Controls.Add(this.lbAnyTime);
            this.Name = "captionCtrl";
            this.Size = new System.Drawing.Size(1088, 30);
            this.Load += new System.EventHandler(this.captionCtrl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbAnyTime;
        private System.Windows.Forms.Label lbToday;
        private System.Windows.Forms.Label lbNextDay;
        private System.Windows.Forms.Label lbPreDay;
        private System.Windows.Forms.Label lbRainLog;
        private System.Windows.Forms.Label lbDate;
    }
}
