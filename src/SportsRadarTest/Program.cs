using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SportsRadarTest.Models;

namespace SportsRadarTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new Startup().Build();
            var logger = services.GetRequiredService<ILogger<Program>>();

            using (var scope = services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                try
                {
                    var context = scopedServices.GetRequiredService<DivisionDataConext>();
                    var dbInitializer = scopedServices.GetRequiredService<DbInitializer>();
                    await dbInitializer.Seed();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message, ex);
                }
            }

            Console.WriteLine("Hello World!");
        }
    }
}
