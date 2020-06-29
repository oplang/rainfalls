using System;
using System.Windows.Forms;
using rainfalls.Abstract.Class;
using rainfalls.Abstract.Interface;
using rainfalls.Base.Class;
using rainfalls.Base.Struct;
using rainfalls.Business.InspectorLab;
using rainfalls.Business.WorksDoneReg;
using rainfalls.path;
using Zyf.Ini;


namespace rainfalls.View.SectionAlarmControl
{
    public delegate void ShowHiddenDelegate();
    public partial class AlarmHandleControl : UserControl
    {
        private _WorksDoneLog m_pWorksDoneLog;
        private string[] m_pWarns = new string[] { "出巡检查", "限速登记", "客车封锁登记", "货车封锁登记" };
        private string[] m_pWarnTypes = new string[] { "出巡开始时间", "限速开始时间", "客车封锁时间", "货车封锁时间" };
        private int m_nLevel;
        private LEVELINFO m_pLevelInfo;
        private int m_nShowTime = 0;
        private IRainfallsDBHelper m_pRainfallsDbHelper;
        private bool m_bShown = false;
        public event ShowHiddenDelegate OnShowHiddenEvent;
        public bool Shown
        {
            get { return m_bShown; }
            set { m_bShown = value; }
        }
        private ASectionObj m_pSectonObj;
        public ASectionObj SectonObj
        {
            set { m_pSectonObj = value; }
        }
        private ISoundPlay m_soundPlay;
        public ISoundPlay SoundPlay
        {
            set { m_soundPlay = value; }
        }
        public IRainfallsDBHelper rainfallsDbHelper
        {
            set { m_pRainfallsDbHelper = value; }
        }
        public AlarmHandleControl()
        {
            InitializeComponent();
        }
        public void SetLogInfo(LEVELINFO lip)
        {
            m_pLevelInfo = lip;
            /*
            r.typelevel >> 16, r.typelevel & 0xffff
             */
            string reason = null;
            CWorksDoneReg.GetWorksReason(m_pLevelInfo.t1, m_pLevelInfo.t2, m_pLevelInfo.delta, m_pLevelInfo.tag, m_pLevelInfo.level, ref reason, m_pLevelInfo.hValue);
            this.labReason.Text = reason;
            CWorksDoneReg.GetWorksDone(m_pLevelInfo.level, ref reason);
            this.labShould.Text = reason;

            if(m_pLevelInfo.level == 1)
            {
                string _pGqInfos = CINIFile.IniReadValue(m_pSectonObj.ID, "出巡工区", paths.GqInfos);
                this.labShould.Text ="通知"+ _pGqInfos +"," + reason;
            }
            //m_pSMS.siteId = m_pLevelInfo.site_id;
            //m_pSMS.km = m_pSectonObj.ID;//将区间ID
            //m_pSMS.tm1 = m_pLevelInfo.t1;
            //m_pSMS.tm2 = m_pLevelInfo.t2;
            //m_pSMS.value = m_pLevelInfo.delta;
            //m_pSMS.typelevel = (m_pLevelInfo.tag << 16) | m_pLevelInfo.level;

            m_pWorksDoneLog.siteId = lip.site_id;
            m_pWorksDoneLog.tm1 = m_pLevelInfo.t1;
            m_pWorksDoneLog.tm2 = m_pLevelInfo.t2;
            m_pWorksDoneLog.value = m_pLevelInfo.delta;
            m_pWorksDoneLog.typelevel = (m_pLevelInfo.tag << 16) | m_pLevelInfo.level;
            m_pWorksDoneLog.hourValue = m_pLevelInfo.hValue;
            m_nLevel = m_pLevelInfo.level;
            this.m_pLbOKHandle.Text = m_pWarns[m_nLevel - 1];

            m_nLevel = m_pLevelInfo.level;
            this.lbTimeCaption.Text = m_pWarnTypes[m_nLevel - 1];
            this.lbCaption.Text = string.Format("{0}[{1}]", m_pSectonObj.XingBieName, m_pSectonObj.SectionName);
            this.lbTime.Text = DateTime.Now.ToString();
            lbName.Text = CINIFile.IniReadValue("基本信息", "当前值班负责人", paths.baseInfoPath);
            m_pWorksDoneLog.name = string.Format("{0},{1}", lbName.Text, m_pSectonObj.SectionName);
            m_nShowTime++;
            m_pRainfallsDbHelper.WriteRunLogInfoDB(m_pSectonObj.SectionName + "报警=" + m_pSectonObj.SectionName, m_pSectonObj.SectionName + "开始报警:警戒级别=" + lip.level.ToString());
            m_soundPlay.AppendSoundAcc();
        }
        private void SectionAlarmCtrl_Load(object sender, EventArgs e)
        {

        }

        private void m_pLbOKHandle_Click(object sender, EventArgs e)
        {
            SaveLogInfo();
            m_soundPlay.RemoveSoundAcc(m_nShowTime);
            m_nShowTime = 0;
            this.Shown = false;
            if (OnShowHiddenEvent != null)
                OnShowHiddenEvent();
            this.Hide();
        }
        void SaveDataNotify(string txt)
        {
            if (this.InvokeRequired)
            {
                Action<DevExpress.XtraEditors.LabelControl> SetValue = (X) =>
                {
                    X.Text += txt;
                    this.Refresh();
                };
                Invoke(SetValue, m_pLbOKHandle);
            }
            else
            {
                m_pLbOKHandle.Text += txt;
                this.Refresh();
            }
        }
        private void SaveLogInfo()
        {
            SaveDataNotify("[正在保存报警数据...]");
            m_pRainfallsDbHelper.WriteWorksDoneLog(m_pWorksDoneLog);

            if (m_pLevelInfo.level == 1 && m_pLevelInfo.liftValue == 0)
            {
                m_pLevelInfo.liftValue = 2;
            }
            _RFLog rlog = new _RFLog();
            rlog.uuid = System.Guid.NewGuid().ToString("N");
            rlog.section_id = m_pSectonObj.ID;
            rlog.site_id = m_pLevelInfo.site_id;
            rlog.logtime = Time.DateTime2DbTime(System.DateTime.Now);
            string startTime = this.lbTime.Text;
            DateTime dt = DateTime.Parse(startTime);
            rlog.tm1 = Time.DateTime2DbTime(dt);
            rlog.note = CINIFile.IniReadValue("基本信息", "当前值班负责人", paths.baseInfoPath);
            rlog.lift_time = m_pLevelInfo.liftTime.ToString();
            rlog.lift_value = m_pLevelInfo.liftValue.ToString();
            rlog.level = m_pLevelInfo.level.ToString();
           

            m_pRainfallsDbHelper.WriteRFlog(rlog);

            _SMS sms = new _SMS();
            sms.siteId = m_pLevelInfo.site_id;
            sms.railLine = rlog.note;
            sms.km = m_pSectonObj.ID;
            sms.tm1 = m_pLevelInfo.t1;
            sms.tm2 = m_pLevelInfo.t2;
            sms.value = m_pLevelInfo.delta;
            sms.typelevel = m_pWorksDoneLog.typelevel;
            sms.hourValue = m_pLevelInfo.hValue;
            m_pRainfallsDbHelper.WriteSms(sms, m_pLevelInfo);


            m_pSectonObj.SaveLevelInfo(m_pLevelInfo);

            InspectorsLab.getInstance().AddNewInspectorTaskAlarm(m_pLevelInfo.level);
            
        }
    }
}
