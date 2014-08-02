using Csjtter.json;

namespace Csjtter {
    public class UserMentionEntity : Entity {

        public long id { private set; get; }
        public string name { private set; get; }
        public string screenName { private set; get; }

        public UserMentionEntity(JsonObject obj)
            : base(obj) {
            id=obj.getLong("id");
            name=obj.getString("name");
            screenName=obj.getString("screen_name");
        }
    }
}
