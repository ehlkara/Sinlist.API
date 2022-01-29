using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;

namespace Sinlist.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = GetConfiguration(args);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
              .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static IConfiguration GetConfiguration(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                .AddJsonFile("serilog.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"serilog.{environment}.json", optional: true, reloadOnChange: true);

            configurationBuilder.AddCommandLine(args);
            configurationBuilder.AddEnvironmentVariables();

            return configurationBuilder.Build();
        }
    }
}
