using OpenQA.Selenium;

namespace CreatingReports.Pages
{
    public class BaseApplicationPage
    {
        public BaseApplicationPage(IWebDriver driver)
        {
            Driver = driver;
        }

        protected IWebDriver Driver { get; set; }
    }
}