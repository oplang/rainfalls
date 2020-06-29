using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rainfalls.Base.ErrorHandle
{
    public delegate void ShowErrorMessage(string txt);
    public class CError
    {
        public event ShowErrorMessage onShowErrorEvent;
        private static CError uniqueInstance;
        private static readonly object padlock = new object();
        private CError()
        {
        }
        public static CError getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new CError();
                    }
                }
            }
            return uniqueInstance;
        }
        public void  Show(string text)
        {
            if (onShowErrorEvent != null)
                onShowErrorEvent(text);
        }
    }
}
