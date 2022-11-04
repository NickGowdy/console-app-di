using ConsoleAppDI.Config;
using ConsoleAppDI.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleAppDI
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var app = host.Services.GetRequiredService<Application>();
            await app.Start();
        }

        static IHostBuilder CreateHostBuilder(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
           .ConfigureAppConfiguration((hostingContext, cfg) =>
           {
               var env = hostingContext.HostingEnvironment;

           }).ConfigureServices(
                    (_, services) => services
                        .AddSingleton<Application, Application>()
                        .AddSingleton<IHttpService, HttpService>());


            return host;
        }
    }
}

