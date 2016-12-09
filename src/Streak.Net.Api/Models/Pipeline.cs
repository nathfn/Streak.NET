using System.Collections.Generic;
using Newtonsoft.Json;

namespace Streak.Net.Api.Models
{
    public class Pipeline: BaseObject
    {
        /// <summary>
        /// Gets or sets the creator key.
        /// </summary>
        /// <value>
        /// The creator key.
        /// </value>
        [JsonProperty(PropertyName = "creatorKey")]
        public string CreatorKey { get; set; }

        /// <summary>
        ///	The name of this pipeline
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// A description of the purpose of this pipeline, displayed in the web UI.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Whether this pipeline is shared with all users in the organization (same domain in email address)
        /// </summary>
        /// <value>
        ///   <c>true</c> if [org wide]; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty(PropertyName = "orgWide")]
        public bool OrgWide { get; set; }

        /// <summary>
        /// Describes what fields each box within the pipeline can have. This field is read-only. To modify, refer to the Fields endpoints
        /// </summary>
        /// <value>
        /// The fields.
        /// </value>
        [JsonProperty(PropertyName = "fields")]
        public List<Field> Fields { get; set; }

        /// <summary>
        /// A map describing the set of possible stages a box within the pipeline can be in. Read-only and can only be modified using Stages endpoints
        /// </summary>
        /// <value>
        /// The stages.
        /// </value>
        [JsonProperty(PropertyName = "stages")]
        public Dictionary<string, Stage> Stages { get; set; }

        /// <summary>
        /// Editable list which allows you to reorder the stages. This modifies the order of the stages that appear in the web UI
        /// </summary>
        /// <value>
        /// The stage order.
        /// </value>
        [JsonProperty(PropertyName = "stageOrder")]
        public List<string> StageOrder { get; set; }

        [JsonProperty(PropertyName = "creationTimestamp")]
        public object CreationTimestamp { get; set; }

        [JsonProperty(PropertyName = "lastUpdatedTimestamp")]
        public object LastUpdatedTimestamp { get; set; }

        /// <summary>
        /// A list of ACL objects (with properties: fullName, email, isOwner, image) which determines a list of users who have access to this pipeline
        /// </summary>
        /// <value>
        /// The acl entries.
        /// </value>
        [JsonProperty(PropertyName = "aclEntries")]
        public List<AclEntry> AclEntries { get; set; }

        /// <summary>
        /// An object with the same properties as elements in the aclEntries array specifying the creator of this pipeline
        /// </summary>
        /// <value>
        /// The owner.
        /// </value>
        [JsonProperty(PropertyName = "owner")]
        public AclEntry Owner { get; set; }

        [JsonProperty(PropertyName = "pipelineKey")]
        public string PipelineKey { get; set; }

        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }
    }
}
