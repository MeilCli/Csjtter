using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csjtter {
    public class CsjtterConfig {
        private string _authorizeURL="https://api.twitter.com/oauth/authorize";
        public string authorizeURL {
            set { _authorizeURL=value; }
            get { return _authorizeURL; }
        }

        private string _requestTokenURL="https://api.twitter.com/oauth/request_token";
        public string requestTokenURL {
            set { _requestTokenURL=value; }
            get { return _requestTokenURL; }
        }

        private string _oauthTokenURL="https://api.twitter.com/oauth/access_token";
        public string oauthToknURL {
            set { _oauthTokenURL=value; }
            get { return _oauthTokenURL; }
        }

        private int _timeout=10;
        /// <summary>
        /// second
        /// </summary>
        public int timeout {
            set {
                if(value>0) { 
                    _timeout=value;
                } 
            }
            get { return _timeout; }
        }

        private bool _include_entities=true;
        public bool include_entities {
            set { _include_entities=value; }
            get { return _include_entities; }
        }

        /// <summary>
        /// isLog>0 = echo request
        /// </summary>
        public int isLog {
            set;
            get;
        }
    }
}
