using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csjtter.api {
    public interface FriendshipsRes {
        long[] friendshipsNoRetweetsIDs();
        IDs friendshipsIncoming(long cursor = -1);
        IDs friendshipsOutgoing(long cursor = -1);
    }
}
