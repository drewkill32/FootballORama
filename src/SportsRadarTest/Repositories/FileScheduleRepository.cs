using Newtonsoft.Json;
using SportsRadarTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsRadarTest.Repositories
{

    public interface IScheduleRepository
    {
        Task<Schedule> GetFbsSchedule();

    }
    public class FileScheduleRepository: IScheduleRepository
    {
        public async Task<Schedule> GetFbsSchedule()
        {
            var json = await File.ReadAllTextAsync("SeedData\\2019ScheduleSeedData.json");
            return JsonConvert.DeserializeObject<Schedule>(json);
            
        }
    }
}
