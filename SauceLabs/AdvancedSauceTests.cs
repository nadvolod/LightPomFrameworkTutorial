using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SauceLabs
{

    [Category("DataDrivenParallelTests")]
    [Parallelizable]
    [TestFixture("chrome", "45", "Windows 7", "", "")]
    [TestFixture("chrome", "50", "Windows 7", "", "")]
    [TestFixture("MicrosoftEdge", "14.14393", "Windows 10", "", "")]
    [TestFixture("chrome", "6.0", "Android", "Android Emulator", "portrait")]
    [TestFixture("Safari", "11.2", "iOS", "iPhone X Simulator", "portrait")]
    public class AdvancedSauceTests : BaseTest
    {
        public AdvancedSauceTests(string browser, string version, string os, string deviceName, string deviceOrientation) : 
            base(browser, version, os, deviceName, deviceOrientation)
        {
        }

        [Test]
        public void TestMethodInClass1()
        {
            Driver.Navigate().GoToUrl("https://www.google.com");
            Assert.Pass("passed the test");
        }

    }
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




    /*
     * Test Requirements:
     * 1. Data drive a single test method to execute on all of these configurations in parallel
     * - Latest chrome, cannot be a specific version
     * - MicrosoftEdge, any version
     * - iPhone X Simulator
     * - Samsugn Galaxy Tab S3 emulator
     * - Samsung Galaxy S8 emulator
     * 2. Even though you have 5 test configurations,
     * you are only allowed to run a maximum of 4 parallel sessions at the same time
     * 3. The test will perform the following actions:
     * - open www.google.com
     * - type in ultimate qa
     * - Search for that string
     * - Click link that goes to www.ultimateqa.com
     * - Write a log command into Sauce Labs that says "Search string 'ultimate qa' in Google"
     * - Pass test
     * 4. When the tests run in Sauce Labs, their job name should be the test method name, in this case 'ExamTestMethod'
     * 5. make sure that the error or pass message gets logged to sauce labs
     */
    [Category("Exam")]
    [Parallelizable]
    [TestFixture("chrome", "", "Windows 7", "", "")]
    [TestFixture("MicrosoftEdge", "14.14393", "Windows 10", "", "")]
    [TestFixture("Safari", "11.2", "iOS", "iPhone X Simulator", "portrait")]
    [TestFixture("chrome", "7.1", "Android", "Samsung Galaxy Tab S3 GoogleAPI Emulator", "portrait")]
    [TestFixture("chrome", "7.1", "Android", "Samsung Galaxy S8 Plus GoogleAPI Emulator", "portrait")]
    public class Exam : BaseTest
    {
        public Exam(string browser, string version, string os, string deviceName, string deviceOrientation) : 
            base(browser, version, os, deviceName, deviceOrientation)
        {
        }

        [Test]
        public void ExamTestMethod()
        {
            Driver.Navigate().GoToUrl("https://www.google.com");
            Driver.FindElement(By.Id("lst-ib")).SendKeys("ultimate qa");
            Thread.Sleep(5000);
            var actions = new Actions(Driver);
            actions.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)Driver).ExecuteScript("sauce:context=Search string 'ultimate qa' in Google");
            Driver.FindElement(By.XPath("//a[@href='https://www.ultimateqa.com/']")).Click();
            Assert.Pass("passed the test");
        }

    }
}
