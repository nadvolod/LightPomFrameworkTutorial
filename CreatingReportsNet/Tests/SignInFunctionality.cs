using CreatingReportsNet.Pages;

namespace CreatingReportsNet.Tests;

[TestFixture]
[Category("SignIn")]
[Category("SampleApp2")]
public class SignInFunctionality : BaseTest
{
    [Test]
    [Property("Author", "NikolayAdvolodkin")]
    public void TCID5()
    {
        var homePage = new HomePage(Driver);
        homePage.GoTo();
        Assert.IsTrue(homePage.IsLoaded, "Home page did not open successfully");

        var signInPage = homePage.Header.ClickSignInButton();
        Assert.IsTrue(signInPage.IsLoaded, "Sign in page did not open sucessfully.");
    }
}