using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace QtpTests
{
    [TestClass]
    public class ValidUserCanSuccessfullyLogin
    {
        [TestMethod]
        public void RunTest()
        {
            //here we create a new instance of the Firefox driver
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.qtptutorial.net/wp-login.php");

            //find the field for ther user name
            var user = driver.FindElement(By.Id("user_login"));
            user.SendKeys("seleniumTestUser");

            //find the field for the password
            var pass = driver.FindElement(By.Id("user_pass"));
            pass.SendKeys("Test12345!!$");

            driver.FindElement(By.Id("wp-submit")).Click();

            var loggedInHeader = driver.FindElement(By.XPath("//h1[text()='My Membership']"));
            Assert.IsTrue(loggedInHeader.Displayed, "The user was not able to successfully login.");
        }
    }
}
