using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rainfalls.Abstract.Interface;
using rainfalls.Base.Struct;
using rainfalls.Abstract.Class;

namespace rainfalls.Business.LevelCalc
{
    public class LevelDelta : ILevelCalc
    {
        public int Calc(ALARMLEVEL[] alarmLevels, int rows, int nRecords, RFCLICK[] g_pList, ASiteObj obj, ref LEVELINFO pLevelinfo, AVirtualSection avobj)
        {
            int i, d, h;
            int N = nRecords;

            for (i = 0; i < rows; i++)
            {
                if (alarmLevels[i].tag != TagType.tag_delta)
                    continue;
                int span = 0;
                d = alarmLevels[i].delta * 10;
                switch (alarmLevels[i].level)
                {
                    case 1:
                        span = d + avobj.PatrolValue;
                        break;
                    case 2:
                        span = d + avobj.LiftSpeedValue;
                        break;
                    case 3:
                        span = d + avobj.BreakOpenValue;
                        break;
                    case 4:
                        span = d + avobj.FreightBreakOpenValue;
                        break;
                }
                if (N >= span)
                {
                    if (g_pList[N - 1].tm - g_pList[N - d].tm <= alarmLevels[i].dur * 60)
                    {
                        if (alarmLevels[i].level > pLevelinfo.level)
                        {
                            pLevelinfo.dur = alarmLevels[i].dur.ToString();
                            pLevelinfo.level = alarmLevels[i].level;
                            pLevelinfo.delta = d;
                            pLevelinfo.t1 = g_pList[N - d].tm;
                            pLevelinfo.t2 = g_pList[N - 1].tm;
                            pLevelinfo.tag = TagType.tag_delta;
                            pLevelinfo.liftValue = alarmLevels[i].liftValue;
                            pLevelinfo.liftTime = 600;
                            pLevelinfo.site_id = obj.SiteID;
                            pLevelinfo.TRAIN = alarmLevels[i].TRAIN;
                        }
                    }
                }
            }
            return pLevelinfo.level;
        }
    }
}
