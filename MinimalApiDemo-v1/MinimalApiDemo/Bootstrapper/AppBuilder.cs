using Microsoft.EntityFrameworkCore;

using MinimalApiDemo.DataAccess;
using MinimalApiDemo.DataAccess.Repositories;

using Serilog;

namespace MinimalApiDemo.Bootstrapper
{
    public static class AppBuilder
    {
        public static WebApplication GetApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //// If needed, Clear default providers
            //builder.Logging.ClearProviders();

            // Use Serilog - from code
            //builder.Host.UseSerilog((hostContext, services, configuration) =>
            //{
            //    configuration
            //        .WriteTo.File("serilog-file.txt")
            //        .WriteTo.Console();
            //});

            // Use Serilog - from configuration
            builder.Host.UseSerilog(
                (hostingContext, loggerConfiguration) =>
                    loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));

            // Setup database connection
            var connectionString = builder.Configuration.GetConnectionString("SqlConnectionString");
            builder
                .Services
                .AddDbContext<UniversityDbContext>(opt => opt.UseSqlServer(connectionString));

            // DI - Register repository 
            builder.Services.AddTransient<IStudentRepository, StudentRepository>();

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors();
            var app = builder.Build();

            // Use CORS
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            return app;
        }
    }
}
