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

        bool hasExecuted = false;

        public OxygenSystem(string name) : base(name ){}

        public void ExecuteEndPhaseEffect(GameWorld world, float deltaTime)
        {
            IEnumerable<Room>? rooms = world.FindObjectsOfType<Room>();
            OxygenTracker? oxygen = world.FindObjectOfType<OxygenTracker>();

            if (oxygen == null)
            {
                Console.WriteLine("ERROR: OxygenTracker not found");
                EndPhaseEffectCompleted?.Invoke(this);
                return;
            }

            foreach (var room in rooms)
            {
                if (room is EmptyRoom && !room.IsOperational)
                    oxygen.SpendOxygen(1);

                if (room is OxygenRoom && room.IsOperational)
                    oxygen.AddOxygen(1);
            }

            EndPhaseEffectCompleted?.Invoke(this);
        }
    }
}
