using System;
using System.Text;

namespace rainfalls.Base.Class
{
    /// <summary>   
    /// 消息CRC校验算法   
    /// </summary>   
    public class CRC
    {

        public static UInt16 getCrc16Code(byte[] creBytes, UInt32 cont)
        {

            // 转换成字节数组  
            // byte[] creBytes = HexString2Bytes(crcString);

            // 开始crc16校验码计算  
            CRC16Util crc16 = new CRC16Util();
            crc16.reset();
            UInt16 crc = crc16.Crc16(creBytes, cont);
            //int crc = crc16.getCrcValue();
            //// 16进制的CRC码  
            //String crcCode = Convert.ToString(crc, 16).ToUpper();
            //// 补足到4位  
            //if (crcCode.Length < 4)
            //{
            //    // crcCode = StringUtil.lefgPadding(crcCode, '0', 4);  
            //    crcCode = crcCode.PadLeft(4, '0');
            //}
            return crc;
        }



        public static String RealHexToStr(String str)
        {
            String hText = "0123456789ABCDEF";
            StringBuilder bin = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                bin.Append(hText[str[i] / 16]).Append(hText[str[i] % 16]).Append(' ');
            }
            return bin.ToString();
        }
        /** 
        * 十六进制字符串转换成字节数组 
        *  
        * @param hexstr 
        * @return 
        */
        public static byte[] HexString2Bytes(String hexstr)
        {
            byte[] b = new byte[hexstr.Length / 2];
            int j = 0;
            for (int i = 0; i < b.Length; i++)
            {
                char c0 = hexstr[j++];
                char c1 = hexstr[j++];
                b[i] = (byte)((parse(c0) << 4) | parse(c1));
            }
            return b;
        }


        /** 
        * 16进制char转换成整型 
        *  
        * @param c 
        * @return 
        */
        public static int parse(char c)
        {
            if (c >= 'a')
                return (c - 'a' + 10) & 0x0f;
            if (c >= 'A')
                return (c - 'A' + 10) & 0x0f;
            return (c - '0') & 0x0f;
        }




        public static string ByteArrayToHexString(byte[] data)//字节数组转为十六进制字符串  
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            return sb.ToString().ToUpper();
        }


    }
}
