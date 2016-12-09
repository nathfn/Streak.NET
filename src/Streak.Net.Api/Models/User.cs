using Newtonsoft.Json;

namespace Streak.Net.Api.Models
{
    public class User : BaseObject
    {
        /// <summary>
        /// The email address of the user
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// A lower case version of the users email address. Useful for normalization
        /// </summary>
        /// <value>
        /// The lowercase email.
        /// </value>
        [JsonProperty(PropertyName = "lowercaseEmail")]
        public string LowercaseEmail { get; set; }

        /// <summary>
        /// The date the user last used into Streak
        /// </summary>
        /// <value>
        /// The last seen timestamp.
        /// </value>
        [JsonProperty(PropertyName = "lastSeenTimestamp")]
        public long LastSeenTimestamp { get; set; }
        /// <summary>
        /// Whether the user has completed the OAuth process. Useful to determine whether they can successully share emails
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is oauth complete; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty(PropertyName = "isOauthComplete")]
        public bool IsOauthComplete { get; set; }

        /// <summary>
        /// A display friendly name, usually the users full name if it exists in their profile
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        /// 
        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        [JsonProperty(PropertyName = "creationTimestamp")]
        public long CreationTimestamp { get; set; }

        [JsonProperty(PropertyName = "lastUpdatedTimestamp")]
        public long LastUpdatedTimestamp { get; set; }

        [JsonProperty(PropertyName = "userKey")]
        public string UserKey { get; set; }
    }
}
