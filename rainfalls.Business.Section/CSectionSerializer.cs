using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using rainfalls.Base.Struct;

namespace rainfalls.Business.Section
{
    public class CSectionSerializer
    {
        private string uuid;
        public string UUID
        {
            get { return uuid; }
            set { uuid = value; }
        }
        private int m_nLevel;
        public int LastLevel
        {
            get { return m_nLevel; }
            set { m_nLevel = value; }
        }
        private int m_nLiftValue;
        public int LiftValue
        {
            get { return m_nLiftValue; }
            set { m_nLiftValue = value; }
        }
        private long m_nWarnTime;
        public long WarningTime
        {
            get { return m_nWarnTime; }
            set { m_nWarnTime = value; }
        }
        private string m_pLiftID;
        public string LiftId
        {
            get { return m_pLiftID; }
            set { m_pLiftID = value; }
        }
        public void Clear()
        {
            LastLevel = 0;
            LiftValue = 0;
            WarningTime = 0;
            LiftId = null;
        }
        public string GetJSON()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(this);
        }
        public void UpdateData(int level, int value, long tm, string id)
        {
            LastLevel = level;
            LiftValue = value;
            WarningTime = tm;
            LiftId = id;
        }
    }
}
