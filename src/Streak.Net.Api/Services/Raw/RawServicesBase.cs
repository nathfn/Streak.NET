using Streak.Net.Api.Communication;
using Streak.Net.Api.Config;
using Streak.Net.Api.Factories;

namespace Streak.Net.Api.Services.Raw
{
    /// <summary>
    /// Base class for all raw service interactions
    /// </summary>
    public abstract class RawServicesBase
    {
        protected readonly Http Http;
        protected readonly ApiHandles ApiHandles;
        protected readonly RawStreakApiResponseFactory RawStreakApiResponseFactory;

        internal RawServicesBase(string apiKey, string apiBaseUrl)
        {
            Http = new Http(apiKey, apiBaseUrl);
            ApiHandles = new ApiHandles();
            RawStreakApiResponseFactory = new RawStreakApiResponseFactory();
        }
    }
}
