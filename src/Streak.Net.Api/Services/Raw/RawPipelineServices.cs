using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using Streak.Net.Api.Enums;
using Streak.Net.Api.Extensions;
using Streak.Net.Api.Models;

namespace Streak.Net.Api.Services.Raw
{
    public class RawPipelineServices: RawServicesBase
    {
        internal RawPipelineServices(string apiKey, string apiBaseUrl) : base(apiKey, apiBaseUrl){}

        /// <summary>
        /// This call will give you access to all pipelines the user of this API key has access to. The stages and fields properties are embedded in the pipeline object for convenience, however, to update these properties you must use the respective endpoints listed in the Stages and Fields sections.
        /// </summary>
        /// <param name="sortBy">The sort by.</param>
        /// <returns></returns>
        public RawApiResponse ListAllPipelines(SortOptions sortBy = null)
        {
            var handle = ApiHandles.ListAllPipelines;
            if (sortBy != null)
            {
                handle += "?sortBy=" + sortBy.Value;
            }
            int httpStatusCode;
            var json = Http.Get(handle,
                out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }

        /// <summary>
        /// This call will give you a single pipeline given the key.
        /// </summary>
        /// <param name="pipelineKey">The key of the pipeline want returned</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Please specify a pipeline key!</exception>
        public RawApiResponse GetPipeline(string pipelineKey)
        {
            if (string.IsNullOrEmpty(pipelineKey))
                throw new ArgumentNullException(nameof(pipelineKey), "Please specify a pipeline key!");
            int httpStatusCode;
            var json = Http.Get(ApiHandles.GetPipeline.Replace("{pipelineKey}", pipelineKey), out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }

        /// <summary>
        /// This call will give you a single pipeline given the key.
        /// </summary>
        /// <param name="name">The name of the pipeline you are creating</param>
        /// <param name="description">The description of the pipeline that is visible when viewing the pipeline.</param>
        /// <param name="orgWide">Whether the pipeline will be shared with all users in the organization (same domain in email address). (Optional)</param>
        /// <param name="fieldNames">The fields each box within the pipeline can have. Fields should be given as a comma-separated array of names and a comma-separated array of corresponding field types (of equal length). To modify after creation use the Field endpoint. (Convenience, Optional)</param>
        /// <param name="fieldTypes">The fields each box within the pipeline can have. Fields should be given as a comma-separated array of names and a comma-separated array of corresponding field types (of equal length). To modify after creation use the Field endpoint. (Convenience, Optional)</param>
        /// <param name="stageNames">The possible stages a box within a pipeline can be in. Stages should be given as a comma-separated array of names. To modify after creation use the Stage endpoint. (Convenience, Optional)</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Please specify a JSON object in a string for creating a pipeline</exception>
        public RawApiResponse CreatePipeline(string name, string description, bool orgWide, string[] fieldNames = null, string[] fieldTypes = null, string[] stageNames = null)
        {
            var collection = HttpUtility.ParseQueryString(string.Empty);
            collection.Add("name", name);
            collection.Add("description", description);
            collection.Add("orgWide", orgWide.ToLowerString());
            collection.Add("fieldNames", string.Join(",", fieldNames ?? new string[0]));
            collection.Add("fieldTypes", string.Join(",", fieldTypes ?? new string[0]));
            collection.Add("stageNames", string.Join(",", stageNames ?? new string[0]));
            int httpStatusCode;
            var json = Http.Put(ApiHandles.CreatePipeline, collection.ToString(), out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }

        /// <summary>
        /// This call lets you delete a pipeline. All associated data of a pipeline (like boxes) will be deleted as well.
        /// </summary>
        /// <param name="pipelineKey">The key of the pipeline to be deleted</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Please specify a pipeline key!</exception>
        public RawApiResponse DeletePipeline(string pipelineKey)
        {
            if (string.IsNullOrEmpty(pipelineKey))
                throw new ArgumentNullException(nameof(pipelineKey), "Please specify a pipeline key!");
            int httpStatusCode;
            var json = Http.Delete(ApiHandles.DeletePipeline.Replace("{pipelineKey}", pipelineKey), out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }

        /// <summary>
        /// This call lets you edit the properties of a pipeline.
        /// </summary>
        /// <param name="pipelineKey">The key of the pipeline to be edited</param>
        /// <param name="name">The name of the pipeline (optional)</param>
        /// <param name="description">The description of the pipeline (optional)</param>
        /// <param name="stageOrder">A JSON array containing ordering of stage keys. The elements of this array are allowed to be re-ordered only. The order of this array affects the UI of the pipeline in the Web UI. (optional)</param>
        /// <param name="orgWide">A boolean indicating whether this pipeline is shared to everyone in the organization. For Google apps customers this means any other user with the same domain in their email address. This field has no effect for regular Gmail users. (optional)</param>
        /// <param name="aclEntries">This is a JSON array of objects representing who the pipeline is currently shared with. You can add and remove objects in a single update. Each object in this array is required to have 1 property - email. Adding a user to the aclEntries causes them to receive an email informing them that the pipeline has been shared with them. (optional)</param>
        /// <returns></returns>
        public RawApiResponse EditPipeline(string pipelineKey, string name = null, string description = null,
            string[] stageOrder = null, bool? orgWide = null, List<AclEntry> aclEntries = null)
        {
            var requestJson = JsonConvert.SerializeObject(new
            {
                name,
                description,
                stageOrder,
                orgWide,
                aclEntries
            }, new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});
            int httpStatusCode;
            var json = Http.Post(ApiHandles.EditPipeline.Replace("{pipelineKey}", pipelineKey), requestJson, out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }
    }
}
