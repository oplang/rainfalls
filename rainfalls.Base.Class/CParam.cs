using System;
using System.Collections.Generic;
using System.Text;

namespace rainfalls.Base.Class
{
    public class CParam
    {
        private static CParam uniqueInstance;
        private static readonly object padlock = new object();
        private CParam()
        {
        }
        public static CParam getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new CParam();
                    }
                }
            }
            return uniqueInstance;
        }
        private string mLParam;
        public string LParam
        {
            get { return mLParam; }
            set { mLParam = value; }
        }
    }
}
