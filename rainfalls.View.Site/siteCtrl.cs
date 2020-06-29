using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace rainfalls.View.Site
{
    public partial class siteCtrl : UserControl
    {
        public siteCtrl()
        {
            InitializeComponent();  
        }

        private void SiteControl_Paint(object sender, PaintEventArgs e)
        {
            
        }
        public string siteName
        {
            set
            {
                lbSiteName.Text = value;
            }
            get
            {
                return lbSiteName.Text;
            }
        }
        public int contRain
        {
        }
        public int 
    }
}
