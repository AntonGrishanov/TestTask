using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace TestTask.Configuration
{
    public static class TestConfiguration
    {
        private static readonly IConfigurationRoot config;

        static TestConfiguration()
        {
            config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public static string BaseUrl => config["BaseUrl"];
        public static string Username => config["Username"];
        public static string Password => config["Password"];
        public static string Browser => config["Browser"];
    }
}
