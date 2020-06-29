using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Threading;
namespace Update
{
    public class CSQLite
    {
        public static CSQLite G_CSQLite = null;
        protected IDbManager m_pDbManager = null;
        protected IDbManager m_pDbSend = null;
        protected string dbtable = "rain";
        public CSQLite(IDbManager dbManager, IDbManager tpManager)
        {
            m_pDbManager = dbManager;
            m_pDbSend = tpManager;
            dbtable += System.DateTime.Now.Year;
        }
        public bool WriteRunLogInfoDB(string errID, string msg,string szVersion)
        {
            string tm = Time.DateTime2DbTime(System.DateTime.Now).ToString();
            msg += "(" + szVersion + ")";
            string szData = tm + "&" + errID + "&RE";
            string sql = "insert into site_log_run values('" + tm + "','" + errID + "','" + msg + "')";
            try
            {
                m_pDbManager.ExcuteSql(sql);
            }
            catch
            {
            }
            finally
            {
                WriteToTempDB(szData);
            }
            return true;
        }
        public void WriteToTempDB(string szData)
        {
            string sql = "insert into db values('" + szData + "')";
            m_pDbSend.ExcuteSql(sql);
        }
        public class Time
        {
            //DateTime ========>  UTC Local time
            public static long DateTime2DbTime(System.DateTime dt)
            {
                long l = dt.ToFileTime();
                return (long)((l - 116444736000000000) / 10000000);
            }

            //UTC Local Time =======> DateTime
            public static System.DateTime DbTime2DateTime(long dbTime)
            {
                long l = dbTime * 10000000 + 116444736000000000;
                System.DateTime dt = System.DateTime.FromFileTime(l);
                return dt;
            }
        }
    }
}
