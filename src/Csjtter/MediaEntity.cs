using Csjtter.json;

namespace Csjtter {
    public class MediaEntity : UrlEntity {

        public long id { private set; get; }
        public string mediaUrl { private set; get; }
        public string mediaUrlHttps { private set; get; }
        public long sourceStatusId { private set; get; }
        public string type { private set; get; }
        public PhotoSize size { private set; get; }

        public MediaEntity(JsonObject obj)
            : base(obj) {
            id=obj.getLong("id");
            mediaUrl=obj.getString("media_url");
            mediaUrlHttps=obj.getString("media_url_https");
            sourceStatusId=obj.getLong("source_status_id");
            type=obj.getString("type");
            if(obj.containsKey("sizes")) {
                size=new PhotoSize(obj.getJsonObject("sizes"));
            } else if(CsjtterConfig.isTest==true) {
                System.Console.Out.WriteLine("MediaEntity null field sizes");
            }
        }
    }
}
