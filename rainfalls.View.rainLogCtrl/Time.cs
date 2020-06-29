using System;
using System.Collections.Generic;
using System.Text;

namespace rainfalls.View.rainLogCtrl
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
}
