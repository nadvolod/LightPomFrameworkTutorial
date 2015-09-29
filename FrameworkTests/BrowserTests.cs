using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.IO;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace FrameworkTests
{
    [TestClass]
    public class BrowserTests
    {
        [TestMethod]
        public void GivenValidElement_WhenElementIsVisible_ElementIsDisplayedFindsElement()
        {
            Browser.Goto("data:text/html,<span id=\"hello\">Hello</span>", false);
            Assert.IsTrue(Browser.ElementIsDisplayed(By.Id("hello")), 
                "ElementIsDisplayed did not find the element when it was supposed to.");
        }

        [TestMethod]
        public void GivenValidElement_WhenElementIsHidden_ElementIsDisplayedDoesNotFindElement()
        {
            Browser.Goto("data:text/html,<span id=\"hello\" style=\"position:absolute;left:-9000px;width:0;overflow:hidden;\">Hello</span>", false);
            Assert.IsFalse(Browser.ElementIsDisplayed(By.Id("hello")),
                "ElementIsDisplayed found a hidden element invalidly.");
        }

        [TestMethod]
        public void GivenValidElement_WhenElementDoesNotHaveId_ElementIsDisplayedDoesNotFindElement()
        {
            Browser.Goto("data:text/html,Hello", false);
            Assert.IsFalse(Browser.ElementIsDisplayed(By.Id("hello")),
                "ElementIsDisplayed found an element that should not have been found");
        }

        [TestMethod]
        public void Test()
        {
            RemoteWebDriver driver = null;
            string serverPath = "Microsoft Web Driver";
            try
            {
                if (System.Environment.Is64BitOperatingSystem)
                {
                    serverPath = Path.Combine(System.Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%"), serverPath);
                }
                else
                {
                    serverPath = Path.Combine(System.Environment.ExpandEnvironmentVariables("%ProgramFiles%"), serverPath);
                }

                // location for MicrosoftWebDriver.exe
                EdgeOptions options = new EdgeOptions();
                options.PageLoadStrategy = EdgePageLoadStrategy.Eager;
                driver = new EdgeDriver(serverPath, options);

                //Set page load timeout to 5 seconds
                driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(5));

                // Navigate to https://www.bing.com/
                driver.Url = "https://www.bing.com/";

                // Find the search box and query for webdriver
                RemoteWebElement element = (RemoteWebElement)driver.FindElementById("sb_form_q");
                element.SendKeys("webdriver");
                element.SendKeys(Keys.Enter);

                // Wait for search result
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(x => x.Title.Contains("webdriver"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (driver != null)
                {
                    driver.Close();
                }
            }
        }
    }
}
