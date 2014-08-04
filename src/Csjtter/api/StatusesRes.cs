using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csjtter.api {
    public interface StatusesRes {
        List<Status> statusesHomeTimeline(Dictionary<string,string> param = null);
        List<Status> statusesMentionsTimeline(Dictionary<string,string> param = null);
        List<Status> statusesUserTimeline(Dictionary<string,string> param = null);
        List<Status> statusesRetweetsOfMe(Dictionary<string,string> param = null);
        List<Status> statusesRetweets(long id,Dictionary<string,string> param = null);
        Status statusesUpdate(string status,Dictionary<string,string> param = null);
        Status statusesDestroy(long id,Dictionary<string,string> param = null);
        Status statusesRetweet(long id,Dictionary<string,string> param = null);
    }
}
