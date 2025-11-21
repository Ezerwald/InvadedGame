using InvadedGame.Engine;
using InvadedGame.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvadedGame.Game.GamePhases
{
    public class ExecutionPhaseController : GameObject, IPhaseController
    {
        public bool IsCompleted { get; } = true;

        public ExecutionPhaseController(string name) : base(name) { }

        public void OnEnter(GameWorld world, float deltaTime)
        {
            Console.WriteLine("Entering Execution Phase...");
        }

        public void OnExit(GameWorld world, float deltaTime)
        {
            Console.WriteLine("Exiting Execution Phase...");
        }

        public override void Update(GameWorld world, float deltaTime)
        {
            // Execution logic (movement, combat, etc.)
        }
    }
}
