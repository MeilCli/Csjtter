using Csjtter.json;

namespace Csjtter {
    public class HashtagEntity : Entity {

        public string text { private set; get; }

        public HashtagEntity(JsonObject obj)
            : base(obj) {
            text=obj.getString("text");
        }
    }
}
