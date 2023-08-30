using SauceLabsNet.Models;

namespace SauceLabsNet.Tests.Parallel;

[TestFixture]
[Category("SimpleParallelTestClasses")]
[Parallelizable]
public class ParallelSauceExample3 : FirstBaseTest
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
}
