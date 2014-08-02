using Csjtter.json;
using Newtonsoft.Json.Linq;

namespace Csjtter {
    public class User {

        public string createdAt { private set; get; }
        public bool isDefaultProfile { private set; get; }
        public bool isDefaultProfileImage { private set; get; }
        public string description { private set; get; }
        public UrlEntity[] urls { private set; get; }
        public UrlEntity[] descriptionUrls { private set; get; }
        public int favoriteCount { private set; get; }
        public int statusCount { private set; get; }
        public int friendCount { private set; get; }
        public int followerCount { private set; get; }
        public int listedCount { private set; get; }
        public bool isFollowRequestSent { private set; get; }
        /// <summary>
        /// Deprecated
        /// </summary>
        public bool isFollowing { private set; get; }
        public bool isGeoEnable { private set; get; }
        public long id { private set; get; }
        public string lang { private set; get; }
        public string location { private set; get; }
        public string name { private set; get; }
        public string screenName { private set; get; }
        public string profileBackgroundColor { private set; get; }
        public string profileBackgroundImage { private set; get; }
        public string profileBackgroundImageHttps { private set; get; }
        public string profileBanner { private set; get; }
        public string profileImage { private set; get; }
        public string profileImageHttps { private set; get; }
        public bool isUseProfileBackgroundImage { private set; get; }
        public bool isProtected { private set; get; }
        public Status status { private set; get; }
        public string timeZone { private set; get; }
        public string url { private set; get; }
        public bool isVerified { private set; get; }

        public User(string obj) {
            init(new JsonObject(JObject.Parse(obj)));
        }

        public User(JsonObject obj) {
            init(obj);
        }

        private void init(JsonObject obj) {
            createdAt=obj.getString("created_at");
            isDefaultProfile=obj.getBoolean("default_profile");
            isDefaultProfileImage=obj.getBoolean("default_profile_image");
            description=obj.getString("description");
            if(obj.containsKey("entities")) {
                JsonObject entity=obj.getJsonObject("entities");
                if(entity.containsKey("url")) {
                    JsonObject urlObject=entity.getJsonObject("url");
                    if(urlObject.containsKey("urls")) {
                        JsonArray ar=urlObject.getJsonArray("urls");
                        urls=new UrlEntity[ar.count()];
                        for(int i=0; i<ar.count(); i++) {
                            urls[i]=new UrlEntity(ar.getJsonObject(i));
                        }
                    } else if(CsjtterConfig.isTest==true) {
                        System.Console.Out.WriteLine("User#init null field urls in url");
                    }
                }
                if(entity.containsKey("description")) {
                    JsonObject urlObject=entity.getJsonObject("description");
                    if(urlObject.containsKey("urls")) {
                        JsonArray ar=urlObject.getJsonArray("urls");
                        descriptionUrls=new UrlEntity[ar.count()];
                        for(int i=0; i<ar.count(); i++) {
                            descriptionUrls[i]=new UrlEntity(ar.getJsonObject(i));
                        }
                    } else if(CsjtterConfig.isTest==true) {
                        System.Console.Out.WriteLine("User#init null field urls in description");
                    }
                }
            }
            favoriteCount=obj.getInt("favourites_count");
            statusCount=obj.getInt("statuses_count");
            friendCount=obj.getInt("friends_count");
            followerCount=obj.getInt("followers_count");
            listedCount=obj.getInt("listed_count");
            isFollowRequestSent=obj.getBoolean("follow_request_sent");
            isFollowing=obj.getBoolean("following");
            isGeoEnable=obj.getBoolean("geo_enabled");
            id=obj.getLong("id");
            lang=obj.getString("lang");
            location=obj.getString("location");
            name=obj.getString("name");
            screenName=obj.getString("screen_name");
            profileBackgroundColor=obj.getString("profile_background_color");
            profileBackgroundImage=obj.getString("profile_background_image_url");
            profileBackgroundImageHttps=obj.getString("profile_background_image_url_https");
            profileBanner=obj.getString("profile_banner_url");
            profileImage=obj.getString("profile_image_url");
            profileImageHttps=obj.getString("profile_image_url_https");
            isUseProfileBackgroundImage=obj.getBoolean("profile_use_background_image");
            isProtected=obj.getBoolean("protected");
            if(obj.containsKey("status")) {
                status=new Status(obj.getJsonObject("status"));
            }
            timeZone=obj.getString("time_zone", null);
            url=obj.getString("url");
            isVerified=obj.getBoolean("verified");
        }

        public override bool Equals(object obj) {
            if(obj==null) {
                return false;
            }
            User user=obj as User;
            if(user==null) {
                return false;
            }
            return id==user.id;
        }

        public bool Equals(User user) {
            if(user==null) {
                return false;
            }
            return id==user.id;
        }
    }
}
