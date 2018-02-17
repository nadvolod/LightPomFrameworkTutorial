using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SauceLabs
{
    internal class SampleApplicationPage : BaseSampleApplicationPage
    {
        public SampleApplicationPage(IWebDriver driver) : base(driver){}

        public bool IsVisible {
            get
            {
                return Driver.Title.Contains(PageTitle);
            }
            internal set { }
        }

        private Actions WebDriverActions => new Actions(Driver);
        private string PageTitle => "Sample Application Lifecycle - Sprint 4 - Ultimate QA";

        public IWebElement FirstNameField =>  Driver.FindElement(By.Name("firstname"));

        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//*[@type='submit']"));

        public IWebElement LastNameField => Driver.FindElement(By.Name("lastname"));
        public IWebElement FemaleGenderRadioButton => Driver.FindElement(By.XPath("//input[@value='female']"));

        public IWebElement FemaleGenderRadioButtonForEmergencyContact => Driver.FindElement(By.Id("radio2-f"));

        public IWebElement FirstNameFieldForEmergencyContact => Driver.FindElement(By.Id("f2"));

        public IWebElement LastNameFieldForEmergencyContact => Driver.FindElement(By.Id("l2"));

        internal void FillOutEmergencyContactForm(TestUser emergencyContactUser)
        {
            SetGenderForEmergencyContact(emergencyContactUser);
            FirstNameFieldForEmergencyContact.SendKeys(emergencyContactUser.FirstName);
            LastNameFieldForEmergencyContact.SendKeys(emergencyContactUser.LastName);
        }

        private void SetGenderForEmergencyContact(TestUser user)
        {
            switch (user.GenderType)
            {
                case Gender.Male:
                    break;
                case Gender.Female:
                    WebDriverActions.MoveToElement(FemaleGenderRadioButtonForEmergencyContact).Click();
                    break;
                case Gender.Other:
                    break;
                default:
                    break;
            }
        }



        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/sample-application-lifecycle-sprint-4/");
            Thread.Sleep(60000);
            Assert.IsTrue(IsVisible, 
                $"Sample application page was not visible. Expected=>{PageTitle}." +
                $"Actual=>{Driver.Title}");
        }

        internal UltimateQAHomePage FillOutPrimaryContactFormAndSubmit(TestUser user)
        {
            SetGender(user);
            WebDriverActions.MoveToElement(FirstNameField).SendKeys(user.FirstName);
            WebDriverActions.MoveToElement(LastNameField).SendKeys(user.LastName);
            WebDriverActions.MoveToElement(SubmitButton).Click();
            return new UltimateQAHomePage(Driver);
        }

        private void SetGender(TestUser user)
        {
            switch (user.GenderType)
            {
                case Gender.Male:
                    break;
                case Gender.Female:
                    WebDriverActions.MoveToElement(FemaleGenderRadioButton).Click();
                    break;
                case Gender.Other:
                    break;
                default:
                    break;
            }
        }
    }
}