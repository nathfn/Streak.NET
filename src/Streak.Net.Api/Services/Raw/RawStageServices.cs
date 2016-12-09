using System;
using System.Web;
using Newtonsoft.Json;
using Streak.Net.Api.Models;

namespace Streak.Net.Api.Services.Raw
{
    public class RawStageServices: RawServicesBase
    {
        internal RawStageServices(string apiKey, string apiBaseUrl) : base(apiKey, apiBaseUrl){ }

        /// <summary>
        /// This call lists the stages defined in a pipeline. Remember, this is only the definition of the stages - to change what stage a box is in, simply update the box with a new stageKey.
        /// </summary>
        /// <param name="pipelineKey">The pipeline key.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Please specify a pipeline key!</exception>
        public RawApiResponse ListStagesInPipeline(string pipelineKey)
        {
            if (string.IsNullOrEmpty(pipelineKey))
                throw new ArgumentNullException(nameof(pipelineKey), "Please specify a pipeline key!");
            int httpStatusCode;
            var json = Http.Get(ApiHandles.ListAllStagesInPipeline.Replace("{pipelineKey}", pipelineKey),
                out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }

        /// <summary>
        /// This call gives you a specific stage defined in a pipeline
        /// </summary>
        /// <param name="pipelineKey">The key of the pipeline</param>
        /// <param name="stageKey">The key of the stage</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Please specify a pipeline key!</exception>
        /// <exception cref="ArgumentNullException">Please specify a pipeline key!</exception>
        public RawApiResponse GetStage(string pipelineKey, string stageKey)
        {
            if (string.IsNullOrEmpty(pipelineKey))
                throw new ArgumentNullException(nameof(pipelineKey), "Please specify a pipeline key!");
            if (string.IsNullOrEmpty(stageKey))
                throw new ArgumentNullException(nameof(stageKey), "Please specify a stage key!");
            var handle = ApiHandles.GetStage.Replace("{pipelineKey}", pipelineKey).Replace("{stageKey}", stageKey);
            int httpStatusCode;
            var json = Http.Get(handle,
                out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }

        /// <summary>
        /// This call lets you create a stage defined in a pipeline.
        /// </summary>
        /// <param name="pipelineKey">The key of the pipeline this stage should belong to</param>
        /// <param name="name">The name of the stage you'd like to add to the pipeline</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Please specify a pipeline key!</exception>
        /// <exception cref="ArgumentNullException">Please specify a pipeline key!</exception>
        public RawApiResponse CreateStage(string pipelineKey, string name)
        {
            if (string.IsNullOrEmpty(pipelineKey))
                throw new ArgumentNullException(nameof(pipelineKey), "Please specify a pipeline key!");
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name), "Please specify a name!");
            var collection = HttpUtility.ParseQueryString(string.Empty);
            collection.Add("name", name);
            int httpStatusCode;
            var json = Http.Put(ApiHandles.CreateStage.Replace("{pipelineKey}", pipelineKey), collection.ToString(), out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }

        /// <summary>
        /// This call lets you delete a stage defined in a pipeline. This call will only suceed if there are no boxes tagged with the key of this stage, else it throws a 400.
        /// </summary>
        /// <param name="pipelineKey">The pipeline key.</param>
        /// <param name="stageKey">The stage key.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Please specify a pipeline key!</exception>
        /// <exception cref="ArgumentNullException">Please specify a Stage key!</exception>
        public RawApiResponse DeleteStage(string pipelineKey, string stageKey)
        {
            if (string.IsNullOrEmpty(pipelineKey))
                throw new ArgumentNullException(nameof(pipelineKey), "Please specify a pipeline key!");
            if (string.IsNullOrEmpty(stageKey))
                throw new ArgumentNullException(nameof(stageKey), "Please specify a stage key!");
            int httpStatusCode;
            var json = Http.Delete(ApiHandles.DeleteStage.Replace("{pipelineKey}", pipelineKey).Replace("{stageKey}", stageKey), out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }

        /// <summary>
        /// This call lets you edit the properties of a Stage.
        /// </summary>
        /// <param name="pipelineKey">The pipeline key.</param>
        /// <param name="stageKey">The key of the stage that this Stage should be in. A list of valid stage keys can be found from the pipeline that this Stage belongs to (optional)</param>
        /// <param name="name">The name of the Stage (optional)</param>
        /// <returns></returns>
        public RawApiResponse EditStage(string pipelineKey, string stageKey, string name)
        {
            if (string.IsNullOrEmpty(pipelineKey))
                throw new ArgumentNullException(nameof(pipelineKey), "Please specify a pipeline key!");
            if (string.IsNullOrEmpty(stageKey))
                throw new ArgumentNullException(nameof(stageKey), "Please specify a stage key!");
            var requestJson = JsonConvert.SerializeObject(new
            {
                name
            }, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            int httpStatusCode;
            var json = Http.Post(ApiHandles.EditStage.Replace("{pipelineKey}", pipelineKey).Replace("{stageKey}", stageKey), requestJson, out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }
    }
}
