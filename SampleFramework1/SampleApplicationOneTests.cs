using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Chrome;

namespace SampleFramework1
{
    [TestClass]
    [TestCategory("SampleApplicationOne")]
    public class SampleApplicationOneTests
    {
        private IWebDriver Driver { get; set; }
        internal TestUser TheTestUser { get; private set; }

        [TestMethod]
        [Description("Validate that user is able to fill out the form successfully using valid data.")]
        public void Test1()
        {
            TheTestUser.GenderType = Gender.Female;

            var sampleApplicationPage = new SampleApplicationPage(Driver);
            sampleApplicationPage.GoTo();
            var ultimateQAHomePage = sampleApplicationPage.FillOutFormAndSubmit(TheTestUser);
            Assert.IsTrue(ultimateQAHomePage.IsVisible, "UltimateQA home page was not visible.");
        }
        [TestMethod]
        [Description("Fake 2nd test.")]
        public void PretendTestNumber2()
        {
            var sampleApplicationPage = new SampleApplicationPage(Driver);
            sampleApplicationPage.GoTo();
            var ultimateQAHomePage = sampleApplicationPage.FillOutFormAndSubmit(TheTestUser);
            Assert.IsFalse(!ultimateQAHomePage.IsVisible, "UltimateQA home page was not visible.");
        }
        [TestMethod]
        [Description("Validate that when selecting the Other gender type, the form is submitted successfully.")]
        public void Test3()
        {
            TheTestUser.GenderType = Gender.Other;
            var sampleApplicationPage = new SampleApplicationPage(Driver);
            sampleApplicationPage.GoTo();
            var ultimateQAHomePage = sampleApplicationPage.FillOutFormAndSubmit(TheTestUser);
            Assert.IsFalse(!ultimateQAHomePage.IsVisible, "UltimateQA home page was not visible.");
        }

        private IWebDriver GetChromeDriver()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }

        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
            Driver.Close();
            Driver.Quit();
        }

        [TestInitialize]
        public void SetupForEverySingleTestMethod()
        {
            Driver = GetChromeDriver();
            TheTestUser = new TestUser();
            TheTestUser.FirstName = "Nikolay";
            TheTestUser.LastName = "BLahzah";
        }
    }
}
