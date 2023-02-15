using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Test.Drivers
{
    public class SampleIntegrationMockServiceDriver : IConfigureServices
    {
        public void ConfigureServices(HostBuilderContext hostBuilderContext, IServiceCollection services)
        {
            // TODO -> Define your own instances to DI
            // services.AddSingleton<IServiceXXX, ServiceXXX>();
        }
    }
}
