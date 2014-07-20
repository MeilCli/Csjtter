using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csjtter {

    /// <summary>
    /// APIにアクセスするのに必要なKeyを保持するクラス
    /// </summary>
    public class AccountKey {
        public string consumerKey { private set; get; }
        public string consumerSecret { private set; get; }
        public string accessToken { internal set; get; }
        private string _accessTokenSecret="";
        public string accessTokenSecret {
            internal set {
                if(value!=null) {
                    _accessTokenSecret=value;
                }
            }
            get {
                return _accessTokenSecret;
            }
        }

        /// <summary>
        /// accessTokenを最初に取得するのに使うコンストラクタ
        /// </summary>
        /// <param name="consumerKey">consumerKey</param>
        /// <param name="consumerSecret">consumerSecret</param>
        public AccountKey(string consumerKey, string consumerSecret) {
            this.consumerKey=consumerKey;
            this.consumerSecret=consumerSecret;
        }

        /// <summary>
        /// 通常時使うコンストラクタ
        /// </summary>
        /// <param name="consumerKey">consumerKey</param>
        /// <param name="consumerSecret">consumerSecret</param>
        /// <param name="accessToken">accessToken</param>
        /// <param name="accessTokenSecret">accessTokenSecret</param>
        public AccountKey(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret) {
            this.consumerKey=consumerKey;
            this.consumerSecret=consumerSecret;
            this.accessToken=accessToken;
            this.accessTokenSecret=accessTokenSecret;
        }

        public override string ToString() {
            return "consumerKey="+consumerKey+"&consumerSecret="+consumerSecret+"&accessToken="+accessToken+"&accessTokenSecret="+accessTokenSecret;
        }
    }
}
