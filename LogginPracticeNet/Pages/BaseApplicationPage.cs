using OpenQA.Selenium;

namespace LogginPracticeNet.Pages;

public class BaseApplicationPage
{
    protected IWebDriver Driver { get; set; }
    public BaseApplicationPage(IWebDriver driver)
    {
        Driver = driver;
    }
}