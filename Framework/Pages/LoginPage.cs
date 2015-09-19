using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Framework.Pages
{
    public class LoginPage
    {
        public void Goto()
        {
            Browser.Goto("/wp-login.php");
        }

        public void Login(string userName, string password)
        {
            //find the field for ther user name
            var userNameField = Browser.Driver.FindElement(By.Id("user_login"));
            userNameField.SendKeys(userName);

            //find the field for the password
            var passwordField = Browser.Driver.FindElement(By.Id("user_pass"));
            passwordField.SendKeys(password);

            Browser.Driver.FindElement(By.Id("wp-submit")).Click();
        }
    }
}