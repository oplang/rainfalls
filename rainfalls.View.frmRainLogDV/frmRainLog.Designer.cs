namespace rainfalls.View.frmRainLogDV
{
    partial class frmRainLog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rainlogXls = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            this.SuspendLayout();
            // 
            // rainlogXls
            // 
            this.rainlogXls.Location = new System.Drawing.Point(12, 12);
            this.rainlogXls.Name = "rainlogXls";
            this.rainlogXls.Size = new System.Drawing.Size(747, 390);
            this.rainlogXls.TabIndex = 0;
            this.rainlogXls.Text = "spreadsheetControl1";
            this.rainlogXls.Click += new System.EventHandler(this.rainlogXls_Click);
            // 
            // frmRainLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 414);
            this.Controls.Add(this.rainlogXls);
            this.Name = "frmRainLog";
            this.Text = "frmRainLog";
            this.Load += new System.EventHandler(this.frmRainLog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraSpreadsheet.SpreadsheetControl rainlogXls;
    }
}