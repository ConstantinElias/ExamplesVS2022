using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace MiddlewareServiceProvider
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureLogging(configureLogging => configureLogging.ClearProviders());
                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog((hostBuilderContext, loggerConfiguration) => loggerConfiguration.ReadFrom.Configuration(hostBuilderContext.Configuration));
    }
}
