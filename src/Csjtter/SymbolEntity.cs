using Csjtter.json;

namespace Csjtter {
    public class SymbolEntity : Entity {

        public string text { private set; get; }

        public SymbolEntity(JsonObject obj)
            : base(obj) {
            text=obj.getString("text");
        }
    }
}
