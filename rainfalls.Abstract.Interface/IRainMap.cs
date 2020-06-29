using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rainfalls.Abstract.Class;

namespace rainfalls.Abstract.Interface
{
    public interface IRainMap
    {
        void DrawRainMap(string id);
        string DrawPrevDay();
        string DrawNextDay(out bool b);
        string DrawRealtime();
        string DrawAnyTime(DateTime dt);
        ASiteObj GetActiveSiteObj();
        void ChangeActiveSite(string id);
    }
}
