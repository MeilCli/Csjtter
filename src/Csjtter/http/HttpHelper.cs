using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace Csjtter.http {
    public class HttpHelper {
        HttpClient client;
        CsjtterConfig config;
        public HttpHelper(CsjtterConfig config) {
            client = new HttpClient();
            this.config = config;
        }

        public HttpResponseMessage post(string url,string header,MultipartFormDataContent content) {
            client.Timeout = TimeSpan.FromMilliseconds(config.timeout);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(header);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("gzip, deflate"));
            return client.PostAsync(url,content).Result;
        }

        public HttpResponseMessage get(string url,string header) {
            client.Timeout = TimeSpan.FromMilliseconds(config.timeout);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(header);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("gzip, deflate"));
            return client.GetAsync(url).Result;
        }

        public HttpResponseMessage delete(string url,string header) {
            client.Timeout = TimeSpan.FromMilliseconds(config.timeout);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(header);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("gzip, deflate"));
            return client.DeleteAsync(url).Result;
        }
    }
}
