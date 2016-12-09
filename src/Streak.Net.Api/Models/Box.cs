using System.Collections.Generic;
using Newtonsoft.Json;

namespace Streak.Net.Api.Models
{
    public class Box: BaseObject
    {
        [JsonProperty(PropertyName = "pipelineKey")]
        public string PipelineKey { get; set; }

        [JsonProperty(PropertyName = "creatorKey")]
        public string CreatorKey { get; set; }

        [JsonProperty(PropertyName = "creationTimestamp")]
        public long CreationTimestamp { get; set; }

        [JsonProperty(PropertyName = "lastUpdatedTimestamp")]
        public long LastUpdatedTimestamp { get; set; }

        [JsonProperty(PropertyName = "lastStageChangeTimestamp")]
        public long LastStageChangeTimestamp { get; set; }

        [JsonProperty(PropertyName = "totalNumberOfEmails")]
        public int TotalNumberOfEmails { get; set; }

        [JsonProperty(PropertyName = "totalNumberOfSentEmails")]
        public int TotalNumberOfSentEmails { get; set; }

        [JsonProperty(PropertyName = "totalNumberOfReceivedEmails")]
        public int TotalNumberOfReceivedEmails { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "assignedToSharingEntries")]
        public List<AclEntry> AssignedToSharingEntries { get; set; }

        [JsonProperty(PropertyName = "creatorSharingEntry")]
        public AclEntry CreatorSharingEntry { get; set; }

        [JsonProperty(PropertyName = "followerSharingEntries")]
        public List<AclEntry> FollowerSharingEntries { get; set; }

        [JsonProperty(PropertyName = "stageKey")]
        public string StageKey { get; set; }

        [JsonProperty(PropertyName = "followerKeys")]
        public List<string> FollowerKeys { get; set; }

        [JsonProperty(PropertyName = "linkedBoxKeys")]
        public List<string> LinkedBoxKeys { get; set; }

        [JsonProperty(PropertyName = "emailAddressesAutoExtracted")]
        public List<string> EmailAddressesAutoExtracted { get; set; }

        [JsonProperty(PropertyName = "emailAddressesWhitelist")]
        public List<string> EmailAddressesWhitelist { get; set; }

        [JsonProperty(PropertyName = "emailAddressesBlacklist")]
        public List<string> EmailAddressesBlacklist { get; set; }

        [JsonProperty(PropertyName = "emailAddresses")]
        public List<string> EmailAddresses { get; set; }

        [JsonProperty(PropertyName = "taskCompleteCount")]
        public int TaskCompleteCount { get; set; }

        [JsonProperty(PropertyName = "taskIncompleteCount")]
        public int TaskIncompleteCount { get; set; }

        [JsonProperty(PropertyName = "taskOverdueCount")]
        public int TaskOverdueCount { get; set; }

        [JsonProperty(PropertyName = "taskAssigneeKeySet")]
        public List<string> TaskAssigneeKeySet { get; set; }

        [JsonProperty(PropertyName = "overdueTaskAssigneeKeySet")]
        public List<string> OverdueTaskAssigneeKeySet { get; set; }

        [JsonProperty(PropertyName = "incompleteTaskAssigneeKeySet")]
        public List<string> IncompleteTaskAssigneeKeySet { get; set; }

        [JsonProperty(PropertyName = "taskAssigneeSharingEntrySet")]
        public List<AclEntry> TaskAssigneeSharingEntrySet { get; set; }

        [JsonProperty(PropertyName = "overdueTaskAssigneeSharingEntrySet")]
        public List<AclEntry> OverdueTaskAssigneeSharingEntrySet { get; set; }

        [JsonProperty(PropertyName = "incompleteTaskAssigneeSharingEntrySet")]
        public List<AclEntry> IncompleteTaskAssigneeSharingEntrySet { get; set; }

        [JsonProperty(PropertyName = "taskTotal")]
        public int TaskTotal { get; set; }

        [JsonProperty(PropertyName = "callLogCount")]
        public int CallLogCount { get; set; }

        [JsonProperty(PropertyName = "meetingNotesCount")]
        public int MeetingNotesCount { get; set; }

        [JsonProperty(PropertyName = "totalCallLogDuration")]
        public int TotalCallLogDuration { get; set; }

        [JsonProperty(PropertyName = "totalMeetingNotesDuration")]
        public int TotalMeetingNotesDuration { get; set; }

        [JsonProperty(PropertyName = "followerCount")]
        public int FollowerCount { get; set; }

        [JsonProperty(PropertyName = "commentCount")]
        public int CommentCount { get; set; }

        [JsonProperty(PropertyName = "gmailThreadCount")]
        public int GmailThreadCount { get; set; }

        [JsonProperty(PropertyName = "fileCount")]
        public int FileCount { get; set; }

        [JsonProperty(PropertyName = "fields")]
        public Dictionary<string, string> Fields { get; set; }

        [JsonProperty(PropertyName = "boxKey")]
        public string BoxKey { get; set; }

        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        [JsonProperty(PropertyName = "freshness")]
        public double Freshness { get; set; }

        [JsonProperty(PropertyName = "lastSavedTimestamp")]
        public long LastSavedTimestamp { get; set; }

        [JsonProperty(PropertyName = "notes")]
        public string Notes { get; set; }
    }
}
