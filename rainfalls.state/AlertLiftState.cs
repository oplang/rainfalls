using System;
using System.Collections.Generic;
using System.Text;
using Zyf.Ini;
using rainfalls.path;
namespace rainfalls.state
{
    public class AlertLiftState
    {
        private volatile static AlertLiftState _instance = null;
        private string mSection = "Lift";
        private string mKey = "Value";
        private string m_sLiftSpeedValue;
        private string m_sLiftSpeedTime;
        private string m_sBreakOpenValue;
        private string m_sBreakOpenTime;
        private static readonly object lockHelper = new object();
        private AlertLiftState() { }
        public static AlertLiftState getInstance()
        {
            if(_instance == null)
            {
                lock(lockHelper)
                {
                    if(_instance == null)
                        _instance = new AlertLiftState();
                }
            }
            return _instance;
        }

        public void saveLiftValue(int value)
        {
            CINIFile.IniWriteValue(mSection, mKey, value.ToString(), paths.liftPath);
        }
        public int readLiftValue()
        {
            string value = "0";
            value = CINIFile.IniReadValue(mSection, mKey, paths.liftPath);
            return int.Parse(value);
        }
    }
}
