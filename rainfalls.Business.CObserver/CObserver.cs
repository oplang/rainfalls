using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rainfalls.Abstract.Class;
using System.Threading;
using rainfalls.Base.Struct;
namespace rainfalls.Business.CObserver
{
    public class CObserver:Observer
    {
        Thread m_pRainfallCompterThread = null;
        public override void Update(string id)
        {
            if(RainMapObj !=null)
                RainMapObj.DrawRainMap(id);

            foreach (ASectionObj section in m_pSectionObjList)
            {
                foreach(AVirtualSection avs in section.VirtualSectionList)
                {
                    if (avs.SiteID.Equals(id))
                    {
                        LEVELINFO li = avs.VirtualLevelCalc(section.AlarmLevels, section.AlarmLevelsCount);
                        section.AlarmComputer(li);
                    }
                }
            }
        }
        public override void DrawRainMapOnly(string id)
        {
            if (RainMapObj != null)
                RainMapObj.DrawRainMap(id);
        }
        void OnTimer()
        {
            for (; ; )
            {
                foreach (ASiteObj obj in SiteObjLists)
                {
                    obj.RainfallCoumpter();
                }
                Thread.Sleep(3 * 60 * 1000);
            }
        }

        public override void StartTimer()
        {
            m_pRainfallCompterThread = new Thread(new ThreadStart(OnTimer));
            m_pRainfallCompterThread.Start();
        }
        public override void EndTimer()
        {
            if (m_pRainfallCompterThread != null)
                if (m_pRainfallCompterThread.IsAlive)
                    m_pRainfallCompterThread.Abort();
        }
    }
}
