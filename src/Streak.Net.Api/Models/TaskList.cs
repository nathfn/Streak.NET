using System.Collections.Generic;

namespace Streak.Net.Api.Models
{
    public class TaskList: BaseObject
    {
        public IEnumerable<Task> Tasks { get; set; }
    }
}
