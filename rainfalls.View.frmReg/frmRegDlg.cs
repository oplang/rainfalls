using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rainfalls.Base.Struct;
using rainfalls.Business.WorksDoneReg;
using rainfalls.Abstract.Interface;
using rainfalls.Abstract.Class;
using rainfalls.Base.Class;
using rainfalls.View.frmPerson;
namespace rainfalls.View.frmReg
{
    public delegate void onBtnClickHandler();
    public partial class frmRegDlg : Form
    {
        private _WorksDoneLog log;
        private _SMS sms;
        private string[] Warn = new string[] { "出巡检查", "限速登记", "封锁登记" };
        private string[] WarnType = new string[] { "出巡开始时间：", "限速开始时间：", "断道封锁时间：" };
        protected int m_nLevel;
        protected LEVELINFO m_levelInfo;
        protected IRainfallsDBHelper m_rainfallsDbHelper;
        public event onBtnClickHandler btnClickEvent;
        private ASectionObj m_pSectonObj;
        ISoundPlay m_soundPlay;
        int m_nShowTime = 0;
        public ISoundPlay SoundPlay
        {
            get { return m_soundPlay; }
            set { m_soundPlay = value; }
        }
        public frmRegDlg(ASectionObj obj)
        {
            m_pSectonObj = obj;
            InitializeComponent();
        }
        public IRainfallsDBHelper rainfallsDbHelper
        {
            set
            {
                m_rainfallsDbHelper = value;
            }
            get
            {
                return m_rainfallsDbHelper;
            }
        }
        public void setLocation(int px,int py)
        {
            Point sp = new Point(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.Left = sp.X / 2 - this.Width/2 -px; // dp.X + 600;
            this.Top = (sp.Y - this.Height) / 2 + py;
            this.Location = new System.Drawing.Point(Left, Top);
        }
        public void SetLogInfo(LEVELINFO lip)
        {
            m_levelInfo = lip;
            /*
            r.typelevel >> 16, r.typelevel & 0xffff
             */
            string reason = null;
            CWorksDoneReg.GetWorksReason(m_levelInfo.t1, m_levelInfo.t2, m_levelInfo.delta, m_levelInfo.tag, m_levelInfo.level, ref reason, m_levelInfo.hValue);
            this.labReason.Text = reason;
            CWorksDoneReg.GetWorksDone(m_levelInfo.level, ref reason);
            this.labShould.Text = reason;
            sms.siteId = m_levelInfo.site_id;
            sms.tm1 = m_levelInfo.t1;
            sms.tm2 = m_levelInfo.t2;
            sms.value = m_levelInfo.delta;
            sms.typelevel = (m_levelInfo.tag << 16) | m_levelInfo.level;
            log.siteId = lip.site_id;
            log.tm1 = m_levelInfo.t1;
            log.tm2 = m_levelInfo.t2;
            log.value = m_levelInfo.delta;
            log.typelevel = (m_levelInfo.tag << 16) | m_levelInfo.level;
            log.hourValue = m_levelInfo.hValue;
            m_nLevel = m_levelInfo.level;
            this.btnOk.Text = Warn[m_nLevel - 1];

            m_nLevel = m_levelInfo.level;
            this.lbTimeCaption.Text = WarnType[m_nLevel -1];
            this.lbKm.Text = m_pSectonObj.SectionName;
            this.lbTime.Text = DateTime.Now.ToString();
            m_nShowTime++;
            m_rainfallsDbHelper.WriteRunLogInfoDB(m_pSectonObj.SectionName + "报警=" + m_pSectonObj.SectionName, m_pSectonObj.SectionName + "开始报警:警戒级别=" + lip.level.ToString());
            m_soundPlay.AppendSoundAcc();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            log.name = this.labPerson.Text;
            if (log.name == "单击选择")
                return;
            this.Hide();
            m_rainfallsDbHelper.WriteWorksDoneLog(log);
            
            if (m_nLevel == 1)
            {
                m_rainfallsDbHelper.WriteSms(sms, m_levelInfo);
            }
            else
            {
                _RFLog rlog = new _RFLog();
                rlog.site_id = m_levelInfo.site_id;
                rlog.logtime = Time.DateTime2DbTime(System.DateTime.Now);
                rlog.railLine = null;
                rlog.km = m_pSectonObj.SectionName;
                rlog.note = labPerson.Text;
                rlog.dir = null;
                rlog.lift_time = m_levelInfo.liftTime.ToString();
                rlog.lift_value = m_levelInfo.liftValue.ToString();
                rlog.level = m_levelInfo.level.ToString();
                string startTime = this.lbTime.Text;
                DateTime dt = DateTime.Parse(startTime);

                if (m_nLevel == 2)
                    rlog.limit_start = Time.DateTime2DbTime(dt);
                else
                    rlog.brk_close = Time.DateTime2DbTime(dt);
                m_rainfallsDbHelper.WriteRFlog(rlog);

                _SMS sms = new _SMS();
                sms.siteId = m_levelInfo.site_id;
                sms.railLine = rlog.railLine;
                sms.km = rlog.km;
                sms.tm1 = m_levelInfo.t1;
                sms.tm2 = m_levelInfo.t2;
                sms.value = m_levelInfo.delta;
                sms.typelevel = (m_levelInfo.tag << 16) | m_levelInfo.level;
                sms.hourValue = m_levelInfo.hValue;
                m_rainfallsDbHelper.WriteSms(sms, m_levelInfo);
                m_rainfallsDbHelper.WriteRunLogInfoDB(m_pSectonObj.SectionName + "登记=" + m_levelInfo.level.ToString(), m_pSectonObj.SectionName + "登记报警:当前级别=" + m_levelInfo.level.ToString());
            }
         //   m_sectionSubject.saveLevel(m_nLevel);
            //CAlarm.G_CAlarm.soundOff(true);
            m_soundPlay.RemoveSoundAcc(m_nShowTime);
            m_nShowTime = 0;
        }

        private void labPerson_Click(object sender, EventArgs e)
        {
            frmPersonDlg dlg = new frmPersonDlg();
            dlg.ShowDialog(this);
            this.labPerson.Text = dlg.Person;
        }

        private void dropDownButton1_Click(object sender, EventArgs e)
        {
            frmPersonDlg dlg = new frmPersonDlg();
            dlg.ShowDialog(this);
            this.labPerson.Text = dlg.Person;
        }
    }
}
