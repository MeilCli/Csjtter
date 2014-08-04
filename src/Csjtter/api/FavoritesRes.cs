using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csjtter.api {
    public interface FavoritesRes {
        Status favoritesCreate(long id,Dictionary<string,string> param = null);
    }
}
