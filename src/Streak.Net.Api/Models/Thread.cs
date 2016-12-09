using System.Collections.Generic;
using Newtonsoft.Json;

namespace Streak.Net.Api.Models
{
    public class Thread: BaseObject
    {
        [JsonProperty(PropertyName = "creatorKey")]
        public string CreatorKey { get; set; }

        [JsonProperty(PropertyName = "boxKey")]
        public string BoxKey { get; set; }

        [JsonProperty(PropertyName = "pipelineKey")]
        public string PipelineKey { get; set; }

        [JsonProperty(PropertyName = "creationTimestamp")]
        public long CreationTimestamp { get; set; }

        [JsonProperty(PropertyName = "lastUpdatedTimestamp")]
        public long LastUpdatedTimestamp { get; set; }

        /// <summary>
        /// The date and time of the last email in the thread, as a unix timestamp
        /// </summary>
        /// <value>
        /// The last email timestamp.
        /// </value>
        [JsonProperty(PropertyName = "lastEmailTimestamp")]
        public long LastEmailTimestamp { get; set; }

        /// <summary>
        /// The subject of the first email in the thread
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }

        /// <summary>
        /// The senders and recipients on the gmail thread.
        /// </summary>
        /// <value>
        /// The names.
        /// </value>
        [JsonProperty(PropertyName = "names")]
        public List<string> Names { get; set; }

        /// <summary>
        /// The senders and recipients on the gmail thread.
        /// </summary>
        /// <value>
        /// The email addresses.
        /// </value>
        [JsonProperty(PropertyName = "emailAddresses")]
        public List<string> EmailAddresses { get; set; }

        /// <summary>
        /// Gmail's key for the thread.
        /// </summary>
        /// <value>
        /// The thread gmail identifier.
        /// </value>
        [JsonProperty(PropertyName = "threadGmailId")]
        public string ThreadGmailId { get; set; }

        [JsonProperty(PropertyName = "fileKeys")]
        public List<string> FileKeys { get; set; }

        /// <summary>
        /// Attachments on messages in the thread.
        /// </summary>
        /// <value>
        /// The files.
        /// </value>
        [JsonProperty(PropertyName = "files")]
        public List<File> Files { get; set; }

        [JsonProperty(PropertyName = "gmailThreadKey")]
        public string GmailThreadKey { get; set; }

        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }
    }
}
