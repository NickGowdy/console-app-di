using System.Net.Http.Json;
using System.Text.Json;

namespace ConsoleAppDI.Service
{
    public class HttpService : IHttpService
    {
        public async Task<T?> Request<T>() where T : class
        {
            try
            {
                using HttpClient client = new()
                {
                    BaseAddress = new Uri("https://weatherapi-com.p.rapidapi.com"),
                    DefaultRequestHeaders =
                {
                    { "X-RapidAPI-Key", "190a862809mshce3258080336a88p1aef72jsn272e41f1cfff" },
                    { "X-RapidAPI-Host", "weatherapi-com.p.rapidapi.com" }
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