using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace AutomationResources
{
    public class WebDriverFactory
    {
        public IWebDriver Create(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    return new ChromeDriver();
                default:
                    throw new ArgumentOutOfRangeException("No such browser exists");
            }
        }
        public IWebDriver CreateChromeDriver()
        {
            var directoryWithChromeDriver = GetChromeBinaryLocationInAutomationResources();
            return new ChromeDriver(directoryWithChromeDriver);
        }
        private IWebDriver GetChromeDriver()
        {
            var outPutDirectory = GetAssemblysOutputDirectory();
            var directoryWithChromeDriver = CreateFilePathForNetCoreApps(outPutDirectory);
            if (string.IsNullOrEmpty(directoryWithChromeDriver))
            {
                directoryWithChromeDriver = CreateFilePathForNetFrameworkApps(outPutDirectory);
            }
            return new ChromeDriver(directoryWithChromeDriver);
        }

        private static string CreateFilePathForNetFrameworkApps(string outPutDirectory)
        {
            //If the outputDirectory is null, a new exception will be thrown
            //Otherwise, we will concatenate the path and create the correct one
            return Path.GetFullPath(Path.Combine(
                                outPutDirectory ?? throw new InvalidOperationException(),
                                @"..\..\..\AutomationResources\bin\Debug"));
        }

        private static string CreateFilePathForNetCoreApps(string outPutDirectory)
        {
            var resourcesDirectory = "";
            if (outPutDirectory != null && outPutDirectory.Contains("netcoreapp"))
                resourcesDirectory = Path.GetFullPath(Path.Combine(outPutDirectory, @"..\..\..\..\AutomationResources\bin\Debug"));
            return resourcesDirectory;
        }

        private static string GetAssemblysOutputDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public IWebDriver CreateSauceDriver(string browser, string version, string os, string deviceName, string deviceOrientation)
        {
            var capabilities =  new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, browser);
            capabilities.SetCapability(CapabilityType.Version, version);
            capabilities.SetCapability(CapabilityType.Platform, os);
            capabilities.SetCapability("deviceName", deviceName);
            capabilities.SetCapability("deviceOrientation", deviceOrientation);
            capabilities.SetCapability("username", 
                Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User));
            capabilities.SetCapability("accessKey", 
                Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User));
            return new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"),
                capabilities, TimeSpan.FromSeconds(600));
        }

        public IWebDriver CreateSauceDriver(SauceConfiguration sauceConfig)
        {
            var driver = CreateSauceDriver(sauceConfig.Browser, sauceConfig.Version, sauceConfig.OS,
                sauceConfig.DeviceName, sauceConfig.DeviceOrientation);
            ((IJavaScriptExecutor)driver).ExecuteScript($"sauce:job-name={sauceConfig.TestCaseName}");
            return driver;
        }

        public IWebDriver CreateRemoteDriver()
        {
            var caps = new DesiredCapabilities();
            caps.SetCapability(CapabilityType.Platform, "Windows 10");

            var options = new ChromeOptions();
            options.BinaryLocation = GetChromeBinaryLocationInAutomationResources();
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
            //DesiredCapabilities caps = new DesiredCapabilities();
            //caps.SetCapability("browserName", "Chrome");
            //caps.SetCapability("platform", "Windows 8.1");
            //caps.SetCapability("version", "62.0");
            //caps.SetCapability("screenResolution", "1024x768");

            var capabilities =  new DesiredCapabilities();
            //capabilities.SetCapability(CapabilityType.BrowserName, "chrome");
            capabilities.SetCapability(CapabilityType.Version, "48.0");
            capabilities.SetCapability(CapabilityType.Platform, "Linux");
            capabilities.SetCapability("username", 
                Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User));
            capabilities.SetCapability("accessKey", 
                Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User));
            return new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"),
                capabilities, TimeSpan.FromSeconds(600));
        }

        private string GetChromeBinaryLocationInAutomationResources()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return Path.GetFullPath(Path.Combine(outPutDirectory, @"..\..\..\AutomationResources\bin\Debug"));
        }
    }
}
