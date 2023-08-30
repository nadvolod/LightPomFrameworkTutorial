using SauceLabsNet.Models;

namespace SauceLabsNet.Tests.Advanced;

[TestFixture]
[Category("DataDrivenParallelTests")]
[Parallelizable]
[TestFixture("chrome", "45", "macOS 10.13", "", "")]
[TestFixture("chrome", "50", "macOS 10.13", "", "")]
public class AdvancedSauceTests2 : BaseTest
{
    public AdvancedSauceTests2(string browser, string version, string os, string deviceName, string deviceOrientation) :
        base(browser, version, os, deviceName, deviceOrientation)
    {
    }
    [Test]
    public void TestMethodInClass2()
    {
        SetGenderTypes(Gender.Female, Gender.Female);

        SampleAppPage.GoTo();
        Thread.Sleep(20000);
        SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
        var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
        AssertPageVisible(ultimateQAHomePage);
    }

}
