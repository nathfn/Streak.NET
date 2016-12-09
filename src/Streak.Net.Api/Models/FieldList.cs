using System.Collections.Generic;

namespace Streak.Net.Api.Models
{
    public class FieldList: BaseObject
    {
        public IEnumerable<Field> Fields { get; set; }
    }
}
