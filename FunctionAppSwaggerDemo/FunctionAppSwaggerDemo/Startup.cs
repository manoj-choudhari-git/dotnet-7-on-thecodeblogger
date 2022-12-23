using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

using System;

[assembly: FunctionsStartup(typeof(FunctionAppSwaggerDemo.Startup))]


namespace FunctionAppSwaggerDemo
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {

            builder.Services.AddTransient<IMyService, MyService>();

        }
    }


    public interface IMyService
    {
        void Log(string message);
    }

    public class MyService : IMyService
    {
        public void Log(string message)
        {
            Console.WriteLine($"{DateTime.Now} - {message}");
        }
    }
}
