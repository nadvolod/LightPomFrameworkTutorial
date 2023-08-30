using AutomationResourcesNet;
using OpenQA.Selenium;

namespace SampleApp2Net.Tests;

public class BaseTest
{
    public IWebDriver Driver { get; private set; }

    [SetUp]
    public void SetupForEverySingleTestMethod()
    {
        var factory = new WebDriverFactory();
        Driver = factory.Create(BrowserType.Chrome);
    }

    [TearDown]
    public void CleanUpAfterEveryTestMethod()
    {
        Driver.Close();
        Driver.Quit();
    }
}