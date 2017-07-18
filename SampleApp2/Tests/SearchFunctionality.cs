using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SampleApp2
{
    [TestClass]
    [TestCategory("SearchingFeature"), TestCategory("SampleApp2")]
    public class SearchFunctionality : BaseTest
    {
        [TestMethod]
        [Description("Checks to make sure that if we search for browser, that browser comes back.")]
        [TestProperty("Author","NikolayAdvolodkin")]
        public void TCID1()
        {
            string stringToSearch = "blouse";

            HomePage homePage = new HomePage(Driver);
            homePage.GoTo();
            SearchPage searchPage = homePage.Search(stringToSearch);
            Assert.IsTrue(searchPage.Contains(Item.Blouse),
                $"When searching for the string=>{stringToSearch}, " +
                $"we did not find it in the search results.");
        }
    }
}
