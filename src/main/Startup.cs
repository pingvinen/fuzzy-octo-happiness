using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServiceStack;

namespace main
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; private set; }
        
        public Startup(IHostingEnvironment env)
        {
            var envName = env.EnvironmentName.ToLowerInvariant();
            
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{envName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
            
            Console.WriteLine($"appsettings for env: appsettings.{envName}.json");
        }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions(); // Most apps are already using this, but just in case.
        }

        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var appHost = new AlalaServiceAppHost(
                AlalaDefines.Name,
                Configuration,
                env,
                loggerFactory,
                typeof(AlalaServiceAppHost).Assembly
            );
            app.UseServiceStack(appHost);
        }
    }
}