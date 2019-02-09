using Funq;
using main.HelloThere;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ServiceStack;

namespace main
{
    public static class ContainerSetup
    {
        public static void RegisterStuff(Container container, IConfigurationRoot configuration, ILoggerFactory loggerFactory)
        {
            // servicestack register all Service implementations
            // automagically

            container.AddSingleton<AlalaConfig>(new AlalaConfig(configuration));
            container.AddSingleton<IHelloThereConfig>(c => c.Resolve<AlalaConfig>());
        }
    }
}