
namespace Csjtter.api {
    internal static class APIConstant {
        //statuses
        public const string statuses_home_timeline = "statuses/home_timeline.json";
        public const string statuses_mentions_timeline = "statuses/mentions_timeline.json";
        public const string statuses_user_timeline = "statuses/user_timeline.json";
        public const string statuses_retweets_of_me = "statuses/retweets_of_me.json";
        public const string statuses_retweets = "statuses/retweets/";
        public const string statuses_update = "statuses/update.json";
        public const string statuses_destroy = "statuses/destroy/";
        public const string statuses_retweet = "statuses/retweet/";
        public const string statuses_show = "statuses/show.json";
        public const string statuses_lookup = "statuses/lookup.json";
        public const string statuses_oembed = "statuses/oembed.json";
        public const string statuses_retweeters_ids = "statuses/retweeters/ids.json";

        //search
        public const string search_tweets = "search/tweets.json";

        //directMessages
        public const string direct_messages = "direct_messages.json";
        public const string direct_messages_sent = "direct_messages/sent.json";
        public const string direct_messages_show = "direct_messages/show.json";
        public const string direct_messages_destroy = "direct_messages/destroy.json";
        public const string direct_messages_new = "direct_messages/new.json";

        //friendships
        public const string friendships_no_retweets_ids = "friendships/no_retweets/ids.json";
        public const string friendships_incoming = "friendships/incoming.json";
        public const string friendships_outgoing = "friendships/outgoing.json";

        //favorites
        public const string favorites_create = "favorites/create.json";
    }
}
