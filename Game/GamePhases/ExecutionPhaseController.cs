using InvadedGame.Engine;
using InvadedGame.Game.Actors;
using InvadedGame.Game.Interfaces;

namespace InvadedGame.Game.GamePhases
{
    public class ExecutionPhaseController : IPhaseController
    {
        public bool IsCompleted { get; private set;  } = false;

        private List<Actor> activeActors = new List<Actor>();
        private int actorsPending = 0;

        public void OnEnter(GameWorld world, float deltaTime)
        {
            Console.WriteLine("Entering Execution Phase...");

            TriggerActorsExecution(world);
            
        }

        public void TriggerActorsExecution(GameWorld world)
        {
            var allActors = world.FindObjectsOfType<Actor>();

            activeActors = allActors.Where(a => a.HasPlannedActions).ToList();

            actorsPending = activeActors.Count;

            if (actorsPending < 0)
            {
                IsCompleted = true;
                return;
            }

            foreach (var actor in activeActors)
            {
                actor.ActionCompleted += OnActorFinished;
                actor.StartExecution();
            }
        }

        public void OnActorFinished(Actor actor)
        {
            Console.WriteLine($"{actor.Name} finished all their actions.");
            actorsPending--;
        }

        public void OnExit(GameWorld world, float deltaTime)
        {
            Console.WriteLine("Exiting Execution Phase.");

            foreach (var actor in activeActors)
            {
                actor.ActionCompleted -= OnActorFinished;
            }
        }

        public void Update(GameWorld world, float deltaTime)
        {
            if (actorsPending < 0 && !IsCompleted)
            {
                TriggerActorsExecution(world);
            }
        }
    }
}
