using OpenQA.Selenium;

namespace CreatingReports.Pages
{
    public class BaseApplicationPage
    {
        protected IWebDriver Driver { get; set; }
        public BaseApplicationPage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}