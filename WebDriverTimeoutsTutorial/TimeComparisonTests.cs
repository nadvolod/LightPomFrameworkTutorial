using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using static OpenQA.Selenium.Support.UI.ExpectedConditions;
using AutomationResources;

namespace WebdriverTimeoutsTutorial
{
    [TestClass]
    [TestCategory("ImplicitAndExplicitWaits")]
    public class TimeComparisonTests
    {
        private IWebDriver _driver;
        private Stopwatch _stopwatch;
        private Stopwatch _pageLoadStopwatch;
        private const string FAKE_ID = "bsId";

        public void RemoteInitialize()
        {
            DesiredCapabilities capability = DesiredCapabilities.Firefox();
            capability.SetCapability("browserstack.user", Environment.GetEnvironmentVariable("BROWSERSTACK_USER", EnvironmentVariableTarget.User));
            capability.SetCapability("browserstack.key", Environment.GetEnvironmentVariable("BROWSERSTACK_KEY", EnvironmentVariableTarget.User));
            capability.SetCapability("browser", "Safari");
            capability.SetCapability("browser_version", "5.1");
            capability.SetCapability("os", "OS X");
            capability.SetCapability("os_version", "Snow Leopard");
            capability.SetCapability("resolution", "1024x768");
            capability.SetCapability("browserstack.debug", "true");

            _driver = new RemoteWebDriver(new Uri("http://hub.browserstack.com/wd/hub/"), capability);

            _driver.Url = "http://www.qtptutorial.net/automation-practice";
            _driver.Navigate().GoToUrl(_driver.Url);
        }
        [TestInitialize]
        public void Setup()
        {
            LocalInitialize();
            //BasicInitialize();
        }

        private void BasicInitialize()
        {
            _driver = new WebDriverFactory().Create(BrowserType.Chrome);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }

        private void LocalInitialize()
        {
            _driver = new WebDriverFactory().Create(BrowserType.Chrome);
            _stopwatch = new Stopwatch();
            _pageLoadStopwatch = new Stopwatch();
            _driver.Url = "http://www.qtptutorial.net/automation-practice";
            _pageLoadStopwatch.Start();
            _driver.Navigate().GoToUrl(_driver.Url);
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
            //go to a url that contains a dynamically loading page element
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_loading/1");
            //click the start button
            _driver.FindElement(By.Id("start")).Click();
            //find the element that has the text Hello World
            var text = _driver.FindElement(By.XPath(".//*[contains(text(),'Hello World!')]"));
            //click on the text
            text.Click();
        }

        [TestMethod]
        public void FindElement_DefaultTimeout()
        {
            //default is 500ms
            TryFind();
        }

        [TestMethod]
        public void FindElement_UpdatedTimeout()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            TryFind();
        }

        [TestMethod]
        public void FindElement_ExplicitWait()
        {
            IClock clock = new SystemClock();
            IWebElement element;
            Stopwatch pollingTimer = new Stopwatch();
            var wait = new WebDriverWait(clock, _driver, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(5));
            wait.Message = "Could not find this fake element";

            //wait.PollingInterval = TimeSpan.FromSeconds(3);
            //wait.IgnoreExceptionTypes(typeof (NoSuchElementException));
            element = wait.Until(ElementIsVisible(By.Id(FAKE_ID)));
        }

        [TestMethod]
        public void FindElement_WebDriverWait()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            var element = wait.Until(ElementIsVisible(By.Id(FAKE_ID)));
        }

        [TestMethod]
        public void FindElement_FluentWaitUsingDriver()
        {
            var wait = new DefaultWait<IWebDriver>(_driver);
            wait.Message = "Could not find this fake element";
            wait.PollingInterval = TimeSpan.FromSeconds(1);
            wait.IgnoreExceptionTypes(typeof(InvalidCastException));

            _driver.Navigate().GoToUrl("www.qtptutorial.net/automation-practice");
            var element = wait.Until(ElementIsVisible(By.Id(FAKE_ID)));
        }

        [TestMethod]
        public void FindElement_DefaultWaitForElement()
        {
            IClock clock = new SystemClock();
            var element = _driver.FindElement(By.Id(FAKE_ID));

            //passing in the web element rather than the driver
            var wait = new DefaultWait<IWebElement>(element);
            wait.Message = "Could not find this fake element";
            wait.PollingInterval = TimeSpan.FromSeconds(1);
            wait.IgnoreExceptionTypes(typeof(InvalidCastException));

            //wait.Until will not work because DefaultWait method definition is different
            //element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(FAKE_ID)));
        }


        public void TryFind()
        {
            try
            {
                _stopwatch.Start();
                _pageLoadStopwatch.Stop();
                var element = _driver.FindElement(By.Id(FAKE_ID));
            }
            catch (Exception e)
            {
                _stopwatch.Stop();
                Trace.WriteLine($"Time Elapsed for page load:{_pageLoadStopwatch.Elapsed.TotalSeconds}s");
                Trace.WriteLine($"Time Elapsed for element identification:{_stopwatch.Elapsed.TotalSeconds}s");
            }
        }

        public void TryFind(WebDriverWait wait)
        {
            try
            {
                _stopwatch.Start();
                _pageLoadStopwatch.Stop();
                var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(FAKE_ID)));
            }
            catch (Exception e)
            {
                _stopwatch.Stop();
                Trace.WriteLine($"Time Elapsed for page load:{_pageLoadStopwatch.Elapsed.TotalSeconds}s");
                Trace.WriteLine($"Time Elapsed for element identification:{_stopwatch.Elapsed.TotalSeconds}s");
            }
        }
    }
}
