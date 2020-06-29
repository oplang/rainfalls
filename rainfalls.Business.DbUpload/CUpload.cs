using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rainfalls.Abstract.Class;
using System.IO;
namespace rainfalls.Business.DbUpload
{
    public class CUpload : ADbUpload
    {
        public CUpload(AMtupSync mtup)
            : base(mtup)
        {
            InitQueueR();
        }
        protected override void InitQueueR()
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "RQueue.rqe"))
                File.Create(AppDomain.CurrentDomain.BaseDirectory + "RQueue.rqe");

            using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "RQueue.rqe"))
            {
                string str = null;
                while ((str = sr.ReadLine()) != null)
                    strList.Enqueue(str);
              //  SendQueueRToMTUP();
            }
        }
        public void WriteToQueueR(string szData)
        {
            if (strList.Count == 10)
                strList.Dequeue();
            strList.Enqueue(szData);
            try
            {
                using (FileStream aFile = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "RQueue.rqe", FileMode.Create))
                {
                    StreamWriter sw = new StreamWriter(aFile);
                    foreach (object obj in strList)
                        sw.WriteLine((string)obj);
                    sw.Close();
                }
            }
            catch
            {
            }
            //LogManager.WriteLog(LogFile.RQueue, (string)obj);
        }
        private void SendQueueRToMTUP()
        {
            string szData = null;
            foreach (object obj in strList)
            {
                szData += obj + "\r\n";
            }
            if (string.IsNullOrEmpty(szData))
                return;
            if(m_pMtupSync.SendData(szData))
            if (!SendToMTUP(szData))
                CSQLite.G_CSQLite.WriteToTempDB(szData.Replace("\r\n", "<br>"));
        }
    }
}
