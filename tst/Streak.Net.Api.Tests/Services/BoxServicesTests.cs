using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Streak.Net.Api.Enums;

namespace Streak.Net.Api.Tests.Services
{
    [TestClass]
    public class BoxServicesTests
    {
        [TestMethod]
        public void ListAllBoxesUserHasAccessToTest()
        {
            var streakServices = new TestSetup().GetStreakServices();

            var x = streakServices.Boxes.ListAllBoxesUserHasAccessTo();

            Assert.IsNotNull(x);
            Assert.IsNotNull(x.Boxes);
            Assert.AreNotEqual(0, x.Boxes.Count());
        }

        [TestMethod]
        public void ListAllBoxesInPipelineTest()
        {
            var streakServices = new TestSetup().GetStreakServices();
            var pipelineKey = new TestSetup().GetPipelineKeyForTest();
            var x = streakServices.Boxes.ListAllBoxesInPipeline(pipelineKey);

            Assert.IsNotNull(x);
            Assert.IsNotNull(x.Boxes);
            Assert.AreNotEqual(0, x.Boxes.Count());

            x = streakServices.Boxes.ListAllBoxesInPipeline(pipelineKey, SortOptions.LastUpdatedTimestamp);

            Assert.IsNotNull(x);
            Assert.IsNotNull(x.Boxes);
            Assert.AreNotEqual(0, x.Boxes.Count());
        }

        [TestMethod]
        public void CreateBoxTest()
        {
            var streakServices = new TestSetup().GetStreakServices();

            var testPipeline = streakServices.Pipelines.CreatePipeline("TEST PIPELINE 1", "DESC", false, null, new[] { "First Stage", "Second Stage", "Fourth & Final Stage" });

            var x = streakServices.Boxes.CreateBox(testPipeline.PipelineKey, "TEST BOX");

            Assert.IsNotNull(x);
            Assert.IsNotNull(x.PipelineKey);
            Assert.AreEqual(testPipeline.PipelineKey, x.PipelineKey);

            var x2 = streakServices.Boxes.CreateBox(testPipeline.PipelineKey, "TEST BOX", testPipeline.Stages.Keys.First());

            Assert.IsNotNull(x2);
            Assert.IsNotNull(x2.PipelineKey);
            Assert.AreEqual(testPipeline.PipelineKey, x2.PipelineKey);
            Assert.AreEqual(x2.StageKey, testPipeline.Stages.Keys.First());

            // Clean up!
            streakServices.Boxes.DeleteBox(x.BoxKey);
            streakServices.Boxes.DeleteBox(x2.BoxKey);
            streakServices.Pipelines.DeletePipeline(testPipeline.PipelineKey);
        }

        [TestMethod]
        public void DeleteBoxTest()
        {
            var streakServices = new TestSetup().GetStreakServices();

            var testPipeline = streakServices.Pipelines.CreatePipeline("TEST PIPELINE 1", "DESC", false, null, new[] { "First Stage", "Second Stage", "Fourth & Final Stage" });

            var x = streakServices.Boxes.CreateBox(testPipeline.PipelineKey, "TEST BOX");
            var x2 = streakServices.Boxes.CreateBox(testPipeline.PipelineKey, "TEST BOX", testPipeline.Stages.Keys.First());

            // Clean up!
            var s1 = streakServices.Boxes.DeleteBox(x.BoxKey);
            var s2 = streakServices.Boxes.DeleteBox(x2.BoxKey);

            Assert.AreEqual(true, s1.Success);
            Assert.AreEqual(true, s2.Success);

            var p1 = streakServices.Pipelines.DeletePipeline(testPipeline.PipelineKey);

            Assert.AreEqual(true, p1.Success);
        }

        [TestMethod]
        public void EditBoxTest()
        {
            var streakServices = new TestSetup().GetStreakServices();

            var testPipeline = streakServices.Pipelines.CreatePipeline("TEST PIPELINE 1", "DESC", false, null, new[] { "First Stage", "Second Stage", "Fourth & Final Stage" });

            var x = streakServices.Boxes.CreateBox(testPipeline.PipelineKey, "TEST BOX");

            x = streakServices.Boxes.EditBox(x.BoxKey, "TEST BOX 1", "NOTES HERE", testPipeline.Stages.Keys.Last());

            Assert.IsNotNull(x);
            Assert.IsNotNull(x.PipelineKey);
            Assert.AreEqual("TEST BOX 1", x.Name);
            Assert.AreEqual("NOTES HERE", x.Notes);
            Assert.AreEqual(testPipeline.PipelineKey, x.PipelineKey);
            Assert.AreEqual(x.StageKey, testPipeline.Stages.Keys.Last());

            // Clean up!
            var s1 = streakServices.Boxes.DeleteBox(x.BoxKey);

            Assert.AreEqual(true, s1.Success);

            var p1 = streakServices.Pipelines.DeletePipeline(testPipeline.PipelineKey);

            Assert.AreEqual(true, p1.Success);
        }
    }
}