using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyedenSeleniumAutomation.stepdefinitions
{
    internal class Hooks
    {
        public static IWebDriver driver;

        [SetUp]
        public static IWebDriver Setup()
        {
            // Assuming you have the necessary NuGet packages installed
            // Make sure to include the [SetUp] attribute from NUnit.Framework

            // Get browser and data from configuration
            var browser = SeleniumConfig.Browser;


            // Create an instance of ChromeOptions
            var options = new ChromeOptions();

            // Enable headless mode if needed
            // options.AddArgument("--headless");

            // Create an instance of ChromeDriver
            driver = browser.ToLower() switch
            {
                "chrome" => new ChromeDriver(options),
                // Add more cases for other browsers if needed
                _ => throw new NotSupportedException($"Browser '{browser}' is not supported."),
            };

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            return driver;
        }

        // Other methods and teardown logic go here
    }
}
