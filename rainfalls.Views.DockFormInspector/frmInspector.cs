using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using rainfalls.Business.InspectorLab;
using rainfalls.path;
using System.Threading;
using Zyf.Ini;
using rainfalls.Base.Class;
using rainfalls.Views.Zone;
namespace rainfalls.Views.DockFormInspector
{
    public partial class frmInspector : DockContent
    {
        private static frmInspector uniqueInstance;
        private static readonly object padlock = new object();
        BindingSource m_pInspectorSource = new BindingSource();
        [System.Runtime.InteropServices.DllImport("winmm")]
        extern static bool PlaySound(string strFile, IntPtr hMod, int flag);
        Thread m_pSoundThread = null;
        ThreadStart m_pStart;
        public enum Flags : int
        {
            SND_SYNC = 0x0,    // play synchronously (default) 
            SND_ASYNC = 0x1,    // play asynchronously 
            SND_NODEFAULT = 0x2,    // silence (!default) if sound not found 
            SND_MEMORY = 0x4,      // pszSound points to a memory file 
            SND_LOOP = 0x8,    // loop the sound until next sndPlaySound 
            SND_NOSTOP = 0x10,      // don't stop any currently playing sound 
            SND_NOWAIT = 0x2000,    // don't wait if the driver is busy 
            SND_ALIAS = 0x10000,    // name is a registry alias 
            SND_ALIAS_ID = 0x110000,// alias is a predefined ID 
            SND_FILENAME = 0x20000, // name is file name 
            SND_RESOURCE = 0x40004, // name is resource name or atom 
        };
        private Dictionary<string, ZoneControl> m_pZoneControlList = new Dictionary<string, ZoneControl>();
        private frmInspector()
        {
            m_pStart = new ThreadStart(SoundThread);
            InitializeComponent();
            this.AllowEndUserDocking = false;
        }
        public static frmInspector getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new frmInspector();
                    }
                }
            }
            return uniqueInstance;
        }
        private void AddNewTask(string uuid)
        {

        }
        void SoundThread()
        {
            //try
            //{
            //    for (; ; )
            //    {
            //        if (InspectorsLab.getInstance().GetTodoTaskNumber() > 0)
            //            PlaySound(paths.messageSoundPath, IntPtr.Zero, (int)(Flags.SND_FILENAME | Flags.SND_SYNC));
            //    }


            //}
            //catch (Exception e)
            //{
            //    //Shared.Base.CLog.LOG(e.Message);
            //    //Shared.Base.CLog.LOG("Exception occur in SoundThread()");
            //}
        }

        private void frmInspector_Load(object sender, EventArgs e)
        {
            IniHelper.IniWriteValue("System", paths.InSperctorHandle, this.Handle.ToInt32().ToString(), paths.HandlePath);
            LoadingInspectorData();
            InspectorsLab.getInstance().OnNewTaskEvent += new NewTaskDelegate(frmInspector_OnNewTaskEvent);
        }

        void frmInspector_OnNewTaskEvent(int level)
        {
            LoadingInspectorData();
        }
        private void LoadingInspectorData()
        {
            List<Inspector> pList = InspectorsLab.getInstance().InspectorList;
            foreach (Inspector isp in pList)
            {
                if (!m_pZoneControlList.Keys.Contains(isp.UUID))
                {
                    ZoneControl pZoneControl = new ZoneControl();
                    pZoneControl.UUID = isp.UUID;
                    pZoneControl.Dock = DockStyle.Top;
                    pZoneControl.Show();
                    pZoneControl.InitializeZoneInfo();
                    pZoneControl.OnRemoveEvent += new RemoveZoneControlDelgate(pZoneControl_OnRemoveEvent);
                    AsyncAddControl(pZoneControl);
                    m_pZoneControlList.Add(isp.UUID, pZoneControl);
                }

            }
        }

        void pZoneControl_OnRemoveEvent(string uuid)
        {
            RemoveZonCtrol(uuid);
        }
        public void RemoveZonCtrol(string uuid)
        {
            foreach (var item in m_pZoneControlList)
            {
                if (item.Key.Equals(uuid))
                {
                    m_pZoneControlList.Remove(uuid);
                    item.Value.Dispose();
                    break;
                }

            }
        }
        private void AsyncAddControl(ZoneControl pZoneControl)
        {
            if (this.InvokeRequired)
            {
                Action<Form> actionAddrCtrl = (X) =>
                {
                    X.Controls.Add(pZoneControl);
                };
                Invoke(actionAddrCtrl, this);
            }
            else
            {
                this.Controls.Add(pZoneControl);
            }
        }
        void InspectorGridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //PersonLab.getInstance().UpdatePersonState("13535678909","1");
            //int i = this.InspectorGridView.FocusedRowHandle;
            //if (i >= 0)
            //{
            //    object needAlert = InspectorGridView.GetRowCellValue(this.InspectorGridView.FocusedRowHandle, InspectorGridView.Columns["UUID"]);
            //    string id = (string)needAlert;

            //    if (!InspectorsLab.getInstance().IsDoing(id))
            //    {
            //        frmPerson.getInstance().SetInspectorID(id);
            //        frmPerson.getInstance().BindingPersonList();
            //        frmPerson.getInstance().StartPosition = FormStartPosition.Manual;
            //        frmPerson.getInstance().Width = this.Width;
            //        frmPerson.getInstance().Height = this.Height - this.lbWarning.Height - 30 - ((i + 1) * 35);
            //        frmPerson.getInstance().Show();
            //    }
            //    else
            //    {
            //        //结束巡查操作
            //        frmConfim.getInstance().StartPosition = FormStartPosition.Manual;
            //        frmConfim.getInstance().Width = this.Width;
            //        frmConfim.getInstance().uuid = id;
            //        frmConfim.getInstance().Show();
            //    }
            //}
           

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (InspectorsLab.getInstance().GetTodoTaskNumber() > 0)
            //{
            //    this.lbWarning.Visible = true;
            //    if (m_pSoundThread == null)
            //    {
            //        m_pSoundThread = new Thread(m_pStart);
            //        m_pSoundThread.Start();
            //    }
            //}
            //else
            //{
            //    this.lbWarning.Visible = false;
            //    if (m_pSoundThread != null)
            //        if (m_pSoundThread.IsAlive)
            //            m_pSoundThread.Abort();
            //}
            //if (this.lbWarning.Appearance.ImageIndex == 0)
            //    this.lbWarning.Appearance.ImageIndex = 1;
            //else
            //    this.lbWarning.Appearance.ImageIndex = 0 ;
        }

        private void frmInspector_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_pSoundThread != null)
                if (m_pSoundThread.IsAlive)
                    m_pSoundThread.Abort();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //InspectorsLab.getInstance().Test();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            frmInspectorDetail.getInstance().Show();
        }

        private void lbInspectorConfig_Click(object sender, EventArgs e)
        {
            frmConfig.getInstance().Show();
        }
    }
}
