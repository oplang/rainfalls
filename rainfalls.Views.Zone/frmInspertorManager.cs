using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rainfalls.Business.InspectorLab;

namespace rainfalls.Views.Zone
{
    public delegate void RefreshZoneControl();
    public delegate void RemoveZoneControl(string uuid);
    public partial class frmInspertorManager : Form
    {
        public event RefreshZoneControl OnRefreshZoneControl;
        public event RemoveZoneControl OnRemoveZoneConrol;
        private static frmInspertorManager uniqueInstance;
        private static readonly object padlock = new object();
        private string s1 = "派人巡守";
        private string s2 = "保存派工单";
        private const string m_pTxtWorkNumberNotify = "请在30分钟内填写派工单";
        private frmInspertorManager()
        {
            InitializeComponent();
            //this.txtWorkNumber.
        }
        public static frmInspertorManager getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new frmInspertorManager();
                    }
                }
            }
            return uniqueInstance;
        }
        private string m_pUUID = null;
        public void LoadingData(string uuid)
        {
            m_pUUID = uuid;
            Inspector pIstor = InspectorsLab.getInstance().GetInspectorByUUID(uuid);
            
            lbCaption.Text = string.Format("{0}-【{1}巡守】",pIstor.ZoneName,pIstor.ZoneLevel == 2?"限速":"扣车");
            sbtnStart.Text = s1;
            if (pIstor.InspectorState.Equals("0"))
            {
                sbtnStop.Enabled = false;
                radioGroupPerson.Properties.Items.Clear();
                foreach (Person p in PersonLab.getInstance().PersonList)
                {
                    if (p.PersonState.Equals("0"))
                    {

                        radioGroupPerson.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(p.PersonPhone, string.Format("{0}-{1}", p.PersonName, p.PersonPhone)));
                    }
                }
                radioGroupPerson.Enabled = true;
            }
            if (pIstor.InspectorState.Equals("1"))
            {
                radioGroupPerson.Properties.Items.Clear();
                radioGroupPerson.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(pIstor.PersonPhone, string.Format("{0}-{1}", pIstor.PersonName, pIstor.PersonPhone)));
                radioGroupPerson.Enabled = false;
                if (!string.IsNullOrEmpty(pIstor.WorkNumber))
                {
                    txtWorkNumber.Enabled = false;
                    sbtnStop.Enabled = true;
                    EnabledNumberButton(false);
                }
                else
                {
                    sbtnStart.Text = s2;
                    sbtnStop.Enabled = false;
                }
            }
            if (!string.IsNullOrEmpty(pIstor.WorkNumber))
            {
                sbtnStart.Enabled = false;
                sbtnStop.Enabled = true;
                txtWorkNumber.Text = pIstor.WorkNumber;
            }
            else
            {
                sbtnStart.Enabled = true;
                sbtnStop.Enabled = false;
            }
            
        }
        void EnabledNumberButton(bool b)
        {
            btn0.Enabled = b;
            btn1.Enabled = b;
            btn2.Enabled = b;
            btn3.Enabled = b;
            btn4.Enabled = b;
            btn5.Enabled = b;
            btn6.Enabled = b;
            btn7.Enabled = b;
            btn8.Enabled = b;
            btn9.Enabled = b;
            sbtnNumberDel.Enabled = b;
        }
        private void sbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sbtnStart_Click(object sender, EventArgs e)
        {
            if (sbtnStart.Text.Equals(s1))
            {
                if (radioGroupPerson.SelectedIndex == -1)
                {
                    return;
                }
                else
                {
                    string phone = radioGroupPerson.Properties.Items[radioGroupPerson.SelectedIndex].Value.ToString();
                    InspectorsLab.getInstance().AddPersonDoing(m_pUUID, phone,txtWorkNumber.Text);
                    this.Close();
                }
            }
            if (sbtnStart.Text.Equals(s2))
            {
                InspectorsLab.getInstance().UpdateWorkNumber(m_pUUID, txtWorkNumber.Text);
                this.Close();
            }
            if (OnRefreshZoneControl != null)
                OnRefreshZoneControl();
        }

        private void frmInspertorManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            uniqueInstance = null;
        }

        private void frmInspertorManager_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnNumberClick(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.SimpleButton btn = sender as DevExpress.XtraEditors.SimpleButton;
            txtWorkNumber.Text += btn.Text;
        }

        private void sbtnNumberDel_Click(object sender, EventArgs e)
        {
            int nLength = txtWorkNumber.Text.Length;
            if (nLength > 0)
                txtWorkNumber.Text = txtWorkNumber.Text.Remove(nLength - 1);
        }

        private void sbtnStop_Click(object sender, EventArgs e)
        {
            InspectorsLab.getInstance().InspectorDone(m_pUUID);
            if (OnRemoveZoneConrol != null)
                OnRemoveZoneConrol(m_pUUID);
            this.Close();
        }
    }
}
