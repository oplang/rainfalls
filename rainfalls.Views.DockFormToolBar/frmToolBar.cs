using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace rainfalls.Views.DockFormToolBar
{
    public partial class frmToolBar : DockContent
    {
        private static frmToolBar uniqueInstance;
        private static readonly object padlock = new object();
        private frmToolBar()
        {
            InitializeComponent();
        }
        public static frmToolBar getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new frmToolBar();
                    }
                }
            }
            return uniqueInstance;
        }
    }
}
