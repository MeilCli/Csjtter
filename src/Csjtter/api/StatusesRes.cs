using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csjtter.api {
    public interface StatusesRes {
        Status statusesUpdate(string status, Dictionary<string, string> param=null);
    }
}
