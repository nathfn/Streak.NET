using System.Collections.Generic;

namespace Streak.Net.Api.Models
{
    public class SnippetList: BaseObject
    {
        public IEnumerable<Snippet> Snippets { get; set; }
    }
}
