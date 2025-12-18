using InvadedGame.Game.Rooms;

namespace InvadedGame.Game.Extensions
{
    public static class RoomExtensions
    {
        public static void Deconstruct(
            this Room room,
            out string name,
            out bool isOperational)
        {
            name = room.Name;
            isOperational = room.IsOperational;
        }
    }
}
