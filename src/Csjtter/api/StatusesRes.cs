using System.Collections.Generic;

namespace Csjtter.api {
    public interface StatusesRes {
        List<Status> statusesHomeTimeline(Dictionary<string, string> param = null);
        List<Status> statusesMentionsTimeline(Dictionary<string, string> param = null);
        List<Status> statusesUserTimeline(Dictionary<string, string> param = null);
        List<Status> statusesRetweetsOfMe(Dictionary<string, string> param = null);
        List<Status> statusesRetweets(long id, Dictionary<string, string> param = null);
        Status statusesUpdate(string status, Dictionary<string, string> param = null);
        Status statusesDestroy(long id, Dictionary<string, string> param = null);
        Status statusesRetweet(long id, Dictionary<string, string> param = null);
        Status statusesShow(long id, Dictionary<string, string> param = null);
        List<Status> statusesLookup(long[] id, Dictionary<string, string> param = null);
        OembedTweet statusesOembed(long id, Dictionary<string, string> param = null);
        OembedTweet statusesOembed(string url, Dictionary<string, string> param = null);
        IDs statusesRetweetersIDs(long id, long cursor = -1);
    }
}
