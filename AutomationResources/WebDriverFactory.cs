using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Remote;

namespace AutomationResources
{
    public class WebDriverFactory
    {
        public IWebDriver Create(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return GetChromeDriver();
                default:
                    throw new ArgumentOutOfRangeException("No such browser exists");
            }
        }
        private IWebDriver GetChromeDriver()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var resourcesDirectory = Path.GetFullPath(Path.Combine(outPutDirectory, @"..\..\..\AutomationResources\bin\Debug"));
            return new ChromeDriver(resourcesDirectory);
        }

        public IWebDriver CreateRemoteDriver()
        {
            var caps = DesiredCapabilities.Chrome();
            caps.SetCapability(CapabilityType.Platform, "Windows 10");

            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var resourcesDirectory = Path.GetFullPath(Path.Combine(outPutDirectory, @"..\..\..\AutomationResources\bin\Debug"));
            ChromeOptions options = new ChromeOptions();
            options.BinaryLocation = resourcesDirectory;
            //---- >>>> Don't do this - Setting the browser name is redundant
            //options.AddAdditionalCapability(CapabilityType.BrowserName, "chrome", true);
            //options.AddAdditionalCapability(CapabilityType.Version, "48.0", true);
            options.AddAdditionalCapability(CapabilityType.Platform, "Windows 10", true);

            //3. IMPORTANT - Notice the options.ToCapabilities() call!!
            return new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), 
                caps);
        }
    }
}
