using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rainfalls.Base.Struct;
using rainfalls.Business.WorksDoneReg;
using rainfalls.Abstract.Interface;
using rainfalls.Base.Class;
using rainfalls.Abstract.Class;
using Zyf.Ini;
using rainfalls.path;

namespace rainfalls.View.frmLift
{
    public delegate void LiftShowHiddenDelegate();
    public partial class AutoLiftNotifyControl : UserControl
    {
        private _WorksDoneLog log;
        _RFLog rlog ;
        private IRainfallsDBHelper m_dbHelper;
        private bool m_bShown = false;
        private _autoLiftLevelInfo m_pLiftLevelInfo;
        private int m_nMaxLvl;
        private int m_nRecords;
        private int m_nShowTime = 0;
        string[] Levels = { "-", "出巡", "限速", "客车封锁","货车封锁" };
        public event LiftShowHiddenDelegate OnShowHiddenEvent;
        public AutoLiftNotifyControl()
        {
            InitializeComponent();
        }
        private ASectionObj m_pSectonObj;
        public ASectionObj SectonObj
        {
            set { m_pSectonObj = value; }
        }
        ISoundPlay m_soundPlay;
        public ISoundPlay SoundPlay
        {
            set { m_soundPlay = value; }
        }
        public bool Shown
        {
            get { return m_bShown; }
            set { m_bShown = value; }
        }
        public IRainfallsDBHelper DbHelper
        {
            get { return m_dbHelper; }
            set { m_dbHelper = value; }
        }
        public void SetLogInfo(_autoLiftLevelInfo autoLevelInfo)
        {
            m_nShowTime++;
            m_pLiftLevelInfo = autoLevelInfo;
            WriteWorksDoneLog(autoLevelInfo);
            //if (m_pSectonObj.SectionAlarmLevel > 1)
            //{
            //    InitializeControlInfo();
            //    m_soundPlay.AppendSoundAcc();
            //}
            //else
            //{
            //    this.lbSectionName.Text = string.Format("{0}[{1}]", m_pSectonObj.XingBieName, m_pSectonObj.SectionName);
            //    this.lbLevel.Text = Levels[m_pSectonObj.SectionAlarmLevel];
            //    this.lbName.Text = CINIFile.IniReadValue("基本信息", "当前值班负责人", paths.baseInfoPath);
            //    long pre6 = Time.DateTime2DbTime(DateTime.Now) - 6 * 3600;
            //    this.lbTime.Text = m_pSectonObj.PatrolledTime > 0 ? Time.DbTime2DateTime(m_pSectonObj.PatrolledTime).ToString() : (Time.DbTime2DateTime(pre6).ToString());
            //    this.lbBreakTimeCaption.Text = "出巡开始时间";
            //    this.lbLiftTimeCaption.Text = "出巡结束时间";
            //    this.m_pLbOKHandle.Text = "恢复正常";
            //    m_soundPlay.AppendSoundAcc();
            //}
            InitializeControlInfo();
           // m_soundPlay.AppendSoundAcc();
        }
        private void InitializeControlInfo()
        {
            rlog = new _RFLog();
            rlog = DbHelper.GetTrackBreakRecords(m_pLiftLevelInfo.uuid);
            if (string.IsNullOrEmpty(rlog.uuid))
            {
                MessageBox.Show(string.Format("没有找到区间:{0}的报警记录,数据错误!",m_pSectonObj.SectionName), "解除提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                StopRegLift();
                return;
            }

            this.lbSectionName.Text = string.Format("{0}[{1}]", m_pSectonObj.XingBieName, m_pSectonObj.SectionName);
            this.lbLevel.Text = Levels[int.Parse(rlog.level)];
            this.lbName.Text = rlog.note;
            this.lbTime.Text = Time.DbTime2DateTime(rlog.tm1).ToString();
            if (rlog.level.Equals("1"))
            {
                this.lbBreakTimeCaption.Text = "出巡开始时间";
                this.lbLiftTimeCaption.Text = "出巡恢复时间";
                this.m_pLbOKHandle.Text = "出巡解除，班次巡查";
            }
            else if (rlog.level.Equals("2"))
            {
                this.lbBreakTimeCaption.Text = "限速开始时间";
                this.lbLiftTimeCaption.Text = "限速恢复时间";
                this.m_pLbOKHandle.Text = "恢复常速";
            }
            else 
            {
                this.lbBreakTimeCaption.Text = "断道封锁时间";
                this.lbLiftTimeCaption.Text = "断道开通时间";
                this.m_pLbOKHandle.Text = rlog.level.Equals("3") ? "解除客车封锁" : "解除货车封锁";
            }
        }
        private void WriteWorksDoneLog(_autoLiftLevelInfo autoLevelInfo)
        {
            /*
           r.typelevel >> 16, r.typelevel & 0xffff
            */
            string reason = null;
            CWorksDoneReg.GetWorksReason(autoLevelInfo.t1, autoLevelInfo.t2, autoLevelInfo.value, TagType.tag_open, autoLevelInfo.level, ref reason, 0);
            this.labReason.Text = reason;
            CWorksDoneReg.GetWorksDone(autoLevelInfo.level, ref reason);
            this.lbTime.Text = reason;
            this.lbSectionName.Text = autoLevelInfo.secName;
            log.siteId = autoLevelInfo.siteid;
            log.tm1 = autoLevelInfo.t1;
            log.tm2 = autoLevelInfo.t2;
            log.value = autoLevelInfo.value;
            log.typelevel = (TagType.tag_open << 16) | autoLevelInfo.level;
            log.hourValue = 0;
            log.name = string.Format("{0},{1}", CINIFile.IniReadValue("基本信息", "当前值班负责人", paths.baseInfoPath), m_pSectonObj.SectionName); 
            m_dbHelper.WriteRunLogInfoDB(autoLevelInfo.secName + "解除=" + autoLevelInfo.level.ToString(), autoLevelInfo.secName + "解除警戒:警戒级别=" + autoLevelInfo.level.ToString());
            m_dbHelper.WriteWorksDoneLog(log);
        }

        private void m_pLbOKHandle_Click(object sender, EventArgs e)
        {
            //if (m_nMaxLvl < 2)
            //{
            //    m_soundPlay.RemoveSoundAcc(m_nShowTime); m_nShowTime = 0;
            //    this.Shown = false;
            //    if (OnShowHiddenEvent != null)
            //        OnShowHiddenEvent();
            //    //解除完了之后是否要记录一下出巡解除时的雨量值;
            //    m_pSectonObj.UpdataLevel(1, 0, m_pLiftLevelInfo.siteid);
            //    return;
            //}
            //long t = Time.DateTime2DbTime(DateTime.Now);
            //for (int i = 0; i < m_nRecords; i++)
            //{
            //    if (m_pRFLog[i].brk_close > 0)
            //    {
            //        m_pRFLog[i].brk_open = t;
            //        m_dbHelper.UpDateRFlogDb(t, m_pRFLog[i].logtime, 5, m_pRFLog[i].site_id, m_pRFLog[i]);

            //        _SMS sms = new _SMS();
            //        sms.siteId = m_pRFLog[i].site_id;
            //        sms.typelevel = (TagType.tag_open << 16) | 5;
            //        sms.tm1 = t;
            //        sms.tm2 = 0;
            //        sms.railLine = m_pRFLog[i].railLine;
            //        sms.km = m_pSectonObj.ID;
            //        sms.value = long.Parse(m_pRFLog[i].lift_value);
            //        m_dbHelper.WriteSms(sms);
            //        m_dbHelper.WriteRunLogInfoDB(sms.km + "解除3级警戒", sms.km + "解除3级警戒");
            //        //解除完了之后是否要记录一下,报警站点的解除时间,解除时的雨量
            //        m_pSectonObj.UpdataLevel(3, 1, m_pLiftLevelInfo.siteid);

            //    }
            //    else if (m_pRFLog[i].limit_start > 0)
            //    {
            //        m_pRFLog[i].limit_restore = t;
            //        m_dbHelper.UpDateRFlogDb(t, m_pRFLog[i].logtime, 4, m_pRFLog[i].site_id, m_pRFLog[i]);
            //        if (2 == m_nMaxLvl)
            //        {
            //            _SMS sms = new _SMS();
            //            sms.siteId = m_pRFLog[i].site_id;
            //            sms.typelevel = (TagType.tag_open << 16) | 4;
            //            sms.railLine = m_pRFLog[i].railLine;
            //            sms.km = m_pSectonObj.ID;
            //            sms.tm1 = m_pLiftLevelInfo.t1;
            //            sms.tm2 = m_pLiftLevelInfo.t2;
            //            sms.value = m_pLiftLevelInfo.value;
            //            m_dbHelper.WriteSms(sms);
            //            m_dbHelper.WriteRunLogInfoDB(sms.km + "解除2级警戒", sms.km + "解除2级警戒");
            //            m_pSectonObj.UpdataLevel(2, 1, m_pLiftLevelInfo.siteid);
            //        }
            //        //解除完了之后是否要记录一下,报警站点的解除时间,解除时的雨量
                   
            //    }
            //}
            long t = Time.DateTime2DbTime(DateTime.Now);
            rlog.tm2 = t;
            m_dbHelper.UpDateRFlogDb(rlog);
            _SMS sms = new _SMS();
            sms.siteId = rlog.site_id;
            sms.typelevel = log.typelevel;
            sms.km = m_pSectonObj.ID;
            sms.tm1 = m_pLiftLevelInfo.t1;
            sms.tm2 = m_pLiftLevelInfo.t2;
            sms.value = m_pLiftLevelInfo.value;
            sms.railLine =  CINIFile.IniReadValue("基本信息", "当前值班负责人", paths.baseInfoPath);
            m_dbHelper.WriteSms(sms);
            m_dbHelper.WriteRunLogInfoDB(sms.km + string.Format("解除{0}级警戒", rlog.level), sms.km + string.Format("解除{0}级警戒", rlog.level));
            m_pSectonObj.UpdataLevel(int.Parse(rlog.level), 0, rlog.site_id);

           // m_soundPlay.RemoveSoundAcc(m_nShowTime); m_nShowTime = 0; ClearValue();
            this.Shown = false;
            if (OnShowHiddenEvent != null)
                OnShowHiddenEvent();
        }
        void ClearValue()
        {
            m_nMaxLvl = 0;
            m_nRecords = 0;
        }
        public void StopRegLift()
        {
            if (m_nShowTime > 0)
            {
                //m_soundPlay.RemoveSoundAcc(m_nShowTime);
                m_nShowTime = 0;
            }
            this.Shown = false;
            if (OnShowHiddenEvent != null)
                OnShowHiddenEvent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbSysTime.Text = string.Format("{0}", DateTime.Now.ToString());
            if (lbWarning.ForeColor == Color.Red)
                lbWarning.ForeColor = Color.LightCoral;
            else
                lbWarning.ForeColor = Color.Red;
        }

        private void lbContinue_Click(object sender, EventArgs e)
        {
            m_dbHelper.WriteRunLogInfoDB("稍后解除", "稍后解除");
            if (m_nShowTime > 0)
            {
                //m_soundPlay.RemoveSoundAcc(m_nShowTime);
                m_nShowTime = 0;
            }
            this.Shown = false;
            if (OnShowHiddenEvent != null)
                OnShowHiddenEvent();
        }
    }
}
