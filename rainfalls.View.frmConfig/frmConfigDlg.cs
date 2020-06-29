using System.Windows.Forms;
using System.Data;
using System.Xml;
using rainfalls.path;
using rainfalls.Base.Struct;
using Zyf.Ini;
using rainfalls.Base.ErrorHandle;
using System.IO;
using System.Runtime.InteropServices;
using System;
namespace rainfalls.View.frmConfig
{
    public partial class frmConfigDlg : Form
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


        const int CS_DropSHADOW = 0x20000;
        const int GCL_STYLE = (-26);
        //声明Win32 API
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);

        private static frmConfigDlg uniqueInstance;
        private static readonly object padlock = new object();
        //创建窗体对象的静态方法
        private string m_pSectonID;
        public static frmConfigDlg InstanceObject()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new frmConfigDlg();
                    }
                }
            }
            return uniqueInstance;
        }
        public frmConfigDlg SetID(string id)
        {
            m_pSectonID = id;
            return InstanceObject();
        }
        private frmConfigDlg()
        {
            InitializeComponent();
            SetClassLong(this.Handle, GCL_STYLE, GetClassLong(this.Handle, GCL_STYLE) | CS_DropSHADOW); //API函数加载，实现窗体边框阴影效果
        }
        public frmConfigDlg Fill(string sec)
        {
            //lbVersion.Text = "当前版本:" + CINIFile.IniReadValue("基本信息", "软件版本", paths.baseInfoPath);
            //lbUpdateTime.Text = "更新时间:" + CINIFile.IniReadValue("基本信息", "更新时间", paths.baseInfoPath);
            //lbUpdateID.Text = "更新标识:" + CINIFile.IniReadValue("基本信息", "更新标识", paths.baseInfoPath);
            //lbMtup.Text = "MTUP:" + CINIFile.IniReadValue("基本信息", "MTUP标识", paths.baseInfoPath);
            doGetDelta();
            doGetCont();
            dtDeltaView.ClearSelection();
            this.lbCaption.Text = "区间:["+sec +"]警戒值文件";
            return InstanceObject();
        }
        private  void doGetDelta()
        {
            int m_nLevel;
            ALARMLEVEL[] m_alarmLevel = new ALARMLEVEL[20];
            XmlDocument doc = new XmlDocument();
            if (!File.Exists(paths.warnPath))
            {
                CError.getInstance().Show(string.Format("没有找到警戒值文件"));
                return;
            }
            doc.Load(paths.warnPath);
            XmlNodeList pList = doc.SelectNodes("/Config/alarmLevel");
            int i = 0;
            try
            {
                foreach (XmlNode nl in pList)
                {
                    if (nl.Attributes[0].Value.Equals(m_pSectonID))
                    {
                        XmlNodeList nodeList = nl.SelectNodes("Delta");
                        foreach (XmlNode Node in nodeList)
                        {
                            m_alarmLevel[i].dur = int.Parse(Node.Attributes[0].Value);
                            m_alarmLevel[i].delta = int.Parse(Node.Attributes[1].Value);
                            m_alarmLevel[i].level = int.Parse(Node.Attributes[2].Value);
                            m_alarmLevel[i].liftValue = int.Parse(Node.Attributes[3].Value);
                            m_alarmLevel[i].tag = 0x01;
                            m_alarmLevel[i].TRAIN = "客货";
                            i++;
                        }
                        XmlNodeList nodeListDaily = nl.SelectNodes("Daily");
                        foreach (XmlNode Node in nodeListDaily)
                        {
                            m_alarmLevel[i].dur = int.Parse(Node.Attributes[0].Value);
                            m_alarmLevel[i].delta = int.Parse(Node.Attributes[1].Value);
                            m_alarmLevel[i].level = int.Parse(Node.Attributes[2].Value);
                            m_alarmLevel[i].liftValue = int.Parse(Node.Attributes[3].Value);
                            m_alarmLevel[i].tag = 0x02;
                            m_alarmLevel[i].TRAIN = "客车";
                            i++;
                        }
                    }

                }
            }
            catch
            {
                CError.getInstance().Show(string.Format("读取警戒值文件时发生错误"));
            }
            if (File.Exists(paths.warn_Freight_Path))
            {
                doc.Load(paths.warn_Freight_Path);
                 pList = doc.SelectNodes("/Config/alarmLevel");
         
                try
                {
                    foreach (XmlNode nl in pList)
                    {
                        if (nl.Attributes[0].Value.Equals(m_pSectonID))
                        {
                            XmlNodeList nodeList = nl.SelectNodes("Delta");
                            foreach (XmlNode Node in nodeList)
                            {
                                m_alarmLevel[i].dur = int.Parse(Node.Attributes[0].Value);
                                m_alarmLevel[i].delta = int.Parse(Node.Attributes[1].Value);
                                m_alarmLevel[i].level = int.Parse(Node.Attributes[2].Value);
                                m_alarmLevel[i].liftValue = int.Parse(Node.Attributes[3].Value);
                                m_alarmLevel[i].tag = 0x01;
                                m_alarmLevel[i].TRAIN = "货车";
                                i++;
                            }
                        }

                    }
                }
                catch
                {
                    CError.getInstance().Show(string.Format("读取警戒值文件时发生错误"));
                }
            }
            m_nLevel = i;
            buildDeltaDataTable(m_alarmLevel, m_nLevel);
        }
        private void buildDeltaDataTable(ALARMLEVEL[] m_alarmLevel ,int N)
        {
            // Create a new DataTable.
            System.Data.DataTable table = new DataTable("delta");
            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;
            DataRow row;

            // Create new DataColumn, set DataType, 
            // ColumnName and add to DataTable.    
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "时长";
            column.ReadOnly = true;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "雨量";
            column.Caption = "delta";
            column.ReadOnly = true;
            // Add the column to the table.
            table.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "警戒级别";
            column.Caption = "level";
            column.ReadOnly = true;
            // Add the column to the table.
            table.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "一小时解除雨量";
            column.Caption = "value";
            column.ReadOnly = true;
            // Add the column to the table.
            table.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "客/货";
            column.Caption = "value";
            column.ReadOnly = true;
            // Add the column to the table.
            table.Columns.Add(column);
            // Instantiate the DataSet variable.
            DataSet dataSet = new DataSet();
            // Add the new DataTable to the DataSet.
            dataSet.Tables.Add(table);

            // Create three new DataRow objects and add 
            // them to the DataTable
            for (int i = 0; i <N; i++)
            {
                row = table.NewRow();
                row["时长"] = m_alarmLevel[i].dur.ToString()+(m_alarmLevel[i].tag.Equals(TagType.tag_delta)?"(分)":"（天）");
                row["雨量"] = m_alarmLevel[i].delta.ToString();
                row["警戒级别"] = m_alarmLevel[i].level.ToString();
                row["一小时解除雨量"] = m_alarmLevel[i].liftValue.ToString();
                row["客/货"] = m_alarmLevel[i].TRAIN;
                table.Rows.Add(row);
            }
            this.dtDeltaView.DataSource = dataSet.Tables["delta"];
            this.dtDeltaView.ClearSelection();
            
        }

        private void frmConfigDlg_Load(object sender, System.EventArgs e)
        {
           
            this.dtContView.ClearSelection(); this.dtDeltaView.Rows[0].Selected = false;
            AnimateWindow(this.Handle, 500, AW_BLEND | AW_ACTIVE);
        }
        private void doGetCont()
        {
            int m_nLevel;
            ALARMLEVEL[] m_alarmLevel = new ALARMLEVEL[20];
            XmlDocument doc = new XmlDocument();
            if (!File.Exists(paths.warnPath))
            {
                CError.getInstance().Show(string.Format("没有找到警戒值文件"));
                return;
            }
            doc.Load(paths.warnPath);
            XmlNodeList pList = doc.SelectNodes("/Config/alarmLevel");
            int i = 0;
            try
            {
                foreach (XmlNode nl in pList)
                {
                    if (nl.Attributes[0].Value.Equals(m_pSectonID))
                    {
                        XmlNodeList nodeList = nl.SelectNodes("Cont");
                        foreach (XmlNode Node in nodeList)
                        {
                            m_alarmLevel[i].c_time = int.Parse(Node.Attributes[0].Value);
                            m_alarmLevel[i].delta = int.Parse(Node.Attributes[1].Value);
                            m_alarmLevel[i].dur = int.Parse(Node.Attributes[2].Value);
                            m_alarmLevel[i].level = int.Parse(Node.Attributes[3].Value);
                            m_alarmLevel[i].liftValue = int.Parse(Node.Attributes[4].Value);
                            m_alarmLevel[i].tag = 0x01;
                            m_alarmLevel[i].TRAIN = "客货";
                            m_alarmLevel[i].TRAIN = m_alarmLevel[i].level > 2 ? "客车" : "客货";
                            i++;
                        }
                    }

                }
            }
            catch
            {
                CError.getInstance().Show(string.Format("读取警戒值文件时发生错误"));
            }
            if(File.Exists(paths.warn_Freight_Path))
            {
                doc.Load(paths.warn_Freight_Path);
                pList = doc.SelectNodes("/Config/alarmLevel");
                try
                {
                    foreach (XmlNode nl in pList)
                    {
                        if (nl.Attributes[0].Value.Equals(m_pSectonID))
                        {
                            XmlNodeList nodeList = nl.SelectNodes("Cont");
                            foreach (XmlNode Node in nodeList)
                            {
                                m_alarmLevel[i].c_time = int.Parse(Node.Attributes[0].Value);
                                m_alarmLevel[i].delta = int.Parse(Node.Attributes[1].Value);
                                m_alarmLevel[i].dur = int.Parse(Node.Attributes[2].Value);
                                m_alarmLevel[i].level = int.Parse(Node.Attributes[3].Value);
                                m_alarmLevel[i].liftValue = int.Parse(Node.Attributes[4].Value);
                                m_alarmLevel[i].tag = 0x01;
                                m_alarmLevel[i].TRAIN = "货车";
                                i++;
                            }
                        }

                    }
                }
                catch
                {
                    CError.getInstance().Show(string.Format("读取警戒值文件时发生错误"));
                }
            }
            m_nLevel = i;
            buildContDataTable(m_alarmLevel, m_nLevel);
        }
        private void buildContDataTable(ALARMLEVEL[] m_alarmLevel, int N)
        {
            // Create a new DataTable.
            System.Data.DataTable table = new DataTable("Cont");
            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;
            DataRow row;

            // Create new DataColumn, set DataType, 
            // ColumnName and add to DataTable.    
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "连续时长(分)";
            column.ReadOnly = true;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);

            // Create new DataColumn, set DataType, 
            // ColumnName and add to DataTable.    
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "连续雨量";
            column.ReadOnly = true;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "一小时雨强";
            column.Caption = "delta";
            column.ReadOnly = true;
            // Add the column to the table.
            table.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "警戒级别";
            column.Caption = "level";
            column.ReadOnly = true;
            // Add the column to the table.
            table.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "一小时解除雨量";
            column.Caption = "value";
            column.ReadOnly = true;
            // Add the column to the table.
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "客/货";
            column.Caption = "value";
            column.ReadOnly = true;
            table.Columns.Add(column);
            // Instantiate the DataSet variable.
            DataSet dataSet = new DataSet();
            // Add the new DataTable to the DataSet.
            dataSet.Tables.Add(table);

            // Create three new DataRow objects and add 
            // them to the DataTable
            for (int i = 0; i < N; i++)
            {
                row = table.NewRow();
                row["连续时长(分)"] = m_alarmLevel[i].c_time.ToString();
                row["连续雨量"] = m_alarmLevel[i].delta.ToString();
                row["一小时雨强"] =  m_alarmLevel[i].dur.ToString();
                row["警戒级别"] = m_alarmLevel[i].level.ToString();
                row["一小时解除雨量"] = m_alarmLevel[i].liftValue.ToString();
                row["客/货"] = m_alarmLevel[i].TRAIN;
                table.Rows.Add(row);
            }
            this.dtContView.DataSource = dataSet.Tables["Cont"];
           
        }

        private void frmConfigDlg_FormClosed(object sender, FormClosedEventArgs e)
        {
            uniqueInstance = null;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void frmConfigDlg_FormClosing(object sender, FormClosingEventArgs e)
        {
            uniqueInstance = null;
            AnimateWindow(this.Handle, 500, AW_BLEND | AW_HIDE);
        }

        private void frmConfigDlg_Deactivate(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
