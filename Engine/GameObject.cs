using InvadedGame.Game.Helpers;

namespace InvadedGame.Engine
{
    public abstract class GameObject
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; }
        public bool Active { get; set; } = true;

        protected GameObject(string name) 
        {
            Name = name;
            Logger.LogInfo($"[CREATED OBJECT]: {Name}");
        }
        
        public virtual void Start(GameWorld world)
        {

        }

        public virtual void Update(GameWorld world, float deltaTime) 
        { 
            Logger.LogInfo($"[UPDATED OBJECT]: {Name} ");
        }
    }
}
