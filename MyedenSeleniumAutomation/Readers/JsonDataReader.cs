using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

internal static class JsonDataReader
{

          private static IConfiguration Configuration { get; set; }

    static string jsonFilePath = $"C:\\Users\\RakeshHabbanakuppeCh\\Downloads\\SeleniumCsharp-master\\SeleniumCsharp-master\\MyedenSeleniumAutomation\\JsonData\\{SeleniumConfig.ENV}Data.json";



    static JsonDataReader()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(jsonFilePath, optional: false, reloadOnChange: true);

        Configuration = builder.Build();
    }

    public static string Emailid => Configuration["MyedenPatient:Emailid"];
    public static string Password => Configuration["MyedenPatient:Password"];
    public static string BaseUrl => Configuration["MyedenPatient:BaseUrl"];
}

