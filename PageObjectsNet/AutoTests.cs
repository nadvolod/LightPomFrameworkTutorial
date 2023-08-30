using AutomationResourcesNet;
using OpenQA.Selenium;

namespace PageObjectsNet;

[TestFixture]
[Category("PageObject Tests")]
public class AutoTests
{
    private IWebDriver _driver;
    [SetUp]
    public void Setup()
    {
        _driver = new WebDriverFactory().Create(BrowserType.Chrome);
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }

    [Test]
    public void Test()
    {
        var theShoppingCart = new ShoppingCartPage(_driver).Open().AddItemToCart();
        Assert.AreEqual(1, theShoppingCart.ItemsInCart(), "we added only 1 item to the cart");
    }

    [Test]
    public void Test2()
    {
        var theShoppingCart = new ShoppingCartPage(_driver).Open().AddItemToCart();
        Assert.AreEqual(1, theShoppingCart.ItemsInCart(), "we added only 1 item to the cart");

        //Do something else
    }

    [Test]
    public void Test3()
    {
        var theShoppingCart = new ShoppingCartPage(_driver).Open().AddItemToCart();
        Assert.AreEqual(1, theShoppingCart.ItemsInCart(), "we added only 1 item to the cart");
        //Do something else 
        //And maybe something else
    }
}
