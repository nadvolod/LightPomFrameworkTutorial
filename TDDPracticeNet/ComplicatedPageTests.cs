using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TDDPractice;

[TestFixture]
[Category("TDDPractice")]
public class ComplicatedPageTests
{
    private IWebDriver driver;

    public void TestMethod1()
    {
        var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var driver = new ChromeDriver(path);

        var complicatedPage = new ComplicatedPage(driver);
        complicatedPage.Open();
        var amazonSearchPage = complicatedPage.SearchUsingAmazon("automation testing");
        Assert.AreEqual("automation testing", amazonSearchPage.ActualSearchResults);
    }

    [Test]
    public void TestMethodNew()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        driver = new ChromeDriver();
        var complicatedPage = new ComplicatedPage(driver);
        complicatedPage.Open();
        complicatedPage.SearchArticles("automation testing");
        Assert.IsTrue(complicatedPage.AreResultsReturned());
    }

}
