using InvadedGame.Engine;
using InvadedGame.Game.Actors;


namespace InvadedGame.Game.Actions
{
    public abstract class GameAction : ICloneable
    {
        public string Name { get; }

        protected GameAction(string name)
        {
            Name = name;
        }

        public abstract void Execute(GameWorld world, Actor actor, float deltaTime);

        public abstract object Clone();
    }
}
