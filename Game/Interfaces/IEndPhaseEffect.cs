using InvadedGame.Engine;

namespace InvadedGame.Game.Interfaces
{
    public interface IEndPhaseEffect
    {
        void ExecuteEndPhaseEffect(GameWorld world, float deltaTime);

        event Action<GameObject>? EndPhaseEffectCompleted; 
    }

}
