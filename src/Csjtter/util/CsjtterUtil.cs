using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Csjtter.util {
    public class CsjtterUtil {
        private readonly static DateTime unixTime = new DateTime(1970,1,1,0,0,0,DateTimeKind.Utc);
        public static long toUnixTime(DateTime dateTime) {
            dateTime = dateTime.ToUniversalTime();
            return (long)dateTime.Subtract(unixTime).TotalSeconds;
        }

        public static string urlEncode(string url) {
            return HttpUtility.UrlEncode(url);
        }
    }
}
