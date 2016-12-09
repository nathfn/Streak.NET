using Newtonsoft.Json;

namespace Streak.Net.Api.Models
{
    public class AclEntry
    {
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "isOwner")]
        public bool IsOwner { get; set; }

        [JsonProperty(PropertyName = "fullName")]
        public string FullName { get; set; }

        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }

        [JsonProperty(PropertyName = "permissionSetName")]
        public string PermissionSetName { get; set; }

        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "userKey")]
        public string UserKey { get; set; }
    }
}
