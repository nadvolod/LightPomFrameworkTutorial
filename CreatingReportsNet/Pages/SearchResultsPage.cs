using OpenQA.Selenium;

namespace CreatingReportsNet.Pages;

public class SearchResultsPage : BaseApplicationPage
{
    public SearchResultsPage(IWebDriver driver) : base(driver)
    {
    }

    public bool IsLoaded => Driver.Url.Contains("?s");
}