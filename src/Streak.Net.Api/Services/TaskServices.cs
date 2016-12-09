using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Streak.Net.Api.Models;
using Streak.Net.Api.Services.Raw;

namespace Streak.Net.Api.Services
{
    public class TaskServices: ServicesBase
    {
        private readonly RawTaskService _rawTaskService;

        internal TaskServices(string apiKey, string apiBaseUrl, bool includeRawResponse) : base(includeRawResponse)
        {
            _rawTaskService = new RawTaskService(apiKey, apiBaseUrl);
        }

        /// <summary>
        /// This call lets you get all the tasks associated with a particular box.
        /// </summary>
        /// <param name="boxKey">The key of the box for which you want the tasks listed</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Please specify a pipeline key!</exception>
        public TaskList ListTasksInPipeline(string boxKey)
        {
            if (string.IsNullOrEmpty(boxKey))
                throw new ArgumentNullException(nameof(boxKey), "Please specify a box key!");
            var taskList = new TaskList
            {
                RawApiResponse = _rawTaskService.ListTasksInPipeline(boxKey)
            };
            taskList.Tasks = JsonConvert.DeserializeObject<List<Task>>(taskList.RawApiResponse.Json);
            taskList.RawApiResponse = GetRawApiResponseOrNull(taskList.RawApiResponse);
            return taskList;
        }

        /// <summary>
        /// This call lets you get a specific task.
        /// </summary>
        /// <param name="taskKey">The key of the task</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Please specify a pipeline key!</exception>
        /// <exception cref="ArgumentNullException">Please specify a pipeline key!</exception>
        public Task GetTask(string taskKey)
        {
            if (string.IsNullOrEmpty(taskKey))
                throw new ArgumentNullException(nameof(taskKey), "Please specify a task key!");
            var rawResponse = _rawTaskService.GetTask(taskKey);
            var task = JsonConvert.DeserializeObject<Task>(rawResponse.Json);
            task.RawApiResponse = GetRawApiResponseOrNull(rawResponse);
            return task;
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
        public Task CreateTask(string boxKey, string text, long dueDate)
        {
            if (string.IsNullOrEmpty(boxKey))
                throw new ArgumentNullException(nameof(boxKey), "Please specify a box key!");
            var rawResponse = _rawTaskService.CreateTask(boxKey,text, dueDate);
            var task = JsonConvert.DeserializeObject<Task>(rawResponse.Json);
            task.RawApiResponse = GetRawApiResponseOrNull(rawResponse);
            return task;
        }

        /// <summary>
        /// This call lets you delete a specific task.
        /// </summary>
        /// <param name="taskKey">The task key.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Please specify a pipeline key!</exception>
        /// <exception cref="ArgumentNullException">Please specify a Task key!</exception>
        public DeleteResponse DeleteTask(string taskKey)
        {
            if (string.IsNullOrEmpty(taskKey))
                throw new ArgumentNullException(nameof(taskKey), "Please specify a task key!");
            var rawResponse = _rawTaskService.DeleteTask(taskKey);
            var deleteResponse = JsonConvert.DeserializeObject<DeleteResponse>(rawResponse.Json);
            deleteResponse.RawApiResponse = GetRawApiResponseOrNull(rawResponse);
            return deleteResponse;
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
        public Task EditTask(string taskKey, List<AclEntry> assignedToSharingEntries, string text = null, long? dueDate = null)
        {
            if (string.IsNullOrEmpty(taskKey))
                throw new ArgumentNullException(nameof(taskKey), "Please specify a task key!");
            var rawResponse = _rawTaskService.EditTask(taskKey, assignedToSharingEntries, text, dueDate);
            var task = JsonConvert.DeserializeObject<Task>(rawResponse.Json);
            task.RawApiResponse = GetRawApiResponseOrNull(rawResponse);
            return task;
        }
    }
}
