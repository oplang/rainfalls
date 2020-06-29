namespace rainfalls.View.Site
{
    partial class siteCtrl
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
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.line2 = new DevComponents.DotNetBar.Controls.Line();
            this.lbKm = new System.Windows.Forms.Label();
            this.lbCont = new System.Windows.Forms.Label();
            this.lb1H = new System.Windows.Forms.Label();
            this.lb3H = new System.Windows.Forms.Label();
            this.lbStatu = new System.Windows.Forms.Label();
            this.lbSiteName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // line1
            // 
            this.line1.Location = new System.Drawing.Point(29, 14);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(108, 23);
            this.line1.TabIndex = 0;
            this.line1.Text = "line1";
            // 
            // line2
            // 
            this.line2.Location = new System.Drawing.Point(65, 26);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(24, 111);
            this.line2.TabIndex = 1;
            this.line2.Text = "line2";
            this.line2.VerticalLine = true;
            // 
            // lbKm
            // 
            this.lbKm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbKm.Location = new System.Drawing.Point(29, 0);
            this.lbKm.Name = "lbKm";
            this.lbKm.Size = new System.Drawing.Size(108, 23);
            this.lbKm.TabIndex = 2;
            this.lbKm.Text = "K256+230";
            this.lbKm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCont
            // 
            this.lbCont.AutoSize = true;
            this.lbCont.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCont.Location = new System.Drawing.Point(84, 40);
            this.lbCont.Name = "lbCont";
            this.lbCont.Size = new System.Drawing.Size(114, 20);
            this.lbCont.TabIndex = 3;
            this.lbCont.Text = "连续    120.5mm";
            // 
            // lb1H
            // 
            this.lb1H.AutoSize = true;
            this.lb1H.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb1H.Location = new System.Drawing.Point(84, 64);
            this.lb1H.Name = "lb1H";
            this.lb1H.Size = new System.Drawing.Size(106, 20);
            this.lb1H.TabIndex = 4;
            this.lb1H.Text = "1小时  92.5mm";
            // 
            // lb3H
            // 
            this.lb3H.AutoSize = true;
            this.lb3H.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb3H.Location = new System.Drawing.Point(84, 88);
            this.lb3H.Name = "lb3H";
            this.lb3H.Size = new System.Drawing.Size(106, 20);
            this.lb3H.TabIndex = 5;
            this.lb3H.Text = "3小时  95.5mm";
            // 
            // lbStatu
            // 
            this.lbStatu.AutoSize = true;
            this.lbStatu.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbStatu.Location = new System.Drawing.Point(84, 112);
            this.lbStatu.Name = "lbStatu";
            this.lbStatu.Size = new System.Drawing.Size(81, 20);
            this.lbStatu.TabIndex = 6;
            this.lbStatu.Text = "状态    正常";
            // 
            // lbSiteName
            // 
            this.lbSiteName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSiteName.Location = new System.Drawing.Point(-4, 112);
            this.lbSiteName.Name = "lbSiteName";
            this.lbSiteName.Size = new System.Drawing.Size(81, 20);
            this.lbSiteName.TabIndex = 7;
            this.lbSiteName.Text = "西安南站";
            this.lbSiteName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SiteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbSiteName);
            this.Controls.Add(this.lbStatu);
            this.Controls.Add(this.lb3H);
            this.Controls.Add(this.lb1H);
            this.Controls.Add(this.lbCont);
            this.Controls.Add(this.lbKm);
            this.Controls.Add(this.line2);
            this.Controls.Add(this.line1);
            this.Name = "SiteControl";
            this.Size = new System.Drawing.Size(209, 137);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SiteControl_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.Line line1;
        private DevComponents.DotNetBar.Controls.Line line2;
        private System.Windows.Forms.Label lbKm;
        private System.Windows.Forms.Label lbCont;
        private System.Windows.Forms.Label lb1H;
        private System.Windows.Forms.Label lb3H;
        private System.Windows.Forms.Label lbStatu;
        private System.Windows.Forms.Label lbSiteName;
    }
}
