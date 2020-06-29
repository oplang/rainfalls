
using rainfalls.Base.Struct;
namespace rainfalls.Abstract.Class
{
    public abstract class AVirtualSection
    {
        private LEVELINFO m_pVirtualLevelInfo;
        public LEVELINFO VirtualLevelInfo
        {
              get { return m_pVirtualLevelInfo; }
            set { m_pVirtualLevelInfo = value; }
        }
        private string m_pSectionID;
        public string SectionID
        {
            get { return m_pSectionID; }
            set { m_pSectionID = value; }
        }
        private string m_pSiteID;
        public string SiteID
        {
            get { return m_pSiteID; }
            set { m_pSiteID = value; }
        }
        private ASiteObj m_pSiteObj;
        public ASiteObj SiteObj
        {
            get { return m_pSiteObj; }
            set { m_pSiteObj = value; }
        }
        private int m_nVirtualLevel;
        public int VirtualLevel
        {
            get { return m_nVirtualLevel; }
            set { m_nVirtualLevel = value; }
        }

        #region 受保护的属性，站点警戒状态，将要序列化存储
        /// <summary>
        /// 解除限速时的雨量
        /// </summary>
        private int m_nLiftSpeedValue;

        public int LiftSpeedValue
        {
            get { return m_nLiftSpeedValue; }
            set { m_nLiftSpeedValue = value; }
        }
        /// <summary>
        /// 解除限速时的时间
        /// </summary>
        private long m_lLiftSpeedTime;

        public long LiftSpeedTime
        {
            get { return m_lLiftSpeedTime; }
            set { m_lLiftSpeedTime = value; }
        }
        /// <summary>
        /// 开通扣车时的雨量
        /// </summary>
        private int m_nBreakOpenValue;

        public int BreakOpenValue
        {
            get { return m_nBreakOpenValue; }
            set { m_nBreakOpenValue = value; }
        }
        /// <summary>
        /// 开通扣车时的时间
        /// </summary>
        private long m_lBreakOpenTime;

        public long BreakOpenTime
        {
            get { return m_lBreakOpenTime; }
            set { m_lBreakOpenTime = value; }
        }

        /// <summary>
        /// 达到出巡警戒值的雨量
        /// </summary>
        private int m_nPatrolValue;

        public int PatrolValue
        {
            get { return m_nPatrolValue; }
            set { m_nPatrolValue = value; }
        }
        /// <summary>
        /// 达到出巡时的时间
        /// </summary>
        private long m_lPatrolTime;

        public long PatrolTime
        {
            get { return m_lPatrolTime; }
            set { m_lPatrolTime = value; }
        }

        /// <summary>
        /// 货车开通扣车时的雨量
        /// </summary>
        private int m_nFreightBreakOpenValue;

        public int FreightBreakOpenValue
        {
            get { return m_nFreightBreakOpenValue; }
            set { m_nFreightBreakOpenValue = value; }
        }
        /// <summary>
        /// 货车开通扣车时的时间
        /// </summary>
        private long m_lFreightBreakOpenTime;

        public long FreightBreakOpenTime
        {
            get { return m_lFreightBreakOpenTime; }
            set { m_lFreightBreakOpenTime = value; }
        }
        #endregion
        public abstract LEVELINFO VirtualLevelCalc(ALARMLEVEL[] alarmLevels, int rows);
        public abstract bool DoCanLiftLevel(int level, int value, long tm);
        public abstract _autoLiftLevelInfo GetLiftLevelInof();
        public abstract void AVSaveJson();
        public abstract void BindClearEvent();
        protected void ClearLevelState()
        {
            FreightBreakOpenValue = 0;
            FreightBreakOpenTime = 0;
            LiftSpeedValue = 0;
            LiftSpeedTime = 0;
            BreakOpenTime = 0;
            BreakOpenValue = 0;
            PatrolTime = 0;
            PatrolValue = 0;
            AVSaveJson();
        }
    }

}
