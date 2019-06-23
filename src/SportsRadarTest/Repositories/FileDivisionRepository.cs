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

    public interface IDivisionRepository
    {
        Task<Division> GetDivision(DivisionType divisionType);
        Task<IEnumerable<Division>> GetAllDivisions();

    }
    public class FileDivisionRepository: IDivisionRepository
    {
        
        public async Task<Division> GetDivision(DivisionType divisionType)
        {
            var json = await File.ReadAllTextAsync($"SeedData\\{divisionType}SeedData.json");
            return await Task.Run(()=> JsonConvert.DeserializeObject<Division>(json));
        }

        public async Task<IEnumerable<Division>> GetAllDivisions()
        {
            var divList = new List<Division>();
            foreach (var div in Enum.GetNames(typeof(DivisionType)))
            {
                Enum.TryParse(typeof(DivisionType), div, out var dt);
                divList.Add(await GetDivision((DivisionType)dt));
            }
            return divList;

        }
    }
}
