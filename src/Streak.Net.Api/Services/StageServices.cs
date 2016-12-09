using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Streak.Net.Api.Models;
using Streak.Net.Api.Services.Raw;

namespace Streak.Net.Api.Services
{
    public class StageServices: ServicesBase
    {
        private readonly RawStageServices _rawStageServices;

        internal StageServices(string apiKey, string apiBaseUrl, bool includeRawResponse) : base(includeRawResponse)
        {
            _rawStageServices = new RawStageServices(apiKey, apiBaseUrl);
        }

        /// <summary>
        /// This call lists the stages defined in a pipeline. Remember, this is only the definition of the stages - to change what stage a box is in, simply update the box with a new stageKey.
        /// </summary>
        /// <returns></returns>
        public StageList ListStagesInPipeline(string pipelineKey)
        {
            if (string.IsNullOrEmpty(pipelineKey))
                throw new ArgumentNullException(nameof(pipelineKey), "Please specify a pipeline key!");
            var stageList = new StageList
            {
                RawApiResponse = _rawStageServices.ListStagesInPipeline(pipelineKey)
            };
            stageList.Stages = JsonConvert.DeserializeObject<Dictionary<string, Stage>>(stageList.RawApiResponse.Json);
            stageList.RawApiResponse = GetRawApiResponseOrNull(stageList.RawApiResponse);
            return stageList;
        }

        /// <summary>
        /// This call gives you a specific stage defined in a pipeline
        /// </summary>
        /// <param name="pipelineKey">The key of the pipeline</param>
        /// <param name="stageKey">The key of the stage</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Please specify a pipeline key!</exception>
        /// <exception cref="ArgumentNullException">Please specify a pipeline key!</exception>
        public Stage GetStage(string pipelineKey, string stageKey)
        {
            if (string.IsNullOrEmpty(pipelineKey))
                throw new ArgumentNullException(nameof(pipelineKey), "Please specify a pipeline key!");
            if (string.IsNullOrEmpty(stageKey))
                throw new ArgumentNullException(nameof(stageKey), "Please specify a stage key!");
            var rawResponse = _rawStageServices.GetStage(pipelineKey, stageKey);
            var stage = JsonConvert.DeserializeObject<Stage>(rawResponse.Json);
            stage.RawApiResponse = GetRawApiResponseOrNull(rawResponse);
            return stage;
        }

        /// <summary>
        /// This call lets you create a stage defined in a pipeline.
        /// </summary>
        /// <param name="pipelineKey">The key of the pipeline this stage should belong to</param>
        /// <param name="name">The name of the stage you'd like to add to the pipeline</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Please specify a pipeline key!</exception>
        /// <exception cref="ArgumentNullException">Please specify a pipeline key!</exception>
        public Stage CreateStage(string pipelineKey, string name)
        {
            if (string.IsNullOrEmpty(pipelineKey))
                throw new ArgumentNullException(nameof(pipelineKey), "Please specify a pipeline key!");
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name), "Please specify a name!");
            var rawResponse = _rawStageServices.CreateStage(pipelineKey, name);
            var stage = JsonConvert.DeserializeObject<Stage>(rawResponse.Json);
            stage.RawApiResponse = GetRawApiResponseOrNull(rawResponse);
            return stage;
        }

        /// <summary>
        /// This call lets you delete a stage defined in a pipeline. This call will only suceed if there are no boxes tagged with the key of this stage, else it throws a 400.
        /// </summary>
        /// <param name="pipelineKey">The pipeline key.</param>
        /// <param name="stageKey">The stage key.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Please specify a pipeline key!</exception>
        /// <exception cref="ArgumentNullException">Please specify a Stage key!</exception>
        public DeleteResponse DeleteStage(string pipelineKey, string stageKey)
        {
            if (string.IsNullOrEmpty(pipelineKey))
                throw new ArgumentNullException(nameof(pipelineKey), "Please specify a pipeline key!");
            if (string.IsNullOrEmpty(stageKey))
                throw new ArgumentNullException(nameof(stageKey), "Please specify a stage key!");
            var rawResponse = _rawStageServices.DeleteStage(pipelineKey, stageKey);
            var deleteResponse = JsonConvert.DeserializeObject<DeleteResponse>(rawResponse.Json);
            deleteResponse.RawApiResponse = GetRawApiResponseOrNull(rawResponse);
            return deleteResponse;
        }

        /// <summary>
        /// This call lets you edit the properties of a Stage.
        /// </summary>
        /// <param name="pipelineKey">The pipeline key.</param>
        /// <param name="stageKey">The key of the stage that this Stage should be in. A list of valid stage keys can be found from the pipeline that this Stage belongs to (optional)</param>
        /// <param name="name">The name of the Stage (optional)</param>
        /// <returns></returns>
        public Stage EditStage(string pipelineKey, string stageKey, string name)
        {
            if (string.IsNullOrEmpty(pipelineKey))
                throw new ArgumentNullException(nameof(pipelineKey), "Please specify a pipeline key!");
            if (string.IsNullOrEmpty(stageKey))
                throw new ArgumentNullException(nameof(stageKey), "Please specify a stage key!");
            var rawResponse = _rawStageServices.EditStage(pipelineKey, stageKey, name);
            var stage = JsonConvert.DeserializeObject<Stage>(rawResponse.Json);
            stage.RawApiResponse = GetRawApiResponseOrNull(rawResponse);
            return stage;
        }
    }
}
