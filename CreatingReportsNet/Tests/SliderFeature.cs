using CreatingReportsNet.Pages;

namespace CreatingReportsNet.Tests;

[TestFixture]
[Category("SliderFeature")]
[Category("SampleApp2")]
public class SliderFeature : BaseTest
{
    [Test]
    [Description("Validate that slider changes images")]
    [Property("Author", "NikolayAdvolodkin")]
    public void TCID3()
    {
        var homePage = new HomePage(Driver);
        homePage.GoTo();
        var currentImage = homePage.Slider.CurrentImage;
        homePage.Slider.ClickNextButton();
        var newImage = homePage.Slider.CurrentImage;
        homePage.Slider.AssertThatImageChanged(currentImage, newImage);

    }
}