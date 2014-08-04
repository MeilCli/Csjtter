using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csjtter.api {
    internal static class APIConstant {
        //statuses
        public const string statuses_home_timeline = "statuses/home_timeline.json";
        public const string statuses_mentions_timeline = "statuses/mentions_timeline.json";
        public const string statuses_user_timeline = "statuses/user_timeline.json";
        public const string statuses_retweets_of_me = "statuses/retweets_of_me.json";
        public const string statuses_retweets = "statuses/retweets/";
        public const string statuses_update="statuses/update.json";
        public const string statuses_destroy = "statuses/destroy/";
        public const string statuses_retweet = "statuses/retweet/";

        //favorites
        public const string favorites_create = "favorites/create.json";
    }
}
