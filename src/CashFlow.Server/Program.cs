using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using CashFlow.Server.Extensions;

namespace CashFlow.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().MigrateDatabase().Run();
            //CreateHostBuilder(args).Build().InitializeDatabase().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
