using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Streak.Net.Api.Enums;
using Streak.Net.Api.Exceptions;
using Streak.Net.Api.Models;

namespace Streak.Net.Api.Tests.Services
{
    [TestClass]
    public class PipelineServicesTests
    {
        [TestMethod]
        public void ListAllPipelinesTest()
        {
            var streakServices = new TestSetup().GetStreakServices();
            var pipelines = streakServices.Pipelines.ListAllPipelines();
            Assert.IsNotNull(pipelines);
            Assert.IsNotNull(pipelines.Pipelines);
            Assert.AreNotSame(0, pipelines.Pipelines.Count());

            var pipelines2 = streakServices.Pipelines.ListAllPipelines(SortOptions.CreationTimestamp);
            Assert.IsNotNull(pipelines2);
            Assert.IsNotNull(pipelines2.Pipelines);
            Assert.AreNotSame(0, pipelines2.Pipelines.Count());

            var pipelines3 = streakServices.Pipelines.ListAllPipelines(SortOptions.LastUpdatedTimestamp);
            Assert.IsNotNull(pipelines3);
            Assert.IsNotNull(pipelines3.Pipelines);
            Assert.AreNotSame(0, pipelines3.Pipelines.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(StreakApiException))]
        public void GetPipelineTest()
        {
            var streakServices = new TestSetup().GetStreakServices();
            var pipelineKey = new TestSetup().GetPipelineKeyForTest();
            var pipeline = streakServices.Pipelines.GetPipeline(pipelineKey);
            Assert.IsNotNull(pipeline);
            Assert.IsNotNull(pipeline.Name);
            Assert.AreNotSame(string.Empty, pipeline.Name);

            pipeline = streakServices.Pipelines.GetPipeline("FAIL");
        }

        [TestMethod]
        public void CreatePipelineTest()
        {
            var streakServices = new TestSetup().GetStreakServices();
            
            var p1 = streakServices.Pipelines.CreatePipeline("Test Pipeline", "This is just a test from the API", false);

            Assert.IsNotNull(p1);
            Assert.IsNotNull(p1.Name);
            Assert.AreNotSame(string.Empty, p1.Name);
            Assert.AreEqual("Test Pipeline", p1.Name);
            Assert.AreEqual("This is just a test from the API", p1.Description);
            Assert.AreEqual(false, p1.OrgWide);
            Assert.AreEqual(0, p1.Stages.Count);
            Assert.AreEqual(0, p1.Fields.Count);

            var d = new Dictionary<string, FieldType> { { "Email", FieldType.TextInput }, { "Firstnames", FieldType.TextInput } };

            var p2 = streakServices.Pipelines.CreatePipeline("Test Pipeline 2", "This is another test", true, d);

            Assert.IsNotNull(p2);
            Assert.IsNotNull(p2.Name);
            Assert.AreNotSame(string.Empty, p2.Name);
            Assert.AreEqual("Test Pipeline 2", p2.Name);
            Assert.AreEqual("This is another test", p2.Description);
            Assert.AreEqual(true, p2.OrgWide);
            Assert.AreEqual(0, p2.Stages.Count);
            Assert.AreEqual(2, p2.Fields.Count);

            d.Add("Lastname", FieldType.TextInput);
            var p3 = streakServices.Pipelines.CreatePipeline("Test Pipeline 3", "This is a third and another test", false, d,
                new[] {"First Stage", "Second Stage", "Fourth & Final Stage"});

            Assert.IsNotNull(p3);
            Assert.IsNotNull(p3.Name);
            Assert.AreNotSame(string.Empty, p3.Name);
            Assert.AreEqual("Test Pipeline 3", p3.Name);
            Assert.AreEqual("This is a third and another test", p3.Description);
            Assert.AreEqual(false, p3.OrgWide);
            Assert.AreEqual(3, p3.Stages.Count);
            Assert.AreEqual(3, p3.Fields.Count);

            // Clean up!
            Assert.AreEqual(true, streakServices.Pipelines.DeletePipeline(p1.PipelineKey).Success);
            Assert.AreEqual(true, streakServices.Pipelines.DeletePipeline(p2.PipelineKey).Success);
            Assert.AreEqual(true, streakServices.Pipelines.DeletePipeline(p3.PipelineKey).Success);
        }

        [TestMethod]
        public void DeletePipelineTest()
        {
            var streakServices = new TestSetup().GetStreakServices();

            var p1 = streakServices.Pipelines.CreatePipeline("Test Pipeline", "This is just a test from the API", false);

            Assert.IsNotNull(p1);
            Assert.IsNotNull(p1.Name);
            Assert.AreNotSame(string.Empty, p1.Name);

            var result = streakServices.Pipelines.DeletePipeline(p1.PipelineKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(true, result.Success);
        }

        [TestMethod]
        public void EditPipelineTest()
        {
            var streakServices = new TestSetup().GetStreakServices();

            var p1 = streakServices.Pipelines.CreatePipeline("Test Pipeline", "This is just a test from the API", true,
                new Dictionary<string, FieldType> {{"Email", FieldType.TextInput }, {"Firstnames", FieldType.TextInput } },
                new[] {"First Stage", "Second Stage", "Fourth & Final Stage"});

            Assert.IsNotNull(p1);
            Assert.IsNotNull(p1.Name);
            Assert.AreEqual("Test Pipeline", p1.Name);
            Assert.AreEqual("This is just a test from the API", p1.Description);
            Assert.AreEqual(true, p1.OrgWide);
            Assert.AreEqual(3, p1.Stages.Count);
            Assert.AreEqual(2, p1.Fields.Count);
            Assert.AreEqual(1, p1.AclEntries.Count);

            p1.AclEntries.Add(new AclEntry {Email = "jen@greybird.dk", PermissionSetName = AclEntryPermissions.ViewAllPermissionSet.Value});
            p1.StageOrder.Reverse();
            // EDIT 1
            p1 = streakServices.Pipelines.EditPipeline(p1.PipelineKey, "Test Pipeline ALTERED", "New description", p1.StageOrder.ToArray(),
                true, p1.AclEntries);

            Assert.AreEqual("Test Pipeline ALTERED", p1.Name);
            Assert.AreEqual("New description", p1.Description);
            Assert.AreEqual(true, p1.OrgWide);
            Assert.AreEqual(2, p1.AclEntries.Count);

            var result = streakServices.Pipelines.DeletePipeline(p1.PipelineKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(true, result.Success);
        }
    }
}