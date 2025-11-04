using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvadedGame.Engine.GameWorld
{
    public abstract class GameWorld
    {
        public List<GameObject> Objects { get; } = new List<GameObject>();

        public void AddObjects(GameObject obj) => Objects.Add(obj);

        public void Update(float deltaTime)
        {
            foreach (var obj in Objects)
                if (obj.Active) obj.Update(deltaTime);
        }
    }
}
