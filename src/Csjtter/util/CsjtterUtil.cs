using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Csjtter.util {
    public class CsjtterUtil {
        private readonly static DateTime unixTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static long toUnixTime(DateTime dateTime) {
            dateTime = dateTime.ToUniversalTime();
            return (long)dateTime.Subtract(unixTime).TotalSeconds;
        }

        //http://kuroeveryday.blogspot.jp/2013/09/CSharpTwitterHttpUtillityUrlEncode.html
        protected static string unreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";
        public static string urlEncode(string value) {
            StringBuilder result = new StringBuilder();
            byte[] data = Encoding.UTF8.GetBytes(value);
            foreach(byte b in data) {
                int c = b;
                if(c < 0x80 && unreservedChars.IndexOf((char)c) != -1) {
                    result.Append((char)c);
                } else {
                    result.Append(String.Format("%{0:X2}", c));
                }

            }
            return result.ToString();
        }

        public static byte[] toByteArray(string s) {
            return Encoding.UTF8.GetBytes(s);
        }

        public static string toBase64(byte[] b) {
            return Convert.ToBase64String(b);
        }

        public static string toString(long[] ls) {
            StringBuilder sb = new StringBuilder();
            foreach(long l in ls) {
                if(sb.Length > 0) {
                    sb.Append(',');
                }
                sb.Append(l);
            }
            return sb.ToString();
        }
    }
}
