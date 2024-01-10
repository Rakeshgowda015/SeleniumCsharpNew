using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyedenSeleniumAutomation.Utilities;
using OpenQA.Selenium.Interactions;

namespace MyedenSeleniumAutomation.utilities
{
    internal class BasePage
    {
        private IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected void GoTourl(string url)
        {
            driver.Url = url;
        }

        protected string GetWindowTitle()
        {
            try
            {
                return driver.Title;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public void Sleep(int timeOutInSeconds)
        {
            System.Threading.Thread.Sleep(timeOutInSeconds * 1000);
        }

        protected void PageLoadTime(int loadTimeInSec)
        {
            try
            {
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(loadTimeInSec);
            }
            catch (TimeoutException)
            {
                // Handle the timeout exception as needed
            }
        }

        public void Refresh()
        {
            driver.Navigate().Refresh();
        }

        protected bool IsElementPresent(string locator)
        {
            By by = ObjectLocators.GetBySelector(locator);
            return IsElementPresent(by);
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                IWebElement element = driver.FindElement(by);
                return element != null;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void ScrollIntoView(string locator)
        {
            By by = ObjectLocators.GetBySelector(locator);
            IWebElement element = driver.FindElement(by);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(false);", element);
        }

        public void ScrollIntoViewUsingWebElement(IWebElement locator)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", locator);
        }

        public void ScrollBy(int pixels)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string script = string.Format("window.scrollBy(0, {0});", pixels);
            js.ExecuteScript(script);
        }

        public bool ClickOnElement(string locator)
        {
            try
            {
                By by = ObjectLocators.GetBySelector(locator);
                IWebElement element = driver.FindElement(by);
                element.Click();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ValidateNewTabTitle(string expectedTitle)
        {
            string currentWindowHandle = driver.CurrentWindowHandle;
            foreach (string windowHandle in driver.WindowHandles)
            {
                if (!windowHandle.Equals(currentWindowHandle))
                {
                    driver.SwitchTo().Window(windowHandle);
                    string actualTitle = driver.Title;
                    if (actualTitle.Contains(expectedTitle))
                    {
                        return true;
                    }
                    driver.Close();
                    driver.SwitchTo().Window(currentWindowHandle);
                    break;
                }
            }
            return false;
        }

        public bool ForceClickOnElement(string locator)
        {
            try
            {
                By by = ObjectLocators.GetBySelector(locator);
                IWebElement element = driver.FindElement(by);

                Actions actions = new Actions(driver);
                actions.MoveToElement(element).Click().Perform();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected bool IsElementClickable(string locator)
        {
            By by = ObjectLocators.GetBySelector(locator);
            return IsElementClickable(by);
        }

        private bool IsElementClickable(By by)
        {
            try
            {
                IWebElement element = driver.FindElement(by);
                return (element != null && element.Enabled);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TypeTextInField(string locator, string text)
        {
            try
            {
                By by = ObjectLocators.GetBySelector(locator);
                IWebElement element = driver.FindElement(by);
                element.Clear();
                element.SendKeys(text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool HoverOverElement(string locator)
        {
            try
            {
                By by = ObjectLocators.GetBySelector(locator);
                IWebElement element = driver.FindElement(by);

                Actions actions = new Actions(driver);
                actions.MoveToElement(element).Build().Perform();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ClickElementWithJavaScript(string locator)
        {
            try
            {
                By by = ObjectLocators.GetBySelector(locator);
                IWebElement element = driver.FindElement(by);

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].click();", element);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
