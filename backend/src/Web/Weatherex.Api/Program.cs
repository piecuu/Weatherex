using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Weatherex.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();

            Log.Information("Weatherex starting...");

            var host = CreateHostBuilder(args).Build();
            await host.RunAsync();

            //try
            //{
            //    Log.Information("Weatherex starting...");
            //    CreateHostBuilder(args).Build().Run();
            //}
            //catch (Exception ex)
            //{
            //    Log.Fatal(ex, "Something gone wrong while starting application. Exiting...");
            //}
            //finally
            //{
            //    Log.CloseAndFlush();
            //}
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
