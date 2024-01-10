using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyedenSeleniumAutomation.Utilities
{
    internal class ObjectLocators
    {
        public static By GetBySelector(string propKey)
        {
            // Get the value from selenium.properties and split the type and value
            string[] split = propKey.Split(';');

            // Check if there are at least two elements in the split array
            if (split.Length != 2)
            {
                throw new ArgumentException("Invalid element locator parameter - " + propKey);
            }

            string type = split[0].ToLower(); // Convert type to lowercase for case-insensitive comparison
            string value = split[1].Trim(); // Trim any leading/trailing spaces from the value

            // Generate the By selector based on the type
            switch (type)
            {
                case "id":
                    return By.Id(value);
                case "css":
                    return By.CssSelector(value);
                case "tagname":
                    return By.TagName(value);
                case "classname":
                case "class":
                    return By.ClassName(value);
                case "name":
                    return By.Name(value);
                case "xpath":
                    return By.XPath(value);
                case "link":
                    return By.LinkText(value);
                default:
                    throw new ArgumentException("Invalid element locator type - " + type);
            }
        }
    }
}
