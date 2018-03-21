using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebdriverTimeoutsTutorial
{
    [TestClass]
    [TestCategory("Implicit waits")]
    public class SeleniumSynchronizationExamples
    {
        private IWebDriver _driver;
        private const string URI = "http://awful-valentine.com/purchase-forms/slow-animation/";

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
        public void Test1()
        {
            _driver.Navigate().GoToUrl(URI);
            FillOutCreditCardInfo();
            _driver.FindElement(By.Id("go")).Click();
            Assert.IsTrue(_driver.FindElement(By.Id("success")).Displayed);
        }

        private void FillOutCreditCardInfo()
        {
            _driver.FindElement(By.Id("name")).SendKeys("test name");
            _driver.FindElement(By.Id("cc")).SendKeys("1234123412341234");
            _driver.FindElement(By.Id("month")).SendKeys("01");
            _driver.FindElement(By.Id("year")).SendKeys("2020");
        }

        [TestMethod]
        public void Test1_FixedImplicitly()
        {
            _driver.Navigate().GoToUrl(URI);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            FillOutCreditCardInfo();
            _driver.FindElement(By.Id("go")).Click();
            Assert.IsTrue(_driver.FindElement(By.Id("success")).Displayed);
        }
        [TestMethod]
        public void Test2_ImplicitWaitExample()
        {
            _driver.Navigate().GoToUrl("https://www.ultimateqa.com");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Assert.IsTrue(_driver.FindElement(By.Id("success")).Displayed);
        }
        [TestMethod]
        public void Test3_ImplicitWait_HiddenElement()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_loading/1");
            SetImplicitWaitAndAssert();
        }
        [TestMethod]
        public void Test4_ImplicitWait_RenderedAfter()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_loading/2");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Assert.IsTrue(_driver.FindElement(By.Id("finish")).Displayed);
        }
        private void SetImplicitWaitAndAssert()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Assert.IsTrue(_driver.FindElement(By.Id("finish")).Displayed);
        }

        [TestMethod]
        public void Test1_FixedExplicitly()
        {
            _driver.Navigate().GoToUrl(URI);
            FillOutCreditCardInfo();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("go"))).Click();
            //_driver.FindElement(By.Id("go")).Click();
            Assert.IsTrue(wait.Until(ExpectedConditions.ElementIsVisible(By.Id("success"))).Displayed);
        }
    }
}
