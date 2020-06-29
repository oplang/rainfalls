using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace rainfalls.View.SectionCtrl
{
    class MyMessageBox : System.Windows.Forms.Panel
    {
        private Point point;
        private UserControl parent;
        private string text;
        /// <summary>
        /// 提示框
        /// </summary>
        /// <param name="text">显示的文本</param>
        /// <param name="point">显示的位置</param>
        /// <param name="parent">在那个窗口显示</param>
        public MyMessageBox(string text, Point point, UserControl parent)
        {
            int width = GetLength(text, this.Font);
            this.Size = new Size(width + 20, 37);
            this.BackColor = Color.Transparent;
            this.Left = point.X - this.Size.Width / 2;
            this.Top = point.Y;
            this.point = point;
            this.parent = parent;
            this.text = text;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(20, 90, 130, 150)), 0, 5, this.Width - 1, this.Height - 6);
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(60, 90, 130, 150)), 1, 6, this.Width - 3, this.Height - 8);
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(90, 130, 150)), 2, 7, this.Width - 5, this.Height - 10);
            e.Graphics.DrawLines(new Pen(Color.FromArgb(20, 90, 130, 150)), new Point[] { 
            new Point((this.Width / 2) - 5, 5),
            new Point((this.Width / 2),0),
            new Point((this.Width / 2)+5,5)
            });
            e.Graphics.DrawLines(new Pen(Color.FromArgb(60, 90, 130, 150)), new Point[] { 
            new Point((this.Width / 2) - 5, 6),
            new Point((this.Width / 2),1),
            new Point((this.Width / 2)+5,6)
            });
            e.Graphics.DrawLines(new Pen(Color.FromArgb(90, 130, 150)), new Point[] { 
            new Point((this.Width / 2) - 5, 7),
            new Point((this.Width / 2),2),
            new Point((this.Width / 2)+5,7)
            });
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            e.Graphics.FillRectangle(Brushes.White, 3, 8, this.Width - 6, this.Height - 11);
            e.Graphics.DrawLine(new Pen(Brushes.White), this.Width / 2, 3, this.Width / 2, 3);
            e.Graphics.DrawLine(new Pen(Brushes.White), this.Width / 2 - 1, 4, this.Width / 2 + 1, 4);
            e.Graphics.DrawLine(new Pen(Brushes.White), this.Width / 2 - 2, 5, this.Width / 2 + 2, 5);
            e.Graphics.DrawLine(new Pen(Brushes.White), this.Width / 2 - 3, 6, this.Width / 2 + 3, 6);
            e.Graphics.DrawLine(new Pen(Brushes.White), this.Width / 2 - 4, 7, this.Width / 2 + 4, 7);
            e.Graphics.DrawString(text, this.Font, Brushes.Black, 10, 15);
            base.OnPaint(e);
        }
        private static int GetLength(string st, Font f)
        {
            if (string.IsNullOrWhiteSpace(st))
                return 0;
            double HLen = f.Height * 0.9;
            double YLen = HLen / 2;
            double Length = 0;
            foreach (char item in st.ToCharArray())
            {
                if (System.Text.Encoding.Default.GetBytes(item.ToString()).Length == 1)
                    Length += YLen;
                else
                    Length += HLen;
            }
            return Convert.ToInt32(Length);
        }
    }
}

