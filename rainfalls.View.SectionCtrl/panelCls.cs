using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace rainfalls.View.SectionCtrl
{
    public class panelCls : Panel
    {
        public Color BorderColor = Color.Gray;
        public int BorderWidth = 1;
        public ButtonBorderStyle BorderLineStyle = ButtonBorderStyle.Dashed;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (BorderColor != null)
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                    BorderColor, BorderWidth, BorderLineStyle,
                    BorderColor, BorderWidth, BorderLineStyle,
                    BorderColor, BorderWidth, BorderLineStyle,
                    BorderColor, 0, BorderLineStyle);
        }
    }
}
