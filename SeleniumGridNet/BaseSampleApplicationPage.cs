using OpenQA.Selenium;

namespace SeleniumGridNet;

public class BaseSampleApplicationPage
{
    protected IWebDriver Driver { get; set; }

    public BaseSampleApplicationPage(IWebDriver driver)
    {
        Driver = driver;
    }
}