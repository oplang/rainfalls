using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;

namespace rainfalls.Business.InspectorLab
{
    /*
     * 巡守人员信息
     * 2018-03-21编写
     */
    public class Person
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
   
        private string m_pPersonState;
        /// <summary>
        /// 巡守人员状态
        /// </summary>
        public string PersonState
        {
            get { return m_pPersonState; }
            set { m_pPersonState = value; }
        }
        public string StateFormat
        {
            get { if (PersonState.Equals("1")) return "巡守中"; else return "空闲"; }
        }
    }
}
