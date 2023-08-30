using AutomationResourcesNet;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace WebDriverTimeoutTutorialNet;

class DynamicControlsTests
{
    private IWebDriver _driver;

    [SetUp]
    public void Setup()
    {
        _driver = new WebDriverFactory().Create(BrowserType.Chrome);
    }

    [TearDown]
    public void Teardown()
    {
        _driver.Close();
        _driver.Quit();
    }

    [Test]
    public void DynamicControlsTest()
    {

        Assert.That(() =>
        {
            _driver.Navigate().GoToUrl(URL.DynamicControlsURL);
            _driver.FindElement(By.XPath("//button[@onclick='swapCheckbox()']")).Click();
            Assert.IsTrue(_driver.FindElement(By.Id("message")).Displayed);
        }, Throws.TypeOf<NoSuchElementException>());
    }

    [Test]
    public void DynamicControlsTest_FixedImplicitly()
    {
        _driver.Navigate().GoToUrl(URL.DynamicControlsURL);
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        _driver.FindElement(By.XPath("//button[@onclick='swapCheckbox()']")).Click();
        Assert.IsTrue(_driver.FindElement(By.Id("message")).Displayed);
    }

    [Test]
    public void DynamicControlsTest_FixedExplicitly()
    {
        _driver.Navigate().GoToUrl(URL.DynamicControlsURL);
        _driver.FindElement(By.XPath("//button[@onclick='swapCheckbox()']")).Click();
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
        wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//input[@type='checkbox']")));
        Assert.IsTrue(wait.Until(ExpectedConditions.ElementIsVisible(By.Id("message"))).Displayed);
    }
}
