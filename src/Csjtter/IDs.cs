using Csjtter.json;

namespace Csjtter {
    public class IDs {

        public long[] ids { private set; get; }
        public long previousCursor { private set; get; }
        public long nextCursor { private set; get; }

        public IDs(JsonObject obj) {
            if(obj.containsKey("ids")) {
                JsonArray ar = obj.getJsonArray("ids");
                ids = new long[ar.count()];
                for(int i = 0; i < ar.count(); i++) {
                    ids[i] = ar.getLong(i);
                }
            } else if(CsjtterConfig.isTest == true) {
                System.Console.Out.WriteLine("IDs null field ids");
            }
            previousCursor = obj.getLong("previous_cursor");
            nextCursor = obj.getLong("next_cursor");
        }
    }
}