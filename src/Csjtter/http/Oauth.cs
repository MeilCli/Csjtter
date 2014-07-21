using Csjtter.util;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Csjtter.http {
    internal class Oauth {
        protected CsjtterConfig config;
        public Oauth(CsjtterConfig config) {
            this.config=config;
        }

        public string makeOauthNonce() {
            return new Random().Next(123400, 9999999).ToString();
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
                baseValue.Append(CsjtterUtil.urlEncode(v.Key));
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
            if(param!=null&&param.Count>0) {
                foreach(KeyValuePair<string, string> v in param) {
                    map.Add(v.Key, v.Value);
                }
            }
            StringBuilder baseValue=new StringBuilder();
            foreach(KeyValuePair<string, string> v in map) {
                if(baseValue.Length>0) {
                    baseValue.Append('&');
                }
                baseValue.Append(CsjtterUtil.urlEncode(v.Key));
                baseValue.Append('=');
                baseValue.Append(CsjtterUtil.urlEncode(v.Value));
            }

            Uri uri=new Uri(url);
            string normalizedUrl=string.Format("{0}://{1}", uri.Scheme, uri.Host);
            if(!((uri.Scheme=="http"&&uri.Port==80)||(uri.Scheme=="https"&&uri.Port==443))) {
                normalizedUrl+=":"+uri.Port;
            }
            normalizedUrl+=uri.AbsolutePath;

            string baseString=method+"&"+CsjtterUtil.urlEncode(normalizedUrl)+"&";
            baseString=baseString+CsjtterUtil.urlEncode(baseValue.ToString());
            if(config.isLog>0) {
                Console.Out.WriteLine("Oauth.cs#makeSignature baseString");
                Console.Out.WriteLine(baseString);
            }

            HMACSHA1 hmacsha1=new HMACSHA1();
            hmacsha1.Key=Encoding.ASCII.GetBytes(string.Format("{0}&{1}", CsjtterUtil.urlEncode(key.consumerSecret), string.IsNullOrEmpty(key.accessTokenSecret)?"":CsjtterUtil.urlEncode(key.accessTokenSecret)));

            byte[] dataBuffer=System.Text.Encoding.UTF8.GetBytes(baseString);
            byte[] hashBytes=hmacsha1.ComputeHash(dataBuffer);

            return CsjtterUtil.toBase64(hashBytes);
        }
    }
}
