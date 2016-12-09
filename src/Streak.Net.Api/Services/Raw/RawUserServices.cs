using System;
using Streak.Net.Api.Models;

namespace Streak.Net.Api.Services.Raw
{
    public class RawUserServices: RawServicesBase
    {
        internal RawUserServices(string apiKey, string apiBaseUrl) : base(apiKey, apiBaseUrl){}

        /// <summary>
        /// This call will give the current user (as defined by the API Key)
        /// </summary>
        /// <returns></returns>
        public RawApiResponse GetCurrentUser()
        {
            int httpStatusCode;
            var json = Http.Get(ApiHandles.GetCurrentUser, out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }

        /// <summary>
        /// This call will return the details for the user specified. Note, you are only permissted to request users who belong to the same domain as the user making the request.
        /// </summary>
        /// <param name="userKey">The user key.</param>
        /// <returns></returns>
        public RawApiResponse GetUser(string userKey)
        {
            if (string.IsNullOrEmpty(userKey))
                throw new ArgumentNullException(nameof(userKey), "Please specify a user key!");
            int httpStatusCode;
            var json = Http.Get(ApiHandles.GetUser.Replace("{userKey}", userKey), out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }
    }
}
