using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rainfalls.Base.Struct;
namespace rainfalls.Abstract.Interface
{
    public interface ISiteSubject
    {
        long getRainStopTime(long tm);
        bool isCanLiftLevel(_RFLog rLog);
        _autoLiftLevelInfo getLiftLevelInfo();
        void saveLiftSpeedPar(long tm);
        void saveLiftBreakPar(long tm);
        int afterLiftRecount();
        void afterLiftSectionAlarm();
    }
}
