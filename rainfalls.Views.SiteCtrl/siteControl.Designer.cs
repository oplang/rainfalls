namespace rainfalls.Views.SiteCtrl
{
    partial class siteControl
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
            this.lineBottomH = new DevComponents.DotNetBar.Controls.Line();
            this.lineTopH = new DevComponents.DotNetBar.Controls.Line();
            this.topSiteName = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip();
            this.lineTopV = new DevComponents.DotNetBar.Controls.Line();
            this.lineBottomV = new DevComponents.DotNetBar.Controls.Line();
            this.picSite = new System.Windows.Forms.PictureBox();
            this.bottomSiteName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picSite)).BeginInit();
            this.SuspendLayout();
            // 
            // lineBottomH
            // 
            this.lineBottomH.AutoSize = true;
            this.lineBottomH.Location = new System.Drawing.Point(0, 82);
            this.lineBottomH.Name = "lineBottomH";
            this.lineBottomH.Size = new System.Drawing.Size(35, 1);
            this.lineBottomH.TabIndex = 43;
            this.lineBottomH.Text = "line2";
            // 
            // lineTopH
            // 
            this.lineTopH.AutoSize = true;
            this.lineTopH.Location = new System.Drawing.Point(0, 20);
            this.lineTopH.Name = "lineTopH";
            this.lineTopH.Size = new System.Drawing.Size(35, 1);
            this.lineTopH.TabIndex = 42;
            this.lineTopH.Text = "line1";
            // 
            // topSiteName
            // 
            this.topSiteName.Dock = System.Windows.Forms.DockStyle.Top;
            this.topSiteName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.topSiteName.Location = new System.Drawing.Point(0, 0);
            this.topSiteName.Name = "topSiteName";
            this.topSiteName.Size = new System.Drawing.Size(80, 17);
            this.topSiteName.TabIndex = 40;
            this.topSiteName.Text = "达维测试站点";
            this.topSiteName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ShowAlways = true;
            // 
            // lineTopV
            // 
            this.lineTopV.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            this.lineTopV.EndLineCap = DevComponents.DotNetBar.Controls.eLineEndType.Rectangle;
            this.lineTopV.Location = new System.Drawing.Point(16, 21);
            this.lineTopV.Name = "lineTopV";
            this.lineTopV.Size = new System.Drawing.Size(1, 20);
            this.lineTopV.StartLineCap = DevComponents.DotNetBar.Controls.eLineEndType.Rectangle;
            this.lineTopV.TabIndex = 44;
            this.lineTopV.Text = "line3";
            this.lineTopV.VerticalLine = true;
            // 
            // lineBottomV
            // 
            this.lineBottomV.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.lineBottomV.EndLineCap = DevComponents.DotNetBar.Controls.eLineEndType.Diamond;
            this.lineBottomV.Location = new System.Drawing.Point(16, 63);
            this.lineBottomV.Name = "lineBottomV";
            this.lineBottomV.Size = new System.Drawing.Size(1, 20);
            this.lineBottomV.StartLineCap = DevComponents.DotNetBar.Controls.eLineEndType.Rectangle;
            this.lineBottomV.TabIndex = 45;
            this.lineBottomV.Text = "line4";
            this.lineBottomV.VerticalLine = true;
            // 
            // picSite
            // 
            this.picSite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSite.Image = global::rainfalls.Views.SiteCtrl.Properties.Resources.no_rain;
            this.picSite.Location = new System.Drawing.Point(0, 34);
            this.picSite.Name = "picSite";
            this.picSite.Size = new System.Drawing.Size(32, 32);
            this.picSite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSite.TabIndex = 46;
            this.picSite.TabStop = false;
            // 
            // bottomSiteName
            // 
            this.bottomSiteName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomSiteName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bottomSiteName.Location = new System.Drawing.Point(0, 83);
            this.bottomSiteName.Name = "bottomSiteName";
            this.bottomSiteName.Size = new System.Drawing.Size(80, 17);
            this.bottomSiteName.TabIndex = 47;
            this.bottomSiteName.Text = "达维测试站点";
            this.bottomSiteName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // siteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bottomSiteName);
            this.Controls.Add(this.picSite);
            this.Controls.Add(this.lineBottomH);
            this.Controls.Add(this.lineTopH);
            this.Controls.Add(this.topSiteName);
            this.Controls.Add(this.lineTopV);
            this.Controls.Add(this.lineBottomV);
            this.Name = "siteControl";
            this.Size = new System.Drawing.Size(80, 100);
            ((System.ComponentModel.ISupportInitialize)(this.picSite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.Line lineBottomH;
        private DevComponents.DotNetBar.Controls.Line lineTopH;
        private System.Windows.Forms.Label topSiteName;
        private System.Windows.Forms.ToolTip toolTip1;
        private DevComponents.DotNetBar.Controls.Line lineTopV;
        private DevComponents.DotNetBar.Controls.Line lineBottomV;
        private System.Windows.Forms.PictureBox picSite;
        private System.Windows.Forms.Label bottomSiteName;

    }
}
