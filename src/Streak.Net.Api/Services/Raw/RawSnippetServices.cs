using System;
using Streak.Net.Api.Models;

namespace Streak.Net.Api.Services.Raw
{
    public class RawSnippetServices: RawServicesBase
    {
        internal RawSnippetServices(string apiKey, string apiBaseUrl) : base(apiKey, apiBaseUrl){ }

        /// <summary>
        /// This call lets you get all the snippets for a user
        /// </summary>
        /// <returns></returns>
        public RawApiResponse ListSnippets()
        {
            int httpStatusCode;
            var json = Http.Get(ApiHandles.ListSnippets,
                out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }

        /// <summary>
        /// This call lets you get a single snippet.
        /// </summary>
        /// <param name="snippetKey">The key of the pipeline</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Please specify a snippet key!</exception>
        public RawApiResponse GetSnippet(string snippetKey)
        {
            if (string.IsNullOrEmpty(snippetKey))
                throw new ArgumentNullException(nameof(snippetKey), "Please specify a snippet key!");
            var handle = ApiHandles.GetField.Replace("{SNIPPET_KEY}", snippetKey);
            int httpStatusCode;
            var json = Http.Get(handle,
                out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }
    }
}
