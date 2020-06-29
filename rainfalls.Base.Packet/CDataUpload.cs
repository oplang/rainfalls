using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using Zyf.Ini;
using rainfalls.Abstract.Interface;
using System.Runtime.CompilerServices;

namespace rainfalls.Base.Mtup
{
    public class CDataUpload : IDataUpload
    {
        private static CDataUpload uniqueInstance;
        private static readonly object padlock = new object();
        private string m_pMtupAddress = null;
        private string m_pAliyunAddress = "139.129.8.107";
        protected static byte[] m_bHead = new byte[2] { 0xAB, 0x7B };
        protected static byte[] m_bAppID = new byte[2] { 0x00, 0x03 };
        protected string m_pMoblieID = "4500";
        protected byte[] m_bMobileID = new byte[4];
        private string m_pCommSiteID;
        private string m_pNetWorkState = "正常";

        public string NetWorkState
        {
            get { return m_pNetWorkState; }
            set { m_pNetWorkState = value; }
        }
        public string GetCommSiteID()
        {
            { return m_pCommSiteID; }
        }
        public void SetCommSiteID(string commsiteid)
        {
            m_pCommSiteID = commsiteid;
        }
        private CDataUpload()
        {
            string szAliAddress = CINIFile.IniReadValue("基本信息", "FTP_IP", AppDomain.CurrentDomain.BaseDirectory + "base.ini");
            if (!string.IsNullOrEmpty(szAliAddress))
                m_pAliyunAddress = szAliAddress;

            string szMtupAddress = CINIFile.IniReadValue("基本信息", "MTUP_IP", AppDomain.CurrentDomain.BaseDirectory + "base.ini");
            if (!string.IsNullOrEmpty(szMtupAddress))
                m_pMtupAddress = szMtupAddress;

            string szMobileId = CINIFile.IniReadValue("基本信息", "MTUP标识", AppDomain.CurrentDomain.BaseDirectory + "base.ini");
            if (!string.IsNullOrEmpty(szMobileId))
                m_pMoblieID = szMobileId;

            m_pMoblieID = Convert.ToString(int.Parse(m_pMoblieID), 16);
            m_bMobileID = HexStringToBytes(m_pMoblieID, 8);
        }
        public static CDataUpload getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new CDataUpload();
                    }
                }
            }
            return uniqueInstance;
        }
        private byte[] HexStringToBytes(string hex, int realLength)
        {
            byte[] b = new byte[realLength / 2];
            int iLenght = hex.Length;
            for (int i = iLenght; i < realLength; i++)
                hex = "0" + hex;
            for (int i = 0, j = 0; i < realLength / 2; i++, j += 2)
                b[i] = Convert.ToByte(hex.Substring(j, 2), 16);
            return b;
        }
        private byte[] PackageData(string szData)
        {
            byte[] bData = Encoding.GetEncoding("GB2312").GetBytes(szData);
            byte[] bDataLength = HexStringToBytes(Convert.ToString(bData.Length, 16), 4);
            byte[] bPackage = new byte[m_bHead.Length * 2 + m_bAppID.Length + m_bMobileID.Length + bDataLength.Length + bData.Length];
            Array.Copy(m_bHead, 0, bPackage, 0, m_bHead.Length);
            Array.Copy(m_bAppID, 0, bPackage, m_bHead.Length, m_bAppID.Length);
            Array.Copy(m_bMobileID, 0, bPackage, m_bHead.Length + m_bAppID.Length, m_bMobileID.Length);
            Array.Copy(bDataLength, 0, bPackage, m_bHead.Length + m_bAppID.Length + m_bMobileID.Length, bDataLength.Length);
            Array.Copy(bData, 0, bPackage, m_bHead.Length + m_bAppID.Length + m_bMobileID.Length + bDataLength.Length, bData.Length);
            Array.Copy(m_bHead, 0, bPackage, m_bHead.Length + m_bAppID.Length + m_bMobileID.Length + bDataLength.Length + bData.Length, m_bHead.Length);
            return bPackage;
        }

        private bool SendToAliyun(byte[] buffer)
        {
            bool b = false;

            IPAddress ip = IPAddress.Parse(m_pAliyunAddress);
            IPEndPoint ipEnd = new IPEndPoint(ip, 5006);
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                s.Connect(ipEnd);
                s.Send(buffer);
                b = recvmsgs(s);
                m_pNetWorkState = "正常";
            }
            catch
            {
                m_pNetWorkState = "无法上传";
                b = false;
            }
            finally
            {
                s.Close();
            }
            return b;
        }
        //接受Aliyun的返回信息
        private bool recvmsgs(Socket client)
        {
            try
            {
                byte[] buffer = new byte[1024];
                int size = client.Receive(buffer);
                // string recvesrc = BitConverter.ToString(buffer, 0, size);
                string recvesrc = System.Text.Encoding.ASCII.GetString(buffer, 0, size);
                if (recvesrc.Equals("OK"))
                {
                    m_pNetWorkState = "正常";
                    return true;
                }
            }
            catch
            {
                m_pNetWorkState = "无法上传";
                return false;
            }
            return false;
        }
        private bool SendToMtup(byte[] buffer)
        {
            bool b = true;
            IPAddress ip = IPAddress.Parse(m_pMtupAddress);
            IPEndPoint ipEnd = new IPEndPoint(ip, 5006);
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                s.Connect(ipEnd);
                if (s.Connected)
                    s.Send(buffer);
                else
                    b = false;
            }
            catch
            {
                b = false;
            }
            finally
            {
                s.Close();
            }
            return b;
        }
       [MethodImpl(MethodImplOptions.Synchronized)]
        public bool SendData(string szData)
        {
            byte[] bPackage = PackageData(szData);
           // bool b = SendToAliyun(bPackage) && SendToMtup(bPackage)  ;
            return SendToAliyun(bPackage);
        }
    }
}
