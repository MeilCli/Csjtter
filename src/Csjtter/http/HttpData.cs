using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csjtter.http {
    public class HttpData {
        public string url { set; get; }
        private Dictionary<string, string> _param;
        public Dictionary<string, string> param {
            set {
                _param=value;
            }
            get {
                if(_param!=null) {
                    return _param;
                } else {
                    return new Dictionary<string, string>();
                }
            }
        }
        private Dictionary<string, string> _fparam;
        //fileName/filepass
        public Dictionary<string, string> fparam {
            set {
                _fparam=value;
            }
            get {
                if(_fparam!=null) {
                    return _fparam;
                } else {
                    return new Dictionary<string, string>();
                }
            }
        }
        public string callback { set; get; }
    }
}
