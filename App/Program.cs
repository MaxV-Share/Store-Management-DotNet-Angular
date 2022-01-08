using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.IO;
using System.Threading.Tasks;
using App.Models.DbContexts;

namespace App
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json")
                                .Build();
        public static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(Configuration)
                    .CreateLogger();

            var host = CreateHostBuilder(args).Build();

            await CreateDbIfNotExistsAsync(host);

            try
            {
                host.Run();
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        private static async Task CreateDbIfNotExistsAsync(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    await context.Database.MigrateAsync();
                    var dbInitializer = services.GetService<DBInitializer>();
                    await dbInitializer.Seed();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                        .UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
                        .ReadFrom.Configuration(hostingContext.Configuration))
                        .ConfigureWebHostDefaults(webBuilder =>
                        {
                            webBuilder.UseWebRoot("wwwroot");
                            webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                            webBuilder.UseStartup<Startup>();
                            webBuilder.UseIISIntegration();
                        });
    }
}
