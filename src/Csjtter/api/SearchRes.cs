using System.Collections.Generic;

namespace Csjtter.api {
    public interface SearchRes {
        SearchResult searchTweets(string q, Dictionary<string, string> param = null);
    }
}
