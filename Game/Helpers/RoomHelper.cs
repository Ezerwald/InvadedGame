using InvadedGame.Engine;
using InvadedGame.Game.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvadedGame.Game.Helpers
{
    public static class RoomHelper
    {
        public static List<Room> GetConnectedRooms(Room room, GameWorld world)
        {
            var connectors = world.FindObjectsOfType<Connector>();
            var connected = new List<Room>();

            foreach (var c in connectors)
            {
                if (c.RoomA == room) connected.Add(c.RoomB);
                if (c.RoomB == room) connected.Add(c.RoomA);
            }

            return connected;
        }
    }
}
