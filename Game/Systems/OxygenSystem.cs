using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InvadedGame.Engine;
using InvadedGame.Game.GamePhases;
using InvadedGame.Game.Interfaces;
using InvadedGame.Game.ResourceTrackers;
using InvadedGame.Game.Rooms;

namespace InvadedGame.Game.Systems
{
    public class OxygenSystem : GameObject, IEndPhaseEffect
    {
        public event Action<GameObject>? EndPhaseEffectCompleted;

        public OxygenTracker OxygenTracker { get; }

        public OxygenSystem(string name, OxygenTracker oxygenTracker) : base(name)
        {
            OxygenTracker = oxygenTracker;
        }

        public void ExecuteEndPhaseEffect(GameWorld world, float deltaTime)
        {
            IEnumerable<Room>? rooms = world.FindObjectsOfType<Room>();

            if (OxygenTracker == null)
            {
                Console.WriteLine("ERROR: OxygenTracker not found");
                EndPhaseEffectCompleted?.Invoke(this);
                return;
            }

            foreach (var room in rooms)
            {
                if (room is EmptyRoom && !room.IsOperational)
                    OxygenTracker.SpendOxygen(1);

                if (room is OxygenRoom && room.IsOperational)
                    OxygenTracker.AddOxygen(1);
            }

            EndPhaseEffectCompleted?.Invoke(this);
        }
    }
}
