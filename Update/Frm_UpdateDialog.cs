using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;
using System.Threading;

namespace Update
{
    public partial class Frm_UpdateDialog : Form
    {
        string source = Application.StartupPath + "\\Update";
        string destination = Application.StartupPath;
        protected IDbManager m_pDbManager = null;
        protected IDbManager m_pDbTempManager = null;
        private string szPath = Application.StartupPath + "\\base.ini";
        public Frm_UpdateDialog()
        {
            InitializeComponent();
        }
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
            string key, string def, System.Text.StringBuilder retVal,
            int size, string filePath);
        public static long writePrivateProfileString(string section, string key, string val, string filePath)
        {
            long t = WritePrivateProfileString(section,
                                                key,
                                                val,
                                                filePath);
            return t;
        }
        public static int getPrivateProfileString(string section,
            string key, string def, System.Text.StringBuilder retVal,
            int size, string filePath)
        {
            int t = GetPrivateProfileString(section,
                                             key,
                                             def,
                                             retVal,
                                             size,
                                             filePath);
            return t;
        }
        private static string ReadNewBuildTime(string path, string node, string attribute)
        {
            string value = "";
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                value = (attribute.Equals("") ? xn.InnerText : xn.Attributes[attribute].Value);
            }
            catch { }
            return value;
        }


        private void btnInstall_Click(object sender, EventArgs e)
        {
            KillRainfallProcess();
            //string version = getPrivateProfileString("基本信息","软件版本","0",
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString("基本信息", "软件版本", "", temp, 255, szPath);
      
            CopyDirectory(this.source, this.destination);
            //writePrivateProfileString("Update", "isHaveNewVersion", "0", szPath);

            XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(AppDomain.CurrentDomain.BaseDirectory + "Update.xml");
            XmlNodeList pList = doc.SelectNodes("/update/valueList/item");
            try
            {
                foreach (XmlNode nl in pList)
                {
                    writePrivateProfileString("基本信息", nl.Attributes[0].Value, nl.Attributes[1].Value, szPath);
                }
            }
            catch
            {
            }
            string strNewBuildTime = ReadNewBuildTime(Application.StartupPath + "\\Update.xml", "/update/build ", "time");
            writePrivateProfileString("基本信息","GMT",strNewBuildTime,szPath);
            writePrivateProfileString("基本信息", "更新时间", DateTime.Now.ToString(), szPath);
            CSQLite.G_CSQLite.WriteRunLogInfoDB("0xEF", "更新完成", temp.ToString());
            this.Close();
        }
        private void KillProcessExists()
        {
            Process[] processes = Process.GetProcessesByName("Rainfall.App.AppSync");
            if(processes.Length<=0)
                MessageBox.Show("Not Find Process");
            foreach (Process p in processes)
            {
                p.Kill();
                p.Close();
            }
            Thread.Sleep(1000);
        }
        private void KillRainfallProcess()
        {
            Process[] processes = Process.GetProcessesByName("Rainfall");
            foreach (Process p in processes)
            {
                p.Kill();
                p.Close();
            }
            Thread.Sleep(1000);
        }
        private void StartProcess()
        {
            try
            {
                if (!CheckProcessExists())
                {
                    Process p = new Process();
                    p.StartInfo.FileName = System.IO.Path.Combine(Application.StartupPath, "rainfall.App.AppSync.exe");
                    p.StartInfo.Arguments = "rainfall.App.AppSync.exe";
                    p.StartInfo.UseShellExecute = true;
                    p.Start();
                    p.WaitForInputIdle(10000);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + " " + ex.Message);
            }
        }

        private bool CheckProcessExists()
        {
            Process[] processes = Process.GetProcessesByName("rainfall.App.AppSync");
            foreach (Process p in processes)
            {
                if (System.IO.Path.Combine(Application.StartupPath, "rainfall.App.AppSync.exe") == p.MainModule.FileName)
                    return true;
            }
            return false;
        }

        public  void CopyDirectory(string source, string destination)
        {
            int i = 0;
            DirectoryInfo info = new DirectoryInfo(source);
            foreach (FileSystemInfo fsi in info.GetFileSystemInfos())
            {
                //目标路径destName = 目标文件夹路径 + 原文件夹下的子文件(或文件夹)名字
                //Path.Combine(string a ,string b) 为合并两个字符串
                String destName = Path.Combine(destination, fsi.Name);
                //如果是文件类,就复制文件
                if (fsi is System.IO.FileInfo)
                {
                    do
                    {
                    
                            if (fsi.Name == "Rainfall.App.AppSync.exe")
                            {
                                KillProcessExists();
                                File.Copy(fsi.FullName, destName, true);
                                File.Delete(fsi.FullName);
                                StartProcess();
                            }
                            else
                            {
                                File.Copy(fsi.FullName, destName, true);
                                File.Delete(fsi.FullName);
                            }

                            i++;
                    } while (File.Exists(fsi.FullName));
                }
                //如果不是 则为文件夹,继续调用文件夹复制函数,递归
                else
                {
                    Directory.CreateDirectory(destName);
                    CopyDirectory(fsi.FullName, destName);
                }
            }
            StringBuilder temp = new StringBuilder(255);
            GetPrivateProfileString("基本信息", "软件版本", "", temp, 255, szPath);
            CSQLite.G_CSQLite.WriteRunLogInfoDB("0xEE" + i.ToString(), "单击更新提示安装", temp.ToString());
        }

        private void Frm_UpdateDialog_Load(object sender, EventArgs e)
        {
            m_pDbManager = new CDbManager_Sqlite(Application.StartupPath + "\\rainfall.sqlite", "");
            m_pDbTempManager = new CDbManager_Sqlite(Application.StartupPath + "\\temp.sqlite", "");
            CSQLite.G_CSQLite = new CSQLite(m_pDbManager, m_pDbTempManager);

            XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(AppDomain.CurrentDomain.BaseDirectory + "Update.xml");
            XmlNodeList pList = doc.SelectNodes("/update/fileList/file");

            int i = 0;
            foreach (XmlNode nl in pList)
            {
                this.lbMsg.Items.Add(nl.Attributes[0].Value);
                i++;
            }
            this.txtCaption.Text = string.Format("检测到{0}个更新文件,单击安装完成更新!",i);
            if(i == 0)
                this.txtCaption.Text = string.Format("检测到新的配置文件,单击安装完成更新!", i);
        }
    }
    public class Time
    {
        //DateTime ========>  UTC Local time
        public static long DateTime2DbTime(System.DateTime dt)
        {
            long l = dt.ToFileTime();
            return (long)((l - 116444736000000000) / 10000000);
        }

        //UTC Local Time =======> DateTime
        public static System.DateTime DbTime2DateTime(long dbTime)
        {
            long l = dbTime * 10000000 + 116444736000000000;
            System.DateTime dt = System.DateTime.FromFileTime(l);
            return dt;
        }
    }
}