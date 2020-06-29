using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rainfalls.Abstract.Interface
{
    public interface IDataUpload
    {
        bool SendData(string szData);
        string GetCommSiteID();

        void SetCommSiteID(string commsiteid);

    }
}
