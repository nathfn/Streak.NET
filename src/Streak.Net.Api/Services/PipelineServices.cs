using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Streak.Net.Api.Enums;
using Streak.Net.Api.Models;
using Streak.Net.Api.Services.Raw;

namespace Streak.Net.Api.Services
{
    public class PipelineServices: ServicesBase
    {
        private readonly RawPipelineServices _rawPipelineServices;

        internal PipelineServices(string apiKey, string apiBaseUrl, bool includeRawResponse) : base(includeRawResponse)
        {
            _rawPipelineServices = new RawPipelineServices(apiKey, apiBaseUrl);
        }

        /// <summary>
        /// This call will give you access to all pipelines the user of this API key has access to. The stages and fields properties are embedded in the pipeline object for convenience, however, to update these properties you must use the respective endpoints listed in the Stages and Fields sections.
        /// </summary>
        /// <param name="sortBy">(optional) What order to sort the pipelines by. There are two valid sorts creationTimestamp and lastUpdatedTimestamp. Both are in descending order.</param>
        /// <returns></returns>
        public PipelineList ListAllPipelines(SortOptions sortBy = null)
        {
            var pipelineList = new PipelineList
            {
                RawApiResponse = _rawPipelineServices.ListAllPipelines(sortBy)
            };
            pipelineList.Pipelines = JsonConvert.DeserializeObject<List<Pipeline>>(pipelineList.RawApiResponse.Json);
            pipelineList.RawApiResponse = GetRawApiResponseOrNull(pipelineList.RawApiResponse);
            return pipelineList;
        }

        /// <summary>
        /// This call will give you a single pipeline given the key.
        /// </summary>
        /// <param name="pipelineKey">The key of the pipeline want returned</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Please specify a pipeline key!</exception>
        public Pipeline GetPipeline(string pipelineKey)
        {
            if (string.IsNullOrEmpty(pipelineKey))
                throw new ArgumentNullException(nameof(pipelineKey), "Please specify a pipeline key!");
            var rawResponse = _rawPipelineServices.GetPipeline(pipelineKey);
            var pipeline = JsonConvert.DeserializeObject<Pipeline>(rawResponse.Json);
            pipeline.RawApiResponse = GetRawApiResponseOrNull(rawResponse);
            return pipeline;
        }

        /// <summary>
        /// Creates the pipeline.
        /// </summary>
        /// <param name="name">The name of the pipeline you are creating</param>
        /// <param name="description">The description of the pipeline that is visible when viewing the pipeline.</param>
        /// <param name="orgWide">Whether the pipeline will be shared with all users in the organization (same domain in email address). (Optional)</param>
        /// <param name="fieldNamesAndTypes">The fields each box within the pipeline can have provided as a dictionary with key = name and value = type. Fields should be given as a comma-separated array of names and a comma-separated array of corresponding field types (of equal length). To modify after creation use the Field endpoint. (Convenience, Optional)</param>
        /// <param name="stageNames">The possible stages a box within a pipeline can be in. Stages should be given as a comma-separated array of names. To modify after creation use the Stage endpoint. (Convenience, Optional)</param>
        /// <returns></returns>
        public Pipeline CreatePipeline(string name, string description, bool orgWide, Dictionary<string, FieldType> fieldNamesAndTypes = null, string[] stageNames = null)
        {
            var rawResponse = _rawPipelineServices.CreatePipeline(name, description, orgWide,
                fieldNamesAndTypes?.Keys.ToArray(), fieldNamesAndTypes?.Values.Select(t => t.Value).ToArray(), stageNames);
            var pipeline = JsonConvert.DeserializeObject<Pipeline>(rawResponse.Json);
            pipeline.RawApiResponse = GetRawApiResponseOrNull(rawResponse);
            return pipeline;
        }

        /// <summary>
        /// This call lets you delete a pipeline. All associated data of a pipeline (like boxes) will be deleted as well.
        /// </summary>
        /// <param name="pipelineKey">The key of the pipeline to be deleted</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Please specify a pipeline key!</exception>
        public DeleteResponse DeletePipeline(string pipelineKey)
        {
            if (string.IsNullOrEmpty(pipelineKey))
                throw new ArgumentNullException(nameof(pipelineKey), "Please specify a pipeline key!");
            var rawResponse = _rawPipelineServices.DeletePipeline(pipelineKey);
            var deleteResponse = JsonConvert.DeserializeObject<DeleteResponse>(rawResponse.Json);
            deleteResponse.RawApiResponse = GetRawApiResponseOrNull(rawResponse);
            return deleteResponse;
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
        public Pipeline EditPipeline(string pipelineKey, string name = null, string description = null,
            string[] stageOrder = null, bool? orgWide = null, List<AclEntry> aclEntries = null)
        {
            var rawResponse = _rawPipelineServices.EditPipeline(pipelineKey, name, description, stageOrder, orgWide, aclEntries);
            var pipeline = JsonConvert.DeserializeObject<Pipeline>(rawResponse.Json);
            pipeline.RawApiResponse = GetRawApiResponseOrNull(rawResponse);
            return pipeline;
        }
    }
}
