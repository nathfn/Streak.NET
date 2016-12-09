using Newtonsoft.Json;

namespace Streak.Net.Api.Models
{
    public class Stage: BaseObject
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }
    }
}
