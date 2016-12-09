using System;
using Newtonsoft.Json;
using Streak.Net.Api.Models;
using Streak.Net.Api.Services.Raw;

namespace Streak.Net.Api.Services
{
    public class UserServices: ServicesBase
    {
        private readonly RawUserServices _rawUserServices;

        internal UserServices(string apiKey, string apiBaseUrl, bool includeRawResponse) : base(includeRawResponse)
        {
            _rawUserServices = new RawUserServices(apiKey, apiBaseUrl);
        }

        /// <summary>
        /// This call will give the current user (as defined by the API Key)
        /// </summary>
        /// <returns></returns>
        public User GetCurrentUser()
        {
            var rawResponse = _rawUserServices.GetCurrentUser();
            var user = JsonConvert.DeserializeObject<User>(rawResponse.Json);
            user.RawApiResponse = GetRawApiResponseOrNull(rawResponse);
            return user;
        }

        /// <summary>
        /// This call will return the details for the user specified. Note, you are only permissted to request users who belong to the same domain as the user making the request.
        /// </summary>
        /// <param name="userKey">The user key.</param>
        /// <returns></returns>
        public User GetUser(string userKey)
        {
            if (string.IsNullOrEmpty(userKey))
                throw new ArgumentNullException(nameof(userKey), "Please specify a user key!");
            var rawResponse = _rawUserServices.GetUser(userKey);
            var user = JsonConvert.DeserializeObject<User>(rawResponse.Json);
            user.RawApiResponse = GetRawApiResponseOrNull(rawResponse);
            return user;
        }
    }
}
