using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace WebdriverTimeoutsTutorial
{
    [TestClass]
    [TestCategory("Implicit waits")]
    public class ImplicitWait
    {
        private IWebDriver _driver;
        private const string URI = "https://the-internet.herokuapp.com/dynamic_loading/1";

        [TestInitialize]
        public void Setup()
        {
            _driver = WebDriverCreator.BasicInitialize();
        }

        [TestCleanup]
        public void Teardown()
        {
            _driver.Close();
            _driver.Quit();
        }

        [TestMethod]
        public void DynamicallyLoadingElementsTestFailure()
        {
            TryFind();
        }

        private void TryFind()
        {
            //go to a url that contains a dynamically loading page element
            _driver.Navigate().GoToUrl(URI);
            //click the start button
            _driver.FindElement(By.TagName("button")).Click();
            //find the element that has the text Hello World
            Assert.IsTrue(_driver.FindElement(By.XPath(".//*[contains(text(),'Hello World!')]")).Displayed);

        }

        [TestMethod]
        public void DynamicallyLoadingElementsTestFailure_FixedImplicitly()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            TryFind();
        }
    }
}
