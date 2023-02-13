using ConsoleUI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static OptionsBuilder<TOptions> ConfigureByName<TOptions>(this IServiceCollection services,IConfiguration configuration)
            where TOptions : class, ICustomConfig
        {
            return services.AddOptions<TOptions>().Bind<TOptions>((IConfiguration)configuration.GetSection(typeof(TOptions).Name));
        } 
    }
}
