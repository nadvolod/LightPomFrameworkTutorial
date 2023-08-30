using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CreatingReportsNet.Pages;

public class LeftPageSection : BaseApplicationPage
{
    public LeftPageSection(IWebDriver driver) : base(driver)
    {
    }
    public IWebElement SearchForm => Driver.FindElements(By.XPath("//form[@role='search']"))[1];
    public IWebElement SearchBox => Driver.FindElements(By.XPath("//form[@role='search']//input[@id='s']"))[0];
    public IWebElement SearchButton => SearchForm.FindElement(By.Id("searchsubmit"));

    public SearchResultsPage Search(string searchString)
    {
        SearchBox.SendKeys(searchString);
        Reporter.LogPassingTestStepToBugLogger($"Search for string=>{searchString} in the left pane's Search bar.");
        WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.ClassName("jetpack-instant-search__search-results-title")));
        return new SearchResultsPage(Driver);
    }
}