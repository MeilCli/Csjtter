using Csjtter.json;
using System.Collections.Generic;

namespace Csjtter {
    public class SearchResult {

        public List<Status> statuses { private set; get; }
        public long maxId { private set; get; }
        public long sinceId { private set; get; }
        public string refreshUrl { private set; get; }
        public string nextResults { private set; get; }
        public string query { private set; get; }
        public int count { private set; get; }
        public float completedIn { private set; get; }

        public SearchResult(JsonObject obj) {
            if(obj.containsKey("statuses")) {
                JsonArray ar = obj.getJsonArray("statuses");
                statuses = new List<Status>(ar.count());
                for(int i = 0; i < ar.count(); i++) {
                    statuses.Add(new Status(ar.getJsonObject(i)));
                }
            } else if(CsjtterConfig.isTest == true) {
                System.Console.Out.WriteLine("SearchResult null field statuses");
            }
            if(obj.containsKey("search_metadata")) {
                JsonObject data = obj.getJsonObject("search_metadata");
                maxId = data.getLong("max_id");
                sinceId = data.getLong("since_id");
                refreshUrl = data.getString("refresh_url");
                nextResults = data.getString("next_results");
                query = data.getString("query");
                count = data.getInt("count");
                completedIn = data.getFloat("completed_in");
            } else if(CsjtterConfig.isTest == true) {
                System.Console.Out.WriteLine("SearchResult null field search_metadata");
            }
        }
    }
}
