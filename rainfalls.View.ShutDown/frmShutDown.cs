using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text;
namespace rainfalls.View.ShutDown
{
    public partial class frmShutDown : Form
    {
        private static frmShutDown uniqueInstance;
        private static readonly object padlock = new object();

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

        //创建窗体对象的静态方法
        public static frmShutDown InstanceObject()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new frmShutDown();
                    }
                }
            }
            return uniqueInstance;
        }
        public frmShutDown()
        {
            InitializeComponent();
        }
        [DllImport("shell32.dll")]
        public static extern int ShellExecute(IntPtr hwnd, StringBuilder lpszOp, StringBuilder lpszFile, StringBuilder lpszParams, StringBuilder lpszDir, int FsShowCmd);
        #region 微软提供的关机接口 调用系统的 kernel32.dll  advapi32.dll user32.dll 实现的关机
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct TokPriv1Luid
        {
            public int Count;
            public long Luid;
            public int Attr;
        }

        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GetCurrentProcess();

        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool OpenProcessToken(IntPtr h, int acc, ref IntPtr phtok);

        [DllImport("advapi32.dll", SetLastError = true)]
        internal static extern bool LookupPrivilegeValue(string host, string name, ref long pluid);

        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool AdjustTokenPrivileges(IntPtr htok, bool disall,
            ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool ExitWindowsEx(int DoFlag, int rea);

        internal const int SE_PRIVILEGE_ENABLED = 0x00000002;
        internal const int TOKEN_QUERY = 0x00000008;
        internal const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
        internal const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";
        internal const int EWX_LOGOFF = 0x00000000;
        internal const int EWX_SHUTDOWN = 0x00000001;
        internal const int EWX_REBOOT = 0x00000002;
        internal const int EWX_FORCE = 0x00000004;
        internal const int EWX_POWEROFF = 0x00000008;
        internal const int EWX_FORCEIFHUNG = 0x00000010;
        #endregion
        private void frmShutDown_FormClosed(object sender, FormClosedEventArgs e)
        {
            uniqueInstance = null;
        }
        private static bool DoExitWin(int DoFlag)
        {
            bool ok;
            TokPriv1Luid tp;
            IntPtr hproc = GetCurrentProcess();
            IntPtr htok = IntPtr.Zero;
            ok = OpenProcessToken(hproc, TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, ref htok);
            tp.Count = 1;
            tp.Luid = 0;
            tp.Attr = SE_PRIVILEGE_ENABLED;
            ok = LookupPrivilegeValue(null, SE_SHUTDOWN_NAME, ref tp.Luid);
            ok = AdjustTokenPrivileges(htok, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero);
            ok = ExitWindowsEx(DoFlag, 0);
            return ok;
        }
        private void frmShutDown_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 500, AW_BLEND | AW_ACTIVE);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DoExitWin(EWX_FORCE | EWX_REBOOT);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoExitWin(EWX_FORCE | EWX_POWEROFF);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string appName = "C:\\loadtouch.vbs";
                //string appName = "C:\\Program files\\Notepad++\\Notepad++.exe";
                Process proc = Process.Start(appName);

                //proc.StartInfo.UseShellExecute = false;
                
                proc.Start();
                //int a = ShellExecute(IntPtr.Zero, new StringBuilder("Open"), new StringBuilder("C:\\Touch\\Touchpack.exe"), new StringBuilder(""), new StringBuilder(@"C:/"), 1);
                //System.Windows.Forms.MessageBox.Show(a.ToString());
            }
            catch
            {
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            uniqueInstance = null;
            Hide();
        }

        private void frmShutDown_FormClosing(object sender, FormClosingEventArgs e)
        {
            uniqueInstance = null; AnimateWindow(this.Handle, 500, AW_BLEND | AW_HIDE);
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShutDown_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
