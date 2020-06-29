using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using rainfalls.Business.InspectorLab;

namespace rainfalls.Views.DockFormInspector
{
    public partial class frmConfim : Form
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
        private string m_pUUID;
        private static frmConfim uniqueInstance;
        private static readonly object padlock = new object();
        
        private frmConfim()
        {
            InitializeComponent();
        }
        public static frmConfim getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new frmConfim();
                    }
                }
            }
            return uniqueInstance;
        }
        public string uuid
        {
            set { m_pUUID = value; }
        }
        private void frmConfim_Load(object sender, EventArgs e)
        {
            int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
            int y = Control.MousePosition.Y+18;
            this.Location = new Point(x, y);//设置窗体在屏幕右下角显示  
            AnimateWindow(this.Handle, 500, AW_SLIDE | AW_ACTIVE | AW_HOR_NEGATIVE);
           
        }

        private void frmConfim_FormClosing(object sender, FormClosingEventArgs e)
        {
            uniqueInstance = null;
            AnimateWindow(this.Handle, 500, AW_BLEND | AW_HIDE);
        }

        private void frmConfim_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(m_pUUID))
            //{
            //    InspectorsLab.getInstance().InspectorDone(m_pUUID);
            //    CFilter.getInstance().Update();
            //    this.Close();
            //}
        }
    }
}
