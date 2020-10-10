using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CreatingReports.Pages
{
    public class RandomStuffSection : BaseApplicationPage
    {
        public RandomStuffSection(IWebDriver driver) : base(driver)
        {
        }
        public bool IsFormSubmitted
        {
            get
            {
                {
                    var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
                    try
                    {
                        var element = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("et-pb-contact-message")));
                        var isSubmitted = element.Text.Contains("Thanks for contacting us");
                        Reporter.LogTestStepForBugLogger(AventStack.ExtentReports.Status.Pass, "Validate that the form was submitted successfully");
                        return isSubmitted;
                    }
                    catch (WebDriverTimeoutException)
                    {
                        return false;
                    }

                }

            }
        }
        public LeftPageSection LeftPane => new LeftPageSection(Driver);

        internal void FillOutFormAndSubmit(string name, string email, string message)
        {
            Driver.FindElement(By.Id("et_pb_contact_name_0")).SendKeys(name);
            Driver.FindElement(By.Id("et_pb_contact_email_0")).SendKeys(email);
            Driver.FindElement(By.Id("et_pb_contact_message_0")).SendKeys(message);

            var captchaPuzzle = Driver.FindElement(By.ClassName("et_pb_contact_captcha_question")).Text;
            var split = captchaPuzzle.Split(' ');
            var result = int.Parse(split[0]) + int.Parse(split[2]);
            Driver.FindElement(By.XPath(@"//*[@class='input et_pb_contact_captcha']")).SendKeys(result.ToString());
            Driver.FindElement(By.XPath(@"//*[@class='et_pb_contact_submit et_pb_button']")).Click();
            Reporter.LogPassingTestStepToBugLogger("Fill out the form in the Random Stuff section." +
                $"Name={name}. Email=>{email}. Message=>{message}.");
        }
    }
}