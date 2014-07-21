using Csjtter.api;
using Csjtter.http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Csjtter {
    public class Csjtter:CsjtterBase,APIRes {
        public Csjtter(AccountKey key, CsjtterConfig config) : base(key, config) { }

        public void statusesUpdate(string status) {
            HttpData data=new HttpData();
            data.url=config.baseRestURL+APIConstant.statuses_update;
            data.param=new Dictionary<string, string>() { { "status", status } };
            HttpResponseMessage res=http.post(key, data);
            CsjtterException exception=checkError(res);
            if(exception!=null) {
                Console.Out.WriteLine("request message");
                Console.Out.WriteLine(res.RequestMessage.Content.ToString()+res.RequestMessage.Content.ReadAsStringAsync().Result);
                throw exception;
            }
        }
    }
}
