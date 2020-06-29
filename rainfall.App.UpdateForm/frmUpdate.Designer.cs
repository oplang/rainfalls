namespace rainfall.App.UpdateForm
{
    partial class frmUpdate
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
            this.m_pBarProcess = new System.Windows.Forms.ProgressBar();
            this.m_pBtnUpdate = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_pLableMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // m_pBarProcess
            // 
            this.m_pBarProcess.Location = new System.Drawing.Point(12, 95);
            this.m_pBarProcess.Name = "m_pBarProcess";
            this.m_pBarProcess.Size = new System.Drawing.Size(301, 14);
            this.m_pBarProcess.TabIndex = 8;
            // 
            // m_pBtnUpdate
            // 
            this.m_pBtnUpdate.Enabled = false;
            this.m_pBtnUpdate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_pBtnUpdate.Location = new System.Drawing.Point(336, 86);
            this.m_pBtnUpdate.Name = "m_pBtnUpdate";
            this.m_pBtnUpdate.Size = new System.Drawing.Size(117, 33);
            this.m_pBtnUpdate.TabIndex = 5;
            this.m_pBtnUpdate.Text = "重启";
            this.m_pBtnUpdate.UseVisualStyleBackColor = true;
            this.m_pBtnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::rainfall.App.UpdateForm.Properties.Resources.install2;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 49);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(82, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(349, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "发现新的软件版本,开始解压安装.完成后请重启雨量计!!!";
            // 
            // m_pLableMessage
            // 
            this.m_pLableMessage.AutoSize = true;
            this.m_pLableMessage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_pLableMessage.Location = new System.Drawing.Point(12, 75);
            this.m_pLableMessage.Name = "m_pLableMessage";
            this.m_pLableMessage.Size = new System.Drawing.Size(65, 17);
            this.m_pLableMessage.TabIndex = 9;
            this.m_pLableMessage.Text = "开始安装...";
            // 
            // frmUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 131);
            this.ControlBox = false;
            this.Controls.Add(this.m_pLableMessage);
            this.Controls.Add(this.m_pBarProcess);
            this.Controls.Add(this.m_pBtnUpdate);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "更新";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUpdate_FormClosed);
            this.Load += new System.EventHandler(this.frmUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar m_pBarProcess;
        private System.Windows.Forms.Button m_pBtnUpdate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label m_pLableMessage;
    }
}

