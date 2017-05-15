using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace SampleFramework1
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
        private string PageTitle => "Sample Application Lifecycle - Sprint 3 - Ultimate QA";

        public IWebElement FirstNameField => Driver.FindElement(By.Name("firstname"));

        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//*[@type='submit']"));

        public IWebElement LastNameField => Driver.FindElement(By.Name("lastname"));

        public IWebElement FemaleGenderRadioButton => Driver.FindElement(By.XPath("//input[@value='female']"));

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/sample-application-lifecycle-sprint-3/");
            Assert.IsTrue(IsVisible, 
                $"Sample application page was not visible. Expected=>{PageTitle}." +
                $"Actual=>{Driver.Title}");
        }

        internal UltimateQAHomePage FillOutFormAndSubmit(TestUser user)
        {
            SetGender(user);
            FirstNameField.SendKeys(user.FirstName);
            LastNameField.SendKeys(user.LastName);
            SubmitButton.Submit();
            return new UltimateQAHomePage(Driver);
        }

        private void SetGender(TestUser user)
        {
            switch (user.GenderType)
            {
                case Gender.Male:
                    break;
                case Gender.Female:
                    FemaleGenderRadioButton.Click();
                    break;
                case Gender.Other:
                    break;
                default:
                    break;
            }
        }
    }
}