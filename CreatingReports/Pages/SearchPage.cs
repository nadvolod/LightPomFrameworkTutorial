using System;
using OpenQA.Selenium;

namespace CreatingReports.Pages
{
    internal class SearchPage : BaseApplicationPage
    {
        public SearchPage(IWebDriver driver) : base(driver)
        {
        }

        internal bool Contains(Item itemToCheckFor)
        {
            switch (itemToCheckFor)
            {
                case Item.Blouse:
                    return Driver.FindElement(By.XPath("//*[@title='Blouse']")).Displayed;
                default:
                    throw new ArgumentOutOfRangeException("No such item exists in this collection");
            }
        }
    }
}