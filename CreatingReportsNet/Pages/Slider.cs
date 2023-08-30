using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace CreatingReportsNet.Pages;

public class Slider : BaseApplicationPage
{
    public Slider(IWebDriver driver) : base(driver)
    {
    }

    public string CurrentImage => MainSliderImage.GetAttribute("style");

    private IWebElement MainSliderImage => Driver.FindElement(By.Id("homeslider"));

    internal void ClickNextButton()
    {
        Driver.FindElement(By.ClassName("bx-next")).Click();
        Reporter.LogPassingTestStepToBugLogger("Click the next button in the slider.");
    }

    public void AssertThatImageChanged(string currentImage, string newImage)
    {
        Reporter.LogTestStepForBugLogger(Status.Info, "Validate that the images rotated in the slider.");
        Assert.AreNotEqual(currentImage, newImage,
            "The slider images did not change when pressing the next button.");
    }
}