using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using rainfalls.Abstract.Class;
using System.Collections;
using rainfalls.Base.Struct;

using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using rainfalls.path;
using Zyf.Ini;
using rainfalls.Base.Class;
using System.Runtime.InteropServices;
using rainfalls.Abstract.Interface;
using rainfalls.View.SectionAlarmControl;
using rainfalls.View.frmLift;
using rainfalls.View.frmConfig;
using GMXS.UI.ErrorMsgNotify;

namespace rainfalls.View.SectionControl
{
    public partial class SectionControl : UserControl
    {
        private int m_ngHeight = 0;
        private Dictionary<string, AlarmHandleControl> m_pAlarmControlDictionary = new Dictionary<string, AlarmHandleControl>();
        private Dictionary<string, AutoLiftNotifyControl> m_pLiftControlDictionary = new Dictionary<string, AutoLiftNotifyControl>();
        private frmErrorMsg m_pErrorDlg;
        public SectionControl()
        {
           
            InitializeComponent();
        }

        private IRainfallsDBHelper m_pRainfallDbHelper;
        public IRainfallsDBHelper RainfallsDbHelper
        {
            set { m_pRainfallDbHelper = value; }
            get { return m_pRainfallDbHelper; }
        }
        private ISoundPlay m_soundPlay;

        public ISoundPlay SoundPlay
        {
            get { return m_soundPlay; }
            set { m_soundPlay = value; }
        }
        private List<ASectionObj> m_pSectionObjList;
        public List<ASectionObj> SectionObjList
        {
            set
            {
                m_pSectionObjList = value;
            }
        }
        private IOpenNotify m_pOpenNofityControl;
        public IOpenNotify OpenNofityControl
        {
            set
            {
                m_pOpenNofityControl = value;
            }
        }
        private void PostInitializeMessage()
        {
            string szHandle = IniHelper.IniReadValue("System", paths.SecetionHandle, paths.HandlePath);
            if (szHandle.Length > 0)
            {
                int nHandle = int.Parse(szHandle);
                IntPtr pHandle = new IntPtr(nHandle);
                CWinMsgAPI.PostMessage(pHandle, CMessage.WM_ONINIT_REGFORM, 0, 0);
            }
        }
        protected override void WndProc(ref Message m)
        {
            string id;
            switch (m.Msg)
            {
                case CMessage.WM_ONSHOW_REGFORM:
                    id = Marshal.PtrToStringBSTR(m.WParam);
                    ShowRegAlarmDialog(id);
                    QJGridViewRefreshRow();
                    break;
                case CMessage.WM_ONSHOW_OPENNOTIFYCONTROL:
                    id = Marshal.PtrToStringBSTR(m.WParam);
                    ShowRegLiftDialog(id);
                    QJGridViewRefreshRow();
                    break;
                case CMessage.WM_ONHIDDEN_OPENNOTIFYCONTROL:
                    id = Marshal.PtrToStringBSTR(m.WParam);
                    HideRegLiftDialog(id);
                    break;
                case CMessage.WM_ONREFRESH_SECTIONGRIDVIEW:
                    QJGridViewRefreshRow();
                    break;
            }
            base.WndProc(ref m);
        }
        public void QJGridViewRefreshRow()
        {
            for (int i = 0; i < m_pSectionObjList.Count; i++)
                QJGridView.RefreshRow(i);
        }
        private void HideRegLiftDialog(string id)
        {
            foreach (ASectionObj obj in m_pSectionObjList)
            {
                if (obj.ID.Equals(id))
                {
                    m_pLiftControlDictionary[id].StopRegLift();
                    m_pLiftControlDictionary[id].Shown = false;
                    frmLift.getInstance().WhoIsShow();
                    frmLift.getInstance().RefreshLocation();
                }
            }
        }
        private void ShowRegLiftDialog(string id)
        {
            foreach (ASectionObj obj in m_pSectionObjList)
            {
                if (obj.ID.Equals(id))
                {
                    m_pLiftControlDictionary[id].SetLogInfo(obj.LiftLevelInfo);
                    m_pLiftControlDictionary[id].Shown = true;
                    m_pLiftControlDictionary[id].Show();
                    frmLift.getInstance().WhoIsShow();
                    frmLift.getInstance().RefreshLocation();
                    frmLift.getInstance().Show();
                }
            }

        }
        private void ShowRegAlarmDialog(string id)
        {
            foreach (ASectionObj obj in m_pSectionObjList)
            {
                if (obj.ID.Equals(id))
                {
                    m_pAlarmControlDictionary[id].SetLogInfo(obj.LastLevelInfo);
                    m_pAlarmControlDictionary[id].Shown = true;
                    m_pAlarmControlDictionary[id].Show();
                    frmAlarm.getInstance().WhoIsShow();
                    frmAlarm.getInstance().RefreshLocation();
                    frmAlarm.getInstance().Show();
                }
            }
        }
        #region 绑定SectionListDataSource
        public void BindingData(BindingSource dataSource)
        {
          
            if (QJGridControl.InvokeRequired)
            {
                Action<DevExpress.XtraGrid.GridControl> bind = (X) =>
                {
                    X.DataSource = dataSource;
                    //this.Height = QJGridView.RowHeight * (QJGridView.RowCount) + QJGridView.ColumnPanelRowHeight + 5;
                };
                Invoke(bind, QJGridControl);
            }
            else
            {
                //此处有问题，想办法找到原因
                QJGridControl.DataSource = dataSource;
            }
        }

   
        #endregion
        public void ControlHeight()
        {
            if (this.InvokeRequired)
            {
                Action<UserControl> bind = (X) =>
                {
                    X.Height = QJGridView.RowHeight * (QJGridView.RowCount) + QJGridView.ColumnPanelRowHeight + QJGridView.ViewCaptionHeight;
                  
                    //this.Height = QJGridView.RowHeight * (QJGridView.RowCount) + QJGridView.ColumnPanelRowHeight + 5;
                };
                Invoke(bind, this);
            }
            else
            {
                // QJGridView.ViewCaptionHeight = 10;
                this.Height = QJGridView.RowHeight * (QJGridView.RowCount) + QJGridView.ColumnPanelRowHeight + QJGridView.ViewCaptionHeight;
                m_ngHeight = this.Height;
               
            }
            //QJGridViewRefreshRow();
            // this.Height = 130;
        }
        private void SectionControl_Load(object sender, EventArgs e)
        {
            IniHelper.IniWriteValue("System", paths.SecetionHandle, this.Handle.ToInt32().ToString(), paths.HandlePath);
           // AlarmControlInit(); LiftControlInit();

           
            QJGridView.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(QJGridView_RowCellClick);
            // this.repositoryItemButtonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(repositoryItemButtonEdit1_ButtonClick);
            
          
           // QJGridView.FormatConditions.Add(SetStyleFormatFontCondition(QJGridView.Columns["LevelFormat"], Color.Black, "LevelFormat=='正常'"));//执行状态(文字颜色)
            //QJGridView.FormatConditions.Add(SetStyleFormatFontCondition(QJGridView.Columns["LevelFormat"], Color.RoyalBlue, "LevelFormat=='出巡'"));//执行状态(文字颜色)
            //QJGridView.FormatConditions.Add(SetStyleFormatFontCondition(QJGridView.Columns["LevelFormat"], Color.Orange, "LevelFormat=='限速'"));//执行状态(文字颜色)
            //QJGridView.FormatConditions.Add(SetStyleFormatFontCondition(QJGridView.Columns["LevelFormat"], Color.DarkRed, "LevelFormat=='扣车'"));//执行状态(文字颜色)
        }

        void QJGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (frmLift.getInstance().Visible || frmAlarm.getInstance().Visible)
            {
                return;
            }
            int i = this.QJGridView.FocusedRowHandle;
            string str = (string)e.CellValue;
            if (string.IsNullOrEmpty(str))
                return;
            if (str.Equals("查看"))
            {
               
                if (i >= 0)
                {
                    object needAlert = QJGridView.GetRowCellValue(this.QJGridView.FocusedRowHandle, QJGridView.Columns["ID"]);
                    string id = (string)needAlert;
                    object secName = QJGridView.GetRowCellValue(this.QJGridView.FocusedRowHandle, QJGridView.Columns["SectionName"]);
                    string sectionName = (string)secName;
                    frmConfigDlg.InstanceObject().SetID(id).Fill(sectionName).Show();
                }
            }
            else
            {
                if (i >= 0)
                {
                    object needAlert = QJGridView.GetRowCellValue(this.QJGridView.FocusedRowHandle, QJGridView.Columns["ID"]);
                    string id = (string)needAlert;
                    foreach (ASectionObj obj in m_pSectionObjList)
                    {
                        if (obj.ID.Equals(id))
                        {
                            if (obj.SectionAlarmLevel >= 1)
                            {
                                if (obj.ManualLiftComputer())
                                {
                                    m_pLiftControlDictionary[id].SetLogInfo(obj.LiftLevelInfo);
                                    m_pLiftControlDictionary[id].Shown = true;
                                    m_pLiftControlDictionary[id].Show();
                                    frmLift.getInstance().WhoIsShow();
                                    frmLift.getInstance().RefreshLocation();
                                    frmLift.getInstance().Show();
                                }
                                else
                                {
                                   // MessageBox.Show(string.Format("当前降雨情况没有达到警戒解除标准，请稍候再试!"), "解除提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    m_pErrorDlg = frmErrorMsg.getInstance();
                                    m_pErrorDlg.SetErrorMessage("当前降雨情况没有达到警戒解除标准，请稍候再试!");
                                    m_pErrorDlg.ShowDialog();
                                }
                            }
                        }
                    }
                }
            }
        }
        protected virtual StyleFormatCondition SetStyleFormatFontCondition(GridColumn gc, Color color, string expression)
        {
            StyleFormatCondition condition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            condition1.Column = gc;
            condition1.Appearance.ForeColor = color;
            condition1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            condition1.Appearance.BackColor = color;
            // condition1.Appearance.Options.UseBackColor = true;
            condition1.Appearance.Options.UseForeColor = true;
            condition1.Appearance.Options.UseTextOptions = true;
            condition1.Condition = FormatConditionEnum.Expression;
            condition1.Expression = expression;
            return condition1;
        }
        public void AlarmControlInit()
        {
            if (m_pSectionObjList == null)
                return;
            if (m_pSectionObjList.Count <= 0)
                return;
            foreach (ASectionObj obj in m_pSectionObjList)
            {
                AlarmHandleControl ahc = new AlarmHandleControl();
                ahc.rainfallsDbHelper = RainfallsDbHelper;
                ahc.SoundPlay = SoundPlay;
                ahc.SectonObj = obj;
                ahc.OnShowHiddenEvent += new ShowHiddenDelegate(frmAlarm.getInstance().WhoIsShow);
                m_pAlarmControlDictionary.Add(obj.ID, ahc);
                frmAlarm.getInstance().AddAlarmControl(ahc);
            }
        }
        public void LiftControlInit()
        {
            foreach (ASectionObj obj in m_pSectionObjList)
            {
                AutoLiftNotifyControl alc = new AutoLiftNotifyControl();
                alc.DbHelper = RainfallsDbHelper;
                alc.SoundPlay = SoundPlay;
                alc.SectonObj = obj;
                alc.OnShowHiddenEvent += new LiftShowHiddenDelegate(frmLift.getInstance().WhoIsShow);
                m_pLiftControlDictionary.Add(obj.ID, alc);
                frmLift.getInstance().AddLiftControl(alc);
            }
        }
        void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int i = this.QJGridView.FocusedRowHandle;
            if (i >= 0)
            {
                object needAlert = QJGridView.GetRowCellValue(this.QJGridView.FocusedRowHandle, QJGridView.Columns["SiteSection"]);
                string section = (string)needAlert;
                System.Diagnostics.Debug.WriteLine(section + ":Click", DateTime.Now.ToString());

               // MessageBox.Show(section);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ControlHeight();
        }

        private void QJGridControl_DataSourceChanged(object sender, EventArgs e)
        {
           // MessageBox.Show("2");
        }

    }
}
