//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Net.Sockets;
//using System.Net;
//using Zyf.Ini;

//namespace rainfalls.Base.Mtup
//{
//    public class CZzdwPacket
//    {
//        private string remoteIp = "139.129.8.107";
//        public CZzdwPacket()
//        {
//            string  ip = CINIFile.IniReadValue("基本信息", "FTP_IP", AppDomain.CurrentDomain.BaseDirectory + "base.ini");
//            if (!string.IsNullOrEmpty(ip))
//                remoteIp = ip;
//        }
//        public bool send( byte[] buffer, int port)
//        {
//            System.Diagnostics.Debug.WriteLine("发送长度:" + buffer.Length);
//            bool isDone = false;
//            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//            IPAddress ip = IPAddress.Parse(remoteIp);
//            IPEndPoint point = new IPEndPoint(ip, port);
//            try
//            {
//                client.Connect(point);
//                client.Send(buffer);
//                if (recvmsgs(buffer, client))
//                    isDone = true;
//                else
//                    isDone = false;

//            }
//            catch (Exception ex)
//            {
//                isDone = false;
//            }
//            finally
//            {
//                client.Close();
//            }
//            return isDone;
//        }

//        //接受服务端发送来的消息
//        private bool recvmsgs(byte[] sourceBuffer, Socket client)
//        {
//            try
//            {
//                byte[] buffer = new byte[1024];
//                int size = client.Receive(buffer);
//                System.Diagnostics.Debug.WriteLine("接收长度:" + size);
//                string recvesrc = BitConverter.ToString(buffer, 0, size);
//                string souresrc = BitConverter.ToString(sourceBuffer, 0, sourceBuffer.Length);
//                System.Diagnostics.Debug.WriteLine("服务器返回:" + BitConverter.ToString(buffer, 0, size));
//                if (souresrc.Equals(recvesrc))
//                    return true;
//            }
//            catch (Exception ex)
//            {
//                //发送失败写入临时文件
//                return false;
//            }
//            return false;
//        }
//    }
//}
