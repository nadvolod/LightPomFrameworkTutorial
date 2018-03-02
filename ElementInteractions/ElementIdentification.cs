using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
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
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            driver = new ChromeDriver(outPutDirectory);
        }

        [TestMethod]
        public void ElementIdentificationTest()
        {
            driver.Navigate().GoToUrl("http://www.qtptutorial.net/automation-practice");

            ////Find an element using an id
            //driver.FindElement(By.Id("idExample"));
            //var idElement = driver.FindElement(By.Id("idExample"));
            //idElement.Click();
            //driver.Navigate().Back();

            ////Find an element using a ClassName
            //element = driver.FindElement(By.ClassName("buttonClassExample"));
            //element.Click();
            //driver.Navigate().Back();

            //////Find an element using Name
            //element = driver.FindElement(By.Name("NameExample"));
            //element.Click();
            //driver.Navigate().Back();

            //////Find an element using Link Text
            //var linkTextElement = driver.FindElement(By.LinkText("Click This Button Using 'ID'"));
            //linkTextElement.Click();
            //driver.Navigate().Back();

            ////Find an element using Partial Link Text
            //var linkTextElementP = driver.FindElement(By.PartialLinkText("Click me"));
            //linkTextElementP.Click();
            //driver.Navigate().Back();

            ////Find an element using Css
            //var cssElement = driver.FindElement(By.CssSelector(".et_pb_promo_button"));
            //cssElement.Click();
            //driver.Navigate().Back();

            //Find an element using Xpath
            //var xpathElement = driver.FindElement(By.XPath(".//*[@id='post-5969']/div/div[2]/div/div[1]/div[2]/a"));
            //xpathElement.Click();
            //driver.Navigate().Back();

            ////Click a radio button using the button order
            //locator = By.XPath("//input[@name='selection'][1]");
            //element = driver.FindElement(locator);
            //element.Click();

            ////Click a radio button using the text
            //locator = By.XPath("//input[@value='I love HP UFT']");
            //element = driver.FindElement(locator);
            //element.Click();

            //////Find a radio button list
            //By byXpath = By.XPath("//input[@type='radio']");
            //IList<IWebElement> elements = driver.FindElements(byXpath);

            ////////Working with HTML tables
            ////////How can you get the whole html table into an object?
            //locator = By.Id("htmlTableId");
            //var table = driver.FindElement(locator);

            //////how can you get a collection of all the rows in the table?
            //IList<IWebElement> collectionOfRows = table.FindElements(By.XPath("//*[@id='htmlTableId']/tbody/tr"));


            //////Using Selenium: What is the Salary of an SDET?
            //var columnIndex = -1;
            //var columnCounter = 1;
            //const string DESIRED_COLUMN_HEADER = "Salary";
            //const string DESIRED_VALUE = "Software Development Engineer in Test";

            //for (int tr = 0; tr < collectionOfRows.Count; tr++)    //for every single row in the table
            //{
            //    var row = collectionOfRows[tr];

            //    IList<IWebElement> allCellsInRow = row.FindElements(By.XPath("./*"));
            //    foreach (var cell in allCellsInRow)
            //    {
            //        if (cell.Text == DESIRED_COLUMN_HEADER)
            //        {
            //            columnIndex = columnCounter;
            //        }

            //        if (cell.Text == DESIRED_VALUE)
            //        {
            //            //.//*[@id='htmlTableId']/tbody/tr[2]/td[3]
            //            string salaryLocator = string.Format(".//*[@id='htmlTableId']/tbody/tr[{0}]/td[{1}]", tr + 1, columnIndex);
            //            var salary = driver.FindElement(By.XPath(salaryLocator));
            //            Console.WriteLine("The {0} of {1} is {2}", DESIRED_COLUMN_HEADER, DESIRED_VALUE, salary.Text);
            //        }
            //        columnCounter++;
            //    }
            //}

            ////How do you get an html table that has no id?
            locator = By.TagName("table");
            IList<IWebElement> tables = driver.FindElements(locator);
        }

        [TestMethod]
        [TestCategory("Navigation")]
        public void SeleniumNavigation()
        {
            driver.Navigate().GoToUrl("http://www.ultimateqa.com/automation");
            driver.Navigate().Forward();
            driver.Navigate().Back();
            driver.Navigate().Refresh();
        }

        [TestMethod]
        [TestCategory("Navigation")]
        public void SeleniumNavigationTest()
        {
            //Go here and assert for title - "http://www.ultimateqa.com"
            driver.Navigate().GoToUrl("http://www.ultimateqa.com");
            Assert.AreEqual("Home - Ultimate QA", driver.Title);
            //Go here and assert for title - "http://www.ultimateqa.com/automation"
            driver.Navigate().GoToUrl("http://www.ultimateqa.com/automation");
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
            driver.Navigate().GoToUrl("http://www.ultimateqa.com/filling-out-forms/");
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
            driver.Navigate().GoToUrl("http://www.ultimateqa.com/filling-out-forms/");
            var name = driver.FindElements(By.Id("et_pb_contact_name_1"));
            name[1].SendKeys("test");

            var textArea = driver.FindElements(By.Id("et_pb_contact_message_1"));
            textArea[1].SendKeys("test text");

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
            driver.Navigate().GoToUrl("http://www.ultimateqa.com/automation");
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
            driver.Navigate().GoToUrl("http://www.ultimateqa.com/automation/");
            var myElement = driver.FindElement(By.XPath("//*[@href='http://courses.ultimateqa.com/users/sign_in']"));
        }

        [TestMethod]
        [TestCategory("Element Interrogation")]
        public void ElementInterrogationTest()
        {
            driver.Url = "http://www.ultimateqa.com/simple-html-elements-for-automation/";
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
