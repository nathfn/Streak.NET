using System.Collections.Generic;

namespace Streak.Net.Api.Models
{
    public class ThreadList: BaseObject
    {
        public IEnumerable<Thread> Threads { get; set; }
    }
}
