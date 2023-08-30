using NLog;
using OpenQA.Selenium;

namespace CreatingReportsNet.Pages;

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
            Reporter.LogTestStepForBugLogger(AventStack.ExtentReports.Status.Info, "Check if the Sign In page loaded successfully.");
            _logger.Trace($"Did sign in page open successfully=>{isLoaded}");
            return isLoaded;

        }
    }
}