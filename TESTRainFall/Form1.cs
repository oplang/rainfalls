using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using rainfalls.path;
using Zyf.Ini;
using System.Diagnostics;
namespace TESTRainFall
{
    public partial class Form1 : Form
    {
        private Graphics g;
        private Point p1;
        private Point p2;
        private delegate void FlushClient(); //代理
        private event FlushClient FlushClientEvent;
        double i = 0.0;
        public Form1()
        {
            InitializeComponent();
        }
        SerialPort m_pSerialPort = null;
        SerialPinChangedEventHandler m_pPinChanged = null;
        public void Initialize(string comX)
        {
            try
            {
                m_pSerialPort = new SerialPort(comX, 9600, Parity.None, 8, StopBits.One);
                m_pSerialPort.Open();
                m_pSerialPort.RtsEnable = true;
                m_pSerialPort.DtrEnable = true;
                m_pPinChanged = new SerialPinChangedEventHandler(On_PinChanged);
                m_pSerialPort.PinChanged += m_pPinChanged;
                //获取全局跳次数据
            }
            catch
            {
                MessageBox.Show(string.Format("测试程序打开端口失败:[{0}]",comX),"端口错误",MessageBoxButtons.OK);
                CloseHandle();
                Application.Exit();
            }
        }
        public void CloseHandle()
        {
            if (m_pSerialPort != null)
            {
                m_pSerialPort.Close();
                m_pSerialPort.Dispose();
            }
        }
        private bool KillRainfallProcess()
        {
            bool bIsKill = false;
            Process[] processes = Process.GetProcessesByName("rainfalls");
            foreach (Process p in processes)
            {
                p.Kill();
                p.Close();
                bIsKill = true;
            }
            System.Threading.Thread.Sleep(1000);
            return bIsKill;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            KillRainfallProcess();
            string comX = CINIFile.IniReadValue("基本信息", "串口编号", paths.baseInfoPath);
            Initialize(comX);
            FlushClientEvent += new FlushClient(Form1_FlushClientEvent);
        }

        void Form1_FlushClientEvent()
        {
            this.lbTestDb.Text = string.Format("{0:F1}  mm", i / 10);
        }
        private void On_PinChanged(object sender, System.IO.Ports.SerialPinChangedEventArgs e)
        {
            if (e.EventType == System.IO.Ports.SerialPinChange.CtsChanged)
            {
                m_pSerialPort.PinChanged -= m_pPinChanged;
                Thread.Sleep(5);
                if (m_pSerialPort.CtsHolding == true)
                {
                    ////Save the Click data
                    //Shared.Base.CLog.LOG("CD-" + m_pSerialPort.CDHolding + "," +
                    //    "Brk-" + m_pSerialPort.BreakState + "," +
                    //    "CTS-" + m_pSerialPort.CtsHolding + "," + 
                    //    "DSR-" + m_pSerialPort.DsrHolding + "," + 
                    //    "DTR-" + m_pSerialPort.DtrEnable + "," + 
                    //    "RTS-" + m_pSerialPort.RtsEnable + ".");
                    i++;
                    this.BeginInvoke(FlushClientEvent);
                }
                m_pSerialPort.PinChanged += m_pPinChanged;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
           CloseHandle();
            this.Close();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Rectangle rect = System.Windows.Forms.SystemInformation.VirtualScreen;

            this.panel1.Top = (rect.Height - this.panel1.Height - this.btnOk.Height) / 2;
            this.panel1.Left = (rect.Width - this.panel1.Width) / 2;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            RestartRainfalls();
        }
        private void RestartRainfalls()
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = System.IO.Path.Combine(Application.StartupPath, "rainfalls.exe");
                p.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show("重启失败原因:" + e.Message);
            }
        }
    }
}