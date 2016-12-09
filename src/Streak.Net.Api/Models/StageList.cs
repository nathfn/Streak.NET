using System.Collections.Generic;

namespace Streak.Net.Api.Models
{
    public class StageList: BaseObject
    {
        public Dictionary<string, Stage> Stages { get; set; }
    }
}
