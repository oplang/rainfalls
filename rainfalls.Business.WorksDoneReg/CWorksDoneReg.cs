using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rainfalls.Base.Struct;
using rainfalls.Base.Class;
namespace rainfalls.Business.WorksDoneReg
{
    /// <summary>
    /// 
    /// </summary>
    public class CWorksDoneReg
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <param name="level">5,扣车开通6,限速解除</param>
        /// <param name="Reason"></param>
        /// <param name="hourValue"></param>

        public static void GetWorksReason(long t1, long t2, int value, int type, int level/*5,扣车开通4,限速解除*/, ref string Reason, long hourValue)
        {
            string[] leveltext = new string[10] {"出巡警戒值","限速运行标准", "扣发客车标准",
		"扣发货车标准", "扣车开通标准","出巡解除标准",
		"7级警戒值","8级警戒值","9级警戒值","10级警戒值"};
            if (level > -5 && level < 11)
            {
                System.DateTime tm1 = Time.DbTime2DateTime(t1);
                System.DateTime tm2 = Time.DbTime2DateTime(t2);
                switch (type)
                {
                    case TagType.tag_delta:
                        if (hourValue > 0)
                            Reason = tm1.ToString("MM") + "月" + tm1.ToString("dd") + "日" + tm1.ToString("HH") + ":" + tm1.ToString("mm") + "—"
                               + tm2.ToString("MM") + "月" + tm2.ToString("dd") + "日" + tm2.ToString("HH") + ":" + tm2.ToString("mm") +
                               "降雨量增加" + value / 10 + "." + value % 10 + "mm，一小时雨强为" + hourValue / 10 + "." + hourValue % 10 + "mm，已达到" + leveltext[level - 1];
                        else
                            Reason = tm1.ToString("MM") + "月" + tm1.ToString("dd") + "日" + tm1.ToString("HH") + ":" + tm1.ToString("mm") + "—"
                               + tm2.ToString("MM") + "月" + tm2.ToString("dd") + "日" + tm2.ToString("HH") + ":" + tm2.ToString("mm") +
                               "降雨量增加" + value / 10 + "." + value % 10 + "mm，已达到" + leveltext[level - 1];
                        break;
                    case TagType.tag_cont:

                        if (hourValue > 0)
                            Reason = tm1.ToString("MM") + "月" + tm1.ToString("dd") + "日" + tm1.ToString("HH") + ":" + tm1.ToString("mm") +
                                "连续降雨量为" + value / 10 + "." + value % 10 + "mm，一小时雨强为" + hourValue / 10 + "." + hourValue % 10 + "mm，已达到" + leveltext[level - 1];
                        else
                            Reason = tm1.ToString("MM") + "月" + tm1.ToString("dd") + "日" + tm1.ToString("HH") + ":" + tm1.ToString("mm") +
                            "连续降雨量为" + value / 10 + "." + value % 10 + "mm，已达到" + leveltext[level - 1];

                        break;
                    case TagType.tag_daily:
                        Reason = tm1.ToString("MM") + "月" + tm1.ToString("dd") + "日" + tm1.ToString("HH") + ":" + tm1.ToString("mm") +
                        " 累计"+ t2 + "天降雨量为" + value / 10 + "." + value % 10 + "mm，并且间隔小于48小时，已达到夜间" + leveltext[level - 1];
                        break;
                    case TagType.tag_hourcont:
                        Reason = tm1.ToString("MM") + "月" + tm1.ToString("dd") + "日" + tm1.ToString("HH") + ":" + tm1.ToString("mm") +
                                "  24小时连续降雨量为" + value / 10 + "." + value % 10 + "mm，一小时雨强为" + hourValue / 10 + "." + hourValue % 10 + "mm，已达到夜间" + leveltext[level - 1];
                        break;
                    case TagType.tag_open:
                        if (level == -1)
                            Reason = tm1.ToString("MM") + "月" + tm1.ToString("dd") + "日" + tm1.ToString("HH") + ":" + tm1.ToString("mm") + "—"
                           + tm2.ToString("MM") + "月" + tm2.ToString("dd") + "日" + tm2.ToString("HH") + ":" + tm2.ToString("mm") +
                           "一小时雨量小于" + value / 10 + "." + value % 10 + "mm，已达到出巡解除标准";
                        else if (level == -2)
                            Reason = tm1.ToString("MM") + "月" + tm1.ToString("dd") + "日" + tm1.ToString("HH") + ":" + tm1.ToString("mm") + "—"
                                + tm2.ToString("MM") + "月" + tm2.ToString("dd") + "日" + tm2.ToString("HH") + ":" + tm2.ToString("mm") +
                                "一小时雨量小于" + value / 10 + "." + value % 10 + "mm，已达到限速解除标准";
                        else if (level == -3)
                            Reason = tm1.ToString("MM") + "月" + tm1.ToString("dd") + "日" + tm1.ToString("HH") + ":" + tm1.ToString("mm") + "—"
                                + tm2.ToString("MM") + "月" + tm2.ToString("dd") + "日" + tm2.ToString("HH") + ":" + tm2.ToString("mm") +
                                "一小时雨强小于" + value / 10 + "." + value % 10 + "mm，并持续半小时，已达到客车开通标准";
                        else if (level == -4)
                            Reason = tm1.ToString("MM") + "月" + tm1.ToString("dd") + "日" + tm1.ToString("HH") + ":" + tm1.ToString("mm") + "—"
                                + tm2.ToString("MM") + "月" + tm2.ToString("dd") + "日" + tm2.ToString("HH") + ":" + tm2.ToString("mm") +
                                "一小时雨强小于" + value / 10 + "." + value % 10 + "mm，并持续半小时，已达到货车开通标准";
                        break;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="level">5,扣车开通4,限速解除</param>
        /// <param name="WorksDone"></param>
        public static void GetWorksDone(int level/*5,扣车开通4,限速解除*/, ref string WorksDone)
        {
            Dictionary<int, string> todo = new Dictionary<int, string>();
            
            try
            {
                todo.Add(0, "无");
                todo.Add(1, "派人巡查线路");
                todo.Add(2, "登记运统46，限速行车并登乘机车检查");
                todo.Add(3, "登记运统46，扣发客运列车");
                todo.Add(4, "登记运统46，扣发货运列车");
                todo.Add(-1, "恢复常速");
                todo.Add(-2, "第一列限速开通线路,其后常速");
                todo.Add(-3, "单击解除客车封锁");
                todo.Add(-4, "单击解除货车封锁");
                WorksDone =  todo[level];
            }
            catch (Exception e)
            {
                //throw new Exception(e.Message+"-----"+level.ToString());
            }
        }

    }
}
