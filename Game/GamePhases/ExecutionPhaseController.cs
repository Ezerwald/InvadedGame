using InvadedGame.Engine;
using InvadedGame.Game.Actors;
using InvadedGame.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvadedGame.Game.GamePhases
{
    public class ExecutionPhaseController : IPhaseController
    {
        public bool IsCompleted => actorsPending <= 0;

        private List<Actor> actors = new List<Actor>();
        private int actorsPending = 0;

        public void OnEnter(GameWorld world, float deltaTime)
        {
            Console.WriteLine("Entering Execution Phase...");
            actors = world.Objects.OfType<Actor>().ToList();

            actorsPending = actors.Count;

            if (actorsPending == 0)
                return;

            foreach (var actor in actors)
            {
                actor.AllActionsCompleted += OnActorFinished;
            }

            foreach (var actor in actors)
            {
                actor.ExecuteNextAction();
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

            foreach (var actor in actors)
            {
                actor.AllActionsCompleted -= OnActorFinished;
            }
        }
    }
}
