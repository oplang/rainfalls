using System.ComponentModel;
using System.Threading;
using rainfalls.Base.Struct;
using System;
using rainfalls.Base.Class;
using rainfalls.Abstract.Interface;
using System.Collections.Generic;
namespace rainfalls.Abstract.Class
{
    public delegate void ClearVirtualLevelStateDelgate();
    public abstract class ASiteObj : INotifyPropertyChanged
    {
        protected LEVELINFO m_pCurLevelInfo;
        public event PropertyChangedEventHandler PropertyChanged;
        private SynchronizationContext m_SyncContext = SynchronizationContext.Current;
        protected List<ILevelCalc> m_pLeveCalcs = new List<ILevelCalc>();
        public event ClearVirtualLevelStateDelgate OnClearVirtualLevelStateEvent;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                if (m_SyncContext == null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
                else
                {
                    //此处采用上下文同步方式发送消息，你当然也可以使用异步方式发送,异步方法为m_SyncContext.Post
                    m_SyncContext.Send(p => PropertyChanged(this, new PropertyChangedEventArgs(propertyName)), null);

                }

            }
        }

        protected int g_nRecords = 0;
        public int Records
        {
            get { return g_nRecords; }
        }
        public RFCLICK[] RainClickLists
        {
            get { return g_pList; }
        }
        protected RFCLICK[] g_pList = new RFCLICK[1024 * 128];
        #region 对象属性
        private IRainfallsDBHelper m_pDbHelper;

        public IRainfallsDBHelper DbHelper
        {
            get { return m_pDbHelper; }
            set { m_pDbHelper = value; }
        }

        private Observer m_pObserver;
        public Observer SiteObserver
        {
            set { m_pObserver = value; }
            get { return m_pObserver; }
        }
        #endregion

        /// <summary>
        /// 降雨过程开始时间
        /// </summary>
        private long m_lContJumpTime;

        public long ContJumpTime
        {
            get { return m_lContJumpTime; }
            set { m_lContJumpTime = value; }
        }
        /// <summary>
        /// 日降雨开始时间
        /// </summary>
        private long m_lNumJumpTime;

        public long NumJumpTime
        {
            get { return m_lNumJumpTime; }
            set { m_lNumJumpTime = value; }
        }
        #region 属性

        private bool m_bRealtime;
        /// <summary>
        /// 是否为实时雨量
        /// </summary>
        public bool IsRealTime
        {
            get { return m_bRealtime; }
            set { m_bRealtime = value; }
        }
        private long m_nBeginTime;
        public long BeginTime
        {
            get { return m_nBeginTime; }
            set { m_nBeginTime = value; }
        }
        private string m_pSectionID;
        public string SectionID
        {
            get { return m_pSectionID; }
            set { m_pSectionID = value; }
        }
        private ARTU_daemon m_pRTUdaemon;
        public ARTU_daemon RTUdaemon
        {
            get { return m_pRTUdaemon; }
            set { m_pRTUdaemon = value; }
        }
        private string m_pType;
        public string Type
        {
            get { return m_pType; }
            set { m_pType = value; }
        }
        private string m_pSiteID;
        public string SiteID
        {
            get { return m_pSiteID; }
            set { m_pSiteID = value; NotifyPropertyChanged("SiteID"); }
        }
        private string m_pSiteName;
        public string SiteName
        {
            get { return m_pSiteName; }
            set { m_pSiteName = value; NotifyPropertyChanged("SiteName"); }
        }
        private string m_pSiteKM;
        public string SiteKM
        {
            get { return m_pSiteKM; }
            set { m_pSiteKM = value; NotifyPropertyChanged("SiteKM"); }
        }
        private string m_pContRain;
        public string ContRain
        {
            get { return m_pContRain; }
            set { m_pContRain = value; NotifyPropertyChanged("ContRain"); }
        }
        private string m_p10M;
        public string Rain10M
        {
            get { return m_p10M; }
            set { m_p10M = value; NotifyPropertyChanged("Rain10M"); }
        }

        private string m_p1HRain;
        public string Rain1H
        {
            get { return m_p1HRain; }
            set { m_p1HRain = value; NotifyPropertyChanged("Rain1H"); }
        }
        private string m_p3HRain;
        public string Rain3H
        {
            get { return m_p3HRain; }
            set { m_p3HRain = value; NotifyPropertyChanged("Rain3H"); }
        }

        private string m_p12HRain;
        public string Rain12H
        {
            get { return m_p12HRain; }
            set { m_p12HRain = value; NotifyPropertyChanged("Rain12H"); }
        }
        private string m_p24HRain;
        public string Rain24H
        {
            get { return m_p24HRain; }
            set { m_p24HRain = value; NotifyPropertyChanged("Rain24H"); }
        }
        private string m_p7Day;
        public string Rain7Day
        {
            get { return m_p7Day; }
            set { m_p7Day = value; NotifyPropertyChanged("Rain7Day"); }
        }

        private string m_pStartRainTime = "无";
        public string RainProStartTime
        {
            get { return m_pStartRainTime; }
            set { m_pStartRainTime = value; NotifyPropertyChanged("RainProStartTime"); }
        }
        private string m_pStopRainTime = "无";
        public string RainProStopTime
        {
            get { return m_pStopRainTime; }
            set { m_pStopRainTime = value; NotifyPropertyChanged("RainProEndTime"); }
        }
        private string m_pSectionsName;
        public string SectionsName
        {
            get { return m_pSectionsName; }
            set { m_pSectionsName = value; NotifyPropertyChanged("SectionsName"); }
        }

        private long m_nLastTime;
        public long LastTime
        {
            get { return m_nLastTime; }
            set { m_nLastTime = value; }
        }


        #endregion
        #region 抽象方法
        /// <summary>
        /// 站点报警计算
        /// </summary>
        /// <param name="alarmLevels">区间警戒值</param>
        /// <returns>返回报警信息</returns>
        public abstract void RainfallCoumpter();
        public abstract bool IsRainStop();
        public abstract LEVELINFO LevelCalc(ALARMLEVEL[] alarmLevels, int rows, AVirtualSection avobj);
        public abstract bool DoCanLiftLevel(long warningtime, int level, int liftvalue, ref _autoLiftLevelInfo liftinfo);
        public abstract void InitializeComponent();
        public abstract void ReceviedData(rtuClick[] newClick);
        protected abstract void WriteSiteJson();
        protected abstract void ReadSiteJson();
        public abstract long getStopTime(long tm);


        #endregion

        #region 父类方法
        public virtual string GetLastTime()
        {
            if (g_nRecords > 1)
            {
                return g_pList[g_nRecords - 1].tm.ToString();
            }
            else
            {
                return "0";
            }
        }
        public virtual void StartRTUdaemon()
        {
            if (this.Type.Equals("ssl"))
            {
                if (m_pRTUdaemon != null)
                {
                    m_pRTUdaemon.receviedNewClickEvent += new OnReceviedNewClickEvent(ReceviedData);
                    m_pRTUdaemon.runninng(this);
                }
            }
        }
        public virtual void StopRTUdaemon()
        {
            if (this.Type.Equals("ssl"))
                if (m_pRTUdaemon != null)
                    m_pRTUdaemon.Dispose();
        }
        protected virtual void Cleanup()
        {
            //更换降雨过程时，清空所有虚拟区间的重新计算雨量起算点
            if (OnClearVirtualLevelStateEvent != null)
                OnClearVirtualLevelStateEvent();
        }
        protected virtual int difftime(long t1, long t2)
        {
            return (int)(t1 - t2);
        }
        protected virtual bool IsSameWorkDay(long t1, long t2)
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
        #endregion
    }
}
