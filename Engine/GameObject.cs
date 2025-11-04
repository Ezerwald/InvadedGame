using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvadedGame.Engine.GameObject
{
    public abstract class GameObject
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; }
        public bool Active { get; set; } = true;
        private readonly List<Component> _components = new();

        protected GameObject(string name) 
        {
            Name = name;
        }

        public T? GetComponent<T>() where T : Component =>
            _components.OfType<T>().FirstOrDefault();

        public void AddComponent(Component component)
        {
            component.Owner = this;
            _components.Add(component);
        }

        public virtual void Update(float deltaTime)
        {
            foreach (var c in _components)
                c.Update(deltaTime);
        }

        public override string ToString() => Name;
    }

    public abstract class Component
    {
        public GameObject Owner { get; internal set; }
        public virtual void Update(float deltaTime) { }
    }
}
