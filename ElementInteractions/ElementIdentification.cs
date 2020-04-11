using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ElementInteractions
{
    [TestClass]
    [TestCategory("Identification and manipulations")]
    public class ElementIdentification
    {
        static IWebDriver driver;
        private IWebElement element;
        private By locator;

        [TestInitialize]
        public void TestSetup()
        {
            /**
             * Automation AutomationResources comes from our solution. It's a project called
             * AutomationResources.
             * We get to use it becuase we added it in References > Add Refernce > Projects > select Automation Resources
             * Now we get to use the WebDriverFactory from the AutomationResource project.
             */
            driver = new AutomationResources.WebDriverFactory().CreateChromeDriver();
        }

        [TestMethod]
        [TestCategory("Navigation")]
        public void SeleniumNavigation()
        {
            driver.Navigate().GoToUrl("https://www.ultimateqa.com/automation");
            driver.Navigate().Forward();
            driver.Navigate().Back();
            driver.Navigate().Refresh();
        }

        [TestMethod]
        [TestCategory("Navigation")]
        public void SeleniumNavigationTest()
        {
            //Go here and assert for title - "https://www.ultimateqa.com"
            driver.Navigate().GoToUrl("https://www.ultimateqa.com");
            Assert.AreEqual("Home - Ultimate QA", driver.Title);
            //Go here and assert for title - "https://www.ultimateqa.com/automation"
            driver.Navigate().GoToUrl("https://www.ultimateqa.com/automation");
            Assert.AreEqual("Automation Practice - Ultimate QA", driver.Title);
            //Click link with href - /complicated-page
            driver.FindElement(By.XPath("//*[@href='/complicated-page']")).Click();
            //assert page title 'Complicated Page - Ultimate QA'
            Assert.AreEqual("Complicated Page - Ultimate QA", driver.Title);
            //Go back
            driver.Navigate().Back();
            //assert page title equals - 'Automation Practice - Ultimate QA'
            Assert.AreEqual("Automation Practice - Ultimate QA", driver.Title);
        }
        [TestMethod]
        [TestCategory("Manipulation")]
        public void Manipulation()
        {
            driver.Navigate().GoToUrl("https://www.ultimateqa.com/filling-out-forms/");
            //find the name field

            var nameField = driver.FindElement(By.Id("et_pb_contact_name_1"));
            nameField.Clear();
            nameField.SendKeys("test");
            //clear the field
            //type into the field

            //find the text field
            var textBox = driver.FindElement(By.Id("et_pb_contact_message_1"));
            //clear the field
            textBox.Clear();
            //type into the field
            textBox.SendKeys("testing");
            //submit
            var submitButton = driver.FindElements(By.ClassName("et_contact_bottom_container"));
            submitButton[0].Submit();
        }

        [TestMethod]
        [TestCategory("Manipulation")]
        public void ManipulationTest()
        {
            driver.Navigate().GoToUrl("https://www.ultimateqa.com/filling-out-forms/");
            var name = driver.FindElements(By.Id("et_pb_contact_name_1"));
            name[0].SendKeys("test");

            var textArea = driver.FindElements(By.Id("et_pb_contact_message_1"));
            textArea[0].SendKeys("test text");

            var captcha = driver.FindElement(By.ClassName("et_pb_contact_captcha_question"));
            //show example of how this will work in Chrome dev tools but not in code
            var table = new DataTable();
            var captchaAnswer = (int)table.Compute(captcha.Text,"");

            var captchaTextBox = driver.FindElement(By.XPath("//*[@class='input et_pb_contact_captcha']"));
            captchaTextBox.SendKeys(captchaAnswer.ToString());

            driver.FindElements(By.XPath("//*[@class='et_pb_contact_submit et_pb_button']"))[1].Submit();
            var successMessage = driver.FindElements(By.ClassName("et-pb-contact-message"))[1].FindElement(By.TagName("p"));
            Assert.IsTrue(successMessage.Text.Equals("Success"));
        }

        [TestMethod]
        [TestCategory("Driver Interrogation")]
        public void DriverLevelInterrogation()
        {
            driver.Navigate().GoToUrl("https://www.ultimateqa.com/automation");
            var x = driver.CurrentWindowHandle;
            var y = driver.WindowHandles;
            x = driver.PageSource;
            x = driver.Title;
            x = driver.Url;
        }

        [TestMethod]
        [TestCategory("Element Interrogation")]
        public void ElementInterrogation()
        {
            driver.Navigate().GoToUrl("https://www.ultimateqa.com/automation/");
            var myElement = driver.FindElement(By.XPath("//*[@href='https://courses.ultimateqa.com/users/sign_in']"));
        }

        [TestMethod]
        [TestCategory("Element Interrogation")]
        public void ElementInterrogationTest()
        {
            driver.Url = "https://www.ultimateqa.com/simple-html-elements-for-automation/";
            driver.Manage().Window.Maximize();
            //1. find button by Id
            //2. GetAttribute("type") and assert that it equals the right value
            //3. GetCssValue("letter-spacing") and assert that it equals the correct value
            //4. Assert that it's Displayed
            //5. Assert that it's Enabled
            //6. Assert that it's NOT selected
            //7. Assert that the Text is correct
            //8. Assert that the TagName is correct
            //9. Assert that the size height is 21
            //10. Assert that the location is x=190, y=330





            var myElement = driver.FindElement(By.Id("button1"));
            Assert.AreEqual("submit", myElement.GetAttribute("type"));
            Assert.AreEqual("normal", myElement.GetCssValue("letter-spacing"));
            Assert.IsTrue(myElement.Displayed);
            Assert.IsTrue(myElement.Enabled);
            Assert.IsFalse(myElement.Selected);
            Assert.AreEqual(myElement.Text, "Click Me!");
            Assert.AreEqual("button", myElement.TagName);
            Assert.AreEqual(21, myElement.Size.Height);
            Assert.AreEqual(190, myElement.Location.X);
            Assert.AreEqual(330, myElement.Location.Y);
        }




        [TestCleanup]
        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
