using System;
using Newtonsoft.Json;
using Streak.Net.Api.Models;
using Streak.Net.Api.Services.Raw;

namespace Streak.Net.Api.Services
{
    public class CommentServices: ServicesBase
    {
        private readonly RawCommentServices _rawCommentServices;

        internal CommentServices(string apiKey, string apiBaseUrl, bool includeRawResponse) : base(includeRawResponse)
        {
            _rawCommentServices = new RawCommentServices(apiKey, apiBaseUrl);
        }

        /// <summary>
        /// This call lets you create a comment associated with a particular box.
        /// </summary>
        /// <param name="boxKey">The key of the box for which you want the threads listed</param>
        /// <param name="message">The message content of the comment</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Please specify a box key!</exception>
        public Comment CreateComment(string boxKey, string message)
        {
            if (string.IsNullOrEmpty(boxKey))
                throw new ArgumentNullException(nameof(boxKey), "Please specify a box key!");
            var rawResponse = _rawCommentServices.CreateComment(boxKey, message);
            var comment = JsonConvert.DeserializeObject<Comment>(rawResponse.Json);
            comment.RawApiResponse = GetRawApiResponseOrNull(rawResponse);
            return comment;
        }
    }
}
