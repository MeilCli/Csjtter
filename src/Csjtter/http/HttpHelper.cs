using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.IO;
using Csjtter.util;
using System.Net;


namespace Csjtter.http {
    internal class HttpHelper : Oauth {

        public HttpHelper(CsjtterConfig config)
            : base(config) {          
        }

        private HttpClient createHttpClient() {
            HttpClientHandler handler=new HttpClientHandler();
            if(handler.SupportsAutomaticDecompression==true) {
                handler.AutomaticDecompression=DecompressionMethods.GZip|DecompressionMethods.Deflate;
            }
            return new HttpClient(handler);
        }

        public HttpResponseMessage post(AccountKey key, HttpData data) {
            List<AccountKey> keys=new List<AccountKey>();
            keys.Add(key);
            return post(keys, data);
        }

        public HttpResponseMessage post(List<AccountKey> keys, HttpData data) {
            HttpContent content=null;
            if(data.fparam.Count==0) {
                content=new FormUrlEncodedContent(data.param);
            } else {
                MultipartFormDataContent con=new MultipartFormDataContent();
                if(data.param.Count>0) {
                    foreach(KeyValuePair<string, string> v in data.param) {
                        StringContent c=new StringContent(v.Value);
                        con.Add(c, v.Key);
                    }
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
                        con.Add(sc, "image", v.Key);
                    } catch(Exception) { }
                }
                content=con;
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

        private HttpResponseMessage post(string url, string header, HttpContent content) {
            HttpClient client=createHttpClient(); 
            client.Timeout=TimeSpan.FromSeconds(config.timeout);
            client.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("OAuth", header);
            return client.PostAsync(url, content).Result;
        }

        private HttpResponseMessage get(string url, string header) {
            HttpClient client=createHttpClient(); 
            client.Timeout=TimeSpan.FromSeconds(config.timeout);
            client.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("OAuth", header);
            return client.GetAsync(url).Result;
        }

        private HttpResponseMessage delete(string url, string header) {
            HttpClient client=createHttpClient(); 
            client.Timeout=TimeSpan.FromSeconds(config.timeout);
            client.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("OAuth", header);
            return client.DeleteAsync(url).Result;
        }
    }
}
