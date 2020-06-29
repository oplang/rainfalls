using System;
using System.Windows.Forms;
using Zyf.Ini;
using rainfalls.path;
using rainfalls.Base.Class;

namespace rainfalls.View.TrackOpenNofityControl
{
    public partial class UITrackOpenNofityControl : UserControl
    {
        private System.Timers.Timer timerCaption = new System.Timers.Timer();
        private static readonly object padlock = new object();
        public UITrackOpenNofityControl()
        {
            InitializeComponent();
            timerCaption.Interval = 1* 1000;
            timerCaption.Elapsed += new System.Timers.ElapsedEventHandler(timerCaption_Elapsed);
            timerCaption.Enabled = true;
        }

        void timerCaption_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
           
        }

        private void OnTimer()
        {
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case CMessage.WM_ONMODIFY_PERSON:
                    lbName.Text = CINIFile.IniReadValue("基本信息", "当前值班负责人", paths.baseInfoPath);
                    break;
            }
            base.WndProc(ref m);
        }
        private void UITrackOpenNofityControl_Load(object sender, EventArgs e)
        {
            IniHelper.IniWriteValue("System", paths.PersonHandle, this.Handle.ToInt32().ToString(), paths.HandlePath);
            string person = CINIFile.IniReadValue("基本信息", "当前值班负责人", paths.baseInfoPath);
            if (string.IsNullOrEmpty(person))
            {
                string szHandle = IniHelper.IniReadValue("System", paths.MainHandle, paths.HandlePath);
                if (szHandle.Length > 0)
                {
                    int nHandle = int.Parse(szHandle);
                    IntPtr pHandle = new IntPtr(nHandle);
                    CWinMsgAPI.PostMessage(pHandle, CMessage.WM_ONADD_PERSON, 0, 0);
                }
            }
            else
            {
                lbName.Text = person;
            }
        }
    }
}
