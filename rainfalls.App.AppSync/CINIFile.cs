using System;
using System.Collections.Generic;
using System.Text;

namespace rainfalls.App.AppSync
{
    /// <summary>
    /// 操作ini配置文件的类
    /// </summary>
    public class CINIFile
    {
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// 写 ini 文件
        /// </summary>
        /// <param name="Section">Section</param>
        /// <param name="Key">Key</param>
        /// <param name="Value">Value</param>
        /// <param name="filepath">filepath</param>
        public static void IniWriteValue(string Section, string Key, string Value, string filepath)
        {
            WritePrivateProfileString(Section, Key, Value, filepath);
        }

        /// <summary>
        /// 读 ini 文件
        /// </summary>
        /// <param name="Section">Section</param>
        /// <param name="Key">Key</param>
        /// <param name="filepath">filepath</param>
        /// <returns></returns>
        public static string IniReadValue(string Section, string Key, string filepath)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, filepath);
            return temp.ToString();
        }

    }
}
