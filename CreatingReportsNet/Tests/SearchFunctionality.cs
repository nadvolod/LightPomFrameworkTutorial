using CreatingReportsNet.Pages;

namespace CreatingReportsNet.Tests;

[TestFixture]
[Category("SearchingFeature")]
[Category("SampleApp2")]
[Category("Logging")]
public class SearchFunctionality : BaseTest
{
    [Test]
    [Description("Checks to make sure that if we search for browser, that browser comes back.")]
    [Property("Author", "NikolayAdvolodkin")]
    public void TCID1()
    {
        var stringToSearch = "blouse";

        var homePage = new HomePage(Driver);
        homePage.GoTo();
        var searchPage = homePage.Search(stringToSearch);
        Assert.IsTrue(searchPage.Contains(Item.Blouse),
            $"When searching for the string=>{stringToSearch}, " +
            $"we did not find it in the search results.");
    }
}