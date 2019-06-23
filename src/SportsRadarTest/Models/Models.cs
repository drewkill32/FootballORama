using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public enum DivisionType
{
    FBS,
    FCS,
    D2,
    D3,
    NAIA,
    USCAA
}

namespace SportsRadarTest.Models
{
    public class Venue
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("capacity")]
        public int Capacity { get; set; }

        [JsonProperty("surface")]
        public string Surface { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }

    public class Team
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("market")]
        public string Market { get; set; }

        [JsonProperty("venue")]
        public Venue Venue { get; set; }
    }

    public class Subdivision
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("teams")]
        public IList<Team> Teams { get; set; }
    }

    public class Conference
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("subdivisions")]
        public IList<Subdivision> Subdivisions { get; set; }

        [JsonProperty("teams")]
        public IList<Team> Teams { get; set; }
    }

    public class Division
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("conferences")]
        public IList<Conference> Conferences { get; set; }
    }

    public class Broadcast
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("network")]
        public string Network { get; set; }

        [JsonProperty("satellite")]
        public string Satellite { get; set; }

        [JsonProperty("internet")]
        public string Internet { get; set; }
    }

    public class Game
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("scheduled")]
        public DateTime Scheduled { get; set; }

        [JsonProperty("coverage")]
        public string Coverage { get; set; }

        [JsonProperty("home_rotation")]
        public string HomeRotation { get; set; }

        [JsonProperty("away_rotation")]
        public string AwayRotation { get; set; }

        [JsonProperty("home")]
        [JsonConverter(typeof(TeamTypeConverter))]
        public Team Home { get; set; }

        [JsonProperty("away")]
        [JsonConverter(typeof(TeamTypeConverter))]
        public Team Away { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("neutral_site")]
        public bool NeutralSite { get; set; }

        [JsonProperty("venue")]
        public Venue Venue { get; set; }
    }

    public class Week
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("games")]
        public IList<Game> Games { get; set; }
    }

    public class Schedule
    {
        public int Id { get; set; }

        [JsonProperty("season")]
        public int Season { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("weeks")]
        public IList<Week> Weeks { get; set; }
    }
}