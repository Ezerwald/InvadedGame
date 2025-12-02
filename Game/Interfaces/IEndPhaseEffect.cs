using InvadedGame.Engine;

namespace InvadedGame.Game.Interfaces
{
    public interface IEndPhaseEffect
    {
        void StartExecution();
        void ExecuteEndPhaseEffect(GameWorld world, float deltaTime);

        event Action<IEndPhaseEffect>? EndPhaseEffectCompleted; 
    }

}
