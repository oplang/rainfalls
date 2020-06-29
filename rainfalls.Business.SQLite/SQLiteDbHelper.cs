using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rainfalls.Abstract.Interface;
using System.Data.SQLite;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Threading;
namespace rainfalls.Base.SQLite
{
    public class SQLiteDbHelper : IDbHelper
    {
        private IDBManager m_SQLiteConnectionPool;
        private readonly string TAG = "SQLiteDbHelper";
        private string mConnectionString = "";//连接字符串 
        //  private SysProperty sysProperty;
        private const string SYS_PROPERTY = "\\rainfalls.sqlite";
        #region IDbHelper 成员
        public SQLiteDbHelper()
        {
           
        }
        private string getConnString()
        {
            SQLiteConnectionStringBuilder pConStr = new SQLiteConnectionStringBuilder();
            pConStr.DataSource = Application.StartupPath + SYS_PROPERTY;
            //throw new Exception(AppDomain.CurrentDomain.BaseDirectory + SYS_PROPERTY);
            mConnectionString = pConStr.ToString();
            return mConnectionString;
        }
        private SQLiteConnection getConnection()
        {
            SQLiteConnection newConn = new SQLiteConnection();
            newConn.ConnectionString = getConnString();
            try
            {
                newConn.Open();
            }
            catch 
            {
                newConn = null;
            }
            return newConn;
        }
        public int ExcuteSql(string sql)
        {


            int n = 0;
           
            using (SQLiteConnection conn = getConnection())
            {
                if (conn == null)
                    return -2;
                try
                {
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                  //  Monitor.Enter(obj);
                    n = cmd.ExecuteNonQuery();
                   // Monitor.Exit(obj);
                }
                catch (Exception e)
                {
                    if (e.Message.Contains("Duplicate"))
                        n = -1;
                    //Log.WriteErrorLog(TAG, e.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
           
            return n;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public int QueryBySql(string sql, System.Data.DataSet ds)
        {

            int n = 0;
            using (SQLiteConnection conn = getConnection())
            {
                if (conn == null)
                    return -2;
                try
                {
                    SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                    da.Fill(ds);
                    if (ds.Tables.Count > 0)
                    {
                        n = ds.Tables[0].Rows.Count;
                    }
                }
                catch
                {
                    //Log.WriteErrorLog(TAG, e.Message);
                    n = -1;
                }
                finally
                {
                    conn.Close();
                }
            }
            return n;
        }

        #endregion
    }
}
