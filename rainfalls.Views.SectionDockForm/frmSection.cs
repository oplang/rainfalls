using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using rainfalls.View.SectionControl;
using rainfalls.Abstract.Interface;
using rainfalls.Abstract.Class;
namespace rainfalls.Views.SectionDockForm
{
    public partial class frmSection : DockContent
    {
        private static frmSection uniqueInstance;
        private static readonly object padlock = new object();

        private SectionControl m_pSectionControl;
        private BindingSource m_pSectionSource = new BindingSource();
        private frmSection()
        {
            InitializeComponent();
            this.AllowEndUserDocking = false;
           
        }
        public static frmSection getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new frmSection();
                    }
                }
            }
            return uniqueInstance;
        }
        public void InitializeSectionList(IRainfallsDBHelper dbHelper, ISoundPlay soundPlay, List<ASectionObj> secObjList)
        {
            #region 线路+站点
            m_pSectionControl = new SectionControl();
            m_pSectionControl.RainfallsDbHelper = dbHelper;
            m_pSectionControl.SoundPlay = soundPlay;
            m_pSectionSource.DataSource = secObjList;
            m_pSectionControl.BindingData(m_pSectionSource);
            m_pSectionControl.SectionObjList = secObjList;
            this.Controls.Add(m_pSectionControl);
            m_pSectionControl.AlarmControlInit();
            m_pSectionControl.LiftControlInit();
            m_pSectionControl.ControlHeight();
            m_pSectionControl.Dock = DockStyle.Fill;
            this.Refresh();
            #endregion
        }
    }
}
