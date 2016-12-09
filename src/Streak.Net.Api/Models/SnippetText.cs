using Newtonsoft.Json;

namespace Streak.Net.Api.Models
{
    public class SnippetText
    {
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}
