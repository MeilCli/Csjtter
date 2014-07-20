using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Csjtter.util;
using System.Net;


namespace Csjtter.http {
    internal class HttpHelper : Oauth {
        private HttpClient client;

        public HttpHelper(CsjtterConfig config)
            : base(config) {
            HttpClientHandler handler=new HttpClientHandler();
            if(handler.SupportsAutomaticDecompression==true) {
                handler.AutomaticDecompression=DecompressionMethods.GZip|DecompressionMethods.Deflate;
            }
            client=new HttpClient(handler);
        }

        public HttpResponseMessage post(AccountKey key, HttpData data) {
            List<AccountKey> keys=new List<AccountKey>();
            keys.Add(key);
            return post(keys, data);
        }

        public HttpResponseMessage post(List<AccountKey> keys, HttpData data) {
            MultipartFormDataContent content=new MultipartFormDataContent();
            if(data.param.Count>0) {
                FormUrlEncodedContent param=new FormUrlEncodedContent(data.param);
                content.Add(param);
            }
            foreach(KeyValuePair<string, string> v in data.fparam) {
                try {
                    FileStream stream=File.Open(v.Value, FileMode.Open);
                    StreamContent sc=new StreamContent(stream);
                    string type;
                    if(v.Key.EndsWith("png")==true) {
                        type="png";
                    } else if(v.Key.EndsWith("gif")==true) {
                        type="gif";
                    } else {
                        type="jpeg";
                    }
                    sc.Headers.ContentType=MediaTypeHeaderValue.Parse("image/"+type);
                    content.Add(sc, "image", v.Key);
                } catch(Exception) { }
            }
            HttpResponseMessage res=null;
            foreach(AccountKey key in keys) {
                string header=this.makeHeader(key, data.url, "POST", data.callback, data.param);
                res=post(data.url, header, content);
                if(res.IsSuccessStatusCode==true) {
                    return res;
                }
            }
            return res;
        }

        public HttpResponseMessage get(AccountKey key, HttpData data) {
            List<AccountKey> keys=new List<AccountKey>();
            keys.Add(key);
            return get(keys, data);
        }

        public HttpResponseMessage get(List<AccountKey> keys, HttpData data) {
            StringBuilder request=new StringBuilder();
            foreach(KeyValuePair<string, string> v in data.param) {
                if(request.Length>0) {
                    request.Append('&');
                }
                request.Append(v.Key);
                request.Append('=');
                request.Append(CsjtterUtil.urlEncode(v.Value));
            }
            HttpResponseMessage res=null;
            foreach(AccountKey key in keys) {
                string header=this.makeHeader(key, data.url, "GET", data.callback, data.param);
                res=get(data.url+"?"+request.ToString(), header);
                if(res.IsSuccessStatusCode==true) {
                    return res;
                }
            }
            return res;
        }

        public HttpResponseMessage delete(AccountKey key, HttpData data) {
            List<AccountKey> keys=new List<AccountKey>();
            keys.Add(key);
            return delete(keys, data);
        }

        public HttpResponseMessage delete(List<AccountKey> keys, HttpData data) {
            StringBuilder request=new StringBuilder();
            foreach(KeyValuePair<string, string> v in data.param) {
                if(request.Length>0) {
                    request.Append('&');
                }
                request.Append(v.Key);
                request.Append('=');
                request.Append(CsjtterUtil.urlEncode(v.Value));
            }
            HttpResponseMessage res=null;
            foreach(AccountKey key in keys) {
                string header=this.makeHeader(key, data.url, "DELETE", data.callback, data.param);
                res=delete(data.url+"?"+request.ToString(), header);
                if(res.IsSuccessStatusCode==true) {
                    return res;
                }
            }
            return res;
        }

        private HttpResponseMessage post(string url, string header, MultipartFormDataContent content) {
            client.Timeout=TimeSpan.FromSeconds(config.timeout);
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Csjtter");
            client.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("OAuth","oauth_consumer_key=\"wlMDRIfgvs1Oc2i1e52GFJqRr\", oauth_nonce=\"72d763acee509a91f8febc1003e6bca5\", oauth_signature=\"TZAGNq4bD5hcfY1Q1tuUiF7G2ak%3D\", oauth_signature_method=\"HMAC-SHA1\", oauth_timestamp=\"1405889128\", oauth_token=\"262154677-mQE2XYJpn4TOFhvCcNyoFAZxDb1u4sCbgFemNXPs\", oauth_version=\"1.0\"");
            if(config.isLog>1) {
                Console.Out.WriteLine("request header");
                Console.Out.WriteLine(client.DefaultRequestHeaders.ToString());
            }
            return client.PostAsync(url,content).Result;
        }

        private HttpResponseMessage get(string url, string header) {
            client.Timeout=TimeSpan.FromSeconds(config.timeout);
            client.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("OAuth", header);
            return client.GetAsync(url).Result;
        }

        private HttpResponseMessage delete(string url, string header) {
            client.Timeout=TimeSpan.FromSeconds(config.timeout);
            HttpRequestMessage mes=new HttpRequestMessage(HttpMethod.Delete, url);
            mes.Headers.Add("Authorization", header);
            return client.SendAsync(mes).Result;
        }
    }
}
