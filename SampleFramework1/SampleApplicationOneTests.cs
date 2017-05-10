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

        [TestMethod]
        public void Test1()
        {
            Driver = GetChromeDriver();
            var sampleApplicationPage = new SampleApplicationPage(Driver);
            sampleApplicationPage.GoTo();
            Assert.IsTrue(sampleApplicationPage.IsVisible, "Sample application page was not visible.");

            var ultimateQAHomePage = sampleApplicationPage.FillOutFormAndSubmit("Nikolay");
            Assert.IsTrue(ultimateQAHomePage.IsVisible, "UltimateQA home page was not visible.");
            Driver.Close();
            Driver.Quit();
        }

        private IWebDriver GetChromeDriver()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
    }
}
