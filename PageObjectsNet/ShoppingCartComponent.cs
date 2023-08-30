using OpenQA.Selenium;

namespace PageObjectsNet;

public class ShoppingCartComponent
{
    private readonly IWebDriver _driver;

    public ShoppingCartComponent(IWebDriver driver)
    {
        _driver = driver;
    }

    public int ItemsInCart()
    {
        return int.Parse(_driver.FindElement(By.ClassName("bag__quantity")).Text);
    }
}