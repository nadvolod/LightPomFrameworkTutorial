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

        internal ContactUsPage ClickContactUsButton()
        {
            ContactUsButton.Click();
            Reporter.LogPassingTestStepToBugLogger("Click the Contact Us button in the header.");
            return new ContactUsPage(driver);
        }
    }
}