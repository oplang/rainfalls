using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using rainfalls.Business.InspectorLab;

namespace rainfalls.Views.DockFormInspector
{
    public partial class frmPerson : Form
    {
        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        //下面是可用的常量，根据不同的动画效果声明自己需要的  
        private const int AW_HOR_POSITIVE = 0x0001;//自左向右显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志  
        private const int AW_HOR_NEGATIVE = 0x0002;//自右向左显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志  
        private const int AW_VER_POSITIVE = 0x0004;//自顶向下显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志  
        private const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志该标志  
        private const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；否则向外扩展  
        private const int AW_HIDE = 0x10000;//隐藏窗口  
        private const int AW_ACTIVE = 0x20000;//激活窗口，在使用了AW_HIDE标志后不要使用这个标志  
        private const int AW_SLIDE = 0x40000;//使用滑动类型动画效果，默认为滚动动画类型，当使用AW_CENTER标志时，这个标志就被忽略  
        private const int AW_BLEND = 0x80000;//使用淡入淡出效果 
        private string m_pFocusInspectorId;
        private static frmPerson uniqueInstance;
        private static readonly object padlock = new object();
        private int m_nFoucsRow = -1;
        private const string m_pFilter = "[PersonState] ='0' ";
        private frmPerson()
        {
            InitializeComponent();
        }
        public static frmPerson getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new frmPerson();
                    }
                }
            }
            return uniqueInstance;
        }
        public void SetInspectorID(string uuid)
        {
            m_pFocusInspectorId = uuid;
        }
        private void frmPerson_Load(object sender, EventArgs e)
        {
            int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height + 35;
            this.Location = new Point(x, y);//设置窗体在屏幕右下角显示  
            AnimateWindow(this.Handle, 500, AW_SLIDE | AW_ACTIVE | AW_HOR_NEGATIVE);
           // this.PersonGridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(PersonGridView_FocusedRowChanged);
            this.PersonGridView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(PersonGridView_RowClick);
        }

        void PersonGridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            m_nFoucsRow = this.PersonGridView.FocusedRowHandle;
           
        }

        void PersonGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            
        }

        private void frmPerson_FormClosing(object sender, FormClosingEventArgs e)
        {
            uniqueInstance = null;
            AnimateWindow(this.Handle, 500, AW_BLEND | AW_HIDE);
        }
        public void BindingPersonList()
        {
            PersonGridControl.DataSource = PersonLab.getInstance().PersonList;
            PersonGridView.ActiveFilter.NonColumnFilter = m_pFilter;
        }

        private void frmPerson_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PersonGridControl_Load(object sender, EventArgs e)
        {
            this.PersonGridView.FocusedRowHandle = 0;
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (m_nFoucsRow >= 0)
            {
               // object objPhone = PersonGridView.GetRowCellValue(m_nFoucsRow, PersonGridView.Columns["PersonPhone"]);
               // string phone = (string)objPhone;
               // InspectorsLab.getInstance().AddPersonDoing(this.m_pFocusInspectorId, phone);
               // PersonGridView.ActiveFilter.NonColumnFilter = m_pFilter;
               //// PersonGridView.DeleteRow(
               // this.Hide();
               // this.Close();
            }
        }
    }
}
