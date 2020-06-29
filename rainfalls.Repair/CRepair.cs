using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zyf.Ini;
using rainfalls.path;
using System.IO;
namespace rainfalls.Repair
{
    public class CRepair
    {
        private static CRepair uniqueInstance;
        private static readonly object padlock = new object();
        private IList<string> m_pMainSectionList = new List<string>();

        private CRepair()
        {
            if (File.Exists(paths.Repair))
            {
                string iniMainSS = IniHelper.IniReadValue("config", "ids", paths.Repair);
                if (!string.IsNullOrEmpty(iniMainSS))
                {
                    string[] ids = iniMainSS.Split('#');
                    foreach (var id in ids)
                    {
                        m_pMainSectionList.Add(id);
                    }
                }
            }

           
        }
        public static CRepair getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new CRepair();
                    }
                }
            }
            return uniqueInstance;
        }
        public bool IsInMainSite(string id)
        {
            foreach (var item in m_pMainSectionList)
                if (item.Equals(id))
                    return true;
            return false;
        }
        
    }
}
