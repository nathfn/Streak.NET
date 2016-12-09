namespace Streak.Net.Api.Config
{
    public class ApiHandles
    {
        #region Users

        public string GetCurrentUser => "/users/me";
        public string GetUser => "/users/{userKey}";

        #endregion

        #region Pipelines

        public string ListAllPipelines => "/pipelines";
        public string GetPipeline => "/pipelines/{pipelineKey}";
        public string DeletePipeline => "/pipelines/{pipelineKey}";
        public string CreatePipeline => "/pipelines";
        public string EditPipeline => "/pipelines/{pipelineKey}";

        #endregion

        #region Boxes

        public string ListAllBoxesUserHasAccessTo = "/boxes";
        public string ListAllBoxesInPipeline = "/pipelines/{pipelineKey}/boxes";
        public string CreateBox = "/pipelines/{pipelineKey}/boxes";
        public string DeleteBox = "/boxes/{boxKey}";
        public string EditBox = "/boxes/{boxKey}";

        #endregion

        #region Stages 

        public string ListAllStagesInPipeline = "/pipelines/{pipelineKey}/stages";
        public string GetStage = "/pipelines/{pipelineKey}/stages/{stageKey}";
        public string CreateStage = "/pipelines/{pipelineKey}/stages";
        public string DeleteStage = "/pipelines/{pipelineKey}/stages/{stageKey}";
        public string EditStage = "/pipelines/{pipelineKey}/stages/{stageKey}";

        #endregion

        #region Fields

        public string ListAllFieldsInPipeline = "/pipelines/{pipelineKey}/fields";
        public string GetField = "/pipelines/{pipelineKey}/fields/{fieldKey}";
        public string CreateField = "/pipelines/{pipelineKey}/fields";
        public string DeleteField = "/pipelines/{pipelineKey}/fields/{fieldKey}";
        public string EditField = "/pipelines/{pipelineKey}/fields/{fieldKey}";
        public string ListFieldValues = "/boxes/{boxKey}/fields";
        public string GetFieldValue = "/boxes/{boxKey}/fields/{fieldKey}";
        public string EditFieldValue = "/boxes/{boxKey}/fields/{fieldKey}";

        #endregion

        #region Tasks

        public string ListTasks = "/api/v2/boxes/{boxKey}/tasks";
        public string GetTask = "/api/v2/boxes/{boxKey}/tasks";
        public string CreateTask = "/api/v2/boxes/{boxKey}/tasks";
        public string DeleteTask = "/tasks/{taskKey}";
        public string EditTask = "/api/v2/tasks/{taskKey}";

        #endregion

        #region Files

        public string ListFiles = "/boxes/{boxKey}/files";
        public string GetFile = "/files/{fileKey}";
        public string GetFileContents = "/files/{fileKey}/contents";
        public string GetFileLink = "/files/{fileKey}/link";

        #endregion

        #region Threads

        public string ListThreads = "/boxes/{boxKey}/threads";
        public string GetThread = "/threads/{threadKey}";

        #endregion

        #region Comments

        public string CreateComment = "/boxes/{boxKey}/comments";

        #endregion

        #region Snippets

        public string ListSnippets = "/snippets";
        public string GetSnippet = "/snippets/{SNIPPET_KEY}";

        #endregion
    }
}
