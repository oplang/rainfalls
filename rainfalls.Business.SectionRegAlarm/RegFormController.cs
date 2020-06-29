using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rainfalls.Abstract.Class;
using rainfalls.Base.Struct;
using rainfalls.View.frmReg;
using System.Windows.Forms;

namespace rainfalls.Business.SectionRegAlarm
{
    public class RegFormController:ASectionRegAlarm
    {
        private frmRegDlg m_pFrmReg;
        private delegate void AsyncShowRegForm(LEVELINFO li);
        public override void OnSectionAlarm(LEVELINFO li)
        {
                if (m_pFrmReg.IsDisposed)
                {
                    m_pFrmReg = new frmRegDlg(OwnSectionObj);
                    // m_frmReg.btnClickEvent += new onBtnClickHandler(frmReg_btnClickEvent);
                }
                if (m_pFrmReg.rainfallsDbHelper == null)
                    m_pFrmReg.rainfallsDbHelper = RainfallsDbHelper;
                if (m_pFrmReg.SoundPlay == null)
                    m_pFrmReg.SoundPlay = SoundPlay;
                m_pFrmReg.setLocation(OffsetX, OffsetY);
                m_pFrmReg.SetLogInfo(li);
                m_pFrmReg.Show();
        }

        protected override void InstanceRegForm()
        {
            m_pFrmReg = new frmRegDlg(OwnSectionObj);
        }
    }
}
