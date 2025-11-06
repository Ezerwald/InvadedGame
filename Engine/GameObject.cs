using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public virtual void Update(GameWorld world, float deltaTime) { }
    }
}
