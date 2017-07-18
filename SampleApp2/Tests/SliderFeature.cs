using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SampleApp2
{
    [TestClass]
    [TestCategory("SliderFeature"), TestCategory("SampleApp2")]
    public class SliderFeature : BaseTest
    {
        [TestMethod]
        [Description("Validate that slider changes images")]
        [TestProperty("Author","NikolayAdvolodkin")]
        public void TCID3()
        {
            HomePage homePage = new HomePage(Driver);
            homePage.GoTo();
            var currentImage = homePage.Slider.CurrentImage;
            homePage.Slider.ClickNextButton();
            var newImage = homePage.Slider.CurrentImage;
            Assert.AreNotEqual(currentImage, newImage, 
                "The slider images did not change when pressing the next button.");
        }
    }
}
