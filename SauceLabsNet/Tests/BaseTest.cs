using AutomationResourcesNet;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using SauceLabsNet.Models;
using SauceLabsNet.Pages;

namespace SauceLabsNet.Tests;

[TestFixture]
public class BaseTest
{
    protected IWebDriver Driver { get; set; }
    internal TestUser TheTestUser { get; private set; }
    internal SampleApplicationPage SampleAppPage { get; private set; }
    internal TestUser EmergencyContactUser { get; private set; }
    public string Browser { get; set; }
    public string Version { get; set; }
    public string OS { get; set; }
    public string DeviceName { get; set; }
    public string DeviceOrientation { get; set; }

    public BaseTest(string browser, string version, string os, string deviceName, string deviceOrientation)
    {
        Browser = browser;
        Version = version;
        OS = os;
        DeviceName = deviceName;
        DeviceOrientation = deviceOrientation;
    }

    [TearDown]
    public void CleanUpAfterEveryTestMethod()
    {
        string isTestPassed = "failed";
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            isTestPassed = "passed";

        ((IJavaScriptExecutor)Driver).ExecuteScript($"sauce:job-result={isTestPassed}");
        ((IJavaScriptExecutor)Driver).ExecuteScript($"sauce:context={TestContext.CurrentContext.Result.Message}");
        Driver.Close();
        Driver.Quit();
    }

    [SetUp]
    public void SetupForEverySingleTestMethod()
    {
        var sauceConfig = new SauceConfiguration
        {
            Browser = Browser,
            Version = Version,
            OS = OS,
            DeviceName = DeviceName,
            DeviceOrientation = DeviceOrientation,
            TestCaseName = TestContext.CurrentContext.Test.MethodName
        };

        Driver = new WebDriverFactory().CreateSauceDriver(sauceConfig);
        SampleAppPage = new SampleApplicationPage(Driver);

        TheTestUser = new TestUser();
        TheTestUser.FirstName = "Nikolay";
        TheTestUser.LastName = "BLahzah";

        EmergencyContactUser = new TestUser();
        EmergencyContactUser.FirstName = "Emergency First Name";
        EmergencyContactUser.LastName = "Emergency Last Name";
    }

    public static void AssertPageVisible(UltimateQAHomePage ultimateQAHomePage)
    {
        Assert.IsTrue(ultimateQAHomePage.IsVisible, "UltimateQA home page was not visible.");
    }

    public static void AssertPageVisibleVariation2(UltimateQAHomePage ultimateQAHomePage)
    {
        Assert.IsFalse(!ultimateQAHomePage.IsVisible, "UltimateQA home page was not visible.");
    }

    public void SetGenderTypes(Gender primaryContact, Gender emergencyContact)
    {
        TheTestUser.GenderType = primaryContact;
        EmergencyContactUser.GenderType = emergencyContact;
    }
}
