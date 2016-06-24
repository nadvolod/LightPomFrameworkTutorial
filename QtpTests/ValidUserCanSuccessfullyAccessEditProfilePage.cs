using Framework.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QtpTests
{
    [TestClass]
    public class ValidUserCanSuccessfullyAccessEditProfilePage : TestBase
    {
        [TestMethod]
        public void AccessEditProfilePage()
        {
            Pages.Login.Goto();
            Pages.Login.LoginWithoutClef("seleniumTestUser", "Test12345!!$");
            Assert.IsTrue(Pages.MyMembership.IsAt(), "A valid user was not able to successfully login.");

            Pages.MyMembership.EditProfile();
            Assert.IsTrue(Pages.EditProfile.IsAt(), "The user was not able to view the Edit Profile page.");
        }
    }
}
