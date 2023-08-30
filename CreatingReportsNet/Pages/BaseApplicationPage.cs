using OpenQA.Selenium;

namespace CreatingReportsNet.Pages;

public class BaseApplicationPage
{
    public BaseApplicationPage(IWebDriver driver)
    {
        Driver = driver;
    }

    protected IWebDriver Driver { get; set; }
}