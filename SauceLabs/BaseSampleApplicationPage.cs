using OpenQA.Selenium;

namespace SauceLabs
{
    public class BaseSampleApplicationPage
    {
        protected IWebDriver Driver { get; set; }

        public BaseSampleApplicationPage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}