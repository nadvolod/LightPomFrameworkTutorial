using OpenQA.Selenium;
using System.Reflection;
using OpenQA.Selenium.Chrome;
using SampleFramework1Net;

namespace SampleFramework1;

[TestFixture]
[Category("SampleApplicationOne")]
public class SampleApplicationOneTests
{
    private IWebDriver Driver { get; set; }
    internal TestUser TheTestUser { get; private set; }
    internal SampleApplicationPage SampleAppPage { get; private set; }
    internal TestUser EmergencyContactUser { get; private set; }

    [Test]
    [Description("Validate that user is able to fill out the form successfully using valid data.")]
    public void Test1()
    {
        SetGenderTypes(Gender.Female, Gender.Female);

        SampleAppPage.GoTo();
        SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
        var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
        AssertPageVisible(ultimateQAHomePage);
    }
    [Test]
    [Description("Fake 2nd test.")]
    public void PretendTestNumber2()
    {
        SampleAppPage.GoTo();
        SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
        var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
        AssertPageVisibleVariation2(ultimateQAHomePage);
    }

    [Test]
    [Description("Validate that when selecting the Other gender type, the form is submitted successfully.")]
    public void Test3()
    {
        SetGenderTypes(Gender.Other, Gender.Other);

        SampleAppPage.GoTo();
        SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
        var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
        AssertPageVisibleVariation2(ultimateQAHomePage);
    }

    private IWebDriver GetChromeDriver()
    {
        var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        return new ChromeDriver(outPutDirectory);
    }

    [TearDown]
    public void CleanUpAfterEveryTestMethod()
    {
        Driver.Close();
        Driver.Quit();
    }

    [SetUp]
    public void SetupForEverySingleTestMethod()
    {
        Driver = GetChromeDriver();
        SampleAppPage = new SampleApplicationPage(Driver);

        TheTestUser = new TestUser();
        TheTestUser.FirstName = "Nikolay";
        TheTestUser.LastName = "BLahzah";

        EmergencyContactUser = new TestUser();
        EmergencyContactUser.FirstName = "Emergency First Name";
        EmergencyContactUser.LastName = "Emergency Last Name";
    }

    private static void AssertPageVisible(UltimateQAHomePage ultimateQAHomePage)
    {
        Assert.IsTrue(ultimateQAHomePage.IsVisible, "UltimateQA home page was not visible.");
    }

    private static void AssertPageVisibleVariation2(UltimateQAHomePage ultimateQAHomePage)
    {
        Assert.IsFalse(!ultimateQAHomePage.IsVisible, "UltimateQA home page was not visible.");
    }

    private void SetGenderTypes(Gender primaryContact, Gender emergencyContact)
    {
        TheTestUser.GenderType = primaryContact;
        EmergencyContactUser.GenderType = emergencyContact;
    }
}
