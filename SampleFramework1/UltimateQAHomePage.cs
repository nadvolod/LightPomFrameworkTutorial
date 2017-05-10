using OpenQA.Selenium;

namespace SampleFramework1
{
    internal class UltimateQAHomePage : BaseSampleApplicationPage
    {
        public UltimateQAHomePage(IWebDriver driver) : base(driver){}

        public bool IsVisible => StartHereButton.Displayed;

        public IWebElement StartHereButton => Driver.FindElement(By.LinkText("Start here"));
    }
}