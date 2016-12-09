using Newtonsoft.Json;

namespace Streak.Net.Api.Models
{
    public class Comment: BaseObject
    {
        [JsonProperty(PropertyName = "boxKey")]
        public string BoxKey { get; set; }

        [JsonProperty(PropertyName = "pipelineKey")]
        public string PipelineKey { get; set; }

        /// <summary>
        /// The date and time of the comment was created
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        [JsonProperty(PropertyName = "timestamp")]
        public long Timestamp { get; set; }

        /// <summary>
        /// The key of the user that created the timestamp
        /// </summary>
        /// <value>
        /// The creator key.
        /// </value>
        [JsonProperty(PropertyName = "creatorKey")]
        public string CreatorKey { get; set; }

        /// <summary>
        /// The message content of the comment
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "commentKey")]
        public string CommentKey { get; set; }

        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }
    }
}
