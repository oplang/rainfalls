using System;
using rainfalls.Abstract.Class;
using rainfalls.Base.Struct;
using rainfalls.path;
using System.IO;
using System.Web.Script.Serialization;
using rainfalls.Base.Class;
using rainfalls.Abstract.Interface;
using rainfalls.Business.LevelCalc;
using System.Data.SQLite;
using System.Data;
using Zyf.Ini;
namespace rainfalls.Business.Site
{
    public class CSiteObj : ASiteObj
    {
        private string m_pJsonPath;
        private string m_pDbName;
        private string m_pTableName;
        public override LEVELINFO LevelCalc(ALARMLEVEL[] alarmLevels,int rows,AVirtualSection avobj)
        {
            LEVELINFO m_pLastLevelInfo = new LEVELINFO();
            LEVELINFO li = new LEVELINFO();
            int lvl = -1;
            int maxLevel = -1;
            foreach (ILevelCalc obj in m_pLeveCalcs)
            {
                lvl = obj.Calc(alarmLevels, rows, g_nRecords, g_pList, this, ref li, avobj);
                if (lvl > maxLevel)
                {
                    maxLevel = lvl;
                    m_pLastLevelInfo = li;
                }
            }
            return m_pLastLevelInfo;
        }

        public override void InitializeComponent()
        {
            
            m_pDbName = string.Format("{0}{1}.sqlite", paths.APPPATH, SiteID);
            m_pTableName = string.Format("rain{0}", DateTime.Now.Year);
            dbCreate();
            ILevelCalc levelDelta = new LevelDelta();
            m_pLeveCalcs.Add(levelDelta);
            ILevelCalc levelCont = new LevelCont();
            m_pLeveCalcs.Add(levelCont);
            ILevelCalc level24Cont = new Level24Cont();
            m_pLeveCalcs.Add(level24Cont);
            ILevelCalc levelDaily = new LevelDaily();
            m_pLeveCalcs.Add(levelDaily);

            m_pJsonPath = string.Format("{0}{1}.json", paths.APPPATH, SiteID);
            if (this.Type.Equals("ssl"))
            {
                readData();
            }
            else
            {
                g_nRecords = DbHelper.readData(SiteID, g_pList);
            }
            
           
            ReadSiteJson();
         //   this.RainfallCoumpter();
        }
        private void dbCreate()
        {
            if (!File.Exists(m_pDbName))
            {
                using (SQLiteConnection cn = new SQLiteConnection("data source=" + m_pDbName))
                {
                    cn.Open();
               
                }
            }
            if (File.Exists(m_pDbName))
            {
                using (SQLiteConnection cn = new SQLiteConnection("data source=" + m_pDbName))
                {
                    if (cn.State != System.Data.ConnectionState.Open)
                    {
                        cn.Open();
                        using (SQLiteCommand cmd = new SQLiteCommand())
                        {
                            cmd.Connection = cn;
                            cmd.CommandText = string.Format("CREATE TABLE IF NOT EXISTS {0} (tm text,contJmp text,numJmp text,id text,PRIMARY KEY (tm,contJmp))", m_pTableName);
                            cmd.ExecuteNonQuery();
                        }
                    }

                }
            }
            else
            {
                //没有找到该站点的数据文件
                throw new Exception(string.Format("没有找到采集点:[{0}]数据文件.数据将无法保存",SiteID));
            }
        }
        private void readData()
        {
            if (File.Exists(m_pDbName))
            {
                string sql = string.Format("select * from '{0}' where id = '{1}'", m_pTableName, SiteID);
                DataSet ds = new DataSet();
                using (SQLiteConnection cn = new SQLiteConnection("data source=" + m_pDbName))
                {
                    if (cn.State != System.Data.ConnectionState.Open)
                    {
                        cn.Open();
                        SQLiteDataAdapter da = new SQLiteDataAdapter(sql, cn);
                        da.Fill(ds);
                       
                    }
                }
                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    foreach (DataRow dr in dt.Rows)
                    {
                        g_pList[g_nRecords].tm = long.Parse(dr[0].ToString());
                        g_pList[g_nRecords].contJmp = int.Parse(dr[1].ToString());
                        g_pList[g_nRecords].numJmp = int.Parse(dr[2].ToString());
                        g_nRecords++;
                    }
                }
            }
        }
        private static readonly object padlock = new object();
        private void writeData(RFCLICK click)
        {
            
            string sql = string.Format("insert into '{0}' values('{1}','{2}','{3}','{4}')", m_pTableName, click.tm, click.contJmp, click.numJmp, SiteID);
            try
            {
                if (File.Exists(m_pDbName))
                {
                    using (SQLiteConnection cn = new SQLiteConnection("data source=" + m_pDbName))
                    {
                        if (cn.State != System.Data.ConnectionState.Open)
                        {
                            cn.Open();
                            using (SQLiteCommand cmd = new SQLiteCommand())
                            {
                                cmd.Connection = cn;
                                cmd.CommandText = sql;
                                lock (padlock)
                                {
                                    try
                                    {
                                        cmd.ExecuteNonQuery();
                                        DbHelper.SSLUploadData(click, this.SiteID);
                                    }
                                    catch { }
                                   
                                }
                                cmd.Dispose();
                            }
                            cn.Dispose();
                        }
                    }

                }
            }
            catch(Exception  e)
            {
            }
        }
        public override void ReceviedData(rtuClick[] newClick)
        {
            #region 雨量存储
            lock (this)
            {
                for (int i = 0; i <= newClick.Length - 1; i++)
                {
                    RFCLICK click = new RFCLICK() { tm = newClick[i].tm };
                    if (0 == g_nRecords)
                    {
                        click.numJmp = click.contJmp = 1;
                        Cleanup();
                        ContJumpTime = click.tm;
                    }
                    else
                    {
                        if (!IsSameWorkDay(click.tm, g_pList[g_nRecords - 1].tm))
                        {
                            click.numJmp = 1;
                            NumJumpTime = click.tm;
                            if (difftime(click.tm, g_pList[g_nRecords - 1].tm) > 24 * 3600)
                            {
                                Cleanup();
                                ContJumpTime = NumJumpTime = click.tm;
                                click.contJmp = 1;
                                //清空配置文件
                            }
                            else
                            {
                                click.contJmp = g_pList[g_nRecords - 1].contJmp + 1;
                            }
                        }
                        else
                        {
                            click.numJmp = g_pList[g_nRecords - 1].numJmp + 1;
                            click.contJmp = g_pList[g_nRecords - 1].contJmp + 1;
                        }

                    }
                    g_pList[g_nRecords].tm = click.tm;
                    g_pList[g_nRecords].numJmp = click.numJmp;
                    g_pList[g_nRecords].contJmp = click.contJmp;
                    ++g_nRecords;

                    if (this.Type.Equals("ssl"))
                    {

                        writeData(click);
                    }
                    else if (this.Type.Equals("comm"))
                    {
                        DbHelper.writeRainData(click, SiteID);
                    }
                    else
                    {
                        DbHelper.writeRainData(click, SiteID);
                    }
                }
            #endregion
                RainfallCoumpter();
                if (g_nRecords > 0)
                {

                    if (Time.DateTime2DbTime(DateTime.Now) - g_pList[g_nRecords - 1].tm > 3600)
                    {
                        //雨量图绘制
                        if (SiteObserver != null)
                        {
                            SiteObserver.DrawRainMapOnly(SiteID);
                        }
                    }
                    else
                    {
                        //区间报警 雨量图绘制
                        if (SiteObserver != null)
                        {
                            SiteObserver.Update(SiteID);
                        }
                    }
                }

                PostRefreshRainMapMessage();
            }
        }

        public override void RainfallCoumpter()
        {
            int nCount = CountHistoryRain();
            ContRain = string.Format("{0}.{1}", nCount / 10, nCount % 10);
            if (IsRealTime)
            {
                int nRain1h = getNearestRain(60 * 60);
                int nRain10m = getNearestRain(60 * 10);
                int nRain3h = getNearestRain(60 * 60 * 24*5);
                int nRain12h = getNearestRain(60 * 60 * 12);
                int nRain24h = getNearestRain(60 * 60 * 24);
                int nRain7Day = getNearestRain(60 * 60 * 24 * 7);
                Rain10M = string.Format("{0}.{1}", nRain10m / 10, nRain10m % 10);
                Rain1H = string.Format("{0}.{1}", nRain1h / 10, nRain1h % 10);
                Rain3H = string.Format("{0}.{1}", nRain3h / 10, nRain3h % 10);
                Rain12H = string.Format("{0}.{1}", nRain12h / 10, nRain12h % 10);
                Rain24H = string.Format("{0}.{1}", nRain24h / 10, nRain24h % 10);
                Rain7Day = string.Format("{0}.{1}", nRain7Day / 10, nRain7Day % 10);
            }
            else
            {
                Rain10M = "0.0";
                Rain1H = "0.0";
                Rain3H = "0.0";
                Rain12H = "0.0";
                Rain24H = "0.0";
                Rain7Day = "0.0";
            }
            CountStartime();
            CountStopTime();
            PostRefreshMessage();
           
        }
        private void PostRefreshRainMapMessage()
        {
            string szHandle = IniHelper.IniReadValue("System", paths.SiteControlHandle, paths.HandlePath);
            if (szHandle.Length > 0)
            {

                int nHandle = int.Parse(szHandle);
                IntPtr pHandle = new IntPtr(nHandle);
                CWinMsgAPI.PostMessage(pHandle, CMessage.WM_ONREFRESH_RAINMAP, 0, 0);
            }
        }
        private void PostRefreshMessage()
        {
            string szHandle = IniHelper.IniReadValue("System", paths.SiteControlHandle, paths.HandlePath);
            if (szHandle.Length > 0)
            {

                int nHandle = int.Parse(szHandle);
                IntPtr pHandle = new IntPtr(nHandle);
                CWinMsgAPI.PostMessage(pHandle, CMessage.WM_ONREFRESH_SITEGRIDVIEW, 0, 0);
            }
        }
        #region 非虚拟函数
        protected int getNearestRain(int sec)
        {
            int N = g_nRecords;
            long t = Time.DateTime2DbTime(DateTime.Now) - sec;
            int _record = 0;
            while (N >= 1)
            {
                if (g_pList[N - 1].tm >= t)
                {
                    _record++;
                    N--;
                }
                else
                    break;
            }
            return _record;
        }
        private  long CountStopTime()
        {
            int N = g_nRecords;
            if (N < 1)
            {
                RainProStopTime = "无";
                return 0;
            }
            long t = CountStartime();
            long t1 = 0;
            if (t > 0)
            {
                for (int i = 0; i <= N - 1; i++)
                {
                    if (i == N - 1)
                    {
                        t1 = g_pList[i].tm;
                        break;
                    }
                    if (g_pList[i].tm >= t)
                    {
                        if (g_pList[i + 1].tm - g_pList[i].tm >= 24 * 3600)
                        {
                            t1 = g_pList[i].tm;
                            break;
                        }
                    }
                }
            }
            else
            {
                RainProStopTime = "无";
                return 0;
            }

            if (IsRealTime)
            {
                if (Time.DateTime2DbTime(DateTime.Now) - t1 >= 24 * 3600)
                {
                    RainProStopTime = "无";
                    return 0;
                }
                else
                {
                    RainProStopTime = Time.DbTime2DateTime(t1).ToString("yyyy-MM-dd HH:mm:ss");
                    return t1;
                }
            }
            else
            {
                RainProStopTime = Time.DbTime2DateTime(t1).ToString("yyyy-MM-dd HH:mm:ss");
                return t1;
            }
        }
        private  long CountStartime()
        {
            long tStartTime = BeginTime + 25 * 3600;
            int N = g_nRecords;
            long t = 0;
            int j = 0;
            if (IsRealTime)
                if (N - 1 >= 0)
                    if (Time.DateTime2DbTime(DateTime.Now) - g_pList[N - 1].tm >= 24 * 3600)
                    {
                        RainProStartTime = "无";
                        return 0;
                    }
            for (int i = N - 1; i >= 0; i--)
            {
                if (tStartTime >= g_pList[i].tm)
                {
                    t = g_pList[i].tm;
                    j = i;
                    break;
                }
            }
            if (t != 0)
            {
                if (tStartTime - t >= 48 * 3600)
                    t = 0;
                else
                {
                    for (int i = j; i >= 0; i--)
                    {
                        if (g_pList[i].contJmp == 1)
                        {
                            t = g_pList[i].tm;
                            break;
                        }
                    }
                }
            }
            RainProStartTime = t > 0 ? Time.DbTime2DateTime(t).ToString("yyyy-MM-dd HH:mm:ss") : "无";
            return t;
        }
        private  int CountHistoryRain()
        {
            int N = g_nRecords;
            if (!this.IsRealTime)
            {
                int cont, daily;
                int k;

                daily = 0;
                k = N;
                while (k-- > 0)
                {
                    if (g_pList[k].tm >= BeginTime && g_pList[k].tm < BeginTime + 24 * 3600)
                        break;
                }
                if (k >= 0)
                    daily = g_pList[k].numJmp;
                else
                    daily = 0;

                k = N;
                long end_time;
                if (BeginTime + 24 * 3600 < Time.DateTime2DbTime(DateTime.Now))
                    end_time = BeginTime + 25 * 3600;
                else
                    end_time = Time.DateTime2DbTime(DateTime.Now);


                while (k-- > 0)
                {
                    if (g_pList[k].tm <= end_time && g_pList[k].tm >= end_time - 24 * 3600)
                        break;
                }
                if (k >= 0)
                    cont = g_pList[k].contJmp;
                else
                    cont = 0;
               return cont;//CLevelCalc.G_LevelCalc.GetContinueRainValue() / 10.0;
            }
            else
            {
                int rain = 0;
                long t = Time.DateTime2DbTime(DateTime.Now);
                if (N == 1)
                    rain = 1;
                if (N > 1)
                {
                    if (t - g_pList[N - 1].tm >= 24 * 60 * 60)
                        rain = 0;
                    else
                        rain = g_pList[N - 1].contJmp;
                }
                return rain;
            }

        }
        #endregion
        public override long getStopTime(long tm)
        {
            long i, j, t;
            if (0 == g_nRecords)
                return 0;
            else if (tm < g_pList[0].tm)
                return 0;
            t = 0; j = 0;
            for (i = 0; i < g_nRecords; i++)
            {
                if (g_pList[i].tm >= tm)
                {
                    if (g_pList[i].contJmp < j)
                        return t;
                }
                else
                {
                    j = g_pList[i].contJmp;
                    t = g_pList[i].tm;
                }
            }
            return g_pList[i - 1].tm;
        }
        protected override void WriteSiteJson()
        {
            if (!string.IsNullOrEmpty(m_pJsonPath))
            {
                CSiteSerializer siteJson = new CSiteSerializer();
                string json = siteJson.GetJSON(this);
                var fs = new FileStream(m_pJsonPath, FileMode.Create, FileAccess.Write);
                var sw = new StreamWriter(fs);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.WriteLine(json);
                sw.Flush();
                sw.Close();
                fs.Close();
            }
        }
        protected override void ReadSiteJson()
        {
            if (File.Exists(m_pJsonPath))
            {
                StreamReader sr = new StreamReader(m_pJsonPath);
                string json = sr.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                CSiteSerializer siteJson = js.Deserialize<CSiteSerializer>(json);
                ContJumpTime = siteJson.ContJumpTime;
                NumJumpTime = siteJson.NumJumpTime;
                sr.Close();
            }
        }
        public override bool IsRainStop()
        {
            if (g_nRecords == 0)
                return true;
            if (g_nRecords >= 1)
            {
                if (Time.DateTime2DbTime(DateTime.Now) - g_pList[g_nRecords - 1].tm >= 24 * 60 * 60)
                {
                    return true;
                }
            }
            return false;
        }

        public override bool DoCanLiftLevel(long warningtime, int level, int liftvalue, ref _autoLiftLevelInfo liftinfo)
        {
            int timespan = 3600;
            switch (level)
            {
                case 1:
                    timespan = 1 * 3600;
                    break;
                case 2:
                     timespan = 1 * 3600;
                    break;
                case 3:
                    timespan = 1 * 3600  +3600 / 2;
                    break;
                case 4:
                    timespan = 1 * 3600  +3600 / 2;
                    break;
            }
            long t = Time.DateTime2DbTime(DateTime.Now);
            long t1 = warningtime;
            if (t - t1 < timespan)
                return false;
            else
                t1 = t - timespan;
            long N = g_nRecords;
            long _record = 0;
            if (N <= 0)
                return true;

            while (N > 1)
            {
                if (g_pList[N - 1].tm <= t && g_pList[N - 1].tm >= t1)
                {
                    _record++;
                    N--;
                }
                else
                    break;
            }

            if (_record <= liftvalue * 10)
            {
                liftinfo.siteid = SiteID;
                liftinfo.t1 = t1;
                liftinfo.t2 = t;
                liftinfo.isAuto = true;
                liftinfo.level = (-level);
                liftinfo.value = liftvalue * 10;
               //加个区间ID;
                return true;
            }
            return false;
        }
    }
}

