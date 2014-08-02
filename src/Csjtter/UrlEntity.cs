using Csjtter.json;

namespace Csjtter {
    public class UrlEntity : Entity {

        public string url { private set; get; }
        public string displayUrl { private set; get; }
        public string expandedUrl { private set; get; }

        public UrlEntity(JsonObject obj)
            : base(obj) {
            url=obj.getString("url");
            displayUrl=obj.getString("display_url");
            expandedUrl=obj.getString("expanded_url");
        }
    }
}
