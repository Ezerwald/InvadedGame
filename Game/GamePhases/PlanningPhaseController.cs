using InvadedGame.Engine;
using InvadedGame.Game.Helpers;
using InvadedGame.Game.Interfaces;

namespace InvadedGame.Game.GamePhases
{
    public class PlanningPhaseController : IPhaseController
    {
        public bool IsCompleted { get; } = true;

        public void OnEnter(GameWorld world, float deltaTime)
        {
            //Logger.LogInfo("Entering Planning Phase...");
        }

        public void OnExit(GameWorld world, float deltaTime)
        {
            //Logger.LogInfo("Exiting Planning Phase...");
        }

        public void Update(GameWorld world, float deltaTime)
        {
            //Logger.LogInfo("Planning phase strategy used");
        }
    }
}
