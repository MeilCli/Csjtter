using Csjtter.json;

namespace Csjtter {
    public class PhotoSize {

        public PhotoConfig thumb { private set; get; }
        public PhotoConfig small { private set; get; }
        public PhotoConfig medium { private set; get; }
        public PhotoConfig large { private set; get; }

        public PhotoSize(JsonObject obj) {
            if(obj.containsKey("thumb")) {
                thumb=new PhotoConfig(obj.getJsonObject("thumb"));
            } else if(CsjtterConfig.isTest==true) {
                System.Console.Out.WriteLine("PhotoSize null field thumb");
            }
            if(obj.containsKey("small")) {
                thumb=new PhotoConfig(obj.getJsonObject("small"));
            } else if(CsjtterConfig.isTest==true) {
                System.Console.Out.WriteLine("PhotoSize null field small");
            }
            if(obj.containsKey("medium")) {
                thumb=new PhotoConfig(obj.getJsonObject("medium"));
            } else if(CsjtterConfig.isTest==true) {
                System.Console.Out.WriteLine("PhotoSize null field medium");
            }
            if(obj.containsKey("large")) {
                thumb=new PhotoConfig(obj.getJsonObject("large"));
            } else if(CsjtterConfig.isTest==true) {
                System.Console.Out.WriteLine("PhotoSize null field large");
            }
        }
    }
}
