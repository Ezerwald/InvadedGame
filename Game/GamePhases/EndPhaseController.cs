using InvadedGame.Engine;
using InvadedGame.Game.Helpers;
using InvadedGame.Game.Interfaces;

namespace InvadedGame.Game.GamePhases
{
    public class EndPhaseController : IPhaseController
    {
        public bool IsCompleted { get; private set; } = false;

        private List<IEndPhaseEffect> endPhaseEffects = new List<IEndPhaseEffect>();
        private int endPhaseEffectsPending = 0;

        public void OnEnter(GameWorld world, float deltaTime)
        {
            Logger.Debug("Entering End Phase...");

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
                effect.StartExecution();
            }
        }

        public void OnEffectCompleted(GameObject effect)
        {
            endPhaseEffectsPending--;
        }

        public void OnExit(GameWorld world, float deltaTime)
        {
            Logger.Debug("Exiting End Phase.");

            foreach (var effect in endPhaseEffects)
            {
                effect.EndPhaseEffectCompleted -= OnEffectCompleted;
            }
        }

        public void Update(GameWorld world, float deltaTime)
        {
            if (endPhaseEffectsPending <= 0)
            {
                IsCompleted = true;
            }
        }
    }
}
