using InvadedGame.Engine;

namespace InvadedGame.Game.Interfaces
{
    public interface IPhaseController
    {
        bool IsCompleted { get; }
        void OnEnter(GameWorld world, float deltaTime);
        void OnExit(GameWorld world, float deltaTime);

        void Update(GameWorld world, float deltaTime);
    }

}
