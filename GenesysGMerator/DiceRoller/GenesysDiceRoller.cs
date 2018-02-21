using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenesysGMerator.DiceRoller
{
    public class GenesysDiceRoller
    {
        public static RollResult Roll(int boost, int setback, int ability, int difficulty, int proficiency, int chalange)
        {
            RollResult result = new RollResult();
            int successes = 0;
            int failures = 0;
            int threats = 0;
            int advantages = 0;
            int triumphs = 0;
            int dispairs = 0;

            Random rand = new Random();

            // Boost Die
            for(int d = 0; d < boost; d++)
            {
                int roll = rand.Next(1, 6);

                switch(roll)
                {
                    case 3:
                        successes += 1;
                        break;
                    case 4:
                        successes += 1;
                        advantages += 1;
                        break;
                    case 5:
                        advantages += 2;
                        break;
                    case 6:
                        advantages += 1;
                        break;
                }
            }

            // Setback Die
            for (int d = 0; d < setback; d++)
            {
                int roll = rand.Next(1, 6);

                switch (roll)
                {
                    case 3:
                        failures += 1;
                        break;
                    case 4:
                        failures += 1;
                        break;
                    case 5:
                        threats += 1;
                        break;
                    case 6:
                        threats += 1;
                        break;
                }
            }

            // Ability Die
            for (int d = 0; d < ability; d++)
            {
                int roll = rand.Next(1, 8);

                switch (roll)
                {
                    case 2:
                        successes += 1;
                        break;
                    case 3:
                        successes += 1;
                        break;
                    case 4:
                        successes += 2;
                        break;
                    case 5:
                        advantages += 1;
                        break;
                    case 6:
                        advantages += 1;
                        break;
                    case 7:
                        successes += 1;
                        advantages += 1;
                        break;
                    case 8:
                        advantages += 2;
                        break;
                }
            }

            // Dificulty Die
            for (int d = 0; d < difficulty; d++)
            {
                int roll = rand.Next(1, 8);

                switch (roll)
                {
                    case 2:
                        failures += 1;
                        break;
                    case 3:
                        failures += 2;
                        break;
                    case 4:
                        threats += 1;
                        break;
                    case 5:
                        threats += 1;
                        break;
                    case 6:
                        threats += 1;
                        break;
                    case 7:
                        threats += 2;
                        break;
                    case 8:
                        failures += 1;
                        threats += 1;
                        break;
                }
            }

            // Proficiency Die
            for (int d = 0; d < proficiency; d++)
            {
                int roll = rand.Next(1, 12);

                switch (roll)
                {
                    case 2:
                        successes += 1;
                        break;
                    case 3:
                        successes += 1;
                        break;
                    case 4:
                        successes += 2;
                        break;
                    case 5:
                        successes += 2;
                        break;
                    case 6:
                        advantages += 1;
                        break;
                    case 7:
                        successes += 1;
                        advantages += 1;
                        break;
                    case 8:
                        successes += 1;
                        advantages += 1;
                        break;
                    case 9:
                        successes += 1;
                        advantages += 1;
                        break;
                    case 10:
                        advantages += 2;
                        break;
                    case 11:
                        advantages += 2;
                        break;
                    case 12:
                        triumphs += 1;
                        break;
                }
            }

            // Chalange Die
            for (int d = 0; d < proficiency; d++)
            {
                int roll = rand.Next(1, 12);

                switch (roll)
                {
                    case 2:
                        failures += 1;
                        break;
                    case 3:
                        failures += 1;
                        break;
                    case 4:
                        failures += 2;
                        break;
                    case 5:
                        failures += 2;
                        break;
                    case 6:
                        threats += 1;
                        break;
                    case 7:
                        threats += 1;
                        break;
                    case 8:
                        failures += 1;
                        threats += 1;
                        break;
                    case 9:
                        failures += 1;
                        threats += 1;
                        break;
                    case 10:
                        threats += 2;
                        break;
                    case 11:
                        threats += 2;
                        break;
                    case 12:
                        dispairs += 1;
                        break;
                }
            }

            // The roll suceeded
            if (successes + triumphs - failures - dispairs > 0)
            {
                result.Successes = successes + triumphs - failures - dispairs;
            }

            // The roll failed
            if (successes + triumphs - failures - dispairs < 0)
            {
                result.Failures = failures + dispairs - successes - triumphs;
            }

            // We had advantages
            if (advantages - threats > 0)
            {
                result.Advantages = advantages - threats;
            }

            if (advantages - threats < 0)
            {
                result.Threats = threats - advantages;
            }

            result.Triumphs = triumphs;
            result.Dispairs = dispairs;

            return result;
        }
    }
}
