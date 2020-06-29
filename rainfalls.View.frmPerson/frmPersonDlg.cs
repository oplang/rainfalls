using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;
using rainfalls.path;
namespace rainfalls.View.frmPerson
{
    public partial class frmPersonDlg : Form
    {
        protected string[] person = new string[10];
        protected string name = null;
        [DllImportAttribute("user32.dll")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        public const Int32 AW_HOR_POSITIVE = 0x00000001;
        public const Int32 AW_HOR_NEGATIVE = 0x00000002;
        public const Int32 AW_VER_POSITIVE = 0x00000004;
        public const Int32 AW_VER_NEGATIVE = 0x00000008;
        public const Int32 AW_CENTER = 0x00000010;
        public const Int32 AW_HIDE = 0x00010000;
        public const Int32 AW_ACTIVATE = 0x00020000;
        public const Int32 AW_SLIDE = 0x00040000;
        public const Int32 AW_BLEND = 0x00080000;
        public frmPersonDlg()
        {
            InitializeComponent();
        }
        protected int GetPerson()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(paths.personPath);
            XmlNodeList pList = doc.SelectNodes("/Config/site/person");

            int i = 0;
            try
            {
                foreach (XmlNode nl in pList)
                {
                    person[i] = nl.Attributes[0].Value;
                    i++;
                }
            }
            catch
            {

            }
            return i;
        }
   
        private void dt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            name = this.dt.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.Close();
        }
        public string Person
        {
            get
            {
                return name;
            }
        }
        private void frmPersonDlg_Load(object sender, EventArgs e)
        {
            int N = GetPerson();
            this.dt.Rows.Add(N);
            for (int i = 0; i < N; i++)
            {
                this.dt.Rows[i].Height = 40;
                this.dt.Rows[i].Cells[0].Value = person[i];
            }
            this.dt.ClearSelection();
            this.Height = 40 * N;
            this.dt.Height = this.Height;
            //Point screenPoint = Control.MousePosition;
            //Point formPoint = this.PointToClient(Control.MousePosition);
            this.Location = Control.MousePosition;
            AnimateWindow(this.Handle, 300, AW_SLIDE + AW_VER_POSITIVE);
        }

        private void frmPersonDlg_FormClosed(object sender, FormClosedEventArgs e)
        {
            AnimateWindow(this.Handle, 300, AW_SLIDE + AW_VER_NEGATIVE + AW_HIDE);
        }
    }
}
