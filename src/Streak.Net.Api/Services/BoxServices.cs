using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Streak.Net.Api.Enums;
using Streak.Net.Api.Models;
using Streak.Net.Api.Services.Raw;

namespace Streak.Net.Api.Services
{
    public class BoxServices: ServicesBase
    {
        private readonly RawBoxServices _rawBoxServices;

        internal BoxServices(string apiKey, string apiBaseUrl, bool includeRawResponse) : base(includeRawResponse)
        {
            _rawBoxServices = new RawBoxServices(apiKey, apiBaseUrl);
        }

        /// <summary>
        /// This call lets you get all boxes that the current user has access to. The boxes returned here are across all pipelines a user has access to. This is a fairly expensive call so there is a lower API quota limit. If possible, get boxes using the pipeline key instead.
        /// </summary>
        /// <returns></returns>
        public BoxList ListAllBoxesUserHasAccessTo()
        {
            var boxList = new BoxList
            {
                RawApiResponse = _rawBoxServices.ListAllBoxesUserHasAccessTo()
            };
            boxList.Boxes = JsonConvert.DeserializeObject<List<Box>>(boxList.RawApiResponse.Json);
            boxList.RawApiResponse = GetRawApiResponseOrNull(boxList.RawApiResponse);
            return boxList;
        }

        /// <summary>
        /// This call lets you get all boxes contained in the specified pipeline.
        /// </summary>
        /// <param name="pipelineKey">The key of the pipeline for which you want the boxes listed</param>
        /// <param name="sortOptions">What order to sort the boxes by. There are two valid sorts creationTimestamp and lastUpdatedTimestamp. Both are in descending order. (optional)</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Please specify a pipeline key!</exception>
        public BoxList ListAllBoxesInPipeline(string pipelineKey, SortOptions sortOptions = null)
        {
            if (string.IsNullOrEmpty(pipelineKey))
                throw new ArgumentNullException(nameof(pipelineKey), "Please specify a pipeline key!");
            var boxList = new BoxList
            {
                RawApiResponse = _rawBoxServices.ListAllBoxesInPipeline(pipelineKey, sortOptions)
            };
            boxList.Boxes = JsonConvert.DeserializeObject<List<Box>>(boxList.RawApiResponse.Json);
            boxList.RawApiResponse = GetRawApiResponseOrNull(boxList.RawApiResponse);
            return boxList;
        }

        /// <summary>
        /// This call gives you a specific box based on the key you provide.
        /// </summary>
        /// <param name="pipelineKey">The key of the pipeline this box should belong to</param>
        /// <param name="name">The name of this box</param>
        /// <param name="stageKey">The stage of this box (Optional)</param>
        /// <returns></returns>
        public Box CreateBox(string pipelineKey, string name, string stageKey = null)
        {
            if (string.IsNullOrEmpty(pipelineKey))
                throw new ArgumentNullException(nameof(pipelineKey), "Please specify a pipeline key!");
            var rawResponse = _rawBoxServices.CreateBox(pipelineKey, name, stageKey);
            var box = JsonConvert.DeserializeObject<Box>(rawResponse.Json);
            box.RawApiResponse = GetRawApiResponseOrNull(rawResponse);
            return box;
        }

        /// <summary>
        ///This call lets you delete a particular box. It also deletes all of the relevant data such as files, emails, and tasks for that box.
        /// </summary>
        /// <param name="boxKey">The key of the box</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Please specify a box key!</exception>
        public DeleteResponse DeleteBox(string boxKey)
        {
            if (string.IsNullOrEmpty(boxKey))
                throw new ArgumentNullException(nameof(boxKey), "Please specify a box key!");
            var rawResponse = _rawBoxServices.DeleteBox(boxKey);
            var deleteResponse = JsonConvert.DeserializeObject<DeleteResponse>(rawResponse.Json);
            deleteResponse.RawApiResponse = GetRawApiResponseOrNull(rawResponse);
            return deleteResponse;
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
        public Box EditBox(string boxKey, string name = null, string notes = null, string stageKey = null, string[] followerKeys = null)
        {
            var rawResponse = _rawBoxServices.EditBox(boxKey, name, notes, stageKey, followerKeys);
            var box = JsonConvert.DeserializeObject<Box>(rawResponse.Json);
            box.RawApiResponse = GetRawApiResponseOrNull(rawResponse);
            return box;
        }
    }
}
