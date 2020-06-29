using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
namespace rainfalls.View.rainLogCtrl
{
    public partial class logCtrl : UserControl
    {
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
        public logCtrl()
        {
            InitializeComponent();
        }
        public long difftime(long t1, long t2)
        {
            return (t1 - t2);
        }
        public void clear()
        {
            int r = 11;
            while (r < this.axF1Book1.MaxRow)
            {
                this.axF1Book1.set_TextRC(r, 1, "");
                this.axF1Book1.set_TextRC(r, 2, "");
                this.axF1Book1.set_TextRC(r, 7, "");
                this.axF1Book1.set_TextRC(r, 11, "");
                this.axF1Book1.set_TextRC(r, 13, "");
                this.axF1Book1.set_TextRC(r, 15, "");
                this.axF1Book1.set_TextRC(r, 17, "");
                this.axF1Book1.set_TextRC(r, 19, "");
                ++r;
            }
        }
        public void SetRainLog( int[] _start_mm, int[] _mm, _maxunit[] mu,long now,long t0,_RFLog[] log,int N)
        {
            
            //CRainCalc.getMMByHour(t0, 25, _start_mm, _mm);
            //_maxunit[] mu = new _maxunit[25];
            //CRainCalc.getMaxUnits(t0, 600, mu);

            ///////////////////////填写累计雨量////////////////////////////////
            long hours = (long)(difftime(now, t0) + 3599) / 3600;
            if (hours > 25 || hours < 0)
                hours = 25;
            int seq = 0;
            int r = 0;
            int c = 0;
            for (int i = 0; i < 2; i++)
            {
                r = i * 4 + R0 + 1;
                for (c = 2; c < 25 && seq < (int)hours; c += 2)
                {
                    this.axF1Book1.set_TextRC(r, c, string.Format("{0:F1}", _start_mm[seq] / 10.0));
                    ++seq;
                }
                while (c < 25)
                {
                    this.axF1Book1.set_TextRC(r, c, "");
                    c += 2;
                }
            }
            r = R0 + 2;
            // 填写小时雨量(1)
            seq = 0;
            for (c = 2; c < 25 && seq < hours; c += 2)
            {
                this.axF1Book1.set_TextRC(r, c + 1, string.Format("{0:F1}", _mm[seq] / 10.0));
                ++seq;
            }
            // fill rest grid with blank
            while (c < 25)
            {
                this.axF1Book1.set_TextRC(r, c + 1, "");
                c += 2;
            }
            // 填写(1)(2)交接处
            r = R0 + 6;
            if (seq < hours)
                this.axF1Book1.set_TextRC(r, 2, string.Format("{0:F1}", _mm[seq - 1] / 10.0));
            else
                this.axF1Book1.set_TextRC(r, 2, "");
            // 填写小时雨量(2)
            for (c = 2; c < 25 && seq < hours; c += 2)   // 25: include 18:00 - 19:00
            {
                this.axF1Book1.set_TextRC(r, c + 1, string.Format("{0:F1}", _mm[seq] / 10.0));
                ++seq;
            }
            // fill rest grid with blank
            while (c < 25)
            {
                this.axF1Book1.set_TextRC(r, c + 1, "");
                c += 2;
            }
            ////////////// 10分种最大雨量 /////////////////////////////////////////////////////////////////
            r = R0 + 3;
            seq = 0;
            for (c = 2; c < 25 && seq < hours; c += 2)
            {
                string hour = this.axF1Book1.get_TextRC(3, c + 1);
                if (hour == "0.1")
                    mu[seq].max = 1;
                this.axF1Book1.set_TextRC(r, c + 1, string.Format("{0:F1}", mu[seq].max / 10.0));
                ++seq;
            }
            // fill rest grid with blank
            while (c < 25)
            {
                this.axF1Book1.set_TextRC(r, c + 1, "");
                c += 2;
            }

            // 填写(1)(2)交接处
            r = R0 + 7;
            if (seq < hours)
                this.axF1Book1.set_TextRC(r, 2, string.Format("{0:F1}", mu[seq - 1].max / 10.0));
            else
                this.axF1Book1.set_TextRC(r, 2, "");

            // 10分种雨量(2)
            for (c = 2; c < 25 && seq < hours; c += 2)   // 25: include 18:00 - 19:00
            {
                string hour = this.axF1Book1.get_TextRC(7, c + 1);

                if (hour == "0.1")
                    mu[seq].max = 1;
                this.axF1Book1.set_TextRC(r, c + 1, string.Format("{0:F1}", mu[seq].max / 10.0));
                ++seq;
            }
            // fill rest grid with blank
            while (c < 25)
            {
                this.axF1Book1.set_TextRC(r, c + 1, "");
                c += 2;
            }
            ///////////////日志部分////////////////////////////////////////////////////////////////////////
            r = 11;
          
            for (int i = 0; i < N; i++)
            {
                this.axF1Book1.set_TextRC(r, 1, log[i].railLine);
                this.axF1Book1.set_TextRC(r, 2, log[i].km);
                this.axF1Book1.set_TextRC(r, 7, log[i].dir);
                if (log[i].brk_close > 0)
                {
                    DateTime dt1 = Time.DbTime2DateTime(log[i].brk_close);
                    this.axF1Book1.set_TextRC(r, 11, dt1.ToString("HH:mm"));

                }
                if (log[i].brk_open > 0)
                {
                    DateTime dt1 = Time.DbTime2DateTime(log[i].brk_open);
                    this.axF1Book1.set_TextRC(r, 13, dt1.ToString("HH:mm"));
                }
                if (log[i].limit_start > 0)
                {
                    DateTime dt1 = Time.DbTime2DateTime(log[i].limit_start);
                    this.axF1Book1.set_TextRC(r, 15, dt1.ToString("HH:mm"));
                }
                if (log[i].limit_restore > 0)
                {
                    DateTime dt1 = Time.DbTime2DateTime(log[i].limit_restore);
                    this.axF1Book1.set_TextRC(r, 17, dt1.ToString("HH:mm"));
                }
                this.axF1Book1.set_TextRC(r, 19, log[i].note);
                r++;
            }
        }
    }
}
