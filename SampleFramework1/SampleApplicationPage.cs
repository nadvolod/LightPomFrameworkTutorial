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
                return Driver.Title.Contains("Sample Application Lifecycle - Sprint 1 - Ultimate QA");
            }
            internal set { }
        }

        public IWebElement FirstNameField => Driver.FindElement(By.Name("firstname"));

        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//*[@type='submit']"));

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/sample-application-lifecycle-sprint-1/");
        }

        internal UltimateQAHomePage FillOutFormAndSubmit(string firstName)
        {
            FirstNameField.SendKeys(firstName);
            SubmitButton.Submit();
            return new UltimateQAHomePage(Driver);
        }
    }
}