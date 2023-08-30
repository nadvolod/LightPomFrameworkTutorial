using OpenQA.Selenium;

namespace CreatingReportsNet.Pages;

public class HeaderSection : BaseApplicationPage
{

    public HeaderSection(IWebDriver driver) : base(driver)
    {
    }

    public IWebElement ContactUsButton => Driver.FindElement(By.Id("contact-link"));

    public IWebElement SignInButton => Driver.FindElement(By.ClassName("login"));

    internal ContactUsPage ClickContactUsButton()
    {
        ContactUsButton.Click();
        Reporter.LogPassingTestStepToBugLogger("Click the Contact Us button in the header.");
        return new ContactUsPage(Driver);
    }

    internal SignInPage ClickSignInButton()
    {
        SignInButton.Click();
        Reporter.LogPassingTestStepToBugLogger("Click the sign in button in the header.");
        return new SignInPage(Driver);
    }
}