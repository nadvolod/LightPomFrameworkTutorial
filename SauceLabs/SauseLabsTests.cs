using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SauceLabs
{
    [TestClass]
    [TestCategory("SauceLabsTests")]
    public class SauseLabsTests
    {
        private IWebDriver Driver { get; set; }
        internal TestUser TheTestUser { get; private set; }
        internal SampleApplicationPage SampleAppPage { get; private set; }
        internal TestUser EmergencyContactUser { get; private set; }

        [TestMethod]
        public void Test1()
        {
            SetGenderTypes(Gender.Female, Gender.Female);

            SampleAppPage.GoTo();
            SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
            var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
            AssertPageVisible(ultimateQAHomePage);
        }
        [TestMethod]
        public void PretendTestNumber2()
        {
            SampleAppPage.GoTo();
            SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
            var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
            AssertPageVisibleVariation2(ultimateQAHomePage);
        }

        [TestMethod]
        public void Test3()
        {
            SetGenderTypes(Gender.Other, Gender.Other);

            SampleAppPage.GoTo();
            SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
            var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
            AssertPageVisibleVariation2(ultimateQAHomePage);
        }
        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
            Driver.Close();
            Driver.Quit();
        }

        [TestInitialize]
        public void SetupForEverySingleTestMethod()
        {
            Driver = new WebDriverFactory().CreateSauceDriver();
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
}
