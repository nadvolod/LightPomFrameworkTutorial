using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace ElementInteractions
{
    [TestClass]
    [TestCategory("Identification and manipulations")]
    public class ElementIdentification
    {
        IWebDriver _driver;
        private IWebElement element;
        private By locator;

        [TestInitialize]
        public void TestSetup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [TestMethod]
        [TestCategory("Navigation")]
        public void SeleniumNavigation()
        {
            _driver.Navigate().GoToUrl("https://www.ultimateqa.com/automation");
            _driver.Navigate().Forward();
            _driver.Navigate().Back();
            _driver.Navigate().Refresh();
        }

        [TestMethod]
        [TestCategory("Navigation")]
        public void SeleniumNavigationTest()
        {
            //Go here and assert for title - "https://www.ultimateqa.com"
            _driver.Navigate().GoToUrl("https://www.ultimateqa.com");
            Assert.AreEqual("Home - Ultimate QA", _driver.Title);
            //Go here and assert for title - "https://www.ultimateqa.com/automation"
            _driver.Navigate().GoToUrl("https://www.ultimateqa.com/automation");
            Assert.AreEqual("Automation Practice - Ultimate QA", _driver.Title);
            //Click link with href - /complicated-page
            _driver.FindElement(By.XPath("//*[@href='/complicated-page']")).Click();
            //assert page title 'Complicated Page - Ultimate QA'
            Assert.AreEqual("Complicated Page - Ultimate QA", _driver.Title);
            //Go back
            _driver.Navigate().Back();
            //assert page title equals - 'Automation Practice - Ultimate QA'
            Assert.AreEqual("Automation Practice - Ultimate QA", _driver.Title);
        }
        [TestMethod]
        [TestCategory("Manipulation")]
        public void Manipulation()
        {
            _driver.Navigate().GoToUrl("https://www.ultimateqa.com/filling-out-forms/");
            //find the name field

            var nameField = _driver.FindElement(By.Id("et_pb_contact_name_1"));
            nameField.Clear();
            nameField.SendKeys("test");
            //clear the field
            //type into the field

            //find the text field
            var textBox = _driver.FindElement(By.Id("et_pb_contact_message_1"));
            //clear the field
            textBox.Clear();
            //type into the field
            textBox.SendKeys("testing");
            //submit
            var submitButton = _driver.FindElements(By.ClassName("et_contact_bottom_container"));
            submitButton[0].Submit();
        }

        [TestMethod]
        [TestCategory("Manipulation")]
        public void ManipulationTest()
        {
            _driver.Navigate().GoToUrl("https://www.ultimateqa.com/filling-out-forms/");
            var name = _driver.FindElements(By.Id("et_pb_contact_name_1"));
            name[0].SendKeys("test");

            var textArea = _driver.FindElements(By.Id("et_pb_contact_message_1"));
            textArea[0].SendKeys("test text");

            var captcha = _driver.FindElement(By.ClassName("et_pb_contact_captcha_question"));
            //show example of how this will work in Chrome dev tools but not in code
            var table = new DataTable();
            var captchaAnswer = (int)table.Compute(captcha.Text,"");

            var captchaTextBox = _driver.FindElement(By.XPath("//*[@class='input et_pb_contact_captcha']"));
            captchaTextBox.SendKeys(captchaAnswer.ToString());

            _driver.FindElements(By.XPath("//*[@class='et_pb_contact_submit et_pb_button']"))[1].Submit();
            var successMessage = _driver.FindElements(By.ClassName("et-pb-contact-message"))[1].FindElement(By.TagName("p"));
            Assert.IsTrue(successMessage.Text.Equals("Success"));
        }

        [TestMethod]
        [TestCategory("Driver Interrogation")]
        public void DriverLevelInterrogation()
        {
            _driver.Navigate().GoToUrl("https://www.ultimateqa.com/automation");
            var x = _driver.CurrentWindowHandle;
            var y = _driver.WindowHandles;
            x = _driver.PageSource;
            x = _driver.Title;
            x = _driver.Url;
        }

        [TestMethod]
        [TestCategory("Element Interrogation")]
        public void ElementInterrogation()
        {
            _driver.Navigate().GoToUrl("https://www.ultimateqa.com/automation/");
            var myElement = _driver.FindElement(By.XPath("//*[@href='https://courses.ultimateqa.com/users/sign_in']"));
        }

        [TestMethod]
        [TestCategory("Element Interrogation")]
        public void ElementInterrogationTest()
        {
            _driver.Url = "https://www.ultimateqa.com/simple-html-elements-for-automation/";
            _driver.Manage().Window.Maximize();
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





            var myElement = _driver.FindElement(By.Id("button1"));
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
            _driver.Close();
            _driver.Quit();
        }
    }
}
