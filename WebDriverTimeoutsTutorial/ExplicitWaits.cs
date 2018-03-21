using System;
using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriverTimeoutsTutorial;
//using static OpenQA.Selenium.Support.UI.ExpectedConditions;

namespace WebdriverTimeoutsTutorial
{
    [TestClass]
    [TestCategory("Explicit waits")]
    public class ExplicitWaits
    {
        private IWebDriver _driver;
        By ElementToWaitFor = By.Id("finish");


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
        public void Test1_FixedExplicitly()
        {
            _driver.Navigate().GoToUrl(URL.SlowAnimationUrl);
            FillOutCreditCardInfo();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("go"))).Click();
            Assert.IsTrue(wait.Until(ExpectedConditions.ElementIsVisible(By.Id("success"))).Displayed);
        }
        private void FillOutCreditCardInfo()
        {
            _driver.FindElement(By.Id("name")).SendKeys("test name");
            _driver.FindElement(By.Id("cc")).SendKeys("1234123412341234");
            _driver.FindElement(By.Id("month")).SendKeys("01");
            _driver.FindElement(By.Id("year")).SendKeys("2020");
        }
        [TestMethod]
        public void Test3_ExplicitWait_HiddenElement()
        {
            _driver.Navigate().GoToUrl(URL.HiddenElementUrl);
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(ElementToWaitFor)).Click();
        }
        [TestMethod]
        public void Test4_ExplicitWait_RenderedAfter()
        {
            _driver.Navigate().GoToUrl(URL.ElementRenderedAfterUrl);
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(ElementToWaitFor)).Click();
        }
        //Quiz
        [TestMethod]
        public void Test3_ExplicitWaitOptions_HiddenElement()
        {
            _driver.Navigate().GoToUrl(URL.HiddenElementUrl);
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementExists(ElementToWaitFor)).Click();
        }
    }
}
