using System;
using System.Windows.Forms;
using Zyf.Ini;
using rainfalls.path;
using System.Xml;
using System.IO;
using rainfalls.Base.ErrorHandle;
using rainfalls.Base.Class;
using System.Runtime.InteropServices;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;

namespace rainfalls.View.frmConfig
{
    public delegate void UpdatePerson(string name);
    public partial class frmUserInfo : Form
    {
        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        //下面是可用的常量，根据不同的动画效果声明自己需要的  
        private const int AW_HOR_POSITIVE = 0x0001;//自左向右显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志  
        private const int AW_HOR_NEGATIVE = 0x0002;//自右向左显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志  
        private const int AW_VER_POSITIVE = 0x0004;//自顶向下显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志  
        private const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志该标志  
        private const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；否则向外扩展  
        private const int AW_HIDE = 0x10000;//隐藏窗口  
        private const int AW_ACTIVE = 0x20000;//激活窗口，在使用了AW_HIDE标志后不要使用这个标志  
        private const int AW_SLIDE = 0x40000;//使用滑动类型动画效果，默认为滚动动画类型，当使用AW_CENTER标志时，这个标志就被忽略  
        private const int AW_BLEND = 0x80000;//使用淡入淡出效果 
        const int CS_DropSHADOW = 0x20000;
        const int GCL_STYLE = (-26);
        //声明Win32 API
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);

        private string m_pCurPerson=null;
        private static frmUserInfo uniqueInstance;
        private static readonly object padlock = new object();
        public event UpdatePerson OnChangePerson;
        private frmUserInfo()
        {
            InitializeComponent();
            SetClassLong(this.Handle, GCL_STYLE, GetClassLong(this.Handle, GCL_STYLE) | CS_DropSHADOW); //API函数加载，实现窗体边框阴影效果
        }
        public static frmUserInfo getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new frmUserInfo();
                    }
                }
            }
            return uniqueInstance;
        }
        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            
            lbVersion.Text =   CINIFile.IniReadValue("基本信息", "软件版本", paths.baseInfoPath);
            lbUpdateTime.Text =   CINIFile.IniReadValue("基本信息", "更新时间", paths.baseInfoPath);
            lbUpdateID.Text =   CINIFile.IniReadValue("基本信息", "更新标识", paths.baseInfoPath);
            lbMtup.Text =  CINIFile.IniReadValue("基本信息", "MTUP标识", paths.baseInfoPath);
            string pCruPerson = CINIFile.IniReadValue("基本信息", "当前值班负责人", paths.baseInfoPath);
            m_pCurPerson = string.IsNullOrEmpty(pCruPerson) ? "" : pCruPerson;
           
            GetPerson();
            FillPerson();
            AnimateWindow(this.Handle, 500, AW_BLEND | AW_ACTIVE);
        }
        protected int GetPerson()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(paths.personPath);
            XmlNodeList pList = doc.SelectNodes("/Config/site/person");

            int i = 0;
            try
            {
                foreach (XmlNode nl in pList)
                {
                    RadioGroupItem item = new RadioGroupItem();
                    item.Value = nl.Attributes[0].Value;
                    item.Description = nl.Attributes[0].Value;
                    m_pRadioPersonGroup.Properties.Items.Add(item);
                    if (m_pCurPerson.Equals(nl.Attributes[0].Value))
                    {
                        m_pRadioPersonGroup.SelectedIndex = i;
                    }

                    i++;
                }
            }
            catch
            {

            }
            return i;
        }
        public void FillPerson()
        {
             string per = "";
            XmlDocument doc = new XmlDocument();
            if (!File.Exists(paths.personPath))
            {
                CError.getInstance().Show(string.Format("没有找到防洪负责人配置文件"));
                return;
            }
            doc.Load(paths.personPath);
            XmlNodeList pList = doc.SelectNodes("/Config/site/person");
            int i = 0;
            try
            {
                foreach (XmlNode nl in pList)
                {
                    per+= string.Format("【{0}】", nl.Attributes[0].Value);
                   
                }
                lbPerson.Text =per;
            }
            catch
            {
                CError.getInstance().Show(string.Format("读取防洪负责人时发生错误"));
            }
        }


        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUserInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            uniqueInstance = null;
            AnimateWindow(this.Handle, 500, AW_BLEND | AW_HIDE);
        }

        private void frmUserInfo_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_pRadioPersonGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioGroup rgp = (RadioGroup)sender;
            string name = rgp.Properties.Items[rgp.SelectedIndex].Description;


            CINIFile.IniWriteValue("基本信息", "当前值班负责人", name, paths.baseInfoPath);
            string szHandle = IniHelper.IniReadValue("System", paths.PersonHandle, paths.HandlePath);
            if (szHandle.Length > 0)
            {
                int nHandle = int.Parse(szHandle);
                IntPtr pHandle = new IntPtr(nHandle);
                CWinMsgAPI.PostMessage(pHandle, CMessage.WM_ONMODIFY_PERSON, 0, 0);
            }
            if (OnChangePerson != null)
                OnChangePerson(name);
        }
    }
}
