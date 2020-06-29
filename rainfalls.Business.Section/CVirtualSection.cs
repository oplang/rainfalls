using rainfalls.Abstract.Class;
using rainfalls.Base.Struct;
using rainfalls.Base.Class;
using System;
using System.IO;
using System.Web.Script.Serialization;

namespace rainfalls.Business.Section
{
    public class CVirtualSection : AVirtualSection
    {
        private string m_pJsonPath ;
        private ASectionObj m_pSectionObj;
        private _autoLiftLevelInfo m_pAutoLiftLevelInfo = new _autoLiftLevelInfo();
        public CVirtualSection(string path,ASectionObj obj)
        {
            m_pSectionObj = obj;
            m_pJsonPath = path;
            ReadJson();
        }
        public override void BindClearEvent()
        {
            SiteObj.OnClearVirtualLevelStateEvent += new ClearVirtualLevelStateDelgate(SiteObj_OnClearVirtualLevelStateEvent);
        }
        void SiteObj_OnClearVirtualLevelStateEvent()
        {
            ClearLevelState();
        }
        public override LEVELINFO VirtualLevelCalc(ALARMLEVEL[] alarmLevels, int rows)
        {
            LEVELINFO li = SiteObj.LevelCalc(alarmLevels, rows,this);
            long now = Time.DateTime2DbTime(DateTime.Now);
            long N = SiteObj.Records;
            if (0 == SiteObj.LastTime)
                if (N > 1)
                    SiteObj.LastTime = SiteObj.RainClickLists[N - 2].tm;
            if (li.level > 0)
            {
                if (now - SiteObj.LastTime > 24 * 3600 || li.level > m_pSectionObj.SectionAlarmLevel)
                {
                    VirtualLevelInfo = li;//save
                }
            }
            SiteObj.LastTime = now;

            return li;
        }
        
        protected  void ReadJson()
        {
            try
            {
                if (File.Exists(m_pJsonPath))
                {
                    var fs = new FileStream(m_pJsonPath, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs);
                    string json = sr.ReadToEnd();
                    fs.Close();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    VirtualSerializer virtualJson = js.Deserialize<VirtualSerializer>(json);
                    BreakOpenTime = virtualJson.BreakOpenTime;
                    BreakOpenValue = virtualJson.BreakOpenValue;
                    LiftSpeedTime = virtualJson.LiftSpeedTime;
                    LiftSpeedValue = virtualJson.LiftSpeedValue;
                    PatrolTime = virtualJson.PatrolTime;
                    PatrolValue = virtualJson.PatrolValue;
                    sr.Close();
                }
            }
            catch { }
        }

        protected  void SaveJson()
        {
            try
            {
                if (!string.IsNullOrEmpty(m_pJsonPath))
                {
                    VirtualSerializer Json = new VirtualSerializer();
                    string json = Json.GetJSON(this);
                    var fs = new FileStream(m_pJsonPath, FileMode.Create, FileAccess.Write);
                    var sw = new StreamWriter(fs);
                    sw.BaseStream.Seek(0, SeekOrigin.End);
                    sw.WriteLine(json);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }
            }
            catch { }
        }
        public override _autoLiftLevelInfo GetLiftLevelInof()
        {
            return m_pAutoLiftLevelInfo;
        }
        public override bool DoCanLiftLevel(int level, int value, long tm)
        {
            bool b = SiteObj.DoCanLiftLevel(tm, level, value, ref m_pAutoLiftLevelInfo);
            return b;
        }

        public override void AVSaveJson()
        {
            SaveJson();
        }
    }
    
}
