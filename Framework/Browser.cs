using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.IO;
using System.Reflection;

namespace Framework
{
    public enum Drivers
    {
        Chrome,
        Firefox,
        IE
    }
    public static class Browser
    {

        private static IWebDriver _webDriver = GetDriver(Drivers.Chrome);

        private static string _baseUrl = "http://www.qtptutorial.net";

        internal static void SwitchTabs(int tabIndex)
        {
            var windows = _webDriver.WindowHandles;
            _webDriver.SwitchTo().Window(windows[tabIndex]);
        }

        internal static IWebDriver GetDriver(Drivers driver)
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var relativePath = @"..\..\..\Framework\Drivers";
            var chromeDriverPath = Path.GetFullPath(Path.Combine(outPutDirectory, relativePath));
            return new ChromeDriver(chromeDriverPath);
        }

        public static bool WaitUntilElementIsDisplayed(By element, int timeoutInSeconds)
        {
            for (int i = 0; i < timeoutInSeconds; i++)
            {
                if (ElementIsDisplayed(element))
                {
                    return true;
                }
                Thread.Sleep(1000);
            }
            return false;
        }

        internal static IWebElement FindElement(By by)
        {
            return _webDriver.FindElement(by);
        }

        public static bool ElementIsDisplayed(By element)
        {
            var present = false;
            _webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0));
            try
            {
                present = _webDriver.FindElement(element).Displayed;
            }
            catch (NoSuchElementException)
            {
            }
            _webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            return present;
        }

        public static ISearchContext Driver { get {return _webDriver;} }
        public static string Title { get { return _webDriver.Title; } }

        public static void Initialize()
        {
            Goto("");
        }

        public static void Close()
        {
            _webDriver.Close();
        }

        public static void Goto(string url, bool useBaseUrl = true)
        {
            if (useBaseUrl)
                _webDriver.Navigate().GoToUrl(string.Format("{0}/{1}", _baseUrl, url));
            else
                _webDriver.Navigate().GoToUrl(url);
        }

        public static void Quit()
        {
            _webDriver.Quit();
        }
    }
}