using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using rainfalls.Abstract.Class;

namespace rainfalls.Business.Site
{
    public class CSiteSerializer
    {
        #region 受保护的属性，站点警戒状态序列化存储
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
        #endregion
        public string GetJSON(ASiteObj obj)
        {
            this.ContJumpTime = obj.ContJumpTime;
            this.NumJumpTime = obj.NumJumpTime;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(this);
        }
    }
}
