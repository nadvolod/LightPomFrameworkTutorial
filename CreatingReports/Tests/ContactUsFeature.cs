using CreatingReports.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CreatingReports.Tests
{
    [TestClass]
    [TestCategory("ContactUsPage")]
    [TestCategory("SampleApp2")]
    public class ContactUsFeature : BaseTest
    {
        [TestMethod]
        [TestProperty("Author", "NikolayAdvolodkin")]
        [Description("Validate that the contact us page opens successfully with a form.")]
        public void TCID2()
        {
            var contactUsPage = new ContactUsPage(Driver);
            contactUsPage.GoTo();
            Assert.IsTrue(contactUsPage.IsLoaded,
                "The contact us page did not open successfully.");
        }

        [TestMethod]
        [TestProperty("Author", "NikolayAdvolodkin")]
        [Description("Validate that the contact us page opens when clicking the Contact Us button.")]
        public void TCID4()
        {
            var homePage = new HomePage(Driver);
            homePage.GoTo();
            Assert.IsTrue(homePage.IsLoaded, "Home page did not open successfully");

            var contactUsPage = homePage.Header.ClickContactUsButton();
            Assert.IsTrue(contactUsPage.IsLoaded, "The contact us page did not open successfully.");
            
        }

        [TestMethod]
        [TestProperty("Author", "NikolayAdvolodkin")]
        public void TCID5()
        {
            //1. open automation practice page
            //2. click the Sign In button
            //3. validate that the correct page opened
        }

        [TestMethod]
        [TestProperty("Author", "NikolayAdvolodkin")]
        public void TCID6()
        {
            //1. open automation page with many items - https://www.ultimateqa.com/complicated-page/
            //2. Fill out and submit the form in the "Section of random stuff"
            //3. validate that form was submitted successfully
        }
        [TestMethod]
        [TestProperty("Author", "NikolayAdvolodkin")]
        public void TCID7()
        {
            //1. open automation page with many items - https://www.ultimateqa.com/complicated-page/
            //2. Perform a search for string "selenium errors"
            //3. validate that correct search results were returned
        }
    }
}