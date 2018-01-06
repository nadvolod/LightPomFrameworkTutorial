using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;

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

            var options = new ChromeOptions();
            options.BinaryLocation = GetSeleniumBinaryLocation();
            //---- >>>> Don't do this - Setting the browser name is redundant
            //options.AddAdditionalCapability(CapabilityType.BrowserName, "chrome", true);
            //options.AddAdditionalCapability(CapabilityType.Version, "48.0", true);
            options.AddAdditionalCapability(CapabilityType.Platform, "Windows 10", true);

            //3. IMPORTANT - Notice the options.ToCapabilities() call!!
            return new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), 
                caps);
        }

        public IWebDriver CreateSauceDriver()
        {

            var capabilities = new DesiredCapabilities();
            //---- >>>> Don't do this - Setting the browser name is redundant
            capabilities.SetCapability(CapabilityType.BrowserName, "chrome");
            capabilities.SetCapability(CapabilityType.Version, "latest");
            capabilities.SetCapability(CapabilityType.Platform, "Windows 10");
            capabilities.SetCapability("username", 
                Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User));
            capabilities.SetCapability("accessKey", Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY",
                EnvironmentVariableTarget.User));
            return new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"),
                capabilities, TimeSpan.FromSeconds(600));
        }

        private string GetSeleniumBinaryLocation()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return Path.GetFullPath(Path.Combine(outPutDirectory ?? throw new InvalidOperationException(), @"..\..\..\AutomationResources\bin\Debug"));
        }
    }
}
