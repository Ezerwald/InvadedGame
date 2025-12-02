using InvadedGame.Engine;
using InvadedGame.Game.Helpers;
using InvadedGame.Game.Interfaces;
using InvadedGame.Game.Menu;
using InvadedGame.InputSystem;

namespace InvadedGame.Game.GamePhases
{
    public class PlanningPhaseController : IPhaseController
    {
        public bool IsCompleted { get; private set; } = false;

        private PlanningStateMachine stateMachine;
        private IMenuRenderer renderer;
        private IInputReader inputReader;

        public void OnEnter(GameWorld world, float deltaTime)
        {
            Logger.Render("Entered Planning Phase");

            IsCompleted = false;

            stateMachine = new PlanningStateMachine(world);
            renderer = new ConsoleMenuRenderer();
            inputReader = new ConsoleInputReader();

            renderer.Render(stateMachine.CurrentMenu);
        }

        public void OnExit(GameWorld world, float deltaTime)
        {   
            Logger.Render("Exited Planning Phase");
            Logger.PauseAndClear();
        }

        public void Update(GameWorld world, float deltaTime)
        {
            if (stateMachine.IsFinished)
            {
                IsCompleted = true;
                return;
            }

            if (inputReader.TryRead(out var input))
            {
                stateMachine.HandleInput(input);
                renderer.Render(stateMachine.CurrentMenu);
            }
        }

    }
}
