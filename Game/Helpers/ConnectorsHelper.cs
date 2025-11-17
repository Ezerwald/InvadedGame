using InvadedGame.Engine;
using InvadedGame.Game.Rooms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvadedGame.Game.Helpers
{
    public static class ConnectorsHelper
    {
        public static Connector? GetConnector(Room roomA, Room roomB, GameWorld world)
        {
            IEnumerable<Connector> connectors = world.FindObjectsOfType<Connector>();

            return connectors.FirstOrDefault(connector =>
                (connector.RoomA == roomA && connector.RoomB == roomB) ||
                (connector.RoomA == roomB && connector.RoomB == roomA)
            );
        }
    }
}