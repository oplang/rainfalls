using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using roninzyf.CLog;
using System.IO;
using System.Runtime.CompilerServices;

namespace LogHelpers
{
    public class LogHelper
    {
        public delegate void RealMonitor(string msg);
        public static event RealMonitor showRunLogEvent;

        private static LogHelper uniqueInstance;
        private static readonly object padlock = new object();
        private Log m_pLog;
        private string m_spLogPath = AppDomain.CurrentDomain.BaseDirectory + "\\rainfalls~Log\\";
        private LogHelper()
        {
            if (Directory.Exists(m_spLogPath) == false)//如果不存在就创建file文件夹
            {
                Directory.CreateDirectory(m_spLogPath);
            }
            m_pLog = new Log(m_spLogPath, LogType.Daily);
        }
        public void dispose()
        {
            m_pLog.Dispose();
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static LogHelper getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new LogHelper();
                    }
                }
            }
            return uniqueInstance;
        }
        /// <summary>
        /// 写入新日志，根据指定的日志对象Msg
        /// </summary>
        /// <param name="msg">日志内容对象</param>
        public void Write(Msg msg)
        {
            m_pLog.Write(msg);
            if (showRunLogEvent != null)
                showRunLogEvent(msg.Text);
        }

        /// <summary>
        /// 写入新日志，根据指定的日志内容和信息类型，采用当前时间为日志时间写入新日志
        /// </summary>
        /// <param name="text">日志内容</param>
        /// <param name="type">信息类型</param>
        public void Write(string text, MsgType type)
        {
            m_pLog.Write(new Msg(text, type));
            if (showRunLogEvent != null)
                showRunLogEvent(text);
        }

        /// <summary>
        /// 写入新日志，根据指定的日志时间、日志内容和信息类型写入新日志
        /// </summary>
        /// <param name="dt">日志时间</param>
        /// <param name="text">日志内容</param>
        /// <param name="type">信息类型</param>
        public void Write(DateTime dt, string text, MsgType type)
        {
            m_pLog.Write(new Msg(dt, text, type));
            if (showRunLogEvent != null)
                showRunLogEvent(text);
        }

        /// <summary>
        /// 写入新日志，根据指定的异常类和信息类型写入新日志
        /// </summary>
        /// <param name="e">异常对象</param>
        /// <param name="type">信息类型</param>
        public void Write(Exception e, MsgType type)
        {
            m_pLog.Write(new Msg(e.Message, type));
            if (showRunLogEvent != null)
                showRunLogEvent(e.Message);
        }
        
    }
}
