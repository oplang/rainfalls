using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using rainfalls.Base.Struct;
using rainfalls.Abstract.Class;
using System.Xml;
using System.Threading;
using rainfalls.Abstract.Interface;
using Aliyun.Queue;
namespace rainfalls.DataSource.Remote
{
    public class rtu_daemon:ARTU_daemon
    {
        private ASiteObj m_pSiteObj;
        private static readonly object padlock = new object();
        IRainfallsDBHelper m_rainfallDBhelper;
        private Thread t;
        HttpAsyncAliyun m_pHttpAsyncAliyun;
        public override void  runninng(ASiteObj obj)
        {
            m_pHttpAsyncAliyun = new HttpAsyncAliyun();
            m_pHttpAsyncAliyun.onCompleteEvent += new OnComplete(rtu_daemon_OnCompleteEvent);
            m_pHttpAsyncAliyun.onExceptionEvent += new OnException(rtu_daemon_onExceptionEvent);
            m_pSiteObj = obj;
            t = new Thread(new ThreadStart(run));
            t.Name= "RTU站点Request初始化";
            t.Start();
        }

        void rtu_daemon_onExceptionEvent()
        {
            Thread.Sleep(1000);
            goon();
        }

        void rtu_daemon_OnCompleteEvent(string id, string data)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("{0},{1}结束读取", System.DateTime.Now.ToString(), m_pSiteObj.SiteID));

            try
            {
                if (id.Equals(m_pSiteObj.SiteID))
                {
                    if (!string.IsNullOrEmpty(data))
                    {
                        if (data.Equals("010"))
                        {
                            //读取数据过程中发生错误
                        }
                        else
                        {
                            string[] pData = data.Split('-');
                            long tm;
                            for (int i = 0; i < pData.Length - 1; i++)
                            {
                                if (long.TryParse(pData[i], out tm))
                                {
                                    System.Diagnostics.Debug.WriteLine(string.Format("{0},{1}插入", System.DateTime.Now.ToString(), tm));
                                    rtuClick[] r = new rtuClick[1];
                                    r[0].tm = tm;
                                    // m_rainfallDBhelper.writeLastTime(m_pTERM_SN, m_nLastTime.ToString());
                                    updateRTUSiteCtrl(r);
                                    System.Diagnostics.Debug.WriteLine(string.Format("{0},{1}插入结束", System.DateTime.Now.ToString(), tm));
                                }
                            }
                        }
                    }
                }
            }
            catch { }
            goon();
        }
        public override void Dispose()
        {
            if (!this.disposed)
            {
                try
                {
                    if (t != null)
                        if (t.IsAlive)
                            t.Abort();
                }
                finally
                {
                    this.disposed = true;
                    GC.SuppressFinalize(this);
                }
            }
           
        }
        void goon()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("{0},{1}开始从Aliyun读取", System.DateTime.Now.ToString(), m_pSiteObj.SiteID));
            m_pHttpAsyncAliyun.PostAsync(m_pSiteObj.SiteID, m_pSiteObj.GetLastTime());
        }
        void run()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("{0},{1}开始从Aliyun读取", System.DateTime.Now.ToString(), m_pSiteObj.SiteID));
            m_pHttpAsyncAliyun.PostAsync(m_pSiteObj.SiteID, m_pSiteObj.GetLastTime());
            
        }
        #region webservice版本
        
        //void run()
        //{
            
        //    //long lastTime = 0; ;
        //    //string ltz = m_rainfallDBhelper.readLastTime(m_pTERM_SN);
        //    //long lt;
        //    //lastTime = long.TryParse(ltz, out lt) ? lt : 0;
        //    //rainfallsWebServer.rtuClick[] rtu;
        //    //for (; ; )
        //    //{
        //    //    lock (padlock)
        //    //    {
        //    //        try
        //    //        {
        //    //            rtu = null;
        //    //            rainfallsWebServer.rainfalls rtuService = new rainfallsWebServer.rainfalls();

        //    //            rtu = rtuService.getData(m_pTERM_SN, lastTime);
                        
        //    //            if (rtu.Length > 0)
        //    //            {
                           
        //    //                for (int i = 0; i <= rtu.Length - 1; i++)
        //    //                {
        //    //                    rtuClick[] r = new rtuClick[1];
        //    //                    r[0].tm = rtu[i].tm;
        //    //                    lastTime = r[0].tm;
        //    //                    m_rainfallDBhelper.writeLastTime(m_pTERM_SN, lastTime.ToString());
        //    //                    r[0].voltage = rtu[i].voltage;
        //    //                    updateRTUSiteCtrl(r);
        //    //                }
                            
        //    //            }
        //    //        }
        //    //        catch (Exception e)
        //    //        {
        //    //           // throw new Exception(e.Message);
        //    //        }
        //    //    }
        //    //    System.Threading.Thread.Sleep(1 * 60 * 1000);
        //    //}
        //}
        #endregion
    }
}
