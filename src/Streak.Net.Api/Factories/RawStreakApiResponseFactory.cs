using Streak.Net.Api.Models;

namespace Streak.Net.Api.Factories
{
    public class RawStreakApiResponseFactory
    {
        public RawApiResponse BuildRawStreakApiResponse(string json, int httpStatusCode)
        {
            return new RawApiResponse(json, httpStatusCode);
        }
    }
}
