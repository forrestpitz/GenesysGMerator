namespace GenesysGMerator.CharacterCreation
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// The different "classes" of character.
    /// </summary>

    [JsonObject]
    public class Archetype
    {
        [JsonProperty(Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty(Required = Required.Always)]
        public Characteristics BaseCharacteristics { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int InitialWounds { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int InitialStrain { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int StartingXP { get; set; }

        // Dont cache skills on archetype since it's a player choice
        ////[JsonProperty(Required = Required.Always)]
        ////public List<Skill> StartingSkills { get; set; }

        ////[JsonProperty(Required = Required.Always)]
        ////public List<Talent> StartingTalents { get; set; }
    }
}