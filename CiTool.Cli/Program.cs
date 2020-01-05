using System.Threading.Tasks;
using CiTool.Cli.Verbs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace CiTool.Cli
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            using IServiceScope scope = host.Services.CreateScope();

            Runner runner = scope.ServiceProvider.GetRequiredService<Runner>();
            return await runner.Run(args);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging((hostContext, logging) =>
                {
                    logging.AddConsole(console =>
                    {
                        console.Format = ConsoleLoggerFormat.Systemd;
                    });
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<Runner>();
                    services.AddScoped<TestVerb>();
                });
    }
}
