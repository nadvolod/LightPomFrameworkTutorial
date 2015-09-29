using Framework.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace QtpTests
{
    [TestClass]
    public class LoginWithInvalidPasswordShouldNotWork : TestBase
    {
        [TestMethod]
        public void RunTest()
        {
            Pages.Login.Goto();
            Pages.Login.Login("seleniumTestUser", "SeleniumRocksMySocks!!");
            Assert.IsFalse(Pages.MyMembership.IsAt());
        }
    }
}
