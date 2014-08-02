using Csjtter.json;

namespace Csjtter {
    public class Entity {

        public int start { private set; get; }
        public int end { private set; get; }

        public Entity(JsonObject obj) {
            JsonArray ar=obj.getJsonArray("indices");
            if(ar!=null) {
                start=ar.getInt(0);
                end=ar.getInt(1);
            }
        }
    }
}
