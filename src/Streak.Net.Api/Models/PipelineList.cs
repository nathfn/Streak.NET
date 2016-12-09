using System.Collections.Generic;

namespace Streak.Net.Api.Models
{
    public class PipelineList: BaseObject
    {
        public IEnumerable<Pipeline> Pipelines { get; set; }
    }
}
