using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    public class Program
    {
        protected Program() { }

        static async Task Main(string[] args)
        {
            var host = Host
                .CreateDefaultBuilder(args)
                .ConfigureLogging((context, logging) =>
                {
                    logging.ClearProviders();
                    logging.AddConsole(options => options.TimestampFormat = "[HH:mm:ss.fff MM/dd/yyyy] ");
                })
                .ConfigureAppConfiguration((context, logging) =>
                {
                    logging.Sources.Clear();
                    logging
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                        //.AddUserSecrets<Program>()
                        .AddEnvironmentVariables()
                        .AddCommandLine(args);
                })
                .ConfigureServices((context, services) =>
                {
                    var configuration = context.Configuration;
                    services
                        .AddSingleton<ConsoleApplication>();
                })
                .Build();

            var application = host.Services.GetRequiredService<ConsoleApplication>();
            await application.RunAsync();
            await Task.Delay(10);
        }
    }
}
