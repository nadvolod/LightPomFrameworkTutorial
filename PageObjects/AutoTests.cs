using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace PageObjects
{
    [TestClass]
    [TestCategory("KDF Tests")]
    public class AutoTests
    {
        public void Setup()
        {
            //TODO need some complicated logic that will read some data source
            //and use reflection to execute test methods
            // 100s of lines of code of extra maintenance
        }
        [TestMethod]
        public void Test()
        {
            var driver = OpenChrome();
            GoToUrl(driver);
            ClickButton(driver, By.ClassName("shelf-item__buy-btn"));
            var bagQuantity = GetText(driver, By.ClassName("bag__quantity"));
            Assert.AreEqual(1, int.Parse(bagQuantity), "we added only 1 item to the cart");
            driver.Quit();
        }

        private static string GetText(IWebDriver driver, By className)
        {
            return driver.FindElement(className).Text;
        }

        private static void ClickButton(IWebDriver driver, By className)
        {
            driver.FindElement(className).Click();
        }

        private static void GoToUrl(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://localhost:3000/");
        }

        private static IWebDriver OpenChrome()
        {
            return new WebDriverFactory().Create(BrowserType.Chrome);
        }

        [TestMethod]
        public void Test2()
        {
            var driver = OpenChrome();
            GoToUrl(driver);
            ClickButton(driver, By.ClassName("shelf-item__buy-btn"));
            var bagQuantity = GetText(driver, By.ClassName("bag__quantity"));
            Assert.AreEqual(1, int.Parse(bagQuantity), "we added only 1 item to the cart");
            
            //Do something else
            driver.Quit();
        }
        [TestMethod]
        public void Test3()
        {
            var driver = OpenChrome();
            GoToUrl(driver);
            ClickButton(driver, By.ClassName("shelf-item__buy-btn"));
            var bagQuantity = GetText(driver, By.ClassName("bag__quantity"));
            Assert.AreEqual(1, int.Parse(bagQuantity), "we added only 1 item to the cart");
            
            //Do something else 
            //And maybe something else
            driver.Quit();
        }
    }
}
