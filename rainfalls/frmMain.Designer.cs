namespace rainfalls
{
    partial class frmMain
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.txtSystime = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtNetWorkState = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtSysInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtMtup = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtDeviceID = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.Color.DarkCyan;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtSystime,
            this.txtNetWorkState,
            this.txtSysInfo,
            this.txtMtup,
            this.txtDeviceID});
            this.statusStrip1.Location = new System.Drawing.Point(0, 311);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(973, 31);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // txtSystime
            // 
            this.txtSystime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSystime.ForeColor = System.Drawing.Color.White;
            this.txtSystime.Name = "txtSystime";
            this.txtSystime.Size = new System.Drawing.Size(239, 26);
            this.txtSystime.Spring = true;
            this.txtSystime.Text = "      ";
            // 
            // txtNetWorkState
            // 
            this.txtNetWorkState.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNetWorkState.ForeColor = System.Drawing.Color.White;
            this.txtNetWorkState.Name = "txtNetWorkState";
            this.txtNetWorkState.Size = new System.Drawing.Size(239, 26);
            this.txtNetWorkState.Spring = true;
            this.txtNetWorkState.Text = "网络状态:正常";
            this.txtNetWorkState.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // txtSysInfo
            // 
            this.txtSysInfo.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSysInfo.ForeColor = System.Drawing.Color.White;
            this.txtSysInfo.Name = "txtSysInfo";
            this.txtSysInfo.Size = new System.Drawing.Size(239, 26);
            this.txtSysInfo.Spring = true;
            this.txtSysInfo.Text = "Vserson";
            // 
            // txtMtup
            // 
            this.txtMtup.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMtup.ForeColor = System.Drawing.Color.White;
            this.txtMtup.Name = "txtMtup";
            this.txtMtup.Size = new System.Drawing.Size(191, 26);
            this.txtMtup.Spring = true;
            this.txtMtup.Text = "MTUP";
            this.txtMtup.Visible = false;
            // 
            // txtDeviceID
            // 
            this.txtDeviceID.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDeviceID.ForeColor = System.Drawing.Color.White;
            this.txtDeviceID.Name = "txtDeviceID";
            this.txtDeviceID.Size = new System.Drawing.Size(239, 26);
            this.txtDeviceID.Spring = true;
            this.txtDeviceID.Text = "设备标识";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(973, 342);
            this.ControlBox = false;
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "rainfalls";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel txtSystime;
        private System.Windows.Forms.ToolStripStatusLabel txtNetWorkState;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel txtSysInfo;
        private System.Windows.Forms.ToolStripStatusLabel txtMtup;
        private System.Windows.Forms.ToolStripStatusLabel txtDeviceID;





    }
}

