using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rainfalls.Base.Struct;
using rainfalls.Abstract.Interface;
namespace rainfalls.Abstract.Class
{
    public delegate void OnReceviedNewClickEvent(rtuClick[] clicks);
    public abstract class ARTU_daemon : IDisposable
    {
        protected bool disposed = false;
        public event OnReceviedNewClickEvent receviedNewClickEvent;
        public abstract void runninng(ASiteObj obj);
        public abstract void Dispose();
        protected void updateRTUSiteCtrl(rtuClick[] clicks)
        {
            if (receviedNewClickEvent != null)
            {
                receviedNewClickEvent(clicks);
            }
        }
    }
}
