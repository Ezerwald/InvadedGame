using InvadedGame.Engine;
using InvadedGame.Game.Actors;
using InvadedGame.Game.Helpers;
using InvadedGame.Game.Rooms;

namespace InvadedGame.Game.Actions
{
    public class BreakRoomAction : GameAction
    {
        public BreakRoomAction() : base($"Break room action"){}

        public override void Execute(GameWorld world, Actor actor, float deltaTime)
        {
            Room room = actor.CurrentRoom;

            if (room.IsOperational == true)
            {
                room.IsOperational = false;
                Logger.LogInfo($"Room {room.Name} was broken");
            }
            else
            {
                Logger.LogWarning("Room is already broken");
            }
        }
    }
}
