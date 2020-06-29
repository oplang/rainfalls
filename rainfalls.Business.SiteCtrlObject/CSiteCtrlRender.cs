using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rainfalls.Abstract.Class;
using rainfalls.Base.Class;
using rainfalls.Base.Struct;
using rainfalls.Abstract.Interface;
namespace rainfalls.Business.SiteCtrlObject
{
    public class CSiteCtrlRender:AMonitoringSite
    {
        protected override bool IsSameWorkDay(long t1, long t2)
        {
            long t;
            System.DateTime lt1 = new DateTime();
            System.DateTime lt2 = new DateTime();
            if (t1 > t2)
            {
                t = t2;
                t2 = t1;
                t1 = t;
            }
            if (difftime(t2, t1) > 24 * 3600)
                return false;

            //转换时间 TimetToSystemTime(t1 + 8 * 3600, &lt1);
            //转换时间 TimetToSystemTime(t2 + 8 * 3600, &lt2);
            lt1 = Time.DbTime2DateTime(t1);
            lt2 = Time.DbTime2DateTime(t2);
            if (lt1.Day == lt2.Day)
            {
                if (lt1.Hour < 18 && lt2.Hour >= 18)
                    return false;
                else
                    return true;
            }
            else
            {
                if (lt1.Hour >= 18 && lt2.Hour >= 0 && lt2.Hour < 18)
                    return true;
                else
                    return false;
            }
        }

        protected override int difftime(long t1, long t2)
        {
            return (int)(t1 - t2);
        }

        protected override void readClickData()
        {
            g_nRecords = m_dbHelper.readData(m_siteId, g_pList);
            if (g_nRecords > 0)
                m_siteCtrlRainInfo = m_rainCalc.getNewRainInfo(g_pList, g_nRecords, g_pList[g_nRecords - 1].contJmp);
        }

        protected override void saveClickData()
        {
            for (int i = 0; i <= m_newClicks.Length - 1; i++)
            {
                RFCLICK click = new RFCLICK();
                click.tm = m_newClicks[i].tm;
                if (0 == g_nRecords)
                {
                    click.numJmp = click.contJmp = 1;
                    m_siteState.clearLiftDefValue();
                    m_siteState.contJumpTime = click.tm;
                }
                else
                {
                    if (!IsSameWorkDay(click.tm, g_pList[g_nRecords - 1].tm))
                    {
                        click.numJmp = 1;
                        m_siteState.numJumpTime = click.tm;
                        if (difftime(click.tm, g_pList[g_nRecords - 1].tm) > 24 * 3600)
                        {
                            m_siteState.numJumpTime = click.tm;
                            m_siteState.contJumpTime = click.tm;
                            click.contJmp = 1;
                            m_siteState.clearLiftDefValue();
                            //清空配置文件
                        }
                        else
                        {
                            click.contJmp = g_pList[g_nRecords - 1].contJmp + 1;
                        }
                    }
                    else
                    {
                        click.numJmp = g_pList[g_nRecords - 1].numJmp + 1;
                        click.contJmp = g_pList[g_nRecords - 1].contJmp + 1;
                    }

                }
                g_pList[g_nRecords].tm = click.tm;
                g_pList[g_nRecords].numJmp = click.numJmp;
                g_pList[g_nRecords].contJmp = click.contJmp;
                ++g_nRecords;
                m_dbHelper.writeRainData(click, m_siteId);
            }
            drawRainMap();
            alarmLevel();
            m_siteCtrlRainInfo = m_rainCalc.getNewRainInfo(g_pList, g_nRecords, g_pList[g_nRecords - 1].contJmp);
        }

        protected override void alarmLevel()
        {
            m_levelCalc.Update(g_pList, g_nRecords, m_siteState);
            callParentAlarmFunction();
        }

        protected override long getStopTime(long tm)
        {
            long i, j, t;
            if (0 == g_nRecords)
                return 0;
            else if (tm < g_pList[0].tm)
                return 0;
            t = 0; j = 0;
            for (i = 0; i < g_nRecords; i++)
            {
                if (g_pList[i].tm >= tm)
                {
                    if (g_pList[i].contJmp < j)
                        return t;
                }
                else
                {
                    j = g_pList[i].contJmp;
                    t = g_pList[i].tm;
                }
            }
            return g_pList[i - 1].tm;
        }
    }
}
