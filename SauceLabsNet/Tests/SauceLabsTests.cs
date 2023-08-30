using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using SauceLabsNet.Models;
using SauceLabsNet.Pages;

namespace SauceLabsNet.Tests;

[TestFixture]
[Category("SauceLabsTests")]
public class SauceLabsTests
{
    private IWebDriver Driver { get; set; }
    internal TestUser TheTestUser { get; private set; }
    internal SampleApplicationPage SampleAppPage { get; private set; }
    internal TestUser EmergencyContactUser { get; private set; }

    [Test]
    public void Test1()
    {
        SetGenderTypes(Gender.Female, Gender.Female);

        SampleAppPage.GoTo();
        SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
        var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
        AssertPageVisible(ultimateQAHomePage);
    }
    [Test]
    public void PretendTestNumber2()
    {
        SampleAppPage.GoTo();
        SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
        var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
        AssertPageVisibleVariation2(ultimateQAHomePage);
    }

    [Test]
    public void Test3()
    {
        ((IJavaScriptExecutor)Driver).ExecuteScript("sauce:job-tags=Test3,EmergencyContactForm");
        SetGenderTypes(Gender.Other, Gender.Other);

        SampleAppPage.GoTo();
        SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
        var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
        AssertPageVisibleVariation2(ultimateQAHomePage);
    }

    [TearDown]
    public void CleanUpAfterEveryTestMethod()
    {
        var passed = TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Success);
        try
        {
            // Logs the result to Sauce Labs
            ((IJavaScriptExecutor)Driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
        }
        finally
        {
            // Terminates the remote webdriver session
            Driver?.Quit();
        }
    }

    [SetUp]
    public void SetupForEverySingleTestMethod()
    {
        //Driver = new WebDriverFactory().CreateSauceDriver();
        SampleAppPage = new SampleApplicationPage(Driver);

        TheTestUser = new TestUser();
        TheTestUser.FirstName = "Nikolay";
        TheTestUser.LastName = "BLahzah";

        EmergencyContactUser = new TestUser();
        EmergencyContactUser.FirstName = "Emergency First Name";
        EmergencyContactUser.LastName = "Emergency Last Name";
    }

    private static void AssertPageVisible(UltimateQAHomePage ultimateQAHomePage) =>
        Assert.IsTrue(ultimateQAHomePage.IsVisible, "UltimateQA home page was not visible.");

    private static void AssertPageVisibleVariation2(UltimateQAHomePage ultimateQAHomePage) =>
        Assert.IsFalse(!ultimateQAHomePage.IsVisible, "UltimateQA home page was not visible.");

    private void SetGenderTypes(Gender primaryContact, Gender emergencyContact)
    {
        TheTestUser.GenderType = primaryContact;
        EmergencyContactUser.GenderType = emergencyContact;
    }

    /**
     *This is a quiz test. Don't look here until you get to the correct lecture.
     * You will know when it's time. Use this to check your answer and code.
     *Test Requirements - chrome 62 on windows 8.1 with screen resolution of 1024x768
      */
    [Test]
    public void QuizExercise1()
    {
        //1. chrome 62 on windows 8.1 with screen resolution of 1024x768

        //DesiredCapabilities caps = new DesiredCapabilities();
        //caps.SetCapability("browserName", "Chrome");
        //caps.SetCapability("platform", "Windows 8.1");
        //caps.SetCapability("version", "62.0");
        //caps.SetCapability("screenResolution", "1024x768");
        //caps.SetCapability("username",
        //    Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User));
        //caps.SetCapability("accessKey",
        //    Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User));
        //Driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"),
        //    caps, TimeSpan.FromSeconds(600));
        //SampleAppPage = new SampleApplicationPage(Driver);
        //SampleAppPage.GoTo();
        //SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
        //var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
        //AssertPageVisibleVariation2(ultimateQAHomePage);

    }
    /**
     *This is a quiz test. Don't look here until you get to the correct lecture.
     * You will know when it's time. Use this to check your answer and code.
     *Test Requirements - chrome 48 on Linux
      */
    [Test]
    public void QuizExercise2()
    {
        //2. chrome 48 on Linux
        //var caps = new DesiredCapabilities();
        //caps.SetCapability("browserName", "Chrome");
        //caps.SetCapability("platform", "Linux");
        //caps.SetCapability("version", "48.0");
        //caps.SetCapability("username",
        //    Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User));
        //caps.SetCapability("accessKey",
        //    Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User));
        //Driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"),
        //    caps, TimeSpan.FromSeconds(600));

        //SampleAppPage = new SampleApplicationPage(Driver);
        //SampleAppPage.GoTo();
        //SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
        var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
        AssertPageVisibleVariation2(ultimateQAHomePage);
    }
}
