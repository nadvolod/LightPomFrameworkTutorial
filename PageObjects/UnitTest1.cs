using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace PageObjects
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RecordedTest()
        {
            var driver = new WebDriverFactory().Create(BrowserType.Chrome);
            driver.Navigate().GoToUrl("http://localhost:3000/");
            driver.FindElement(By.ClassName("shelf-item__buy-btn")).Click();
            var bagQuantity = driver.FindElement(By.ClassName("bag__quantity")).Text;
            Assert.AreEqual(1, bagQuantity, "we added only 1 item to the cart");
            driver.Quit();
        }
    }
}
