using Csjtter.api;
using Csjtter.http;
using Csjtter.json;
using Csjtter.util;
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

        protected List<Status> toStatusList(HttpResponseMessage res) {
            List<Status> list = new List<Status>();
            JsonArray ar = new JsonArray(res.Content.ReadAsStringAsync().Result);
            for(int i = 0; i < ar.count(); i++) {
                list.Add(new Status(ar.getJsonObject(i)));
            }
            return list;
        }

        protected OembedTweet toOembedTweet(HttpResponseMessage res) {
            return new OembedTweet(new JsonObject(res.Content.ReadAsStringAsync().Result));
        }

        protected IDs toIDs(HttpResponseMessage res) {
            return new IDs(new JsonObject(res.Content.ReadAsStringAsync().Result));
        }

        protected SearchResult toSearchResult(HttpResponseMessage res) {
            return new SearchResult(new JsonObject(res.Content.ReadAsStringAsync().Result));
        }

        protected DirectMessage toDirectMessage(HttpResponseMessage res) {
            return new DirectMessage(new JsonObject(res.Content.ReadAsStringAsync().Result));
        }

        protected List<DirectMessage> toDirectMessageList(HttpResponseMessage res) {
            List<DirectMessage> list = new List<DirectMessage>();
            JsonArray ar = new JsonArray(res.Content.ReadAsStringAsync().Result);
            for(int i = 0; i < ar.count(); i++) {
                list.Add(new DirectMessage(ar.getJsonObject(i)));
            }
            return list;
        }

        protected long[] toLongArray(HttpResponseMessage res) {
            JsonArray ar = new JsonArray(res.Content.ReadAsStringAsync().Result);
            long[] ls = new long[ar.count()];
            for(int i = 0; i < ar.count(); i++) {
                ls[i] = ar.getLong(i);
            }
            return ls;
        }

        protected User toUser(HttpResponseMessage res) {
            return new User(new JsonObject(res.Content.ReadAsStringAsync().Result));
        }

        protected List<User> toUserList(HttpResponseMessage res) {
            List<User> list = new List<User>();
            JsonArray ar = new JsonArray(res.Content.ReadAsStringAsync().Result);
            for(int i = 0; i < ar.count(); i++) {
                list.Add(new User(ar.getJsonObject(i)));
            }
            return list;
        }

        public List<Status> statusesHomeTimeline(Dictionary<string, string> param = null) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.statuses_home_timeline);
            data.param = param ?? new Dictionary<string, string>();
            HttpResponseMessage res = http.get(key, data);
            checkErrorAndThrow(res);
            return toStatusList(res);
        }

        public List<Status> statusesMentionsTimeline(Dictionary<string, string> param = null) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.statuses_mentions_timeline);
            data.param = param ?? new Dictionary<string, string>();
            HttpResponseMessage res = http.get(key, data);
            checkErrorAndThrow(res);
            return toStatusList(res);
        }

        public List<Status> statusesUserTimeline(Dictionary<string, string> param = null) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.statuses_user_timeline);
            data.param = param ?? new Dictionary<string, string>();
            HttpResponseMessage res = http.get(key, data);
            checkErrorAndThrow(res);
            return toStatusList(res);
        }

        public List<Status> statusesRetweetsOfMe(Dictionary<string, string> param = null) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.statuses_retweets_of_me);
            data.param = param ?? new Dictionary<string, string>();
            HttpResponseMessage res = http.get(key, data);
            checkErrorAndThrow(res);
            return toStatusList(res);
        }

        public List<Status> statusesRetweets(long id, Dictionary<string, string> param = null) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.statuses_retweets + id + ".json");
            data.param = param ?? new Dictionary<string, string>();
            HttpResponseMessage res = http.get(key, data);
            checkErrorAndThrow(res);
            return toStatusList(res);
        }

        public Status statusesUpdate(string status, Dictionary<string, string> param = null) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.statuses_update);
            data.param = param ?? new Dictionary<string, string>();
            data.param.Add("status", status);
            HttpResponseMessage res = http.post(key, data);
            checkErrorAndThrow(res);
            return toStatus(res);
        }

        public Status statusesDestroy(long id, Dictionary<string, string> param = null) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.statuses_destroy + id + ".json");
            data.param = param ?? new Dictionary<string, string>();
            data.param.Add("id", "" + id);
            HttpResponseMessage res = http.post(key, data);
            checkErrorAndThrow(res);
            return toStatus(res);
        }

        public Status statusesRetweet(long id, Dictionary<string, string> param = null) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.statuses_retweet + id + ".json");
            data.param = param ?? new Dictionary<string, string>();
            data.param.Add("id", "" + id);
            HttpResponseMessage res = http.post(key, data);
            checkErrorAndThrow(res);
            return toStatus(res);
        }

        public Status statusesShow(long id, Dictionary<string, string> param = null) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.statuses_show);
            data.param = param ?? new Dictionary<string, string>();
            data.param.Add("id", "" + id);
            HttpResponseMessage res = http.get(key, data);
            checkErrorAndThrow(res);
            return toStatus(res);
        }

        public List<Status> statusesLookup(long[] id, Dictionary<string, string> param = null) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.statuses_lookup);
            data.param = param ?? new Dictionary<string, string>();
            data.param.Add("id", CsjtterUtil.toString(id));
            HttpResponseMessage res = http.get(key, data);
            checkErrorAndThrow(res);
            return toStatusList(res);
        }

        public OembedTweet statusesOembed(long id, Dictionary<string, string> param = null) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.statuses_oembed);
            data.param = param ?? new Dictionary<string, string>();
            data.param.Add("id", "" + id);
            HttpResponseMessage res = http.get(key, data);
            checkErrorAndThrow(res);
            return toOembedTweet(res);
        }

        public OembedTweet statusesOembed(string url, Dictionary<string, string> param = null) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.statuses_oembed);
            data.param = param ?? new Dictionary<string, string>();
            data.param.Add("url", url);
            HttpResponseMessage res = http.get(key, data);
            checkErrorAndThrow(res);
            return toOembedTweet(res);
        }

        public IDs statusesRetweetersIDs(long id, long cursor = -1) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.statuses_retweeters_ids);
            data.param = new Dictionary<string, string>();
            data.param.Add("id", "" + id);
            if(cursor != -1) {
                data.param.Add("cursor", "" + cursor);
            }
            HttpResponseMessage res = http.get(key, data);
            checkErrorAndThrow(res);
            return toIDs(res);
        }

        public SearchResult searchTweets(string q, Dictionary<string, string> param = null) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.search_tweets);
            data.param = param ?? new Dictionary<string, string>();
            data.param.Add("q", q);
            HttpResponseMessage res = http.get(key, data);
            checkErrorAndThrow(res);
            return toSearchResult(res);
        }

        public List<DirectMessage> directMessages(Dictionary<string, string> param = null) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.direct_messages);
            data.param = param ?? new Dictionary<string, string>();
            HttpResponseMessage res = http.get(key, data);
            checkErrorAndThrow(res);
            return toDirectMessageList(res);
        }

        public List<DirectMessage> directMessagesSent(Dictionary<string, string> param = null) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.direct_messages_sent);
            data.param = param ?? new Dictionary<string, string>();
            HttpResponseMessage res = http.get(key, data);
            checkErrorAndThrow(res);
            return toDirectMessageList(res);
        }

        public DirectMessage directMessagesShow(long id) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.direct_messages_show);
            data.param = new Dictionary<string, string>();
            data.param.Add("id", "" + id);
            HttpResponseMessage res = http.get(key, data);
            checkErrorAndThrow(res);
            return toDirectMessage(res);
        }

        public DirectMessage directMessagesDestroy(long id) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.direct_messages_destroy);
            data.param = new Dictionary<string, string>();
            data.param.Add("id", "" + id);
            HttpResponseMessage res = http.post(key, data);
            checkErrorAndThrow(res);
            return toDirectMessage(res);
        }

        public DirectMessage directMessagesNew(string text, long user_id) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.direct_messages_new);
            data.param = new Dictionary<string, string>();
            data.param.Add("text", text);
            data.param.Add("user_id", "" + user_id);
            HttpResponseMessage res = http.post(key, data);
            checkErrorAndThrow(res);
            return toDirectMessage(res);
        }

        public DirectMessage directMessagesNew(string text, string screen_name) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.direct_messages_new);
            data.param = new Dictionary<string, string>();
            data.param.Add("text", text);
            data.param.Add("screen_name", screen_name);
            HttpResponseMessage res = http.post(key, data);
            checkErrorAndThrow(res);
            return toDirectMessage(res);
        }

        public long[] friendshipsNoRetweetsIDs() {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.friendships_no_retweets_ids);
            data.param = new Dictionary<string, string>();
            HttpResponseMessage res = http.get(key, data);
            checkErrorAndThrow(res);
            return toLongArray(res);
        }

        public IDs friendshipsIncoming(long cursor = -1) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.friendships_incoming);
            data.param = new Dictionary<string, string>();
            if(cursor != -1) {
                data.param.Add("cursor", "" + cursor);
            }
            HttpResponseMessage res = http.get(key, data);
            checkErrorAndThrow(res);
            return toIDs(res);
        }

        public IDs friendshipsOutgoing(long cursor = -1) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.friendships_outgoing);
            data.param = new Dictionary<string, string>();
            if(cursor != -1) {
                data.param.Add("cursor", "" + cursor);
            }
            HttpResponseMessage res = http.get(key, data);
            checkErrorAndThrow(res);
            return toIDs(res);
        }

        public Status favoritesCreate(long id, Dictionary<string, string> param = null) {
            HttpData data = new HttpData(config.baseRestURL + APIConstant.favorites_create);
            data.param = param ?? new Dictionary<string, string>();
            data.param.Add("id", "" + id);
            HttpResponseMessage res = http.post(key, data);
            checkErrorAndThrow(res);
            return toStatus(res);
        }

    }
}
