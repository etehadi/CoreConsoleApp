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
    internal static class Program
    {
        static void Main(string[] args)
        {
            var configBuilder = new ConfigurationBuilder().BuildConfig();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configBuilder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            Log.Logger.Information("Application Starging");


            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {                    
                    services.AddTransient<ISampleService, SampleService>();
                    services.ConfigureByName<SampleServiceConfig>(context.Configuration);
                })
                .UseSerilog()
                .Build();


           ActivatorUtilities.CreateInstance<SampleCommand>(host.Services).ParseCommand(args).Wait();
        }



        static IConfigurationBuilder BuildConfig(this IConfigurationBuilder builder)
        {
            return builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
        }
    }
}