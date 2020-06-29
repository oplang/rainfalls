//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Collections;
//using System.Drawing;
//using System.Data;
//using System.Text;
//using System.Windows.Forms;
//using rainfalls.Abstract.Class;
//using rainfalls.Abstract.Interface;
//using rainfalls.Base.Class;
//using rainfalls.Base.Struct;
//using Zyf.NetWork;
//namespace rainfalls.View.Statuebar
//{
//    public partial class statueBarCtrl : UserControl
//    {
//        protected readonly string m_sTimeTag = "系统时间：";
//        protected readonly string m_sRainTag = "降雨过程：";
//        protected readonly string m_sNetWorkTag = "网络状态：";
//        protected string m_sRainProStartTime = null;
//        protected string m_sRainProEndTime = null;
//        protected int m_nStatu = 0;
//        protected readonly string[] m_statu = { "正常", "断开" };
//        private ASiteSubject m_curSite;
//        private Dictionary<string, ASiteSubject> _siteDictionary = new Dictionary<string, ASiteSubject>();
//        private IRainCalc m_rainCalc;

//        public IRainCalc RainCalc
//        {
//            get { return m_rainCalc; }
//            set { m_rainCalc = value; }
//        }
//        public statueBarCtrl()
//        {
//            InitializeComponent();
//        }
//        /// <summary>
//        /// 监测站点选择后，实现更新RainMapCtrl的当前站点变量，绘制当前站点雨量图
//        /// </summary>
//        /// <param name="id"></param>
//        public void defaultChange(string id)
//        {
//            m_curSite = _siteDictionary[id];
//        }
//        public Dictionary<string, ASiteSubject> siteList
//        {
//            set
//            {
//                _siteDictionary = value;
//                bindEvent();
//            }
//        }
//        /// <summary>
//        /// 绑定监测站点数据采集存储后，绘制雨量图
//        /// </summary>
//        private void bindEvent()
//        {
//            IDictionaryEnumerator en = _siteDictionary.GetEnumerator();
//            while (en.MoveNext())
//            {
//                ASiteSubject site = (ASiteSubject)en.Value;
//                if (site.IsCommSite)
//                    m_curSite = site;
//            }
//        }
//        public string RainProStartTime
//        {
//            set
//            {
//                m_sRainProStartTime = value;
//            }
//        }
//        public string RainProEndTime
//        {
//            set
//            {
//                m_sRainProEndTime = value;
//            }
//        }
//        public int NetWorkStatu
//        {
//            set
//            {
//                m_nStatu = value;
//            }
//        }
//        private void timerSys_Tick(object sender, EventArgs e)
//        {
//            string szTime = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
//            szTime = m_sTimeTag + szTime;
//            lbSysTime.Text = szTime;
//            //lbNetWork.Text = m_sNetWorkTag + m_statu[m_nStatu];
//            lbRainProcess.Text = m_sRainTag + m_sRainProStartTime + " -- " + m_sRainProEndTime;
//        }
//        public void updateRainProcessTime(long t, bool bRealTime, ASiteSubject site)
//        {
//            try
//            {
//                long t1 = m_rainCalc.getStartime(t, bRealTime, site.G_nRecords, site.G_pList);
//                if (t1 > 0)
//                {
//                    m_sRainProStartTime = Time.DbTime2DateTime(t1).ToString("yyyy-MM-dd HH:mm:ss");
//                }
//                else
//                {
//                    m_sRainProStartTime = "0000-00-00 00:00:00";
//                }
//                t1 = m_rainCalc.getEndTime(t1, bRealTime, site.G_nRecords, site.G_pList);
//                if (t1 > 0)
//                {
//                    m_sRainProEndTime = Time.DbTime2DateTime(t1).ToString("yyyy-MM-dd HH:mm:ss");
//                }
//                else
//                {
//                    m_sRainProEndTime = "0000-00-00 00:00:00";
//                }
                
//            }
//            catch (Exception e)
//            {
//                MessageBox.Show(e.Message);
//            }
//        }

//        private void statueBarCtrl_Load(object sender, EventArgs e)
//        {
//            Timer t = new Timer();
//            t.Tick += new EventHandler(timerSys_Tick);
//            t.Start();
//            NetWorkCls.onNotify += new Notity(NetWorkCls_onNotify);
//            Timer netWorkTime = new Timer();
//            netWorkTime.Interval = 30 * 1000;
//            netWorkTime.Tick += new EventHandler(netWorkTime_Tick);
//            netWorkTime.Start();
//        }

//        void NetWorkCls_onNotify(string msg)
//        {
//            lbNetWork.Text = msg;
//        }

//        void netWorkTime_Tick(object sender, EventArgs e)
//        {
//            NetWorkCls.CheckServeStatus();
//        }
//    }
//}
