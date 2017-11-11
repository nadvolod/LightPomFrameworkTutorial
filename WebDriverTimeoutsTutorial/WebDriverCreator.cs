using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using AutomationResources;

namespace WebdriverTimeoutsTutorial
{
    public static class WebDriverCreator
    {
        public static IWebDriver BasicInitialize()
        {
            return new WebDriverFactory().Create(BrowserType.Chrome);
        }

        public static IWebDriver RemoteInitialize()
        {
            var capability = new DesiredCapabilities();
            capability.SetCapability("browserstack.user", Environment.GetEnvironmentVariable("BROWSERSTACK_USER", EnvironmentVariableTarget.User));
            capability.SetCapability("browserstack.key", Environment.GetEnvironmentVariable("BROWSERSTACK_KEY", EnvironmentVariableTarget.User));


            capability.SetCapability("browser", "Chrome");
            capability.SetCapability("browser_version", "30.0");
            capability.SetCapability("os", "Windows");
            capability.SetCapability("os_version", "7");
            capability.SetCapability("resolution", "1024x768");

            //capability.SetCapability("browser", "IE");
            //capability.SetCapability("browser_version", "8.0");
            //capability.SetCapability("os", "Windows");
            //capability.SetCapability("os_version", "7");
            //capability.SetCapability("resolution", "1024x768");
            capability.SetCapability("browserstack.debug", "true");

            var driver =  new RemoteWebDriver(new Uri("http://hub.browserstack.com/wd/hub/"), capability);
            return driver;
        }
    }
}