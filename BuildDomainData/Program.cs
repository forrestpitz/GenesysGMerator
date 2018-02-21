namespace BuildDomainData
{
    using GenesysGMerator.CharacterCreation;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GenerateArchetype());
            Console.WriteLine();
            Console.WriteLine(GenerateCareers());

            Console.ReadLine();
        }

        public static string GenerateCareers()
        {
            List<Career> careers = new List<Career>();

            Career Entertainer = new Career();
            Entertainer.Name = "Entertainer";
            Entertainer.Skills = new List<SkillType> { SkillType.Athletics, SkillType.Brawl, SkillType.Coordination, SkillType.Deception, SkillType.Perception, SkillType.Ranged, SkillType.Stealth, SkillType.Survival };
            careers.Add(Entertainer);

            Career Healer = new Career();
            Healer.Name = "Healer";
            Healer.Skills = new List<SkillType> { SkillType.Cool, SkillType.Discipline, SkillType.Knowledge, SkillType.Medicine, SkillType.Melee, SkillType.Resilience, SkillType.Survival, SkillType.Vigilance };
            careers.Add(Healer);

            Career Leader = new Career();
            Leader.Name = "Healer";
            Leader.Skills = new List<SkillType> { SkillType.Charm, SkillType.Coercion, SkillType.Cool, SkillType.Discipline, SkillType.Leadership, SkillType.Melee, SkillType.Negotiation, SkillType.Perception };
            careers.Add(Leader);

            Career Scoundrel = new Career();
            Scoundrel.Name = "Scoundrel";
            Scoundrel.Skills = new List<SkillType> { SkillType.Charm, SkillType.Cool, SkillType.Coordination, SkillType.Deception, SkillType.Ranged, SkillType.Skulduggery, SkillType.Stealth, SkillType.Streetwise };
            careers.Add(Scoundrel);

            Career Socialite = new Career();
            Socialite.Name = "Socialite";
            Socialite.Skills = new List<SkillType> { SkillType.Charm, SkillType.Cool, SkillType.Deception, SkillType.Knowledge, SkillType.Negotiation, SkillType.Perception, SkillType.Streetwise, SkillType.Vigilance };
            careers.Add(Socialite);

            Career Soldier = new Career();
            Soldier.Name = "Soldier";
            Soldier.Skills = new List<SkillType> { SkillType.Charm, SkillType.Cool, SkillType.Deception, SkillType.Knowledge, SkillType.Negotiation, SkillType.Perception, SkillType.Streetwise, SkillType.Vigilance };
            careers.Add(Soldier);

            Career MadScientist = new Career();
            MadScientist.Name = "Mad Scientist";
            MadScientist.Skills = new List<SkillType> { SkillType.Alchemy, SkillType.Coercion, SkillType.Knowledge, SkillType.Mechanics, SkillType.Medicine, SkillType.Operating, SkillType.Skulduggery, SkillType.Ranged_Heavy };
            careers.Add(MadScientist);

            Career Priest = new Career();
            Priest.Name = "Priest";
            Priest.Skills = new List<SkillType> { SkillType.Charm, SkillType.Coercion, SkillType.Cool, SkillType.Discipline, SkillType.Divine, SkillType.Medicine, SkillType.Melee, SkillType.Negotiation };
            careers.Add(Priest);

            Career Druid = new Career();
            Druid.Name = "Druid";
            Druid.Skills = new List<SkillType> { SkillType.Athletics, SkillType.Brawl, SkillType.Coordination, SkillType.Melee, SkillType.Primal, SkillType.Resilience, SkillType.Survival, SkillType.Vigilance };
            careers.Add(Druid);

            Career StarshipCaptain = new Career();
            StarshipCaptain.Name = "Starship Captain";
            StarshipCaptain.Skills = new List<SkillType> { SkillType.Computers, SkillType.Discipline, SkillType.Gunnery, SkillType.Knowledge, SkillType.Leadership, SkillType.Mechanics, SkillType.Operating, SkillType.Perception };
            careers.Add(StarshipCaptain);

            Career Tradesperson = new Career();
            Tradesperson.Name = "Tradesperson";
            Tradesperson.Skills = new List<SkillType> { SkillType.Athletics, SkillType.Brawl, SkillType.Discipline, SkillType.Mechanics, SkillType.Negotiation, SkillType.Perception, SkillType.Resilience, SkillType.Streetwise };
            careers.Add(Tradesperson);

            Career Knight = new Career();
            Knight.Name = "Knight";
            Knight.Skills = new List<SkillType> { SkillType.Athletics, SkillType.Discipline, SkillType.Leadership, SkillType.Melee_Heavy, SkillType.Melee_Light, SkillType.Resilience, SkillType.Riding, SkillType.Vigilance };
            careers.Add(Knight);

            Career Explorer = new Career();
            Explorer.Name = "Explorer";
            Explorer.Skills = new List<SkillType> { SkillType.Athletics, SkillType.Brawl, SkillType.Coordination, SkillType.Deception, SkillType.Perception, SkillType.Ranged, SkillType.Ranged_Heavy, SkillType.Stealth, SkillType.Survival };
            careers.Add(Explorer);

            return JsonConvert.SerializeObject(careers);
        }

        public static string GenerateArchetype()
        {
            ////AverageHuman
            List<Archetype> archetypes = new List<Archetype>();
            Archetype averageHuman = new Archetype();
            averageHuman.Name = "Average Human";
            Characteristics baseCharacteristics = new Characteristics()
            {
                Agility = 2,
                Brawn = 2,
                Cunning = 2,
                Intelect = 2,
                Presence = 2,
                Willpower = 2
            };

            averageHuman.BaseCharacteristics = baseCharacteristics;

            averageHuman.InitialStrain = 12;
            averageHuman.InitialWounds = 12;
            averageHuman.StartingXP = 110;

            archetypes.Add(averageHuman);

            ////Laboror,
            Archetype laboror = new Archetype();
            laboror.Name = "Laboror";
            baseCharacteristics = new Characteristics()
            {
                Brawn = 3,
                Agility = 2,
                Intelect = 2,
                Cunning = 2,
                Willpower = 1,
                Presence = 2,
            };

            laboror.BaseCharacteristics = baseCharacteristics;

            laboror.InitialWounds = 15;
            laboror.InitialStrain = 9;
            laboror.StartingXP = 100;

            archetypes.Add(laboror);

            ////Intellectual,
            Archetype intellectual = new Archetype();
            intellectual.Name = "Intellectual";
            baseCharacteristics = new Characteristics()
            {
                Brawn = 1,
                Agility = 1,
                Intelect = 2,
                Cunning = 2,
                Willpower = 2,
                Presence = 2,
            };

            intellectual.BaseCharacteristics = baseCharacteristics;

            intellectual.InitialWounds = 9;
            intellectual.InitialStrain = 14;
            intellectual.StartingXP = 100;

            archetypes.Add(intellectual);

            ////Aristocrat,
            Archetype aristocrat = new Archetype();
            aristocrat.Name = "Aristocrat";
            baseCharacteristics = new Characteristics()
            {
                Brawn = 1,
                Agility = 2,
                Intelect = 2,
                Cunning = 2,
                Willpower = 2,
                Presence = 3,
            };

            aristocrat.BaseCharacteristics = baseCharacteristics;

            aristocrat.InitialWounds = 11;
            aristocrat.InitialStrain = 12;
            aristocrat.StartingXP = 100;

            archetypes.Add(aristocrat);

            ////Elf,
            Archetype elf = new Archetype();
            elf.Name = "Elf";
            baseCharacteristics = new Characteristics()
            {
                Brawn = 2,
                Agility = 3,
                Intelect = 2,
                Cunning = 2,
                Willpower = 1,
                Presence = 2,
            };

            elf.BaseCharacteristics = baseCharacteristics;

            elf.InitialWounds = 11;
            elf.InitialStrain = 11;
            elf.StartingXP = 90;

            archetypes.Add(elf);

            ////Dwarf,
            Archetype dwarf = new Archetype();
            dwarf.Name = "Dwarf";
            baseCharacteristics = new Characteristics()
            {
                Brawn = 2,
                Agility = 1,
                Intelect = 2,
                Cunning = 2,
                Willpower = 3,
                Presence = 2,
            };

            dwarf.BaseCharacteristics = baseCharacteristics;

            dwarf.InitialWounds = 13;
            dwarf.InitialStrain = 13;
            dwarf.StartingXP = 90;

            archetypes.Add(dwarf);

            ////Orc,
            Archetype orc = new Archetype();
            orc.Name = "Orc";
            baseCharacteristics = new Characteristics()
            {
                Brawn = 3,
                Agility = 2,
                Intelect = 2,
                Cunning = 2,
                Willpower = 2,
                Presence = 1,
            };

            orc.BaseCharacteristics = baseCharacteristics;

            orc.InitialWounds = 15;
            orc.InitialStrain = 10;
            orc.StartingXP = 100;

            archetypes.Add(orc);

            ////Mongrel,
            Archetype mongrel = new Archetype();
            mongrel.Name = "Mongrel";
            baseCharacteristics = new Characteristics()
            {
                Brawn = 2,
                Agility = 2,
                Intelect = 2,
                Cunning = 2,
                Willpower = 2,
                Presence = 2,
            };

            mongrel.BaseCharacteristics = baseCharacteristics;

            mongrel.InitialWounds = 12;
            mongrel.InitialStrain = 10;
            mongrel.StartingXP = 100;

            archetypes.Add(mongrel);

            ////Revenant,
            Archetype revenant = new Archetype();
            revenant.Name = "Revenant";
            baseCharacteristics = new Characteristics()
            {
                Brawn = 3,
                Agility = 2,
                Intelect = 2,
                Cunning = 2,
                Willpower = 2,
                Presence = 1,
            };

            revenant.BaseCharacteristics = baseCharacteristics;

            revenant.InitialWounds = 15;
            revenant.InitialStrain = 11;
            revenant.StartingXP = 100;

            archetypes.Add(revenant);

            ////Bioroid,
            Archetype bioroid = new Archetype();
            bioroid.Name = "Bioroid";
            baseCharacteristics = new Characteristics()
            {
                Brawn = 3,
                Agility = 1,
                Intelect = 1,
                Cunning = 1,
                Willpower = 1,
                Presence = 1,
            };

            bioroid.BaseCharacteristics = baseCharacteristics;

            bioroid.InitialWounds = 14;
            bioroid.InitialStrain = 9;
            bioroid.StartingXP = 155;

            archetypes.Add(bioroid);

            ////Clone,
            Archetype clone = new Archetype();
            clone.Name = "Clone";
            baseCharacteristics = new Characteristics()
            {
                Brawn = 2,
                Agility = 2,
                Intelect = 2,
                Cunning = 2,
                Willpower = 2,
                Presence = 2,
            };

            clone.BaseCharacteristics = baseCharacteristics;

            clone.InitialWounds = 13;
            clone.InitialStrain = 12;
            clone.StartingXP = 80;

            archetypes.Add(clone);

            ////AnamalisticAlien,
            Archetype anamalisticAlien = new Archetype();
            anamalisticAlien.Name = "Anamalistic Alien";
            baseCharacteristics = new Characteristics()
            {
                Brawn = 3,
                Agility = 3,
                Intelect = 2,
                Cunning = 2,
                Willpower = 1,
                Presence = 2,
            };

            anamalisticAlien.BaseCharacteristics = baseCharacteristics;

            anamalisticAlien.InitialWounds = 13;
            anamalisticAlien.InitialStrain = 9;
            anamalisticAlien.StartingXP = 70;

            archetypes.Add(anamalisticAlien);

            ////Psionic,
            Archetype psionic = new Archetype();
            psionic.Name = "Psionic";
            baseCharacteristics = new Characteristics()
            {
                Brawn = 2,
                Agility = 2,
                Intelect = 2,
                Cunning = 2,
                Willpower = 3,
                Presence = 1,
            };

            psionic.BaseCharacteristics = baseCharacteristics;

            psionic.InitialWounds = 9;
            psionic.InitialStrain = 14;
            psionic.StartingXP = 70;

            archetypes.Add(psionic);

            ////Robot,
            Archetype robot = new Archetype();
            robot.Name = "Robot";
            baseCharacteristics = new Characteristics()
            {
                Brawn = 1,
                Agility = 1,
                Intelect = 1,
                Cunning = 1,
                Willpower = 1,
                Presence = 1,
            };

            robot.BaseCharacteristics = baseCharacteristics;

            robot.InitialWounds = 11;
            robot.InitialStrain = 11;
            robot.StartingXP = 175;

            archetypes.Add(robot);

            ////Vanguard,
            Archetype vanguard = new Archetype();
            vanguard.Name = "Vanguard";
            baseCharacteristics = new Characteristics()
            {
                Brawn = 2,
                Agility = 2,
                Intelect = 2,
                Cunning = 1,
                Willpower = 2,
                Presence = 3,
            };

            vanguard.BaseCharacteristics = baseCharacteristics;

            vanguard.InitialWounds = 11;
            vanguard.InitialStrain = 11;
            vanguard.StartingXP = 100;

            archetypes.Add(vanguard);

            return JsonConvert.SerializeObject(archetypes);
        }
    }
}
