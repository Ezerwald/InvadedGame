using InvadedGame.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvadedGame.Game.ResourceTrackers
{
    public class OxygenTracker : GameObject
    {
        public int OxygenValue { get; private set; } = 0;
        public OxygenTracker(string name, int oxygenLevel)
            : base(name)
        {
            OxygenValue = oxygenLevel;
        }

        public void SpendOxygen(int spentOxygenValue)
        {
            OxygenValue -= spentOxygenValue;
            Console.WriteLine($"Spent **{spentOxygenValue}** Oxygen. New Oxygen level: **{OxygenValue}**");
        }

        public void AddOxygen(int addedOxygenValue)
        {
            OxygenValue += addedOxygenValue;
            Console.WriteLine($"Added **{addedOxygenValue}** Oxygen. New Oxygen level: **{OxygenValue}**");
        }
    }
}
