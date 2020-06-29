namespace rainfalls.View.SectionCtrl
{
    partial class sectionCtrl
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
            this.toolTip1 = new System.Windows.Forms.ToolTip();
            this.plSection = new rainfalls.View.SectionCtrl.panelCls();
            this.lbLiftLevel = new System.Windows.Forms.Label();
            this.lbLevel = new System.Windows.Forms.Label();
            this.plSection.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // plSection
            // 
            this.plSection.Controls.Add(this.lbLiftLevel);
            this.plSection.Controls.Add(this.lbLevel);
            this.plSection.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plSection.Location = new System.Drawing.Point(0, 1);
            this.plSection.Name = "plSection";
            this.plSection.Size = new System.Drawing.Size(351, 37);
            this.plSection.TabIndex = 0;
            // 
            // lbLiftLevel
            // 
            this.lbLiftLevel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbLiftLevel.BackColor = System.Drawing.Color.ForestGreen;
            this.lbLiftLevel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbLiftLevel.ForeColor = System.Drawing.Color.FloralWhite;
            this.lbLiftLevel.Location = new System.Drawing.Point(234, 1);
            this.lbLiftLevel.Name = "lbLiftLevel";
            this.lbLiftLevel.Size = new System.Drawing.Size(115, 35);
            this.lbLiftLevel.TabIndex = 4;
            this.lbLiftLevel.Text = "单击解除";
            this.lbLiftLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbLiftLevel.Visible = false;
            this.lbLiftLevel.Click += new System.EventHandler(this.lbLiftLevel_Click);
            // 
            // lbLevel
            // 
            this.lbLevel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbLevel.AutoSize = true;
            this.lbLevel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbLevel.Location = new System.Drawing.Point(9, 8);
            this.lbLevel.Name = "lbLevel";
            this.lbLevel.Size = new System.Drawing.Size(218, 20);
            this.lbLevel.TabIndex = 1;
            this.lbLevel.Text = "\"区间:测试站A1-Q1   警戒:{正常}\"";
            // 
            // sectionCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.plSection);
            this.Name = "sectionCtrl";
            this.Size = new System.Drawing.Size(351, 38);
            this.Load += new System.EventHandler(this.sectionCtrl_Load);
            this.plSection.ResumeLayout(false);
            this.plSection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private panelCls plSection;
        private System.Windows.Forms.Label lbLevel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbLiftLevel;

    }
}
