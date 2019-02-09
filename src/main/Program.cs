using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace main
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                            .UseKestrel()
                            .UseContentRoot(Directory.GetCurrentDirectory())
                            .UseStartup<Startup>()
                            .UseUrls(AlalaDefines.Url)
                            .Build();
            
            host.Run();
        }
    }
}