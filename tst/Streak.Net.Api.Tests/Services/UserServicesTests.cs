using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Streak.Net.Api.Tests.Services
{
    [TestClass]
    public class UserServicesTests
    {
       [TestMethod]
        public void GetCurrentUserTest()
        {
            var streakServices = new TestSetup().GetStreakServices();
            var currentUser = streakServices.Users.GetCurrentUser();
            Assert.IsNotNull(currentUser);
            Assert.AreNotEqual(string.Empty, currentUser.Email);
        }

        [TestMethod()]
        public void GetUserTest()
        {
            var streakServices = new TestSetup().GetStreakServices();
            var currentUser = streakServices.Users.GetUser(streakServices.Users.GetCurrentUser().UserKey);
            Assert.IsNotNull(currentUser);
            Assert.AreNotEqual(string.Empty, currentUser.Email);
        }
    }
}