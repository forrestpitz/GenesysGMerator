namespace GenesysGMerator.CharacterCreation
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonObject]
    public class Skill
    {
        [JsonProperty(Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public SkillType Name { get; set; }

        ////[JsonProperty(Required = Required.Always)]
        ////public Setting Setting { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool IsCareer { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int Rank { get; set; }
    }
}