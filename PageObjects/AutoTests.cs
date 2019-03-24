using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace PageObjects
{
    [TestClass]
    public class AutoTests
    {
        [TestMethod]
        public void Test()
        {
            var driver = new WebDriverFactory().Create(BrowserType.Chrome);
            driver.Navigate().GoToUrl("http://localhost:3000/");
            driver.FindElement(By.ClassName("shelf-item__buy-btn")).Click();
            var bagQuantity = driver.FindElement(By.ClassName("bag__quantity")).Text;
            Assert.AreEqual(1, int.Parse(bagQuantity), "we added only 1 item to the cart");
            driver.Quit();
        }
        [TestMethod]
        public void Test2()
        {
            var driver = new WebDriverFactory().Create(BrowserType.Chrome);
            driver.Navigate().GoToUrl("http://localhost:3000/");
            driver.FindElement(By.ClassName("shelf-item__buy-btn")).Click();
            var bagQuantity = driver.FindElement(By.ClassName("bag__quantity")).Text;
            Assert.AreEqual(1, int.Parse(bagQuantity), "we added only 1 item to the cart");
            
            //Do something else
            driver.Quit();
        }
        [TestMethod]
        public void Test3()
        {
            var driver = new WebDriverFactory().Create(BrowserType.Chrome);
            driver.Navigate().GoToUrl("http://localhost:3000/");
            driver.FindElement(By.ClassName("shelf-item__buy-btn")).Click();
            var bagQuantity = driver.FindElement(By.ClassName("bag__quantity")).Text;
            Assert.AreEqual(1, int.Parse(bagQuantity), "we added only 1 item to the cart");
            
            //Do something else 
            //And maybe something else
            driver.Quit();
        }
    }
}
