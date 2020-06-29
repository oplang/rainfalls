using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rainfalls.Business.InspectorLab;

namespace rainfalls.Views.Zone
{
    public delegate void RemoveZoneControlDelgate(string uuid);
    public partial class ZoneControl : UserControl
    {
        enum STATE : byte { ToDo = 0, Doing, Done };
        public event RemoveZoneControlDelgate OnRemoveEvent;
        public ZoneControl()
        {
          
            InitializeComponent();
        }
        private string m_pUUID;
        public string UUID
        {
            get { return m_pUUID; }
            set { m_pUUID = value; }
        }
        private int m_nZoneState;
        [Browsable(true), Category("AppearanceZone")]
        public int ZoneState
        {
            get { return m_nZoneState; }
            set { m_nZoneState = value; ChangeState(); }
        }

        private void ChangeState()
        {
            this.lbZoneState.Appearance.ImageIndex = m_nZoneState;
        }

        public void InitializeZoneInfo()
        {
            Inspector pIstor = InspectorsLab.getInstance().GetInspectorByUUID(UUID);
            lbZoneName.Text = pIstor.ZoneName;
            int i;
            if (this.InvokeRequired)
            {
                Action<DevExpress.XtraEditors.LabelControl> InvokeControl = (X) =>
                {
                    if (int.TryParse(pIstor.InspectorState, out i))
                        X.Appearance.ImageIndex = i;
                    else
                        X.Appearance.ImageIndex = 0;
                };
                Invoke(InvokeControl, lbZoneState);
            }
            else
            {
                if (int.TryParse(pIstor.InspectorState, out i))
                    lbZoneState.Appearance.ImageIndex = i;
                else
                    lbZoneState.Appearance.ImageIndex = 0;
            }

            
        }

        private void ControlClick(object sender, EventArgs e)
        {
            frmInspertorManager.getInstance().OnRefreshZoneControl += new RefreshZoneControl(ZoneControl_OnRefreshZoneControl);
            frmInspertorManager.getInstance().OnRemoveZoneConrol += new RemoveZoneControl(ZoneControl_OnRemoveZoneConrol);
            frmInspertorManager.getInstance().LoadingData(this.UUID);
            frmInspertorManager.getInstance().Show();
        }

        void ZoneControl_OnRemoveZoneConrol(string uuid)
        {
            if (OnRemoveEvent != null)
                OnRemoveEvent(uuid);
        }

        void ZoneControl_OnRefreshZoneControl()
        {
            InitializeZoneInfo();
        }
    }
}
