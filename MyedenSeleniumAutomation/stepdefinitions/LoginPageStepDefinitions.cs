using DocumentFormat.OpenXml.Bibliography;
using MyedenSeleniumAutomation.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MyedenSeleniumAutomation.stepdefinitions
{
    [Binding]
    internal class LoginPageStepDefinitions
    {
        IWebDriver driver = Hooks.Setup();
        [Given("the user is on the login page")]
        public void GivenTheUserIsOnTheLoginPage()
        {
            LoginPage loginpage = new LoginPage(driver);
            loginpage.loginToPatientMyeden();
        }

        [When("the user enters valid credentials")]
        public void WhenTheUserEntersValidCredentials()
        {
            // Implement login logic
        }

        [Then("the user should be logged in")]
        public void ThenTheUserShouldBeLoggedIn()
        {
            // Implement verification logic
        }

    }
}
