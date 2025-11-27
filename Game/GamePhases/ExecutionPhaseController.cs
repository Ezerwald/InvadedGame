using InvadedGame.Engine;
using InvadedGame.Game.Actors;
using InvadedGame.Game.Helpers;
using InvadedGame.Game.Interfaces;

namespace InvadedGame.Game.GamePhases
{
    public class ExecutionPhaseController : IPhaseController
    {
        public bool IsCompleted { get; private set;  } = false;

        private List<Actor> activeActors = new List<Actor>();
        private int actorsPending = 0;
        private int round = 0;

        public void OnEnter(GameWorld world, float deltaTime)
        {
            round = 0;

            TriggerActorsExecution(world);
            
        }

        public void TriggerActorsExecution(GameWorld world)
        {
            var allActors = world.FindObjectsOfType<Actor>();

            activeActors = allActors.Where(a => a.HasPlannedActions).ToList();

            actorsPending = activeActors.Count;

            if (actorsPending <= 0)
            {
                IsCompleted = true;
                return;
            }

            foreach (var actor in activeActors)
            {
                actor.ActionCompleted += OnActionCompleted;
                actor.StartExecution();
            }

            round++;
        }

        public void OnActionCompleted(Actor actor)
        {
            Logger.Info($"Finishes Round *{round}* action.", actor);
            actorsPending--;
        }

        public void OnExit(GameWorld world, float deltaTime)
        {
            foreach (var actor in activeActors)
            {
                actor.ActionCompleted -= OnActionCompleted;
            }
        }

        public void Update(GameWorld world, float deltaTime)
        {
            if (actorsPending <= 0 && !IsCompleted)
            {
                TriggerActorsExecution(world);
            }
        }
    }
}
