namespace Streak.Net.Api.Models
{
    /// <summary>
    /// Models a raw response from the Streak API with the returned JSON string and the HTTP status code.
    /// </summary>
    public class RawApiResponse
    {
        public RawApiResponse(string json, int httpStatusCode)
        {
            Json = json;
            HttpStatusCode = httpStatusCode;
        }

        /// <summary>
        /// The raw JSON response from the API. In case of an error this will be the error message from Streak API.
        /// </summary>
        /// <value>
        /// The json.
        /// </value>
        public string Json { get; set; }

        /// <summary>
        /// Gets or sets the HTTP status code for the API request
        /// </summary>
        /// <value>
        /// The HTTP status code.
        /// </value>
        public int HttpStatusCode { get; set; }
    }
}
