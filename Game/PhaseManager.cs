using InvadedGame.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvadedGame.Game
{
    public enum GamePhase
    {
        PlanningPhase,
        ExecutionPhase,
        EndPhase
    }

    public class PhaseManager : GameObject
    {
        public GamePhase CurrentPhase { get; private set; } = GamePhase.PlanningPhase;

        public PhaseManager(string name):base(name) { }

        public override void Update(GameWorld world, float deltaTime)
        {
            if (this.CurrentPhase == GamePhase.PlanningPhase)
            {
                Console.WriteLine("Planning phase happening");
            }
            switch (this.CurrentPhase)
            {
                case GamePhase.PlanningPhase:
                    Console.WriteLine("Planning phase happening");
                    break;
                case GamePhase.ExecutionPhase:
                    Console.WriteLine("Execution phase is happening");
                    break;
                case GamePhase.EndPhase:
                    Console.WriteLine("End phase is happening");
                    break;
            }
        }
    }
}
