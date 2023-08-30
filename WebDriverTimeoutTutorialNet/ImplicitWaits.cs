using AutomationResourcesNet;
using OpenQA.Selenium;

namespace WebDriverTimeoutTutorialNet;

[TestFixture]
[Category("Implicit waits")]
public class ImplicitWaits
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
    public void Test1()
    {
        Assert.That(() =>
        {
            _driver.Navigate().GoToUrl(URL.SlowAnimationUrl);
            FillOutCreditCardInfo();
            _driver.FindElement(By.Id("go")).Click();
            Assert.IsTrue(_driver.FindElement(By.Id("success")).Displayed);
        }, Throws.TypeOf<ElementNotVisibleException>());

    }

    private void FillOutCreditCardInfo()
    {
        _driver.FindElement(By.Id("name")).SendKeys("test name");
        _driver.FindElement(By.Id("cc")).SendKeys("1234123412341234");
        _driver.FindElement(By.Id("month")).SendKeys("01");
        _driver.FindElement(By.Id("year")).SendKeys("2020");
    }

    [Test]
    public void Test1_FixedImplicitly()
    {
        Assert.That(() =>
        {
            _driver.Navigate().GoToUrl(URL.SlowAnimationUrl);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            FillOutCreditCardInfo();
            _driver.FindElement(By.Id("go")).Click();
            Assert.IsTrue(_driver.FindElement(By.Id("success")).Displayed);
        }, Throws.TypeOf<ElementNotVisibleException>());


    }

    [Test]
    public void Test2_ImplicitWaitExample()
    {
        Assert.That(() =>
        {
            _driver.Navigate().GoToUrl("https://www.ultimateqa.com");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Assert.IsTrue(_driver.FindElement(By.Id("success")).Displayed);
        }, Throws.TypeOf<ElementNotVisibleException>());

    }

    [Test]
    public void Test3_ImplicitWait_HiddenElement()
    {
        Assert.That(() =>
        {
            _driver.Navigate().GoToUrl(URL.HiddenElementUrl);
            SetImplicitWaitAndClick();
        }, Throws.TypeOf<ElementNotVisibleException>());


    }
    [Test]
    public void Test4_ImplicitWait_RenderedAfter()
    {
        Assert.That(() =>
        {
            _driver.Navigate().GoToUrl(URL.ElementRenderedAfterUrl);
            SetImplicitWaitAndClick();
        }, Throws.TypeOf<NoSuchElementException>());

    }

    private void SetImplicitWaitAndClick()
    {
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        _driver.FindElement(By.Id("finish")).Click();
    }
}
