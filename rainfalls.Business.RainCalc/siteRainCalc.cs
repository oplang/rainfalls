using System;
using rainfalls.Abstract.Interface;
using rainfalls.Base.Struct;
using rainfalls.Base.Class;
using rainfalls.Abstract.Class;
using System.Collections.Generic;
namespace rainfalls.Business.RainCalc
{
    public class siteRainCalc:IRainCalc
    {
        private List<ASectionObj> m_pSectionObjList;
        public void  setSectionObjList(List<ASectionObj> list)
        {
            m_pSectionObjList = list;
        }
        public int getMaxUnits(long start_time, int sec, _maxunit[] unit, ASiteObj site)
        {
            long h1, h2;
            int s, e;
            int delta;
            RFCLICK[] g_pList = site.RainClickLists;
            int g_nRecords = site.Records;
            if (0 == g_nRecords)
                return 0;

            for (s = 0, e = 1; s < g_nRecords - 1 && e < g_nRecords; ++s)
            {
                h1 = (g_pList[s].tm - start_time);
                if (h1 >= 0)
                    h1 /= 3600;
                h2 = (g_pList[e].tm - start_time);
                if (h2 >= 0)
                    h2 /= 3600;

                if (h1 >= 0 && h1 < 25 && h2 >= 0 && h2 < 25)
                {
                    while (e < g_nRecords && (g_pList[e].tm - g_pList[s].tm) < sec && h1 == h2)
                    {
                        delta = g_pList[e].numJmp - g_pList[s].numJmp + 1;
                        if (delta > unit[h1].max)
                        {
                            unit[h1].idx_end = (short)e;
                            unit[h1].idx_start = (short)s;
                            unit[h1].max = delta;
                            unit[h1].start = g_pList[s].tm;
                            unit[h1].end = g_pList[e].tm;
                        }
                        ++e;
                        if (e < g_nRecords)
                            h2 = (long)difftime(g_pList[e].tm, start_time) / 3600;
                    } // while
                }
                else
                    ++e;
            }
            int[] _start_mm = new int[48];
            int[] _mm = new int[48];
            getMMByHour(start_time, 25, _start_mm, _mm,site);

            return 1;
        }
        public  int difftime(long t1, long t2)
        {
            return (int)(t1 - t2);
        }
        public void getMMByHour(long t0 /* start time */, int hours, int[] start_mm, int[] mm, ASiteObj site)
        {
            long diff;
            int h;
            int i;
            RFCLICK[] g_pList = site.RainClickLists;
            int g_nRecords = site.Records;
            RFCLICK m_startClick;
            m_startClick.tm = 0;
            m_startClick.contJmp = 0;
            for (int j = 0; j < g_nRecords; j++)
            {
                if (g_pList[j].tm < t0)
                {
                    m_startClick.tm = g_pList[j].tm;
                    m_startClick.contJmp = g_pList[j].contJmp;
                }
                else
                {
                    break;
                }
            }
            diff = m_startClick.tm - t0;
            if (diff > -24 * 3600 && diff < 0)
            {
                for (h = 0; h < (diff + 24 * 3600 + 3599) / 3600; h++)
                {
                    start_mm[h] = m_startClick.contJmp;
                }
            }
            for (i = 0; i < g_nRecords; i++)
            {
                diff = g_pList[i].tm - t0;
                if (diff >= 0 && diff < hours * 3600)
                {
                    for (h = (int)((diff + 3599) / 3600); h <= Math.Min((diff + 24 * 3600 + 3599) / 3600, hours); h++)
                    {
                        start_mm[h] = g_pList[i].contJmp;
                    }
                    mm[diff / 3600]++;
                }
            }
            return;
        }


        public long getEndTime(long t0, bool bIsRealTime, int g_nRecords, RFCLICK[] g_pList)
        {
            throw new NotImplementedException();
        }

        public siteCtrlRainInfo getNewRainInfo(RFCLICK[] g_pList, int N, int contRain)
        {
            throw new NotImplementedException();
        }

        public long getStartime(long t0, bool bIsRealTime, int g_nRecords, RFCLICK[] g_pList)
        {
            throw new NotImplementedException();
        }


        public string getLineName(string sectionid)
        {
            foreach (ASectionObj sec in m_pSectionObjList)
            {
                if (sec.ID.Equals(sectionid))
                    return sec.LineName;
            }
            return null;
        }

        public string getQjName(string sectionid)
        {
            foreach (ASectionObj sec in m_pSectionObjList)
            {
                if (sec.ID.Equals(sectionid))
                    return sec.SectionName;
            }
            return null;
        }

        public string getXingbieName(string sectionid)
        {
            foreach (ASectionObj sec in m_pSectionObjList)
            {
                if (sec.ID.Equals(sectionid))
                    return sec.XingBieName;
            }
            return null;
        }
    }
}
