namespace GenesysGMerator.Helpers
{
    using System.Collections.Generic;
    using GenesysGMerator.CharacterCreation;
    using System.IO;
    using Newtonsoft.Json;

    public class DomainDataHelper
    {
        public static List<Archetype> GetArchitypes()
        {
            string serializedArchitypes = File.ReadAllText(@"DomainData\Archetypes.txt");
            return JsonConvert.DeserializeObject<List<Archetype>>(serializedArchitypes);
        }

        public static List<Career> GetCareers()
        {
            string serializedCareers = File.ReadAllText(@"DomainData\Careers.txt");
            return JsonConvert.DeserializeObject<List<Career>>(serializedCareers);
        }
    }
}
