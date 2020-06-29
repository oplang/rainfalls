using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rainfalls.Abstract.Class;
using rainfalls.Base.Class;
using rainfalls.Base.Struct;
using rainfalls.path;
using Zyf.Ini;
namespace rainfalls.Business.WorkSection
{
    public class CWorkSection : AWorkSection
    {
        public override void saveCurLevel()
        {
            CINIFile.IniWriteValue(SiteSection, workAreaCls.siteCurLevel, m_nLevel.ToString(), paths.workAreaPath);
        }

        public override void readCurLevel()
        {
            string szLevel = CINIFile.IniReadValue(SiteSection, workAreaCls.siteCurLevel, paths.levels);
            int l;
            m_nLevel = int.TryParse(szLevel, out l) ? l : 0;
        }
    }
}
