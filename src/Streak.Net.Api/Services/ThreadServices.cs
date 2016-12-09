using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Streak.Net.Api.Models;
using Streak.Net.Api.Services.Raw;

namespace Streak.Net.Api.Services
{
    public class ThreadServices: ServicesBase
    {
        private readonly RawThreadServices _rawThreadServices;

        internal ThreadServices(string apiKey, string apiBaseUrl, bool includeRawResponse) : base(includeRawResponse)
        {
            _rawThreadServices = new RawThreadServices(apiKey, apiBaseUrl);
        }

        /// <summary>
        /// This call lets you get all the threads associated with a particular box.
        /// </summary>
        /// <param name="boxKey">The key of the box for which you want the threads listed</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Please specify a pipeline key!</exception>
        public ThreadList ListTasksInPipeline(string boxKey)
        {
            if (string.IsNullOrEmpty(boxKey))
                throw new ArgumentNullException(nameof(boxKey), "Please specify a box key!");
            var threadList = new ThreadList
            {
                RawApiResponse = _rawThreadServices.ListTasksInPipeline(boxKey)
            };
            threadList.Threads = JsonConvert.DeserializeObject<List<Thread>>(threadList.RawApiResponse.Json);
            threadList.RawApiResponse = GetRawApiResponseOrNull(threadList.RawApiResponse);
            return threadList;
        }

        /// <summary>
        /// This call lets you get a specific thread.
        /// </summary>
        /// <param name="threadKey">The key of the thread.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Please specify a thread key!</exception>
        public Thread GetThread(string threadKey)
        {
            if (string.IsNullOrEmpty(threadKey))
                throw new ArgumentNullException(nameof(threadKey), "Please specify a thread key!");
            var rawResponse = _rawThreadServices.GetThread(threadKey);
            var thread = JsonConvert.DeserializeObject<Thread>(rawResponse.Json);
            thread.RawApiResponse = GetRawApiResponseOrNull(rawResponse);
            return thread;
        }
    }
}
