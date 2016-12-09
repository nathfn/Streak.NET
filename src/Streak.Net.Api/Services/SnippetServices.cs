using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Streak.Net.Api.Models;
using Streak.Net.Api.Services.Raw;

namespace Streak.Net.Api.Services
{
    public class SnippetServices: ServicesBase
    {
        private readonly RawSnippetServices _rawSnippetServices;

        internal SnippetServices(string apiKey, string apiBaseUrl, bool includeRawResponse) : base(includeRawResponse)
        {
            _rawSnippetServices = new RawSnippetServices(apiKey, apiBaseUrl);
        }

        /// <summary>
        /// This call lets you get all the snippets for a user
        /// </summary>
        /// <returns></returns>
        public SnippetList ListSnippets()
        {
            var snippetList = new SnippetList
            {
                RawApiResponse = _rawSnippetServices.ListSnippets()
            };
            snippetList.Snippets = JsonConvert.DeserializeObject<List<Snippet>>(snippetList.RawApiResponse.Json);
            snippetList.RawApiResponse = GetRawApiResponseOrNull(snippetList.RawApiResponse);
            return snippetList;
        }

        /// <summary>
        /// This call lets you get a single snippet.
        /// </summary>
        /// <param name="snippetKey">The key of the pipeline</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Please specify a snippet key!</exception>
        public Snippet GetSnippet(string snippetKey)
        {
            if (string.IsNullOrEmpty(snippetKey))
                throw new ArgumentNullException(nameof(snippetKey), "Please specify a snippet key!");
            var rawResponse = _rawSnippetServices.GetSnippet(snippetKey);
            var snippet = JsonConvert.DeserializeObject<Snippet>(rawResponse.Json);
            snippet.RawApiResponse = GetRawApiResponseOrNull(rawResponse);
            return snippet;
        }
    }
}
