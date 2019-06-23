using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SportsRadarTest.Models;
using SportsRadarTest.Repositories;

namespace SportsRadarTest
{
    public class Startup
    {


        private void ConfigureServices(IServiceCollection services,IConfigurationRoot config)
        {
            services.AddLogging(configure => configure.AddConsole().AddDebug());

            var connection = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<DivisionDataConext>(options => options.UseSqlServer(connection));
            services.AddScoped<DbInitializer>();
            services.AddTransient<IDivisionRepository, FileDivisionRepository>();
            services.AddTransient<IScheduleRepository, FileScheduleRepository>();

        }

        private IConfigurationRoot ConfigureAppConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .AddCommandLine(Environment.GetCommandLineArgs())
                .Build();
        }
        public IServiceProvider Build()
        {
            var config = ConfigureAppConfiguration();
            var services = new ServiceCollection();
            services.AddSingleton(config);
            ConfigureServices(services,config);
            return services.BuildServiceProvider();
        }
    }
}
