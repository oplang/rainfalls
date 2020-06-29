using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
namespace Rainfall.App.AppSync
{
    public class CUpdate
    {
        private string szAddress = null;
        public CUpdate(string szAddress)
        {
            this.szAddress = szAddress;
        }
        public bool CheckUpdates(out string msg)
        {
            string deviceId = XmlConfig.readDeviceId();
            CFTPClient ftp = null;
            try
            {
                msg = "开始更新进程";
                ftp = new CFTPClient();
                ftp.RemoteHost = szAddress;
                ftp.RemotePath = "update";
                ftp.RemoteUser = "anonymous";
                ftp.RemotePass = "anonymous@anonymous.net";
                ftp.Connect();
                ftp.ChDir(deviceId);
                try
                {
                    ftp.GetFile("Update.xml", Application.StartupPath + "\\", "Update.xml");
                }
                catch
                {
                }

                long NewBuildTime, CurlBuildTime;
                NewBuildTime = CurlBuildTime = 0;

                string strNewBuildTime = CXml.Read(Application.StartupPath+"\\Update.xml", "/update/build ", "time");
                string strCurlBuildTime = XmlConfig.readBuildTime();
                if (string.IsNullOrEmpty(strNewBuildTime))
                {
                    ftp.DisConnect();
                    msg = "远程目录没有设置更新时间";
                    return false;
                }
                else
                    NewBuildTime = long.Parse(strNewBuildTime);
                if (string.IsNullOrEmpty(strCurlBuildTime))
                    strCurlBuildTime = "0";
                CurlBuildTime = long.Parse(strCurlBuildTime);
                if (NewBuildTime > CurlBuildTime)
                {
                    CSQLite.G_CSQLite.WriteRunLogInfoDB("0xDA", "检测到新版本");
                    ftp.DisConnect();
                    msg = "检测到新版本";
                    return true;
                }
                else
                {
                    msg = "当前已是最新版本";
                    CSQLite.G_CSQLite.WriteRunLogInfoDB("0xD9", "当前已是最新版本");
                    return false;
                }
            }
            catch
            {
                try
                {
                    ftp.DisConnect();
                }
                catch
                {
                }
                msg = "检测更新失败";
                CSQLite.G_CSQLite.WriteRunLogInfoDB("E02", "检测更新函数失败");
                return false;
            }
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public bool downLoad(out string msg)
        {
            string deviceId = XmlConfig.readDeviceId();
            XmlNodeList pList = CXml.ReadList(Application.StartupPath+"\\Update.xml", "/update/fileList/file");
            CSQLite.G_CSQLite.WriteRunLogInfoDB("D03", "开始下载更新文件");
            msg = "开始下载更新文件";
            foreach (XmlNode nl in pList)
            {
                try
                {
                    FtpClient ftp = new FtpClient();
                    ftp.Server = szAddress;
                    ftp.RemotePath = "update";
                    ftp.Login();
                    ftp.ChangeDir(deviceId);
                    long nSize = 0;
                    if ((nSize = ftp.GetFileSize(nl.Attributes[0].Value)) > 0)
                    {
                        long nDoneSize = 0;
                        string szFile = null;
                        do
                        {
                            ftp.Download(nl.Attributes[0].Value, Application.StartupPath + "\\Update\\" + nl.Attributes[0].Value, true);
                            szFile = Application.StartupPath + "\\Update\\" + nl.Attributes[0].Value;
                            if (File.Exists(szFile))
                            {
                                FileInfo fi = new FileInfo(szFile);
                                nDoneSize = fi.Length;
                            }
                        } while (nDoneSize != nSize);
                    }
                    ftp.Close();
                }
                catch (Exception e)
                {
                    CSQLite.G_CSQLite.WriteRunLogInfoDB("D05", "更新文件下载失败");
                    msg = nl.Attributes[0].Value + "更新文件下载失败" + e.Message;
                    return false;
                }
            }
            CSQLite.G_CSQLite.WriteRunLogInfoDB("D04", "更新文件下载完成");
            msg = "更新文件下载完成";
            return true;
        }
    }
}
