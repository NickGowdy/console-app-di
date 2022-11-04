using ConsoleAppDI.Service;
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
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(
                    (_, services) => services
                        .AddSingleton<Application, Application>()
                        .AddSingleton<IHttpService, HttpService>());
        }
    }
}

