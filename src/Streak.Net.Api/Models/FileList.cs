using System.Collections.Generic;

namespace Streak.Net.Api.Models
{
    public class FileList: BaseObject
    {
        public IEnumerable<File> Files { get; set; }
    }
}
