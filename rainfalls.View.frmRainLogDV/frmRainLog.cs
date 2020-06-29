using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rainfalls.View.frmRainLogDV
{
    public partial class frmRainLog : Form
    {
        public frmRainLog()
        {
            InitializeComponent();
        }

        private const int R0 = 1;
        public struct _maxunit
        {
            public long start;
            public long end;
            public int max;
            public short idx_start;
            public short idx_end;
        }
        public struct _RFLog
        {
            public string site_id;
            public long logtime;
            public string railLine;
            public string km;
            public string dir;
            public long brk_close;
            public long brk_open;
            public long limit_start;
            public long limit_restore;
            public string note;
            public string lift_time;
            public string lift_value;
            public string level;
        }
        public long difftime(long t1, long t2)
        {
            return (t1 - t2);
        }
        public void clear()
        {
            int r = 11;
            //while (r < this.axF1Book1.MaxRow)
            //{
            //    this.axF1Book1.set_TextRC(r, 1, "");
            //    this.axF1Book1.set_TextRC(r, 2, "");
            //    this.axF1Book1.set_TextRC(r, 7, "");
            //    this.axF1Book1.set_TextRC(r, 11, "");
            //    this.axF1Book1.set_TextRC(r, 13, "");
            //    this.axF1Book1.set_TextRC(r, 15, "");
            //    this.axF1Book1.set_TextRC(r, 17, "");
            //    this.axF1Book1.set_TextRC(r, 19, "");
            //    ++r;
            //}
        }
 

        private void frmRainLog_Load(object sender, EventArgs e)
        {
            rainlogXls.ActiveWorksheet.Cells[1,2].Value = 0;
        }

        private void rainlogXls_Click(object sender, EventArgs e)
        {
           
        }
    }
}
