using System.Net.Http.Json;
using System.Text.Json;
using ConsoleAppDI.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ConsoleAppDI.Service
{
    public class HttpService : IHttpService
    {
        private readonly IConfiguration Configuration;

        public HttpService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<T?> Request<T>() where T : class
        {
            try
            {
                using HttpClient client = new()
                {
                    BaseAddress = new Uri(uriString: Configuration["WeatherApiConfig:Url"]),
                    DefaultRequestHeaders =
                {
                    { "X-RapidAPI-Key", Configuration["WeatherApiConfig:Key"] },
                    { "X-RapidAPI-Host", Configuration["WeatherApiConfig:Url"] }
                }
                };
                return await client.GetFromJsonAsync<T>("current.json?q=SW1 Canada postal code");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}