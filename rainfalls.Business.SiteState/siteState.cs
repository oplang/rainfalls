using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rainfalls.Abstract.Class;
using Zyf.Ini;
using rainfalls.path;
using rainfalls.Base.Struct;
namespace rainfalls.Business.SiteState
{
    public class siteState:ASiteState
    {
        public override void clearLiftDefValue()
        {
           // throw new NotImplementedException();
            m_nLiftSpeedValue = 0;
            CINIFile.IniWriteValue(m_szSiteId, liftCls.m_szLiftSpeedValue, "0", paths.rtuSitePath);
            m_nBreakOpenValue = 0;
            CINIFile.IniWriteValue(m_szSiteId, liftCls.m_szBreakOpenValue, "0", paths.rtuSitePath);
            m_lgLiftSpeedTime = 0;
            CINIFile.IniWriteValue(m_szSiteId, liftCls.m_szLiftSpeedTime, "0", paths.rtuSitePath);
            m_lgBreakOpenTime = 0;
            CINIFile.IniWriteValue(m_szSiteId, liftCls.m_szBreakOpenTime, "0", paths.rtuSitePath);
            m_lgContRainStartTime = 0;
            CINIFile.IniWriteValue(m_szSiteId, liftCls.m_szContRainStartTime, "0", paths.rtuSitePath);
            m_lgDayRainStartTime = 0;
            CINIFile.IniWriteValue(m_szSiteId, liftCls.m_szDayRainStartTime, "0", paths.rtuSitePath);
        }

        public override void doGetLiftDefValue()
        {
            int n;
            string szLiftSpeedValue = CINIFile.IniReadValue(m_szSiteId, liftCls.m_szLiftSpeedValue, paths.rtuSitePath);
            m_nLiftSpeedValue = int.TryParse(szLiftSpeedValue, out n) ? n :  0;
            string szBreakOpenValue = CINIFile.IniReadValue(m_szSiteId, liftCls.m_szBreakOpenValue, paths.rtuSitePath);
            m_nBreakOpenValue = int.TryParse(szBreakOpenValue, out n) ? n : 0;
            long t;
            string szLiftSpeedTime = CINIFile.IniReadValue(m_szSiteId, liftCls.m_szLiftSpeedTime, paths.rtuSitePath);
            m_lgLiftSpeedTime = long.TryParse(szLiftSpeedTime, out t) ? t : 0;
            string szBreakOpenTime = CINIFile.IniReadValue(m_szSiteId, liftCls.m_szBreakOpenTime, paths.rtuSitePath);
            m_lgBreakOpenTime = long.TryParse(szBreakOpenTime, out t) ? t : 0;
            string szContStartTime = CINIFile.IniReadValue(m_szSiteId, liftCls.m_szContRainStartTime, paths.rtuSitePath);
            m_lgContRainStartTime = long.TryParse(szContStartTime, out t) ? t : 0;
            string szDayStartTime = CINIFile.IniReadValue(m_szSiteId, liftCls.m_szDayRainStartTime, paths.rtuSitePath);
            m_lgDayRainStartTime = long.TryParse(szDayStartTime, out t) ? t : 0;
        }

        public override void saveValue(string key,string value)
        {
            CINIFile.IniWriteValue(m_szSiteId, key, value, paths.rtuSitePath);
        }
    }
}
