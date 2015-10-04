using OpenQA.Selenium;

namespace Framework.Pages
{
    public class MyMembershipPage
    {
        private int PAGE_LOAD_TIMEOUT = 10;

        public bool IsAt()
        {
            By element = By.XPath("//h1[contains(text(),'My Membership')]");
            return Browser.WaitUntilElementIsDisplayed(element, PAGE_LOAD_TIMEOUT);
        }

        public void EditProfile()
        {
            var editProfile = Browser.FindElement(By.LinkText("Edit Profile"));
            editProfile.Click();
        }
    }
}