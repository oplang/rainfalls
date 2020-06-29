using Zyf.Ini;
using rainfalls.path;

namespace rainfalls.Base.Class
{
    public delegate void AsyncRainMapCaption(string siteName);
    public class CSoftInfo
    {
        private static CSoftInfo uniqueInstance;
        private static readonly object padlock = new object();
        public event AsyncRainMapCaption OnDefaultSiteNameEvent;
        private CSoftInfo()
        {
        }
        public static CSoftInfo getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new CSoftInfo();
                    }
                }
            }
            return uniqueInstance;
        }

        private string m_pMainSiteID;
        public string MainSiteID
        {
            get { return CINIFile.IniReadValue("基本信息", "MTUP标识", paths.baseInfoPath); }
            set { m_pMainSiteID = value; }
        }
        public string Verson
        {
            get { return CINIFile.IniReadValue("基本信息", "软件版本", paths.baseInfoPath) + m_pUpdateIdentity; }
        }
        private string m_pUpdateIdentity;
        public string UpdasteIdentity
        {
            set { m_pUpdateIdentity = value; m_pUpdateIdentity += "1"; }
            get { return m_pUpdateIdentity; }
        }
        public void SetDefaultSiteName(string siteName)
        {
            if (OnDefaultSiteNameEvent != null)
                OnDefaultSiteNameEvent(siteName);
        }
    }
}
