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
        public bool IsCompleted => endPhaseEffectsPending <= 0;

        private List<IEndPhaseEffect> endPhaseEffects = new List<IEndPhaseEffect>();
        private int endPhaseEffectsPending = 0;

        public EndPhaseController(string name) : base(name) { }

        public void OnEnter(GameWorld world, float deltaTime)
        {
            Console.WriteLine("Entering End Phase...");

            endPhaseEffects = world.Objects.OfType<IEndPhaseEffect>().ToList();

            endPhaseEffectsPending = endPhaseEffects.Count;

            if (endPhaseEffectsPending == 0)
                return;

            foreach (var effect in endPhaseEffects)
            {
                effect.EndPhaseEffectCompleted += OnEffectCompleted;
            }

            foreach (var effect in endPhaseEffects)
            {
                effect.ExecuteEndPhaseEffect(world, deltaTime);
            }
        }

        public void OnEffectCompleted(GameObject effect)
        {
            Console.WriteLine(effect.Name, " end phase effect completed.");
            endPhaseEffectsPending--;
        }

        public void OnExit(GameWorld world, float deltaTime)
        {
            Console.WriteLine("Exiting End Phase");

            foreach (var effect in endPhaseEffects)
            {
                effect.EndPhaseEffectCompleted -= OnEffectCompleted;
            }
        }
    }
}
