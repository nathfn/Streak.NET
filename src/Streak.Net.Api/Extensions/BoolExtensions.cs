namespace Streak.Net.Api.Extensions
{
    public static class BoolExtensions
    {
        public static string ToLowerString(this bool b)
        {
            return b.ToString().ToLower();
        }
    }
}
