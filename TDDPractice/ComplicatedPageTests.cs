using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace TDDPractice
{
    [TestClass]
    [TestCategory("TDDPractice")]
    public class ComplicatedPageTests
    {
        private IWebDriver driver;

        public void TestMethod1()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var driver = new ChromeDriver(path);

            var complicatedPage = new ComplicatedPage(driver);
            complicatedPage.Open();
            var amazonSearchPage = complicatedPage.SearchUsingAmazon("automation testing");
            Assert.AreEqual("automation testing", amazonSearchPage.ActualSearchResults);
        }

        [TestMethod]
        public void TestMethodNew()
        {
            driver = new WebDriverFactory().Create(BrowserType.Chrome);
            var complicatedPage = new ComplicatedPage(driver);
            complicatedPage.Open();
            complicatedPage.SearchArticles("automation testing");
            Assert.IsTrue(complicatedPage.AreResultsReturned());
        }

    }
}
