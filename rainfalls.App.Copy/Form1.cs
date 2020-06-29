using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace rainfalls.App.Copy
{
    public partial class Copy : Form
    {
        string source = Application.StartupPath + "\\Update";
        string destination = Application.StartupPath;
        public Copy()
        {
            InitializeComponent();
        }
        public static void CopyDirectory(string source, string destination)
        {
            DirectoryInfo info = new DirectoryInfo(source);
            foreach (FileSystemInfo fsi in info.GetFileSystemInfos())
            {
                //目标路径destName = 目标文件夹路径 + 原文件夹下的子文件(或文件夹)名字
                //Path.Combine(string a ,string b) 为合并两个字符串
                String destName = Path.Combine(destination, fsi.Name);
                //如果是文件类,就复制文件
                if (fsi is System.IO.FileInfo)
                {
                    File.Copy(fsi.FullName, destName, true);
                    File.Delete(fsi.FullName);
                }
                //如果不是 则为文件夹,继续调用文件夹复制函数,递归
                else
                {
                    Directory.CreateDirectory(destName);
                    CopyDirectory(fsi.FullName, destName);
                }
            }
        }

        private void Copy_Load(object sender, EventArgs e)
        {
            try
            {
                CopyDirectory(source, destination);
            }
            catch
            {
                this.Close();
            }
            this.Close();
        }

        private void Copy_FormClosed(object sender, FormClosedEventArgs e)
        {
            string appName = Application.StartupPath + "\\Rainfall.App.AppSync.exe";
            Process proc = Process.Start(appName);
        }

    }
}
