namespace rainfalls.View.RainMapCtrl
{
    partial class RainMapCtr
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox_Main = new System.Windows.Forms.PictureBox();
            this.toolTip_Main = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Main
            // 
            this.pictureBox_Main.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_Main.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_Main.Name = "pictureBox_Main";
            this.pictureBox_Main.Size = new System.Drawing.Size(671, 263);
            this.pictureBox_Main.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Main.TabIndex = 1;
            this.pictureBox_Main.TabStop = false;
            this.pictureBox_Main.Click += new System.EventHandler(this.pictureBox_Main_Click);
            this.pictureBox_Main.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Main_MouseMove);
            // 
            // toolTip_Main
            // 
            this.toolTip_Main.AutoPopDelay = 10000;
            this.toolTip_Main.BackColor = System.Drawing.Color.Transparent;
            this.toolTip_Main.InitialDelay = 500;
            this.toolTip_Main.ReshowDelay = 100;
            // 
            // RainMapCtr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox_Main);
            this.Name = "RainMapCtr";
            this.Size = new System.Drawing.Size(671, 263);
            this.Load += new System.EventHandler(this.UserControl_RainMap_Load);
            this.SizeChanged += new System.EventHandler(this.RainMapCtr_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Main;
        private System.Windows.Forms.ToolTip toolTip_Main;
    }
}
