using OpenQA.Selenium;

namespace PageObjects
{
    public class ShoppingCartPage
    {
        private IWebDriver _driver;

        public ShoppingCartPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public ShoppingCartPage Open()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");
            return this;
        }

        public ShoppingCartComponent AddItemToCart()
        {
            _driver.FindElement(By.ClassName("shelf-item__buy-btn")).Click();
            return new ShoppingCartComponent(_driver);
        }
    }
}