using System;
using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;

namespace CreatingReports.Tests
{
    [TestCategory("CreatingReports")]
    [TestClass]
    public class BaseTest
    {
        protected IWebDriver Driver { get; private set; }
        public TestContext TestContext { get; set; }
        private static TestContext _testContext;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private ScreenshotTaker ScreenshotTaker { get; set; }

        [TestInitialize]
        public void SetupForEverySingleTestMethod()
        {
            Reporter.AddTestCaseMetadataToHtmlReport(TestContext);
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);
            ScreenshotTaker = new ScreenshotTaker(Driver, TestContext);
        }
        [TestCleanup]
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
                Logger.Debug(TestContext.TestName);
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
}