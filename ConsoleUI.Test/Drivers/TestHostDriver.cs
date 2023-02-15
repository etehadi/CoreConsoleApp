using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Test.Drivers
{
    /// <summary>
    /// Use this class to resolve objects in DI container
    /// </summary>
    public class TestHostDriver : IConfigureServices, IDisposable
    {
        private IHost _host;
        private readonly SampleIntegrationMockServiceDriver _sampleIntegrationMockServiceDriver;


        public TestHostDriver(SampleIntegrationMockServiceDriver sampleIntegrationMockServiceDriver)
        {
            _sampleIntegrationMockServiceDriver = sampleIntegrationMockServiceDriver;
        }


        public void BuildHost() =>
           _host = ConsoleUI.Program.CreateHostBuilder(Array.Empty<string>())
               .ConfigureServices((hostBuilderContext, services) =>
               {
                   _sampleIntegrationMockServiceDriver.ConfigureServices(hostBuilderContext, services);
                   this.ConfigureServices(hostBuilderContext, services);
               })
               .Build();




        public void ConfigureServices(HostBuilderContext hostBuilderContext, IServiceCollection services)
        {
            // TODO -> Define your own instances to DI
            // services.AddSingleton<IServiceXXX, ServiceXXX>();
        }

        public void Dispose() => _host?.Dispose();

        public T GetRequiredService<T>() where T : notnull 
            => _host.Services.GetRequiredService<T>();

        public T GetOptions<T>() where T : class
            => GetRequiredService<IOptions<T>>().Value;
    }
}
