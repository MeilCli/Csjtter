using Csjtter.api;
using Csjtter.http;
using Csjtter.json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Csjtter {
    public class Csjtter : CsjtterBase,APIRes {
        public Csjtter(AccountKey key,CsjtterConfig config) : base(key,config) { }

        protected Status toStatus(HttpResponseMessage res) {
            return new Status(res.Content.ReadAsStringAsync().Result);
        }

        protected List<Status> toStatusList(HttpResponseMessage res) {
            List<Status> list = new List<Status>();
            JsonArray ar = new JsonArray(res.Content.ReadAsStringAsync().Result);
            for (int i = 0;i < ar.count();i++) {
                list.Add(new Status(ar.getJsonObject(i)));
            }
            return list;
        }

        public List<Status> statusesHomeTimeline(Dictionary<string,string> param = null) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.statuses_home_timeline);
            data.param = param ?? new Dictionary<string,string>();
            HttpResponseMessage res = http.get(key,data);
            checkErrorAndThrow(res);
            return toStatusList(res);
        }

        public List<Status> statusesMentionsTimeline(Dictionary<string,string> param = null) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.statuses_mentions_timeline);
            data.param = param ?? new Dictionary<string,string>();
            HttpResponseMessage res = http.get(key,data);
            checkErrorAndThrow(res);
            return toStatusList(res);
        }

        public List<Status> statusesUserTimeline(Dictionary<string,string> param = null) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.statuses_user_timeline);
            data.param = param ?? new Dictionary<string,string>();
            HttpResponseMessage res = http.get(key,data);
            checkErrorAndThrow(res);
            return toStatusList(res);
        }

        public List<Status> statusesRetweetsOfMe(Dictionary<string,string> param = null) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.statuses_retweets_of_me);
            data.param = param ?? new Dictionary<string,string>();
            HttpResponseMessage res = http.get(key,data);
            checkErrorAndThrow(res);
            return toStatusList(res);
        }

        public List<Status> statusesRetweets(long id,Dictionary<string,string> param = null) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.statuses_retweets+id+".json");
            data.param = param ?? new Dictionary<string,string>();
            HttpResponseMessage res = http.get(key,data);
            checkErrorAndThrow(res);
            return toStatusList(res);
        }

        public Status statusesUpdate(string status,Dictionary<string,string> param = null) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.statuses_update);
            data.param = param ?? new Dictionary<string,string>();
            data.param.Add("status",status);
            HttpResponseMessage res = http.post(key,data);
            checkErrorAndThrow(res);
            return toStatus(res);
        }

        public Status statusesDestroy(long id,Dictionary<string,string> param = null) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.statuses_destroy+id+".json");
            data.param = param ?? new Dictionary<string,string>();
            data.param.Add("id",""+id);
            HttpResponseMessage res = http.post(key,data);
            checkErrorAndThrow(res);
            return toStatus(res);
        }

        public Status statusesRetweet(long id,Dictionary<string,string> param = null) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.statuses_retweet + id + ".json");
            data.param = param ?? new Dictionary<string,string>();
            data.param.Add("id","" + id);
            HttpResponseMessage res = http.post(key,data);
            checkErrorAndThrow(res);
            return toStatus(res);
        }

        public Status favoritesCreate(long id,Dictionary<string,string> param = null) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.favorites_create);
            data.param = param ?? new Dictionary<string,string>();
            data.param.Add("id","" + id);
            HttpResponseMessage res = http.post(key,data);
            checkErrorAndThrow(res);
            return toStatus(res);
        }
    }
}
