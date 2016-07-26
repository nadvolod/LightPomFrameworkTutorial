using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace QtpTests
{
    [TestClass]
    public class LoginWithInvalidUserNameShouldNotWork
    {
        [TestMethod]
        public void RunTest()
        {
            //here we create a new instance of the Firefox driver
            var driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.qtptutorial.net/wp-login.php");

            //find the field for ther user name
            var user = driver.FindElement(By.Id("user_login"));
            user.SendKeys("InvalidUserName");

            //find the field for the password
            var pass = driver.FindElement(By.Id("user_pass"));
            pass.SendKeys("Test12345!!$");

            driver.FindElement(By.Id("wp-submit")).Click();

            var error = driver.FindElement(By.Id("login_error"));
            Assert.IsTrue(error.Displayed, "The error message for a user with an invalid user name was not displayed.");
        }
    }
}
