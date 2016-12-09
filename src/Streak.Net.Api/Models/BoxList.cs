using System.Collections.Generic;

namespace Streak.Net.Api.Models
{
    public class BoxList: BaseObject
    {
        public IEnumerable<Box> Boxes { get; set; }
    }
}
