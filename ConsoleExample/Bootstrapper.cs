using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConsoleExample
{
    internal class Bootstrapper
    {
        public Bootstrapper()
        {
        }

        internal Task Run(string[] args)
        {
            var host = new HostBuilder();

            host.ConfigureHostConfiguration((config) => ConfigHost(config));
            host.ConfigureAppConfiguration((hostContext, config) => ConfigureApp(hostContext, config, args));
            host.ConfigureServices((hostContext, services) => ConfigServices(hostContext, services));
            host.ConfigureLogging((hostContext, logging) => ConfigLogging(hostContext,logging));

            return host.RunConsoleAsync();
        }

        private void ConfigLogging(HostBuilderContext hostContext, ILoggingBuilder loggingBuilder)
        {
        }

        private void ConfigureApp(HostBuilderContext hostContext, IConfigurationBuilder config, string[] args)
        {
            config.SetBasePath(Environment.CurrentDirectory);
            config.AddJsonFile("appSettings.json");
            config.AddCommandLine(args);
            
        }

        private void ConfigServices(HostBuilderContext hostContext, IServiceCollection services)
        {
            services.AddTransient<ISampleService, SampleService>();
            services.AddScoped<IHostedService, ConsoleExampleHostedService>(); ;
        }

        private void ConfigHost(IConfigurationBuilder config)
        {
        }
    }
}