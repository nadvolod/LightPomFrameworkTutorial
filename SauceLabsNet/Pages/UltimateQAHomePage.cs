using OpenQA.Selenium;

namespace SauceLabsNet.Pages;

public class UltimateQAHomePage : BasePage
{
    public UltimateQAHomePage(IWebDriver driver) : base(driver)
    {
    }

    public bool IsVisible
    {
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
        ((IJavaScriptExecutor)Driver).ExecuteScript($"sauce:job-name=navigate to https://www.ultimateqa.com");
        Driver.Navigate().GoToUrl("https://www.ultimateqa.com");
        Thread.Sleep(65000);
        return this;
    }
}
