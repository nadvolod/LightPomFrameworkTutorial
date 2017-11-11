using OpenQA.Selenium;
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
    }
}