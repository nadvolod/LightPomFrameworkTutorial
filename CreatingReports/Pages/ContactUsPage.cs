using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace CreatingReports.Pages
{
    internal class ContactUsPage : BaseApplicationPage
    {
        public ContactUsPage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsLoaded
        {
            get
            {
                try
                {
                    Reporter.LogTestStepForBugLogger(Status.Info,
                        "Validate that Contact Us page loaded successfully.");
                    var displayed = CenterColumn.Displayed;
                    return displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }

        public IWebElement CenterColumn => Driver.FindElement(By.Id("center_column"));

        internal void GoTo()
        {
            var url = "http://automationpractice.com/index.php?controller=contact";
            Driver.Navigate().GoToUrl(url);
            Reporter.LogPassingTestStepToBugLogger($"Open url=>{url} for Contact Us page.");
        }
    }
}