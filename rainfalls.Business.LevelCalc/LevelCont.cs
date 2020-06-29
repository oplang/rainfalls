using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rainfalls.Abstract.Interface;
using rainfalls.Base.Struct;
using rainfalls.Abstract.Class;
using rainfalls.Base.Class;
namespace rainfalls.Business.LevelCalc
{
    public class LevelCont : ILevelCalc
    {

        public int Calc(ALARMLEVEL[] alarmLevels, int rows, int nRecords, RFCLICK[] g_pList, ASiteObj obj, ref LEVELINFO pLevelinfo, AVirtualSection avobj)
        {
            int i, hourRain;
            hourRain = 0;
            long N = nRecords;
            for (i = 0; i < rows; ++i)
            {
                if (alarmLevels[i].tag != TagType.tag_cont)
                    continue;
                hourRain = alarmLevels[i].dur * 10;
                if (alarmLevels[i].level == 1)
                {
                    if (g_pList[N - 1].contJmp == alarmLevels[i].delta * 10)
                    {
                        if (i < rows)
                        {
                            pLevelinfo.site_id = obj.SiteID;
                            pLevelinfo.t1 = Time.DateTime2DbTime(System.DateTime.Now);
                            pLevelinfo.t2 = 0;
                            pLevelinfo.delta = g_pList[N - 1].contJmp;
                            pLevelinfo.level = alarmLevels[i].level;
                            pLevelinfo.tag = TagType.tag_cont;
                            pLevelinfo.TRAIN = alarmLevels[i].TRAIN;
                        }
                        else
                            return -1;
                    }
                }
                else
                {
                    if (hourRain <= 0)
                    {
                        if (g_pList[N - 1].contJmp == alarmLevels[i].delta * 10)
                        {
                            if (i < rows)
                            {
                                pLevelinfo.site_id = obj.SiteID;
                                pLevelinfo.t1 = Time.DateTime2DbTime(System.DateTime.Now);
                                pLevelinfo.t2 = 0;
                                pLevelinfo.delta = g_pList[N - 1].contJmp;
                                pLevelinfo.level = alarmLevels[i].level;
                                pLevelinfo.tag = TagType.tag_cont;
                                pLevelinfo.hValue = hourRain;
                                pLevelinfo.liftValue = alarmLevels[i].liftValue;
                                pLevelinfo.liftTime = 600;
                                pLevelinfo.TRAIN = alarmLevels[i].TRAIN;
                            }
                            else
                                return -1;
                        }
                    }
                    else
                    {
                        if (g_pList[N - 1].contJmp >= alarmLevels[i].delta * 10)
                        {
                            int nDouble = 0;
                            switch (alarmLevels[i].level)
                            {
                                
                                case 2:
                                    nDouble = hourRain + avobj.LiftSpeedValue;
                                    break;
                                case 3:
                                    nDouble = hourRain + avobj.BreakOpenValue;
                                    break;
                                case 4:
                                    nDouble = hourRain + avobj.FreightBreakOpenValue;
                                    break;
                            }
                            if (N >= nDouble)
                            {
                                long span = 0;
                                if (hourRain > 0)
                                    span = g_pList[N - 1].tm - g_pList[N - hourRain].tm;
                                else
                                    span = g_pList[N - 1].tm - g_pList[N - 1].tm;
                                if (span <= 3600)
                                {
                                    if (i < rows)
                                    {
                                        pLevelinfo.site_id = obj.SiteID;
                                        pLevelinfo.t1 = Time.DateTime2DbTime(System.DateTime.Now);
                                        pLevelinfo.t2 = 0;
                                        pLevelinfo.delta = g_pList[N - 1].contJmp;
                                        pLevelinfo.level = alarmLevels[i].level;
                                        pLevelinfo.tag = TagType.tag_cont;
                                        pLevelinfo.hValue = hourRain;
                                        pLevelinfo.liftValue = alarmLevels[i].liftValue;
                                        pLevelinfo.liftTime = 600;
                                        pLevelinfo.TRAIN = alarmLevels[i].TRAIN;
                                    }
                                    else
                                        return -1;
                                }
                            }
                        }

                    }
                }
            }
            return pLevelinfo.level;
        }
    }
}
