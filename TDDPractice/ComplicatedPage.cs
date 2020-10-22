using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TDDPractice
{
    public class ComplicatedPage
    {
        public ComplicatedPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        internal void Open()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/complicated-page/");
        }

        internal AmazonSearchPage SearchUsingAmazon(string searchTerm)
        {
            var searchBar = Driver.FindElement(By.ClassName("amzn-native-search"));
            searchBar.SendKeys(searchTerm);
            Driver.FindElement(By.ClassName("amzn-native-search-go")).Click();

            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            return new AmazonSearchPage(Driver);
        }

        internal void SearchArticles(string searchTerm)
        {
            Driver.Manage().Window.Maximize();
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var searchBox = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#s")));
            searchBox.Click();
            var searchBar = Driver.FindElement(By.CssSelector("#jetpack-instant-search__box-input-1"));
            searchBar.SendKeys(searchTerm);
        }

        internal bool AreResultsReturned()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var searchResults = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(text(),'Found 110 results')]")));
            return searchResults.Displayed;
        }
    }
}