namespace rainfalls.View.Toolbar
{
    partial class rainfallsToolBar
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
            this.lbPerson = new System.Windows.Forms.Label();
            this.lbOpen = new System.Windows.Forms.Label();
            this.lbConfig = new System.Windows.Forms.Label();
            this.lbTest = new System.Windows.Forms.Label();
            this.lbShutDown = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbPerson
            // 
            this.lbPerson.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbPerson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPerson.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPerson.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbPerson.Location = new System.Drawing.Point(263, 0);
            this.lbPerson.Name = "lbPerson";
            this.lbPerson.Size = new System.Drawing.Size(140, 40);
            this.lbPerson.TabIndex = 0;
            this.lbPerson.Text = "值班负责人:赵永峰";
            this.lbPerson.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbPerson.Visible = false;
            this.lbPerson.Click += new System.EventHandler(this.lbLog_Click);
            // 
            // lbOpen
            // 
            this.lbOpen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbOpen.BackColor = System.Drawing.Color.White;
            this.lbOpen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbOpen.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbOpen.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbOpen.Location = new System.Drawing.Point(409, 0);
            this.lbOpen.Name = "lbOpen";
            this.lbOpen.Size = new System.Drawing.Size(140, 40);
            this.lbOpen.TabIndex = 1;
            this.lbOpen.Text = "措施日志";
            this.lbOpen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbOpen.Visible = false;
            this.lbOpen.Click += new System.EventHandler(this.lbOpen_Click);
            // 
            // lbConfig
            // 
            this.lbConfig.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbConfig.BackColor = System.Drawing.Color.White;
            this.lbConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbConfig.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbConfig.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbConfig.Location = new System.Drawing.Point(555, 0);
            this.lbConfig.Name = "lbConfig";
            this.lbConfig.Size = new System.Drawing.Size(140, 40);
            this.lbConfig.TabIndex = 2;
            this.lbConfig.Text = "用户信息";
            this.lbConfig.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbConfig.Visible = false;
            this.lbConfig.Click += new System.EventHandler(this.lbConfig_Click);
            // 
            // lbTest
            // 
            this.lbTest.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbTest.BackColor = System.Drawing.Color.White;
            this.lbTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTest.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTest.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbTest.Location = new System.Drawing.Point(701, 0);
            this.lbTest.Name = "lbTest";
            this.lbTest.Size = new System.Drawing.Size(140, 40);
            this.lbTest.TabIndex = 3;
            this.lbTest.Text = "本地测试";
            this.lbTest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTest.Visible = false;
            this.lbTest.Click += new System.EventHandler(this.lbTest_Click);
            // 
            // lbShutDown
            // 
            this.lbShutDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbShutDown.BackColor = System.Drawing.Color.White;
            this.lbShutDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbShutDown.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbShutDown.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbShutDown.Location = new System.Drawing.Point(847, 0);
            this.lbShutDown.Name = "lbShutDown";
            this.lbShutDown.Size = new System.Drawing.Size(140, 40);
            this.lbShutDown.TabIndex = 4;
            this.lbShutDown.Text = "工具";
            this.lbShutDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbShutDown.Click += new System.EventHandler(this.lbShutDown_Click);
            // 
            // rainfallsToolBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbShutDown);
            this.Controls.Add(this.lbTest);
            this.Controls.Add(this.lbConfig);
            this.Controls.Add(this.lbOpen);
            this.Controls.Add(this.lbPerson);
            this.Name = "rainfallsToolBar";
            this.Size = new System.Drawing.Size(1251, 40);
            this.Load += new System.EventHandler(this.rainfallsToolBar_Load);
            this.SizeChanged += new System.EventHandler(this.rainfallsToolBar_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbPerson;
        private System.Windows.Forms.Label lbOpen;
        private System.Windows.Forms.Label lbConfig;
        private System.Windows.Forms.Label lbTest;
        private System.Windows.Forms.Label lbShutDown;

    }
}
