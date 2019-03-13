using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace CreatingReports.Pages
{
    public class ComplicatedPage : BaseApplicationPage
    {
        public ComplicatedPage(IWebDriver driver) : base(driver)
        {
        }
        public void GoTo()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/complicated-page/");
            Reporter.LogPassingTestStepToBugLogger($"Navigate to Complicated Page at url=>https://www.ultimateqa.com/complicated-page/");
        }

        public bool IsLoaded
        {
            get
            {
                var isLoaded = Driver.Url.Contains("complicated-page");
                Reporter.LogTestStepForBugLogger(Status.Info, "Check whether the complicated page loaded successfully");
                return isLoaded;
            }

        }

        public RandomStuffSection RandomStuffSection => new RandomStuffSection(Driver);
    }
}
