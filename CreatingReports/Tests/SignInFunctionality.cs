using CreatingReports.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CreatingReports.Tests
{
    [TestClass]
    [TestCategory("SignIn")]
    [TestCategory("SampleApp2")]
    public class SignInFunctionality : BaseTest
    {
        [TestMethod]
        [TestProperty("Author", "NikolayAdvolodkin")]
        public void TCID5()
        {
            var homePage = new HomePage(Driver);
            homePage.GoTo();
            Assert.IsTrue(homePage.IsLoaded, "Home page did not open successfully");

            var signInPage = homePage.Header.ClickSignInButton();
            Assert.IsTrue(signInPage.IsLoaded, "Sign in page did not open sucessfully.");
        }
    }
}