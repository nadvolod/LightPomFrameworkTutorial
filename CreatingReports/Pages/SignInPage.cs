
using NLog;
using OpenQA.Selenium;

namespace CreatingReports.Pages
{
    internal class SignInPage : BaseApplicationPage
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        public SignInPage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsLoaded
        {
            get
            {
                var isLoaded = Driver.Url.Contains("controller=authentication");
                _logger.Trace($"Did sign in page open successfully=>{isLoaded}");
                return isLoaded;

            }
        }
    }
}