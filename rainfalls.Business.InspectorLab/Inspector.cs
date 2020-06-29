using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rainfalls.Abstract.Class;
using rainfalls.Base.Class;
using System.ComponentModel;
using System.Threading;
using System.Diagnostics;
namespace rainfalls.Business.InspectorLab
{
    public class Inspector
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private SynchronizationContext m_SyncContext = SynchronizationContext.Current;
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
        #region 巡守任务信息-----------------------------
        private string m_pUUID;
        public string UUID
        {
            set { if (string.IsNullOrEmpty(m_pUUID)) m_pUUID = value; }
            get { return m_pUUID; }
        }
        private string m_pWarning_time;
        public string WarningTime
        {
            get { return m_pWarning_time; }
            set { m_pWarning_time = value; }
        }
        private string m_pSectionID;
        public string SectionID
        {
            get { return m_pSectionID; }
            set { m_pSectionID = value; }
        }
        private string m_pStartTime;
        public string StartTime
        {
            get { return m_pStartTime; }
            set { m_pStartTime = value;  }
        }
        public string StartTimeFormat
        {
            get { return TimeFormat(m_pStartTime); }
        }
        private string m_pStopTime;
        public string StopTime
        {
            get { return m_pStopTime; }
            set { m_pStopTime = value;  }
        }

        public string StopTimeFormat
        {
            get { return TimeFormat(m_pStopTime); }
        }
        private string m_pInspectorState;
        /// <summary>
        /// 巡守状态 (0-区间报警,派人巡守)-(1巡守中)-（2巡守结束）
        /// </summary>
        public string InspectorState
        {
            get { return m_pInspectorState; }
            set { m_pInspectorState = value; m_pStateFormat = value; }
        }
        private string m_pStateFormat;
        public string StateFormat
        {
            get { return StateString(m_pStateFormat); }
            set { m_pStateFormat = value; NotifyPropertyChanged("StateFormat"); }
        }
        private string m_pWorkNumber;
        public string WorkNumber
        {
            get { return m_pWorkNumber; }
            set { m_pWorkNumber = value; }
        }
        #endregion --------------------------------------

        #region 巡守区段-----------------------------------
        private string m_pZoneName;
        /// <summary>
        /// 巡守名称
        /// </summary>
        public string ZoneName
        {
            set { m_pZoneName = value; NotifyPropertyChanged("ZoneName"); }
            get { return m_pZoneName; }
        }
        private string m_pZoneID;
        /// <summary>
        /// 巡守标识
        /// </summary>
        public string ZoneID
        {
            set { m_pZoneID = value; }
            get { return m_pZoneID; }
        }
        private string m_pZoneType;
        /// <summary>
        /// 巡守类型（区段|看守点）
        /// </summary>
        public string ZoneType
        {
            set { m_pZoneType = value; }
            get { return m_pZoneType; }
        }
        #endregion  
        private int m_nZoneLevel;
        public int ZoneLevel
        {
            set { m_nZoneLevel = value; }
            get { return m_nZoneLevel; }
        }
        #region 巡守人员--------------------------------------------------

        private string m_pPersonName;
        /// <summary>
        /// 巡守人员姓名
        /// </summary>
        public string PersonName
        {
            get { return m_pPersonName; }
            set { m_pPersonName = value; }
        }
 
        private string m_pPersonType;
        /// <summary>
        /// 巡守人员类型（正式|临时）
        /// </summary>
        public string PersonType
        {
            get { return m_pPersonType; }
            set { m_pPersonType = value; }
        }
   
        private string m_pPersonPhone;
        /// <summary>
        /// 巡守人员手机号码
        /// </summary>
        public string PersonPhone
        {
            get { return m_pPersonPhone; }
            set { m_pPersonPhone = value; }
        }
        private string m_pPersonID;
        /// <summary>
        /// 巡守人员身份证号码
        /// </summary>
        public string PersonID
        {
            get { return m_pPersonID; }
            set { m_pPersonID = value; }
        }

        #endregion -----------------------------------------------------

        
        public void AddPersonToInspector(Person p)
        {
            this.PersonID = p.PersonID;
            this.PersonName = p.PersonName;
            this.PersonPhone = p.PersonPhone;
            this.PersonType = p.PersonType;
        }
        private string TimeFormat(string lzTime)
        {
            if (string.IsNullOrEmpty(lzTime))
                return "";
            return Time.DbTime2DateTime(long.Parse(lzTime)).ToString();
        }
        private  string StateString(string pState)
        {
            string _pState = "";
            int _nState;
            if (int.TryParse(pState, out _nState))
            {
                Debug.Assert((_nState == 1 || _nState == 0 || _nState == 2), "巡守状态不是有效的数值");
                if (pState == "0")
                {
                    _pState = "准备";
                }
                if (pState == "1")
                {
                    _pState = "巡守中[" + PersonName + "]";
                }
                if (pState == "2")
                {
                    _pState = "巡守结束";
                }
            }
            Debug.Assert(_pState != "", "巡守状态字符串格式化错误");
            return _pState;

        }
    }
}
