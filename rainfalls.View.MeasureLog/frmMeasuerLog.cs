using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rainfalls.Base.Struct;
using rainfalls.Base.Class;
using rainfalls.Business.WorksDoneReg;
using rainfalls.Abstract.Interface;
using System.Runtime.InteropServices;
namespace rainfalls.View.MeasureLog
{
    public partial class frmMeasuerLog : Form
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

        const int CS_DropSHADOW = 0x20000;
        const int GCL_STYLE = (-26);
        //声明Win32 API
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);

        private static frmMeasuerLog uniqueInstance;
        private static readonly object padlock = new object();
        private IRainfallsDBHelper m_dbHelper;

        public IRainfallsDBHelper DbHelper
        {
            get { return m_dbHelper; }
            set { m_dbHelper = value; }
        }
        //创建窗体对象的静态方法
        public static frmMeasuerLog InstanceObject()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new frmMeasuerLog();
                    }
                }
            }
            return uniqueInstance;
        }
        public void Init()
        {
            _WorksDoneLog[] log = new _WorksDoneLog[1000];
            int N = m_dbHelper.GetMeasuresLogRecords(log);
            if (N > 0)
            {
                this.dtMeasureLog.Rows.Add(N);
                for (int i = 0; i < N; i++)
                {
                    string szStr = null;
                    string[] infos = log[i].name.Split(',');
                    this.dtMeasureLog.Rows[i].Cells[0].Value = Time.DbTime2DateTime(log[i].reg_tm).ToString("yyyy.MM.dd HH:mm");
                    if(log[i].typelevel >0)
                        CWorksDoneReg.GetWorksReason(log[i].tm1, log[i].tm2, log[i].value, log[i].typelevel >> 16, log[i].typelevel & 0xffff, ref szStr, log[i].hourValue);
                    else
                        CWorksDoneReg.GetWorksReason(log[i].tm1, log[i].tm2, log[i].value, 5, log[i].typelevel , ref szStr, log[i].hourValue);
                    this.dtMeasureLog.Rows[i].Cells[2].Value = szStr;
                    if (log[i].typelevel > 0)
                        CWorksDoneReg.GetWorksDone(log[i].typelevel & 0xfff, ref szStr);
                    else
                        CWorksDoneReg.GetWorksDone(log[i].typelevel , ref szStr);
                    this.dtMeasureLog.Rows[i].Cells[3].Value = szStr;
                    this.dtMeasureLog.Rows[i].Cells[4].Value = infos[0];
                    this.dtMeasureLog.Rows[i].Cells[5].Value = log[i].siteId;
                    this.dtMeasureLog.Rows[i].Cells[1].Value = infos.Length > 1 ? infos[1] : "";
                }
            }
            else
                this.dtMeasureLog.Rows.Clear();
            this.dtMeasureLog.Rows.Add(10);
        }
        private frmMeasuerLog()
        {
            InitializeComponent();
        }

        private void frmMeasuerLog_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMeasuerLog_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMeasuerLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            uniqueInstance = null;
            AnimateWindow(this.Handle, 500, AW_BLEND | AW_HIDE);
        }

        private void frmMeasuerLog_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 500, AW_BLEND | AW_ACTIVE); 
            SetClassLong(this.Handle, GCL_STYLE, GetClassLong(this.Handle, GCL_STYLE) | CS_DropSHADOW); //API函数加载，实现窗体边框阴影效果
        }
    }
}
