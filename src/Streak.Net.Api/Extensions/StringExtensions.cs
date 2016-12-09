namespace Streak.Net.Api.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveFirstAndLastCharacter(this string s)
        {
            return string.IsNullOrEmpty(s) ? string.Empty : s.Substring(1, s.Length - 1);
        }
    }
}
