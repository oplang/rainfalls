using System.Collections.Generic;
using System.ComponentModel;
using rainfalls.Base.Struct;
using System.Threading;
using rainfalls.Abstract.Interface;

namespace rainfalls.Abstract.Class
{
    public abstract class ASectionObj : INotifyPropertyChanged
    {
        protected ALARMLEVEL[] m_pAlarmLevels = new ALARMLEVEL[100];
        private int m_nAlarmLevels;
        private List<ASiteObj> m_pSiteObjList = new List<ASiteObj>();
        protected List<AVirtualSection> m_pVirtualSectionList = new List<AVirtualSection>();
        public event PropertyChangedEventHandler PropertyChanged;
        private SynchronizationContext m_SyncContext = SynchronizationContext.Current;
        protected string[] worksdone = { "正常", "出巡", "限速", "扣车[客]", "扣车[货]", "限速~出巡", "扣车~出巡" };
        //protected string[] todo = { "无", "巡查线路", "限速行车", "扣发列车", "单击解除限速警戒", "单击开通区间", "出巡解除" };
        protected Dictionary<int, string> todo = new Dictionary<int, string>();
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
        #region 属性
        private string m_pSeeWarn = "查看";
        public string SeeWarn
        {
            get { return m_pSeeWarn; }
            set { m_pSeeWarn = value; }
        }
        public List<AVirtualSection> VirtualSectionList
        {
            get { return m_pVirtualSectionList; }
        }

        private LEVELINFO m_pCurLevelInfo;
        public LEVELINFO LastLevelInfo
        {
            get { return m_pCurLevelInfo; }
            set { m_pCurLevelInfo = value; }
        }
        private _autoLiftLevelInfo m_pLiftLevelInfo;
        public _autoLiftLevelInfo LiftLevelInfo
        {
            get { return m_pLiftLevelInfo; }
            set { m_pLiftLevelInfo = value; }
        }
        public List<ASiteObj> SiteObjList
        {
            get { return m_pSiteObjList; }
        }
        public ALARMLEVEL[] AlarmLevels
        {
            get { return m_pAlarmLevels; }
        }
        private string m_pID;
        /// <summary>
        /// 区间标识
        /// </summary>
        public string ID
        {
            get { return m_pID; }
            set { m_pID = value;  }
        }
        private string m_pLineName;
        public string LineName
        {
            get { return m_pLineName; }
            set { m_pLineName = value; }
        }
        private string m_pXingBieName;
        public string XingBieName
        {
            get { return m_pLineName+"~"+m_pXingBieName; }
            set { m_pXingBieName = value; }
        }
        private string m_pSectionName;
        public string SectionName
        {
            get { return m_pSectionName; }
            set { m_pSectionName = value; }
        }
        private string m_pLevelFormat;
        public string LevelFormat
        {
            get { return m_pLevelFormat; }
            set { m_pLevelFormat = value; NotifyPropertyChanged("LevelFormat"); }
        }
        private string m_pHadMeasure;
        public string HadMeasure
        {
            get { return m_pHadMeasure; }
            set { m_pHadMeasure = value; NotifyPropertyChanged("HadMeasure"); }
        }

        private int m_nCurLevel;
        public int SectionAlarmLevel
        {
            get { return m_nCurLevel; }
            set { m_nCurLevel = value; }
        }

        public int AlarmLevelsCount
        {
            get { return m_nAlarmLevels; }
            set { m_nAlarmLevels = value; }
        }
        private long m_nPatrolledTime;
        public long PatrolledTime
        {
            get { return m_nPatrolledTime; }
            set { m_nPatrolledTime = value; }
        }
        private string m_pWeatherWarning;
        /// <summary>
        /// 气象预警
        /// </summary>
        public string WeatherWarning
        {
            get { return m_pWeatherWarning; }
            set { m_pWeatherWarning = value; }
        }

        private IRainfallsDBHelper m_pDBHelper;

        public IRainfallsDBHelper DBHelper
        {
            get { return m_pDBHelper; }
            set { m_pDBHelper = value; }
        }
        #endregion
        #region 公共方法
        public void AddSiteObject(ASiteObj site)
        {
            m_pSiteObjList.Add(site);
        }
        #endregion
        #region 抽象方法
        public abstract void AlarmComputer(LEVELINFO li);
        public abstract void InitializeComponent();
        protected abstract void doGetDef();
        public abstract void SaveLevelInfo(LEVELINFO li);
        protected abstract void ReadJson();
        protected abstract void SaveJson();
        public abstract void UpdataLevel(int oldLevel, int newLevel,string site_id);
        public abstract bool ManualLiftComputer();
        #endregion
    }
}
