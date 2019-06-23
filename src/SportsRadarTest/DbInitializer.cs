using System;
using System.Linq;
using SportsRadarTest.Models;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.IO;
using SportsRadarTest.Repositories;
using System.Threading.Tasks;

namespace SportsRadarTest
{
    internal class DbInitializer
    {
        private readonly DivisionDataConext context;
        private readonly IDivisionRepository divisionRepository;
        private readonly IScheduleRepository scheduleRepository;

        public DbInitializer(DivisionDataConext context, IDivisionRepository divisionRepository, IScheduleRepository scheduleRepository)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.divisionRepository = divisionRepository ?? throw new ArgumentNullException(nameof(divisionRepository));
            this.scheduleRepository = scheduleRepository ?? throw new ArgumentNullException(nameof(scheduleRepository));
        }

        internal async Task Seed()
        {
            if (!context.Divisions.Any())
            {

                var divisions = await divisionRepository.GetAllDivisions();
                foreach (var division in divisions)
                {
                    await context.AddAsync(division);
                }
                
                
            }
            if (!context.Schedules.Any())
            {
                var schedules = await scheduleRepository.GetFbsSchedule();
                await context.AddAsync(schedules);

            }
            await context.SaveChangesAsync();
        }
    }
}