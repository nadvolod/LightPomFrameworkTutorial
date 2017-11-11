using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static OpenQA.Selenium.Support.UI.ExpectedConditions;

namespace WebdriverTimeoutsTutorial
{
    [TestClass]
    public class DefaultWait
    {
        private IWebDriver _driver;
        private const string URI = "https://the-internet.herokuapp.com/dynamic_loading/2";
        private const string id = "finish_fake";
        private By elementId = By.Id(id);
        Stopwatch _stopwatch = new Stopwatch();

        [TestInitialize]
        public void Setup()
        {
            _driver = WebDriverCreator.BasicInitialize();
            //go to a url that contains a dynamically loading page element
            _driver.Navigate().GoToUrl(URI);
            //click the start button
            _driver.FindElement(By.TagName("button")).Click();
        }

        [TestCleanup]
        public void Teardown()
        {
            _driver.Close();
            _driver.Quit();
        }


        [TestMethod]
        public void DefaultWaitTest() //aka Fluent Wait in Java
        {
            var wait = new DefaultWait<IWebDriver>(_driver)
            {
                Timeout = TimeSpan.FromSeconds(10),
                //Message = "Dude, where's my element?",
                PollingInterval = TimeSpan.FromSeconds(1)
            };
            //wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            IClock clock  = new SystemClock();
            var wait2 = new WebDriverWait(clock, _driver, TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(1));
            _stopwatch.Start();
            wait.Until(ElementIsVisible(elementId));
            _stopwatch.Stop();
            Trace.WriteLine($"Time Elapsed for element identification:{_stopwatch.Elapsed.TotalSeconds}s");
        }

    }
}
