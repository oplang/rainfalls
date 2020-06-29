//namespace rainfalls.View.Statuebar
//{
//    partial class statueBarCtrl
//    {
//        /// <summary> 
//        /// 必需的设计器变量。
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary> 
//        /// 清理所有正在使用的资源。
//        /// </summary>
//        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region 组件设计器生成的代码

//        /// <summary> 
//        /// 设计器支持所需的方法 - 不要
//        /// 使用代码编辑器修改此方法的内容。
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.components = new System.ComponentModel.Container();
//            this.panel1 = new System.Windows.Forms.Panel();
//            this.lbNetWork = new System.Windows.Forms.Label();
//            this.lbSysTime = new System.Windows.Forms.Label();
//            this.lbRainProcess = new System.Windows.Forms.Label();
//            this.timerSys = new System.Windows.Forms.Timer(this.components);
//            this.panel1.SuspendLayout();
//            this.SuspendLayout();
//            // 
//            // panel1
//            // 
//            this.panel1.Controls.Add(this.lbNetWork);
//            this.panel1.Controls.Add(this.lbSysTime);
//            this.panel1.Controls.Add(this.lbRainProcess);
//            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.panel1.Location = new System.Drawing.Point(0, 0);
//            this.panel1.Name = "panel1";
//            this.panel1.Size = new System.Drawing.Size(1114, 40);
//            this.panel1.TabIndex = 0;
//            // 
//            // lbNetWork
//            // 
//            this.lbNetWork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
//            this.lbNetWork.AutoSize = true;
//            this.lbNetWork.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
//            this.lbNetWork.Location = new System.Drawing.Point(925, 5);
//            this.lbNetWork.Name = "lbNetWork";
//            this.lbNetWork.Size = new System.Drawing.Size(107, 20);
//            this.lbNetWork.TabIndex = 8;
//            this.lbNetWork.Text = "网络状态：正常";
//            this.lbNetWork.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
//            // 
//            // lbSysTime
//            // 
//            this.lbSysTime.AllowDrop = true;
//            this.lbSysTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.lbSysTime.AutoEllipsis = true;
//            this.lbSysTime.AutoSize = true;
//            this.lbSysTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
//            this.lbSysTime.Location = new System.Drawing.Point(570, 5);
//            this.lbSysTime.Name = "lbSysTime";
//            this.lbSysTime.Size = new System.Drawing.Size(257, 20);
//            this.lbSysTime.TabIndex = 7;
//            this.lbSysTime.Text = "系统时间：2015年3月24日 18：08：09";
//            this.lbSysTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
//            // 
//            // lbRainProcess
//            // 
//            this.lbRainProcess.AutoSize = true;
//            this.lbRainProcess.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
//            this.lbRainProcess.Location = new System.Drawing.Point(15, 5);
//            this.lbRainProcess.Name = "lbRainProcess";
//            this.lbRainProcess.Size = new System.Drawing.Size(411, 20);
//            this.lbRainProcess.TabIndex = 6;
//            this.lbRainProcess.Text = "降雨过程：2014-02-04 18：20：12 -- 2015-02-05 16：11：22";
//            this.lbRainProcess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
//            // 
//            // timerSys
//            // 
//            this.timerSys.Enabled = true;
//            this.timerSys.Tick += new System.EventHandler(this.timerSys_Tick);
//            // 
//            // statueBarCtrl
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.Controls.Add(this.panel1);
//            this.Name = "statueBarCtrl";
//            this.Size = new System.Drawing.Size(1114, 40);
//            this.Load += new System.EventHandler(this.statueBarCtrl_Load);
//            this.panel1.ResumeLayout(false);
//            this.panel1.PerformLayout();
//            this.ResumeLayout(false);

//        }

//        #endregion

//        private System.Windows.Forms.Panel panel1;
//        private System.Windows.Forms.Label lbSysTime;
//        private System.Windows.Forms.Label lbRainProcess;
//        private System.Windows.Forms.Label lbNetWork;
//        private System.Windows.Forms.Timer timerSys;
//    }
//}
