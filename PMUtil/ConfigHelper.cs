using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;

namespace PMUtil
{
    public  class ConfigHelper
    {
        public static IConfiguration Configuration { get; set; }
        static ConfigHelper()
        {
            Configuration = new ConfigurationBuilder()
            .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
            .Build();
        }
    }
}
