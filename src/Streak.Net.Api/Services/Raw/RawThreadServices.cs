using System;
using Streak.Net.Api.Models;

namespace Streak.Net.Api.Services.Raw
{
    public class RawThreadServices : RawServicesBase
    {
        internal RawThreadServices(string apiKey, string apiBaseUrl) : base(apiKey, apiBaseUrl){ }

        /// <summary>
        /// This call lets you get all the threads associated with a particular box.
        /// </summary>
        /// <param name="boxKey">The key of the box for which you want the threads listed</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Please specify a pipeline key!</exception>
        public RawApiResponse ListTasksInPipeline(string boxKey)
        {
            if (string.IsNullOrEmpty(boxKey))
                throw new ArgumentNullException(nameof(boxKey), "Please specify a box key!");
            int httpStatusCode;
            var json = Http.Get(ApiHandles.ListThreads.Replace("{boxKey}", boxKey),
                out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }

        /// <summary>
        /// This call lets you get a specific thread.
        /// </summary>
        /// <param name="threadKey">The key of the thread.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Please specify a thread key!</exception>
        public RawApiResponse GetThread(string threadKey)
        {
            if (string.IsNullOrEmpty(threadKey))
                throw new ArgumentNullException(nameof(threadKey), "Please specify a thread key!");
            var handle = ApiHandles.GetThread.Replace("{threadKey}", threadKey);
            int httpStatusCode;
            var json = Http.Get(handle,
                out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }
    }
}
