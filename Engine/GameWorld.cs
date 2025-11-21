using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvadedGame.Engine
{
    public class GameWorld
    {
        public List<GameObject> Objects { get; } = new List<GameObject>();

        public void AddObject(GameObject obj) => Objects.Add(obj);

        public bool Running { get; private set; } = false;

        public void Start()
        {
            Running = true;

            foreach (GameObject obj in Objects)
            {
                obj.Start(this);
            }
        }

        public void Update()
        {
            float deltaTime = 1;

            foreach (var obj in Objects)
            {
                if (!obj.Active)
                {
                    return;
                }

                obj.Update(this, deltaTime);
            }
        }

        public T? FindObjectOfType<T>() where T : GameObject =>
            Objects.OfType<T>().FirstOrDefault();

        public IEnumerable<T> FindObjectsOfType<T>() where T : GameObject =>
            Objects.OfType<T>();
    }
}
