using System;
using System.Collections.Generic;
using System.Text;
using rainfalls.Abstract.Interface;
using System.Runtime.CompilerServices;
using rainfalls.Base.Struct;
using System.Data;
using rainfalls.Base.Class;
using System.IO;
using System.Threading;
using rainfalls.Abstract.Class;
namespace rainfalls.Business.DbHelper
{
    public class rainfallsDBHelper : IRainfallsDBHelper, IDisposable
    {
        private Thread m_pTimeThread = null;
        protected bool disposed = false;
        private Queue<string> strList = new Queue<string>(10);
        private IDataUpload m_pUploadObj;
        private static rainfallsDBHelper uniqueInstance;
        private static readonly object padlock = new object();
        private IDbHelper m_sqliteManager;
        private string m_dbTableName = "rain";
        private const string m_dbSectionLogRain = "section_log_rain";
        private const string m_dbTempCash = "dbCash";
        //private CDataUpload m_pDataUpload;
        private rainfallsDBHelper(IDbHelper sqliteHelper, IDataUpload obj)
        {
            m_pUploadObj = obj;
            m_sqliteManager = sqliteHelper;
            m_dbTableName += System.DateTime.Now.Year;
            CheckTempCash();
            checkRainTableExits();
            checkLastTimeTableExits();
            DeleteRunLog();
            checkLogRainTableExits();
            m_pTimeThread = new Thread(new ThreadStart(OnTimerSend));
            m_pTimeThread.Start();
        }
        public static rainfallsDBHelper getInstance(IDbHelper sqliteHelper, IDataUpload obj)
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new rainfallsDBHelper(sqliteHelper, obj);
                    }
                }
            }
            return uniqueInstance;
        }
        public IDataUpload MtupSync
        {
            set { m_pUploadObj = value; }
        }
        private void CheckTempCash()
        {
            string sql = string.Format("SELECT COUNT(*) FROM sqlite_master where type='table' and name='{0}'", m_dbTempCash);
            if (m_sqliteManager.ExcuteSql(sql) == 0)
            {
                sql = string.Format("CREATE TABLE {0} (uuid text PRIMARY KEY,time text,db text,isUpload text)", m_dbTempCash);
                m_sqliteManager.ExcuteSql(sql);
            }
            sql = string.Format("delete from {0} where time<'{1}'", m_dbTempCash, Time.DateTime2DbTime(DateTime.Now) - 60 * 60 * 24 * 30);
            m_sqliteManager.ExcuteSql(sql);
            m_sqliteManager.ExcuteSql("vacuum");
        }
        private void DeleteRunLog()
        {
            string sql = string.Format("delete from site_log_run where tm<{0}", Time.DateTime2DbTime(System.DateTime.Now) - 7 * 24 * 3600);
            m_sqliteManager.ExcuteSql(sql);
            m_sqliteManager.ExcuteSql("vacuum");
        }
        private void checkRainTableExits()
        {
            string sql = string.Format("SELECT COUNT(*) FROM sqlite_master where type='table' and name='{0}'", m_dbTableName);
            if (m_sqliteManager.ExcuteSql(sql) == 0)
            {
                sql = string.Format("CREATE TABLE {0} (tm text,contJmp text,numJmp text,id text)", m_dbTableName);
                m_sqliteManager.ExcuteSql(sql);
            }
        }
        private void checkLogRainTableExits()
        {
            string sql = string.Format("SELECT COUNT(*) FROM sqlite_master where type='table' and name='{0}'", m_dbSectionLogRain);
            if (m_sqliteManager.ExcuteSql(sql) == 0)
            {
                sql = string.Format("CREATE TABLE {0} (uuid text PRIMARY KEY,secid text,site_id text,log_time text,tm1 text,tm2 text,note text,lift_time text,lift_value text,level text)"
                    , m_dbSectionLogRain);
                m_sqliteManager.ExcuteSql(sql);
            }
        }
        private void checkLastTimeTableExits()
        {
            
        }
        
        public void writeLastTime(string id, string value)
        {
            
        }
        public string readLastTime(string id)
        {
            string sql = string.Format("select max(tm) from {0} where id = '{1}'", m_dbTableName, id);
            DataSet ds = new DataSet();
            m_sqliteManager.QueryBySql(sql, ds);
            DataTable dt = ds.Tables[0];
            string tm = null;
            foreach (DataRow dr in dt.Rows)
            {
                tm = dr[0].ToString();
            }
            return tm;
        }
        public int readData(string id, RFCLICK[] g_pList)
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "delet.rqe"))
            {
                using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "delet.rqe"))
                {
                    string str = null;
                    while ((str = sr.ReadLine()) != null)
                    {
                        string sqldelete = string.Format("delete from rain2018 where id ='{0}' and tm>'{1}'", id, str);
                        m_sqliteManager.ExcuteSql(sqldelete);
                    }
                    
                }
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "delet.rqe");

            }
            string sql = string.Format("select * from '{0}' where id = '{1}'", m_dbTableName, id);
            DataSet ds = new DataSet();
            m_sqliteManager.QueryBySql(sql, ds);
            DataTable dt = ds.Tables[0];
            int g_nRecords = 0;
            foreach (DataRow dr in dt.Rows)
            {
                g_pList[g_nRecords].tm = long.Parse(dr[0].ToString());
                g_pList[g_nRecords].contJmp = int.Parse(dr[1].ToString());
                g_pList[g_nRecords].numJmp = int.Parse(dr[2].ToString());
                g_nRecords++;
            }

           
            return g_nRecords;
        }
        public void writeRainData(RFCLICK click, string id)
        {
            string sql = string.Format("insert into '{0}' values('{1}','{2}','{3}','{4}')", m_dbTableName, click.tm, click.contJmp, click.numJmp, id);
            string szData = string.Format("{0}&{1}&{2}&{3}&TE", id, click.tm, click.contJmp, click.numJmp);
            WriteToTempDB(szData);
            m_sqliteManager.ExcuteSql(sql);
        }
        public void SSLUploadData(RFCLICK click, string id)
        {
            string szData = string.Format("{0}&{1}&{2}&{3}&TE", id, click.tm, click.contJmp, click.numJmp);
            WriteToTempDB(szData);
        }
        private void WriteToTempDB(string szData)
        {
            string uuid = System.Guid.NewGuid().ToString("N");
            string sql = string.Format("insert into {0} values('{1}','{2}','{3}','{4}')",m_dbTempCash,uuid,Time.DateTime2DbTime(DateTime.Now), szData,"0");
            m_sqliteManager.ExcuteSql(sql);
            _DataCash _dbCash = new _DataCash();
            _dbCash.uuid = uuid;
            _dbCash.db = szData;
            RealSendTenTime(_dbCash);
        }
        private void ChangeDbCashState(string uuid)
        {
            string sql = string.Format("update {0} set isUpload = '{1}' where uuid='{2}'", m_dbTempCash, 1, uuid);
            m_sqliteManager.ExcuteSql(sql);
        }
        //private void DeleteToTempDB(string szData)
        //{
        //    string sql = string.Format("delete from tempdb where db='{0}'", szData);
        //    m_sqliteManager.ExcuteSql(sql);
        //    m_sqliteManager.ExcuteSql("vacuum");
        //}
        public void WriteWorksDoneLog(_WorksDoneLog log)
        {
            log.reg_tm = Time.DateTime2DbTime(System.DateTime.Now);
            string sql = string.Format("insert into site_log_worksdone values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", log.reg_tm, log.tm1, log.tm2, log.value, log.typelevel, log.hourValue, log.name, log.siteId);
            string szData = string.Format("{0}&{1}&{2}&{3}&{4}&{5}&{6}&{7}&HE", log.siteId, log.reg_tm, log.tm1, log.tm2, log.value, log.typelevel, log.hourValue, log.name);
            WriteToTempDB(szData);
            
            m_sqliteManager.ExcuteSql(sql);

        }
        public void ExchangeTime(ref long t1, ref long t2, int typelevel, LEVELINFO li)
        {
            int type = typelevel >> 16;
            if (type == TagType.tag_cont)
            {
                t2 = t1;
                t1 = li.contJmp;
            }
            if (type == TagType.tag_daily)
            {
                long t = t2;
                t2 = t1;
                t1 = t;// li.numJmp;
            }
        }
        public bool WriteRFlog(_RFLog log)
        {
            string sql = string.Format("insert into section_log_rain values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", log.uuid, log.section_id, log.site_id, log.logtime, log.tm1, log.tm2, log.note, log.lift_time, log.lift_value, log.level);
            string szData = string.Format("{0}&{1}&{2}&{3}&{4}&{5}&{6}&{7}&{8}&ZE", log.section_id, log.site_id, log.logtime, log.tm1, log.tm2, log.note, log.lift_time, log.lift_value, log.level);
            WriteToTempDB(szData);
            m_sqliteManager.ExcuteSql(sql);
            return true;
        }
        public bool UpDateRFlogDb(_RFLog log)
        {
            string sql = string.Format("update section_log_rain set tm2 = '{0}' where uuid = '{1}' ", log.tm2, log.uuid);
            string szData = string.Format("{0}&{1}&{2}&{3}&{4}&{5}&{6}&{7}&{8}&ZE", log.section_id, log.site_id, log.logtime, log.tm1, log.tm2, log.note, log.lift_time, log.lift_value, log.level);
            WriteToTempDB(szData);
            
            m_sqliteManager.ExcuteSql(sql);
            return true;
        }
        public void WriteSms(_SMS sms, LEVELINFO li)
        {
            sms.bulidTime = Time.DateTime2DbTime(System.DateTime.Now);
            ExchangeTime(ref sms.tm1, ref sms.tm2, sms.typelevel, li);
            string sql = string.Format("insert into site_log_sms values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", sms.bulidTime, sms.railLine, sms.km, sms.tm1, sms.tm2, sms.typelevel, sms.value, sms.hourValue);
            string szData = string.Format("{0}&{1}&{2}&{3}&{4}&{5}&{6}&{7}&{8}&BE", sms.siteId, sms.bulidTime, sms.railLine, sms.km, sms.tm1, sms.tm2, sms.typelevel, sms.value, sms.hourValue);
            WriteToTempDB(szData);
            
            m_sqliteManager.ExcuteSql(sql);
        }
        public void WriteSms(_SMS sms)
        {
            sms.bulidTime = Time.DateTime2DbTime(System.DateTime.Now);
            string sql = string.Format("insert into site_log_sms values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", sms.bulidTime, sms.railLine, sms.km, sms.tm1, sms.tm2, sms.typelevel, sms.value, sms.hourValue);
            string szData = string.Format("{0}&{1}&{2}&{3}&{4}&{5}&{6}&{7}&{8}&BE", sms.siteId, sms.bulidTime, sms.railLine, sms.km, sms.tm1, sms.tm2, sms.typelevel, sms.value, sms.hourValue);
            WriteToTempDB(szData);
            
            m_sqliteManager.ExcuteSql(sql);
        }
        public int GetRainLogRecords(_RFLog[] log, long t, string id)
        {
            string sql = string.Format("select * from section_log_rain where (log_time>{0} and log_time<={1}) and (site_id='{2}' and level<>'1') ",
                t, t + 24 * 3600,id);
            System.Data.DataSet ds = new System.Data.DataSet();
            int N = 0;
            if (m_sqliteManager.QueryBySql(sql, ds) > 0)
            {
                System.Data.DataTable dt = ds.Tables[0];
                foreach (System.Data.DataRow dr in dt.Rows)
                {
                    log[N].uuid = dr[0].ToString();
                    log[N].section_id = dr[1].ToString();
                    log[N].site_id = dr[2].ToString();
                    log[N].logtime = long.Parse(dr[3].ToString());
                    log[N].tm1 = long.Parse(dr[4].ToString());
                    log[N].tm2 = long.Parse(dr[5].ToString());
                    log[N].note = dr[6].ToString();
                    log[N].lift_time = dr[7].ToString();
                    log[N].lift_value = dr[8].ToString();
                    log[N].level = dr[9].ToString();
                    N++;
                }
            }
            else
                return 0;
            return N;
        }
        public _RFLog[] GetTrackBreakRecords(out int N, ASectionObj obj)
        {
            _RFLog[] log = new _RFLog[64];
            long stopTime = 0;
            long t;

            System.Data.DataSet ds = new System.Data.DataSet();
            string sql = string.Format("select * from section_log_rain where tm2 == 0 and secid ='{0}' order by log_time", obj.ID);
            N = 0;
            if (m_sqliteManager.QueryBySql(sql, ds) > 0)
            {
                System.Data.DataTable dt = ds.Tables[0];
                foreach (System.Data.DataRow dr in dt.Rows)
                {
                    t = long.Parse(dr[3].ToString());
                    if (t > 0)
                    {
                        foreach (AVirtualSection av in obj.VirtualSectionList)
                        {
                            if (dr[2].ToString().Equals(av.SiteID))
                                stopTime = av.SiteObj.getStopTime(t);
                        }

                        if (Time.DateTime2DbTime(System.DateTime.Now) - stopTime < 24 * 3600)
                        {

                            log[N].uuid = dr[0].ToString();
                            log[N].section_id = dr[1].ToString();
                            log[N].site_id = dr[2].ToString();
                            log[N].logtime = long.Parse(dr[3].ToString());
                            log[N].tm1 = long.Parse(dr[4].ToString());
                            log[N].tm2 = long.Parse(dr[5].ToString());
                            log[N].note = dr[6].ToString();
                            log[N].lift_time = dr[7].ToString();
                            log[N].lift_value = dr[8].ToString();
                            log[N].level = dr[9].ToString();
                            N++;
                        }
                    }
                }
            }
            return log;
        }
        public _RFLog GetTrackBreakRecords(string uuid)
        {
            _RFLog log = new _RFLog();

            System.Data.DataSet ds = new System.Data.DataSet();
            string sql = string.Format("select * from section_log_rain where  uuid ='{0}' ", uuid);
            if (m_sqliteManager.QueryBySql(sql, ds) > 0)
            {
                System.Data.DataTable dt = ds.Tables[0];
                foreach (System.Data.DataRow dr in dt.Rows)
                {
                    log.uuid = dr[0].ToString();
                    log.section_id = dr[1].ToString();
                    log.site_id = dr[2].ToString();
                    log.logtime = long.Parse(dr[3].ToString());
                    log.tm1 = long.Parse(dr[4].ToString());
                    log.tm2 = long.Parse(dr[5].ToString());
                    log.note = dr[6].ToString();
                    log.lift_time = dr[7].ToString();
                    log.lift_value = dr[8].ToString();
                    log.level = dr[9].ToString();

                }
            }
            return log;
        }
    
        public bool WriteRunLogInfoDB(string ID, string msg)
        {
            string sql = "insert into site_log_run values('" + Time.DateTime2DbTime(System.DateTime.Now) + "','null ','" + msg + "')";

            m_sqliteManager.ExcuteSql(sql);
            string szData = m_pUploadObj.GetCommSiteID() + "&" + Time.DateTime2DbTime(System.DateTime.Now) + "&" + msg+"-"+CSoftInfo.getInstance().Verson + "&GE";
            SendOnceToMTUP(szData);
            return true;
        }
        public int GetMeasuresLogRecords(_WorksDoneLog[] log)
        {
            //long t = CLevelCalc.G_LevelCalc.contJmpTime;
            string sql = "select * from site_log_worksdone where tm > '" + Time.DateTime2DbTime(DateTime.Parse(DateTime.Now.Year + "-" + "1" + "-1")) + "' order by tm desc";
            System.Data.DataSet ds = new System.Data.DataSet();
            int N = 0;
            if (m_sqliteManager.QueryBySql(sql, ds) > 0)
            {
                System.Data.DataTable dt = ds.Tables[0];
                foreach (System.Data.DataRow dr in dt.Rows)
                {
                    log[N].reg_tm = long.Parse(dr[0].ToString());
                    log[N].tm1 = long.Parse(dr[1].ToString());
                    log[N].tm2 = long.Parse(dr[2].ToString());
                    log[N].value = int.Parse(dr[3].ToString());
                    log[N].typelevel = int.Parse(dr[4].ToString());
                    log[N].hourValue = int.Parse(dr[5].ToString());
                    log[N].name = dr[6].ToString();
                    log[N].siteId = dr[7].ToString();

                    N++;
                }
            }
            else
                return 0;
            return N;
        }
        //----------------------------------------------------
        bool m_bIsExit = false;
        public void OnTimerSend()
        {
            do
            {
                Thread.Sleep(1000 * 60 * 1);
                
                try
                {
                    string sql = string.Format("select uuid,db  from {0} where isUpload ='0' LIMIT  300", m_dbTempCash);
                    DataSet ds = new DataSet();
                    m_sqliteManager.QueryBySql(sql, ds);
                    DataTable dt = ds.Tables[0];
                    //  WriteLogs(string.Format("检索临时库--记录数:{0}" ,dt.Rows.Count.ToString()));
                    foreach (DataRow dr in dt.Rows)
                    {
                        _DataCash _dbCash = new _DataCash();
                        _dbCash.uuid = dr[0].ToString(); 
                        _dbCash.db = dr[1].ToString(); 
                        RealSendTenTime(_dbCash);
                    }
                }
                catch (Exception e)
                {
                    // WriteLogs(string.Format("上传失败:{0}",e.Message));
                }

               
                //心跳包
                string szData = string.Format("{0}&{1}&{2}&OE", CSoftInfo.getInstance().MainSiteID, Time.DateTime2DbTime(DateTime.Now), CSoftInfo.getInstance().Verson);
                m_pUploadObj.SendData(szData);
            } while (!m_bIsExit);

        }
        private void WriteLogs(string context)
        {
            //var path = AppDomain.CurrentDomain.BaseDirectory + "service.log";
            //var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            //var sw = new StreamWriter(fs);
            //sw.BaseStream.Seek(0, SeekOrigin.End);
            //sw.WriteLine(string.Format("{0}:{1}", DateTime.Now.ToString(), context));

            //sw.Flush();
            //sw.Close();
            //fs.Close();
        }

        /////////////////上传代码\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        public void InitQueueR()
        {
            //if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "RQueue.rqe"))
            //{
            //    File.Create(AppDomain.CurrentDomain.BaseDirectory + "RQueue.rqe");
            //}
            //else
            //{
            //    using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "RQueue.rqe"))
            //    {
            //        string str = null;
            //        while ((str = sr.ReadLine()) != null)
            //            strList.Enqueue(str);
            //    }
            //    SendQueueDb();
            //}
        }
        //protected void WriteToQueueR(string szData)
        //{
        //    if (strList.Count == 10)
        //        strList.Dequeue();
        //    strList.Enqueue(szData);
        //    try
        //    {
        //        using (FileStream aFile = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "RQueue.rqe", FileMode.Create))
        //        {
        //            StreamWriter sw = new StreamWriter(aFile);
        //            foreach (object obj in strList)
        //                sw.WriteLine((string)obj);
        //            sw.Close();
        //        }
        //    }
        //    catch
        //    {
        //        return;
        //    }
        //    SendQueueDb();
        //}
        //void SendQueueDb()
        //{
        //    Thread t = new Thread(new ThreadStart(SendQueueRToMTUP), 262144);
           
        //    t.IsBackground = true;
        //    t.Name = "SendQueueDb";
        //    t.Start();
        //}
        //protected void SendQueueRToMTUP()
        //{
        //    try
        //    {
        //        string szData = null;
        //        foreach (object obj in strList)
        //        {
        //            szData += obj + "\r\n";
        //        }
        //        if (string.IsNullOrEmpty(szData))
        //            return;
        //        if (!m_pUploadObj.SendData(szData))
        //            WriteToTempDB(szData.Replace("\r\n", "<br>"));
        //    }
        //    catch { }
        //}

        void sendParameterized(object o)
        {
            _DataCash _pCash = (_DataCash)o;

            int iCount = 0;
            for (int i = 0; i < 6; i++)
            {
                if (m_pUploadObj.SendData(_pCash.db))
                {
                    iCount++;
                    break;
                }
            }
            if (iCount > 0)
                ChangeDbCashState(_pCash.uuid);
        }

        void sendRunLog(object o)
        {
            string szData = (string)o;
            m_pUploadObj.SendData(szData);
        }
        public struct _DataCash
        {
           public  string uuid;
           public string db;
        }
        protected void RealSendTenTime(_DataCash db)
        {
            Thread t = new Thread(new ParameterizedThreadStart(sendParameterized));
            t.Name = "SendTenTimeToMTUP";
            t.Start(db);
   
        }
        protected void SendOnceToMTUP(string szData)
        {
            Thread t = new Thread(new ParameterizedThreadStart(sendRunLog));
            t.Name = "sendRunLog";
            t.Start(szData);
        }
        public void Dispose()
        {
            m_bIsExit = true;
            if (!this.disposed)
            {
                try
                {
                    if (m_pTimeThread != null)
                        if (m_pTimeThread.IsAlive)
                            m_pTimeThread.Abort();
                }
                finally
                {
                    this.disposed = true;
                    GC.SuppressFinalize(this);
                }
            }
        }
  /*
   * 
   * 防洪巡守表Inspector,为了不修改数据库字段名，将person_id,存储WorkNumber(派工单)
   * 
   * 
   * 
   * 
   */
        public List<_InspectorInfo> GetAllInspectorList()
        {
            List<_InspectorInfo> pList = new List<_InspectorInfo>();
            string sql = "select * from Inspector order by warning_time desc ";
            System.Data.DataSet ds = new System.Data.DataSet();
            int N = 0;
            if (m_sqliteManager.QueryBySql(sql, ds) > 0)
            {
                System.Data.DataTable dt = ds.Tables[0];
                foreach (System.Data.DataRow dr in dt.Rows)
                {
                    _InspectorInfo _inspector = new _InspectorInfo();

                    _inspector.uuid = dr[0].ToString();
                    _inspector.warning_time = dr[1].ToString();
                    _inspector.section_id = dr[2].ToString();
                    _inspector.zone_name = dr[3].ToString();
                    _inspector.zone_type = dr[4].ToString();
                    _inspector.zone_id = dr[5].ToString();
                    _inspector.start_time = dr[6].ToString();
                    _inspector.stop_time = dr[7].ToString();
                    _inspector.person_mame = dr[8].ToString();
                    _inspector.person_type = dr[9].ToString();
                    _inspector.person_phone = dr[10].ToString();
                    _inspector.work_number = dr[11].ToString();
                    _inspector.inpector_state = dr[12].ToString();
                    pList.Add(_inspector);
                }
            }
            return pList;
        }
        public List<_InspectorInfo> GetInspectorList()
        {
            List<_InspectorInfo> pList = new List<_InspectorInfo>();
            string sql = "select * from Inspector where state < '2' ";
            System.Data.DataSet ds = new System.Data.DataSet();
            int N = 0;
            if (m_sqliteManager.QueryBySql(sql, ds) > 0)
            {
                System.Data.DataTable dt = ds.Tables[0];
                foreach (System.Data.DataRow dr in dt.Rows)
                {
                    _InspectorInfo _inspector = new _InspectorInfo();

                    _inspector.uuid = dr[0].ToString();
                    _inspector.warning_time = dr[1].ToString();
                    _inspector.section_id = dr[2].ToString();
                    _inspector.zone_name = dr[3].ToString();
                    _inspector.zone_type = dr[4].ToString();
                    _inspector.zone_id = dr[5].ToString();
                    _inspector.start_time = dr[6].ToString();
                    _inspector.stop_time = dr[7].ToString();
                    _inspector.person_mame = dr[8].ToString();
                    _inspector.person_type = dr[9].ToString();
                    _inspector.person_phone = dr[10].ToString();
                    _inspector.work_number = dr[11].ToString();
                    _inspector.inpector_state = dr[12].ToString();
                    pList.Add(_inspector);
                }
            }
            return pList;
        }
        public void InsertInspectorRecord(_InspectorInfo _pInfo)
        {
            string sql = "insert into Inspector values" +
                "('" + _pInfo.uuid + "','" + _pInfo.warning_time + "','" + _pInfo.section_id + "','" + _pInfo.zone_name + "','" + _pInfo.zone_type + "'," +
                "'" + _pInfo.zone_id + "','" + _pInfo.start_time + "','" + _pInfo.stop_time + "','" + _pInfo.person_mame + "','" + _pInfo.person_type + "'," +
                "'" + _pInfo.person_phone + "','" + _pInfo.work_number + "','" + _pInfo.inpector_state + "')";

            m_sqliteManager.ExcuteSql(sql);
            SyncInspectorData(_pInfo.uuid);
        }
        public void UpdatePerson(_InspectorInfo pInfo)
        {
            string sql = string.Format("update Inspector set start_time='{0}',person_name='{1}',person_type='{2}',person_phone='{3}',person_id='{4}', state='{5}' where uuid ='{6}'",
                pInfo.start_time, pInfo.person_mame, pInfo.person_type, pInfo.person_phone, pInfo.work_number, pInfo.inpector_state, pInfo.uuid);
            m_sqliteManager.ExcuteSql(sql);
            SyncInspectorData(pInfo.uuid);
        }
        public void UpdateWorkNumber(string number,string uuid)
        {
            string sql = string.Format("update Inspector set person_id='{0}' where uuid ='{1}'",
                number,uuid);
            m_sqliteManager.ExcuteSql(sql);
            SyncInspectorData(uuid);
        }
        public void UpdateInspectorDone(_InspectorInfo pInfo)
        {
            string sql = string.Format("update Inspector set end_time='{0}', state='{1}' where uuid ='{2}'",
                pInfo.stop_time, pInfo.inpector_state, pInfo.uuid);
            m_sqliteManager.ExcuteSql(sql);
            SyncInspectorData(pInfo.uuid);
        }
        private void SyncInspectorData(string uuid)
        {
            string sql = "select * from Inspector where uuid = '" + uuid + "' ";
            System.Data.DataSet ds = new System.Data.DataSet();
            int N = 0;
            if (m_sqliteManager.QueryBySql(sql, ds) > 0)
            {
                System.Data.DataTable dt = ds.Tables[0];
                foreach (System.Data.DataRow dr in dt.Rows)
                {
                    _InspectorInfo _inspector = new _InspectorInfo();

                    _inspector.uuid = dr[0].ToString();
                    _inspector.warning_time = dr[1].ToString();
                    _inspector.section_id = dr[2].ToString();
                    _inspector.zone_name = dr[3].ToString();
                    _inspector.zone_type = dr[4].ToString();
                    _inspector.zone_id = dr[5].ToString();
                    _inspector.start_time = dr[6].ToString();
                    _inspector.stop_time = dr[7].ToString();
                    _inspector.person_mame = dr[8].ToString();
                    _inspector.person_type = dr[9].ToString();
                    _inspector.person_phone = dr[10].ToString();
                    _inspector.work_number = dr[11].ToString();
                    _inspector.inpector_state = dr[12].ToString();
                    string szData = string.Format("{0}&{1}&{2}&{3}&{4}&{5}&{6}&{7}&{8}&{9}&XE",
                        _inspector.zone_id, _inspector.warning_time, _inspector.section_id, _inspector.start_time, _inspector.stop_time, 
                        _inspector.person_mame, _inspector.person_type,_inspector.person_phone, _inspector.work_number, _inspector.inpector_state);
                    WriteToTempDB(szData);
                   
                }
            }

        }
    }
}
