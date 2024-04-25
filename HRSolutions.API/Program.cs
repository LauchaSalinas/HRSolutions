
using HRSolutions.DataAccess;
using HRSolutions.DataAccess.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using HRSolutions.Application;

namespace WeatherForecastTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.MapType<DateOnly>(() => new OpenApiSchema
                {
                    Type = "string",
                    Format = "date"
                });
            });

            builder.Services.AddApplication();

            builder.Services.AddDataAccess(databaseConfiguration =>
            {
                databaseConfiguration.UseInMemoryDatabase = builder.Configuration.GetValue("InMemoryDatabase", false);
                databaseConfiguration.ConnectionString = builder.Configuration.GetConnectionString("HRDBConnection") ?? throw new Exception("Missing connection string");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection(); Since im running this in my local proxmox server without a SSL certificate for local LAN im disabling it, feel free to enable it again.

            app.UseAuthorization();


            app.MapControllers();
            SeedDatabase(app);
            app.Run();
        }

        static void SeedDatabase(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<HRSolutionsContext>();
                context.Database.EnsureCreated();
                HRSolutionsContextSeed.Initialize(services);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
            }
        }
    }
}
