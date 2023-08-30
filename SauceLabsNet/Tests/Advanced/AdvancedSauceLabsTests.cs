namespace SauceLabsNet.Tests.Advanced;

[Category("DataDrivenParallelTests")]
[Parallelizable]
[TestFixture("chrome", "45", "Windows 7", "", "")]
[TestFixture("chrome", "50", "Windows 7", "", "")]
[TestFixture("MicrosoftEdge", "14.14393", "Windows 10", "", "")]
[TestFixture("chrome", "6.0", "Android", "Android Emulator", "portrait")]
[TestFixture("Safari", "11.2", "iOS", "iPhone X Simulator", "portrait")]
public class AdvancedSauceLabsTests : BaseTest
{
    public AdvancedSauceLabsTests(string browser,
                                  string version,
                                  string os,
                                  string deviceName,
                                  string deviceOrientation) :
    base(browser,
         version,
         os,
         deviceName,
         deviceOrientation)
    {
    }

    [Test]
    public void TestMethodInClass1()
    {
        Driver.Navigate().GoToUrl("https://www.google.com");
        Assert.Pass("passed the test");
    }
}
