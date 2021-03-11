using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace POC_LOG
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hostBuilder = CreateHostBuilder(args).Build();
            Serilog.Log.Information("Iniciando o Host.....");
            hostBuilder.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) => {
                    var settings = config.Build();
                    Serilog.Log.Logger = new LoggerConfiguration()
                    .WriteTo.Console(outputTemplate: "{NewLine}{Timestamp:dd/MM/yyyy HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}")
                    .Enrich.FromLogContext()
                    .CreateLogger();
                })                
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
