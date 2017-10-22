using System;
using OpenQA.Selenium;

namespace CreatingReports.Pages
{
    public class HeaderSection
    {
        private IWebDriver driver;

        public HeaderSection(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement ContactUsButton => driver.FindElement(By.Id("contact-link"));

        public IWebElement SignInButton => driver.FindElement(By.ClassName("login"));

        internal ContactUsPage ClickContactUsButton()
        {
            ContactUsButton.Click();
            Reporter.LogPassingTestStepToBugLogger("Click the Contact Us button in the header.");
            return new ContactUsPage(driver);
        }

        internal SignInPage ClickSignInButton()
        {
            SignInButton.Click();
            Reporter.LogPassingTestStepToBugLogger("Click the sign in button in the header.");
            return new SignInPage(driver);
        }
    }
}