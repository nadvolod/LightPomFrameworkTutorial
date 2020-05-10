using System;
using AutomationResources;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace ElementInteractions
{

    [TestFixture]
    public class UnitTest1
    {
        private IWebDriver _driver;
        private Actions _actions;
        private WebDriverWait _wait;


        [Test]
        public void DragDropExample1()
        {
            _driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));
            IWebElement sourceElement = _driver.FindElement(By.Id("draggable"));
            IWebElement targetElement = _driver.FindElement(By.Id("droppable"));
            _actions.DragAndDrop(sourceElement, targetElement).Perform();

            Assert.AreEqual("Dropped!", targetElement.Text);

            //var item1 = driver.FindElement(By.Id("1"));
            //var dropLocation = driver.FindElement(By.ClassName("done"));
            //actions.DragAndDrop(item1, dropLocation).Perform();
            ////actions.ClickAndHold(item1).MoveToElement(dropLocation).Release().Perform(); 

            //driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
            //var draggable = driver.FindElement(By.Id("draggable"));
            //var drop = driver.FindElement(By.Id("droppable"));
            ////actions.DragAndDrop(draggable, drop).Perform();
            //actions.ClickAndHold(draggable).MoveToElement(drop).Release().Perform();

            //driver.Navigate().GoToUrl("http://demo.guru99.com/test/drag_drop.html");
            //draggable = driver.FindElement(By.XPath("//*[@id='credit2']/a"));
            //drop = driver.FindElement(By.XPath("//*[@id='bank']/li"));
            ////actions.DragAndDrop(draggable, drop).Perform();
            //actions.ClickAndHold(draggable).MoveToElement(drop).Release().Perform();

           
        }

        [Test]
        public void DragDropExample2()
        {

            _driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));

            IWebElement sourceElement = _driver.FindElement(By.Id("draggable"));
            IWebElement targetElement = _driver.FindElement(By.Id("droppable"));
            var drag = _actions
                .ClickAndHold(sourceElement)
                .MoveToElement(targetElement)
                .Release(targetElement)
                .Build();

            drag.Perform();

            Assert.AreEqual("Dropped!", targetElement.Text);

        }

        [Test]
        public void jQueryDragDropQuiz()
        {
            _driver.Navigate().GoToUrl("http://www.pureexample.com/jquery-ui/basic-droppable.html");
            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("//*[@id='ExampleFrame-94']")));

            //var sourceLocator = _driver.FindElement(By.ClassName("//*[@class='square ui-draggable']"));
            var sourceLocator = _driver.FindElement(By.XPath("//*[@class='square ui-draggable']"));
            var destinationLocator = _driver.FindElement(By.XPath("//*[@class='squaredotted ui-droppable']"));
            _actions.DragAndDrop(sourceLocator, destinationLocator).Build().Perform();

            var droppedText = _driver.FindElement(By.XPath("//*[@id='info']")).Text;

            Assert.AreEqual("dropped!", droppedText);

        }

        [SetUp]
        public void Setup()
        {
            _driver = new WebDriverFactory().Create(BrowserType.Chrome);
            _actions = new Actions(_driver);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
