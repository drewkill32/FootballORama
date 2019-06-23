using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SportsRadarTest
{
    public class Settings
    {

        private static IConfigurationRoot config;

        public string ConnectionString { get; set; }
        public static Settings Default { get; private set; }
        public Settings()
        {

        }
        public Settings(IConfigurationRoot config) : this(true)
        {
            Settings.config = config;
            ConnectionString = config["ConnectionStrings:DefaultConnection"];
            config.Bind(this);

        }
        public Settings(bool addToDefault)
        {
            if (addToDefault)
                Default = this;
        }
    }
}
