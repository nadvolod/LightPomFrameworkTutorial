using SauceLabsNet.Models;

namespace SauceLabsNet.Tests.Parallel;

[TestFixture]
[Category("SimpleParallelTestClasses")]
[Parallelizable]
public class ParallelSauceExample2 : FirstBaseTest
{
    [Test]
    public void Test1()
    {
        SetGenderTypes(Gender.Female, Gender.Female);

        SampleAppPage.GoTo();
        SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
        var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TestUser);
        AssertPageVisible(ultimateQAHomePage);
    }

    [Test]
    public void Test2()
    {
        SetGenderTypes(Gender.Other, Gender.Other);

        SampleAppPage.GoTo();
        SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
        var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TestUser);
        AssertPageVisibleVariation2(ultimateQAHomePage);
    }

    [Test]
    public void Test3()
    {
        SetGenderTypes(Gender.Other, Gender.Other);

        SampleAppPage.GoTo();
        SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
        var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TestUser);
        AssertPageVisibleVariation2(ultimateQAHomePage);
    }

}

