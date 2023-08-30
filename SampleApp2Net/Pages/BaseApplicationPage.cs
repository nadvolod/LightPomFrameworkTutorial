using OpenQA.Selenium;

namespace SampleApp2Net.Pages;

public class BaseApplicationPage
{
    protected IWebDriver Driver { get; set; }
    public BaseApplicationPage(IWebDriver driver)
    {
        Driver = driver;
    }
}