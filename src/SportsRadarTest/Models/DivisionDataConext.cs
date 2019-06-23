using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsRadarTest.Models
{
    public class DivisionDataConext:DbContext
    {
        

        public DivisionDataConext(DbContextOptions<DivisionDataConext> options) : base(options)
        {

        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Subdivision> Subdivisions { get; set; }

        public DbSet<Conference> Conferences { get; set; }

        public DbSet<Division> Divisions { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Week> Weeks { get; set; }

        public DbSet<Schedule> Schedules { get; set; }



    }
}
