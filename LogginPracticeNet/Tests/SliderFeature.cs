using LogginPracticeNet.Pages;

namespace LogginPracticeNet.Tests;

[TestFixture]
[Category("SliderFeature"), Category("SampleApp2")]
public class SliderFeature : BaseTest
{
    [Test]
    [Description("Validate that slider changes images")]
    [Property("Author", "NikolayAdvolodkin")]
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
