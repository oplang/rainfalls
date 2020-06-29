using System;
using System.Collections.Generic;
using System.Text;
using rainfalls.Base.Struct;
using rainfalls.Base.Class;
using System.Drawing;
using System.Windows.Forms;
using Zyf.Ini;
using rainfalls.Abstract.Class;
using rainfalls.Abstract.Interface;
namespace rainfalls.Business.RainMap
{
    public delegate void RainMapNotifyDelegate(long t, bool bIsRealTime);
    public class CRainmapRender
    {
        //long m_nRailWayDayStartTime;
        //long m_nEndTime;
        long m_nBeginTime;
        //long m_nCurrentTime;

        int m_nOneHourWidth = 33;
        int m_nOneMmRainHeight = 50;
        int m_nHMarigineLeft = 30;
        int m_nHMarigineRight = 30;
        int m_nVMarigineTop = 5;
        int m_nVMarigineBottom = 50;
        int m_nMapHeight = 0;
        int m_nMapWidth = 0;
        int m_nNumOfDays = 1;
        int m_nMaxRainHeight = 10;
        int m_nParentWidth = 0;
        int m_nParentHeight = 0;

        float m_fPenWidth = 1f;
        float m_fRainPenWidth = 2.0f;
        float m_fAxisFontSize = 10.0f;
        float m_fCaptionFontSize = 12.0f;

        _maxunit[] g_mu = new _maxunit[25];
        int[] g_start_mm = new int[100];
        int[] g_mm = new int[100];

        IRainCalc m_pSiteRainCalc;

        public event RainMapNotifyDelegate OnCountRainStartAndStopTimeEvent;
        public CRainmapRender(int width, int height, IRainCalc siteRainCalc)
        {
            m_nParentWidth = width;
            m_nParentHeight = height;
            CalcBeginTime();
            m_pSiteRainCalc = siteRainCalc;
        }
        public int parentWidth
        {
            set
            {
                m_nParentWidth = value;
            }
        }
        public int parentHeight
        {
            set
            {
                m_nParentHeight = value;
            }
        }

        public void CalcBeginTime()
        {
            DateTime dt = DateTime.Now;
            long t0 = Time.DateTime2DbTime(dt);
            if (dt.Hour < 19)
                t0 -= 24 * 3600;
            DateTime dtStart = Time.DbTime2DateTime(t0);
            m_nBeginTime = Time.DateTime2DbTime(new DateTime(dtStart.Year, dtStart.Month, dtStart.Day, 18, 0, 0));
        }

        ~CRainmapRender()
        {
            //pRainlinePen.Dispose();
            //m_pPen.Dispose();
        }

        public void SetBeginTime(long nBeginTime)
        {
            m_nBeginTime = nBeginTime;
        }

        public long GetBeginTime()
        {
            return m_nBeginTime;
        }


        public Bitmap DrawRainMap(ref int nWidth, ref int nHeight, bool bRealtime, ASiteObj site)
        {
            GetParams();
            m_nOneHourWidth = (m_nParentWidth - m_nHMarigineLeft - m_nHMarigineRight) / 25;
            m_nOneMmRainHeight = (m_nParentHeight - m_nVMarigineTop - m_nVMarigineBottom) / 10;
            m_nMapWidth = m_nNumOfDays * 25 * m_nOneHourWidth + m_nHMarigineLeft + m_nHMarigineRight;
            m_nMapHeight = m_nMaxRainHeight * m_nOneMmRainHeight + m_nVMarigineTop + m_nVMarigineBottom;
            nWidth = m_nMapWidth;
            nHeight = m_nMapHeight;

            System.Drawing.Bitmap pBitmap = new Bitmap(m_nMapWidth, m_nMapHeight);//

            System.Drawing.Graphics pGraphics = System.Drawing.Graphics.FromImage(pBitmap);
            pGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (bRealtime)
            {
               
            }
            if (OnCountRainStartAndStopTimeEvent != null)
                OnCountRainStartAndStopTimeEvent(m_nBeginTime , bRealtime);

            g_mu = new _maxunit[100];
            g_start_mm = new int[100];
            g_mm = new int[100];

            m_pSiteRainCalc.getMaxUnits(m_nBeginTime, 600, g_mu, site);
            m_pSiteRainCalc.getMMByHour(m_nBeginTime, 25, g_start_mm, g_mm, site);
            DrawRainAxis(pGraphics);

            DrawRainLine(pGraphics, site.RainClickLists, site.Records, bRealtime, g_mu);
          

            pGraphics.Dispose();
            GC.Collect();
            
            return pBitmap;
        }

        void DrawRainAxis(System.Drawing.Graphics g)
        {
            #region fill the draw area
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.FillRectangle(System.Drawing.Brushes.White, 0, 0, m_nMapWidth, m_nMapHeight);
            #endregion

            #region draw the x axis
            Pen pPen = new Pen(Color.Gray, m_fPenWidth);
            Font pFont = new Font("微软雅黑", m_fAxisFontSize);
            int i = 0;
            for (i = 10; i >= 0; i--)
            {
                g.DrawLine(pPen, m_nHMarigineLeft - m_nOneHourWidth / 10, m_nVMarigineTop + i * m_nOneMmRainHeight, m_nMapWidth - m_nHMarigineRight + m_nOneHourWidth / 10, m_nVMarigineTop + i * m_nOneMmRainHeight);
                int t = 10 - i;
                string sz = t.ToString();
                g.DrawString(sz, pFont, Brushes.Black,
                    m_nHMarigineLeft - m_nOneHourWidth / 10 - sz.Length * pFont.Size,
                    m_nVMarigineTop + i * m_nOneMmRainHeight - pFont.GetHeight(g) / 2);
                g.DrawString(sz, pFont, Brushes.Black,
                    m_nMapWidth - m_nHMarigineRight + m_nOneHourWidth / 10,
                    m_nVMarigineTop + i * m_nOneMmRainHeight - pFont.GetHeight(g) / 2);
            }
            #endregion

            #region draw the y axis
            for (i = 0; i <= 25 * m_nNumOfDays; i++)
            {
                if (i == 6)
                {
                    g.DrawLine(pPen, m_nHMarigineLeft + i * m_nOneHourWidth - m_nOneHourWidth / 20, m_nVMarigineTop, m_nHMarigineLeft + i * m_nOneHourWidth - m_nOneHourWidth / 20, m_nMapHeight - m_nVMarigineBottom + m_nOneMmRainHeight / 20);
                    g.DrawLine(pPen, m_nHMarigineLeft + i * m_nOneHourWidth + m_nOneHourWidth / 20, m_nVMarigineTop, m_nHMarigineLeft + i * m_nOneHourWidth + m_nOneHourWidth / 20, m_nMapHeight - m_nVMarigineBottom + m_nOneMmRainHeight / 20);
                }
                else
                    g.DrawLine(pPen, m_nHMarigineLeft + i * m_nOneHourWidth, m_nVMarigineTop, m_nHMarigineLeft + i * m_nOneHourWidth, m_nMapHeight - m_nVMarigineBottom + m_nOneMmRainHeight / 20);

                int n = i + 18;
                if (n > 24)
                    n = n % 24;
                string sz = n.ToString();

                g.DrawString(sz, pFont, Brushes.Black,
                    m_nHMarigineLeft + i * m_nOneHourWidth - pFont.Size * sz.Length / 2,
                    m_nMapHeight - m_nVMarigineBottom + pFont.GetHeight() / 2);
            }
            pFont.Dispose();
            pPen.Dispose();
            #endregion
        }
        void DrawSystemTime(System.Drawing.Graphics g)
        {
            string szTime = "系统时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Font pFontTail = new Font("微软雅黑", m_fCaptionFontSize);
            Brush pBrush = Brushes.Red;
            g.DrawString(szTime, pFontTail, pBrush,
               m_nHMarigineLeft + 600, m_nMapHeight - m_nVMarigineBottom + pFontTail.GetHeight() * 3 / 2);
            pFontTail.Dispose();
        }

        public string GetRainCaptionString()
        {
            #region draw the caption
            DateTime dtStart = Time.DbTime2DateTime(m_nBeginTime);
            DateTime dtEnd = Time.DbTime2DateTime(m_nBeginTime + 24 * 3600);
            return dtStart.Year + "年" + dtStart.Month + "月" + dtStart.Day + "日 至 " + dtEnd.Year + "年" + dtEnd.Month + "月" + dtEnd.Day + "日";
            #endregion
        }

        int GetX(long dT)
        {
            if (dT < 0) dT = 0;
            float dX = (float)m_nOneHourWidth / (float)3600.0;//横轴每秒的宽度
            return (int)(m_nHMarigineLeft + dT * dX);
        }

        int GetY(int nJumps)
        {


            int h;
            int m = m_nOneMmRainHeight * m_nMaxRainHeight;

            if (nJumps > 0
                && nJumps == (nJumps / (m_nMaxRainHeight * 10)) * m_nMaxRainHeight * 10)
                h = m_nMaxRainHeight * m_nOneMmRainHeight;
            else
                h = (nJumps * m_nOneMmRainHeight / 10) % m;

            return m_nMapHeight - m_nVMarigineBottom - h;
        }

        void DrawRainLine(Graphics g, RFCLICK[] pLists, int N, bool bRealtime, _maxunit[] mu)
        {
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            if (bRealtime)
                if (difftime(Time.DateTime2DbTime(DateTime.Now), m_nBeginTime) > m_nNumOfDays * 25 * 3600)
                    m_nBeginTime += 24 * 3600;

            Pen pRainlinePen = new Pen(Color.Green, m_fRainPenWidth);
            RFCLICK[] pList = pLists;
            int i;
            pList[N].tm = m_nBeginTime + 1;
            for (i = 0; ; i++)
            {
                if (pList[i].tm >= m_nBeginTime)
                    break;
            }

            long d;
            int lastHeight;
            long stopTime;

            if (i == N)    // 没有 startDate 之后的数据
            {
                if (N > 0
                    && (d = difftime(m_nBeginTime, pList[N - 1].tm)) >= 0
                    && d <= 24 * 3600)
                {
                    stopTime = pList[N - 1].tm;
                    lastHeight = pList[N - 1].contJmp;
                }
                else
                {
                    lastHeight = 0;
                    stopTime = m_nBeginTime;
                }
            }
            else
            {
                if (0 == i)
                {
                    lastHeight = 0;
                    stopTime = pList[0].tm;
                }
                else
                {
                    if (difftime(m_nBeginTime, pList[i - 1].tm) > 24 * 3600)
                    {
                        lastHeight = 0;
                        stopTime = m_nBeginTime;
                    }
                    else
                    {
                        lastHeight = pList[i - 1].contJmp;
                        stopTime = pList[i - 1].tm;
                    }
                }
            }

            float nLastX = GetX(0);
            float nLastY = GetY(lastHeight);

            for (; i < N; i++)
            {

                if (difftime(pList[i].tm, m_nBeginTime) > 25 * 3600)
                    break;

                d = difftime(pList[i].tm, stopTime);
                if (d > 24 * 3600)    // 超过24小时先回零
                {

                    d = difftime(stopTime + 24 * 3600, m_nBeginTime);

                    g.DrawLine(pRainlinePen, nLastX, nLastY, GetX(d), nLastY);

                    lastHeight = 0;
                    nLastX = GetX(d);
                    nLastY = GetY(lastHeight);
                }

                ////上一次水平延续到这一次 -->
                d = difftime(pList[i].tm, m_nBeginTime);
                g.DrawLine(pRainlinePen, nLastX, nLastY, GetX(d), GetY(lastHeight));
                nLastX = GetX(d);
                nLastY = GetY(lastHeight);

                // if 已达到最大高度, 先回零
                if (nLastY == m_nVMarigineTop)
                {
                    nLastX = GetX(d);
                    nLastY = GetY(0);
                }

                stopTime = pList[i].tm;
                lastHeight = pList[i].contJmp;

                long h = (long)(pList[i].tm - m_nBeginTime) / 3600;
                if (h > 0)
                {
                    if (g_mm[h] == 1)
                    {
                        pRainlinePen.Color = Color.Red;
                        g.DrawLine(pRainlinePen, nLastX, nLastY, GetX(d), GetY(lastHeight));
                        nLastX = GetX(d);
                        nLastY = GetY(lastHeight);
                        pRainlinePen.Color = Color.Green;
                    }
                    if (i == mu[h].idx_start)
                        pRainlinePen.Color = Color.Red;
                  
                }
                g.DrawLine(pRainlinePen, nLastX, nLastY, GetX(d), GetY(lastHeight));
                nLastX = GetX(d);
                nLastY = GetY(lastHeight);
                h = (long)(pList[i].tm - m_nBeginTime) / 3600;
                if (h > 0)
                {
                    if (i == mu[h].idx_end)
                    {
                        pRainlinePen.Color = Color.Green;
                    }
                }
            }

            long nEndTime = bRealtime ? Time.DateTime2DbTime(DateTime.Now) : m_nBeginTime + 25 * 3600;
            d = difftime(nEndTime, stopTime);
            if (d > 24 * 3600)
            {
                //if(bRealtime)
                // CSQLite.G_CSQLite.WriteRunLogInfoDB("A03", "当前24小时内没有降雨，警戒状态修改为正常");
                d = difftime(stopTime + 24 * 3600, m_nBeginTime);
                g.DrawLine(pRainlinePen, nLastX, nLastY, GetX(d), GetY(lastHeight));

                nLastX = GetX(d);
                nLastY = GetY(0);
                lastHeight = 0;
            }

            d = difftime(nEndTime, m_nBeginTime);
            g.DrawLine(pRainlinePen,
                nLastX, nLastY,
                GetX(d),
                GetY(lastHeight));

            pRainlinePen.Dispose();
        }
       
        long difftime(long t1, long t2)
        {
            return (t1 - t2);
        }
        void GetParams()
        {
            try
            {
                string szPath = Application.StartupPath + "\\RainMapConfig.ini";
                m_nOneHourWidth = int.Parse(CINIFile.IniReadValue("RainMapParams", "OneHourWidth", szPath));
                m_nOneMmRainHeight = int.Parse(CINIFile.IniReadValue("RainMapParams", "OneMmRainHeight", szPath));
                m_nHMarigineLeft = int.Parse(CINIFile.IniReadValue("RainMapParams", "HMarigineLeft", szPath));
                m_nHMarigineRight = int.Parse(CINIFile.IniReadValue("RainMapParams", "HMarigineRight", szPath));
                m_nVMarigineTop = int.Parse(CINIFile.IniReadValue("RainMapParams", "VMarigineTop", szPath));
                m_nVMarigineBottom = int.Parse(CINIFile.IniReadValue("RainMapParams", "VMarigineBottom", szPath));
                m_fPenWidth = float.Parse(CINIFile.IniReadValue("RainMapParams", "PenWidth", szPath));
                m_fRainPenWidth = float.Parse(CINIFile.IniReadValue("RainMapParams", "RainPenWidth", szPath));
                m_fAxisFontSize = float.Parse(CINIFile.IniReadValue("RainMapParams", "AxisFontSize", szPath));
                m_fCaptionFontSize = float.Parse(CINIFile.IniReadValue("RainMapParams", "CaptionFontSize", szPath));
            }
            catch
            {
                // CLog.LOG("Exception occur in GetParams()");
            }
        }
        public void OnMouseMove(Control pCtrl, System.Windows.Forms.ToolTip pToolTip, int x, int y)
        {
            string szMsg = "";
            bool bActiveToolTip = false;

            if (y > m_nVMarigineTop)
            {
                int h = (x - m_nHMarigineLeft) / m_nOneHourWidth;
                if (h >= 0 && h < 25)
                {
                    if (g_mu[h].max > 0)
                    {
                        DateTime t1 = Time.DbTime2DateTime(g_mu[h].start);
                        DateTime t2 = Time.DbTime2DateTime(g_mu[h].end);
                        szMsg = string.Format("最大10分钟雨量:\n{0}:{1:D2}-{2}:{3:D2}: {4:F1}毫米\n本小时雨量:{5:F1}毫米",
                                t1.Hour, t1.Minute,
                                t2.Hour, t2.Minute, (g_mu[h].max) / 10.0,
                                g_mm[h] / 10.0);
                        pToolTip.SetToolTip(pCtrl, szMsg);
                        bActiveToolTip = true;
                    }
                }
                else
                {
                    pToolTip.SetToolTip(pCtrl, "None");
                }
            }

            pToolTip.Active = bActiveToolTip;
        }

    }
}
