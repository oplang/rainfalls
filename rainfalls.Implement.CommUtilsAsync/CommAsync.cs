using System;
using System.Collections.Generic;
using System.Text;
using rainfalls.Abstract.Class;
using rainfalls.Base.Struct;
using rainfalls.Base.Class;
namespace rainfalls.Implement.CommUtilsAsync
{
    public class CommAsync :ACommUtilsAsync
    {
        private int g_nRecords = 0;
        public override void saveClickData()
        {
            RFCLICK click = new RFCLICK();
            click.tm = Time.DateTime2DbTime(System.DateTime.Now);
            if (0 == g_nRecords)
            {
                click.numJmp = click.contJmp = 1;
                clickPoint.Clear();
                contAndDailyTime.contJumpTime = click.tm;
                XmlConfig.writeContStartTime(contAndDailyTime.contJumpTime.ToString());
                //初始化配置参数
            }
            else
            {
                if (!IsSameWorkDay(click.tm, g_pList[g_nRecords - 1].tm))
                {
                    click.numJmp = 1;
                    contAndDailyTime.numJumpTime = click.tm;
                    XmlConfig.writeDailyStartTime(click.tm.ToString());
                    if (difftime(click.tm, g_pList[g_nRecords - 1].tm) > 24 * 3600)
                    {
                        contAndDailyTime.numJumpTime = click.tm;
                        XmlConfig.writeDailyStartTime(click.tm.ToString());
                        contAndDailyTime.contJumpTime = click.tm;
                        XmlConfig.writeContStartTime(contAndDailyTime.contJumpTime.ToString());
                        click.contJmp = 1;
                        clickPoint.Clear();
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
            //写入数据库

            CSQLite.G_CSQLite.InertRainToDB(click);
            OneMinuteIsThan40(click.tm);
        }
    }
}
