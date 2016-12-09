using System.Collections.Generic;
using Newtonsoft.Json;

namespace Streak.Net.Api.Models
{
    public class Task : BaseObject
    {
        [JsonProperty(PropertyName = "boxKey")]
        public string BoxKey { get; set; }

        [JsonProperty(PropertyName = "pipelineKey")]
        public string PipelineKey { get; set; }

        /// <summary>
        /// The user key of the user that created the task
        /// </summary>
        /// <value>
        /// The creator key.
        /// </value>
        [JsonProperty(PropertyName = "creatorKey")]
        public string CreatorKey { get; set; }

        /// <summary>
        /// The date the task was created
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        [JsonProperty(PropertyName = "creationDate")]
        public long CreationDate { get; set; }

        [JsonProperty(PropertyName = "lastStatusChangeDate")]
        public long LastStatusChangeDate { get; set; }

        /// <summary>
        /// The date the task is due and a reminder is sent
        /// </summary>
        /// <value>
        /// The due date.
        /// </value>
        [JsonProperty(PropertyName = "dueDate")]
        public long DueDate { get; set; }

        /// <summary>
        /// The text of a task
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        /// <summary>
        /// Whether the task is DONE or NOT_DONE
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets the status of the reminder if this task has a due date, can be: NONE, SCHEDULED, REMINDED or ERROR_ON_REMINDER
        /// </summary>
        /// <value>
        /// The reminder status.
        /// </value>
        [JsonProperty(PropertyName = "reminderStatus")]
        public string ReminderStatus { get; set; }

        /// <summary>
        /// Who the task is assigned to
        /// </summary>
        /// <value>
        /// The assigned to sharing entries.
        /// </value>
        [JsonProperty(PropertyName = "assignedToSharingEntries")]
        public List<AclEntry> AssignedToSharingEntries { get; set; }

        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        [JsonProperty(PropertyName = "lastSavedTimestamp")]
        public long LastSavedTimestamp { get; set; }
    }
}
