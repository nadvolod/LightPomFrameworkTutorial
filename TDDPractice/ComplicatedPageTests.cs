using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace TDDPractice
{
    [TestClass]
    [TestCategory("TDDPractice")]
    public class ComplicatedPageTests
    {
        
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
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var driver = new ChromeDriver(path);

            var complicatedPage = new ComplicatedPage(driver);
            complicatedPage.Open();
            complicatedPage.SearchArticles("automation testing");
            Assert.IsTrue(complicatedPage.AreResultsReturned());
        }

    }
}
