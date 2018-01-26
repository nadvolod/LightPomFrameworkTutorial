using OpenQA.Selenium;

namespace SampleApp2
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