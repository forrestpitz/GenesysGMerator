namespace GenesysGMerator.CharacterCreation
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Collections.Generic;

    [JsonObject]
    public class Career
    {
        [JsonProperty(Required = Required.Always)]
        public string Name { get; set; }
        
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter), Required = Required.Always)]
        public List<SkillType> Skills { get; set; }
    }
}