using System;
using System.Collections.Generic;
using System.Text;
namespace rainfalls.Base.Struct
{

    public struct siteCtrlRainInfo
    {
        public int rainCont;
        public int rain1H;
        public int rain3H;
    }
    public struct siteRainInfo
    {
        public string siteId;
        public int contRain;
        public int n1hRain;
        public int n3HRain;
    }
    public struct siteInfo
    {
        public string id;
        public string section;
        public string section_id;
        public string km;
    }
    public struct siteBaseInfo
    {
        public string siteSection;
        public string siteName;
        public string siteId;
        public string siteKm;
    }
    public static class workAreaCls
    {
        public static string section = "工区信息";
        public static string siteName = "站点名称";
        public static string xianBie = "线别";
        public static string siteId = "站点标识";
        public static string siteKm = "站点里程";
        public static string siteQj = "站点区间";
        public static string siteDevId = "设备标识";
        public static string siteMtupId = "MTUP_ID";
        public static string siteMtupIP = "MTUP_IP";
        public static string webServiceAddress = "WEB服务_IP";
        public static string siteCurLevel = "当前警戒级别";
    }
    public static class liftCls
    {
        public static string m_szLiftSpeedValue = "解除限速时雨量值";
        public static string m_szLiftSpeedTime = "解除限速时间";
        public static string m_szBreakOpenValue = "解除扣车时雨量值";
        public static string m_szBreakOpenTime = "解除扣车时间";
        public static string m_szContRainStartTime = "连续雨量开始时间";
        public static string m_szDayRainStartTime = "日降雨量开始时间";
    }
    public struct workAreaStruct
    {
        public string site_id;
        public string site_name;
        public string site_km;
        public string site_qj;
        public string siteDev_Id;
        public string siteMtup_Id;
        public string webServiceAddress;
        public string siteCurLevel;
        public string xianBie;
    }
    public class TagType
    {
        public const int tag_delta = 0x01;
        public const int tag_daily = 0x02;
        public const int tag_hourcont = 0x03;
        public const int tag_cont = 0x04;
        public const int tag_open = 0x05;
    }
    /// <summary>
    /// 雨量跳次结构
    /// </summary>
    public struct RFCLICK
    {
        public long tm;
        public int contJmp;
        public int numJmp;
    }
    /// <summary>
    /// 警戒值结构
    /// </summary>
    public struct ALARMLEVEL
    {
        public int c_time;
        public int dur;//时长
        public int delta;//雨量增加值
        public int level;//警戒级别  
        public int tag;//警戒值类型(1,2,3,4,5)
        public int liftValue;//解除条件
        public string TRAIN;
    }
    public struct _SMS
    {
        public string siteId;
        public long bulidTime;
        public string railLine;
        public string km;
        public long tm1;
        public long tm2;
        public int typelevel;
        public long value;
        public long hourValue;
    }
    public struct _RFLog
    {
        public string uuid;
        public string section_id;
        public string site_id;
        public long logtime;
        public long tm1;
        public long tm2;
        public string note;
        public string lift_time;
        public string lift_value;
        public string level;
    }
    public struct _WorksDoneLog
    {
        public string siteId;
        public long reg_tm;
        public long tm1;
        public long tm2;
        public int typelevel;
        public int value;
        public string name;
        public int hourValue;
    }
    public struct _RunLog
    {
        public long logtime;
        public string msg;
    }
    /// <summary>
    /// 报警结构
    /// </summary>
    public struct LEVELINFO
    {
        public string dur;
        public string site_id;
        public string site_km;
        public long contJmp;
        public long numJmp;
        public long t1, t2;          //t1为开始时间，t2为结束时间
        public int delta;          //达到报警时的雨量信息（一般为警戒值设定的值）
        public int level;             //警戒级别
        public int tag;               //可能是标记为报警类型
        public int hValue;       //不为空时，为连续雨量的一小时雨强
        public int liftValue;
        public int liftTime;
        public string TRAIN;
    }
    /// <summary>
    /// 设置限速、扣车解除时的雨量，因为下次雨量计算将以此点重新计算报警
    /// </summary>
    public struct _ClickPoint
    {
        public int restorePoint;//保存限速解除时的总雨量值
        public int openPoint;   //保存扣车解除时的总雨量值
        public int curLevel;
        public long limitOpen_time;
        public long breakOpen_time;
        public void Clear()
        {
            breakOpen_time = limitOpen_time = 0;
            curLevel = restorePoint = openPoint = 0;
        }
    }
    public struct _contAndDailyTime
    {
        public long contJumpTime;
        public long numJumpTime;
    }
    public struct _autoLiftLevelInfo
    {
        public string uuid;
        public string siteid;
        public long limitTime;
        public long t1;
        public long t2;
        public int value;
        public bool isAuto;
        public int level;
        public string secName;
        public string secid;
    }
    public struct _InspectorInfo
    {
        public string uuid;
        public string warning_time;
        public string section_id;
        public string zone_name;
        public string zone_type;
        public string zone_id;
        public string start_time;
        public string stop_time;
        public string person_mame;
        public string person_type;
        public string person_phone;
        public string work_number;
        public string inpector_state;
    }
    public struct _Km
    {
        public string dir;
        public string startKm;
        public string endKm;
    }
    public struct _maxunit
    {
        public long start;
        public long end;
        public int max;
        public short idx_start;
        public short idx_end;
    }
    public struct _measureslog
    {
        public string siteId;
        public long warning_time;
        public string warning_time_asc;
        public string reg_time_asc;
        public string reason;
        public int measure_id;
        public string name;
    }
    public struct _sitestatus
    {
        public int curLevel;
        public long limitOpen_time;
        public int limitOpen_rain;
        public long breakOpen_time;
        public int breakOpen_rain;
    }
    public struct rtuSiteSRC
    {
        public string TERM_SN;
        public string site_km;
        public string qj;
        public string site_name;
        public string site_id;
    }

    public struct rtuClick
    {
        public long tm;
        public string voltage;
    }
}
