//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;

//namespace MyFormat
//{
//    public class Format
//    {
//        /// <summary>
//        /// 将十六进制字符串转换成十六进制数组（不足末尾补0），失败返回空数组
//        /// </summary>
//        /// <param name="strings"></param>
//        /// <returns></returns>
//        public byte[] StringToHex(this string strings)
//        {
//            byte[] hex = new byte[0];
//            try
//            {
//                strings = strings.Replace("0x", "");
//                strings = strings.Replace("0X", "");
//                strings = strings.Replace(" ", "");
//                strings = Regex.Replace(strings, @"(?i)[^a-f\d\s]+", "");
//                if (strings.Length % 2 != 0)
//                {
//                    strings += "0";
//                }
//                hex = new byte[strings.Length / 2];
//                for (int i = 0; i < hex.Length; i++)
//                {
//                    hex[i] = Convert.ToByte(strings.Substring(i * 2, 2), 16);
//                }
//                return hex;
//            }
//            catch
//            {
//                return hex;
//            }
//        }

//        /// <summary>
//        /// 将十六进制数组转换成十六进制字符串，并以space隔开
//        /// </summary>
//        /// <param name="hex"></param>
//        /// <param name="space"></param>
//        /// <returns></returns>
//        public string HexToStrings(this byte[] hex, string space)
//        {
//            string strings = "";
//            for (int i = 0; i < hex.Length; i++)//逐字节变为16进制字符，并以space隔开
//            {
//                strings += hex[i].ToString("X2") + space;
//            }
//            return strings;
//        }

//        /// <summary>
//        /// 将十六进制数组转换成十六进制字符串
//        /// </summary>
//        /// <param name="hex"></param>
//        /// <returns></returns>
//        public string HexToStrings(this byte[] hex)
//        {
//            return HexToStrings(hex, "");
//        }

//        /// <summary>
//        /// 移除字符串中的多余空格
//        /// </summary>
//        /// <param name="strings"></param>
//        /// <returns></returns>
//        public string RemoveUnwantedSpaces(this string strings)
//        {
//            strings = Regex.Replace(strings.Trim(), "\\s+", " ");
//            return strings;
//        }

//        /// <summary>
//        /// 在字符串中每隔length个字符添加一个空格
//        /// </summary>
//        /// <param name="strings"></param>
//        /// <param name="length"></param>
//        /// <returns></returns>
//        public string InsertSpace(this string strings, int length)
//        {
//            int i;
//            string str = "";
//            for (i = 0; i < strings.Length; i++)
//            {
//                str += strings[i];
//                if (i % length != 0 && i != strings.Length - 1)
//                {
//                    str += " ";
//                }
//            }
//            return str;
//        }

//        public bool IsEscaped(this string strings)
//        {
//            if (strings.Length == 7)
//            {
//                return true;
//            }
//            return false;
//        }

//        /// <summary>
//        /// UDS DTC故障码转义
//        /// </summary>
//        /// <param name="strings"></param>
//        /// <returns></returns>
//        public static string DtcEscape(this string strings)
//        {
//            if (strings.IsEscaped())
//            {
//                return strings;
//            }

//            string code = string.Empty;
//            byte dtc_code = Convert.ToByte(strings.Substring(0, 2), 16);
//            if ((dtc_code & 0xC0) == 0x00)
//            {
//                code += "P";
//            }
//            else if ((dtc_code & 0xC0) == 0x40)
//            {
//                code += "C";
//            }
//            else if ((dtc_code & 0xC0) == 0x80)
//            {
//                code += "B";
//            }
//            else
//            {
//                code += "U";
//            }

//            code += (dtc_code & 0x3F).ToString("X2");
//            code += strings.Substring(2, 4);

//            return code;
//        }

//        public static string DtcReverseEscape(this string strings)
//        {
//            if (!strings.IsEscaped())
//            {
//                return strings;
//            }
//            string code = string.Empty;
//            byte dtc_code = Convert.ToByte(strings.Substring(1, 2), 16);
//            if (strings[0] == 'P')
//            {
//                dtc_code |= 0x00;
//            }
//            else if (strings[0] == 'C')
//            {
//                dtc_code |= 0x40;
//            }
//            else if (strings[0] == 'B')
//            {
//                dtc_code |= 0x80;
//            }
//            else
//            {
//                dtc_code |= 0xC0;
//            }
//            code = dtc_code.ToString("X2") + strings.Substring(3, 4);
//            return code;
//        }

//        /// <summary>
//        /// Intel
//        /// </summary>
//        /// <param name="bytes"></param>
//        /// <param name="start"></param>
//        /// <param name="length"></param>
//        /// <param name="value"></param>
//        /// <returns></returns>
//        public static byte[] SetBitIntel(this byte[] bytes, int start, int length, int value)
//        {
//            for (int i = 0; i < length; i++)
//            {
//                int posByte = (i + start) / 8;
//                int posBit = (i + start) % 8;
//                byte bitValue = (byte)((value >> i) & 0x01);

//                bytes[posByte] &= (byte)(~(1 << posBit));
//                bytes[posByte] |= (byte)(bitValue << posBit);
//            }
//            return bytes;
//        }

//        /// <summary>
//        /// Intel
//        /// </summary>
//        /// <param name="bytes"></param>
//        /// <param name="start"></param>
//        /// <param name="length"></param>
//        /// <returns></returns>
//        public static int GetBitIntel(this byte[] bytes, int start, int length)
//        {
//            int value = 0;
//            for (int i = 0; i < length; i++)
//            {
//                int posByte = (i + start) / 8;
//                int posBit = (i + start) % 8;
//                value |= (((int)bytes[posByte] >> posBit) & 0x01) << i;
//            }
//            return value;
//        }

//        /// <summary>
//        /// Motorola
//        /// </summary>
//        /// <param name="bytes"></param>
//        /// <param name="start"></param>
//        /// <param name="length"></param>
//        /// <param name="value"></param>
//        /// <returns></returns>
//        public static byte[] SetBitMotorola(this byte[] bytes, int start, int length, int value)
//        {
//            int posByte = start / 8;
//            int posBit = start % 8;

//            for (int i = 0; i < length; i++)
//            {
//                byte bitValue = (byte)((value >> i) & 0x01);

//                bytes[posByte] &= (byte)(~(1 << posBit));
//                bytes[posByte] |= (byte)(bitValue << posBit);
//                if (i >= length)
//                {
//                    break;
//                }
//                if (++posBit >= 8)
//                {
//                    posBit = 0;
//                    posByte--;
//                }
//            }
//            return bytes;
//        }

//        /// <summary>
//        /// Motorola
//        /// </summary>
//        /// <param name="bytes"></param>
//        /// <param name="start"></param>
//        /// <param name="length"></param>
//        /// <returns></returns>
//        public static int GetBitMotorola(this byte[] bytes, int start, int length)
//        {
//            int value = 0;
//            int posByte = start / 8;
//            int posBit = start % 8;

//            for (int i = 0; i < length; i++)
//            {
//                value |= (((int)bytes[posByte] >> posBit) & 0x01) << i;

//                if (i >= length)
//                {
//                    break;
//                }
//                if (++posBit >= 8)
//                {
//                    posBit = 0;
//                    posByte--;
//                }
//            }
//            return value;
//        }
//    }
//}
