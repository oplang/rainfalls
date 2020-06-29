using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace Rainfall.App.AppSync
{
    class GSMMODEM
    {
        //构造函数
        public GSMMODEM()
        {
            //串口初始化
            _sp.NewLine = "\r\n";
            _sp.ReadTimeout = 2500;
            _sp.RtsEnable = true;
            //_sp.DtrEnable = true;

            //_sp.Handshake = Handshake.RequestToSendXOnXOff;
        }

        public GSMMODEM(string ComPort, int BaudRate)
        {
            //串口初始化
            _sp.PortName = ComPort;
            _sp.BaudRate = BaudRate;
            _sp.NewLine = "\r\n";
            _sp.ReadTimeout = 2500;
            _sp.RtsEnable = true;
            //_sp.DtrEnable = true;

            //_sp.Handshake = Handshake.RequestToSendXOnXOff;
        }
        //属性
        private SerialPort _sp = new SerialPort();

        //public bool AutoDelMsg = false;             //设置是否在阅读短信后自动删除SIM卡内短信存档（建议在经常接收短信时设置为 true）
        //设计和运行时都可以读写，true 自动删除   false 不自动删除
        //默认为 true

        //端口号
        public string ComPort
        {
            get
            {
                return _sp.PortName;
            }
            set
            {
                _sp.PortName = value;
            }
        }

        //波特率
        public int BaudRate
        {
            get
            {
                return _sp.BaudRate;
            }
            set
            {
                _sp.BaudRate = value;
            }
        }

        //是否开启
        public bool IsOpen
        {
            get
            {
                return _sp.IsOpen;
            }
        }

        //打开设备
        public void OpenComm()
        {
            try
            {
                _sp.Open();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //关闭设备
        public void CloseComm()
        {
            try
            {
                _sp.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //发送AT指令，返回由设备返回的数据
        public string SendATCommand(string ATCmd)
        {
            _sp.DiscardInBuffer();
            try
            {
                _sp.WriteLine(ATCmd);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            try
            {
                Thread.Sleep(100);
                return _sp.ReadExisting();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public string Write(byte[] byte1, int a, int b)
        {
            try
            {
                _sp.Write(byte1, a, b);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            try
            {
                Thread.Sleep(100);
                return _sp.ReadExisting();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }

}
