using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rainfalls.Abstract.Class;
using rainfalls.Base.Struct;
using rainfalls.Abstract.Interface;
using rainfalls.Base.Class;
using System.Threading.Tasks;
using Zyf.Ini;
using rainfalls.path;
using System.Threading;
namespace rainfalls.Business.InspectorLab
{
    public delegate void NewTaskDelegate(int level);
    public class InspectorsLab
    {
        private List<Inspector> m_pInspectorList = new List<Inspector>();
        private IRainfallsDBHelper m_pDbHelper;
        private static InspectorsLab uniqueInstance;
        private static readonly object padlock = new object();
        enum STATE : byte { ToDo = 0, Doing, Done };
        public event NewTaskDelegate OnNewTaskEvent;
        private InspectorsLab()
        {
            ZoneLab.getInstance().InitializingZoneList();
            PersonLab.getInstance().InitializingPersonList();
        }
        public static InspectorsLab getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new InspectorsLab();
                    }
                }
            }
            return uniqueInstance;
        }

        public IRainfallsDBHelper DbHelper
        {
            set { m_pDbHelper = value; }
        }
        public List<Inspector> InspectorList
        {
            get { return m_pInspectorList; }
            set { m_pInspectorList = value; }
        }
        public int GetTodoTaskNumber()
        {
            int N = 0;
            foreach (Inspector obj in m_pInspectorList)
            {
                if (obj.InspectorState == "0")
                {
                    N++;
                }
            }
            return N;
        }
        
        public void ReadInSpectorRecords()
        {
            m_pInspectorList.Clear();
            if (m_pDbHelper != null)
            {
                List<_InspectorInfo> pLists = m_pDbHelper.GetInspectorList();
                foreach (_InspectorInfo _inspector in pLists)
                {

                    Inspector pInspector = new Inspector();
                     
                    pInspector.UUID = _inspector.uuid;
                    pInspector.WarningTime = _inspector.warning_time;
                    pInspector.SectionID = _inspector.section_id;
                    pInspector.ZoneName = _inspector.zone_name;
                    pInspector.ZoneType = _inspector.zone_type;
                    pInspector.ZoneID = _inspector.zone_id;
                    pInspector.StartTime = _inspector.start_time;
                    pInspector.StopTime = _inspector.stop_time;
                    pInspector.PersonName = _inspector.person_mame;
                    pInspector.PersonPhone = _inspector.person_phone;
                    pInspector.PersonType = _inspector.person_type;
                    pInspector.WorkNumber = _inspector.work_number;
                    pInspector.InspectorState = _inspector.inpector_state;
                    pInspector.ZoneLevel = ZoneTypeFormat(pInspector.ZoneType);
                    m_pInspectorList.Add(pInspector);
                }
            }

        }
        private int ZoneTypeFormat(string pType)
        {
            int level ;
            string[] pStr = pType.Split('|');
            if (pStr.Length > 1)
            {
                if (int.TryParse(pStr[1], out level))
                {
                    return level;
                }
            }
            return 0;
        }
        public Inspector GetInspectorByUUID(string uuid)
        {
            foreach (Inspector pInspector in m_pInspectorList)
            {
                if (pInspector.UUID.Equals(uuid))
                {
                    return pInspector;
                }
            }
            return null;
        }
        public List<Inspector> GetAllInspectorRecords()
        {
            List<Inspector> _pInspectorList = new List<Inspector>();
            if (m_pDbHelper != null)
            {
                List<_InspectorInfo> pLists = m_pDbHelper.GetAllInspectorList();
                foreach (_InspectorInfo _inspector in pLists)
                {
                    Inspector pInspector = new Inspector();
                    pInspector.UUID = _inspector.uuid;
                    pInspector.WarningTime = _inspector.warning_time;
                    pInspector.SectionID = _inspector.section_id;
                    pInspector.ZoneName = _inspector.zone_name;
                    pInspector.ZoneType = _inspector.zone_type;
                    pInspector.ZoneID = _inspector.zone_id;
                    pInspector.StartTime = _inspector.start_time;
                    pInspector.StopTime = _inspector.stop_time;
                    pInspector.PersonName = _inspector.person_mame;
                    pInspector.PersonPhone = _inspector.person_phone;
                    pInspector.PersonType = _inspector.person_type;
                    pInspector.WorkNumber = _inspector.work_number;
                    pInspector.InspectorState = _inspector.inpector_state;
                    pInspector.ZoneLevel = ZoneTypeFormat(pInspector.ZoneType);
                    _pInspectorList.Add(pInspector);
                }
            }
            return _pInspectorList;
        }
        public void AddPersonDoing(string uuid, string phone,string workNumber)
        {
            foreach (Inspector pInspector in m_pInspectorList)
            {
                if (pInspector.UUID.Equals(uuid))
                {
                    Person p = PersonLab.getInstance().GetPerson(phone);
                    pInspector.AddPersonToInspector(p);
                    pInspector.StartTime = (Time.DateTime2DbTime(DateTime.Now).ToString());
                    PersonLab.getInstance().UpdatePersonState(phone, "1");
                    pInspector.InspectorState = ((int)STATE.Doing).ToString();
                    pInspector.WorkNumber = workNumber;
                    UpdateSpectorPersonRecord(uuid);
                }
            }
        }
        private void UpdateSpectorPersonRecord(string uuid)
        {
            foreach (Inspector pInspector in m_pInspectorList)
            {
                if (pInspector.UUID.Equals(uuid))
                {
                    _InspectorInfo p = new _InspectorInfo();
                    p.uuid = uuid;
                    p.work_number = pInspector.WorkNumber;
                    p.person_mame = pInspector.PersonName;
                    p.person_phone = pInspector.PersonPhone;
                    p.person_type = pInspector.PersonType;
                    p.start_time = pInspector.StartTime;
                    p.inpector_state = pInspector.InspectorState;
                    m_pDbHelper.UpdatePerson(p);
                }
            }
        }
        public void UpdateWorkNumber(string uuid, string workNumber)
        {
            foreach (Inspector pInspector in m_pInspectorList)
            {
                if (pInspector.UUID.Equals(uuid))
                {
                    pInspector.WorkNumber = workNumber;
                    m_pDbHelper.UpdateWorkNumber(workNumber, uuid);
                }
            }
        }
        public void InspectorDone(string uuid)
        {

            foreach (Inspector pInspector in m_pInspectorList)
            {
                if (pInspector.UUID.Equals(uuid))
                {
                    pInspector.StopTime = (Time.DateTime2DbTime(DateTime.Now).ToString());
                    pInspector.InspectorState = ((int)STATE.Done).ToString();
                    PersonLab.getInstance().UpdatePersonState(pInspector.PersonPhone, "0");
                    _InspectorInfo p = new _InspectorInfo();
                    p.uuid = uuid;
                    p.stop_time = pInspector.StopTime;
                    p.inpector_state = pInspector.InspectorState;
                    m_pDbHelper.UpdateInspectorDone(p);

                   // m_pInspectorList.Remove(pInspector);
                }
            }
            for(int i=0;i<m_pInspectorList.Count;i++)
            {
                if (m_pInspectorList[i].UUID.Equals(uuid))
                {
                    m_pInspectorList.RemoveAt(i);
                    break;
                }
            }
            
        }
        public bool IsDoing(string uuid)
        {
            bool b = true;
            foreach (Inspector pInspector in m_pInspectorList)
            {
                if (pInspector.UUID.Equals(uuid))
                {
                    if (pInspector.InspectorState == ((int)STATE.ToDo).ToString())
                        b = false;
                }
            }
            return b;
        }
   
        public int GetRowCount()
        {
            return m_pInspectorList.Count;
        }
        private void WriteNewSpectorRecord(Zone ze)
        {
            //写入数据库
            string uuid = System.Guid.NewGuid().ToString("N");
            _InspectorInfo _inspector = new _InspectorInfo();
            _inspector.uuid = uuid;
            _inspector.warning_time = Time.DateTime2DbTime(DateTime.Now).ToString();
            _inspector.section_id = null;
            _inspector.zone_name = ze.ZoneName;
            _inspector.zone_type = string.Format("{0}|{1}", ze.ZoneType, ze.ZoneLevel);
            _inspector.zone_id = ze.ZoneID;
            _inspector.inpector_state = ((int)STATE.ToDo).ToString();
            m_pDbHelper.InsertInspectorRecord(_inspector);
            //添加至List
            Inspector pInspector = new Inspector();
            pInspector.UUID = _inspector.uuid;
            pInspector.WarningTime = _inspector.warning_time;
            pInspector.SectionID = _inspector.section_id;
            pInspector.ZoneName = _inspector.zone_name;
            pInspector.ZoneType = _inspector.zone_type;
            pInspector.ZoneID = _inspector.zone_id;
            pInspector.ZoneLevel = ze.ZoneLevel;
            pInspector.InspectorState = _inspector.inpector_state;
            m_pInspectorList.Add(pInspector);

        }
        public void AddNewInspectorTaskAlarm(int level)
        {
            List<Zone> _pLists = new List<Zone>();
            _pLists = ZoneLab.getInstance().GetShouldInspectList(level);
            AddNewTask(_pLists);
            if (OnNewTaskEvent != null)
                OnNewTaskEvent(level);
        }
        
        public void AddNewInspectorTaskWeatherWarning(ASectionObj obj)
        {
            //List<Zone> _pLists = new List<Zone>();
            //if (obj.WeatherWarning.Equals("red"))
            //{
            //    _pLists = ZoneLab.getInstance().GetShouldInspectList(obj.ID, 3);
            //    AddNewTask(_pLists, obj.ID);
            //}
        }
        private void AddNewTask(List<Zone> pList)
        {
            foreach (Zone ze in pList)
            {
                bool _isExist = false;
                foreach (Inspector ist in m_pInspectorList)
                {
                    if (ze.ZoneID.Equals(ist.ZoneID))
                    {
                        _isExist = true;
                        break;
                    }
                }
                if (!_isExist)
                {
                    WriteNewSpectorRecord(ze);
                }
            }
        }
    }
}
