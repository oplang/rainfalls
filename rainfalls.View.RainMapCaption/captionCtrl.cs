using System;
using System.Drawing;
using System.Windows.Forms;

using System.Diagnostics;
using rainfalls.Abstract.Interface;
using rainfalls.Abstract.Class;
using rainfalls.View.frmRainLog;
using rainfalls.Base.Class;
using rainfalls.App.Update;
namespace rainfalls.View.RainMapCaption
{
    public partial class captionCtrl : UserControl, IRainMapCaption
    {
        private SoftUpdate m_pSoftUpdate;
        private IRainMap m_pRainMapCtrl;
        private IRainCalc m_pSiteRainCalc;
        private IRainfallsDBHelper m_dbHelper;
        private bool m_bISReal = true;
        private Form m_pDadForm;
        private string m_pSiteName;
        System.Windows.Forms.Timer m_pTimer;
        public captionCtrl(Form ParentForm)
        {
            CSoftInfo.getInstance().OnDefaultSiteNameEvent += new AsyncRainMapCaption(captionCtrl_OnDefaultSiteNameEvent);
            m_pDadForm = ParentForm;
            m_pSoftUpdate = new SoftUpdate();
            InitializeComponent();
        }

        void captionCtrl_OnDefaultSiteNameEvent(string siteName)
        {
            setCaptionKm(siteName);
        }
        public IRainfallsDBHelper DbHelper
        {
            get { return m_dbHelper; }
            set { m_dbHelper = value; }
        }
        public IRainMap RainMapObj
        {
            set { m_pRainMapCtrl = value; }
        }
        public IRainCalc SiteRainCalc
        {
            set { m_pSiteRainCalc = value; }
        }
        public void setCaptionKm(string siteName)
        {
            m_pSiteName = siteName;
            if (this.InvokeRequired)
            {
                Action<Form> changeCaption = (X) =>
                {
                    X.Text=(string.Format("雨量图--{0}", m_pSiteName));
                };
                Invoke(changeCaption, m_pDadForm);
            }
            else
            {
                m_pDadForm.Text = (string.Format("雨量图--{0}", m_pSiteName));
            }
        }
        private void lbPreDay_Click(object sender, EventArgs e)
        {
            lbDate.Text = m_pRainMapCtrl.DrawPrevDay();
            lbDate.ForeColor = Color.Gray;
            m_bISReal = false;
        }

        private void lbNextDay_Click(object sender, EventArgs e)
        {
            bool b;
            lbDate.Text = m_pRainMapCtrl.DrawNextDay(out b);
            m_bISReal = b;
            if (b)
            {
                lbDate.ForeColor = Color.Maroon;

            }
            else
            {
                lbDate.ForeColor = Color.Gray;
            }
        }

        private void lbToday_Click(object sender, EventArgs e)
        {
            lbDate.Text = m_pRainMapCtrl.DrawRealtime();
            lbDate.ForeColor = Color.Maroon;
            m_bISReal = true;
        }

        private void lbAnyTime_Click(object sender, EventArgs e)
        {
            frmDateTime.getInstance().OnChangeDateEvent += new UpdateDate(captionCtrl_OnChangeDateEvent);
            frmDateTime.getInstance().Show();
        }

        void captionCtrl_OnChangeDateEvent(DateTime dt)
        {
            frmDateTime.getInstance().ManuaCloseForm();
            lbDate.Text = m_pRainMapCtrl.DrawAnyTime(dt);
            lbDate.ForeColor = Color.Gray;
            m_bISReal = false;
        }


        public void DrawRainMapCaption()
        {
            setCaptionDate(m_pRainMapCtrl.DrawRealtime());
        }
        private void setCaptionDate(string caption)
        {
          
            if (this.InvokeRequired)
            {
                Action<Label> changeDate = (X) =>
                {
                    X.Text = string.Format("{0}", caption);
                };
                Invoke(changeDate, lbDate);
            }
            else
            {
                lbDate.Text = string.Format("{0}", caption);
            }
        }
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            Label lb = (Label)sender;
            lb.ForeColor = Color.Red;
        }
        private void OnMouseLeave(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            lb.ForeColor = Color.Maroon;
        }

        private void captionCtrl_Load(object sender, EventArgs e)
        {
            m_pSoftUpdate.OnUpdateNofityEvent += new UpdateNotifyDelegate(m_pSoftUpdate_OnUpdateNofityEvent);
            m_pSoftUpdate.RUNAUTOUPDATE();

            m_pTimer = new System.Windows.Forms.Timer();
            m_pTimer.Interval = 60000;
            m_pTimer.Tick += new EventHandler(OnTimer);
            m_pTimer.Enabled = true;
        }
        void OnTimer(object sender, EventArgs e)
        {
            lbDate.Text = m_pRainMapCtrl.DrawRealtime();
        }
        void m_pSoftUpdate_OnUpdateNofityEvent(string msg)
        {
            if (msg.Equals("OK"))
            {
                string[] args = new string[2] { m_pSoftUpdate.FileName, m_pSoftUpdate.Version };
                Process p = new Process();
                p.StartInfo.FileName = System.IO.Path.Combine(Application.StartupPath, "AutoUpdate.exe");
                p.StartInfo.Arguments = m_pSoftUpdate.FileName;
                p.StartInfo.UseShellExecute = true;
                p.Start();
            }
        }

        private void lbRainLog_Click(object sender, EventArgs e)
        {
            rainLogDlg.getInstance().SetDefault(m_pRainMapCtrl.GetActiveSiteObj());
            rainLogDlg.getInstance().SiteRainCalc = m_pSiteRainCalc;
            rainLogDlg.getInstance().DbHelper = DbHelper;
            rainLogDlg.getInstance().Initialize(m_bISReal, DateTime.Parse((lbDate.Text.Split('至'))[1]).ToString());
            rainLogDlg.getInstance().Show();
        }
    }
}
