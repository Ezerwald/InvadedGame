using InvadedGame.Engine;
using InvadedGame.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvadedGame.Game.GamePhases
{
    public class EndPhaseController : GameObject, IPhaseController
    {
        public event Action? EndPhaseCompleted;

        private List<IEndPhaseEffect> endPhaseEffects = new List<IEndPhaseEffect>();
        private int endPhaseSystemsPending = 0;

        public EndPhaseController(string name) : base(name) { }

        public void OnEnter(GameWorld world, float deltaTime)
        {
            Console.WriteLine("Entering End Phase...");

            endPhaseEffects.Clear();

            foreach (var obj in world.Objects)
            {
                if (obj is IEndPhaseEffect effect)
                {
                    endPhaseEffects.Add(effect);
                }
            }

            endPhaseSystemsPending = endPhaseEffects.Count;

            if (endPhaseSystemsPending == 0)
            {
                EndPhaseCompleted?.Invoke();
                return;
            }

            foreach (IEndPhaseEffect obj in endPhaseEffects)
            {
                obj.ExecuteEndPhaseEffect(world, deltaTime);
            }
        }

        public void NotifyEndPhaseEffectFinished()
        {
            endPhaseSystemsPending--;

            if (endPhaseSystemsPending <= 0)
            {
                Console.WriteLine("All End Phase effects finished!");
                EndPhaseCompleted?.Invoke();
            }
        }

        public void OnExit(GameWorld world, float deltaTime)
        {
            Console.WriteLine("Exiting End Phase");
        }
    }
}
