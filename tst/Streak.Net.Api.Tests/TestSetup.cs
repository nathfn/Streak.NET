using System.IO;

namespace Streak.Net.Api.Tests
{
    public class TestSetup
    {
        public StreakServices GetStreakServices()
        {
            // Reading the API key from a text file not included in the solution. Replace with your own!
            return new StreakServices(File.ReadAllText(@"C:\test-streak-api-key.txt"));
        }

        public string GetPipelineKeyForTest()
        {
            // Returning an existing pipeline used for testing!
            // Replace with own!
            return File.ReadAllText(@"C:\test-streak-pipeline-key.txt");
        }
    }
}
