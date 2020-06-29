using rainfalls.Abstract.Class;
using rainfalls.Abstract.Interface;
using rainfalls.Base.Class;
using rainfalls.Base.Struct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rainfalls.Business.LevelCalc
{
    public class LevelDaily : ILevelCalc
    {
        public int Calc(ALARMLEVEL[] alarmLevels, int rows, int nRecords, RFCLICK[] g_pList, ASiteObj obj, ref LEVELINFO pLevelinfo, AVirtualSection avobj)
        {
            int i, hourRain, d;
            hourRain = 0;
            long N = nRecords;
            for (i = 0; i < rows; ++i)
            {
                if (alarmLevels[i].tag != TagType.tag_daily)
                    continue;
                hourRain = alarmLevels[i].dur * 10;
                long _nLiftTime = 0;
                //int span = 0;
                //d = alarmLevels[i].delta * 10;
                //switch (alarmLevels[i].level)
                //{
                //    case 1:
                //        span = d + avobj.PatrolValue;
                //        break;
                //    case 2:
                //        span = d + avobj.LiftSpeedValue;
                //        _nLiftTime = avobj.LiftSpeedTime;
                //        break;
                //    case 3:
                //        span = d + avobj.BreakOpenValue;
                //        break;
                //    case 4:
                //        span = d + avobj.FreightBreakOpenValue;
                //        break;
                //}
                long _nNow = g_pList[N - 1].tm;
                if (_nNow - _nLiftTime >= alarmLevels[i].dur * 24 * 3600)
                {
                    long _nStart = _nNow - alarmLevels[i].dur * 24 * 3600;
                    int _nRain = 0;
                    while (N >= 1)
                    {
                        if (g_pList[N - 1].tm <= _nNow && g_pList[N - 1].tm >= _nStart)
                        {
                            _nRain++;
                            if (N == 1)
                                break;
                            if (g_pList[N - 1].tm - g_pList[N - 2].tm >= 48 * 3600)
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                        N--;
                    }
                    if (_nRain >= alarmLevels[i].delta * 10)
                    {
                        if (i < rows)
                        {
                            pLevelinfo.site_id = obj.SiteID;
                            pLevelinfo.t1 = Time.DateTime2DbTime(System.DateTime.Now);
                            pLevelinfo.t2 = alarmLevels[i].dur;
                            pLevelinfo.delta = alarmLevels[i].delta * 10;
                            pLevelinfo.level = alarmLevels[i].level;
                            pLevelinfo.tag = TagType.tag_daily;
                            pLevelinfo.liftValue = alarmLevels[i].liftValue;
                            pLevelinfo.liftTime = 600;
                            pLevelinfo.TRAIN = alarmLevels[i].TRAIN;
                        }
                        else
                            return -1;
                    }
                }
            }
            return pLevelinfo.level;
        }
    }
}

