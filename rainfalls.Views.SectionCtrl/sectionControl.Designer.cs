namespace rainfalls.Views.SectionCtrl
{
    partial class sectionControl
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
            this.leftPanel = new System.Windows.Forms.Panel();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.picPerson = new System.Windows.Forms.PictureBox();
            this.siteCtrl = new rainfalls.Views.SiteCtrl.siteControl();
            ((System.ComponentModel.ISupportInitialize)(this.picPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.White;
            this.leftPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leftPanel.Location = new System.Drawing.Point(38, 46);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(30, 14);
            this.leftPanel.TabIndex = 1;
            // 
            // rightPanel
            // 
            this.rightPanel.BackColor = System.Drawing.Color.Black;
            this.rightPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rightPanel.Location = new System.Drawing.Point(68, 46);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(32, 14);
            this.rightPanel.TabIndex = 2;
            // 
            // picPerson
            // 
            this.picPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPerson.Image = global::rainfalls.Views.SectionCtrl.Properties.Resources.head;
            this.picPerson.Location = new System.Drawing.Point(50, 8);
            this.picPerson.Name = "picPerson";
            this.picPerson.Size = new System.Drawing.Size(32, 32);
            this.picPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picPerson.TabIndex = 47;
            this.picPerson.TabStop = false;
            this.picPerson.Visible = false;
            // 
            // siteCtrl
            // 
            this.siteCtrl.IsTopShow = false;
            this.siteCtrl.Location = new System.Drawing.Point(0, 0);
            this.siteCtrl.Name = "siteCtrl";
            this.siteCtrl.SiteName = null;
            this.siteCtrl.Size = new System.Drawing.Size(80, 100);
            this.siteCtrl.TabIndex = 3;
            // 
            // sectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picPerson);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.siteCtrl);
            this.Name = "sectionControl";
            this.Size = new System.Drawing.Size(100, 100);
            ((System.ComponentModel.ISupportInitialize)(this.picPerson)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel rightPanel;
        private SiteCtrl.siteControl siteCtrl;
        private System.Windows.Forms.PictureBox picPerson;

    }
}
