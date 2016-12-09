namespace Streak.Net.Api.Enums
{
    public class SortOptions
    {
        private SortOptions(string value) { Value = value; }
        public string Value { get; set; }
        public static SortOptions CreationTimestamp => new SortOptions("creationTimestamp");
        public static SortOptions LastUpdatedTimestamp => new SortOptions("lastUpdatedTimestamp");
    }
}
