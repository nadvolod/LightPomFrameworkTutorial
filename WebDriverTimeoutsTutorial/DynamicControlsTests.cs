using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace WebDriverTimeoutsTutorial
{
    class DynamicControlsTests
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
        public void DynamicControlsTest()
        {
            _driver.Navigate().GoToUrl(URL.DynamicControlsURL);
            _driver.FindElement(By.XPath("//button[@onclick='swapCheckbox()']")).Click();
            Assert.IsTrue(_driver.FindElement(By.Id("message")).Displayed);
        }

        [TestMethod]
        public void DynamicControlsTest_FixedImplicitly()
        {
            _driver.Navigate().GoToUrl(URL.DynamicControlsURL);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.FindElement(By.XPath("//button[@onclick='swapCheckbox()']")).Click();
            Assert.IsTrue(_driver.FindElement(By.Id("message")).Displayed);
        }

        [TestMethod]
        public void DynamicControlsTest_FixedExplicitly()
        {
            _driver.Navigate().GoToUrl(URL.DynamicControlsURL);
            _driver.FindElement(By.XPath("//button[@onclick='swapCheckbox()']")).Click();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//input[@type='checkbox']")));
            Assert.IsTrue(wait.Until(ExpectedConditions.ElementIsVisible(By.Id("message"))).Displayed);
        }
    }
}
