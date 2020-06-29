using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rainfalls.Base.Struct;
using rainfalls.Abstract.Class;

namespace rainfalls.Abstract.Interface
{
    public interface ILevelCalc
    {
        int Calc(ALARMLEVEL[] alarmLevels, int rows, int nRecords, RFCLICK[] pLists, ASiteObj obj, ref LEVELINFO pLevelinfo, AVirtualSection avobj);
    }
}
