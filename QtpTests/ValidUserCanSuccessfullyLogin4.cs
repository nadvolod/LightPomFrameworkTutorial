using System;
using System.Drawing.Printing;
using Framework.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace QtpTests
{
    [TestClass]
    public class ValidUserCanSuccessfullyLogin4 : TestBase
    {
        [TestMethod]
        public void RunTest()
        {
            Pages.Login.Goto();
            Pages.Login.Login("seleniumTestUser", "Test12345!!$");
            Assert.IsTrue(Pages.MyMembership.IsAt(), "A valid user was not able to successfully login.");
        }
    }
}
