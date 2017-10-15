using System;
using AventStack.ExtentReports;
using NLog;
using OpenQA.Selenium;

namespace CreatingReports.Pages
{
    internal class SearchPage : BaseApplicationPage
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public SearchPage(IWebDriver driver) : base(driver)
        {
        }

        internal bool Contains(Item itemToCheckFor)
        {
            Reporter.LogTestStepForBugLogger(Status.Info,
                $"Validate that item=>{itemToCheckFor} exists.");

            switch (itemToCheckFor)
            {
                case Item.Blouse:
                    var isBlouseDisplayed = Driver.FindElement(By.XPath("//*[@title='Blouse']")).Displayed;
                    Logger.Trace("Element found by XPath=>*[@title=\'Blouse\'] isDisplayed=>" + isBlouseDisplayed);
                    return isBlouseDisplayed;
                default:
                    throw new ArgumentOutOfRangeException("No such item exists in this collection");
            }
        }
    }
}