using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElementInteractions
{
    [TestClass]
    [TestCategory("Locating web elements")]
    public class IdentifyingWebElements
    {
        public IWebDriver Driver { get; private set; }
        [TestInitialize]
        public void SetupBeforeEveryTestMethod()
        {
            Driver = new WebDriverFactory().Create(BrowserType.Chrome);
        }
        [TestMethod]
        public void DifferentTypesOfSeleniumLocationStrategies()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/simple-html-elements-for-automation/");
            HighlightElementUsingJavaScript(By.ClassName("buttonClass"));
            HighlightElementUsingJavaScript(By.Id("idExample"));
            HighlightElementUsingJavaScript(By.LinkText("Click me using this link text!"));
            HighlightElementUsingJavaScript(By.Name("button1"));
            HighlightElementUsingJavaScript(By.PartialLinkText("link text!"));
            HighlightElementUsingJavaScript(By.TagName("div"));
            HighlightElementUsingJavaScript(By.CssSelector("#idExample"));
            HighlightElementUsingJavaScript(By.CssSelector(".buttonClass"));
            HighlightElementUsingJavaScript(By.XPath("//*[@id='idExample']"));
            HighlightElementUsingJavaScript(By.XPath("//*[@class='buttonClass']"));
        }

        /*
         Highlight this link using all of the different location strategies
             */
        [TestMethod]
        public void SeleniumLocationStrategiesQuiz()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/simple-html-elements-for-automation/");
            var link = Driver.FindElements(By.ClassName("et_pb_blurb_description"))[4];
            //HighlightElementUsingJavaScript(By.ClassName("et_pb_blurb_description"));
            HighlightElementUsingJavaScript(By.Id("simpleElementsLink"));
            HighlightElementUsingJavaScript(By.LinkText("Click this link"));
            HighlightElementUsingJavaScript(By.Name("clickableLink"));
            HighlightElementUsingJavaScript(By.PartialLinkText("Click this lin"));
            HighlightElementUsingJavaScript(By.TagName("a"));
            HighlightElementUsingJavaScript(By.CssSelector("#simpleElementsLink"));
            HighlightElementUsingJavaScript(By.XPath("//*[@id='simpleElementsLink']"));
        }

        [TestMethod]
        public void SeleniumElementLocationExam()
        {
 
            /*
             *-Using only XPath!!
             -When debugging and testing, make sure that you scroll the element into view, Selenium
             will not scroll for you. Not yet...
             */

            //click any radio button
            //select one checkbox
            //after selecting that checkbox, highlight the text that it applies to
            //select Audi from the dropdown
            //open Tab2 and assert that it is opened. Hint, use .Text property when you find the element
            //in the HTML Table with id, highlight one of the salary cells
            //Highlight the center section called "Highlight me", but you can only
            //highlight the highest level div for that element. The top parent div.
            //Hint, this is the class - et_pb_column et_pb_column_1_3  et_pb_column_10 et_pb_css_mix_blend_mode_passthrough

            Driver.FindElement(By.XPath("//*[@type='radio'][@value='male']")).Click();
            Driver.FindElement(By.XPath("//*[@value='Bike']")).Click();
            Driver.FindElement(By.TagName("select")).Click();
            Driver.FindElement(By.XPath("//*[@value='audi']")).Click();

            Driver.FindElement(By.XPath("//li[@class='et_pb_tab_1']")).Click();
            Assert.AreEqual(" Tab 2 content", 
                Driver.FindElement(By.XPath("//*[@class='et_pb_tab clearfix et_pb_tab_1 et-pb-active-slide']")).Text);
            HighlightElementUsingJavaScript(By.XPath("//td[contains(text(),'$150,000+')]"));

            //HighlightElementUsingJavaScript(By.ClassName("et_pb_column et_pb_column_1_3  et_pb_column_10 et_pb_css_mix_blend_mode_passthrough"));
            HighlightElementUsingJavaScript(
                By.XPath("//*[@class='et_pb_column et_pb_column_1_3  et_pb_column_10 et_pb_css_mix_blend_mode_passthrough']"));
        }

        private void HighlightElementUsingJavaScript(By locationStrategy, int duration = 2)
        {
            var element = Driver.FindElement(locationStrategy);
            var originalStyle = element.GetAttribute("style");
            IJavaScriptExecutor JavaScriptExecutor = Driver as IJavaScriptExecutor;
            JavaScriptExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])",
                element,
                "style",
                "border: 7px solid yellow; border-style: dashed;");

            if (duration <= 0) return;
            Thread.Sleep(TimeSpan.FromSeconds(duration));
            JavaScriptExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])",
                element,
                "style",
                originalStyle);
        }
        [TestCleanup]
        public void CleanupAfterEveryTestMethod()
        {
            Driver.Quit();
        }
        [TestMethod]
        public void ElementIdentificationTest()
        {
            //driver.Navigate().GoToUrl("http://www.qtptutorial.net/automation-practice");

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
            //locator = By.TagName("table");
            //IList<IWebElement> tables = driver.FindElements(locator);
        }


    }
}
