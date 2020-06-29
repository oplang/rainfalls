using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rainfalls.Abstract.Class;
using System.Runtime.CompilerServices;
namespace rainfalls.Event.CaptionCtrl
{
    public class captionCtrlEvent:ACaptionEvent
    {
          private static captionCtrlEvent uniqueInstance;
        private static readonly object padlock = new object();
      
        private captionCtrlEvent()
        {
           
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static captionCtrlEvent getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new captionCtrlEvent();
                    }
                }
            }
            return uniqueInstance;
        }
    }
}
