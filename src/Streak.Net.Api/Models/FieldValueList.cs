using System.Collections.Generic;

namespace Streak.Net.Api.Models
{
    public class FieldValueList : BaseObject
    {
        public IEnumerable<FieldValue> FieldValues { get; set; }
    }
}
