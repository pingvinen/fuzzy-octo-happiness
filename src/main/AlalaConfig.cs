using main.HelloThere;
using Microsoft.Extensions.Configuration;
using RapidCore.Configuration;

namespace main
{
    public class AlalaConfig : ConfigBase, IHelloThereConfig
    {
        public AlalaConfig(IConfiguration configuration) : base(configuration)
        {
        }


        string IHelloThereConfig.Something => Get("HelloThereSomething", "CBB lyder kewl");
    }
}