using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rainfalls.View.Messagebox;

namespace rainfalls.Base.Error
{
    public partial class ErrorControl : UserControl
    {

        private static ErrorControl uniqueInstance;
        private static readonly object padlock = new object();
        private ErrorControl()
        {
             InitializeComponent();
        }
        public static ErrorControl getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new ErrorControl();
                    }
                }
            }
            return uniqueInstance;
        }
        public void ShowMessage(string text)
        {
            if (this.InvokeRequired)
            {
                frmMsgBox f = new frmMsgBox();
                Action<frmMsgBox> actionAddrCtrl = (X) =>
                {
                    X.setText(text);
                    X.ShowDialog();
                };
                Invoke(actionAddrCtrl, f);
            }
            else
            {
                frmMsgBox f = new frmMsgBox();
                f.setText(text);
                f.ShowDialog();
            }
        }
    }
}
