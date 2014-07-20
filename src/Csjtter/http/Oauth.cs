using Csjtter.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Csjtter.http {
    internal class Oauth {
        protected CsjtterConfig config;
        public Oauth(CsjtterConfig config) {
            this.config=config;
        }

        public string makeOauthNonce() {
            return CsjtterUtil.toUnixTime(DateTime.Now).ToString()+new Random().Next(10);
            //return new Random().Next(123400, 9999999).ToString();
        }

        public string makeHeader(AccountKey key, string url, string method, string callback, Dictionary<string, string> param) {
            string time=CsjtterUtil.toUnixTime(DateTime.Now).ToString();
            string nonce=makeOauthNonce();
            SortedDictionary<string, string> map=new SortedDictionary<string, string>();
            map.Add("oauth_nonce", nonce);
            if(callback!=null) {
                map.Add("oauth_callback", callback);
            }
            map.Add("oauth_signature_method", "HMAC-SHA1");
            map.Add("oauth_timestamp", time);
            map.Add("oauth_consumer_key", key.consumerKey);
            if(key.accessToken!=null&&key.accessToken.Length>0) {
                map.Add("oauth_token", key.accessToken);
            }
            map.Add("oauth_version", "1.0");
            map.Add("oauth_signature", makeSignature(key, url, method, callback, time, nonce, param));
            StringBuilder baseValue=new StringBuilder();
            foreach(KeyValuePair<string, string> v in map) {
                if(baseValue.Length>0) {
                    baseValue.Append(',');
                    baseValue.Append(' ');
                }
                baseValue.Append(v.Key);
                baseValue.Append('=');
                baseValue.Append('"');
                baseValue.Append(CsjtterUtil.urlEncode(v.Value));
                baseValue.Append('"');
            }
            string baseString=baseValue.ToString();
            if(config.isLog>0) {
                Console.Out.WriteLine("Oauth.cs#makeHeader baseString");
                Console.Out.WriteLine(baseString);
            }
            return baseString;
        }


        private string makeSignature(AccountKey key, string url, string method, string callback, string time, string nonce, Dictionary<string, string> param) {
            SortedDictionary<string, string> map=new SortedDictionary<string, string>();
            map.Add("oauth_nonce", nonce);
            if(callback!=null) {
                map.Add("oauth_callback", callback);
            }
            map.Add("oauth_signature_method", "HMAC-SHA1");
            map.Add("oauth_timestamp", time);
            map.Add("oauth_consumer_key", key.consumerKey);
            if(key.accessToken!=null) {
                map.Add("oauth_token", key.accessToken);
            }
            map.Add("oauth_version", "1.0");
            map.Add("include_entities", config.include_entities==true?"true":"false");
            if(param!=null&&param.Count>0) {
                foreach(KeyValuePair<string, string> v in param) {
                   map.Add(v.Key,v.Value);
                }
            }
            StringBuilder baseValue=new StringBuilder();
            foreach(KeyValuePair<string, string> v in map) {
                if(baseValue.Length>0) {
                    baseValue.Append('&');
                }
                baseValue.Append(v.Key);
                baseValue.Append('=');
                baseValue.Append(CsjtterUtil.urlEncode(v.Value));
                //baseValue.Append(v.Value);
            }
            string baseString=method+"&"+CsjtterUtil.urlEncode(url)+"&";
            baseString=baseString+CsjtterUtil.urlEncode(baseValue.ToString());
            if(config.isLog>0) {
                Console.Out.WriteLine("Oauth.cs#makeSignature baseString");
                Console.Out.WriteLine(baseString);
            }
            //HMACSHA1 mac=new HMACSHA1(CsjtterUtil.toByteArray(CsjtterUtil.urlEncode(key.consumerSecret)+"&"+CsjtterUtil.urlEncode(key.accessTokenSecret)));
            //string res=CsjtterUtil.toBase64(mac.ComputeHash(CsjtterUtil.toByteArray(baseString)));
            //mac.Clear();
            //return res;
            HMACSHA1 hmacsha1=new HMACSHA1();
            hmacsha1.Key=Encoding.UTF8.GetBytes(string.Format("{0}&{1}", CsjtterUtil.urlEncode(key.consumerSecret), string.IsNullOrEmpty(key.accessTokenSecret)?"":CsjtterUtil.urlEncode(key.accessTokenSecret)));

            byte[] dataBuffer=System.Text.Encoding.ASCII.GetBytes(baseString);
            byte[] hashBytes=hmacsha1.ComputeHash(dataBuffer);

            return Convert.ToBase64String(hashBytes);
        }
    }
}
