using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rainfalls.Business.InspectorLab
{
    /// <summary>
    /// 巡守区段对象类
    /// </summary>
    public class Zone
    {
        private string m_pSectionID;
        /// <summary>
        /// 巡守所属区间标识
        /// </summary>
        public string SectionID
        {
            set { m_pSectionID = value; }
            get { return m_pSectionID; }
        }
        private string m_pZoneName;
        /// <summary>
        /// 巡守名称
        /// </summary>
        public string ZoneName
        {
            set { m_pZoneName = value; }
            get { return m_pZoneName; }
        }
        private string m_pZoneID;
        /// <summary>
        /// 巡守标识
        /// </summary>
        public string ZoneID
        {
            set { m_pZoneID = value; }
            get { return m_pZoneID; }
        }
        private string m_pZoneType;
        /// <summary>
        /// 巡守类型（区段|看守点）
        /// </summary>
        public string ZoneType
        {
            set { m_pZoneType = value; }
            get { return m_pZoneType; }
        }
        private int m_pZoneLevel;
        /// <summary>
        /// 巡守级别(1-2-3)
        /// </summary>
        public int ZoneLevel
        {
            set { m_pZoneLevel = value; }
            get { return m_pZoneLevel; }
        }
    }
}
