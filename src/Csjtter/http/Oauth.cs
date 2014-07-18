using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csjtter.http {
    public class Oauth {

        public string makeOauthNonce() {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(System.DateTime.Now.Millisecond.ToString().ToCharArray()));
        }

        public string makeHeader(AccountKey key,string callback) {
            Dictionary<string,string> map = new Dictionary<string,string>();
            map.Add("oauth_nonce",makeOauthNonce());
            if (callback != null) {
                map.Add("oauth_callback",callback);
            }
            map.Add("oauth_signature_method","HMAC-SHA1");
            map.Add("oauth_timestamp",Csjtter.util.CsjtterUtil.toUnixTime(DateTime.Now).ToString());
            map.Add("oauth_consumer_key",key.consumerKey);
            return null;
        }

    }
}
