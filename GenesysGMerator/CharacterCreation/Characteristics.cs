namespace GenesysGMerator.CharacterCreation
{
    using Newtonsoft.Json;

    [JsonObject]
    public class Characteristics
    {
        [JsonProperty(Required = Required.Always)]
        public int Brawn { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int Agility { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int Intelect { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int Cunning { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int Willpower { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int Presence { get; set; }
    }
}