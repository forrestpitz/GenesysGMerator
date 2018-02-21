namespace GenesysGMerator.CampaignManagement
{
    using GenesysGMerator.CharacterCreation;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    [JsonObject]
    public class Campaign
    {
        [JsonProperty(Required=Required.Always)]
        public string Name { get; set; }

        [JsonProperty]
        public List<Character> Characters { get; set; }
    }
}
