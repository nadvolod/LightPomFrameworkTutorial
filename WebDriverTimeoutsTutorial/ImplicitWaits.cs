using System;
using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using WebDriverTimeoutsTutorial;

namespace WebdriverTimeoutsTutorial
{
    [TestClass]
    [TestCategory("Implicit waits")]
    public class ImplicitWaits
    {
        private IWebDriver _driver;

        [TestInitialize]
        public void Setup()
        {
           _driver = new WebDriverFactory().Create(BrowserType.Chrome);
        }

        [TestCleanup]
        public void Teardown()
        {
            _driver.Close();
            _driver.Quit();
        }

        [TestMethod]
        [ExpectedException(typeof(NoSuchElementException))]
        public void Test1()
        {
            _driver.Navigate().GoToUrl(URL.SlowAnimationUrl);
            _driver.FindElement(By.XPath("//button[@onclick='swapCheckbox()']")).Click();
            Assert.IsTrue(_driver.FindElement(By.Id("message")).Displayed);
        }

        [TestMethod]
        public void Test1_FixedImplicitly()
        {
            _driver.Navigate().GoToUrl(URL.SlowAnimationUrl);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.FindElement(By.XPath("//button[@onclick='swapCheckbox()']")).Click();
            Assert.IsTrue(_driver.FindElement(By.Id("message")).Displayed);
        }
        [TestMethod]
        [ExpectedException(typeof(NoSuchElementException))]
        public void Test2_ImplicitWaitExample()
        {
            _driver.Navigate().GoToUrl("https://www.ultimateqa.com");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Assert.IsTrue(_driver.FindElement(By.Id("success")).Displayed);
        }
        [TestMethod]
        [ExpectedException(typeof(ElementNotVisibleException))]
        public void Test3_ImplicitWait_HiddenElement()
        {
            _driver.Navigate().GoToUrl(URL.HiddenElementUrl);
            SetImplicitWaitAndClick();
        }
        [TestMethod]
        [ExpectedException(typeof(NoSuchElementException))]
        public void Test4_ImplicitWait_RenderedAfter()
        {
            _driver.Navigate().GoToUrl(URL.ElementRenderedAfterUrl);
            SetImplicitWaitAndClick();
        }
        private void SetImplicitWaitAndClick()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.FindElement(By.Id("finish")).Click();
        }
    }
}
