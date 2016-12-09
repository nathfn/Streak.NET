using Streak.Net.Api.Models;

namespace Streak.Net.Api.Services
{
    public abstract class ServicesBase
    {
        private readonly bool _includeRawResponse;

        internal ServicesBase(bool includeRawResponse)
        {
            _includeRawResponse = includeRawResponse;
        }

        public RawApiResponse GetRawApiResponseOrNull(RawApiResponse rawApiResponse)
        {
            return _includeRawResponse ? rawApiResponse : null;
        }
    }
}
