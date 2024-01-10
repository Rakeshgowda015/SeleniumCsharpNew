using Microsoft.Extensions.Configuration;
using System;
using System.IO;

public class SeleniumConfig
{
    private static IConfiguration Configuration { get; set; }

    static SeleniumConfig()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("C:\\Users\\RakeshHabbanakuppeCh\\Downloads\\SeleniumCsharp-master\\SeleniumCsharp-master\\MyedenSeleniumAutomation\\appsettings.json", optional: false, reloadOnChange: true);

        Configuration = builder.Build();
    }

    public static string Browser => Configuration["AppSettings:Browser"];
    public static string ENV => Configuration["AppSettings:ENV"];
}

