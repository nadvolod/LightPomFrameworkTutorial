using Framework.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace QtpTests
{
    [TestClass]
    public class LoginWithInvalidUserNameShouldNotWork2 : TestBase
    {
        [TestMethod]
        public void RunTest()
        {
            Pages.Login.Goto();
            Pages.Login.Login("INvalidSeleniumHacker", "Test12345!!$");
            Assert.IsFalse(Pages.MyMembership.IsAt());
        }
    }
}
