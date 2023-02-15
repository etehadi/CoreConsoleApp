using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Services
{
    public class SampleService : ISampleService
    {
        private readonly ILogger<SampleService> _log;
        private readonly SampleServiceConfig _config;

        public SampleService(ILogger<SampleService> log, IOptions<SampleServiceConfig> config)
        {
            _log = log;
            _config = config.Value;
        }

        public async Task<int> Run(int input)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < _config.RunCount; i++)
                    _log.LogInformation("Number is {@Number}", i);
            });

            return input;
        }
    }
}
