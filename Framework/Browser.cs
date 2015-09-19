using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Framework
{
    public static class Browser
    {
        private static IWebDriver _webDriver = new ChromeDriver();
        private static string _baseUrl = "http://www.qtptutorial.net";
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

        public static void Goto(string relativeUrl)
        {
            _webDriver.Navigate().GoToUrl(string.Format("{0}/{1}", _baseUrl, relativeUrl));
        }
    }
}