using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SportsRadarTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsRadarTest
{
    public class TeamTypeConverter : JsonConverter
    {


        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
    
            var target = new Team() { Id = reader.Value.ToString() };
            //serializer.Populate(reader, target);

            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanRead
        {
            get { return true; }
        }
    }
}
