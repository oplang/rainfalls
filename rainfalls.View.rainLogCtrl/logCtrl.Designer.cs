namespace rainfalls.View.rainLogCtrl
{
    partial class logCtrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(logCtrl));
            this.axF1Book1 = new AxTTF160.AxF1Book();
            ((System.ComponentModel.ISupportInitialize)(this.axF1Book1)).BeginInit();
            this.SuspendLayout();
            // 
            // axF1Book1
            // 
            this.axF1Book1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axF1Book1.Location = new System.Drawing.Point(0, 0);
            this.axF1Book1.Name = "axF1Book1";
            this.axF1Book1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axF1Book1.OcxState")));
            this.axF1Book1.Size = new System.Drawing.Size(774, 631);
            this.axF1Book1.TabIndex = 4;
            // 
            // logCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axF1Book1);
            this.Name = "logCtrl";
            this.Size = new System.Drawing.Size(774, 631);
            ((System.ComponentModel.ISupportInitialize)(this.axF1Book1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxTTF160.AxF1Book axF1Book1;
    }
}
