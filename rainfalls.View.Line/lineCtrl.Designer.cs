namespace rainfalls.View.Line
{
    partial class lineCtrl
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
            this.picLine = new System.Windows.Forms.PictureBox();
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.lbSiteName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            this.SuspendLayout();
            // 
            // picLine
            // 
            this.picLine.Image = global::rainfalls.View.Line.Properties.Resources.line2;
            this.picLine.Location = new System.Drawing.Point(0, 210);
            this.picLine.Name = "picLine";
            this.picLine.Size = new System.Drawing.Size(1126, 10);
            this.picLine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLine.TabIndex = 9;
            this.picLine.TabStop = false;
            // 
            // pic2
            // 
            this.pic2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pic2.Image = global::rainfalls.View.Line.Properties.Resources.siteShapeBottom;
            this.pic2.Location = new System.Drawing.Point(480, 219);
            this.pic2.Name = "pic2";
            this.pic2.Size = new System.Drawing.Size(164, 18);
            this.pic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic2.TabIndex = 7;
            this.pic2.TabStop = false;
            // 
            // pic1
            // 
            this.pic1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pic1.Image = global::rainfalls.View.Line.Properties.Resources.siteShape;
            this.pic1.Location = new System.Drawing.Point(480, 191);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(164, 18);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic1.TabIndex = 6;
            this.pic1.TabStop = false;
            // 
            // lbSiteName
            // 
            this.lbSiteName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbSiteName.AutoSize = true;
            this.lbSiteName.BackColor = System.Drawing.Color.Transparent;
            this.lbSiteName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSiteName.Location = new System.Drawing.Point(525, 203);
            this.lbSiteName.Name = "lbSiteName";
            this.lbSiteName.Size = new System.Drawing.Size(74, 22);
            this.lbSiteName.TabIndex = 11;
            this.lbSiteName.Text = "西安南站";
            // 
            // lineCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbSiteName);
            this.Controls.Add(this.picLine);
            this.Controls.Add(this.pic2);
            this.Controls.Add(this.pic1);
            this.Name = "lineCtrl";
            this.Size = new System.Drawing.Size(1124, 250);
            this.Load += new System.EventHandler(this.lineCtrl_Load);
            this.SizeChanged += new System.EventHandler(this.lineCtrl_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.picLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic2;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.PictureBox picLine;
       // private SiteCtrl.siteCtrl mainSite;
        private System.Windows.Forms.Label lbSiteName;
    }
}
