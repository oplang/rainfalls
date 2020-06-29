using System;
using System.Runtime.InteropServices;
namespace rainfalls.App.AppSync
{
    public class Time
    {
        //DateTime ========>  UTC Local time
        public static long DateTime2DbTime(System.DateTime dt)
        {
            long l = dt.ToFileTime();
            return (long)((l - 116444736000000000) / 10000000);
        }

        //UTC Local Time =======> DateTime
        public static System.DateTime DbTime2DateTime(long dbTime)
        {
            long l = dbTime * 10000000 + 116444736000000000;
            System.DateTime dt = System.DateTime.FromFileTime(l);
            return dt;
        }
    }

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
        /// 从System.DateTime转换。   
        /// </summary>   
        /// <param name="time">System.DateTime类型的时间。</param>   
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
        /// 转换为System.DateTime类型。   
        /// </summary>   
        /// <returns></returns>   
        public DateTime ToDateTime()
        {
            return new DateTime(wYear, wMonth, wDay, wHour, wMinute, wSecond, wMilliseconds);
        }
        /// <summary>   
        /// 静态方法。转换为System.DateTime类型。   
        /// </summary>   
        /// <param name="time">SYSTEMTIME类型的时间。</param>   
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
