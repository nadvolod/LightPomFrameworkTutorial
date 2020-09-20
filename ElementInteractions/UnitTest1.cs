using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace ElementInteractions
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebElement draggable;
            IWebElement drop;
            new DriverManager().SetUpDriver(new ChromeConfig());
            var driver = new ChromeDriver();
            var actions = new Actions(driver);

            //driver.Navigate().GoToUrl("http://localhost:3000/");

            //var item1 = driver.FindElement(By.Id("1"));
            //var dropLocation = driver.FindElement(By.ClassName("done"));
            //actions.DragAndDrop(item1, dropLocation).Perform();
            ////actions.ClickAndHold(item1).MoveToElement(dropLocation).Release().Perform(); 

            //driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
            //var draggable = driver.FindElement(By.Id("draggable"));
            //var drop = driver.FindElement(By.Id("droppable"));
            ////actions.DragAndDrop(draggable, drop).Perform();
            //actions.ClickAndHold(draggable).MoveToElement(drop).Release().Perform();

            driver.Navigate().GoToUrl("http://demo.guru99.com/test/drag_drop.html");
            draggable = driver.FindElement(By.XPath("//*[@id='credit2']/a"));
            drop = driver.FindElement(By.XPath("//*[@id='bank']/li"));
            //actions.DragAndDrop(draggable, drop).Perform();
            actions.ClickAndHold(draggable).MoveToElement(drop).Release().Perform(); 

            driver.Quit();
        }
    }
}
