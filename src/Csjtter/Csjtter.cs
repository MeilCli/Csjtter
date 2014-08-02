using Csjtter.api;
using Csjtter.http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Csjtter {
    public class Csjtter : CsjtterBase, APIRes {
        public Csjtter(AccountKey key, CsjtterConfig config) : base(key, config) { }

        protected Status toStatus(HttpResponseMessage res) {
            return new Status(res.Content.ReadAsStringAsync().Result);
        }

        public Status statusesUpdate(string status, Dictionary<string, string> param=null) {
            HttpData data=new HttpData();
            data.url=config.baseRestURL+APIConstant.statuses_update;
            data.param=param??new Dictionary<string, string>();
            data.param.Add("status", status);
            HttpResponseMessage res=http.post(key, data);
            checkErrorAndThrow(res);
            return toStatus(res);
        }
    }
}
