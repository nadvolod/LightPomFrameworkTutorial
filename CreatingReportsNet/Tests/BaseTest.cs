using AutomationResourcesNet;
using NLog;
using OpenQA.Selenium;

namespace CreatingReportsNet.Tests;

[Category("CreatingReports")]
[TestFixture]
public class BaseTest
{
    //private static TestContext _testContext;
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    protected IWebDriver Driver { get; private set; }
    public TestContext TestContext { get; set; }
    private ScreenshotTaker ScreenshotTaker { get; set; }

    [SetUp]
    public void SetupForEverySingleTestMethod()
    {
        Logger.Debug("*************************************** TEST STARTED");
        Logger.Debug("*************************************** TEST STARTED");
        Reporter.AddTestCaseMetadataToHtmlReport(TestContext);
        var factory = new WebDriverFactory();
        Driver = factory.Create(BrowserType.Chrome);
        Driver.Manage().Window.Maximize();
        ScreenshotTaker = new ScreenshotTaker(Driver, TestContext);
    }

    [TearDown]
    public void TearDownForEverySingleTestMethod()
    {
        Logger.Debug(GetType().FullName + " started a method tear down");
        try
        {
            TakeScreenshotForTestFailure();
        }
        catch (Exception e)
        {
            Logger.Error(e.Source);
            Logger.Error(e.StackTrace);
            Logger.Error(e.InnerException);
            Logger.Error(e.Message);
        }
        finally
        {
            StopBrowser();
            Logger.Debug(TestContext.Test.Name);
            Logger.Debug("*************************************** TEST STOPPED");
            Logger.Debug("*************************************** TEST STOPPED");
        }
    }

    private void TakeScreenshotForTestFailure()
    {
        if (ScreenshotTaker != null)
        {
            ScreenshotTaker.CreateScreenshotIfTestFailed();
            Reporter.ReportTestOutcome(ScreenshotTaker.ScreenshotFilePath);
        }
        else
        {
            Reporter.ReportTestOutcome("");
        }
    }

    private void StopBrowser()
    {
        if (Driver == null)
            return;
        Driver.Quit();
        Driver = null;
        Logger.Trace("Browser stopped successfully.");
    }
}