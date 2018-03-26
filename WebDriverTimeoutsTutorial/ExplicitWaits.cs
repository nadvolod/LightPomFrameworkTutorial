using System;
using System.Threading;
using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriverTimeoutsTutorial;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

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
        public void ExplicitWait1()
        {
            Thread.Sleep(1000);
        }
        [TestMethod]
        public void ExplicitWait2()
        {
            _driver.Navigate().GoToUrl(URL.HiddenElementUrl);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            IWebElement element = wait.Until((d) =>
            {
                return d.FindElement(By.Id("success"));
            });
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
        //1. open page
        //2. synchronize on slowest loading element
        //3. proceed with actions
        [TestMethod]
        public void HowToCorrectlySynchronize()
        {

            _driver.Navigate().GoToUrl("https://www.ultimateqa.com");
            _driver.Manage().Window.Maximize();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            var firstSyncElement = By.XPath("//*[@class='et_parallax_bg et_pb_parallax_css et_pb_inner_shadow']");
            wait.Until(ExpectedConditions.ElementIsVisible(firstSyncElement));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Automation Exercises"))).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[text()='Automation Practice']")));
            _driver.FindElement(By.LinkText("Big page with many elements")).Click();

            var finalElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@title='girl with laptop 2']")));
            Assert.IsTrue(finalElement.Displayed);
        }

        private void FillOutCreditCardInfo()
        {
            _driver.FindElement(By.Id("name")).SendKeys("test name");
            _driver.FindElement(By.Id("cc")).SendKeys("1234123412341234");
            _driver.FindElement(By.Id("month")).SendKeys("01");
            _driver.FindElement(By.Id("year")).SendKeys("2020");
        }
    }
}
