using Csjtter.json;

namespace Csjtter {
    public class OembedTweet {

        public string html { private set; get; }
        public string authorUrl { private set; get; }
        public string authorName { private set; get; }
        public string providerUrl { private set; get; }
        public string providerName { private set; get; }
        public string url { private set; get; }
        public string version { private set; get; }
        public string type { private set; get; }
        public string cacheAge { private set; get; }
        public int height { private set; get; }
        public int width { private set; get; }

        public OembedTweet(JsonObject obj) {
            html = obj.getString("html");
            authorUrl = obj.getString("author_url");
            authorName = obj.getString("author_name");
            providerUrl = obj.getString("provider_url");
            providerName = obj.getString("provider_name");
            url = obj.getString("url");
            version = obj.getString("version");
            type = obj.getString("type");
            cacheAge = obj.getString("cache_age");
            height = obj.getInt("height", -1);
            width = obj.getInt("width");
        }
    }
}
