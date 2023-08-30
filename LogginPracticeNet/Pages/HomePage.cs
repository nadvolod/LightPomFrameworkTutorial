using NLog;
using OpenQA.Selenium;

namespace LogginPracticeNet.Pages;

internal class HomePage : BaseApplicationPage
{
    private static Logger _logger = LogManager.GetCurrentClassLogger();
    public HomePage(IWebDriver driver) : base(driver)
    {
        Slider = new Slider(driver);
    }

    public Slider Slider { get; internal set; }

    internal void GoTo()
    {
        var url = "http://automationpractice.com";
        Driver.Navigate().GoToUrl(url);
        _logger.Info($"Open url=>{url}");
    }

    internal SearchPage Search(string itemToSearchFor)
    {
        _logger.Trace("Attempting to perform a Search.");
        Driver.FindElement(By.Id("search_query_top")).SendKeys(itemToSearchFor);
        Driver.FindElement(By.Name("submit_search")).Click();
        _logger.Info($"Search for an item in the search bar=>{itemToSearchFor}");
        return new SearchPage(Driver);
    }
}