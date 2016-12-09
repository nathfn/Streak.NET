using Newtonsoft.Json;

namespace Streak.Net.Api.Models
{
    public class Snippet: BaseObject
    {
        /// <summary>
        /// The key of the user that created the timestamp
        /// </summary>
        /// <value>
        /// The user key.
        /// </value>
        [JsonProperty(PropertyName = "userKey")]
        public string UserKey { get; set; }

        /// <summary>
        /// The date and time the snippet was created
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        [JsonProperty(PropertyName = "creationDate")]
        public long CreationDate { get; set; }

        /// <summary>
        /// Whether this snippet is part of a pipeline or not
        /// </summary>
        /// <value>
        ///   <c>true</c> if [part of pipeline]; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty(PropertyName = "partOfPipeline")]
        public bool PartOfPipeline { get; set; }

        /// <summary>
        /// The text of the snippet
        /// </summary>
        /// <value>
        /// The snippet text.
        /// </value>
        [JsonProperty(PropertyName = "snippetText")]
        public SnippetText SnippetText { get; set; }

        /// <summary>
        /// The name of the snippet
        /// </summary>
        /// <value>
        /// The name of the snippet.
        /// </value>
        [JsonProperty(PropertyName = "snippetName")]
        public string SnippetName { get; set; }

        /// <summary>
        /// The type of the snippet, can be TEXT or HTML
        /// </summary>
        /// <value>
        /// The type of the snippet.
        /// </value>
        [JsonProperty(PropertyName = "snippetType")]
        public string SnippetType { get; set; }

        [JsonProperty(PropertyName = "snippetKey")]
        public string SnippetKey { get; set; }

        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }
    }
}
