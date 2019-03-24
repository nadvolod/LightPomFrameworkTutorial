using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace PageObjects
{
    [TestClass]
    [TestCategory("PageObject Tests")]
    public class AutoTests
    {
        private IWebDriver _driver;
        [TestInitialize]
        public void Setup()
        {
            _driver = new WebDriverFactory().Create(BrowserType.Chrome);
        }
        [TestCleanup]
        public void TearDown()
        {
            _driver.Quit();
        }
        [TestMethod]
        public void Test()
        {
            var theShoppingCart = new ShoppingCartPage(_driver).Open().AddItemToCart();
            Assert.AreEqual(1, theShoppingCart.ItemsInCart(), "we added only 1 item to the cart");
        }

        [TestMethod]
        public void Test2()
        {
            var theShoppingCart = new ShoppingCartPage(_driver).Open().AddItemToCart();
            Assert.AreEqual(1, theShoppingCart.ItemsInCart(), "we added only 1 item to the cart");
            
            //Do something else
        }
        [TestMethod]
        public void Test3()
        {
            var theShoppingCart = new ShoppingCartPage(_driver).Open().AddItemToCart();
            Assert.AreEqual(1, theShoppingCart.ItemsInCart(), "we added only 1 item to the cart");
            //Do something else 
            //And maybe something else
        }
    }
}
