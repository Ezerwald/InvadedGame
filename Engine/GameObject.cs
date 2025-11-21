using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            Console.WriteLine($"Game object {name} has been successfully created");
        }

        public virtual void Update(GameWorld world, float deltaTime) 
        { 
            Console.WriteLine($"Game object {Name} has been successfully updated");
        }
    }
}
