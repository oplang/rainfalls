namespace Update
{
    partial class Frm_UpdateDialog
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
            this.lbMsg = new System.Windows.Forms.ListBox();
            this.btnInstall = new System.Windows.Forms.Button();
            this.txtCaption = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbMsg
            // 
            this.lbMsg.BackColor = System.Drawing.Color.White;
            this.lbMsg.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMsg.FormattingEnabled = true;
            this.lbMsg.ItemHeight = 17;
            this.lbMsg.Location = new System.Drawing.Point(12, 29);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(476, 106);
            this.lbMsg.TabIndex = 0;
            // 
            // btnInstall
            // 
            this.btnInstall.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnInstall.Location = new System.Drawing.Point(192, 156);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(117, 36);
            this.btnInstall.TabIndex = 1;
            this.btnInstall.Text = "安装";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // txtCaption
            // 
            this.txtCaption.AutoSize = true;
            this.txtCaption.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCaption.Location = new System.Drawing.Point(9, 9);
            this.txtCaption.Name = "txtCaption";
            this.txtCaption.Size = new System.Drawing.Size(231, 17);
            this.txtCaption.TabIndex = 3;
            this.txtCaption.Text = "检测到6个更新文件您确定要现在安装吗？";
            // 
            // Frm_UpdateDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 204);
            this.ControlBox = false;
            this.Controls.Add(this.txtCaption);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.lbMsg);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_UpdateDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "更新提示";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Frm_UpdateDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbMsg;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Label txtCaption;
    }
}