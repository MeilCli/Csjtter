using Csjtter.http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Csjtter {
    public class CsjtterBase {
        protected AccountKey key;
        protected CsjtterConfig config;
        internal HttpHelper http;

        public CsjtterBase(AccountKey key, CsjtterConfig config) {
            this.key=key;
            this.config=config;
            this.http=new HttpHelper(config);
        }

        protected CsjtterException checkError(HttpResponseMessage res) {
            if(res==null) {
                return new CsjtterException("null return error");
            }
            if(res.IsSuccessStatusCode==true) {
                return null;
            }
            string errorString=res.Content.ReadAsStringAsync().Result;
            if(config.isLog>1) {
                Console.Out.WriteLine("error header");
                Console.Out.WriteLine(res.Headers.ToString());
                Console.Out.WriteLine("error response");
                Console.Out.WriteLine(errorString);
            }
            JObject obj=JObject.Parse(errorString);
            JArray ar=(JArray)obj["errors"];
            string errorMssage=(string)ar[0]["message"];
            int code=(int)ar[0]["code"];
            return new CsjtterException(errorMssage, (int)res.StatusCode, code);
        }

        public AccountKey getRequestToken() {
            return getRequestToken(null);
        }

        public AccountKey getRequestToken(string callback) {
            HttpData data=new HttpData();
            data.callback=callback;
            data.url=config.requestTokenURL;
            HttpResponseMessage res=http.post(key, data);
            CsjtterException exception=checkError(res);
            if(exception!=null) {
                throw exception;
            }
            string text=res.Content.ReadAsStringAsync().Result;
            string oauthToken="";
            string oauthTokenSecret="";
            foreach(string s in text.Split('&')) {
                if(s.StartsWith("oauth_token=")==true) {
                    oauthToken=s.Substring(s.IndexOf('=')+1);
                } else if(s.StartsWith("oauth_token_secret=")==true) {
                    oauthTokenSecret=s.Substring(s.IndexOf('=')+1);
                }
            }
            key.accessToken=oauthToken;
            key.accessTokenSecret=oauthTokenSecret;
            return key;
        }

        public string getAuthorizeURL() {
            return config.authorizeURL+"?oauth_token="+key.accessToken;
        }

        public AccountData getOauthToken(string oauth_verifier) {
            HttpData data=new HttpData();
            data.url=config.oauthToknURL;
            data.param=new Dictionary<string, string> { { "oauth_verifier", oauth_verifier } };
            HttpResponseMessage res=http.post(key, data);
            CsjtterException exception=checkError(res);
            if(exception!=null) {
                throw exception;
            }
            string text=res.Content.ReadAsStringAsync().Result;
            string oauthToken="";
            string oauthTokenSecret="";
            string userId="";
            string screenName="";
            string name="";
            foreach(string s in text.Split('&')) {
                if(s.StartsWith("oauth_token=")==true) {
                    oauthToken=s.Substring(s.IndexOf('=')+1);
                } else if(s.StartsWith("oauth_token_secret=")==true) {
                    oauthTokenSecret=s.Substring(s.IndexOf('=')+1);
                } else if(s.StartsWith("user_id=")==true) {
                    userId=s.Substring(s.IndexOf('=')+1);
                } else if(s.StartsWith("screen_name=")==true) {
                    screenName=s.Substring(s.IndexOf('=')+1);
                } else if(s.StartsWith("name=")==true) {
                    name=s.Substring(s.IndexOf('=')+1);
                }
            }
            key.accessToken=oauthToken;
            key.accessTokenSecret=oauthTokenSecret;
            return new AccountData(key, name, screenName, long.Parse(userId));
        }

        /*public void test() {
            HttpData data=new HttpData();
            data.url="https://api.twitter.com/1.1/statuses/update.json";
            data.param=new Dictionary<string, string>() { {"status","C#でPOST"}};
            HttpResponseMessage res=http.post(key, data);
            CsjtterException exception=checkError(res);
            if(exception!=null) {
                Console.Out.WriteLine("request message");
                Console.Out.WriteLine(res.RequestMessage.Content.ToString()+res.RequestMessage.Content.ReadAsStringAsync().Result);
                throw exception;
            }
            string text=res.Content.ReadAsStringAsync().Result;
            Console.Out.WriteLine(text);
        }*/
        
        /*public void test() {
            HttpData data=new HttpData();
            data.url="https://api.twitter.com/1.1/statuses/home_timeline.json";
            HttpResponseMessage res=http.get(key, data);
            CsjtterException exception=checkError(res);
            if(exception!=null) {
                Console.Out.WriteLine("request message");
                Console.Out.WriteLine(res.RequestMessage.Headers.ToString());
                throw exception;
            }
            string text=res.Content.ReadAsStringAsync().Result;
           Console.Out.WriteLine(text);
        }*/
    }
}
