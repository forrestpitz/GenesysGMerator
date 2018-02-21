namespace GenesysGMerator.Helpers
{
    using System.Collections.Generic;
    using GenesysGMerator.CharacterCreation;
    using System.IO;
    using Newtonsoft.Json;
    using System;

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

        public static string GetName()
        {
            string[] names = File.ReadAllLines(@"DomainData\Misc\FirstNames.txt");
            Random rand = new Random();
            int pos = rand.Next(0, names.Length - 1);
            return names[pos];
        }

        public static string GetInsult()
        {
            Random rand = new Random();
            string[] ins1 = File.ReadAllLines(@"DomainData\Misc\Insult1.txt");
            int ins1Pos = rand.Next(0, ins1.Length - 1);
            string[] ins2 = File.ReadAllLines(@"DomainData\Misc\Insult2.txt");
            int ins2Pos = rand.Next(0, ins2.Length - 1);
            string[] ins3 = File.ReadAllLines(@"DomainData\Misc\Insult2.txt");
            int ins3Pos = rand.Next(0, ins3.Length - 1);
            return string.Join(" ", ins1[ins1Pos], ins2[ins2Pos], ins3[ins3Pos]);
        }

        public static string GetDumbItem()
        {
            Random rand = new Random();
            string[] items = File.ReadAllLines(@"DomainData\Items\DumbItems.txt");
            int pos = rand.Next(0, items.Length - 1);
            return items[pos];
        }

        public static string GetGoodPlotHook()
        {
            Random rand = new Random();
            string[] plotHooks = File.ReadAllLines(@"DomainData\Encounters\GoodPlotHooks.txt");
            int pos = rand.Next(0, plotHooks.Length - 1);
            return plotHooks[pos];
        }

        public static string GetDungeonFlavor()
        {
            Random rand = new Random();
            string[] dungeonFlavor = File.ReadAllLines(@"DomainData\Encounters\DungeonFlavor.txt");
            int pos = rand.Next(0, dungeonFlavor.Length - 1);
            return dungeonFlavor[pos];
        }

        public static string GetForestFlavor()
        {
            Random rand = new Random();
            string[] forestFlavor = File.ReadAllLines(@"DomainData\Encounters\ForestFlavor.txt");
            int pos = rand.Next(0, forestFlavor.Length - 1);
            return forestFlavor[pos];
        }

        public static string GetNpcPlotHooks()
        {
            Random rand = new Random();
            string[] npcPlotHooks = File.ReadAllLines(@"DomainData\Encounters\NPCPlothooks.txt");
            int pos = rand.Next(0, npcPlotHooks.Length - 1);
            return npcPlotHooks[pos];
        }

        public static string GetRoadEncounter()
        {
            Random rand = new Random();
            string[] roadEncounters = File.ReadAllLines(@"DomainData\Encounters\RoadEncounters.txt");
            int pos = rand.Next(0, roadEncounters.Length - 1);
            return roadEncounters[pos];
        }

        public static string GetRoadTravelEvent()
        {
            Random rand = new Random();
            string[] roadTravelEvents = File.ReadAllLines(@"DomainData\Encounters\RoadTravel.txt");
            int pos = rand.Next(0, roadTravelEvents.Length - 1);
            return roadTravelEvents[pos];
        }

        public static string GetRottingCityFlavor()
        {
            Random rand = new Random();
            string[] rottingCityFlavor = File.ReadAllLines(@"DomainData\Encounters\RottingCityFlavor.txt");
            int pos = rand.Next(0, rottingCityFlavor.Length - 1);
            return rottingCityFlavor[pos];
        }

        public static string GetShipFlavor()
        {
            Random rand = new Random();
            string[] shipFlavor = File.ReadAllLines(@"DomainData\Encounters\ShipFlavor.txt");
            int pos = rand.Next(0, shipFlavor.Length - 1);
            return shipFlavor[pos];
        }

        public static string GetShittyPlotHook()
        {
            Random rand = new Random();
            string[] shittyPlotHooks = File.ReadAllLines(@"DomainData\Encounters\ShittyPlotHooks.txt");
            int pos = rand.Next(0, shittyPlotHooks.Length - 1);
            return shittyPlotHooks[pos];
        }

        public static string GetTravelEncounters()
        {
            Random rand = new Random();
            string[] travelEncounters = File.ReadAllLines(@"DomainData\Encounters\TravelEncounters.txt");
            int pos = rand.Next(0, travelEncounters.Length - 1);
            return travelEncounters[pos];
        }

        public static string GetUrbanEncounter()
        {
            Random rand = new Random();
            string[] urbanEncounters = File.ReadAllLines(@"DomainData\Encounters\UrbanEncounters.txt");
            int pos = rand.Next(0, urbanEncounters.Length - 1);
            return urbanEncounters[pos];
        }

        public static string GetVillageFlavor()
        {
            Random rand = new Random();
            string[] villageFlavor = File.ReadAllLines(@"DomainData\Encounters\VillageFlavor.txt");
            int pos = rand.Next(0, villageFlavor.Length - 1);
            return villageFlavor[pos];
        }

        public static string GetOffRoadTravel()
        {
            Random rand = new Random();
            string[] offRoadTravel = File.ReadAllLines(@"DomainData\Encounters\OffRoadTravel.txt");
            int pos = rand.Next(0, offRoadTravel.Length - 1);
            return offRoadTravel[pos];
        }
    }
}
