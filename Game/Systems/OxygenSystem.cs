using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InvadedGame.Engine;
using InvadedGame.Game.ResourceTrackers;
using InvadedGame.Game.Rooms;

namespace InvadedGame.Game.Systems
{
    public class OxygenSystem : GameObject
    {
        public OxygenSystem(string name) : base(name ){}

        public void Update(GameWorld world, float deltaTime)
        {
            IEnumerable<Room> rooms = world.FindObjectsOfType<Room>();
            foreach (Room room in rooms)
            {
                if ((room is EmptyRoom) && (room.IsOperational == false))
                {
                    OxygenTracker? oxygen = world.FindObjectOfType<OxygenTracker>();
                    if (oxygen != null)
                    {
                        oxygen.SpendOxygen(1);
                    }
                }
            }
        }
    }
}
