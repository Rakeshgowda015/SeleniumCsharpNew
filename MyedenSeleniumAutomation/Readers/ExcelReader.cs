using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace MyedenSeleniumAutomation.Readers
{
    internal static class ExcelReader
    {
        public static Dictionary<string, string> ReadXPaths(string filePath, string sheetName)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Set the license context
            var xpaths = new Dictionary<string, string>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[sheetName];
                var rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++) // Assuming the data starts from the second row
                {
                    var elementName = worksheet.Cells[row, 1].Text;
                    var xpath = worksheet.Cells[row, 2].Text;

                    xpaths[elementName] = xpath;
                }
            }

            return xpaths;
        }
        public static string getxpath(string value)
        {
            // Read XPaths from Excel
            var xpaths = ReadXPaths("C:\\Users\\RakeshHabbanakuppeCh\\Downloads\\SeleniumCsharp-master\\SeleniumCsharp-master\\MyedenSeleniumAutomation\\xpath.xlsx", "Sheet1");
            string loginButtonXPath = xpaths[value];
            return loginButtonXPath;
        }
        public static string gettitle(string value)
        {
            // Read XPaths from Excel
            var xpaths = ReadXPaths("C:\\Users\\RakeshHabbanakuppeCh\\Downloads\\SeleniumCsharp-master\\SeleniumCsharp-master\\MyedenSeleniumAutomation\\xpath.xlsx", "Sheet2");
            string loginButtonXPath = xpaths[value];
            Console.WriteLine(loginButtonXPath);
            return loginButtonXPath;
        }




    }
}
