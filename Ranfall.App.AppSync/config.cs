using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
namespace Rainfall.App.AppSync
{
    public class XmlConfig
    {
        public static string readSiteName()
        {
            string str = CXml.Read(Application.StartupPath + "\\config.xml", "/Config/site/siteName", "name");
            return (str != null && str != "") ? str : "0";
        }
        public static string readDeviceId()
        {
            string str;
            str = CXml.Read(Application.StartupPath + "\\config.xml", "/Config/site/device", "id");
            return (str != null && str != "") ? str : "0";
        }
        public static string readVerson()
        {
            string str = CXml.Read(Application.StartupPath + "\\config.xml", "/Config/site/version", "number");
            return (str != null && str != "") ? str : "0";
        }
        public static string readBuildTime()
        {
            string str = CXml.Read(Application.StartupPath + "\\config.xml", "/Config/site/build", "time");
            return (str != null && str != "") ? str : "0";
        }
        public static string readUpdateTime()
        {
            string str = CXml.Read(Application.StartupPath + "\\config.xml", "/Config/site/update", "time");
            return (str != null && str != "") ? str : "0";
        }
        public static string readServerIP()
        {
            string str = CXml.Read(Application.StartupPath + "\\config.xml", "/Config/site/server", "ip");
            XmlDocument doc = new XmlDocument();
            doc.Load(Application.StartupPath + "\\config.xml");
            return (str != null && str != "") ? str : "0";
        }
        public static string readComPort()
        {
            string str = CXml.Read(Application.StartupPath + "\\config.xml", "/Config/site/com", "port");
            return (str != null && str != "") ? str : "0";
        }
        public static string readAlarmLevel()
        {
            string str = CXml.Read(Application.StartupPath + "\\config.xml", "/Config/site/alarm", "level");
            return (str != null && str != "") ? str : "0";
        }
        public static string readSoundLevel()
        {
            string str = CXml.Read(Application.StartupPath + "\\config.xml", "/Config/site/alarm", "slevel");
            return (str != null && str != "") ? str : "0";
        }
        public static string readRestorePoint()
        {
            string str = CXml.Read(Application.StartupPath + "\\config.xml", "/Config/site/click", "restorePoint");
            return (str != null && str != "") ? str : "0";
        }
        public static string readOpenPoint()
        {
            string str = CXml.Read(Application.StartupPath + "\\config.xml", "/Config/site/click", "openPoint");
            return (str != null && str != "") ? str : "0";
        }
        public static string readLineName()
        {
            string str = CXml.Read(Application.StartupPath + "\\line.xml", "/Config/site/line", "name");
            return (str != null && str != "") ? str : "0";
        }
        public static string readAlarmTime()
        {
            string str = CXml.Read(Application.StartupPath + "\\config.xml", "/Config/site/alarm", "time");
            return (str != null && str != "") ? str : "0";
        }
        public static string readContStartTime()
        {
            string str = CXml.Read(Application.StartupPath + "\\config.xml", "/Config/site/contAndDailyStartTime", "contStartTime");
            return (str != null && str != "") ? str : "0";
        }
        public static string readDailyStartTime()
        {
            string str = CXml.Read(Application.StartupPath + "\\config.xml", "/Config/site/contAndDailyStartTime", "dailyStartTime");
            return (str != null && str != "") ? str : "0";
        }
        public static string readLimitStartTime()
        {
            string str = CXml.Read(Application.StartupPath + "\\config.xml", "/Config/site/auto", "limitStartTime");
            return (str != null && str != "") ? str : "0";
        }
        public static string readLastUploadTime(string Property)
        {
            string str = CXml.Read(Application.StartupPath + "\\config.xml", "/Config/site/upload", Property);
            return (str != null && str != "") ? str : "0";
        }
        public static string readTrackOpenButtonStatus()
        {
            string str = CXml.Read(Application.StartupPath + "\\config.xml", "/Config/site/button", "isClick");
            return (str != null && str != "") ? str : "0";
        }
        //-----------------------------------------------------------------------------------------------------------------
        public static void writeConfigNode(string node, string attribute, string value)
        {
            CXml.Update(Application.StartupPath + "\\config.xml", "/Config/site/" + node, attribute, value);
        }
        public static void writeSiteName(string value)
        {
            CXml.Update(Application.StartupPath + "\\config.xml", "/Config/site/siteName", "name", value);
        }
        public static void writeDeviceId(string value)
        {
            CXml.Update(Application.StartupPath + "\\config.xml", "/Config/site/device", "id", value);
        }
        public static void writeVerson(string value)
        {
            CXml.Update(Application.StartupPath + "\\config.xml", "/Config/site/version", "number", value);
        }
        public static void writeBuildTime(string value)
        {
            CXml.Update(Application.StartupPath + "\\config.xml", "/Config/site/build", "time", value);
        }
        public static void writeUpdateTime(string value)
        {
            CXml.Update(Application.StartupPath + "\\config.xml", "/Config/site/update", "time", value);
        }
        public static void writeServerIP(string value)
        {
            CXml.Update(Application.StartupPath + "\\config.xml", "/Config/site/server", "ip", value);
        }
        public static void writeComPort(string value)
        {
            CXml.Update(Application.StartupPath + "\\config.xml", "/Config/site/com", "port", value);
        }
        public static void writeAlarmLevel(string value)
        {
            CXml.Update(Application.StartupPath + "\\config.xml", "/Config/site/alarm", "level", value);
        }
        public static void writeSoundLevel(string value)
        {
            CXml.Update(Application.StartupPath + "\\config.xml", "/Config/site/alarm", "slevel", value);
        }
        public static void writeRestorePoint(string value)
        {
            CXml.Update(Application.StartupPath + "\\config.xml", "/Config/site/click", "restorePoint", value);
        }
        public static void writeOpenPoint(string value)
        {
            CXml.Update(Application.StartupPath + "\\config.xml", "/Config/site/click", "openPoint", value);
        }
        public static void writeLineName(string value)
        {
            CXml.Update(Application.StartupPath + "\\line.xml", "/Config/site/line", "name", value);
        }
        public static void writeAlarmTime(string value)
        {
            CXml.Update(Application.StartupPath + "\\config.xml", "/Config/site/alarm", "time", value);
        }
        public static void writeContStartTime(string value)
        {
            CXml.Update(Application.StartupPath + "\\config.xml", "/Config/site/contAndDailyStartTime", "contStartTime", value);
        }
        public static void writeDailyStartTime(string value)
        {
            CXml.Update(Application.StartupPath + "\\config.xml", "/Config/site/contAndDailyStartTime", "dailyStartTime", value);
        }
        public static void writeLimitStartTime(string value)
        {
            CXml.Update(Application.StartupPath + "\\config.xml", "/Config/site/auto", "limitStartTime", value);
        }
        public static void writeLastUploadTime(string value, string Property)
        {
            CXml.Update(Application.StartupPath + "\\config.xml", "/Config/site/upload ", Property, value);
        }
        public static void writeTrackOpenButtonStatus(string value)
        {
            CXml.Update(Application.StartupPath + "\\config.xml", "/Config/site/button ", "isClick", value);
        }
        public static void WriteCCID(string value)
        {
            CXml.Update(Application.StartupPath + "\\config.xml", "/Config/site/device", "CCID", value);
        }
        //----------------------------------------------------------------------------------------------------------------------
        public static int GetPerson(string[] person)
        {
            XmlNodeList pList = CXml.ReadList(Application.StartupPath + "\\person.xml", "/Config/site/person");
            int i = 0;
            try
            {
                foreach (XmlNode nl in pList)
                {
                    person[i] = nl.Attributes[0].Value;
                    i++;
                }
            }
            catch
            {

            }
            return i;
        }
    }
}
