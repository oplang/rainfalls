using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zyf.Xml.Helper;
using System.Runtime.CompilerServices;
using rainfalls.Abstract.Class;
using rainfalls.Base.Struct;
using rainfalls.Business.Section;
using System.Windows.Forms;
namespace rainfalls.Model.XmlHelper
{
    public  class CRainfallXmlHelper
    {
        public readonly string configPath = Application.StartupPath + "\\config.xml";
        private static CRainfallXmlHelper uniqueInstance;
        private static readonly object padlock = new object();

        private CRainfallXmlHelper()
        {
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static CRainfallXmlHelper getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new CRainfallXmlHelper();
                    }
                }
            }
            return uniqueInstance;
        }
        public string siteName
        {
            get { return xmlHelper.Read(configPath, "/Config/workArea", "监测站"); }
        }
        public string updateID
        {
            get { return xmlHelper.Read(configPath, "/Config/workArea", "更新标识"); }
        }
        //public List<string> GetSection()
        //{
        //    List<string> seclist = new List<string>();
        //    System.Xml.XmlNodeList list = xmlHelper.GetXmlNodeList(configPath, "/Config/rtu");
        //    foreach (System.Xml.XmlNode nl in list)
        //    {
        //        seclist.Add(nl.Attributes["区间"].Value);
        //    }
        //    return seclist;
        //}
        public List<ASectionObj> GetSection()
        {
            List<ASectionObj> seclist = new List<ASectionObj>();
            try
            {
                System.Xml.XmlNodeList list = xmlHelper.GetXmlNodeList(configPath, "/Config/section");
                foreach (System.Xml.XmlNode nl in list)
                {
                    ASectionObj sec = new CSectionObj();
                    sec.ID = nl.Attributes["ID"].Value;
                    sec.SectionName = nl.Attributes["区间"].Value;
                    sec.LineName = nl.Attributes["线路"].Value;
                    sec.XingBieName = nl.Attributes["行别"].Value;
                    seclist.Add(sec);
                }
            }
            catch { };
            return seclist;
        }
        public List<siteInfo> GetRTUSiteInfo()
        {
            List<siteInfo> siteList = new List<siteInfo>();
            try
            {
                System.Xml.XmlNodeList list = xmlHelper.GetXmlNodeList(configPath, "/Config/section");
                foreach (System.Xml.XmlNode nl in list)
                {
                    string section_id = nl.Attributes[0].Value;
                    string section = nl.Attributes[1].Value;
                    System.Xml.XmlNodeList childList = nl.SelectNodes("site");
                    foreach (System.Xml.XmlNode xnl in childList)
                    {
                        siteInfo s = new siteInfo();
                        s.section_id = section_id;
                        s.section = section;
                        s.id = xnl.Attributes["采集标识"].Value;
                        s.km = xnl.Attributes["里程"].Value;
                        siteList.Add(s);
                    }
                }
            }
            catch { };
            return siteList;
        }
        public siteInfo GetCommSiteInfo()
        {
            siteInfo site = new siteInfo();
            try
            {
                System.Xml.XmlNodeList list = xmlHelper.GetXmlNodeList(configPath, "/Config/workArea");
                foreach (System.Xml.XmlNode nl in list)
                {
                    System.Xml.XmlNodeList childList = nl.SelectNodes("site");
                    foreach (System.Xml.XmlNode xnl in childList)
                    {
                        site.section = null;
                        site.id = xnl.Attributes["采集标识"].Value;
                        site.km = xnl.Attributes["里程"].Value;
                    }
                }
            }
            catch { }
            return site;
        }
    }
}
