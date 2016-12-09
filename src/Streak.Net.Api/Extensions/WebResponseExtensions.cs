using System.Net;

namespace Streak.Net.Api.Extensions
{
    internal static class WebResponseExtensions
    {
        public static int GetHttpStatusCode(this WebResponse r)
        {
            return (int)((HttpWebResponse)r).StatusCode;
        }
    }
}
