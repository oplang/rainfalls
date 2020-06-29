using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rainfalls.Views.SectionCtrl
{
    public partial class sectionControl : UserControl
    {
        private int m_nLevel = 0;
        private bool m_bIsInspection = false;
        public sectionControl()
        {
            InitializeComponent();
        }
        [CategoryAttribute("site"),
     DescriptionAttribute("站点显示位置")]
        public bool IsTopShow
        {
            set { siteCtrl.IsTopShow = value; }
            get { return siteCtrl.IsTopShow; }
        }
        [CategoryAttribute("site"),
     DescriptionAttribute("站点名称")]
        [DefaultValue("测试站点")]
        public string SiteName
        {
            set { siteCtrl.SiteName = value; }
            get { return siteCtrl.SiteName; }
        }
        [CategoryAttribute("section"),
DescriptionAttribute("区间警戒")]
        [DefaultValue(0)]
        public int Level
        {
            set { m_nLevel = value; SwitchLevel(); }
            get { return m_nLevel; }
        }
        [CategoryAttribute("section"),
DescriptionAttribute("区间是否有人巡查")]
        [DefaultValue(false)]
        public bool IsInspection
        {
            set { m_bIsInspection = value; ShowPicPerson(); }
            get { return m_bIsInspection; }
            
        }
        private void ShowPicPerson()
        {
                picPerson.Visible = m_bIsInspection;
        }
        private void SwitchLevel()
        {
            switch (m_nLevel)
            {
                case 0: leftPanel.BackColor = Color.White; rightPanel.BackColor = Color.Black; break;
                case 1: leftPanel.BackColor = Color.White; rightPanel.BackColor = Color.Cyan; break;
                case 2: leftPanel.BackColor = Color.White; rightPanel.BackColor = Color.Chocolate; break;
                case 3: leftPanel.BackColor = Color.White; rightPanel.BackColor = Color.Crimson; break;
            }
        }
    }
}
