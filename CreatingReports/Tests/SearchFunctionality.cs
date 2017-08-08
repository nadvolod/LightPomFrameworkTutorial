using CreatingReports.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CreatingReports.Tests
{
    [TestClass]
    [TestCategory("SearchingFeature")]
    [TestCategory("SampleApp2")]
    [TestCategory("Logging")]
    public class SearchFunctionality : BaseTest
    {
        [TestMethod]
        [Description("Checks to make sure that if we search for browser, that browser comes back.")]
        [TestProperty("Author", "NikolayAdvolodkin")]
        public void TCID1()
        {
            var stringToSearch = "blouse";

            var homePage = new HomePage(Driver);
            homePage.GoTo();
            var searchPage = homePage.Search(stringToSearch);
            Assert.IsFalse(searchPage.Contains(Item.Blouse),
                $"When searching for the string=>{stringToSearch}, " +
                $"we did not find it in the search results.");
        }
    }
}