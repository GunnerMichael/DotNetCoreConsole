using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleExample
{
    public class ConsoleExampleHostedService : IHostedService
    {
        private ISampleService _sample;
        private IConfiguration _config;

        public ConsoleExampleHostedService(ISampleService sample,
            IConfiguration configuration)   
        {
            _sample = sample;
            _config = configuration;
            
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"State: {_config["state"]}");

            if (_sample != null)
            {
                return _sample.DoWorkAsync();
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
