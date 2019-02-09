using ServiceStack;

namespace main.HelloThere
{
    public class HelloThereService : Service
    {
        private readonly IHelloThereConfig _config;

        public HelloThereService(IHelloThereConfig config)
        {
            _config = config;
        }

        public HelloThereResponse Any(HelloThereRequest request)
        {
            return new HelloThereResponse
            {
                Message = $"Hello there {request.Who}",
                SomethingConfig = _config.Something
            };
        }
    }
}