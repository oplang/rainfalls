using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using rainfalls.Abstract.Class;
using rainfalls.Abstract.Interface;
using rainfalls.Base.Struct;

using rainfalls.View.rainLogCtrl;
using System.Runtime.InteropServices;
namespace rainfalls.View.frmRainLog
{
    public partial class rainLogDlg : Form
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

        private static rainLogDlg uniqueInstance;
        private static readonly object padlock = new object();
        logCtrl m_pLogCtrl = new logCtrl();
        //创建窗体对象的静态方法
        public static rainLogDlg getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new rainLogDlg();
                    }
                }
            }
            return uniqueInstance;
        }
        private const int R0 = 1;
        private ASiteObj m_pCurSite;
        private IRainCalc m_siteRainCalc;
        private IRainfallsDBHelper m_dbHelper;

        public IRainfallsDBHelper DbHelper
        {
            get { return m_dbHelper; }
            set { m_dbHelper = value; }
        }
        public IRainCalc SiteRainCalc
        {
            get { return m_siteRainCalc; }
            set { m_siteRainCalc = value; }
        }
        public void SetDefault(ASiteObj site)
        {
            m_pCurSite = site;
            lbSiteKm.Text = m_pCurSite.SiteName;
        }
        private rainLogDlg()
        {
            InitializeComponent();
        }
        public void Initialize(bool bRealtime, string historytm)
        {
            int[] _start_mm = new int[48];
            int[] _mm = new int[48];

            if (bRealtime)
                setlbDtTxt();
            else
                setlbDtTxt(historytm);
            //////////////
            long now = Time.DateTime2DbTime(DateTime.Now);
            long oneDayBefore = Time.DateTime2DbTime(DateTime.Parse(lbTime.Text)) - 24 * 3600;
            long d = 0;
            DateTime dt_now = Time.DbTime2DateTime(now);
            DateTime dt_oneDayBefor = Time.DbTime2DateTime(oneDayBefore);
            if (dt_now.Day == dt_oneDayBefor.Day &&
                 dt_now.Month == dt_oneDayBefor.Month &&
                 dt_now.Year == dt_oneDayBefor.Year &&
                 dt_now.Hour > 18)
                d = now;
            else
                d = oneDayBefore;
            DateTime dt = Time.DbTime2DateTime(d);
            dt = new DateTime(dt.Year, dt.Month, dt.Day, 19, 0, 0);
            long t0 = Time.DateTime2DbTime(dt);
            ////////////////
            _maxunit[] mu = new _maxunit[25];
            m_siteRainCalc.getMMByHour(t0, 25, _start_mm, _mm, m_pCurSite);
            m_siteRainCalc.getMaxUnits(t0, 600, mu, m_pCurSite);
            rainLogCtrl.logCtrl._maxunit [] mu2 = new rainLogCtrl.logCtrl._maxunit[25];
            for (int i = 0; i < 25; i++)
            {
                mu2[i].start = mu[i].start;
                mu2[i].end = mu[i].end;
                mu2[i].max = mu[i].max;
                mu2[i].idx_start = mu[i].idx_start;
                mu2[i].idx_end = mu[i].idx_end;
            }
            _RFLog[] log = new _RFLog[64];
            int N = m_dbHelper.GetRainLogRecords(log, t0,m_pCurSite.SiteID);
            rainLogCtrl.logCtrl._RFLog[] rLog = new rainLogCtrl.logCtrl._RFLog[64];
            for (int i = 0; i < N; i++)
            {
                if (log[i].level.Equals("1"))
                    continue;
                if (log[i].level.Equals("2"))
                {
                    rLog[i].limit_restore = log[i].tm2;
                    rLog[i].limit_start = log[i].tm1;
                    rLog[i].brk_close = 0;
                    rLog[i].brk_open = 0;
                }
                if (log[i].level.Equals("3") || log[i].level.Equals("4"))
                {
                    rLog[i].limit_restore = 0;
                    rLog[i].limit_start = 0;
                    rLog[i].brk_close = log[i].tm2;
                    rLog[i].brk_open = log[i].tm1;
                }

                rLog[i].dir = (m_siteRainCalc.getXingbieName(log[i].section_id).Split('~'))[1];
                rLog[i].km = m_siteRainCalc.getQjName(log[i].section_id);
                rLog[i].level = log[i].level;
               
                rLog[i].logtime = log[i].logtime;
                rLog[i].note = log[i].note;
                rLog[i].railLine = m_siteRainCalc.getLineName(log[i].section_id);
                rLog[i].site_id = log[i].site_id;
            }
            rainlogCtrl.SetRainLog(_start_mm, _mm, mu2, now, t0, rLog,N);
        }
        private void setlbDtTxt()
        {
            DateTime dt = DateTime.Now;
            if (dt.Hour >= 19)
                dt = dt.AddDays(1);
            this.lbTime.Text = dt.ToString("yyyy-MM-dd");
        }
        private void setlbDtTxt(string historytime)
        {
            DateTime dt = DateTime.Parse(historytime);
            this.lbTime.Text = dt.ToString("yyyy-MM-dd 19:00:00");
        }
        private void rainLogDlg_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 100, AW_BLEND | AW_ACTIVE);
            
        }

        private void rainLogDlg_FormClosing(object sender, FormClosingEventArgs e)
        {
            uniqueInstance = null;
            AnimateWindow(this.Handle, 500, AW_BLEND | AW_HIDE);
        }

        private void rainLogDlg_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
