using InvadedGame.Game.Rooms;

namespace InvadedGame.Game.Exceptions
{
    public class MovementException : Exception
    {
        public MovementException(string message) : base(message) { }

        public MovementException(Room from, Room to, string reason)
            : base($"Cannot move from {from.Name} to {to.Name}: {reason}") { }
    }
}
