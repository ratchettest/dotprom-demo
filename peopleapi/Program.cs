using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace peopleapi {
    public class Program {
        public static void Main(string[] args) {
            var logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File("log.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            CreateHostBuilder(args)
                .UseSerilog(logger)
                
                .Build()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                });
            
    }
}
