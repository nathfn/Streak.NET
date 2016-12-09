using System;
using System.Web;
using Newtonsoft.Json;
using Streak.Net.Api.Enums;
using Streak.Net.Api.Models;

namespace Streak.Net.Api.Services.Raw
{
    public class RawFieldServices: RawServicesBase
    {
        internal RawFieldServices(string apiKey, string apiBaseUrl) : base(apiKey, apiBaseUrl){ }

        /// <summary>
        /// This call lists the fields defined in a pipeline. Remember, this is only the definition of the fields - to change the value of the field for a specific box, use the edit field for box endpoint.
        /// </summary>
        /// <param name="pipelineKey">The key of the pipeline</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Please specify a pipeline key!</exception>
        public RawApiResponse ListFieldsInPipeline(string pipelineKey)
        {
            if (string.IsNullOrEmpty(pipelineKey))
                throw new ArgumentNullException(nameof(pipelineKey), "Please specify a pipeline key!");
            int httpStatusCode;
            var json = Http.Get(ApiHandles.ListAllFieldsInPipeline.Replace("{pipelineKey}", pipelineKey),
                out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }

        /// <summary>
        /// This call lets you get a specific field defined in a pipeline.
        /// </summary>
        /// <param name="pipelineKey">The key of the pipeline</param>
        /// <param name="fieldKey">The key of the Field</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Please specify a pipeline key!</exception>
        /// <exception cref="ArgumentNullException">Please specify a pipeline key!</exception>
        public RawApiResponse GetField(string pipelineKey, string fieldKey)
        {
            if (string.IsNullOrEmpty(pipelineKey))
                throw new ArgumentNullException(nameof(pipelineKey), "Please specify a pipeline key!");
            if (string.IsNullOrEmpty(fieldKey))
                throw new ArgumentNullException(nameof(fieldKey), "Please specify a field key!");
            var handle = ApiHandles.GetField.Replace("{pipelineKey}", pipelineKey).Replace("{fieldKey}", fieldKey);
            int httpStatusCode;
            var json = Http.Get(handle,
                out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }

        /// <summary>
        /// This call lets you create a field for a pipeline. This defines the field in the pipeline so that you can add values for that field for each box in the pipeline.
        /// </summary>
        /// <param name="pipelineKey">The key of the pipeline this field should belong to</param>
        /// <param name="name">The name of the field you'd like to add to the pipeline</param>
        /// <param name="fieldType">The type of the field, can be any of: TEXT_INPUT, DATE or PERSON</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Please specify a pipeline key!</exception>
        /// <exception cref="ArgumentNullException">Please specify a pipeline key!</exception>
        public RawApiResponse CreateField(string pipelineKey, string name, FieldType fieldType)
        {
            if (string.IsNullOrEmpty(pipelineKey))
                throw new ArgumentNullException(nameof(pipelineKey), "Please specify a pipeline key!");
            var collection = HttpUtility.ParseQueryString(string.Empty);
            collection.Add("name", name);
            collection.Add("type", fieldType.Value);
            int httpStatusCode;
            var json = Http.Put(ApiHandles.CreateField.Replace("{pipelineKey}", pipelineKey), collection.ToString(), out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }

        /// <summary>
        /// This call lets you delete a field defined in a pipeline. Note: this will also remove the values of this field for every box in the pipeline.
        /// </summary>
        /// <param name="pipelineKey">The pipeline key.</param>
        /// <param name="fieldKey">The Field key.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Please specify a pipeline key!</exception>
        /// <exception cref="ArgumentNullException">Please specify a Field key!</exception>
        public RawApiResponse DeleteField(string pipelineKey, string fieldKey)
        {
            if (string.IsNullOrEmpty(pipelineKey))
                throw new ArgumentNullException(nameof(pipelineKey), "Please specify a pipeline key!");
            if (string.IsNullOrEmpty(fieldKey))
                throw new ArgumentNullException(nameof(fieldKey), "Please specify a Field key!");
            int httpStatusCode;
            var json = Http.Delete(ApiHandles.DeleteField.Replace("{pipelineKey}", pipelineKey).Replace("{fieldKey}", fieldKey), out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }

        /// <summary>
        /// This call lets you edit the name of a field. Note that editing the type of a field is not currently permitted and will throw a 400 error.
        /// </summary>
        /// <param name="pipelineKey">The pipeline key.</param>
        /// <param name="fieldKey">The key of the Field that this Field should be in. A list of valid Field keys can be found from the pipeline that this Field belongs to (optional)</param>
        /// <param name="name">The new name of the field</param>
        /// <returns></returns>
        public RawApiResponse EditField(string pipelineKey, string fieldKey, string name)
        {
            if (string.IsNullOrEmpty(pipelineKey))
                throw new ArgumentNullException(nameof(pipelineKey), "Please specify a pipeline key!");
            if (string.IsNullOrEmpty(fieldKey))
                throw new ArgumentNullException(nameof(fieldKey), "Please specify a Field key!");
            var requestJson = JsonConvert.SerializeObject(new
            {
                name
            }, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            int httpStatusCode;
            var json = Http.Post(ApiHandles.EditField.Replace("{pipelineKey}", pipelineKey).Replace("{fieldKey}", fieldKey), requestJson, out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }

        /// <summary>
        /// This call lists the field values for the box specified.
        /// Note: for fields that have no value set, the value property is ommitted from the returned JSON
        /// </summary>
        /// <param name="boxKey">The key of the box</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Please specify a box key!</exception>
        public RawApiResponse ListFieldValuesForBox(string boxKey)
        {
            if (string.IsNullOrEmpty(boxKey))
                throw new ArgumentNullException(nameof(boxKey), "Please specify a box key!");
            var handle = ApiHandles.ListFieldValues.Replace("{boxKey}", boxKey);
            int httpStatusCode;
            var json = Http.Get(handle,
                out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }

        /// <summary>
        /// This call gets a specific field value for the box specified.
        /// </summary>
        /// <param name="boxKey">The key of the box</param>
        /// <param name="fieldKey">The key of the field</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// Please specify a box key!
        /// or
        /// Please specify a field key!
        /// </exception>
        public RawApiResponse GetFieldValueForBox(string boxKey, string fieldKey)
        {
            if (string.IsNullOrEmpty(boxKey))
                throw new ArgumentNullException(nameof(boxKey), "Please specify a box key!");
            if (string.IsNullOrEmpty(fieldKey))
                throw new ArgumentNullException(nameof(boxKey), "Please specify a field key!");
            var handle = ApiHandles.GetFieldValue.Replace("{boxKey}", boxKey).Replace("{fieldKey}", fieldKey);
            int httpStatusCode;
            var json = Http.Get(handle,
                out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }

        /// <summary>
        /// This call lets you edit the value of a field for a particular box.
        /// </summary>
        /// <param name="boxKey">The key of the box</param>
        /// <param name="fieldKey">	The name of the field</param>
        /// <param name="value">The new value for the field.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// Please specify a box key!
        /// or
        /// Please specify a field key!
        /// </exception>
        public RawApiResponse EditFieldValueForBox(string boxKey, string fieldKey, string value)
        {
            if (string.IsNullOrEmpty(boxKey))
                throw new ArgumentNullException(nameof(boxKey), "Please specify a box key!");
            if (string.IsNullOrEmpty(fieldKey))
                throw new ArgumentNullException(nameof(boxKey), "Please specify a field key!");
            var requestJson = JsonConvert.SerializeObject(new
            {
                value
            }, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            int httpStatusCode;
            var json = Http.Post(ApiHandles.EditFieldValue.Replace("{boxKey}", boxKey).Replace("{fieldKey}", fieldKey), requestJson, out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }
    }
}
