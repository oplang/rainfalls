using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rainfalls.View.SectionAlarmControl;

namespace rainfalls.View.SectionControl
{
    public partial class frmAlarm : Form
    {
        private static frmAlarm uniqueInstance;
        private static readonly object padlock = new object();
        private List<AlarmHandleControl> m_pAlarmControlList = new List<AlarmHandleControl>();
        private int m_nMaxShow = 6;
        private frmAlarm()
        {
            InitializeComponent();
        }
        public static frmAlarm getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new frmAlarm();
                    }
                }
            }
            return uniqueInstance;
        }
        public void AddAlarmControl(AlarmHandleControl ahc)
        {
            m_pAlarmControlList.Add(ahc);
        }
        public void WhoIsShow()
        {
            this.Controls.Clear();
            int n = 0;
            Point p = new Point();
            p.X = 10;
            p.Y = 10;

            int nCtrlHeight = 122;
            int nCaptionHeight = 38;
            for (int i = 0; i < m_pAlarmControlList.Count; i++)
            {
                if (m_pAlarmControlList[i].Shown)
                {
                    this.Controls.Add(m_pAlarmControlList[i]);
                    m_pAlarmControlList[i].Location = p;
                    m_pAlarmControlList[i].Show();
                    p.Y += (nCtrlHeight + 5);
                    n++;
                }
            }
            if (n < m_nMaxShow)
                this.Height = n * nCtrlHeight + nCaptionHeight + n * 5 + 10;
            else
                this.Height = m_nMaxShow * nCtrlHeight + nCaptionHeight + n * 5 + 10;
            if (n == 0)
            {
                this.Hide();
            }
           
        }
        public void RefreshLocation()
        {
            this.SetBounds((Screen.GetBounds(this).Width / 2) - (this.Width / 2), (Screen.GetBounds(this).Height / 2) - (this.Height / 2), this.Width, this.Height, BoundsSpecified.Location);
        }
    }
}
