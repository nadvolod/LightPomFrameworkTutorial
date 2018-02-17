using System.Threading;
using OpenQA.Selenium;

namespace SauceLabs
{
    public class UltimateQAHomePage : BaseSampleApplicationPage
    {
        public UltimateQAHomePage(IWebDriver driver) : base(driver){}

        public bool IsVisible {
            get
            {
                try
                {
                    return StartHereButton.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }

        public IWebElement StartHereButton => Driver.FindElement(By.LinkText("Start learning now"));

        public UltimateQAHomePage Open()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com");
            Thread.Sleep(65000);
            return this;
        }
    }
}