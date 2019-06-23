using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SportsRadarTest.Models;
using System.IO;

namespace SportsRadarTest
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DivisionDataConext>
    {
        #region Private Fields

        private static IConfigurationRoot configuration;

        #endregion Private Fields

        #region Public Constructors

        static DesignTimeDbContextFactory()
        {
            configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();
        }

        #endregion Public Constructors

        #region Public Methods

        DivisionDataConext IDesignTimeDbContextFactory<DivisionDataConext>.CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DivisionDataConext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new DivisionDataConext(builder.Options);
        }


        #endregion Public Methods
    }
}