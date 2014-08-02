using Csjtter.json;

namespace Csjtter {
    public class PhotoConfig {

        public int h { private set; get; }
        public int w { private set; get; }
        public string resize { private set; get; }

        public PhotoConfig(JsonObject obj) {
            h=obj.getInt("h");
            w=obj.getInt("w");
            resize=obj.getString("resize");
        }
    }
}
