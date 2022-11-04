using ConsoleAppDI.Models;
using Microsoft.Extensions.Logging;

namespace ConsoleAppDI
{
    public class Application
    {
        private readonly IHttpService _httpService;
        private readonly ILogger<Application> _logger;
        public Application(IHttpService httpService, ILogger<Application> logger)
        {
            _httpService = httpService;
            _logger = logger;
        }

        public async Task Start()
        {
            try
            {
                var response = await _httpService.Request<WeatherResponse>();
            }
            catch (Exception ex)
            {
                _logger.LogError(1, ex, ex.Message);
            }

        }
    }
}