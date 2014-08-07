using Csjtter.json;

namespace Csjtter {
    public class DirectMessage {

        public string createdAt { private set; get; }
        public HashtagEntity[] hashtags { private set; get; }
        public SymbolEntity[] symbols { private set; get; }
        public UrlEntity[] urls { private set; get; }
        public MediaEntity[] media { private set; get; }
        public MediaEntity[] extendedMedia { private set; get; }
        public UserMentionEntity[] userMentions { private set; get; }
        public long id { private set; get; }
        public User recipient { private set; get; }
        public long recipientId { private set; get; }
        public string recipientScreenName { private set; get; }
        public User sender { private set; get; }
        public long senderId { private set; get; }
        public string senderScreenName { private set; get; }
        public string text { private set; get; }

        public DirectMessage(JsonObject obj) {
            createdAt = obj.getString("created_at");
            if(obj.containsKey("entities")) {
                JsonObject entity = obj.getJsonObject("entities");
                if(entity.containsKey("hashtags")) {
                    JsonArray ar = entity.getJsonArray("hashtags");
                    hashtags = new HashtagEntity[ar.count()];
                    for(int i = 0; i < ar.count(); i++) {
                        hashtags[i] = new HashtagEntity(ar.getJsonObject(i));
                    }
                }
                if(entity.containsKey("symbols")) {
                    JsonArray ar = entity.getJsonArray("symbols");
                    symbols = new SymbolEntity[ar.count()];
                    for(int i = 0; i < ar.count(); i++) {
                        symbols[i] = new SymbolEntity(ar.getJsonObject(i));
                    }
                }
                if(entity.containsKey("urls")) {
                    JsonArray ar = entity.getJsonArray("urls");
                    urls = new UrlEntity[ar.count()];
                    for(int i = 0; i < ar.count(); i++) {
                        urls[i] = new UrlEntity(ar.getJsonObject(i));
                    }
                }
                if(entity.containsKey("media")) {
                    JsonArray ar = entity.getJsonArray("media");
                    media = new MediaEntity[ar.count()];
                    for(int i = 0; i < ar.count(); i++) {
                        media[i] = new MediaEntity(ar.getJsonObject(i));
                    }
                }
                if(entity.containsKey("user_mentions")) {
                    JsonArray ar = entity.getJsonArray("user_mentions");
                    userMentions = new UserMentionEntity[ar.count()];
                    for(int i = 0; i < ar.count(); i++) {
                        userMentions[i] = new UserMentionEntity(ar.getJsonObject(i));
                    }
                }
            }
            if(obj.containsKey("extended_entities")) {
                JsonObject entity = obj.getJsonObject("extended_entities");
                if(entity.containsKey("media")) {
                    JsonArray ar = entity.getJsonArray("media");
                    extendedMedia = new MediaEntity[ar.count()];
                    for(int i = 0; i < ar.count(); i++) {
                        extendedMedia[i] = new MediaEntity(ar.getJsonObject(i));
                    }
                }
            }
            id = obj.getLong("id");
            if(obj.containsKey("recipient")) {
                recipient = new User(obj.getJsonObject("recipient"));
            } else if(CsjtterConfig.isTest == true) {
                System.Console.Out.WriteLine("DirectMessage null field recipient");
            }
            recipientId = obj.getLong("recipient_id");
            recipientScreenName = obj.getString("recipient_screen_name");
            if(obj.containsKey("sender")) {
                sender = new User(obj.getJsonObject("sender"));
            } else if(CsjtterConfig.isTest == true) {
                System.Console.Out.WriteLine("DirectMessage null field sender");
            }
            senderId = obj.getLong("sender_id");
            senderScreenName = obj.getString("sender_screen_name");
            text = obj.getString("text");
        }
    }
}
