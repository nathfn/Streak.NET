using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using Streak.Net.Api.Models;

namespace Streak.Net.Api.Services.Raw
{
    public class RawTaskService: RawServicesBase
    {
        internal RawTaskService(string apiKey, string apiBaseUrl) : base(apiKey, apiBaseUrl){ }

        /// <summary>
        /// This call lets you get all the tasks associated with a particular box.
        /// </summary>
        /// <param name="boxKey">The key of the box for which you want the tasks listed</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Please specify a pipeline key!</exception>
        public RawApiResponse ListTasksInPipeline(string boxKey)
        {
            if (string.IsNullOrEmpty(boxKey))
                throw new ArgumentNullException(nameof(boxKey), "Please specify a box key!");
            int httpStatusCode;
            var json = Http.Get(ApiHandles.ListTasks.Replace("{boxKey}", boxKey),
                out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }

        /// <summary>
        /// This call lets you get a specific task.
        /// </summary>
        /// <param name="taskKey">The key of the task</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Please specify a pipeline key!</exception>
        /// <exception cref="ArgumentNullException">Please specify a pipeline key!</exception>
        public RawApiResponse GetTask(string taskKey)
        {
            if (string.IsNullOrEmpty(taskKey))
                throw new ArgumentNullException(nameof(taskKey), "Please specify a task key!");
            var handle = ApiHandles.GetTask.Replace("{taskKey}", taskKey);
            int httpStatusCode;
            var json = Http.Get(handle,
                out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }

        /// <summary>
        /// This call lets you create a task.
        /// </summary>
        /// <param name="boxKey">The key of the box that this task should be associated with.</param>
        /// <param name="text">The text for the task. When the user is reminded (by email) of the associated box, the message text is also presented.</param>
        /// <param name="dueDate">The due date of this reminder. This is specified using number of milliseconds since epoch.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Please specify a pipeline key!</exception>
        /// <exception cref="ArgumentNullException">Please specify a pipeline key!</exception>
        public RawApiResponse CreateTask(string boxKey, string text, long dueDate)
        {
            if (string.IsNullOrEmpty(boxKey))
                throw new ArgumentNullException(nameof(boxKey), "Please specify a box key!");
            var collection = HttpUtility.ParseQueryString(string.Empty);
            collection.Add("text", text);
            collection.Add("dueDate", dueDate.ToString());
            int httpStatusCode;
            var json = Http.Put(ApiHandles.CreateTask.Replace("{boxKey}", boxKey), collection.ToString(), out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }

        /// <summary>
        /// This call lets you delete a specific task.
        /// </summary>
        /// <param name="taskKey">The task key.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Please specify a pipeline key!</exception>
        /// <exception cref="ArgumentNullException">Please specify a Task key!</exception>
        public RawApiResponse DeleteTask(string taskKey)
        {
            if (string.IsNullOrEmpty(taskKey))
                throw new ArgumentNullException(nameof(taskKey), "Please specify a task key!");
            int httpStatusCode;
            var json = Http.Delete(ApiHandles.DeleteTask.Replace("{taskKey}", taskKey), out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }

        /// <summary>
        /// This call lets you edit a specific task.
        /// </summary>
        /// <param name="taskKey">The key of the Task that this Task should be in. A list of valid Task keys can be found from the pipeline that this Task belongs to (optional)</param>
        /// <param name="text">A message attached to the task. When the user is reminded (by email) of the associated box, the message text is also presented. (optional)</param>
        /// <param name="dueDate">The date this reminder should be sent to the user. This is specified using number of milliseconds since epoch. (optional)</param>
        /// <param name="assignedToSharingEntries">Who the task is assigned to</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Please specify a task key!</exception>
        public RawApiResponse EditTask(string taskKey, List<AclEntry> assignedToSharingEntries, string text = null, long? dueDate = null)
        {
            if (string.IsNullOrEmpty(taskKey))
                throw new ArgumentNullException(nameof(taskKey), "Please specify a task key!");
            var requestJson = JsonConvert.SerializeObject(new
            {
                text,
                dueDate,
                assignedToSharingEntries
            }, new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});
            int httpStatusCode;
            var json = Http.Post(ApiHandles.EditTask.Replace("{taskKey}", taskKey), requestJson, out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }
    }
}
