using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using rainfalls.Base.Struct;
using Zyf.Ini;
using rainfalls.path;
namespace rainfalls.Rtu.Single
{
    public class rtuSite
    {
        // public event commStateChange onCommStateChangeEvent;
        private static rtuSite uniqueInstance;
        private static readonly object padlock = new object();
        private List<rtuSiteSRC> rtuList = new List<rtuSiteSRC>();
        private workAreaStruct workAreaInfo = new workAreaStruct();
        private rtuSite()
        {
           Initialize();
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static rtuSite getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new rtuSite();
                    }
                }
            }
            return uniqueInstance;
        }
        public workAreaStruct workAreaInfomation
        {
            get
            {
                return workAreaInfo;
            }
        }
        private void Initialize()
        {
            workAreaInfo.site_id = CINIFile.IniReadValue(workAreaCls.section, workAreaCls.siteId, paths.workAreaPath);
            workAreaInfo.site_name = CINIFile.IniReadValue(workAreaCls.section, workAreaCls.siteName, paths.workAreaPath);
            workAreaInfo.site_km = CINIFile.IniReadValue(workAreaCls.section, workAreaCls.siteKm, paths.workAreaPath);
            workAreaInfo.site_qj = CINIFile.IniReadValue(workAreaCls.section, workAreaCls.siteQj, paths.workAreaPath);
            workAreaInfo.siteDev_Id = CINIFile.IniReadValue(workAreaCls.section, workAreaCls.siteDevId, paths.workAreaPath);
            workAreaInfo.siteMtup_Id = CINIFile.IniReadValue(workAreaCls.section, workAreaCls.siteMtupId, paths.workAreaPath);
            workAreaInfo.webServiceAddress = CINIFile.IniReadValue(workAreaCls.section, workAreaCls.webServiceAddress, paths.workAreaPath);
            workAreaInfo.siteCurLevel = CINIFile.IniReadValue(workAreaCls.section, workAreaCls.siteCurLevel, paths.workAreaPath);
            workAreaInfo.xianBie = CINIFile.IniReadValue(workAreaCls.section, workAreaCls.xianBie, paths.workAreaPath);
        }
        public List<rtuSiteSRC> getRTUSite()
        {
            rainfallsWebServer.rainfalls rf = new rainfallsWebServer.rainfalls();
            rainfallsWebServer.childStruct [] child = rf.getChildSite(workAreaInfo.site_id);
            for (int i = 0; i <= child.Length - 1; i++)
            {
                rtuSiteSRC c = new rtuSiteSRC();
                c.site_id = child[i].site_id;
                c.site_name = child[i].site_name;
                c.site_km = child[i].site_km;
                c.TERM_SN = child[i].TERM_SN;
                c.qj = child[i].qj;
                rtuList.Add(c);
            }
            return rtuList;
        }
    }
}
