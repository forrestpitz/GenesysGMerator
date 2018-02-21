namespace GenesysGMerator.CharacterCreation
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Represents a character
    /// </summary>

    [JsonObject]
    public class Character
    {
        public Character()
        {
            Skills = new List<Skill>();
            Weapons = new List<Weapon>();
        }

        [JsonProperty(Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty(Required = Required.Always)]
        public Archetype Arechetype { get; set; }

        [JsonProperty(Required = Required.Always)]
        public Career Career { get; set; }
        
        public string PlayerName { get; set; }

        ////[JsonProperty(Required = Required.Always)]
        ////public int Soak { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int WoundThreshold { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int WoundsCurrent { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int StrainThreshold { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int StrainCurrent { get; set; }

        ////[JsonProperty(Required = Required.Always)]
        ////public int DefenseRanged { get; set; }

        ////[JsonProperty(Required = Required.Always)]
        ////public int DefenseMelee { get; set; }

        [JsonProperty(Required = Required.Always)]
        public Characteristics Characteristics { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<Skill> Skills{ get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<Weapon> Weapons { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int XPToatal { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int XPBalance { get; set; }
    }
}
