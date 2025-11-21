using InvadedGame.Engine;
using InvadedGame.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvadedGame.Game.GamePhases
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

        public PhaseManager(string name) : base(name) { }

        public void SwitchToNextPhase(GameWorld world, float deltaTime)
        {
            switch (CurrentPhase)
            {
                case GamePhase.PlanningPhase: CurrentPhase = GamePhase.ExecutionPhase; break;
                case GamePhase.ExecutionPhase: CurrentPhase = GamePhase.EndPhase; break;
                case GamePhase.EndPhase: CurrentPhase = GamePhase.PlanningPhase; break;
            }
        }

        public override void Update(GameWorld world, float deltaTime)
        {
            switch (this.CurrentPhase)
            {
                case GamePhase.PlanningPhase:
                    var planningController = world.FindObjectOfType<PlanningPhaseController>();
                    if (planningController.IsCompleted)
                    {
                        SwitchToNextPhase(world, deltaTime);
                    }
                    break;

                case GamePhase.ExecutionPhase:
                    var executionController = world.FindObjectOfType<ExecutionPhaseController>();
                    if (executionController.IsCompleted)
                    {
                        SwitchToNextPhase(world, deltaTime);
                    }
                    break;
                case GamePhase.EndPhase:
                    var endController = world.FindObjectOfType<EndPhaseController>();
                    if (endController.IsCompleted)
                    {
                        SwitchToNextPhase(world, deltaTime);
                    }
                    break;
            }
        }
    }
}
