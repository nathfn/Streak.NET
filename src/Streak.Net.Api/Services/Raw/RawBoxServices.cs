using System;
using System.Web;
using Newtonsoft.Json;
using Streak.Net.Api.Enums;
using Streak.Net.Api.Models;

namespace Streak.Net.Api.Services.Raw
{
    public class RawBoxServices: RawServicesBase
    {
        internal RawBoxServices(string apiKey, string apiBaseUrl) : base(apiKey, apiBaseUrl){ }

        /// <summary>
        /// This call lets you get all boxes that the current user has access to. The boxes returned here are across all pipelines a user has access to. This is a fairly expensive call so there is a lower API quota limit. If possible, get boxes using the pipeline key instead.
        /// </summary>
        /// <returns></returns>
        public RawApiResponse ListAllBoxesUserHasAccessTo()
        {
            int httpStatusCode;
            var json = Http.Get(ApiHandles.ListAllBoxesUserHasAccessTo,
                out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }

        /// <summary>
        /// This call lets you get all boxes contained in the specified pipeline.
        /// </summary>
        /// <param name="pipelineKey">The key of the pipeline for which you want the boxes listed</param>
        /// <param name="sortOptions">What order to sort the boxes by. There are two valid sorts creationTimestamp and lastUpdatedTimestamp. Both are in descending order. (optional)</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Please specify a pipeline key!</exception>
        public RawApiResponse ListAllBoxesInPipeline(string pipelineKey, SortOptions sortOptions = null)
        {
            if (string.IsNullOrEmpty(pipelineKey))
                throw new ArgumentNullException(nameof(pipelineKey), "Please specify a pipeline key!");
            var handle = ApiHandles.ListAllBoxesInPipeline.Replace("{pipelineKey}", pipelineKey);
            if (sortOptions != null)
            {
                handle += "?sortBy=" + sortOptions.Value;
            }
            int httpStatusCode;
            var json = Http.Get(handle,
                out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }

        /// <summary>
        /// This call gives you a specific box based on the key you provide.
        /// </summary>
        /// <param name="pipelineKey">The key of the pipeline this box should belong to</param>
        /// <param name="name">The name of this box</param>
        /// <param name="stageKey">The stage of this box (Optional)</param>
        /// <returns></returns>
        public RawApiResponse CreateBox(string pipelineKey, string name, string stageKey = null)
        {
            if (string.IsNullOrEmpty(pipelineKey))
                throw new ArgumentNullException(nameof(pipelineKey), "Please specify a pipeline key!");
            var collection = HttpUtility.ParseQueryString(string.Empty);
            collection.Add("name", name);
            if (!string.IsNullOrEmpty(stageKey))
                collection.Add("stageKey", stageKey);
            int httpStatusCode;
            var json = Http.Put(ApiHandles.CreateBox.Replace("{pipelineKey}", pipelineKey), collection.ToString(), out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }

        /// <summary>
        ///This call lets you delete a particular box. It also deletes all of the relevant data such as files, emails, and tasks for that box.
        /// </summary>
        /// <param name="boxKey">The key of the box</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Please specify a box key!</exception>
        public RawApiResponse DeleteBox(string boxKey)
        {
            if (string.IsNullOrEmpty(boxKey))
                throw new ArgumentNullException(nameof(boxKey), "Please specify a box key!");
            int httpStatusCode;
            var json = Http.Delete(ApiHandles.DeleteBox.Replace("{boxKey}", boxKey), out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }

        /// <summary>
        /// This call lets you edit the properties of a box.
        /// </summary>
        /// <param name="boxKey">The key of the box to be edited</param>
        /// <param name="name">The name of the box (optional)</param>
        /// <param name="notes">The notes of the box (optional)</param>
        /// <param name="stageKey">The key of the stage that this box should be in. A list of valid stage keys can be found from the pipeline that this box belongs to (optional)</param>
        /// <param name="followerKeys">A JSON array of user keys who are following this box. When a user follows a box, they receive notification emails upon major changes to the box (optional)</param>
        /// <returns></returns>
        public RawApiResponse EditBox(string boxKey, string name = null, string notes = null, string stageKey = null, string[] followerKeys = null)
        {
            var requestJson = JsonConvert.SerializeObject(new
            {
                name,
                notes,
                stageKey,
                followerKeys
            }, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            int httpStatusCode;
            var json = Http.Post(ApiHandles.EditBox.Replace("{boxKey}", boxKey), requestJson, out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }
    }
}
