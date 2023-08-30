using AutomationResourcesNet;
using OpenQA.Selenium;
using SauceLabsNet.Models;
using SauceLabsNet.Pages;

namespace SauceLabsNet.Tests;

public class FirstBaseTest
{
    protected IWebDriver Driver { get; set; }
    internal TestUser TestUser { get; private set; }
    internal SampleApplicationPage SampleAppPage { get; private set; }
    internal TestUser EmergencyContactUser { get; private set; }

    [TearDown]
    public void CleanUpAfterEveryTestMethod()
    {
        Driver.Close();
        Driver.Quit();
    }

    [SetUp]
    public void SetupForEverySingleTestMethod()
    {
        Driver = new WebDriverFactory().CreateSauceDriver();
        SampleAppPage = new SampleApplicationPage(Driver);

        TestUser = new TestUser
        {
            FirstName = "Nikolay",
            LastName = "BLahzah"
        };

        EmergencyContactUser = new TestUser
        {
            FirstName = "Emergency First Name",
            LastName = "Emergency Last Name"
        };
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
        TestUser.GenderType = primaryContact;
        EmergencyContactUser.GenderType = emergencyContact;
    }
}
