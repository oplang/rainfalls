using System;
using rainfalls.Abstract.Class;
using rainfalls.Base.Struct;
using rainfalls.Base.Class;
using System.Xml;
using rainfalls.path;
using System.IO;
using rainfalls.Base.ErrorHandle;
using Zyf.Ini;
using System.Runtime.InteropServices;
using System.Web.Script.Serialization;
using System.Threading;
using System.Threading.Tasks;

using System.Collections.Generic;
using rainfalls.Abstract.Interface;
using rainfalls.Business.InspectorLab;


namespace rainfalls.Business.Section
{
    public class CSectionObj : ASectionObj
    {
        private const string PTRAIN = "客车";
        private const string FTRAIN = "货车";
        private Stack<_RFLog> m_pAlarmRecordlogs = new Stack<_RFLog>();
        private string m_pJsonPath;
        private CSectionSerializer m_pSectionSerializer = new CSectionSerializer();
        private System.Timers.Timer timer = new System.Timers.Timer();

        public CSectionObj()
        {
            AlarmLevelsCount = 0;
        }
        private void AddTodoItem()
        {


            todo.Add(0, "无");
            todo.Add(1, "巡查线路");
            todo.Add(2, "限速行车");
            todo.Add(3, "扣发客车");
            todo.Add(4, "扣发货车");
            todo.Add(-1, "单击解除出巡警戒");
            todo.Add(-2, "单击解除限速警戒");
            todo.Add(-3, "单击解除客车封锁");
            todo.Add(-4, "单击解除货车封锁");
           
        }
        private void PushAllRlogStack()
        {
            int n;
            m_pAlarmRecordlogs.Clear();
            _RFLog[] rlog = DBHelper.GetTrackBreakRecords(out n, this);
            if (n > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    m_pAlarmRecordlogs.Push(rlog[i]);
                }
            }
        }
        public override void AlarmComputer(LEVELINFO li)
        {
            if (li.level > 0)
            {
               
                if (li.level > SectionAlarmLevel)
                {
                    SectionAlarmLevel = li.level;
                    LevelFormat = worksdone[SectionAlarmLevel];
                    HadMeasure = todo[SectionAlarmLevel];
                    LastLevelInfo = li;
                    PostShowRegFormMessage();
                    PostHideLiftControlMessage();
                }
            }
        }
        private void PostShowRegFormMessage()
        {
            string szHandle = IniHelper.IniReadValue("System", paths.SecetionHandle, paths.HandlePath);
            if (szHandle.Length > 0)
            {
                int wParam = Marshal.StringToBSTR(ID).ToInt32();
                int nHandle = int.Parse(szHandle);
                IntPtr pHandle = new IntPtr(nHandle);
                CWinMsgAPI.PostMessage(pHandle, CMessage.WM_ONSHOW_REGFORM, wParam, 0);
            }
        }

        void AllRainStopHandle()
        {
            do
            {
                if (IsAllSiteRainStop())
                {
                    SectionAlarmLevel = 0;
                    m_pSectionSerializer.Clear();
                    LevelFormat = worksdone[SectionAlarmLevel];
                    HadMeasure = todo[SectionAlarmLevel];
                }
                Thread.Sleep(30 * 1000);
            } while (true);
        }
        public override void InitializeComponent()
        {
            AddTodoItem();
            doGetDef();
            m_pJsonPath = string.Format("{0}{1}.json", paths.APPPATH, ID);
            CreateVirualSectionObj();
            RefStack();
            Task.Factory.StartNew(AllRainStopHandle);
            Task.Factory.StartNew(AutoLiftComputer);

        }
        private void RefStack()
        {
            PushAllRlogStack();
            ReadJson();
        }
        /// <summary>
        /// 手动解除
        /// </summary>
        /// <returns></returns>
        public override bool ManualLiftComputer()
        {
            _autoLiftLevelInfo li = new _autoLiftLevelInfo();
            bool IsCanLiftSection = false;
            int m_nLevel = SectionAlarmLevel;
            if (m_nLevel > 0)
            {

                //检查报警站点雨量是否满足解除条件
                foreach (AVirtualSection avs in VirtualSectionList)
                {
                    if (avs.SiteID.Equals(m_pSectionSerializer.LiftId))
                    {
                        if (avs.DoCanLiftLevel(m_pSectionSerializer.LastLevel, m_pSectionSerializer.LiftValue, m_pSectionSerializer.WarningTime))
                        {
                            IsCanLiftSection = true;
                            li = avs.GetLiftLevelInof();
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                //如果报警站点满足解除条件，判断区间内其它采集点的雨量是否满足解除条件
                if (IsCanLiftSection)
                {
                    foreach (AVirtualSection avs in VirtualSectionList)
                    {
                        if (!avs.SiteID.Equals(m_pSectionSerializer.LiftId))
                        {
                            IsCanLiftSection &= avs.DoCanLiftLevel(m_pSectionSerializer.LastLevel, m_pSectionSerializer.LiftValue, m_pSectionSerializer.WarningTime);
                        }
                    }
                }
                if (IsCanLiftSection)
                {
                    if (m_nLevel == SectionAlarmLevel)
                    {
                        li.secName = SectionName;
                        li.secid = ID;
                        li.uuid = m_pSectionSerializer.UUID;
                        LiftLevelInfo = li;

                        HadMeasure = todo[li.level];
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            return false;
        }
        /// <summary>
        /// 自动判断线程
        /// </summary>
        void AutoLiftComputer()
        {
            _autoLiftLevelInfo li = new _autoLiftLevelInfo();
            for (; ; )
            {
                Thread.Sleep(5 * 1000);
                bool IsCanLiftSection = false;
                int m_nLevel = SectionAlarmLevel;
                if (m_nLevel > 0)
                {

                    //检查报警站点雨量是否满足解除条件
                    foreach (AVirtualSection avs in VirtualSectionList)
                    {
                        if (avs.SiteID.Equals(m_pSectionSerializer.LiftId))
                        {
                            if (avs.DoCanLiftLevel(m_pSectionSerializer.LastLevel, m_pSectionSerializer.LiftValue, m_pSectionSerializer.WarningTime))
                            {
                                IsCanLiftSection = true;
                                li = avs.GetLiftLevelInof();
                            }
                            else
                            {
                                IsCanLiftSection = false; //PostShowOpenNotifyControlMessage(0);
                                HadMeasure = todo[SectionAlarmLevel]; PostRefreshSectionGridViewMessage();
                            }
                        }
                    }
                    //如果报警站点满足解除条件，判断区间内其它采集点的雨量是否满足解除条件
                    if (IsCanLiftSection)
                    {
                        bool b = true;
                        foreach (AVirtualSection avs in VirtualSectionList)
                        {
                            if (!avs.SiteID.Equals(m_pSectionSerializer.LiftId))
                            {
                                b = avs.DoCanLiftLevel(m_pSectionSerializer.LastLevel, m_pSectionSerializer.LiftValue, m_pSectionSerializer.WarningTime);
                                if (b == false)
                                {
                                    IsCanLiftSection = false;
                                }
                            }
                        }
                    }
                    if (IsCanLiftSection)
                    {
                        if (m_nLevel == SectionAlarmLevel)
                        {
                            //li.secName = SectionName;
                            //li.secid = ID;
                            //LiftLevelInfo = li;
                            HadMeasure = todo[li.level]; PostRefreshSectionGridViewMessage();
                            //PostShowLiftControlMessage();
                        }
                        else
                        {
                            //PostHideLiftControlMessage();
                            HadMeasure = todo[SectionAlarmLevel]; PostRefreshSectionGridViewMessage();
                        }
                    }
                    else
                    {
                        //PostHideLiftControlMessage();
                        HadMeasure = todo[SectionAlarmLevel]; PostRefreshSectionGridViewMessage();
                    }
                }

            }
        }
        private void PostRefreshSectionGridViewMessage()
        {
            string szHandle = IniHelper.IniReadValue("System", paths.SecetionHandle, paths.HandlePath);
            if (szHandle.Length > 0)
            {
                int nHandle = int.Parse(szHandle);
                IntPtr pHandle = new IntPtr(nHandle);
                CWinMsgAPI.PostMessage(pHandle, CMessage.WM_ONREFRESH_SECTIONGRIDVIEW, 0, 0);
            }
        }
        private void PostShowLiftControlMessage()
        {
            string szHandle = IniHelper.IniReadValue("System", paths.SecetionHandle, paths.HandlePath);
            if (szHandle.Length > 0)
            {
                int wParam = Marshal.StringToBSTR(ID).ToInt32();
                int nHandle = int.Parse(szHandle);
                IntPtr pHandle = new IntPtr(nHandle);
                CWinMsgAPI.PostMessage(pHandle, CMessage.WM_ONSHOW_OPENNOTIFYCONTROL, wParam, 0);
            }
        }
        private void PostHideLiftControlMessage()
        {
            HadMeasure = todo[SectionAlarmLevel];
            string szHandle = IniHelper.IniReadValue("System", paths.SecetionHandle, paths.HandlePath);
            if (szHandle.Length > 0)
            {
                int wParam = Marshal.StringToBSTR(ID).ToInt32();
                int nHandle = int.Parse(szHandle);
                IntPtr pHandle = new IntPtr(nHandle);
                CWinMsgAPI.PostMessage(pHandle, CMessage.WM_ONHIDDEN_OPENNOTIFYCONTROL, wParam, 0);
            }
        }
        private void CreateVirualSectionObj()
        {
            foreach (ASiteObj obj in SiteObjList)
            {
                AVirtualSection avs = new CVirtualSection(string.Format("{0}Virtual{1}-{2}.json", paths.APPPATH, ID, obj.SiteID), this);
                avs.SectionID = this.ID;
                avs.SiteID = obj.SiteID;
                avs.SiteObj = obj;
                avs.BindClearEvent();
                VirtualSectionList.Add(avs);
            }
        }
        private bool IsAllSiteRainStop()
        {
            bool b = true;
            foreach (AVirtualSection avs in VirtualSectionList)
            {
                //只要有一个采集点降雨没有停止，就返回false
                if (!avs.SiteObj.IsRainStop())
                {
                    b = false;
                    break;
                }
            }
            return b;
        }

        #region 重写override
        protected override void ReadJson()
        {
            if (m_pAlarmRecordlogs.Count > 0)
            {
                _RFLog r = m_pAlarmRecordlogs.Peek();
                m_pSectionSerializer.LiftId = r.site_id;
                m_pSectionSerializer.LiftValue = int.Parse(r.lift_value);
                m_pSectionSerializer.LastLevel = int.Parse(r.level);
                m_pSectionSerializer.WarningTime = r.tm1;
                m_pSectionSerializer.UUID = r.uuid;
                SectionAlarmLevel = m_pSectionSerializer.LastLevel;
            }
            else
            {
                SectionAlarmLevel = 0;
                m_pSectionSerializer.Clear();
            }
            LevelFormat = worksdone[SectionAlarmLevel];
            HadMeasure = todo[SectionAlarmLevel];

            //if (File.Exists(m_pJsonPath))
            //{
            //    StreamReader sr = new StreamReader(m_pJsonPath);
            //    string json = sr.ReadToEnd();
            //    JavaScriptSerializer js = new JavaScriptSerializer();
            //    m_pSectionSerializer = js.Deserialize<CSectionSerializer>(json);
            //    SectionAlarmLevel = m_pSectionSerializer.LastLevel;
            //    LevelFormat = worksdone[SectionAlarmLevel];
            //    HadMeasure = todo[SectionAlarmLevel];
            //    sr.Close();
            //}
            //else
            //{
            //    LevelFormat = worksdone[SectionAlarmLevel];
            //    HadMeasure = todo[SectionAlarmLevel];
            //}
        }

        protected override void SaveJson()
        {
            //if (!string.IsNullOrEmpty(m_pJsonPath))
            //{
            //    string json = m_pSectionSerializer.GetJSON();
            //    var fs = new FileStream(m_pJsonPath, FileMode.Create, FileAccess.Write);
            //    var sw = new StreamWriter(fs);
            //    sw.BaseStream.Seek(0, SeekOrigin.End);
            //    sw.WriteLine(json);
            //    sw.Flush();
            //    sw.Close();
            //    fs.Close();
            //}
            //更新数据库
        }

        public override void SaveLevelInfo(LEVELINFO li)
        {
            PostHideLiftControlMessage();
            RefStack();

            if (li.level == 1)
            {
                PatrolledTime = li.t2;
                // li.liftValue = 2;//出巡自动解除为2毫米
            }
            //SectionAlarmLevel = li.level;
            //m_pSectionSerializer.UpdateData(li.level, li.liftValue, Time.DateTime2DbTime(DateTime.Now), li.site_id);
            //SaveJson();
        }
        public override void UpdataLevel(int oldLevel, int newLevel, string site_id)
        {
            foreach (AVirtualSection avs in VirtualSectionList)
            {
                if (avs.SiteID.Equals(site_id))
                {
                    if (oldLevel == 4)
                    {
                        avs.FreightBreakOpenTime = Time.DateTime2DbTime(DateTime.Now);
                        avs.FreightBreakOpenValue = avs.SiteObj.Records;
                        avs.PatrolTime = avs.BreakOpenTime;
                    }
                    if (oldLevel == 3)
                    {
                        avs.BreakOpenTime = Time.DateTime2DbTime(DateTime.Now);
                        avs.BreakOpenValue = avs.SiteObj.Records;
                        avs.PatrolTime = avs.BreakOpenTime;
                    }
                    if (oldLevel == 2)
                    {
                        avs.LiftSpeedTime = Time.DateTime2DbTime(DateTime.Now);
                        avs.LiftSpeedValue = avs.SiteObj.Records;
                        avs.PatrolTime = avs.LiftSpeedTime;
                    }
                    if (oldLevel == 1)
                    {
                        avs.PatrolTime = Time.DateTime2DbTime(DateTime.Now);
                        avs.PatrolValue = avs.SiteObj.Records;
                    }
                    avs.AVSaveJson();
                }
            }
            //LevelFormat = worksdone[SectionAlarmLevel];
            //HadMeasure = todo[SectionAlarmLevel];
            //if (newLevel == 1)
            //    m_pSectionSerializer.UpdateData(SectionAlarmLevel, 2/*常理下如果解除*/, Time.DateTime2DbTime(DateTime.Now), site_id);
            //if (newLevel == 0)
            //    m_pSectionSerializer.UpdateData(0, 0, 0, null);
            RefStack();
        }
        #endregion
        #region 读取区间警戒值

        protected override void doGetDef()
        {
            doGetPassengerDef(); doGetFreightDef();
        }
        private void doGetPassengerDef()
        {
            XmlDocument doc = new XmlDocument();
            int i = AlarmLevelsCount;
            try
            {
                doc.Load(paths.warnPath);
                XmlNodeList pList = doc.SelectNodes("/Config/alarmLevel");
               
                foreach (XmlNode nl in pList)
                {
                    if (nl.Attributes[0].Value.Equals(ID))
                    {
                        XmlNodeList nodeListDelta = nl.SelectNodes("Delta");
                        foreach (XmlNode Node in nodeListDelta)
                        {
                            m_pAlarmLevels[i].dur = int.Parse(Node.Attributes[0].Value);
                            m_pAlarmLevels[i].delta = int.Parse(Node.Attributes[1].Value);
                            m_pAlarmLevels[i].level = int.Parse(Node.Attributes[2].Value);
                            m_pAlarmLevels[i].liftValue = int.Parse(Node.Attributes[3].Value);
                            m_pAlarmLevels[i].tag = TagType.tag_delta;
                            m_pAlarmLevels[i].TRAIN = PTRAIN;
                            i++;
                        }
                        XmlNodeList nodeListDaily = nl.SelectNodes("Daily");
                        foreach (XmlNode dailyNode in nodeListDaily)
                        {
                           
                            m_pAlarmLevels[i].dur = int.Parse(dailyNode.Attributes[0].Value);//单位为天
                            m_pAlarmLevels[i].delta = int.Parse(dailyNode.Attributes[1].Value);//
                            m_pAlarmLevels[i].level = int.Parse(dailyNode.Attributes[2].Value);
                            m_pAlarmLevels[i].liftValue = int.Parse(dailyNode.Attributes[3].Value);//开通条件
                            m_pAlarmLevels[i].tag = TagType.tag_daily;
                            m_pAlarmLevels[i].TRAIN = PTRAIN;
                            i++;
                        }

                        XmlNodeList nodeListCont = nl.SelectNodes("Cont");
                        foreach (XmlNode contNode in nodeListCont)
                        {
                            int tm;
                            m_pAlarmLevels[i].c_time = int.TryParse(contNode.Attributes[0].Value, out tm) ? tm : 0;
                
                            m_pAlarmLevels[i].delta = int.Parse(contNode.Attributes[1].Value);
                            m_pAlarmLevels[i].dur = int.Parse(contNode.Attributes[2].Value);//连续雨量dur保存一小时雨强
                            m_pAlarmLevels[i].level = int.Parse(contNode.Attributes[3].Value);
                            m_pAlarmLevels[i].liftValue = int.Parse(contNode.Attributes[4].Value);//开通条件

                            m_pAlarmLevels[i].tag = m_pAlarmLevels[i].c_time == 0 ? TagType.tag_cont : TagType.tag_hourcont;
                            m_pAlarmLevels[i].TRAIN = PTRAIN;
                            i++;
                        }
                    }

                }
            }
            catch(Exception e)
            {
               throw new Exception(string.Format("区间{0}客车警戒值读取错误"+e.Message, SectionName));
            }
            AlarmLevelsCount = i;
        }
        private void doGetFreightDef()
        {
            XmlDocument doc = new XmlDocument();


            int i = AlarmLevelsCount;
            try
            {
                doc.Load(paths.warn_Freight_Path);
                XmlNodeList pList = doc.SelectNodes("/Config/alarmLevel");
                foreach (XmlNode nl in pList)
                {
                    if (nl.Attributes[0].Value.Equals(ID))
                    {
                        XmlNodeList nodeListDelta = nl.SelectNodes("Delta");
                        foreach (XmlNode Node in nodeListDelta)
                        {
                            m_pAlarmLevels[i].dur = int.Parse(Node.Attributes[0].Value);
                            m_pAlarmLevels[i].delta = int.Parse(Node.Attributes[1].Value);
                            m_pAlarmLevels[i].level = int.Parse(Node.Attributes[2].Value);
                            m_pAlarmLevels[i].liftValue = int.Parse(Node.Attributes[3].Value);
                            m_pAlarmLevels[i].tag = TagType.tag_delta;
                            m_pAlarmLevels[i].TRAIN = FTRAIN;
                            i++;
                        }
                        XmlNodeList nodeListCont = nl.SelectNodes("Cont");
                        foreach (XmlNode contNode in nodeListCont)
                        {
                            int tm;
                            m_pAlarmLevels[i].c_time = int.TryParse(contNode.Attributes[0].Value, out tm) ? tm : 0;

                            m_pAlarmLevels[i].delta = int.Parse(contNode.Attributes[1].Value);
                            m_pAlarmLevels[i].dur = int.Parse(contNode.Attributes[2].Value);//连续雨量dur保存一小时雨强
                            m_pAlarmLevels[i].level = int.Parse(contNode.Attributes[3].Value);
                            m_pAlarmLevels[i].liftValue = int.Parse(contNode.Attributes[4].Value);//开通条件

                            m_pAlarmLevels[i].tag = m_pAlarmLevels[i].c_time == 0 ? TagType.tag_cont : TagType.tag_hourcont;
                            m_pAlarmLevels[i].TRAIN = PTRAIN;
                            i++;
                        }
                    }

                }
            }
            catch
            {
                throw new Exception(string.Format("区间{0}货车警戒值读取错误", SectionName));
               
            }
            AlarmLevelsCount = i;
        }
        #endregion
    }
}
