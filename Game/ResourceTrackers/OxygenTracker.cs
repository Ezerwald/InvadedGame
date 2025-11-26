using InvadedGame.Engine;
using InvadedGame.Game.Helpers;

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
            Logger.LogInfo($"Spent **{spentOxygenValue}** Oxygen. New Oxygen level: **{OxygenValue}**");
        }

        public void AddOxygen(int addedOxygenValue)
        {
            OxygenValue += addedOxygenValue;
            Logger.LogInfo($"Added **{addedOxygenValue}** Oxygen. New Oxygen level: **{OxygenValue}**");
        }
    }
}
