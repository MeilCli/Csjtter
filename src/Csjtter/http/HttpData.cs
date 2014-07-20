using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csjtter.http {
    public class HttpData {
        public string url { set; get; }
        private static Dictionary<string, string> null_param=new Dictionary<string, string>();
        private Dictionary<string, string> _param=null_param;
        public Dictionary<string, string> param {
            set {
                if(value!=null) {
                    _param=value;
                }
            }
            get {
                return _param;
            }
        }
        private Dictionary<string, string> _fparam=null_param;
        //fileName/filepass
        public Dictionary<string, string> fparam {
            set {
                if(value!=null) {
                    _fparam=value;
                }
            }
            get {
                return _fparam;
            }
        }
        public string callback { set; get; }
    }
}
