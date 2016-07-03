using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;
using Newtonsoft.Json;

namespace SIMPLSharpTwitter
{
    public static class TwitterJson
    {

        public class OauthResponse
        {
            [JsonProperty("token_type")]
            public string TokenType { get; set; }
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }
        }
        public class tweet
        {
            [JsonProperty("tweets")]
            public IList<tweetConfig> tweets { get; set; }
            //public tweetConfig tweetconfigs { get; set; }
            //public IList<tweetConfig> Entities { get; set; }        
        }
        public class tweetConfig
        {
            [JsonProperty("created_at")]
            public string created_at { get; set; }
            [JsonProperty("text")]
            public string text { get; set; }
        }
        public class tokenJson
        {
            [JsonProperty("token_type")]
            public string TokenType { get; set; }
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }
        }

        public class TimeLine
        {
            [JsonProperty("created_at")]
            public string CreatedAt { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("id_str")]
            public string IdStr { get; set; }

            [JsonProperty("text")]
            public string Text { get; set; }

            [JsonProperty("source")]
            public string Source { get; set; }

            [JsonProperty("truncated")]
            public bool Truncated { get; set; }

            [JsonProperty("in_reply_to_status_id")]
            public string InReplyToStatusId { get; set; }

            [JsonProperty("in_reply_to_status_id_str")]
            public string InReplyToStatusIdStr { get; set; }

            [JsonProperty("in_reply_to_user_id")]
            public string InReplyToUserId { get; set; }

            [JsonProperty("in_reply_to_user_id_str")]
            public string InReplyToUserIdStr { get; set; }

            [JsonProperty("in_reply_to_screen_name")]
            public string InReplyToScreenName { get; set; }

            [JsonProperty("user")]
            public User User { get; set; }

            [JsonProperty("geo")]
            public string Geo { get; set; }

            [JsonProperty("coordinates")]
            public string Coordinates { get; set; }

            [JsonProperty("place")]
            public string Place { get; set; }

            [JsonProperty("contributors")]
            public string Contributors { get; set; }

            [JsonProperty("retweet_count")]
            public int RetweetCount { get; set; }

            [JsonProperty("favorite_count")]
            public int FavoriteCount { get; set; }

            [JsonProperty("entities")]
            public Entities Entities { get; set; }

            [JsonProperty("favorited")]
            public bool Favorited { get; set; }

            [JsonProperty("retweeted")]
            public bool Retweeted { get; set; }

            [JsonProperty("lang")]
            public string Lang { get; set; }
        }
        public class User
        {

            [JsonProperty("id")]
            public Int64 Id { get; set; }

            [JsonProperty("id_str")]
            public string IdStr { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("screen_name")]
            public string ScreenName { get; set; }

            [JsonProperty("location")]
            public string Location { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("entities")]
            public UserEntities Entities { get; set; }

            [JsonProperty("protected")]
            public bool Protected { get; set; }

            [JsonProperty("followers_count")]
            public int FollowersCount { get; set; }

            [JsonProperty("friends_count")]
            public int FriendsCount { get; set; }

            [JsonProperty("listed_count")]
            public int ListedCount { get; set; }

            [JsonProperty("created_at")]
            public string CreatedAt { get; set; }

            [JsonProperty("favourites_count")]
            public int FavouritesCount { get; set; }

            [JsonProperty("utc_offset")]
            public string UtcOffset { get; set; }

            [JsonProperty("time_zone")]
            public string TimeZone { get; set; }

            [JsonProperty("geo_enabled")]
            public bool GeoEnabled { get; set; }

            [JsonProperty("verified")]
            public bool Verified { get; set; }

            [JsonProperty("statuses_count")]
            public int StatusesCount { get; set; }

            [JsonProperty("lang")]
            public string Lang { get; set; }

            [JsonProperty("contributors_enabled")]
            public bool ContributorsEnabled { get; set; }

            [JsonProperty("is_translator")]
            public bool IsTranslator { get; set; }

            [JsonProperty("profile_background_color")]
            public string ProfileBackgroundColor { get; set; }

            [JsonProperty("profile_background_image_url")]
            public string ProfileBackgroundImageUrl { get; set; }

            [JsonProperty("profile_background_image_url_https")]
            public string ProfileBackgroundImageUrlHttps { get; set; }

            [JsonProperty("profile_background_tile")]
            public bool ProfileBackgroundTile { get; set; }

            [JsonProperty("profile_image_url")]
            public string ProfileImageUrl { get; set; }

            [JsonProperty("profile_image_url_https")]
            public string ProfileImageUrlHttps { get; set; }

            [JsonProperty("profile_link_color")]
            public string ProfileLinkColor { get; set; }

            [JsonProperty("profile_sidebar_border_color")]
            public string ProfileSidebarBorderColor { get; set; }

            [JsonProperty("profile_sidebar_fill_color")]
            public string ProfileSidebarFillColor { get; set; }

            [JsonProperty("profile_text_color")]
            public string ProfileTextColor { get; set; }

            [JsonProperty("profile_use_background_image")]
            public bool ProfileUseBackgroundImage { get; set; }

            [JsonProperty("default_profile")]
            public bool DefaultProfile { get; set; }

            [JsonProperty("default_profile_image")]
            public bool DefaultProfileImage { get; set; }

            [JsonProperty("following")]
            public string Following { get; set; }

            [JsonProperty("follow_request_sent")]
            public string FollowRequestSent { get; set; }

            [JsonProperty("notifications")]
            public string Notifications { get; set; }
        }
        public class Entities
        {

            [JsonProperty("hashtags")]
            public List<Hashtag> Hashtags { get; set; }

            [JsonProperty("symbols")]
            public List<string> Symbols { get; set; }

            [JsonProperty("urls")]
            public List<Url> Urls { get; set; }

            [JsonProperty("user_mentions")]
            public List<UserMention> UserMentions { get; set; }

            [JsonProperty("media")]
            public List<Media> Media { get; set; }
        }
        public class UserEntities
        {

            [JsonProperty("description")]
            public Description Description { get; set; }
        }
        public class Hashtag
        {
            [JsonProperty("text")]
            public string Text { get; set; }

            [JsonProperty("indices")]
            public List<int> Indices { get; set; }

        }
        public class Url
        {
            [JsonProperty("url")]
            public string UrlValue { get; set; }

            [JsonProperty("expanded_url")]
            public string ExpandedUrl { get; set; }

            [JsonProperty("display_url")]
            public string DisplayUrl { get; set; }

            [JsonProperty("indices")]
            public List<int> Indices { get; set; }

        }
        public class UserMention
        {
            [JsonProperty("screenname")]
            public string ScreenName { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("indices")]
            public List<int> Indices { get; set; }

        }
        public class Media
        {

            public object id { get; set; }
            public string id_str { get; set; }
            public List<int> indices { get; set; }
            public string media_url { get; set; }
            public string media_url_https { get; set; }
            public string url { get; set; }
            public string display_url { get; set; }
            public string expanded_url { get; set; }
            public string type { get; set; }
            public Sizes sizes { get; set; }
        }

        public class Sizes
        {
            public Thumb thumb { get; set; }
            public Small small { get; set; }
            public Medium medium { get; set; }
            public Large large { get; set; }
        }
        public class Thumb
        {
            public int w { get; set; }
            public int h { get; set; }
            public string resize { get; set; }
        }

        public class Small
        {
            public int w { get; set; }
            public int h { get; set; }
            public string resize { get; set; }
        }

        public class Medium
        {
            public int w { get; set; }
            public int h { get; set; }
            public string resize { get; set; }
        }

        public class Large
        {
            public int w { get; set; }
            public int h { get; set; }
            public string resize { get; set; }
        }
        public class Description
        {
            [JsonProperty("urls")]
            public List<Url> Urls { get; set; }
        }
    }
}