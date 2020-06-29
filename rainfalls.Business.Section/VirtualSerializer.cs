using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rainfalls.Abstract.Class;
using System.Web.Script.Serialization;

namespace rainfalls.Business.Section
{
    public class VirtualSerializer
    {
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
        public string GetJSON(AVirtualSection obj)
        {
            FreightBreakOpenValue = obj.FreightBreakOpenValue;
            FreightBreakOpenTime = obj.FreightBreakOpenTime;
            BreakOpenTime = obj.BreakOpenTime;
            BreakOpenValue = obj.BreakOpenValue;
            LiftSpeedTime = obj.LiftSpeedTime;
            LiftSpeedValue = obj.LiftSpeedValue;
            PatrolTime = obj.PatrolTime;
            PatrolValue = obj.PatrolValue;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(this);
        }
    }
}
