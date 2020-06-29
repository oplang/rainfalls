namespace rainfalls.View.SectionGroupsCtrl
{
    partial class CSectionGroupsCtrl
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
            ((System.ComponentModel.ISupportInitialize)(this.picLine)).BeginInit();
            this.SuspendLayout();
            // 
            // picLine
            // 
            this.picLine.BackColor = System.Drawing.SystemColors.ControlDark;
            this.picLine.Location = new System.Drawing.Point(0, 76);
            this.picLine.Name = "picLine";
            this.picLine.Size = new System.Drawing.Size(1176, 1);
            this.picLine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLine.TabIndex = 0;
            this.picLine.TabStop = false;
            // 
            // CSectionGroupsCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picLine);
            this.Name = "CSectionGroupsCtrl";
            this.Size = new System.Drawing.Size(967, 83);
            this.Load += new System.EventHandler(this.sectionGroupsCtrl_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.sectionGroupsCtrl_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.picLine)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picLine;
    }
}
