using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Streak.Net.Api.Exceptions;

namespace Streak.Net.Api.Tests.Services
{
    [TestClass]
    public class StageServicesTests
    {
        [TestMethod]
        public void ListStagesInPipelineTest()
        {
            var s = new TestSetup().GetStreakServices();

            var p = s.Pipelines.CreatePipeline("Test Pipeline", "Description", false, null, new[] { "Stage 1", "Stage 2", "Stage 3" });

            var res =
                s.Stages.ListStagesInPipeline(
                    p.PipelineKey);

            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Stages);
            Assert.AreNotEqual(0, res.Stages.Count);
            Assert.AreEqual(3, res.Stages.Count);
            var ordered = res.Stages.OrderBy(st => st.Key);
            Assert.AreEqual("Stage 1", ordered.First().Value.Name);

            s.Pipelines.DeletePipeline(p.PipelineKey);
        }

        [TestMethod]
        public void GetStageTest()
        {
            var s = new TestSetup().GetStreakServices();

            var p = s.Pipelines.CreatePipeline("Test Pipeline", "Description", false, null, new []{"Stage 1"});

            var stage1 = s.Stages.GetStage(p.PipelineKey, p.Stages.First().Value.Key);

            Assert.IsNotNull(stage1);
            Assert.AreEqual(stage1.Key, p.Stages.First().Value.Key);
            Assert.AreEqual(stage1.Name, p.Stages.First().Value.Name);

            s.Pipelines.DeletePipeline(p.PipelineKey);
        }

        [TestMethod]
        public void CreateStageTest()
        {
            var s = new TestSetup().GetStreakServices();

            var p = s.Pipelines.CreatePipeline("Test Pipeline", "Description", false);

            Assert.IsNotNull(p.Stages);
            Assert.AreEqual(0, p.Stages.Count);

            var stage1 = s.Stages.CreateStage(p.PipelineKey, "Stage 1");


            Assert.IsNotNull(stage1);
            Assert.IsNotNull(stage1.Key);
            Assert.AreEqual(stage1.Name, "Stage 1");

            p = s.Pipelines.GetPipeline(p.PipelineKey);

            Assert.IsNotNull(p.Stages);
            Assert.AreEqual(1, p.Stages.Count);
            Assert.AreEqual(stage1.Key, p.Stages.First().Value.Key);
            Assert.AreEqual(stage1.Name, p.Stages.First().Value.Name);

            s.Pipelines.DeletePipeline(p.PipelineKey);
        }

        [TestMethod]
        public void DeleteStageTest()
        {
            var s = new TestSetup().GetStreakServices();

            var p = s.Pipelines.CreatePipeline("Test Pipeline", "Description", false);
            var stage1 = s.Stages.CreateStage(p.PipelineKey, "Stage 1");

            var res = s.Stages.DeleteStage(p.PipelineKey, stage1.Key);

            Assert.IsNotNull(res);
            Assert.AreEqual(true, res.Success);

            s.Pipelines.DeletePipeline(p.PipelineKey);
        }

        [TestMethod]
        [ExpectedException(typeof(StreakApiException))]
        public void DeleteStageWithBoxTest()
        {
            var s = new TestSetup().GetStreakServices();
            var p = s.Pipelines.CreatePipeline("Test Pipeline", "Description", false);
            var stage1 = s.Stages.CreateStage(p.PipelineKey, "Stage 1");
            var b = s.Boxes.CreateBox(p.PipelineKey, "BOX 1", stage1.Key);
            try
            {
                s.Stages.DeleteStage(p.PipelineKey, stage1.Key);
            }
            finally
            {
                s.Boxes.DeleteBox(b.BoxKey);
                s.Pipelines.DeletePipeline(p.PipelineKey);
            }
        }

        [TestMethod]
        public void EditStageTest()
        {
            var s = new TestSetup().GetStreakServices();

            var p = s.Pipelines.CreatePipeline("Test Pipeline", "Description", false);

            var stage1 = s.Stages.CreateStage(p.PipelineKey, "Stage 1");

            p = s.Pipelines.GetPipeline(p.PipelineKey);

            Assert.IsNotNull(p.Stages);
            Assert.AreEqual(1, p.Stages.Count);
            Assert.AreEqual(stage1.Key, p.Stages.First().Value.Key);
            Assert.AreEqual(stage1.Name, p.Stages.First().Value.Name);

            var updatedStage = s.Stages.EditStage(p.PipelineKey, stage1.Key, "Stage 1 ALTERED");

            p = s.Pipelines.GetPipeline(p.PipelineKey);

            Assert.IsNotNull(p.Stages);
            Assert.AreEqual(1, p.Stages.Count);
            Assert.AreEqual(updatedStage.Key, p.Stages.First().Value.Key);
            Assert.AreEqual(updatedStage.Name, p.Stages.First().Value.Name);

            s.Pipelines.DeletePipeline(p.PipelineKey);
        }
    }
}