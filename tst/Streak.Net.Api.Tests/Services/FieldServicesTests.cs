using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Streak.Net.Api.Enums;

namespace Streak.Net.Api.Tests.Services
{
    [TestClass]
    public class FieldServicesTests
    {
        [TestMethod]
        public void ListFieldsInPipelineTest()
        {
            var streakServices = new TestSetup().GetStreakServices();

            var d = new Dictionary<string, FieldType> { { "Email", FieldType.TextInput }, { "Firstnames", FieldType.TextInput } };

            var p1 = streakServices.Pipelines.CreatePipeline("Test Pipeline", "This is just a test from the API", false, d);

            var fields = streakServices.Fields.ListFieldsInPipeline(p1.PipelineKey);

            Assert.IsNotNull(fields);
            Assert.IsNotNull(fields.Fields);
            Assert.AreEqual(2, fields.Fields.Count());
            Assert.AreEqual("Email", fields.Fields.First().Name);
            Assert.AreEqual("TEXT_INPUT", fields.Fields.First().Type);

            var result = streakServices.Pipelines.DeletePipeline(p1.PipelineKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(true, result.Success);
        }

        [TestMethod]
        public void GetFieldTest()
        {
            var streakServices = new TestSetup().GetStreakServices();

            var d = new Dictionary<string, FieldType> { { "Email", FieldType.TextInput }, { "Firstnames", FieldType.TextInput } };

            var p1 = streakServices.Pipelines.CreatePipeline("Test Pipeline", "This is just a test from the API", false, d);

            var field = streakServices.Fields.GetField(p1.PipelineKey, p1.Fields.First().Key);

            Assert.IsNotNull(field);
            Assert.AreEqual("Email", field.Name);
            Assert.AreEqual("TEXT_INPUT", field.Type);

            var result = streakServices.Pipelines.DeletePipeline(p1.PipelineKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(true, result.Success);
        }

        [TestMethod]
        public void CreateFieldTest()
        {
            var streakServices = new TestSetup().GetStreakServices();

            var p1 = streakServices.Pipelines.CreatePipeline("Test Pipeline", "This is just a test from the API", false);

            var field = streakServices.Fields.CreateField(p1.PipelineKey, "Email", FieldType.TextInput);

            Assert.IsNotNull(field);
            Assert.AreEqual("Email", field.Name);
            Assert.AreEqual("TEXT_INPUT", field.Type);

            var result = streakServices.Pipelines.DeletePipeline(p1.PipelineKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(true, result.Success);
        }

        [TestMethod]
        public void DeleteFieldTest()
        {
            var streakServices = new TestSetup().GetStreakServices();

            var p1 = streakServices.Pipelines.CreatePipeline("Test Pipeline", "This is just a test from the API", false);

            var field = streakServices.Fields.CreateField(p1.PipelineKey, "Email", FieldType.TextInput);

            Assert.IsNotNull(field);
            Assert.AreEqual("Email", field.Name);
            Assert.AreEqual("TEXT_INPUT", field.Type);

            var result = streakServices.Fields.DeleteField(p1.PipelineKey, field.Key);

            Assert.IsNotNull(result);
            Assert.AreEqual(true, result.Success);

            result = streakServices.Pipelines.DeletePipeline(p1.PipelineKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(true, result.Success);
        }

        [TestMethod]
        public void EditFieldTest()
        {
            var streakServices = new TestSetup().GetStreakServices();

            var p1 = streakServices.Pipelines.CreatePipeline("Test Pipeline", "This is just a test from the API", false);

            var field = streakServices.Fields.CreateField(p1.PipelineKey, "Email", FieldType.TextInput);

            Assert.IsNotNull(field);
            Assert.AreEqual("Email", field.Name);
            Assert.AreEqual("TEXT_INPUT", field.Type);
            var fieldKey = field.Key;
            field = streakServices.Fields.EditField(p1.PipelineKey, fieldKey, "Email2");

            Assert.IsNotNull(field);
            Assert.AreEqual("Email2", field.Name);
            Assert.AreEqual("Email2", field.Name);
            Assert.AreEqual("TEXT_INPUT", field.Type);
            Assert.AreEqual(fieldKey, field.Key);

            var result = streakServices.Pipelines.DeletePipeline(p1.PipelineKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(true, result.Success);
        }
    }
}