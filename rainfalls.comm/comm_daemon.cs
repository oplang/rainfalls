using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;
using System.Runtime.CompilerServices;
using rainfalls.Base.Struct;
using rainfalls.Base.Class;
using System.Runtime.InteropServices;
namespace rainfalls.DataSource.Comm
{
    //雨量数据采集
    public delegate void OnReceviedNewClickEvent(rtuClick [] oneData);
    public class comm_daemon
    {
        public event OnReceviedNewClickEvent receviedNewClickEvent;
        private static comm_daemon uniqueInstance;

        private static readonly object padlock = new object();
        private string m_pCommX;
        Thread m_pThread = null;

        [DllImport("mfc_comm.dll", EntryPoint = "AcquireComm", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern int AcquireComm(int comm, int handle,ClickDelegate cd);
        public delegate void ClickDelegate();
        private bool m_bCommState = true;
        private comm_daemon()
        {
           //Initialize(comX);
        }
        private void StartCommThread()
        {
            if (m_pThread == null)
            {

                m_pThread = new Thread(new ThreadStart(mfc_comm_daemon));
                m_pThread.Start();

            }
        }
        void mfc_comm_daemon()
        {
            if (!string.IsNullOrEmpty(m_pCommX))
            {
                if (m_pCommX.Length > 1)
                {
                    int comm;
                    char pComm = m_pCommX[m_pCommX.Length - 1];
                    if (int.TryParse(pComm.ToString(), out comm))
                    {
                        int n = AcquireComm(comm, m_nHandle, new ClickDelegate(Callback));
                        m_bCommState = false;

                    }
                }
            }
            m_bCommState = false;
        }
       
        void Callback()
        {
            Thread t = new Thread(new ThreadStart(click_daemon));
            t.Start();
        }
        void click_daemon()
        {
            rtuClick[] oneData = new rtuClick[1];
            
            oneData[0].tm = Time.DateTime2DbTime(DateTime.Now);
            if (receviedNewClickEvent != null)
            {
                receviedNewClickEvent(oneData);
            }
        }
        private void StopCommThread()
        {

            if (m_pThread != null)
                if (m_pThread.IsAlive)
                    m_pThread.Abort();
            m_pThread = null;
            
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static comm_daemon getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new comm_daemon();
                    }
                }
            }
            return uniqueInstance;
        }
        public string COMX
        {
            get { return m_pCommX; }
        }
        private int m_nHandle;
        public void Initialize(string comX,int handle)
        {
            m_nHandle = handle;
            m_pCommX = comX; 
            StartCommThread();
        }
        
        public bool CheckPortState()
        {
            return m_bCommState;
        }
        public void Close()
        {
            StopCommThread();
        }
    }
}
