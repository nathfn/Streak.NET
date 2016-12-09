using Streak.Net.Api.Services.Raw;

namespace Streak.Net.Api
{
    public class RawStreakServices
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StreakServices"/> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        public RawStreakServices(string apiKey): this(apiKey, "https://www.streak.com/api/v1"){ }

        /// <summary>
        /// Initializes a new instance of the <see cref="StreakServices"/> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <param name="apiBaseUrl">The API base URL.</param>
        public RawStreakServices(string apiKey, string apiBaseUrl)
        {
            UsersRaw = new RawUserServices(apiKey, apiBaseUrl);
            PipelinesRaw = new RawPipelineServices(apiKey, apiBaseUrl);
            BoxesRaw = new RawBoxServices(apiKey, apiBaseUrl);
            StagesRaw = new RawStageServices(apiKey, apiBaseUrl);
            FieldsRaw = new RawFieldServices(apiKey, apiBaseUrl);
            TasksRaw = new RawTaskService(apiKey, apiBaseUrl);
            TasksRaw = new RawTaskService(apiKey, apiBaseUrl);
            FilesRaw = new RawFileServices(apiKey, apiBaseUrl);
            ThreadsRaw = new RawThreadServices(apiKey, apiBaseUrl);
            CommentsRaw = new RawCommentServices(apiKey, apiBaseUrl);
            SnippetsRaw = new RawSnippetServices(apiKey, apiBaseUrl);
        }

        /// <summary>
        /// Provides access to the user service for interacting with Streak users in a raw API fashion where the raw JSON response and HTTP status code is returned. Nothing else. Each Streak user has a corresponding user object. Creation of users is done when a user signs up for Streak and these objects can not be altered through the API. Since API keys are associated with the user, each API key only has priveledges to access its own user object.
        /// </summary>
        /// <value>
        /// The user services.
        /// </value>
        public RawUserServices UsersRaw { get; }

        /// <summary>
        /// Provides access to the pipeline service for interacting with Streak pipelines in a raw API fashion where the raw JSON response and HTTP status code is returned
        /// Pipelines are a core data object in Streak. They represent a business process that a user or set of users would like managed. Pipelines are typically used for Sales, Hiring, Product Development, Bug Tracking, Project Management, Fundraising, Dealflow and others.
        /// A pipeline defines the schema for the boxes it contains.It defines the set of stages that contained boxes can be in as well as the set of custom fields.A pipeline is created by a single user but can be shared to other users or to an entire organization.
        /// Pipelines have several fields that describe the schema of the pipeline and hence describe the schema of any boxes contained within it.
        /// can not be altered through the API.Since API keys are associated with the user, each API key only has priveledges to access its own user object.
        /// </summary>
        /// <value>
        /// The pipeline services.
        /// </value>
        public RawPipelineServices PipelinesRaw { get; }

        /// <summary>
        /// Provides access to the box service for interacting with Streak boxes in a raw API fashion where the raw JSON response and HTTP status code is returned
        /// A box is the fundamental data type in Streak. What a box represents depends on the context it is being used. For sales, a box could be a deal. For hiring, a box may be a candidate. For bug tracking, a box may be a single bug. A box belongs to a single pipeline. A box contains emails, files, tasks and data for custom fields of a pipeline. It also specifies what stage (defined in its pipeline) this box belongs to.
        /// </summary>
        /// <value>
        /// The box services.
        /// </value>
        public RawBoxServices BoxesRaw { get; }

        /// <summary>
        /// Provides access to the stage service for interacting with Streak stages in a raw API fashion where the raw JSON response and HTTP status code is returned
        /// Stages are different possible states a box can be in. The list of valid stages a box can be in are defined in the pipeline it belongs to. All boxes in the same pipeline all have the same set of permissible stages. Listing the stages for a given pipeline can be done by getting a specific pipeline or using the list stages enpoint below. To set what stage a given box is in, update the stageKey property of a box using the edit box endpoint.
        /// </summary>
        /// <value>
        /// The stage services.
        /// </value>
        public RawStageServices StagesRaw { get; }

        /// <summary>
        /// Provides access to the field service for interacting with Streak fields in a raw API fashion where the raw JSON response and HTTP status code is returned
        /// Fields allow users to define custom schema on their boxes.
        /// That is, a field is user defined metadata on a box.In the web UI of Streak, a field shows up as an additional column in the pipeline view and box views. Fields are defined on a per pipeline basis. This means that all boxes in the same pipeline have the same custom fields (schema).
        /// Fields have a name and a type.The type can be any of: TEXT_INPUT, DATE or PERSON.
        /// </summary>
        /// <value>
        /// The field services.
        /// </value>
        public RawFieldServices FieldsRaw { get; }

        /// <summary>
        /// Provides access to the task service for interacting with Streak tasks in a raw API fashion where the raw JSON response and HTTP status code is returned
        /// Tasks allow you to create a task list per box. All tasks have the text property. They can optionally be assigned to any member of the pipeline. They also have an optional due date, which when set, adds the task to the teams calendar and sends an email reminder when due.
        /// </summary>
        /// <value>
        /// The field services.
        /// </value>
        public RawTaskService TasksRaw { get; }

        /// <summary>
        /// Provides access to the file service for interacting with Streak files in a raw API fashion where the raw JSON response and HTTP status code is returned
        /// Files are automatically extracted from emails that exist in a box. Each file is associated with the box it's in.
        /// </summary>
        /// <value>
        /// The field services.
        /// </value>
        public RawFileServices FilesRaw { get; }

        /// <summary>
        /// Provides access to the thread service for interacting with Streak threads in a raw API fashion where the raw JSON response and HTTP status code is returned
        /// Streak associates a list of gmail threads with each box in a pipeline.
        /// </summary>
        /// <value>
        /// The field services.
        /// </value>
        public RawThreadServices ThreadsRaw { get; }

        /// <summary>
        /// Provides access to the comment service for interacting with Streak comments in a raw API fashion where the raw JSON response and HTTP status code is returned
        /// Streak associates a list of gmail threads with each box in a pipeline.
        /// </summary>
        /// <value>
        /// The field services.
        /// </value>
        public RawCommentServices CommentsRaw { get; }

        /// <summary>
        /// Provides access to the snippet service for interacting with Streak snippets in a raw API fashion where the raw JSON response and HTTP status code is returned
        /// Snippets are saved fragments of text that can be inserted into emails. A snippet can optionally be associated with a pipeline so that it is shared to every user in that has access to that pipeline.
        /// </summary>
        /// <value>
        /// The field services.
        /// </value>
        public RawSnippetServices SnippetsRaw { get; }
    }
}
