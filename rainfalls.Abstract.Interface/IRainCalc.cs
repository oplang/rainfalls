using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rainfalls.Base.Struct;
using rainfalls.Abstract.Class;
namespace rainfalls.Abstract.Interface
{
    public interface IRainCalc
    {
        siteCtrlRainInfo getNewRainInfo(RFCLICK[] g_pList, int N, int contRain);
        int getMaxUnits(long start_time, int sec, _maxunit[] unit, ASiteObj site);
        void getMMByHour(long t0 /* start time */, int hours, int[] start_mm, int[] mm, ASiteObj site);
        long getStartime(long t0, bool bIsRealTime, int g_nRecords, RFCLICK[] g_pList);
        long getEndTime(long t0, bool bIsRealTime, int g_nRecords, RFCLICK[] g_pList);
        string getLineName(string sectionid);
        string getQjName(string sectionid);
        string getXingbieName(string sectionid);
        void setSectionObjList(List<ASectionObj> list);
    }
}
