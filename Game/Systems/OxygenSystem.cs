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
        bool executedThisRound = false; // for once per round systems

        public OxygenSystem(string name) : base(name ){}

        public void ExecuteEndPhaseEffect(GameWorld world, float deltaTime)
        {
            IEnumerable<Room> rooms = world.FindObjectsOfType<Room>();
            OxygenTracker? oxygen = world.FindObjectOfType<OxygenTracker>();

            if (oxygen == null)
            {
                Console.WriteLine("ERROR: OxygenTracker is not found");
                return;
            }

            foreach (Room room in rooms)
            {
                // Empty rooms leakege
                if ((room is EmptyRoom) && (room.IsOperational == false))
                {
                    oxygen.SpendOxygen(1);
                }

                // Oxygen generating rooms profit
                if ((room is OxygenRoom) && (room.IsOperational == true))
                {
                    oxygen.AddOxygen(1);
                }
            }
        }

        public override void Update(GameWorld world, float deltaTime)
        {
            base.Update(world, deltaTime);

            PhaseManager? phaseManager = world.FindObjectOfType<PhaseManager>();

            if (phaseManager != null)
            {
                if (phaseManager.CurrentPhase == GamePhase.PlanningPhase && executedThisRound)
                {
                    executedThisRound = false;
                }
                else if (phaseManager.CurrentPhase == GamePhase.EndPhase && !executedThisRound)
                {
                    executedThisRound = true;
                    this.ExecuteEndPhaseEffect(world, deltaTime);
                }
            }
        }
    }
}
