using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rainfalls.View.frmDateTime
{
    public partial class frmDateTimeDlg : Form
    {
        protected DateTime dateTime;
        public frmDateTimeDlg()
        {
            InitializeComponent();
        }

        private void pbAddYear_Click(object sender, EventArgs e)
        {
            int y = int.Parse(this.lbYear.Text) + 1;
            this.lbYear.Text = y.ToString();
        }

        private void pbAddMonth_Click(object sender, EventArgs e)
        {
            int m = int.Parse(this.lbMonth.Text);
            if (m >= 12)
            {
                m = 1;
            }
            else
            {
                m++;
            }
            DateTime dt = DateTime.Parse(this.lbYear.Text + "-" + m.ToString());
            this.lbMonth.Text = dt.ToString("MM");


            int maxday = DateTime.DaysInMonth(int.Parse(this.lbYear.Text), m);
            if (int.Parse(lbDay.Text) > maxday)
            {
                lbDay.Text = maxday.ToString();
            }
        }

        private void pbAddDay_Click(object sender, EventArgs e)
        {
            int year = int.Parse(this.lbYear.Text);
            int month = int.Parse(this.lbMonth.Text);
            int maxday = DateTime.DaysInMonth(year, month);
            int day = int.Parse(this.lbDay.Text);
            if (day >= maxday)
            {
                day = 1;
            }
            else
            {
                day++;
            }
            DateTime dt = DateTime.Parse(this.lbYear.Text + "-" + month.ToString() + "-" + day.ToString());
            this.lbDay.Text = dt.ToString("dd");
        }

        private void pbSubYear_Click(object sender, EventArgs e)
        {
            int y = int.Parse(this.lbYear.Text) - 1;
            this.lbYear.Text = y.ToString();
        }

        private void pbSubMonth_Click(object sender, EventArgs e)
        {
            int m = int.Parse(this.lbMonth.Text);
            if (m <= 1)
            {
                m = 12;
            }
            else
            {
                m--;
            }
            DateTime dt = DateTime.Parse(this.lbYear.Text + "-" + m.ToString());
            this.lbMonth.Text = dt.ToString("MM");


            int maxday = DateTime.DaysInMonth(int.Parse(this.lbYear.Text), m);
            if (int.Parse(lbDay.Text) > maxday)
            {
                lbDay.Text = maxday.ToString();
            }
            
        }

        private void pbSubDay_Click(object sender, EventArgs e)
        {
            int year = int.Parse(this.lbYear.Text);
            int month = int.Parse(this.lbMonth.Text);
            int maxday = DateTime.DaysInMonth(year, month);
            int day = int.Parse(this.lbDay.Text);
            if (day <= 1)
            {
                day = maxday;
            }
            else
            {
                day--;
            }
            DateTime dt = DateTime.Parse(this.lbYear.Text + "-" + month.ToString() + "-" + day.ToString());
            this.lbDay.Text = dt.ToString("dd");
        }
        public DateTime GetDateTime
        {
            get
            {
                return dateTime;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            dateTime = new DateTime(int.Parse(this.lbYear.Text), int.Parse(this.lbMonth.Text), int.Parse(this.lbDay.Text), 0, 0, 0);
        }

        private void frmDateTimeDlg_Load(object sender, EventArgs e)
        {
            this.lbYear.Text = DateTime.Now.Year.ToString();
            this.lbMonth.Text = DateTime.Now.Month.ToString();
            this.lbDay.Text = DateTime.Now.Day.ToString();
            this.lbAddDay.Image = this.lbAddMonth.Image = lbAddYear.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "rec\\add.png");
            this.lbSubDay.Image = this.lbSubMonth.Image = lbSubYear.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "rec\\sub.png");
        }
    }
}
