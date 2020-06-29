using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace rainfalls.View.frmConfig
{
    public class panelCls : Panel
    {
        public Color BorderColor = Color.Gray;
        public int BorderWidth = 1;
        public ButtonBorderStyle BorderLineStyle = ButtonBorderStyle.Solid;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (BorderColor != null)
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                    BorderColor, 0, BorderLineStyle,
                    BorderColor, BorderWidth, BorderLineStyle,
                    BorderColor, 0, BorderLineStyle,
                    BorderColor, 0, BorderLineStyle);
        }
    }
}
