using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zyf.un.Xml;
using System.Xml;
using System.Diagnostics;

namespace rainfalls.Business.InspectorLab
{
    public class ZoneLab
    {
        private readonly string configPath = AppDomain.CurrentDomain.BaseDirectory + "zone.xml";
        private List<Zone> m_pZoneLists = new List<Zone>();

        private static ZoneLab uniqueInstance;
        private static readonly object padlock = new object();
        private ZoneLab()
        {

        }
        public static ZoneLab getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new ZoneLab();
                    }
                }
            }
            return uniqueInstance;
        }
        public void InitializingZoneList()
        {
            try
            {
                XmlNodeList list = xmlHelper.GetXmlNodeList(configPath, "/Config/site/zone");
                foreach (System.Xml.XmlNode nl in list)
                {
                    Zone ze = new Zone();
                    ze.SectionID = nl.Attributes["section_id"].Value;
                    ze.ZoneName = nl.Attributes["zone_name"].Value;
                    ze.ZoneID = nl.Attributes["zone_id"].Value;
                    ze.ZoneType = nl.Attributes["zone_type"].Value;
                    int _pLevel;
                    ze.ZoneLevel = int.TryParse(nl.Attributes["zone_level"].Value, out _pLevel) ? _pLevel : 0;
                    Debug.Assert(ze.ZoneLevel > 0, "区段警戒级别小于等于'0',请检查巡守区段配置文件");
                    m_pZoneLists.Add(ze);
                }
            }
            catch { };

        }
        public List<Zone> ZoneLists
        {
            get { return m_pZoneLists; }
        }
        public List<Zone> GetShouldInspectList(int nLevel)
        {
            List<Zone> _pZoneList = new List<Zone>();
            foreach (Zone ze in m_pZoneLists)
            {

                if (ze.ZoneLevel.Equals(nLevel))
                {
                    _pZoneList.Add(ze);
                }

            }
            return _pZoneList;
        }
    }
}
