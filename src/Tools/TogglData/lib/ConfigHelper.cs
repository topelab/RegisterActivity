using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.EntityFrameworkCore
{
    public static class ConfigHelper
    {
        private static string _settingsFile = "appsettings.json";
        private static string _additionalSettingsFile;
        private static IConfiguration _config;
        public static IConfiguration Config
        {
            get
            {
                if (_config == null)
                {
                    var builder = new ConfigurationBuilder()
                        .AddJsonFile(_settingsFile, true, true)
                        .AddEnvironmentVariables();

                    if (!string.IsNullOrWhiteSpace(_additionalSettingsFile))
                    {
                        builder = builder.AddJsonFile(_additionalSettingsFile, true, true);
                    }

                    _config = builder.Build();
                }
                return _config;
            }
        }

        public static void SetAdditionalSettingsFile(string settingsFile)
        {
            _additionalSettingsFile = settingsFile;
        }

        public static string GetConnectionString(string name = null)
        {
            name = name ?? "localserver";
            return Config[$"ConnectionStrings:{name}"];
        }

    }
}
