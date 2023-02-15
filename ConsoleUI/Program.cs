using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Core;
using Serilog.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ConsoleUI.Services;
using ConsoleUI.Extensions;
using ConsoleUI.Commands;

namespace ConsoleUI
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            ConfigLog();
            Log.Logger.Information("Application Starging...");


            var host = CreateHostBuilder(args).Build();
            ActivatorUtilities.CreateInstance<SampleCommand>(host.Services)
                .ParseCommand(args).Wait();


            Log.Logger.Information("Application Ended.");
        }

        private static void ConfigLog()
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configBuilder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<ISampleService, SampleService>();
                    services.ConfigureByName<SampleServiceConfig>(context.Configuration);
                })
                .UseSerilog();

 
    }
}