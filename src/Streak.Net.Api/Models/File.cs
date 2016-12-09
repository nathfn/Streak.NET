using Newtonsoft.Json;

namespace Streak.Net.Api.Models
{
    public class File: BaseObject
    {
        /// <summary>
        /// Each file comes from a particular email that was added to a box. This property is the key of the user that added the email to the box.
        /// </summary>
        /// <value>
        /// The file owner.
        /// </value>
        [JsonProperty(PropertyName = "fileOwner")]
        public string FileOwner { get; set; }

        /// <summary>
        /// The size of the file in bytes
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        [JsonProperty(PropertyName = "size")]
        public string Size { get; set; }

        /// <summary>
        /// The mime type of the file
        /// </summary>
        /// <value>
        /// The type of the MIME.
        /// </value>
        [JsonProperty(PropertyName = "mimeType")]
        public string MimeType { get; set; }

        /// <summary>
        /// The filename with extension
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        [JsonProperty(PropertyName = "fileName")]
        public string FileName { get; set; }

        /// <summary>
        /// The filename with extension
        /// </summary>
        /// <value>
        /// The name of the main file.
        /// </value>
        [JsonProperty(PropertyName = "mainFileName")]
        public string MainFileName { get; set; }

        [JsonProperty(PropertyName = "fileKey")]
        public string FileKey { get; set; }
    }
}
