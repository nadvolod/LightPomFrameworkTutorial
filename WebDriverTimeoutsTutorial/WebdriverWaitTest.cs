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
    [TestCategory("ImplicitAndExplicitWaits")]
    public class WebdriverWaitTest
    {
        private IWebDriver _driver;
        private const string URI = "https://the-internet.herokuapp.com/dynamic_loading/2";
        private By elementId = By.Id("finish");
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
        public void ExplicitWait1()
        {
            _stopwatch.Start();
            Thread.Sleep(10000);
            var myElement = _driver.FindElement(elementId);
            _stopwatch.Stop();
            Trace.WriteLine($"ExplicitWait1-Time Elapsed for element identification:{_stopwatch.Elapsed.TotalSeconds}s");
        }

        [TestMethod]
        public void ExplicitWait2()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _stopwatch.Start();
            IWebElement myDynamicElement = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(elementId);
            });
            _stopwatch.Stop();
            Trace.WriteLine($"ExplicitWait2-Time Elapsed for element identification:{_stopwatch.Elapsed.TotalSeconds}s");
        }

        [TestMethod]
        public void Time_WebDriverWait()
        {
            IClock clock = new SystemClock();
            var wait = new WebDriverWait(clock,_driver,TimeSpan.FromSeconds(10),TimeSpan.FromSeconds(5));
            _stopwatch.Start();
            var myElement = wait.Until(ElementIsVisible(elementId));
            _stopwatch.Stop();
            Trace.WriteLine($"Time_WebDriverWait-Time Elapsed for element identification:{_stopwatch.Elapsed.TotalSeconds}s");
        }

        [TestMethod]
        public void Clean_WebDriverWait()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _stopwatch.Start();
            var myElement = wait.Until(ElementExists(elementId));
            _stopwatch.Stop();
            Trace.WriteLine($"Clean_WebDriverWait-Time Elapsed for element identification:{_stopwatch.Elapsed.TotalSeconds}s");
        }
    }
}
