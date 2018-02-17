using AutomationResources;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SauceLabs
{
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver Driver { get; set; }
        internal TestUser TheTestUser { get; private set; }
        internal SampleApplicationPage SampleAppPage { get; private set; }
        internal TestUser EmergencyContactUser { get; private set; }
        public string Browser { get; set; }
        public string  Version { get; set; }
        public string OS { get; set; }
        public string DeviceName { get; set; }
        public string DeviceOrientation { get; set; }

        public BaseTest(string browser, string version, string os, string deviceName, string deviceOrientation)
        {
            Browser = browser;
            Version = version;
            OS = os;
            DeviceName = deviceName;
            DeviceOrientation = deviceOrientation;
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
            Driver = new WebDriverFactory().CreateSauceDriver(Browser, Version, OS, DeviceName, DeviceOrientation);
            SampleAppPage = new SampleApplicationPage(Driver);

            TheTestUser = new TestUser();
            TheTestUser.FirstName = "Nikolay";
            TheTestUser.LastName = "BLahzah";

            EmergencyContactUser = new TestUser();
            EmergencyContactUser.FirstName = "Emergency First Name";
            EmergencyContactUser.LastName = "Emergency Last Name";
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
            TheTestUser.GenderType = primaryContact;
            EmergencyContactUser.GenderType = emergencyContact;
        }
    }
}