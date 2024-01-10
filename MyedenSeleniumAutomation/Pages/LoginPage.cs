using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Wordprocessing;
using MyedenSeleniumAutomation.Readers;
using MyedenSeleniumAutomation.utilities;
using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyedenSeleniumAutomation.Pages
{
    internal class LoginPage :BasePage
    {
        private IWebDriver driver;
      String  emailid= JsonDataReader.Emailid;
      String  password=   JsonDataReader.Password;
      String   baseurl=   JsonDataReader.BaseUrl;


        public LoginPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
        private String expectedTitle = ExcelReader.gettitle("Loginpage");
        private String logo = ExcelReader.getxpath("LoginPageLogo");
        private String welcomeText= ExcelReader.getxpath("WelcomeText");
        private String loginEmailTextField = ExcelReader.getxpath("LoginEmailTextField");
        private String loginPasswordTextField = ExcelReader.getxpath("LoginPasswordTextField");
        private String loginButton = ExcelReader.getxpath("LoginButton");

        public void loginToPatientMyeden() {
            Boolean Status = false;
            try
            {
               

                GoTourl(baseurl);
                Sleep(8);
                string pageTitle = driver.Title;
                Assert.That(pageTitle, Is.EqualTo(expectedTitle));
                IsElementPresent(logo);
                IsElementPresent(welcomeText);
                TypeTextInField(loginEmailTextField, emailid);
                Sleep(3);
                TypeTextInField(loginPasswordTextField, password);
                Sleep(1);
                ClickOnElement(loginButton);


            }
            catch (Exception ex)
            {
                // Handle the exception or log it as needed
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Optionally, rethrow the exception if you want it to propagate further
                // throw;
            }
        }

    }
}
