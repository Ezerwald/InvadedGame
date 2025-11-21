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

        private readonly IPhaseController planningController;
        private readonly IPhaseController executionController;
        private readonly IPhaseController endController;

        private IPhaseController activeController;

        public PhaseManager(
            string name,
            IPhaseController planning,
            IPhaseController execution,
            IPhaseController end)
            : base(name)
        {
            planningController = planning;
            executionController = execution;
            endController = end;

            activeController = planningController;
            activeController.OnEnter(world, 0);

            Console.WriteLine($"PhaseManager: Entering initial phase {CurrentPhase.ToString()}");
        }

        private void SwitchToNextPhase(GameWorld world, float deltaTime)
        {
            activeController.OnExit(world, deltaTime);

            CurrentPhase = CurrentPhase switch
            {
                GamePhase.PlanningPhase => GamePhase.ExecutionPhase,
                GamePhase.ExecutionPhase => GamePhase.EndPhase,
                GamePhase.EndPhase => GamePhase.PlanningPhase,
                _ => CurrentPhase
            };

            activeController = CurrentPhase switch
            {
                GamePhase.PlanningPhase => planningController,
                GamePhase.ExecutionPhase => executionController,
                GamePhase.EndPhase => endController,
                _ => activeController
            };

            Console.WriteLine($"Switched to next Phase: {CurrentPhase.ToString()}");

            activeController.OnEnter(world, deltaTime);
        }


        public override void Update(GameWorld world, float deltaTime)
        {
            base.Update(world, deltaTime);

            if (activeController.IsCompleted)
                SwitchToNextPhase(world, deltaTime);
        }
    }
}
