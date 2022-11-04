namespace ConsoleAppDI
{
    public class Application
    {
        private readonly IHttpService _httpService;
        public Application(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task Start()
        {
            var response = await _httpService.Request();
            Console.WriteLine("***************************");
            Console.WriteLine(response);
            Console.WriteLine("***************************");
        }
    }
}