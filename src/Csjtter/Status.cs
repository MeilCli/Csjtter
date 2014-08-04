using Csjtter.json;
using Newtonsoft.Json.Linq;

namespace Csjtter {
    public class Status {

        public string createdAt { private set; get; }
        /// <summary>
        /// tweet id which user's retweet 
        /// </summary>
        public long currentUserRetweetId { private set; get; }
        public HashtagEntity[] hashtags { private set; get; }
        public SymbolEntity[] symbols { private set; get; }
        public UrlEntity[] urls { private set; get; }
        public MediaEntity[] media { private set; get; }
        public MediaEntity[] extendedMedia { private set; get; }
        public UserMentionEntity[] userMentions { private set; get; }
        public int favoriteCount { private set; get; }
        public int retweetCount { private set; get; }
        public bool isFavoriteByMe { private set; get; }
        public bool isRetweetByMe { private set; get; }
        public long id { private set; get; }
        public string inReplyToScreenName { private set; get; }
        public long inReplyToStatusId { private set; get; }
        public long inReplyToUserId { private set; get; }
        public string lang { private set; get; }
        public Status retweetedStatus { private set; get; }
        public string source { private set; get; }
        public string text { private set; get; }
        public User user { private set; get; }

        public Status(string obj) {
            init(new JsonObject(JObject.Parse(obj)));
        }

        public Status(JsonObject obj) {
            init(obj);
        }

        private void init(JsonObject obj) {
            createdAt=obj.getString("created_at");
            if(obj.containsKey("current_user_retweet")) {
                currentUserRetweetId=obj.getJsonObject("current_user_retweet").getLong("id");
            }
            if(obj.containsKey("entities")) {
                JsonObject entity=obj.getJsonObject("entities");
                if(entity.containsKey("hashtags")) {
                    JsonArray ar=entity.getJsonArray("hashtags");
                    hashtags=new HashtagEntity[ar.count()];
                    for(int i=0; i<ar.count(); i++) {
                        hashtags[i]=new HashtagEntity(ar.getJsonObject(i));
                    }
                }
                if(entity.containsKey("symbols")) {
                    JsonArray ar=entity.getJsonArray("symbols");
                    symbols=new SymbolEntity[ar.count()];
                    for(int i=0; i<ar.count(); i++) {
                        symbols[i]=new SymbolEntity(ar.getJsonObject(i));
                    }
                }
                if(entity.containsKey("urls")) {
                    JsonArray ar=entity.getJsonArray("urls");
                    urls=new UrlEntity[ar.count()];
                    for(int i=0; i<ar.count(); i++) {
                        urls[i]=new UrlEntity(ar.getJsonObject(i));
                    }
                }
                if(entity.containsKey("media")) {
                    JsonArray ar=entity.getJsonArray("media");
                    media=new MediaEntity[ar.count()];
                    for(int i=0; i<ar.count(); i++) {
                        media[i]=new MediaEntity(ar.getJsonObject(i));
                    }
                }
                if(entity.containsKey("user_mentions")) {
                    JsonArray ar=entity.getJsonArray("user_mentions");
                    userMentions=new UserMentionEntity[ar.count()];
                    for(int i=0; i<ar.count(); i++) {
                        userMentions[i]=new UserMentionEntity(ar.getJsonObject(i));
                    }
                }
            }
            if(obj.containsKey("extended_entities")) {
                JsonObject entity=obj.getJsonObject("extended_entities");
                if(entity.containsKey("media")) {
                    JsonArray ar=entity.getJsonArray("media");
                    extendedMedia=new MediaEntity[ar.count()];
                    for(int i=0; i<ar.count(); i++) {
                        extendedMedia[i]=new MediaEntity(ar.getJsonObject(i));
                    }
                }
            }
            favoriteCount=obj.getInt("favorite_count");
            retweetCount=obj.getInt("retweet_count");
            isFavoriteByMe=obj.getBoolean("favorited");
            isRetweetByMe=obj.getBoolean("retweeted");
            id=obj.getLong("id");
            inReplyToScreenName=obj.getString("in_reply_to_screen_name", null);
            inReplyToStatusId=obj.getLong("in_reply_to_status_id", -1);
            inReplyToUserId=obj.getLong("in_reply_to_user_id", -1);
            lang=obj.getString("lang", null);
            if(obj.containsKey("retweeted_status")) {
                retweetedStatus=new Status(obj.getJsonObject("retweeted_status"));
            }
            source=obj.getString("source");
            text = obj.getString("text");
            if(obj.containsKey("user")) {
                user=new User(obj.getJsonObject("user"));
            }
        }

        public override bool Equals(object obj) {
            if(obj==null) {
                return false;
            }
            Status status=obj as Status;
            if(status==null) {
                return false;
            }
            return id==status.id;
        }

        public bool Equals(Status status) {
            if(status==null) {
                return false;
            }
            return id==status.id;
        }
    }
}
