using InvadedGame.Engine;
using InvadedGame.Game.Helpers;
using InvadedGame.Game.Interfaces;
using InvadedGame.Game.Rooms;

namespace InvadedGame.Game.Systems
{
    public class OxygenSystem : GameObject, IEndPhaseEffect
    {
        public event Action<GameObject>? EndPhaseEffectCompleted;

        public int OxygenValue = 0;

        private bool pending = false;

        public OxygenSystem(string name, int oxygenLevel) : base(name)
        {
            this.OxygenValue = oxygenLevel;
        }

        public void SpendOxygen(int spentOxygenValue)
        {
            OxygenValue -= spentOxygenValue;
            Logger.Info($"Spent **{spentOxygenValue}** Oxygen. New Oxygen level: **{OxygenValue}**", this);
        }

        public void AddOxygen(int addedOxygenValue)
        {
            OxygenValue += addedOxygenValue;
            Logger.Info($"Added **{addedOxygenValue}** Oxygen. New Oxygen level: **{OxygenValue}**", this);
        }

        public void StartExecution()
        {
            Logger.Info($"Gets order to start end effect execution...", this);
            pending = true;
        }

        public void ExecuteEndPhaseEffect(GameWorld world, float deltaTime)
        {
            IEnumerable<Room>? rooms = world.FindObjectsOfType<Room>();

            foreach (var room in rooms)
            {
                if (room is EmptyRoom && !room.IsOperational)
                    SpendOxygen(1);

                if (room is OxygenRoom && room.IsOperational)
                    AddOxygen(1);
            }

            EndPhaseEffectCompleted?.Invoke(this);
        }

        public override void Update(GameWorld world, float deltaTime)
        {
            base.Update(world, deltaTime);

            if (pending)
            {
                pending = false;
                ExecuteEndPhaseEffect(world, deltaTime);
            }
        }
    }
}
