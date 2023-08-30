using NLog;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace CreatingReportsNet;

public class ScreenshotTaker
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private readonly IWebDriver _driver;
    private readonly TestContext _testContext;

    public ScreenshotTaker(IWebDriver driver, TestContext testContext)
    {
        if (driver == null)
            return;
        _driver = driver;
        _testContext = testContext;
        ScreenshotFileName = _testContext.Test.Name;
    }

    public string ScreenshotFilePath { get; private set; }
    private string ScreenshotFileName { get; set; }

    public void CreateScreenshotIfTestFailed()
    {
        if (_testContext.Result.Outcome == ResultState.Failure ||
            _testContext.Result.Outcome == ResultState.Inconclusive)
            TakeScreenshotForFailure();
    }

    public string TakeScreenshot(string screenshotFileName)
    {
        var ss = GetScreenshot();
        var successfullySaved = TryToSaveScreenshot(screenshotFileName, ss);

        return successfullySaved ? ScreenshotFilePath : "";
    }

    public bool TakeScreenshotForFailure()
    {
        ScreenshotFileName = $"FAIL_{ScreenshotFileName}";

        var ss = GetScreenshot();
        var successfullySaved = TryToSaveScreenshot(ScreenshotFileName, ss);
        if (successfullySaved)
            Logger.Error($"Screenshot Of Error=>{ScreenshotFilePath}");
        return successfullySaved;
    }

    private Screenshot GetScreenshot()
    {
        return ((ITakesScreenshot)_driver)?.GetScreenshot();
    }

    private bool TryToSaveScreenshot(string screenshotFileName, Screenshot ss)
    {
        try
        {
            SaveScreenshot(screenshotFileName, ss);
            return true;
        }
        catch (Exception e)
        {
            Logger.Error(e.InnerException);
            Logger.Error(e.Message);
            Logger.Error(e.StackTrace);
            return false;
        }
    }

    private void SaveScreenshot(string screenshotName, Screenshot ss)
    {
        if (ss == null)
            return;
        ScreenshotFilePath = $"{Reporter.LatestResultsReportFolder}\\{screenshotName}.jpg";
        ScreenshotFilePath = ScreenshotFilePath.Replace('/', ' ').Replace('"', ' ');
        ss.SaveAsFile(ScreenshotFilePath, ScreenshotImageFormat.Png);
    }
}