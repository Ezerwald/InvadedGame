using InvadedGame.Engine;
using InvadedGame.Game.Rooms;

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