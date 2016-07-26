using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework;
using OpenQA.Selenium;

namespace FrameworkTests
{
    [TestClass]
    public class BrowserTests
    {
        [TestInitialize]
        public void TestSetup()
        {
            Browser.Initialize();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Browser.Close();
            Browser.Quit();
        }
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


    }
}
