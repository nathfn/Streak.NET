using Newtonsoft.Json;

namespace Streak.Net.Api.Models
{
    public class Field: BaseObject
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}
