using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csjtter.src.Csjtter {
    public class AccountData : AccountKey {
        public string name { private set; get; }
        public string screenName { private set; get; }
        public long userId { private set; get; }
        public AccountData(AccountKey key,string name,string screenName,long userId)
            : base(key.consumerKey,key.consumerSecret,key.accessToken,key.accessTokenSecret) {
            this.name = name;
            this.screenName = screenName;
            this.userId = userId;
        }
    }
}
