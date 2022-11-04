namespace ConsoleAppDI.Service
{
    public class HttpService : IHttpService
    {
        public async Task<string> Request()
        {
            var httpClient = new HttpClient();

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("https://weatherapi-com.p.rapidapi.com/current.json?q=SW1 Canada postal code"),
                Headers =
            {
                { "X-RapidAPI-Key", "190a862809mshce3258080336a88p1aef72jsn272e41f1cfff" },
                { "X-RapidAPI-Host", "weatherapi-com.p.rapidapi.com" }
            }
            };

            using var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return body;
        }
    }
}