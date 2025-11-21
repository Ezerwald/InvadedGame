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

        private IPhaseController planningController;
        private IPhaseController executionController;
        private IPhaseController endController;

        public PhaseManager(string name,
                            IPhaseController planning,
                            IPhaseController execution,
                            IPhaseController end) 
            : base(name) 
        {
            planningController = planning;
            executionController = execution;
            endController = end;
        }

        public void SwitchToNextPhase(GameWorld world, float deltaTime)

        {
            switch (CurrentPhase)
            {
                case GamePhase.PlanningPhase: CurrentPhase = GamePhase.ExecutionPhase; break;
                case GamePhase.ExecutionPhase: CurrentPhase = GamePhase.EndPhase; break;
                case GamePhase.EndPhase: CurrentPhase = GamePhase.PlanningPhase; break;
            }

            Console.WriteLine("Switched to next Phase TODO (Phase Name)");
        }

        public override void Update(GameWorld world, float deltaTime)
        {
            base.Update(world, deltaTime);

            switch (this.CurrentPhase)
            {
                case GamePhase.PlanningPhase:
                    if (planningController.IsCompleted)
                    {
                        SwitchToNextPhase(world, deltaTime);
                    }
                    break;

                case GamePhase.ExecutionPhase:
                    if (executionController.IsCompleted)
                    {
                        SwitchToNextPhase(world, deltaTime);
                    }
                    break;

                case GamePhase.EndPhase:
                    if (endController.IsCompleted)
                    {
                        SwitchToNextPhase(world, deltaTime);
                    }
                    break;
            }
        }
    }
}
