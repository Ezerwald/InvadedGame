using InvadedGame.Engine;
using InvadedGame.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvadedGame.Game.GamePhases
{
    public class PlanningPhaseController : GameObject, IPhaseController
    {
        public bool IsCompleted { get; } = true;

        public PlanningPhaseController(string name) : base(name) { }

        public void OnEnter(GameWorld world, float deltaTime)
        {
            Console.WriteLine("Entering Planning Phase...");
        }

        public void OnExit(GameWorld world, float deltaTime)
        {
            Console.WriteLine("Exiting Planning Phase...");
        }

        public override void Update(GameWorld world, float deltaTime)
        {
            // Planning logic (UI decisions, etc.)
        }
    }

}
