using System;
using System.Runtime.InteropServices;

namespace Rainfall.App.AppSync
{
    public class CRasDial
    {
        public const int RAS_MaxEntryName = 256;
        public const int RAS_MaxPhoneNumber = 128;
        public const int UNLEN = 256;
        public const int PWLEN = 256;
        public const int DNLEN = 15;
        public const int MAX_PATH = 260;
        public const int RAS_MaxDeviceType = 16;
        public const int RAS_MaxCallbackNumber = RAS_MaxPhoneNumber;

        public delegate void Callback(uint unMsg, int rasconnstate, int dwError);

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Auto)]
        public struct RASDIALPARAMS
        {
            public int dwSize;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = RAS_MaxEntryName + 1)]
            public string szEntryName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = RAS_MaxPhoneNumber + 1)]
            public string szPhoneNumber;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = RAS_MaxCallbackNumber + 1)]
            public string szCallbackNumber;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = UNLEN + 1)]
            public string szUserName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = PWLEN + 1)]
            public string szPassword;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = DNLEN + 1)]
            public string szDomain;
            public int dwSubEntry;
            public int dwCallbackId;
        }

        private const int RASCS_PAUSED = 0x1000;
        private const int RASCS_DONE = 0x2000;
        private const int RASBASE = 600;
        private const int ERROR_INVALID_PORT_HANDLE = (RASBASE + 1);
        private const int ERROR_INVALID_HANDLE = 6;

        public enum RASCONNSTATE : int
        {
            RASCS_OpenPort = 0, //0
            RASCS_PortOpened, //1
            RASCS_ConnectDevice, //2
            RASCS_DeviceConnected, //3
            RASCS_AllDevicesConnected, //4
            RASCS_Authenticate, //5
            RASCS_AuthNotify, //6
            RASCS_AuthRetry, //6
            RASCS_AuthCallback, //8
            RASCS_AuthChangePassword, //9
            RASCS_AuthProject, //10
            RASCS_AuthLinkSpeed, //11
            RASCS_AuthAck, //12
            RASCS_ReAuthenticate, //13
            RASCS_Authenticated, //14
            RASCS_PrepareForCallback, //15
            RASCS_WaitForModemReset, //16
            RASCS_WaitForCallback, //17
            RASCS_Projected, //18
            RASCS_Interactive = RASCS_PAUSED, //4096
            RASCS_RetryAuthentication, //4097
            RASCS_CallbackSetByCaller, //4098
            RASCS_PasswordExpired, //4099
            RASCS_Connected = RASCS_DONE, //8192
            RASCS_Disconnected //8193
        };

        private const int RAS_MaxDeviceName = 128;
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        struct RASCONNSTATUS
        {
            public int dwSize;
            public int rasconnstate;
            public int dwError;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = RAS_MaxDeviceType + 1)]
            public string szDeviceType;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = RAS_MaxDeviceName + 1)]
            public string szDeviceName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = RAS_MaxPhoneNumber + 1)]
            public string szPhoneNumber;
        };

        [DllImport("rasapi32.dll ", CharSet = CharSet.Auto)]
        public static extern int RasDial(int lpRasDialExtensions, string lpszPhonebook, ref   RASDIALPARAMS lprasdialparams, int dwNotifierType, Callback lpvNotifier, ref   int lphRasConn);

        [DllImport("rasapi32.dll", CharSet = CharSet.Auto)]
        public extern static int RasHangUp(int hrasconn); // handle to the RAS connection to hang up );

        [DllImport("rasapi32.dll", CharSet = CharSet.Auto)]
        private static extern uint RasGetConnectStatus(int hrasconn, ref RASCONNSTATUS lprasconnstatus);
        [DllImport("coredll.dll", SetLastError = true)]
        static extern Int32 GetLastError();

        private RASDIALPARAMS RasDialParams;
        private int rasSession;

        public CRasDial()
        {
            rasSession = 0;
            RasDialParams = new RASDIALPARAMS();
            RasDialParams.dwSize = Marshal.SizeOf(RasDialParams);
        }

        #region   Properties
        public string UserName
        {
            get
            {
                return RasDialParams.szUserName;
            }
            set
            {
                RasDialParams.szUserName = value;
            }
        }

        public string Password
        {
            get
            {
                return RasDialParams.szPassword;
            }
            set
            {
                RasDialParams.szPassword = value;
            }
        }

        public string EntryName
        {
            get
            {
                return RasDialParams.szEntryName;
            }
            set
            {
                RasDialParams.szEntryName = value;
            }
        }
        #endregion

        public int GetRasStatus()
        {
            RASCONNSTATUS RASConnStatus = new RASCONNSTATUS();
            RASConnStatus.dwSize = Marshal.SizeOf(typeof(RASCONNSTATUS));
            uint lResult = RasGetConnectStatus(rasSession, ref RASConnStatus);
            return (int)lResult;
        }

        public int DialUp()
        {
            RasDialParams.szEntryName += "\0 ";
            RasDialParams.szDomain += "*";
            int result = RasDial(0, null, ref   RasDialParams, 0, null, ref rasSession);
            return result;
        }

        public void HangUp()
        {
            if (rasSession != 0)
            {
                int lStatus = RasHangUp(rasSession);
                if (lStatus != 0)
                {
                    //πÿ±’≤¶∫≈¡¨Ω” ß∞‹
                }
                rasSession = 0;
            }
        }
    }
}