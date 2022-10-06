using Microsoft.AspNetCore.OpenApi;
using Microsoft.Extensions.Logging.Console;

using MinimalApiDemo.Api;
using MinimalApiDemo.Bootstrapper;

namespace MinimalApiDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Get WebApplication instance
            var app = AppBuilder.GetApp(args);
            app.Logger.LogInformation("application instance created");

            // Configure Request Pipeline
            RequestPipelineBuilder.Configure(app);
            app.Logger.LogInformation("request pipeline has been configured");

            // Configure APIs 
            StudentsApi.RegisterApis(app);
            app.Logger.LogInformation("Apis have been registered");

            // Start the app
            app.Run();
        }
    }
}