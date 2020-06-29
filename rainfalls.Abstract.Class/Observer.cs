using System.Collections.Generic;
using rainfalls.Abstract.Interface;
namespace rainfalls.Abstract.Class
{
    public abstract class Observer
    {
        
        protected List<ASectionObj> m_pSectionObjList = new List<ASectionObj>();
        public List<ASectionObj> SectionObjList
        {
            set { m_pSectionObjList = value; }
            get { return m_pSectionObjList; }
        }
        protected List<ASiteObj> m_pSiteObjLists = new List<ASiteObj>();
        public List<ASiteObj> SiteObjLists
        {
            set { m_pSiteObjLists = value; }
            get { return m_pSiteObjLists; }
        }
        private IRainMap m_pRainMapCtrlObj;
        public IRainMap RainMapObj
        {
            set { m_pRainMapCtrlObj = value; }
            get { return m_pRainMapCtrlObj; }
        }
        public abstract void DrawRainMapOnly(string id);
        public abstract void Update(string id);
        public abstract void StartTimer();
        public abstract void EndTimer();

    }
}
