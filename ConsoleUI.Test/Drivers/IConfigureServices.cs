using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Test.Drivers
{
    public interface IConfigureServices
    {
        public void ConfigureServices(HostBuilderContext hostBuilderContext, IServiceCollection services);
    }
}
