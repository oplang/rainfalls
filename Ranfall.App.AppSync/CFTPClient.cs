using System;
using System.Net;
using System.IO;
using System.Text;
using System.Net.Sockets;

namespace Rainfall.App.AppSync
{
    public class CFTPClient
    {
        #region ���캯��
        /// <summary>
        /// ȱʡ���캯��
        /// </summary>
        public CFTPClient()
        {
            strRemoteHost = "";
            strRemotePath = "";
            strRemoteUser = "";
            strRemotePass = "";
            strRemotePort = 21;
            bConnected = false;
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="remoteHost">FTP������IP��ַ</param>
        /// <param name="remotePath">��ǰ������Ŀ¼</param>
        /// <param name="remoteUser">��¼�û��˺�</param>
        /// <param name="remotePass">��¼�û�����</param>
        /// <param name="remotePort">FTP�������˿�</param>
        public CFTPClient(string remoteHost, string remotePath, string remoteUser, string remotePass, int remotePort)
        {
            strRemoteHost = remoteHost;
            strRemotePath = remotePath;
            strRemoteUser = remoteUser;
            strRemotePass = remotePass;
            strRemotePort = remotePort;
            Connect();
        }
        #endregion

        #region ��½�ֶΡ�����
        /// <summary>
        /// FTP������IP��ַ
        /// </summary>
        private string strRemoteHost;
        public string RemoteHost
        {
            get
            {
                return strRemoteHost;
            }
            set
            {
                strRemoteHost = value;
            }
        }
        /// <summary>
        /// FTP�������˿�
        /// </summary>
        private int strRemotePort;
        public int RemotePort
        {
            get
            {
                return strRemotePort;
            }
            set
            {
                strRemotePort = value;
            }
        }
        /// <summary>
        /// ��ǰ������Ŀ¼
        /// </summary>
        private string strRemotePath;
        public string RemotePath
        {
            get
            {
                return strRemotePath;
            }
            set
            {
                strRemotePath = value;
            }
        }
        /// <summary>
        /// ��¼�û��˺�
        /// </summary>
        private string strRemoteUser;
        public string RemoteUser
        {
            set
            {
                strRemoteUser = value;
            }
        }
        /// <summary>
        /// �û���¼����
        /// </summary>
        private string strRemotePass;
        public string RemotePass
        {
            set
            {
                strRemotePass = value;
            }
        }

        /// <summary>
        /// �Ƿ��¼
        /// </summary>
        private Boolean bConnected;
        public bool Connected
        {
            get
            {
                return bConnected;
            }
        }
        #endregion

        #region ����
        /// <summary>
        /// �������� 
        /// </summary>
        public string Connect()
        {
            socketControl = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(RemoteHost), strRemotePort);
            // ����
            try
            {
                socketControl.Connect(ep);
            }
            catch (Exception)
            {
                return "Couldn't connect to remote server";
            }

            // ��ȡӦ����
            ReadReply();
            if (iReplyCode != 220)
            {
                DisConnect();
                return strReply.Substring(4);
            }

            // ��½
            SendCommand("USER " + strRemoteUser);
            if (!(iReplyCode == 331 || iReplyCode == 230))
            {
                CloseSocketConnect();//�ر�����
                return strReply.Substring(4);
            }
            if (iReplyCode != 230)
            {
                SendCommand("PASS " + strRemotePass);
                if (!(iReplyCode == 230 || iReplyCode == 202))
                {
                    CloseSocketConnect();//�ر�����
                    return strReply.Substring(4);
                }
            }
            bConnected = true;

            // �л�����ʼĿ¼
            if (!string.IsNullOrEmpty(strRemotePath))
            {
                if (ChDir(strRemotePath))
                    return "OK";
                else
                    return "Invalid Path ";
            }
            return "OK";
        }


        /// <summary>
        /// �ر�����
        /// </summary>
        public void DisConnect()
        {
            if (socketControl != null)
            {
                SendCommand("QUIT");
            }
            CloseSocketConnect();
        }

        #endregion

        #region ����ģʽ

        /// <summary>
        /// ����ģʽ:���������͡�ASCII����
        /// </summary>
        public enum TransferType
        {
            Binary,
            ASCII
        };

        /// <summary>
        /// ���ô���ģʽ
        /// </summary>
        /// <param name="ttType">����ģʽ</param>
        public bool SetTransferType(TransferType ttType)
        {
            if (ttType == TransferType.Binary)
            {
                SendCommand("TYPE I");//binary���ʹ���
            }
            else
            {
                SendCommand("TYPE A");//ASCII���ʹ���
            }
            if (iReplyCode != 200)
            {
                return false;
            }
            else
            {
                trType = ttType;
                return true;
            }
        }


        /// <summary>
        /// ��ô���ģʽ
        /// </summary>
        /// <returns>����ģʽ</returns>
        public TransferType GetTransferType()
        {
            return trType;
        }

        #endregion

        #region �ļ�����
        /// <summary>
        /// ����ļ��б�
        /// </summary>
        /// <param name="strMask">�ļ�����ƥ���ַ���</param>
        /// <returns></returns>
        public bool Dir(string strMask, ref string[] strsFileList)
        {
            // ��������
            if (!bConnected)
            {
                Connect();
            }

            //���������������ӵ�socket
            Socket socketData = CreateDataSocket();

            //��������
            SendCommand("LIST " + strMask);

            //����Ӧ�����
            if (!(iReplyCode == 150 || iReplyCode == 125 || iReplyCode == 226))
            {
                return false;
            }

            //��ý��
            strMsg = "";
            while (true)
            {
                int iBytes = socketData.Receive(buffer, buffer.Length, 0);
                strMsg += GB2312.GetString(buffer, 0, iBytes);
                if (iBytes < buffer.Length)
                {
                    break;
                }
            }
            char[] seperator = { '\n' };
            strsFileList = strMsg.Split(seperator);
            socketData.Close();//����socket�ر�ʱҲ���з�����
            if (iReplyCode != 226)
            {
                ReadReply();
                if (iReplyCode != 226)
                {
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// ��ȡ�ļ���С
        /// </summary>
        /// <param name="strFileName">�ļ���</param>
        /// <returns>�ļ���С</returns>
        public long GetFileSize(string strFileName)
        {
            if (!bConnected)
            {
                Connect();
            }
            SendCommand("SIZE " + Path.GetFileName(strFileName));
            long lSize = 0;
            if (iReplyCode == 213)
            {
                lSize = Int64.Parse(strReply.Substring(4));
            }
            else
            {
                return lSize;
                //throw new IOException(strReply.Substring(4));
            }
            return lSize;
        }


        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="strFileName">��ɾ���ļ���</param>
        public bool Delete(string strFileName)
        {
            if (!bConnected)
            {
                Connect();
            }
            SendCommand("DELE " + strFileName);
            if (iReplyCode != 250)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// ������(������ļ����������ļ�����,�����������ļ�)
        /// </summary>
        /// <param name="strOldFileName">���ļ���</param>
        /// <param name="strNewFileName">���ļ���</param>
        public bool Rename(string strOldFileName, string strNewFileName)
        {
            if (!bConnected)
            {
                Connect();
            }
            SendCommand("RNFR " + strOldFileName);
            if (iReplyCode != 350)
            {
                return false;
            }
            //  ������ļ�����ԭ���ļ�����,������ԭ���ļ�
            SendCommand("RNTO " + strNewFileName);
            if (iReplyCode != 250)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region �ϴ�������
        /// <summary>
        /// ����һ���ļ�
        /// </summary>
        /// <param name="strFileNameMask">�ļ�����ƥ���ַ���</param>
        /// <param name="strFolder">����Ŀ¼(������\����)</param>
        public string Get(string strFileNameMask, string strFolder)
        {
            string msg = null;
            if (!bConnected)
            {
                Connect();
            }
            //string[] strFiles = Dir(strFileNameMask);
            string[] strFiles = null;
            if (Dir(strFileNameMask, ref strFiles))
            {
                foreach (string strFile in strFiles)
                {
                    if (!strFile.Equals(""))//һ����˵strFiles�����һ��Ԫ�ؿ����ǿ��ַ���
                    {
                        if (strFile.LastIndexOf(".") > -1)
                        {
                            if (!Get(strFile.Replace("\r", ""), strFolder, strFile.Replace("\r", "")))
                            {
                                msg += strFile + "����ʧ��\r";
                            }
                        }
                    }
                }
            }
            return msg;
        }


        /// <summary>
        /// ����Ŀ¼
        /// </summary>
        /// <param name="strRemoteFileName">Ҫ���ص��ļ���</param>
        /// <param name="strFolder">����Ŀ¼(������\����)</param>
        /// <param name="strLocalFileName">�����ڱ���ʱ���ļ���</param>
        public bool Get(string strRemoteFileName, string strFolder, string strLocalFileName)
        {
            if (strLocalFileName.StartsWith("-r"))
            {
                string[] infos = strLocalFileName.Split(' ');
                strRemoteFileName = strLocalFileName = infos[infos.Length - 1];

                if (!bConnected)
                {
                    Connect();
                }
                SetTransferType(TransferType.Binary);
                if (strLocalFileName.Equals(""))
                {
                    strLocalFileName = strRemoteFileName;
                }
                if (!File.Exists(strLocalFileName))
                {
                    Stream st = File.Create(strLocalFileName);
                    st.Close();
                }

                FileStream output = new
                    FileStream(strFolder + "\\" + strLocalFileName, FileMode.Create);
                Socket socketData = CreateDataSocket();
                SendCommand("RETR " + strRemoteFileName);
                if (!(iReplyCode == 150 || iReplyCode == 125
                || iReplyCode == 226 || iReplyCode == 250))
                {
                    return false;
                }
                while (true)
                {
                    int iBytes = socketData.Receive(buffer, buffer.Length, 0);
                    output.Write(buffer, 0, iBytes);
                    if (iBytes <= 0)
                    {
                        break;
                    }
                }
                output.Close();
                if (socketData.Connected)
                {
                    socketData.Close();
                }
                if (!(iReplyCode == 226 || iReplyCode == 250))
                {
                    ReadReply();
                    if (!(iReplyCode == 226 || iReplyCode == 250))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// ����һ���ļ�
        /// </summary>
        /// <param name="strRemoteFileName">Ҫ���ص��ļ���</param>
        /// <param name="strFolder">����Ŀ¼(������\����)</param>
        /// <param name="strLocalFileName">�����ڱ���ʱ���ļ���</param>
        public bool GetFile(string strRemoteFileName, string strFolder, string strLocalFileName)
        {
            if (!bConnected)
            {
                Connect();
            }
            SetTransferType(TransferType.Binary);
            if (strLocalFileName.Equals(""))
            {
                strLocalFileName = strRemoteFileName;
            }
            FileStream output = new
                FileStream(strFolder + "\\" + strLocalFileName, FileMode.Create);
            Socket socketData = CreateDataSocket();
            SendCommand("RETR " + strRemoteFileName);
            if (!(iReplyCode == 150 || iReplyCode == 125
            || iReplyCode == 226 || iReplyCode == 250))
            {
                return false;
                // throw new IOException(strReply.Substring(4));
            }
            while (true)
            {
                int iBytes = socketData.Receive(buffer, buffer.Length, 0);
                output.Write(buffer, 0, iBytes);
                if (iBytes <= 0)
                {
                    break;
                }
            }
            output.Close();
            if (socketData.Connected)
            {
                socketData.Close();
            }
            if (!(iReplyCode == 226 || iReplyCode == 250))
            {
                ReadReply();
                if (!(iReplyCode == 226 || iReplyCode == 250))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// ����һ���ļ�
        /// </summary>
        /// <param name="strRemoteFileName">Ҫ���ص��ļ���</param>
        /// <param name="strFolder">����Ŀ¼(������\����)</param>
        /// <param name="strLocalFileName">�����ڱ���ʱ���ļ���</param>
        public bool GetBrokenFile(string strRemoteFileName, string strFolder, string strLocalFileName, long size)
        {
            if (!bConnected)
            {
                Connect();
            }
            SetTransferType(TransferType.Binary);



            FileStream output = new
                FileStream(strFolder + "\\" + strLocalFileName, FileMode.Append);
            Socket socketData = CreateDataSocket();
            SendCommand("REST " + size.ToString());
            SendCommand("RETR " + strRemoteFileName);
            if (!(iReplyCode == 150 || iReplyCode == 125
            || iReplyCode == 226 || iReplyCode == 250))
            {
                return false;
            }

            //int byteYu = (int)size % 512;
            //int byteChu = (int)size / 512;
            //byte[] tempBuffer = new byte[byteYu];
            //for (int i = 0; i < byteChu; i++)
            //{
            //    socketData.Receive(buffer, buffer.Length, 0);
            //}

            //socketData.Receive(tempBuffer, tempBuffer.Length, 0);

            //socketData.Receive(buffer, byteYu, 0);
            while (true)
            {
                int iBytes = socketData.Receive(buffer, buffer.Length, 0);
                //totalBytes += iBytes;

                output.Write(buffer, 0, iBytes);
                if (iBytes <= 0)
                {
                    break;
                }
            }
            output.Close();
            if (socketData.Connected)
            {
                socketData.Close();
            }
            if (!(iReplyCode == 226 || iReplyCode == 250))
            {
                ReadReply();
                if (!(iReplyCode == 226 || iReplyCode == 250))
                {
                    return false;
                }
            }
            return true;
        }



        /// <summary>
        /// �ϴ�һ���ļ�
        /// </summary>
        /// <param name="strFolder">����Ŀ¼(������\����)</param>
        /// <param name="strFileNameMask">�ļ���ƥ���ַ�(���԰���*��?)</param>
        public string Put(string strFolder, string strFileNameMask)
        {
            string msg = null;
            string[] strFiles = Directory.GetFiles(strFolder, strFileNameMask);
            foreach (string strFile in strFiles)
            {
                //strFile���������ļ���(����·��)
                if (!Put(strFile))
                {
                    msg += strFile + "�ϴ�ʧ��\r";
                }
            }
            return msg;
        }


        /// <summary>
        /// �ϴ�һ���ļ�
        /// </summary>
        /// <param name="strFileName">�����ļ���</param>
        public bool Put(string strFileName)
        {
            if (!bConnected)
            {
                Connect();
            }
            Socket socketData = CreateDataSocket();
            SendCommand("STOR " + Path.GetFileName(strFileName));
            if (!(iReplyCode == 125 || iReplyCode == 150))
            {
                return false;
            }
            FileStream input = new
            FileStream(strFileName, FileMode.Open);
            int iBytes = 0;
            while ((iBytes = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                socketData.Send(buffer, iBytes, 0);
            }
            input.Close();
            if (socketData.Connected)
            {
                socketData.Close();
            }
            if (!(iReplyCode == 226 || iReplyCode == 250))
            {
                ReadReply();
                if (!(iReplyCode == 226 || iReplyCode == 250))
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region Ŀ¼����
        /// <summary>
        /// ����Ŀ¼
        /// </summary>
        /// <param name="strDirName">Ŀ¼��</param>
        public bool MkDir(string strDirName)
        {
            if (!bConnected)
            {
                Connect();
            }
            SendCommand("MKD " + strDirName);
            if (iReplyCode != 257)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// ɾ��Ŀ¼
        /// </summary>
        /// <param name="strDirName">Ŀ¼��</param>
        public bool RmDir(string strDirName)
        {
            if (!bConnected)
            {
                Connect();
            }
            SendCommand("RMD " + strDirName);
            if (iReplyCode != 250)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// �ı�Ŀ¼
        /// </summary>
        /// <param name="strDirName">�µĹ���Ŀ¼��</param>
        public bool ChDir(string strDirName)
        {
            if (strDirName.Equals(".") || strDirName.Equals(""))
            {
                return false;
            }
            if (!bConnected)
            {
                Connect();
            }
            SendCommand("CWD " + strDirName);
            if (iReplyCode != 250)
            {
                //throw new IOException(strReply.Substring(4));
                if (MkDir(strDirName))
                {
                    SendCommand("CWD " + strDirName);
                    if (iReplyCode != 250)
                        return false;
                }
                else
                    return false;
            }
            this.strRemotePath = strDirName;
            return true;
        }

        #endregion

        #region �ڲ�����
        /// <summary>
        /// ���������ص�Ӧ����Ϣ(����Ӧ����)
        /// </summary>
        private string strMsg;
        /// <summary>
        /// ���������ص�Ӧ����Ϣ(����Ӧ����)
        /// </summary>
        private string strReply;
        /// <summary>
        /// ���������ص�Ӧ����
        /// </summary>
        private int iReplyCode;
        /// <summary>
        /// ���п������ӵ�socket
        /// </summary>
        private Socket socketControl;
        /// <summary>
        /// ����ģʽ
        /// </summary>
        private TransferType trType;
        /// <summary>
        /// ���պͷ������ݵĻ�����
        /// </summary>
        private static int BLOCK_SIZE = 512;
        Byte[] buffer = new Byte[BLOCK_SIZE];
        /// <summary>
        /// ���뷽ʽ(Ϊ��ֹ��������������� GB2312���뷽ʽ)
        /// </summary>
        Encoding GB2312 = Encoding.GetEncoding("gb2312");
        #endregion

        #region �ڲ�����
        /// <summary>
        /// ��һ��Ӧ���ַ�����¼��strReply��strMsg
        /// Ӧ�����¼��iReplyCode
        /// </summary>
        private void ReadReply()
        {
            strMsg = "";
            strReply = ReadLine();
            iReplyCode = Int32.Parse(strReply.Substring(0, 3));
        }

        /// <summary>
        /// ���������������ӵ�socket
        /// </summary>
        /// <returns>��������socket</returns>
        private Socket CreateDataSocket()
        {
            SendCommand("PASV");
            if (iReplyCode != 227)
            {
                throw new IOException(strReply.Substring(4));
            }
            int index1 = strReply.IndexOf('(');
            int index2 = strReply.IndexOf(')');
            string ipData =
            strReply.Substring(index1 + 1, index2 - index1 - 1);
            int[] parts = new int[6];
            int len = ipData.Length;
            int partCount = 0;
            string buf = "";
            for (int i = 0; i < len && partCount <= 6; i++)
            {
                char ch = Char.Parse(ipData.Substring(i, 1));
                if (Char.IsDigit(ch))
                    buf += ch;
                else if (ch != ',')
                {
                    throw new IOException("Malformed PASV strReply: " +
                    strReply);
                }
                if (ch == ',' || i + 1 == len)
                {
                    try
                    {
                        parts[partCount++] = Int32.Parse(buf);
                        buf = "";
                    }
                    catch (Exception)
                    {
                        throw new IOException("Malformed PASV strReply: " +
                         strReply);
                    }
                }
            }
            string ipAddress = parts[0] + "." + parts[1] + "." +
            parts[2] + "." + parts[3];
            int port = (parts[4] << 8) + parts[5];
            Socket s = new
            Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new
            IPEndPoint(IPAddress.Parse(ipAddress), port);
            try
            {
                s.Connect(ep);
            }
            catch (Exception)
            {
                throw new IOException("Can't connect to remote server");
            }
            return s;
        }


        /// <summary>
        /// �ر�socket����(���ڵ�¼��ǰ)
        /// </summary>
        private void CloseSocketConnect()
        {
            if (socketControl != null)
            {
                socketControl.Close();
                socketControl = null;
            }
            bConnected = false;
        }

        /// <summary>
        /// ��ȡSocket���ص������ַ���
        /// </summary>
        /// <returns>����Ӧ������ַ�����</returns>
        private string ReadLine()
        {
            while (true)
            {
                int iBytes = socketControl.Receive(buffer, buffer.Length, 0);
                strMsg += GB2312.GetString(buffer, 0, iBytes);
                if (iBytes < buffer.Length)
                {
                    break;
                }
            }
            char[] seperator = { '\n' };
            string[] mess = strMsg.Split(seperator);
            if (strMsg.Length > 2)
            {
                strMsg = mess[mess.Length - 2];
                //seperator[0]��10,���з�����13��0��ɵ�,�ָ���10������û���ַ���,
                //��Ҳ�����Ϊ���ַ���������(Ҳ�����һ��)�ַ�������,
                //�������һ��mess��û�õĿ��ַ���
                //��Ϊʲô��ֱ��ȡmess[0],��Ϊֻ�����һ���ַ���Ӧ��������Ϣ֮���пո�
            }
            else
            {
                strMsg = mess[0];
            }
            if (!strMsg.Substring(3, 1).Equals(" "))//�����ַ�����ȷ������Ӧ����(��220��ͷ,�����һ�ո�,�ٽ��ʺ��ַ���)
            {
                return ReadLine();
            }
            return strMsg;
        }


        /// <summary>
        /// ���������ȡӦ��������һ��Ӧ���ַ���
        /// </summary>
        /// <param name="strCommand">����</param>
        private void SendCommand(String strCommand)
        {
            Byte[] cmdBytes =
            GB2312.GetBytes((strCommand + "\r\n").ToCharArray());
            socketControl.Send(cmdBytes, cmdBytes.Length, 0);
            ReadReply();
        }

        #endregion
    }
}