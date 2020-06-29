using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rainfalls.Base.Struct;
using rainfalls.Abstract.Class;
namespace rainfalls.Abstract.Interface
{
    public interface IRainfallsDBHelper
    {
        int readData(string id, RFCLICK[] g_pList);
        void writeRainData(RFCLICK click, string id);
        void SSLUploadData(RFCLICK click, string id);
        void writeLastTime(string id, string value);
        string readLastTime(string id);
        void WriteWorksDoneLog(_WorksDoneLog log);
        void WriteSms(_SMS sms,LEVELINFO li);
        void WriteSms(_SMS sms);
        bool WriteRFlog(_RFLog log);
        _RFLog GetTrackBreakRecords(string uuid);
        _RFLog[] GetTrackBreakRecords(out int N, ASectionObj obj);
        bool UpDateRFlogDb(_RFLog log);
        int GetRainLogRecords(_RFLog[] log, long t, string id);
        bool WriteRunLogInfoDB(string errID, string msg);
        int GetMeasuresLogRecords(_WorksDoneLog[] log);
        List<_InspectorInfo> GetInspectorList();
        void InsertInspectorRecord(_InspectorInfo _inspector);
        void UpdatePerson(_InspectorInfo pInfo);
        void UpdateInspectorDone(_InspectorInfo pInfo);
        List<_InspectorInfo> GetAllInspectorList();
        void UpdateWorkNumber(string number, string uuid);
    }
}
