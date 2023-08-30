using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NLog;
using NUnit.Framework.Interfaces;

namespace CreatingReportsNet;

public static class Reporter
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private static ExtentReports ReportManager { get; set; }
    private static string ApplicationDebuggingFolder => "c://temp/CreatingReports";

    private static string HtmlReportFullPath { get; set; }

    public static string LatestResultsReportFolder { get; set; }

    private static TestContext MyTestContext { get; set; }

    private static ExtentTest CurrentTestCase { get; set; }

    public static void StartReporter()
    {
        Logger.Trace("Starting a one time setup for the entire" +
                        " .CreatingReports namespace." +
                        "Going to initialize the reporter next...");
        CreateReportDirectory();
        var htmlReporter = new ExtentHtmlReporter(HtmlReportFullPath);
        ReportManager = new ExtentReports();
        ReportManager.AttachReporter(htmlReporter);
    }

    private static void CreateReportDirectory()
    {
        var filePath = Path.GetFullPath(ApplicationDebuggingFolder);
        LatestResultsReportFolder = Path.Combine(filePath, DateTime.Now.ToString("MMdd_HHmm"));
        Directory.CreateDirectory(LatestResultsReportFolder);

        HtmlReportFullPath = $"{LatestResultsReportFolder}\\TestResults.html";
        Logger.Trace("Full path of HTML report=>" + HtmlReportFullPath);
    }

    public static void AddTestCaseMetadataToHtmlReport(TestContext testContext)
    {
        MyTestContext = testContext;
        CurrentTestCase = ReportManager.CreateTest(MyTestContext.Test.Name);
    }

    public static void LogPassingTestStepToBugLogger(string message)
    {
        Logger.Info(message);
        CurrentTestCase.Log(Status.Pass, message);
    }

    public static void ReportTestOutcome(string screenshotPath)
    {
        var status = MyTestContext.Result.Outcome;

        if (status == ResultState.Failure)
        {
            Logger.Error($"Test Failed=>{MyTestContext.Test.ClassName}");
            CurrentTestCase.AddScreenCaptureFromPath(screenshotPath);
            CurrentTestCase.Fail("Fail");
        }
        else if(status == ResultState.Inconclusive)
        {
            CurrentTestCase.AddScreenCaptureFromPath(screenshotPath);
            CurrentTestCase.Warning("Inconclusive");
        }
        else if (status == ResultState.Skipped)
        {
            CurrentTestCase.Skip("Test skipped");
        }
        else
        {
            CurrentTestCase.Pass("Pass");
        }

        ReportManager.Flush();
    }

    public static void LogTestStepForBugLogger(Status status, string message)
    {
        Logger.Info(message);
        CurrentTestCase.Log(status, message);
    }
}