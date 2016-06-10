using Framework.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace QtpTests
{
    [TestClass]
    public class LoginWithInvalidUserNameShouldNotWork2 : TestBase
    {
        [TestMethod]
        public void LoginWithInvalidUserNameShouldNotWork()
        {
            Pages.Login.Goto();
            Pages.Login.Login("INvalidSeleniumHacker", "Test12345!!$");
            Assert.IsFalse(Pages.MyMembership.IsAt());
        }
    }
}
