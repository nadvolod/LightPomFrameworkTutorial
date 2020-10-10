using OpenQA.Selenium;

namespace CreatingReports.Pages
{
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
            Reporter.LogPassingTestStepToBugLogger($"Serach for string=>{searchString} in the left pane's Search bar.");
            return new SearchResultsPage(Driver);
        }
    }
}