using System;
using System.Collections.Generic;
using System.Text;
using rainfalls.Abstract.Interface;
using System.Data.SQLite;
using System.Threading;
using System.Data;
using System.Runtime.CompilerServices;
using System.IO;
namespace rainfalls.Base.SQLite
{
    public class SQLiteConnectionPool
    {
      
        private string mConnectionString = "";//连接字符串 
      //  private SysProperty sysProperty;
        private const string SYS_PROPERTY = "rainfalls.sqlite";
        private static SQLiteConnectionPool uniqueInstance;
        private static readonly object padlock = new object();

        private SQLiteConnectionPool()
        {
          
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static SQLiteConnectionPool getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new SQLiteConnectionPool();
                    }
                }
            }
            return uniqueInstance;
        }
      

        public string getConnString()
        {
            //if (string.IsNullOrEmpty(mConnectionString))
            //{
            //    XmlHelper.XmlHelper xml = new XmlHelper.XmlHelper(Path.Combine(SYS_PROPERTY), false, "config");
            //    mConnectionString = string.Format("Database={0};Data Source={1};User Id={2};Password={3};pooling=true;CharSet=gb2312;port=3306;",
            //        xml.getAttribute("/config", "dbname"), xml.getAttribute("/config", "ip"), xml.getAttribute("/config", "userid"), xml.getAttribute("/config", "pwsid"));
            //}
            SQLiteConnectionStringBuilder pConStr = new SQLiteConnectionStringBuilder();
            pConStr.DataSource = AppDomain.CurrentDomain.BaseDirectory + SYS_PROPERTY;
     
            mConnectionString = pConStr.ToString();
            return mConnectionString;
        }
        public  SQLiteConnection createConnection()
        {
            lock (this)
            {
                SQLiteConnection newConn = new SQLiteConnection();
                newConn.ConnectionString = getConnString();
                try
                {
                    newConn.Open();
                }
                catch (Exception e)
                {
                    //Log.Log.WriteErrorLog(TAG, e.Message);
                }
                return newConn;
            }
        }
    
    }
}
