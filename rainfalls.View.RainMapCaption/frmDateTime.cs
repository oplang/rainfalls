using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace rainfalls.View.RainMapCaption
{
    public delegate void UpdateDate(DateTime dt);
    public partial class frmDateTime : Form
    {
        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        //下面是可用的常量，根据不同的动画效果声明自己需要的  
        private const int AW_HOR_POSITIVE = 0x0001;//自左向右显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志  
        private const int AW_HOR_NEGATIVE = 0x0002;//自右向左显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志  
        private const int AW_VER_POSITIVE = 0x0004;//自顶向下显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志  
        private const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志该标志  
        private const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；否则向外扩展  
        private const int AW_HIDE = 0x10000;//隐藏窗口  
        private const int AW_ACTIVE = 0x20000;//激活窗口，在使用了AW_HIDE标志后不要使用这个标志  
        private const int AW_SLIDE = 0x40000;//使用滑动类型动画效果，默认为滚动动画类型，当使用AW_CENTER标志时，这个标志就被忽略  
        private const int AW_BLEND = 0x80000;//使用淡入淡出效果 
        public event UpdateDate OnChangeDateEvent;

        const int CS_DropSHADOW = 0x20000;
        const int GCL_STYLE = (-26);
        //声明Win32 API
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);

        private static frmDateTime uniqueInstance;
        private static readonly object padlock = new object();

        private frmDateTime()
        {
            InitializeComponent();
            SetClassLong(this.Handle, GCL_STYLE, GetClassLong(this.Handle, GCL_STYLE) | CS_DropSHADOW); //API函数加载，实现窗体边框阴影效果
        }
        public static frmDateTime getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new frmDateTime();
                    }
                }
            }
            return uniqueInstance;
        }
        private void frmDateTime_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 500, AW_BLEND | AW_ACTIVE);
            this.lbYear.Text = DateTime.Now.Year.ToString();
            this.lbMonth.Text = DateTime.Now.Month.ToString();
            this.lbDay.Text = DateTime.Now.Day.ToString();
            lbCaption.Text = string.Format("当前日期:{0}年{1}月{2}日", lbYear.Text, lbMonth.Text, lbDay.Text);
        }

        private void lbAddYear_Click(object sender, EventArgs e)
        {
            int y = int.Parse(this.lbYear.Text) + 1;
            this.lbYear.Text = y.ToString();
            lbCaption.Text = string.Format("当前日期:{0}年{1}月{2}日", lbYear.Text, lbMonth.Text, lbDay.Text);
        }

        private void lbAddMonth_Click(object sender, EventArgs e)
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
            lbCaption.Text = string.Format("当前日期:{0}年{1}月{2}日", lbYear.Text, lbMonth.Text, lbDay.Text);
        }

        private void lbAddDay_Click(object sender, EventArgs e)
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
            lbCaption.Text = string.Format("当前日期:{0}年{1}月{2}日", lbYear.Text, lbMonth.Text, lbDay.Text);
        }

        private void lbSubYear_Click(object sender, EventArgs e)
        {
            int y = int.Parse(this.lbYear.Text) - 1;
            this.lbYear.Text = y.ToString();
            lbCaption.Text = string.Format("当前日期:{0}年{1}月{2}日", lbYear.Text, lbMonth.Text, lbDay.Text);
        }

        private void lbSubMonth_Click(object sender, EventArgs e)
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
            lbCaption.Text = string.Format("当前日期:{0}年{1}月{2}日", lbYear.Text, lbMonth.Text, lbDay.Text);
        }

        private void lbSubDay_Click(object sender, EventArgs e)
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
            lbCaption.Text = string.Format("当前日期:{0}年{1}月{2}日", lbYear.Text, lbMonth.Text, lbDay.Text);
        }

        private void frmDateTime_FormClosing(object sender, FormClosingEventArgs e)
        {
           // uniqueInstance = null;
            AnimateWindow(this.Handle, 500, AW_BLEND | AW_HIDE);
        }

        private void frmDateTime_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void frmDateTime_Deactivate(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 500, AW_BLEND | AW_HIDE);
            this.Hide();
        }

        private void sbQuery_Click(object sender, EventArgs e)
        {
            if (OnChangeDateEvent != null)
                OnChangeDateEvent(new DateTime(int.Parse(this.lbYear.Text), int.Parse(this.lbMonth.Text), int.Parse(this.lbDay.Text), 0, 0, 0));
           
        }
        public void ManuaCloseForm()
        {
            AnimateWindow(this.Handle, 500, AW_BLEND | AW_HIDE);
            this.Hide();
        }
        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 500, AW_BLEND | AW_HIDE);
            this.Hide();
        }

        private void frmDateTime_VisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible==true)
                AnimateWindow(this.Handle, 500, AW_BLEND | AW_ACTIVE);
            else
                AnimateWindow(this.Handle, 500, AW_BLEND | AW_HIDE);
        }
    }
}
