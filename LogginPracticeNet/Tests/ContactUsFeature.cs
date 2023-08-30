using LogginPracticeNet.Pages;

namespace LogginPracticeNet.Tests;

[TestFixture]
[Category("ContactUsPage"), Category("SampleApp2")]
public class ContactUsFeature : BaseTest
{
    [Test]
    [Property("Author", "NikolayAdvolodkin")]
    [Description("Validate that the contact us page opens successfully with a form.")]
    public void TCID2()
    {
        ContactUsPage contactUsPage = new ContactUsPage(Driver);
        contactUsPage.GoTo();
        Assert.IsTrue(contactUsPage.IsLoaded,
            "The contact us page did not open successfully.");
    }
}
