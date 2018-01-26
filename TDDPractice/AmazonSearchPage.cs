using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TDDPractice
{
    internal class AmazonSearchPage
    {
        private IWebDriver driver;

        public AmazonSearchPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string ActualSearchResults
        {
            get
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(
                        "//*[@class='a-color-state a-text-bold']")));
                return element.Text.Replace('"', ' ').Trim();
            }
        }
    }
}