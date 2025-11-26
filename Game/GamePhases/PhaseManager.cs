using InvadedGame.Engine;
using InvadedGame.Game.Helpers;
using InvadedGame.Game.Interfaces;
using System.Diagnostics;

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
            GameWorld world,
            IPhaseController planningController,
            IPhaseController executionController,
            IPhaseController endController)
            : base(name)
        {
            this.planningController = planningController;
            this.executionController = executionController;
            this.endController = endController;

            activeController = this.planningController;
            activeController.OnEnter(world, 0);

            Logger.LogInfo($"PhaseManager: Entering initial phase {CurrentPhase.ToString()}");
        }

        private void SwitchToNextPhase(GameWorld world, float deltaTime)
        {
            activeController.OnExit(world, deltaTime);

            GamePhase nextPhase = CurrentPhase switch
            {
                GamePhase.PlanningPhase => GamePhase.ExecutionPhase,
                GamePhase.ExecutionPhase => GamePhase.EndPhase,
                GamePhase.EndPhase => GamePhase.PlanningPhase,
                _ => throw new UnreachableException(),
            };

            activeController = nextPhase switch
            {
                GamePhase.PlanningPhase => planningController,
                GamePhase.ExecutionPhase => executionController,
                GamePhase.EndPhase => endController,
                _ => throw new UnreachableException(),
            };

            Logger.LogInfo($"Switched to next Phase: {nextPhase.ToString()}");

            CurrentPhase = nextPhase;
            activeController.OnEnter(world, deltaTime);
        }


        public override void Update(GameWorld world, float deltaTime)
        {
            base.Update(world, deltaTime);

            activeController.Update(world, deltaTime);

            if (activeController.IsCompleted)
                SwitchToNextPhase(world, deltaTime);
        }
    }
}
