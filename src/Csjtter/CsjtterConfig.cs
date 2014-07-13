using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csjtter {
    public class CsjtterConfig {
        private string _authorizeURL = "https://api.twitter.com/oauth/authorize";
        public string authorizeURL {
            set { _authorizeURL = value; }
            get { return _authorizeURL; }
        }
    }
}
