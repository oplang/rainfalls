using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rainfalls.View.AlarmControl
{
    public partial class SectionAlarmControl : UserControl
    {
        public SectionAlarmControl()
        {
            InitializeComponent();
        }

        private void m_pLbOKHandle_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
