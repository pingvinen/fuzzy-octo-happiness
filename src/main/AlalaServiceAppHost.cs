using System;
using System.Reflection;
using Funq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ServiceStack;
using ServiceStack.Api.OpenApi;
using ServiceStack.Text;

namespace main
{
    public class AlalaServiceAppHost : AppHostBase
    {
        private readonly IConfigurationRoot _configuration;
        private readonly IHostingEnvironment _env;
        private readonly ILoggerFactory _loggerFactory;

        public AlalaServiceAppHost(
            string name, 
            IConfigurationRoot configuration, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory, 
            Assembly assembly
        ) : base(name, assembly)
        {
            _configuration = configuration;
            _env = env;
            _loggerFactory = loggerFactory;
        }

        public override void Configure(Container container)
        {
            SetConfig(new HostConfig
            {
                DebugMode = _env.IsDevelopment(),
                WriteErrorsToResponse = true,
                UseCamelCase = true,
                EnableOptimizations = _env.IsProduction()
            });
            
            JsConfig.EmitCamelCaseNames = true;
            JsConfig.DateHandler = DateHandler.ISO8601;
            JsConfig.IncludeNullValues = true;
            JsConfig.AlwaysUseUtc = true;
            JsConfig.AssumeUtc = false;
            JsConfig.TimeSpanHandler = TimeSpanHandler.StandardFormat;
            
            // TODO authentication
            
            Plugins.Add(new CorsFeature(allowedHeaders: "Content-Type, Authorization"));
            Plugins.Add(new OpenApiFeature());

            ContainerSetup.RegisterStuff(container, _configuration, _loggerFactory);
        }
    }
}