using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework.Pages
{
    public class LoginPage
    {
        WebDriverWait _wait = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(5));
        public void Goto()
        {
            Browser.Goto("/wp-login.php");          
        }

        public void LoginWithoutClef(string userName, string password)
        {
            var link = _wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("login with a password")));
            link.Click();

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