using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rainfalls.View.Messagebox
{
    public partial class frmMsgBox : Form
    {
        public frmMsgBox()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void setText(string text)
        {
            label2.Text = text;
        }
    }
}
