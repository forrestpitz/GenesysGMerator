namespace GenesysGMerator.CharacterCreation
{
    using Newtonsoft.Json;
    public class Weapon
    {
        [JsonProperty(Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Skill { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int Damage { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int Crit { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int Range { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int Special { get; set; }
    }
}