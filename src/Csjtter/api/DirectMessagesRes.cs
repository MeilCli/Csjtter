using System.Collections.Generic;

namespace Csjtter.api {
    public interface DirectMessagesRes {
        List<DirectMessage> directMessages(Dictionary<string, string> param = null);
        List<DirectMessage> directMessagesSent(Dictionary<string, string> param = null);
        DirectMessage directMessagesShow(long id);
        DirectMessage directMessagesDestroy(long id);
        DirectMessage directMessagesNew(string text, long user_id);
        DirectMessage directMessagesNew(string text, string screen_name);
    }
}
