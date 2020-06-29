using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Net;
using System.Windows.Forms;
using System.Text;

namespace Rainfall.App.AppSync
{
    public struct SystemTime
    {
        public ushort wYear;
        public ushort wMonth;
        public ushort wDayOfWeek;
        public ushort wDay;
        public ushort wHour;
        public ushort wMinute;
        public ushort wSecond;
        public ushort wMilliseconds;

        /// <summary>   
        /// ��System.DateTimeת����   
        /// </summary>   
        /// <param name="time">System.DateTime���͵�ʱ�䡣</param>   
        public void FromDateTime(DateTime time)
        {
            wYear = (ushort)time.Year;
            wMonth = (ushort)time.Month;
            wDayOfWeek = (ushort)time.DayOfWeek;
            wDay = (ushort)time.Day;
            wHour = (ushort)time.Hour;
            wMinute = (ushort)time.Minute;
            wSecond = (ushort)time.Second;
            wMilliseconds = (ushort)time.Millisecond;
        }
        /// <summary>   
        /// ת��ΪSystem.DateTime���͡�   
        /// </summary>   
        /// <returns></returns>   
        public DateTime ToDateTime()
        {
            return new DateTime(wYear, wMonth, wDay, wHour, wMinute, wSecond, wMilliseconds);
        }
        /// <summary>   
        /// ��̬������ת��ΪSystem.DateTime���͡�   
        /// </summary>   
        /// <param name="time">SYSTEMTIME���͵�ʱ�䡣</param>   
        /// <returns></returns>   
        public static DateTime ToDateTime(SystemTime time)
        {
            return time.ToDateTime();
        }

        [DllImport("Kernel32.dll")]
        public static extern bool SetLocalTime(ref SystemTime Time);
        [DllImport("Kernel32.dll")]
        public static extern void GetLocalTime(ref SystemTime Time);
    }
}
