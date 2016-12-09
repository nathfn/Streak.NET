using System;
using System.Web;
using Streak.Net.Api.Models;

namespace Streak.Net.Api.Services.Raw
{
    public class RawCommentServices: RawServicesBase
    {
        internal RawCommentServices(string apiKey, string apiBaseUrl) : base(apiKey, apiBaseUrl){ }

        /// <summary>
        /// This call lets you create a comment associated with a particular box.
        /// </summary>
        /// <param name="boxKey">The key of the box for which you want the threads listed</param>
        /// <param name="message">The message content of the comment</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Please specify a box key!</exception>
        public RawApiResponse CreateComment(string boxKey, string message)
        {
            if (string.IsNullOrEmpty(boxKey))
                throw new ArgumentNullException(nameof(boxKey), "Please specify a box key!");
            var collection = HttpUtility.ParseQueryString(string.Empty);
            collection.Add("message", message);
            int httpStatusCode;
            var json = Http.Put(ApiHandles.CreateComment.Replace("{boxKey}", boxKey), collection.ToString(), out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }
    }
}
