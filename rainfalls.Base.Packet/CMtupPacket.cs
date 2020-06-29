//using System;
//using System.Net;
//using System.Net.Sockets;
//using System.Text;
//using rainfalls.Abstract.Class;
//namespace rainfalls.Base.Mtup
//{
//    public class CMtupPacket : AMtupSync, IDisposable
//    {
//        CZzdwPacket m_pZzdwPacket = new CZzdwPacket();
//        public CMtupPacket(string ip)
//            : base(ip)
//        {
//            szMoblieID = Convert.ToString(int.Parse(szMoblieID), 16);
//            bMobileID = HexStringToBytes(szMoblieID, 8);
//        }

//        private int Send(Socket server, byte[] bPackage)
//        {
//            try
//            {
//                // Blocks until send returns.
//                server.Send(bPackage, 0, bPackage.Length, SocketFlags.None);
//            }
//            catch (SocketException e)
//            {
//                return (e.ErrorCode);
//            }
//            return 0;
//        }
//        private byte[] PackageData(string szData)
//        {
//            byte[] bData = Encoding.GetEncoding("GB2312").GetBytes(szData);
//            byte[] bDataLength = HexStringToBytes(Convert.ToString(bData.Length, 16), 4);
//            byte[] bPackage = new byte[bHead.Length * 2 + bAppID.Length + bMobileID.Length + bDataLength.Length + bData.Length];
//            Array.Copy(bHead, 0, bPackage, 0, bHead.Length);
//            Array.Copy(bAppID, 0, bPackage, bHead.Length, bAppID.Length);
//            Array.Copy(bMobileID, 0, bPackage, bHead.Length + bAppID.Length, bMobileID.Length);
//            Array.Copy(bDataLength, 0, bPackage, bHead.Length + bAppID.Length + bMobileID.Length, bDataLength.Length);
//            Array.Copy(bData, 0, bPackage, bHead.Length + bAppID.Length + bMobileID.Length + bDataLength.Length, bData.Length);
//            Array.Copy(bHead, 0, bPackage, bHead.Length + bAppID.Length + bMobileID.Length + bDataLength.Length + bData.Length, bHead.Length);
//            return bPackage;
//        }
//        public override bool SendData(string szData)
//        {
//            IPAddress ip = IPAddress.Parse(szMtupAddress);
//            IPEndPoint ipEnd = new IPEndPoint(ip, szMtupPort);
//            int result = -1;
//            byte[] bPackage;

         
//            using (Socket syncSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
//            {
//                try
//                {
//                    syncSocket.Connect(ipEnd);
//                }
//                catch (SocketException e)
//                {
//                    System.Diagnostics.Debug.WriteLine(szMtupAddress + "连接服务器失败-->" + e.Message);
//                }
//                bPackage = PackageData(szData);
//                result = Send(syncSocket, bPackage);
//                try
//                {
//                    syncSocket.Disconnect(false);
//                    syncSocket.Close();
//                }
//                catch (Exception e)
//                {
//                    System.Diagnostics.Debug.WriteLine(e.Message);
//                }
//            }
//            bool b = m_pZzdwPacket.send(bPackage, 5006);
//            if (result == 0 && b)
//                return true;
//            else
//                return false;
//        }
//        private  Socket ConnectSocket(string server, int port)
//        {
//            Socket s = null;
//            IPHostEntry hostEntry = null;

//            // Get host related information.
//            hostEntry = Dns.GetHostEntry(server);

//            // Loop through the AddressList to obtain the supported AddressFamily. This is to avoid
//            // an exception that occurs when the host IP Address is not compatible with the address family
//            // (typical in the IPv6 case).
//            foreach (IPAddress address in hostEntry.AddressList)
//            {
//                IPEndPoint ipe = new IPEndPoint(address, port);
//                Socket tempSocket =  new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

//                tempSocket.Connect(ipe);

//                if (tempSocket.Connected)
//                {
//                    s = tempSocket;
//                    break;
//                }
//                else
//                {
//                    continue;
//                }
//            }
//            return s;
//        }
//        public void Dispose()
//        {
//            GC.SuppressFinalize(this);
//        }
//    }
//}
